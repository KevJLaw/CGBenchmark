CBBenchmark v1.0.1

CGBenchmark is a Windows application that will iterate through GPU engine and memory clock speeds in order to find the combination
that produces the optimal hash rate on your GPU, using the cgminer RPC API.  It was developed and tested with cgminer 3.7.2.

To use CGBenchmark, first start cgminer on your mining system as you normally would, except add the following two options:

--api-listen --api-allow W:127.0.0.1

This will allow you to run CGBenchmark locally on your mining system.  If you need to run CGBenchmark from a different system,
you will want to replace 127.0.0.1 with the IP address of that system.  Such as:

--api-listen --api-allow W:192.168.1.1

Refer to the API-README.txt file included with cgminer for details on these options.

If you are running CGBenchmark from a different system, you may also have to configure your firewall to allow inbound traffic to 
TCP port 4028.  

After cgminer is running on your mining system, open CGBenchmark.  If you are running it on your mining system, leave the IP
Address as 127.0.0.1.  Otherwise change it to the IP address of your mining system.  Leave the port as 4028.

Select the GPU number you plan to test.  For example, 0, 1, 2, etc.  This number should correspond with the GPU number in cgminer.

Configure the minimum and maximum clock speeds for both engine and memory.  If you only want to test against one of them, uncheck
the one you don't want to test.  If you enable both, it will test against every possible combination of the two clock speeds.

The step value is how large of an increment to use for each clock speed.  For instance, if you set the memory clock minimum to 
1250, the maximum to 1300 and the step to 10, it would test the following memory clock speeds:

1250
1260
1270
1280
1290
1300

The wait value is how long (in seconds) to wait after configuring the engine/memory clock speeds before checking the hash rate.  The
hash rate is the 5s average, so the wait value must be longer than 5 seconds.  Depending on how long your GPU takes for the hash rate 
to settle down, you may need to configure this anywhere from 10 to 60 seconds.

If you specify large ranges with small steps and a long wait time, it can take awhile to test through all the possible combinations.  
For this reason I find that it is best to first test through the ranges you are interested in with larger steps, say 5 or 10.  Once 
you find a range that is producing good hash rates, you can retest a smaller range using smaller steps like 1 or 2 to find the optimal
combination.

Once everything is configured, select File - Start (or hit F5).  CGBenchmark will connect to cgminer and iterate over every engine/memory 
clock speed combination you specified, recording the hash rate each time.  The results are displayed in the results tab, and a timestamped 
log file is also produced in the same directry as CGBenchmark.  The GPU tab will display information about the GPU as reported by cgminer.

You can stop the test at any time by selecting File - Stop (or hit F6), or just close CGBenchmark.

If the GPU becomes unresponsive, or unexpected engine/memory clock speeds are encountered, it will stop the benchmark.  When running
the test you'll want to keep an eye on your mining system in case you push it a little too hard and the GPU becomes unresponsive, in 
which case you may have to restart the mining system and restart the test.

If the test finishes successfully, CGBenchmark will prompt with the engine/memory clock speed that produced the highest hash rate.  You
can review the results tab or the log file for details.

I would recommend running CGBenchmark on a different system than your miner if possible, to ensure the most accurate results.  

If you receive an error that the connection cannot be established, this is likely due to a firewall or other network-related issue.  

If you receive an error that the GPU cannot be contacted, your GPU may not be alive and needs a reboot, or you specified an invalid
GPU number.  View the log file to see the exact message received from the cgminer API.  

If you receive an error stating that it failed to set the engine or memory clock speed, review the log file to see the cgminer message.  
For instance, if it says access was denied, then you may have specified an incorrect IP address in the cgminer command-line options.  
Also, despite what the cgminer API-README.txt states, I have problems when I specify multiple comma-separated IP addresses for the 
--api-allow option.  If you are setting multiple IP's for that option, you might try just setting one and see if that helps.

The current version does not support testing voltage ranges, as I found that undervolting from cgminer doesn't reliably work for me
anyways.  I have always had to use MSI Afterburner or Sapphire Trixx to undervolt the GPU's.

To test multiple GPU's simulatenously, just open multiple instances of CGBenchmark and have each one test a different GPU..

You will need .NET Framework 2.0 or higher in order to run CGBenchmark.

Hopefully you find CGBenchmark useful, and can squeeze a few more Kh/s from your GPU's.  I developed this in my spare time to give back
to the community, so I apologize if you encounter any annoying little bugs.

If you feel like donating, see below.  If not, that's cool too.

BTC: 176MSr5MbDRZkakEar3s8XWz5Gg8eL561R
LTC: LYqpP9EJHqdX2aEpqqQubZtyHzBQtdm6eW
DGC: D9RvkC94WAb2K4WhRQBgsUxH4C2Kvvc8Nf

Enjoy.
