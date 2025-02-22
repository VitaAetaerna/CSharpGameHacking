using System.Diagnostics;
using System;

public class Proc{
	private ProcModify _procModify = new ProcModify(); // Used for the Memory Manipulation
	private string _processName = "Spotify"; // Process Name 

	// Preperation Phase - Get all the basic stuff like Handle, Process ID and so on
	public void GetProcessInfo() {
		var mainProc = GetMainProcess(_processName);
		var procId = mainProc.Id;
		var baseHandle = getBaseHandle(mainProc);
	}

	public Process GetMainProcess(string processName){
		Console.WriteLine("Getting the Process name " + processName);
		var processListSnapshot = Process.GetProcesses(); // Get All Local Running Processes if needed
		var processSnapshot = Process.GetProcessesByName(processName); // Get All Currently Running Processes for the Game Specifically

		// If no process of Game was found -> Exit
		if (processSnapshot == null){
			Console.WriteLine("Could not find the target's Process Name / Process ID"); 
			Environment.Exit(0);		}
 
		// Extract the Main Process that i want to edit and read memory from
		var mainProcess = processSnapshot[0];

		Console.WriteLine("Parent Process is " + mainProcess + " ID: " + mainProcess.Id);


		// Output all the found Processes with the name and its PID -> Also output the main Process + its PID and Output the Main Process and its Base Handle
		for (int i = 0; i<processSnapshot.Length - 1; i++){
			Console.WriteLine("Child Process ID to " + processSnapshot[i + 1] + " is " + processSnapshot[i + 1].Id);
		}
		return mainProcess;
	}

	public nint getBaseHandle(Process mainProcess){
		// Get the base Handle to interact with the Process
		var baseHandle = mainProcess.Handle;
		if (baseHandle == 0){
			Console.WriteLine("Base Handle of Process " + mainProcess + mainProcess.Id + " could not be fetched");
		} 
		Console.WriteLine("Parent Process is " + mainProcess + " Base Handle: " + baseHandle);
		return baseHandle;
	}
}
