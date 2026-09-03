/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	public sealed class Thread : CriticalFinalizerObject // TypeDefIndex: 2589
	{
		// Fields
		private static LocalDataStoreMgr s_LocalDataStoreMgr; // 0x00
		[ThreadStatic]
		private static LocalDataStoreHolder s_LocalDataStore; // 0x80000000
		[ThreadStatic]
		internal static CultureInfo m_CurrentCulture; // 0x80000008
		[ThreadStatic]
		internal static CultureInfo m_CurrentUICulture; // 0x80000010
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentCulture; // 0x08
		private static AsyncLocal<CultureInfo> s_asyncLocalCurrentUICulture; // 0x10
		private InternalThread internal_thread; // 0x10
		private object m_ThreadStartArg; // 0x18
		private object pending_exception; // 0x20
		[ThreadStatic]
		private static Thread current_thread; // 0x80000018
		private MulticastDelegate m_Delegate; // 0x28
		private ExecutionContext m_ExecutionContext; // 0x30
		private bool m_ExecutionContextBelongsToOuterScope; // 0x38
		private IPrincipal principal; // 0x40
		private int principal_version; // 0x48
	
		// Properties
		internal bool ExecutionContextBelongsToCurrentScope { get; set; } // 0x0000000181692330-0x0000000181692340 0x00000001816923E0-0x00000001816923F0
		public CultureInfo CurrentUICulture { get; } // 0x00000001816916B0-0x0000000181691710 
		public CultureInfo CurrentCulture { get; } // 0x0000000181691610-0x0000000181691670 
		private InternalThread Internal { get; } // 0x0000000181692340-0x0000000181692370 
		public static Context CurrentContext { get; } // 0x00000001814B8C70-0x00000001814B8C80 
		public static Thread CurrentThread { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] get; } // 0x00000001816922F0-0x0000000181692330 
		internal static int CurrentThreadId { get; } // 0x00000001816922A0-0x00000001816922F0 
		public bool IsThreadPoolThread { get; } // 0x00000001816923A0-0x00000001816923E0 
		internal bool IsThreadPoolThreadInternal { get; } // 0x00000001816923A0-0x00000001816923E0 
		public bool IsAlive { get; } // 0x0000000181692370-0x00000001816923A0 
		public bool IsBackground { set; } // 0x00000001816923F0-0x00000001816924C0
		public string Name { set; } // 0x00000001816924C0-0x0000000181692520
		public int ManagedThreadId { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000181691750-0x0000000181691780 
	
		// Constructors
		public Thread(ThreadStart start); // 0x00000001816921A0-0x0000000181692220
		public Thread(ParameterizedThreadStart start); // 0x0000000181692220-0x00000001816922A0
		public Thread(ParameterizedThreadStart start, int maxStackSize); // 0x00000001816920A0-0x00000001816921A0
	
		// Methods
		public void Start(); // 0x0000000181691DA0-0x0000000181691DC0
		public void Start(object parameter); // 0x0000000181691F10-0x0000000181691FF0
		private void Start(ref StackCrawlMark stackMark); // 0x0000000181691DC0-0x0000000181691F10
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal ExecutionContext.Reader GetExecutionContextReader(); // 0x0000000181691720-0x0000000181691750
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal ExecutionContext GetMutableExecutionContext(); // 0x0000000181691780-0x0000000181691820
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext value, bool belongsToCurrentScope); // 0x0000000181691980-0x00000001816919C0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal void SetExecutionContext(ExecutionContext.Reader value, bool belongsToCurrentScope); // 0x0000000181691980-0x00000001816919C0
		private bool JoinInternal(int millisecondsTimeout); // 0x00000001816918D0-0x00000001816918E0
		public void Join(); // 0x00000001816918E0-0x00000001816918F0
		public bool Join(int millisecondsTimeout); // 0x00000001816918F0-0x0000000181691980
		private static void SleepInternal(int millisecondsTimeout); // 0x0000000181691C50-0x0000000181691C60
		public static void Sleep(int millisecondsTimeout); // 0x0000000181691C60-0x0000000181691CF0
		private static bool YieldInternal(); // 0x0000000181692090-0x00000001816920A0
		public static bool Yield(); // 0x0000000181692090-0x00000001816920A0
		private void SetStartHelper(Delegate start, int maxStackSize); // 0x0000000181691A20-0x0000000181691BF0
		internal CultureInfo GetCurrentUICultureNoAppX(); // 0x00000001816916B0-0x0000000181691710
		private CultureInfo GetCurrentCultureNoAppX(); // 0x0000000181691610-0x0000000181691670
		public static void MemoryBarrier(); // 0x00000001816812A0-0x00000001816812B0
		private void ConstructInternalThread(); // 0x0000000181691580-0x0000000181691590
		private static void GetCurrentThread_icall(ref Thread thread); // 0x0000000181691670-0x0000000181691680
		private static Thread GetCurrentThread(); // 0x0000000181691680-0x00000001816916B0
		public static int GetDomainID(); // 0x0000000181691710-0x0000000181691720
		private bool Thread_internal(MulticastDelegate start); // 0x0000000181692000-0x0000000181692010
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~Thread(); // 0x0000000181682750-0x00000001816827A0
		private static unsafe void SetName_icall(InternalThread thread, char* name, int nameLength); // 0x00000001816919C0-0x00000001816919D0
		private static void SetName_internal(InternalThread thread, string name); // 0x00000001816919D0-0x0000000181691A20
		private static void SpinWait_nop(); // 0x0000000181539480-0x0000000181539490
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void SpinWait(int iterations); // 0x0000000181691CF0-0x0000000181691D20
		private void StartInternal(object principal, ref StackCrawlMark stackMark); // 0x0000000181691D20-0x0000000181691DA0
		private static void SetState(InternalThread thread, ThreadState set); // 0x0000000181691C40-0x0000000181691C50
		private static void ClrState(InternalThread thread, ThreadState clr); // 0x0000000181691570-0x0000000181691580
		private static ThreadState GetState(InternalThread thread); // 0x00000001816918C0-0x00000001816918D0
		private static int SystemMaxStackStize(); // 0x0000000181691FF0-0x0000000181692000
		private static int GetProcessDefaultStackSize(int maxStackSize); // 0x0000000181691820-0x00000001816918C0
		private void SetStart(MulticastDelegate start, int maxStackSize); // 0x0000000181691BF0-0x0000000181691C40
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void BeginCriticalRegion(); // 0x00000001816914F0-0x0000000181691570
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void EndCriticalRegion(); // 0x0000000181691590-0x0000000181691610
		[ComVisible(false)]
		public override int GetHashCode(); // 0x0000000181691750-0x0000000181691780
		private ThreadState ValidateThreadState(); // 0x0000000181692010-0x0000000181692090
	}
}
