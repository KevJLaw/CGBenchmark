Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class Form1

    Dim IPAddress As String = String.Empty
    Dim Port As String = String.Empty
    Dim GPU As String = String.Empty
    Dim Engine_Min As String = String.Empty
    Dim Engine_Max As String = String.Empty
    Dim Engine_Step As String = String.Empty
    Dim Memory_Min As String = String.Empty
    Dim Memory_Max As String = String.Empty
    Dim Memory_Step As String = String.Empty
    Dim Wait As String = String.Empty

    Dim Running As Boolean = False

    Dim LogFile As String = String.Empty

    Dim BestHash As String = "0"
    Dim BestEngine As String = String.Empty
    Dim BestMemory As String = String.Empty

    Private myThread As Thread
    Dim KillThread As Boolean

    Dim failure As Boolean = False
    Dim failureMessage As String = String.Empty

    Dim AboutWindow As About

    Delegate Sub UpdateUIHandler()
    Delegate Sub UpdateUIHandler_String(ByVal string1 As String)
    Delegate Sub UpdateUIHandler_String_String_String_String(ByVal string1 As String, ByVal string2 As String, ByVal string3 As String, ByVal string4 As String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GPUTimer.Start()
        StopStripMenuItem1.Enabled = False
    End Sub

#Region "Input Functions"

    Private Sub getInput()

        IPAddress = IPAddress_Label.Text.Trim
        Port = Port_Label.Text.Trim
        GPU = GPU_Label.Text.Trim
        Engine_Min = Engine_Min_Label.Text.Trim
        Engine_Max = Engine_Max_Label.Text.Trim
        Engine_Step = Engine_Step_Label.Text.Trim
        Memory_Min = Memory_Min_Label.Text.Trim
        Memory_Max = Memory_Max_Label.Text.Trim
        Memory_Step = Memory_Step_Label.Text.Trim
        Wait = Wait_Label.Text.Trim

        validateInput()

    End Sub

    Private Sub validateInput()

        Dim success As Boolean = True

        If IPAddress = "" Then
            success = False
            MsgBox("Please enter a valid IP Address", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Port) Then
            success = False
            MsgBox("Please enter a valid Port", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(GPU) Then
            success = False
            MsgBox("Please enter a valid GPU", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Engine_Min) Then
            success = False
            MsgBox("Please enter a valid Engine Clock Minimum", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Engine_Max) Then
            success = False
            MsgBox("Please enter a valid Engine Clock Maximum", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Engine_Step) Then
            success = False
            MsgBox("Please enter a valid Engine Clock Step", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Memory_Min) Then
            success = False
            MsgBox("Please enter a valid Memory Clock Minimum", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Memory_Max) Then
            success = False
            MsgBox("Please enter a valid Memory Clock Maximum", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Memory_Step) Then
            success = False
            MsgBox("Please enter a valid Memory Clock Step", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(Wait) Then
            success = False
            MsgBox("Please enter a valid Wait", MsgBoxStyle.Exclamation, "Error")
        End If

        If success Then
            If CInt(Port) <= 0 Then
                success = False
                MsgBox("Please enter a valid Port", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(GPU) < 0 Then
                success = False
                MsgBox("Please enter a valid GPU", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Engine_Min) <= 0 Then
                success = False
                MsgBox("Please enter a valid Engine Clock Minimum", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Engine_Max) <= 0 Then
                success = False
                MsgBox("Please enter a valid Engine Clock Maximum", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Engine_Step) <= 0 Then
                success = False
                MsgBox("Please enter a valid Engine Clock Step", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Memory_Min) <= 0 Then
                success = False
                MsgBox("Please enter a valid Memory Clock Minimum", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Memory_Max) <= 0 Then
                success = False
                MsgBox("Please enter a valid Memory Clock Maximum", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Memory_Step) <= 0 Then
                success = False
                MsgBox("Please enter a valid Memory Clock Step", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Wait) <= 5 Then
                success = False
                MsgBox("Wait must be longer than 5 seconds", MsgBoxStyle.Exclamation, "Error")
            End If

        End If

        If success Then
            If CInt(Engine_Max) <= CInt(Engine_Min) Then
                success = False
                MsgBox("Please enter valid values for Engine Clock", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Engine_Step) > (CInt(Engine_Max) - CInt(Engine_Min)) Then
                success = False
                MsgBox("Please enter valid values for Engine Clock/Step", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Memory_Max) <= CInt(Memory_Min) Then
                success = False
                MsgBox("Please enter valid values for Memory Clock", MsgBoxStyle.Exclamation, "Error")
            ElseIf CInt(Memory_Step) > (CInt(Memory_Max) - CInt(Memory_Min)) Then
                success = False
                MsgBox("Please enter valid values for Memory Clock/Step", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        If Not Enable_Engine_Check.Checked AndAlso Not Enable_Memory_Check.Checked Then
            success = False
            MsgBox("Please enable either Engine or Clock Stepping", MsgBoxStyle.Exclamation, "Error")
        End If

        If success Then
            runBenchmark()
        End If

    End Sub

#End Region

#Region "Benchmark Functions"

    Private Sub runBenchmark()

        logStart()

        Dim memClockMax As Integer = CInt(Memory_Max)
        Dim memClockMin As Integer = CInt(Memory_Min)
        Dim memClockStep As Integer = CInt(Memory_Step)
        Dim memEnable As Boolean = Enable_Memory_Check.Checked
        Dim engClockMax As Integer = CInt(Engine_Max)
        Dim engClockMin As Integer = CInt(Engine_Min)
        Dim engClockStep As Integer = CInt(Engine_Step)
        Dim engEnable As Boolean = Enable_Engine_Check.Checked
        Dim currentHash As String
        Dim currentEngine As String
        Dim currentMemory As String
        Dim currentHW As String
        Dim APIoutput As String = String.Empty

        If Not testConnection(IPAddress, Port, APIoutput) Then
            failure = True
            failureMessage = "Cannot establish a connection to " & IPAddress & ":" & Port
            log(failureMessage)
            log("Error: " & APIoutput)
        ElseIf Not testGPU(GPU, APIoutput) Then
            failure = True
            failureMessage = "GPU " & GPU & " at " & IPAddress & ":" & Port & " cannot be contacted."
            log(failureMessage)
            log("API Output: " & APIoutput)
        End If

        If Not KillThread AndAlso Not failure Then

            If engEnable AndAlso memEnable Then
                For i As Integer = memClockMin To memClockMax Step memClockStep
                    If Not KillThread AndAlso Not failure Then

                        If setMemory(GPU, i.ToString, APIoutput) Then
                            For j As Integer = engClockMin To engClockMax Step engClockStep
                                If Not KillThread AndAlso Not failure Then
                                    If setEngine(GPU, j.ToString, APIoutput) Then
                                        suspend(CInt(Wait))
                                        If Not KillThread AndAlso Not failure Then
                                            If getGPUResults(GPU, currentHash, currentEngine, currentMemory, currentHW, APIoutput) Then
                                                If currentEngine <> j.ToString Then
                                                    failure = True
                                                    failureMessage = "Failed to set engine clock to " & j.ToString & " MHz."
                                                    log(failureMessage)
                                                    log("API Output: " & APIoutput)
                                                ElseIf currentMemory <> i.ToString Then
                                                    failure = True
                                                    failureMessage = "Failed to set memory clock to " & i.ToString & " MHz."
                                                    log(failureMessage)
                                                    log("API Output: " & APIoutput)
                                                Else
                                                    logResult(currentHash, currentEngine, currentMemory, currentHW)
                                                End If
                                            Else
                                                failure = True
                                                failureMessage = "Failed to retrieve details from GPU " & GPU & "."
                                                log(failureMessage)
                                                log("API Output: " & APIoutput)
                                            End If
                                        End If
                                    Else
                                        failure = True
                                        failureMessage = "Failed to set engine clock to " & j.ToString & " MHz."
                                        log(failureMessage)
                                        log("API Output: " & APIoutput)
                                    End If

                                Else
                                    Exit For
                                End If
                            Next
                        Else
                            failure = True
                            failureMessage = "Failed to set memory clock to " & i.ToString & " MHz."
                            log(failureMessage)
                            log("API Output: " & APIoutput)
                        End If
                    Else
                        Exit For
                    End If
                Next

            ElseIf engEnable Then
                For j As Integer = engClockMin To engClockMax Step engClockStep
                    If Not KillThread AndAlso Not failure Then
                        If setEngine(GPU, j.ToString, APIoutput) Then
                            suspend(CInt(Wait))
                            If Not KillThread AndAlso Not failure Then
                                If getGPUResults(GPU, currentHash, currentEngine, currentMemory, currentHW, APIoutput) Then
                                    If currentEngine <> j.ToString Then
                                        failure = True
                                        failureMessage = "Failed to set engine clock to " & j.ToString & " MHz."
                                        log(failureMessage)
                                        log("API Output: " & APIoutput)
                                    Else
                                        logResult(currentHash, currentEngine, currentMemory, currentHW)
                                    End If
                                Else
                                    failure = True
                                    failureMessage = "Failed to retrieve details from GPU " & GPU & "."
                                    log(failureMessage)
                                    log("API Output: " & APIoutput)
                                End If
                            End If
                        Else
                            failure = True
                            failureMessage = "Failed to set engine clock to " & j.ToString & " MHz."
                            log(failureMessage)
                            log("API Output: " & APIoutput)
                        End If
                    Else
                        Exit For
                    End If
                Next

            ElseIf memEnable Then
                For i As Integer = memClockMin To memClockMax Step memClockStep
                    If Not KillThread AndAlso Not failure Then
                        If setMemory(GPU, i.ToString, APIoutput) Then
                            suspend(CInt(Wait))
                            If Not KillThread AndAlso Not failure Then
                                If getGPUResults(GPU, currentHash, currentEngine, currentMemory, currentHW, APIoutput) Then
                                    If currentMemory <> i.ToString Then
                                        failure = True
                                        failureMessage = "Failed to set memory clock to " & i.ToString & " MHz."
                                        log(failureMessage)
                                        log("API Output: " & APIoutput)
                                    Else
                                        logResult(currentHash, currentEngine, currentMemory, currentHW)
                                    End If
                                Else
                                    failure = True
                                    failureMessage = "Failed to retrieve details from GPU " & GPU & "."
                                    log(failureMessage)
                                    log("API Output: " & APIoutput)
                                End If
                            End If
                        Else
                            failure = True
                            failureMessage = "Failed to set memory clock to " & i.ToString & " MHz."
                            log(failureMessage)
                            log("API Output: " & APIoutput)
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
        End If

        logStop()

    End Sub

    Sub suspend(ByVal intSeconds As Integer)
        For k As Integer = 0 To intSeconds
            If Not KillThread Then
                Thread.Sleep(1000)
            End If
        Next
    End Sub

    Sub updateGPUItem(ByVal index As Integer, ByVal parameter As String, ByVal value As String)

        Dim myGPUItem(1) As String
        myGPUItem(0) = parameter
        myGPUItem(1) = value
        Dim myItem As New ListViewItem(myGPUItem)

        GPU_ListView.Items(index) = myItem

    End Sub

    Private Sub updateUI_result(ByVal engine As String, ByVal memory As String, ByVal hash As String, ByVal hw As String)
        Dim handler As New UpdateUIHandler_String_String_String_String(AddressOf updateUI_result_async)
        Dim args() As Object = {engine, memory, hash, hw}
        Me.BeginInvoke(handler, args)
    End Sub

    Private Sub updateUI_result_async(ByVal engine As String, ByVal memory As String, ByVal hash As String, ByVal hw As String)
        Dim myResult(3) As String
        myResult(0) = engine
        myResult(1) = memory
        myResult(2) = hash
        myResult(3) = hw
        Dim myItem As New ListViewItem(myResult)
        Results_ListView.Items.Add(myItem)
        Results_ListView.EnsureVisible(Results_ListView.Items.Count - 1)
        Results_ListView.Update()
    End Sub

    Private Sub refreshGPUInfo(ByVal gpuNumber As String)
        Dim handler As New UpdateUIHandler_String(AddressOf getGPUStats)
        Dim args() As Object = {gpuNumber}
        Me.BeginInvoke(handler, args)
    End Sub

#End Region

#Region "API Functions"

    Private Function testConnection(ByVal ip As String, ByVal prt As String, ByRef debug As String) As Boolean

        Dim success As Boolean = False

        Try
            Dim s As Socket = ConnectSocket(ip, CInt(prt))
            If Not s Is Nothing Then
                s.Shutdown(SocketShutdown.Both)
                s.Close()
                success = True
            Else
                debug = "Connection failed"
            End If
        Catch ex As Exception
            debug = Replace(ex.Message, vbCrLf, " ")
        End Try

        Return success

    End Function

    Private Function testGPU(ByVal gpuNumber As String, ByRef debug As String) As Boolean

        Dim success As Boolean = False
        Dim value As String = String.Empty

        value = String.Empty
        value = SocketSendReceive(IPAddress, CInt(Port), "gpu", gpuNumber)
        debug = value

        If getParameter(value, "Status").ToUpper = "Alive".ToUpper Then
            success = True
        End If

        Return success

    End Function

    Private Function getGPUResults(ByVal gpuNumber As String, ByRef hash As String, ByRef engine As String, ByRef memory As String, ByRef hw As String, ByRef debug As String) As Boolean

        Dim success As Boolean = False
        Dim value As String = String.Empty

        value = String.Empty
        value = SocketSendReceive(IPAddress, CInt(Port), "gpu", gpuNumber)
        debug = value

        hash = String.Empty
        engine = String.Empty
        memory = String.Empty
        hw = String.Empty
        hash = getParameter(value, "MHS 5s")
        engine = getParameter(value, "GPU Clock")
        memory = getParameter(value, "Memory Clock")
        hw = getParameter(value, "Hardware Errors")

        If hash <> String.Empty AndAlso engine <> String.Empty AndAlso memory <> String.Empty Then
            success = True
        End If

        Return success

    End Function

    Private Sub getGPUStats(ByVal gpuNumber As String)

        Dim success As Boolean = False
        Dim value As String = String.Empty

        value = SocketSendReceive(IPAddress, CInt(Port), "gpu", gpuNumber)

        If value <> String.Empty AndAlso value <> "Connection failed" Then

            GPU_ListView.BeginUpdate()
            updateGPUItem(0, "Enabled", getParameter(value, "Enabled"))
            updateGPUItem(1, "Status", getParameter(value, "Status"))
            updateGPUItem(2, "Temperature", getParameter(value, "Temperature"))
            updateGPUItem(3, "Fan Speed", getParameter(value, "Fan Speed"))
            updateGPUItem(4, "Fan Percent", getParameter(value, "Fan Percent"))
            updateGPUItem(5, "GPU Clock", getParameter(value, "GPU Clock"))
            updateGPUItem(6, "Memory Clock", getParameter(value, "Memory Clock"))
            updateGPUItem(7, "GPU Voltage", getParameter(value, "GPU Voltage"))
            updateGPUItem(8, "GPU Activity", getParameter(value, "GPU Activity"))
            updateGPUItem(9, "Powertune", getParameter(value, "Powertune"))
            updateGPUItem(10, "MHS av", getParameter(value, "MHS av"))
            updateGPUItem(11, "MHS 5s", getParameter(value, "MHS 5s"))
            updateGPUItem(12, "Accepted", getParameter(value, "Accepted"))
            updateGPUItem(13, "Rejected", getParameter(value, "Rejected"))
            updateGPUItem(14, "Hardware Errors", getParameter(value, "Hardware Errors"))
            updateGPUItem(15, "Utility", getParameter(value, "Utility"))
            updateGPUItem(16, "Intensity", getParameter(value, "Intensity"))
            updateGPUItem(17, "Last Share Pool", getParameter(value, "Last Share Pool"))
            updateGPUItem(18, "Last Share Time", getParameter(value, "Last Share Time"))
            updateGPUItem(19, "Total MH", getParameter(value, "Total MH"))
            updateGPUItem(20, "Diff1 Work", getParameter(value, "Diff1 Work"))
            updateGPUItem(21, "Difficulty Accepted", getParameter(value, "Difficulty Accepted"))
            updateGPUItem(22, "Difficulty Rejected", getParameter(value, "Difficulty Rejected"))
            updateGPUItem(23, "Last Share Difficulty", getParameter(value, "Last Share Difficulty"))
            updateGPUItem(24, "Last Valid Work", getParameter(value, "Last Valid Work"))
            updateGPUItem(25, "Device Hardware", getParameter(value, "Device Hardware%"))
            updateGPUItem(26, "Device Rejected", getParameter(value, "Device Rejected%"))
            GPU_ListView.EndUpdate()

        End If

    End Sub

    Private Function setEngine(ByVal gpuNumber As String, ByVal clock As String, ByRef debug As String) As Boolean

        Dim success As Boolean = False
        Dim value As String = String.Empty
        Dim msg As String = String.Empty

        value = SocketSendReceive(IPAddress, CInt(Port), "gpuengine", gpuNumber & "," & clock)
        msg = getParameter(value, "Msg")
        debug = value

        If InStr(msg.ToUpper, "reported success".ToUpper) > 0 Then
            success = True
        End If

        Return success

    End Function

    Private Function setMemory(ByVal gpuNumber As String, ByVal clock As String, ByRef debug As String) As Boolean

        Dim success As Boolean = False
        Dim value As String = String.Empty
        Dim msg As String = String.Empty

        value = SocketSendReceive(IPAddress, CInt(Port), "gpumem", gpuNumber & "," & clock)
        msg = getParameter(value, "Msg")
        debug = value

        If InStr(msg.ToUpper, "reported success".ToUpper) > 0 Then
            success = True
        End If

        Return success

    End Function

    Private Function getParameter(ByVal result As String, ByVal param As String) As String

        Dim commaSplit() As String = Split(result, ",")
        Dim colonSplit() As String
        Dim parameter As String = String.Empty
        Dim value As String = String.Empty
        Dim returnValue As String = String.Empty

        For Each item As String In commaSplit
            If InStr(item, "{") = 0 AndAlso InStr(item, "}") = 0 Then
                colonSplit = Split(item, ":")
                If UBound(colonSplit) = 1 Then
                    parameter = Replace(colonSplit(0), """", "")
                    value = Replace(colonSplit(1), """", "")
                    If parameter = param Then
                        returnValue = value
                        Exit For
                    End If
                End If
            End If

        Next

        Return returnValue

    End Function

#End Region

#Region "Start/Stop Functions"

    Private Sub Start()
        If Not Running Then
            If Not myThread Is Nothing Then
                myThread.Abort()
                myThread.Join()
                myThread = Nothing
            End If
            myThread = New Thread(AddressOf startBenchmark_async)
            myThread.IsBackground = True
            myThread.Start()
        End If
    End Sub

    Private Sub startBenchmark_async()
        updateUI_started_async()
        resetStartValues()
        getInput()
        If Not KillThread Then show_summary_prompt()
        Reset()
    End Sub

    Private Sub resetStartValues()
        Running = True
        KillThread = False
        LogFile = "cgbenchmark_" & Replace(Replace(Now().ToString, ":", "_"), "/", "_") & ".log"
        BestHash = "0"
        BestEngine = String.Empty
        BestMemory = String.Empty
        failure = False
        failureMessage = String.Empty
    End Sub

    Private Sub updateUI_started_async()
        Dim handler As New UpdateUIHandler(AddressOf updateUI_started)
        Me.BeginInvoke(handler)
    End Sub

    Private Sub updateUI_started()
        StartToolStripMenuItem.Enabled = False
        StopStripMenuItem1.Enabled = True
        ToolStripStatusLabel1.Text = "Running..."
        IPAddress_Label.Enabled = False
        Port_Label.Enabled = False
        GPU_Label.Enabled = False
        Engine_Min_Label.Enabled = False
        Engine_Max_Label.Enabled = False
        Engine_Step_Label.Enabled = False
        Memory_Min_Label.Enabled = False
        Memory_Max_Label.Enabled = False
        Memory_Step_Label.Enabled = False
        Enable_Engine_Check.Enabled = False
        Enable_Memory_Check.Enabled = False
        Wait_Label.Enabled = False
        initGPUListView()
        Me.Refresh()
    End Sub

    Private Sub initGPUListView()
        Results_ListView.Items.Clear()
        For i As Integer = 0 To 26
            GPU_ListView.Items.Add(New ListViewItem)
        Next
    End Sub

    Private Sub show_summary_prompt()
        Dim handler As New UpdateUIHandler(AddressOf show_summary_prompt_async)
        Me.BeginInvoke(handler)
    End Sub

    Private Sub show_summary_prompt_async()
        If failure Then
            MsgBox(failureMessage, MsgBoxStyle.Exclamation, "Error")
        Else
            If IsNumeric(BestHash) AndAlso CDbl(BestHash) > 0 Then
                log("Best:" & vbTab & "Eng: " & BestEngine & vbTab & "Mem: " & BestMemory & vbTab & "Hash: " & BestHash & " Mh/s")
                MsgBox("Best:" & vbTab & "Eng: " & BestEngine & vbTab & "Mem: " & BestMemory & vbTab & "Hash: " & BestHash & " Mh/s", MsgBoxStyle.Information, "Finished")
            End If
        End If
    End Sub

    Private Sub Stop_Running()
        KillThread = True
        log("Stop Benchmark")
    End Sub

    Private Sub Reset()
        Running = False
        updateUI_stopped()
    End Sub

    Private Sub updateUI_stopped()
        Dim handler As New UpdateUIHandler(AddressOf updateUI_stopped_async)
        Me.BeginInvoke(handler)
    End Sub

    Private Sub updateUI_stopped_async()
        StartToolStripMenuItem.Enabled = True
        StopStripMenuItem1.Enabled = False
        ViewLogToolStripMenuItem.Enabled = True
        ToolStripStatusLabel1.Text = ""
        IPAddress_Label.Enabled = True
        Port_Label.Enabled = True
        GPU_Label.Enabled = True
        If Enable_Engine_Check.Checked Then
            Engine_Min_Label.Enabled = True
            Engine_Max_Label.Enabled = True
            Engine_Step_Label.Enabled = True
        End If
        If Enable_Memory_Check.Checked Then
            Memory_Min_Label.Enabled = True
            Memory_Max_Label.Enabled = True
            Memory_Step_Label.Enabled = True
        End If
        Enable_Engine_Check.Enabled = True
        Enable_Memory_Check.Enabled = True
        Wait_Label.Enabled = True
        GPU_ListView.Items.Clear()
        Me.Refresh()
    End Sub

#End Region

#Region "Menu Functions"

    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        Start()
    End Sub

    Private Sub StopStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopStripMenuItem1.Click
        Stop_Running()
    End Sub

    Private Sub QuitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem2.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        ShowAbout()
    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLogToolStripMenuItem.Click
        If LogFile <> String.Empty Then
            Try
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = "notepad.exe"
                myProcess.StartInfo.Arguments = LogFile
                myProcess.Start()
            Catch Err As Exception
                MsgBox("Error accessing log file: " & LogFile, MsgBoxStyle.Information, "Error")
            End Try
        Else
            MsgBox("No log file has been produced yet.", MsgBoxStyle.Information, "Error")
        End If
    End Sub

#End Region

#Region "Socket Functions"

    Private Function ConnectSocket(ByVal server As String, ByVal serverPort As Integer) As Socket
        Dim s As Socket = Nothing

        Try

            Dim address As IPAddress = System.Net.IPAddress.Parse(server)
            Dim endPoint As New IPEndPoint(address, serverPort)
            Dim tempSocket As New Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            tempSocket.Connect(endPoint)

            If tempSocket.Connected Then
                s = tempSocket
            End If

        Catch ex As Exception
        End Try

        Return s

    End Function

    Private Function SocketSendReceive(ByVal server As String, ByVal port As Integer, ByVal command As String, ByVal parameters As String) As String
        Dim page As [String] = String.Empty

        Try

            Dim ascii As Encoding = Encoding.ASCII
            Dim bytesSent As [Byte]() = ascii.GetBytes("{""command"":""" & command & """,""parameter"":""" & parameters & """}")
            Dim bytesReceived(4096) As [Byte]

            Dim s As Socket = ConnectSocket(server, port)

            If Not s Is Nothing Then
                s.Send(bytesSent, bytesSent.Length, 0)
                Dim bytes As Int32

                Do
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0)
                    page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes)
                Loop While bytes > 0

                s.Shutdown(SocketShutdown.Both)
                s.Close()
            Else
                page = "Connection failed"
            End If

        Catch ex As Exception
            Return page
        End Try

        Return page

    End Function

#End Region

#Region "Log Functions"

    Private Sub logStart()
        log("Start Benchmark")
        log("Settings:")
        log("Socket: " & IPAddress & ":" & Port)
        log("GPU: " & GPU)
        log("Engine Clock: " & Engine_Min & "-" & Engine_Max & ", Step " & Engine_Step)
        log("Memory Clock: " & Memory_Min & "-" & Memory_Max & ", Step " & Memory_Step)
        log("Wait: " & Wait)
    End Sub

    Private Sub logResult(ByVal hash As String, ByVal engine As String, ByVal memory As String, ByVal hw As String)
        If IsNumeric(hash) Then
            If CDbl(hash) > CDbl(BestHash) Then
                BestHash = hash
                BestEngine = engine
                BestMemory = memory
            End If
        End If
        log("Eng: " & engine & vbTab & "Mem: " & memory & vbTab & "Hash: " & hash & " Mh/s" & vbTab & "HW: " & hw)
        updateUI_result(engine, memory, hash, hw)
    End Sub

    Private Sub logStop()
        log("Finish")
    End Sub

    Public Sub log(ByVal entry As String)
        Try
            Using sw As StreamWriter = New StreamWriter(LogFile, True)
                sw.WriteLine(Now() & vbTab & entry)
                sw.Flush()
                sw.Close()
            End Using

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "About Functions"

    Private Sub ShowAbout()
        Try
            If Not AboutWindow Is Nothing Then
                AboutWindow.Close()
            End If

            AboutWindow = New About
            AboutWindow.Show()

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Checkbox Functions"

    Private Sub Enable_Engine_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enable_Engine_Check.CheckedChanged
        If Enable_Engine_Check.Checked Then
            Engine_Min_Label.Enabled = True
            Engine_Max_Label.Enabled = True
            Engine_Step_Label.Enabled = True
        Else
            Engine_Min_Label.Enabled = False
            Engine_Max_Label.Enabled = False
            Engine_Step_Label.Enabled = False
        End If
    End Sub

    Private Sub Enable_Memory_Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enable_Memory_Check.CheckedChanged
        If Enable_Memory_Check.Checked Then
            Memory_Min_Label.Enabled = True
            Memory_Max_Label.Enabled = True
            Memory_Step_Label.Enabled = True
        Else
            Memory_Min_Label.Enabled = False
            Memory_Max_Label.Enabled = False
            Memory_Step_Label.Enabled = False
        End If
    End Sub

#End Region

#Region "Timer Functions"

    Private Sub GPUTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GPUTimer.Tick
        If Running Then
            If Not KillThread AndAlso Not failure Then
                If GPU <> String.Empty AndAlso IsNumeric(GPU) Then
                    refreshGPUInfo(GPU)
                End If
            End If
        End If
    End Sub

#End Region


End Class
