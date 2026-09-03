/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[Serializable]
	public sealed class ExecutionContext : IDisposable, ISerializable // TypeDefIndex: 2577
	{
		// Fields
		private SynchronizationContext _syncContext; // 0x10
		private SynchronizationContext _syncContextNoFlow; // 0x18
		private LogicalCallContext _logicalCallContext; // 0x20
		private IllogicalCallContext _illogicalCallContext; // 0x28
		private Flags _flags; // 0x30
		private Dictionary<IAsyncLocal, object> _localValues; // 0x38
		private List<IAsyncLocal> _localChangeNotifications; // 0x40
		private static readonly ExecutionContext s_dummyDefaultEC; // 0x00
		internal static readonly ExecutionContext Default; // 0x08
	
		// Properties
		internal bool isNewCapture { get; set; } // 0x000000018166F670-0x000000018166F680 0x000000018166F6A0-0x000000018166F6C0
		internal bool isFlowSuppressed { get; set; } // 0x000000018166F660-0x000000018166F670 0x000000018166F680-0x000000018166F6A0
		internal bool IsPreAllocatedDefault { get; } // 0x000000018166F5E0-0x000000018166F5F0 
		internal LogicalCallContext LogicalCallContext { get; set; } // 0x000000018166F5F0-0x000000018166F660 0x000000018033E830-0x000000018033E840
		internal IllogicalCallContext IllogicalCallContext { get; set; } // 0x000000018166F570-0x000000018166F5E0 0x000000018033E840-0x000000018033E850
		internal SynchronizationContext SynchronizationContext { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal SynchronizationContext SynchronizationContextNoFlow { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		private enum Flags // TypeDefIndex: 2578
		{
			None = 0,
			IsNewCapture = 1,
			IsFlowSuppressed = 2,
			IsPreAllocatedDefault = 4
		}
	
		internal struct Reader // TypeDefIndex: 2579
		{
			// Fields
			private ExecutionContext m_ec; // 0x00
	
			// Properties
			public bool IsNull { get; } // 0x0000000180E87410-0x0000000180E87420 
			public bool IsFlowSuppressed { get; } // 0x0000000181672900-0x0000000181672920 
			public SynchronizationContext SynchronizationContext { get; } // 0x0000000181672980-0x00000001816729A0 
			public SynchronizationContext SynchronizationContextNoFlow { get; } // 0x0000000181672960-0x0000000181672980 
			public LogicalCallContext.Reader LogicalCallContext { get; } // 0x0000000181672920-0x0000000181672960 
	
			// Constructors
			public Reader(ExecutionContext ec); // 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public ExecutionContext DangerousGetRawExecutionContext(); // 0x00000001808BADD0-0x00000001808BADE0
			public bool IsDefaultFTContext(bool ignoreSyncCtx); // 0x00000001816728A0-0x0000000181672900
			public object GetLocalValue(IAsyncLocal local); // 0x00000001816727F0-0x0000000181672870
			public bool HasSameLocalValues(ExecutionContext other); // 0x0000000181672870-0x00000001816728A0
		}
	
		[Flags]
		internal enum CaptureOptions // TypeDefIndex: 2580
		{
			None = 0,
			IgnoreSyncCtx = 1,
			OptimizeDefaultCase = 2
		}
	
		// Constructors
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal ExecutionContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal ExecutionContext(bool isPreAllocatedDefault); // 0x000000018166F400-0x000000018166F430
		private ExecutionContext(SerializationInfo info, StreamingContext context); // 0x000000018166F430-0x000000018166F570
		static ExecutionContext(); // 0x000000018166F340-0x000000018166F400
	
		// Methods
		internal static object GetLocalValue(IAsyncLocal local); // 0x000000018166E490-0x000000018166E520
		internal static void SetLocalValue(IAsyncLocal local, object newValue, bool needChangeNotifications); // 0x000000018166F090-0x000000018166F340
		[HandleProcessCorruptedStateExceptions]
		internal static void OnAsyncLocalContextChanged(ExecutionContext previous, ExecutionContext current); // 0x000000018166E690-0x000000018166EA20
		public void Dispose(); // 0x00000001809CF740-0x00000001809CF750
		public static void Run(ExecutionContext executionContext, ContextCallback callback, object state); // 0x000000018166EDB0-0x000000018166EF20
		[FriendAccessAllowed]
		internal static void Run(ExecutionContext executionContext, ContextCallback callback, object state, bool preserveSyncCtx); // 0x000000018166ED20-0x000000018166EDB0
		internal static void RunInternal(ExecutionContext executionContext, ContextCallback callback, object state); // 0x000000018166ECA0-0x000000018166ED20
		[HandleProcessCorruptedStateExceptions]
		internal static void RunInternal(ExecutionContext executionContext, ContextCallback callback, object state, bool preserveSyncCtx); // 0x000000018166EA20-0x000000018166ECA0
		internal static void EstablishCopyOnWriteScope(ref ExecutionContextSwitcher ecsw); // 0x000000018166E330-0x000000018166E3D0
		private static void EstablishCopyOnWriteScope(Thread currentThread, bool knownNullWindowsIdentity, ref ExecutionContextSwitcher ecsw); // 0x000000018166E3D0-0x000000018166E440
		[HandleProcessCorruptedStateExceptions]
		internal static ExecutionContextSwitcher SetExecutionContext(ExecutionContext executionContext, bool preserveSyncCtx); // 0x000000018166EF20-0x000000018166F090
		public ExecutionContext CreateCopy(); // 0x000000018166DFF0-0x000000018166E180
		internal ExecutionContext CreateMutableCopy(); // 0x000000018166E180-0x000000018166E330
		public static bool IsFlowSuppressed(); // 0x000000018166E650-0x000000018166E690
		public static ExecutionContext Capture(); // 0x000000018166DFA0-0x000000018166DFF0
		[FriendAccessAllowed]
		internal static ExecutionContext FastCapture(); // 0x000000018166E440-0x000000018166E490
		internal static ExecutionContext Capture(ref StackCrawlMark stackMark, CaptureOptions options); // 0x000000018166DDA0-0x000000018166DFA0
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018166E520-0x000000018166E600
		internal bool IsDefaultFTContext(bool ignoreSyncCtx); // 0x000000018166E600-0x000000018166E650
	}
}
