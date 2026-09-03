/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	[DefaultEvent("Exited")]
	[DefaultProperty("StartInfo")]
	[MonitoringDescription("Provides access to local and remote processes, enabling starting and stopping of local processes.")]
	public class Process : Component // TypeDefIndex: 8739
	{
		// Fields
		private bool haveProcessId; // 0x28
		private int processId; // 0x2C
		private bool haveProcessHandle; // 0x30
		private SafeProcessHandle m_processHandle; // 0x38
		private bool isRemoteMachine; // 0x40
		private string machineName; // 0x48
		private int m_processAccess; // 0x50
		private ProcessThreadCollection threads; // 0x58
		private ProcessModuleCollection modules; // 0x60
		private bool haveWorkingSetLimits; // 0x68
		private bool havePriorityClass; // 0x69
		private bool watchForExit; // 0x6A
		private bool watchingForExit; // 0x6B
		private EventHandler onExited; // 0x70
		private bool exited; // 0x78
		private int exitCode; // 0x7C
		private bool signaled; // 0x80
		private bool haveExitTime; // 0x81
		private bool raisedOnExited; // 0x82
		private RegisteredWaitHandle registeredWaitHandle; // 0x88
		private WaitHandle waitHandle; // 0x90
		private ISynchronizeInvoke synchronizingObject; // 0x98
		private StreamReader standardOutput; // 0xA0
		private StreamWriter standardInput; // 0xA8
		private StreamReader standardError; // 0xB0
		private bool disposed; // 0xB8
		private StreamReadMode outputStreamReadMode; // 0xBC
		private StreamReadMode errorStreamReadMode; // 0xC0
		private StreamReadMode inputStreamReadMode; // 0xC4
		internal AsyncStreamReader output; // 0xC8
		internal AsyncStreamReader error; // 0xD0
		private string process_name; // 0xD8
	
		// Properties
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MonitoringDescription("Indicates if the process component is associated with a real process.")]
		private bool Associated { get; } // 0x0000000181B78860-0x0000000181B78870 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MonitoringDescription("Indicates if the associated process has been terminated.")]
		public bool HasExited { get; } // 0x0000000181B78870-0x0000000181B78BF0 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MonitoringDescription("The unique identifier for the process.")]
		public int Id { get; } // 0x0000000181B78BF0-0x0000000181B78C10 
		[Browsable(false)]
		[DefaultValue(null)]
		[MonitoringDescription("The object used to marshal the event handler calls issued as a result of a Process exit.")]
		public ISynchronizeInvoke SynchronizingObject { get; } // 0x0000000181B78E80-0x0000000181B78FF0 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MonitoringDescription("The handle of the main window of the process.")]
		public IntPtr MainWindowHandle { get; } // 0x0000000181B78C10-0x0000000181B78C20 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MonitoringDescription("The name of this process.")]
		public string ProcessName { get; } // 0x0000000181B78C20-0x0000000181B78E80 
	
		// Nested types
		private enum StreamReadMode // TypeDefIndex: 8740
		{
			undefined = 0,
			syncMode = 1,
			asyncMode = 2
		}
	
		private enum State // TypeDefIndex: 8741
		{
			HaveId = 1,
			IsLocal = 2,
			IsNt = 4,
			HaveProcessInfo = 8,
			HaveNtProcessInfo = 12,
			Exited = 16,
			Associated = 32,
			IsWin2k = 64
		}
	
		// Constructors
		private Process(string machineName, bool isRemoteMachine, int processId, ProcessInfo processInfo); // 0x0000000181B787C0-0x0000000181B78860
	
		// Methods
		private void ReleaseProcessHandle(SafeProcessHandle handle); // 0x0000000181B78580-0x0000000181B785A0
		protected override void Dispose(bool disposing); // 0x0000000181B77A00-0x0000000181B77A50
		public void Close(); // 0x0000000181B777D0-0x0000000181B77A00
		private void EnsureState(State state); // 0x0000000181B77A50-0x0000000181B77CD0
		public static Process GetCurrentProcess(); // 0x0000000181B77CD0-0x0000000181B77DA0
		protected void OnExited(); // 0x0000000181B78120-0x0000000181B78380
		private SafeProcessHandle GetProcessHandle(int access, bool throwIfExited); // 0x0000000181B77DA0-0x0000000181B78100
		private SafeProcessHandle GetProcessHandle(int access); // 0x0000000181B78100-0x0000000181B78110
		public void Refresh(); // 0x0000000181B78530-0x0000000181B78580
		private void StopWatchingForExit(); // 0x0000000181B785A0-0x0000000181B786C0
		public override string ToString(); // 0x0000000181B786C0-0x0000000181B787C0
		private static IntPtr MainWindowHandle_icall(int pid); // 0x0000000181B78110-0x0000000181B78120
		private static string ProcessName_icall(IntPtr handle); // 0x0000000181B78380-0x0000000181B78390
		private static string ProcessName_internal(SafeProcessHandle handle); // 0x0000000181B78390-0x0000000181B78470
		private void RaiseOnExited(); // 0x0000000181B78470-0x0000000181B78530
	}
}
