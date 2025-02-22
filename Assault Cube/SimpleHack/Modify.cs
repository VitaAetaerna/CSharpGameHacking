using System.Runtime.InteropServices; 
using System; 

public class ProcModify{
	// This Class is used for the manipulation and modification of the Process / Memory
	// Read Process Memory and Write Process Memory is a Method from Kernel32.dll

		// Import the Dll
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool ReadProcessMemory(
		IntPtr hProcess, // Handle to Process
		IntPtr lpBaseAdress, // Base Memory Adress to modify
		out byte[] lpBuffer, // The Buffer the read data is stored in
		int dwSize, // The Size of the buffer - Depending on the Size of the alue Read (int, short...)
		out IntPtr lpNumberOfBytesRead // How many Bytes got read to get the value
		);

	// Import the Dll
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(
		IntPtr hProcess, // Handle to Process
		IntPtr lpBaseAdress, // Base Memory Adresss to modify
		byte[] lpBuffer, // Value to Write
		int dwSize, // Buffer Size in Bytes
		out IntPtr lpNumbersOfBytesWritten // Written bytes
		);
}
