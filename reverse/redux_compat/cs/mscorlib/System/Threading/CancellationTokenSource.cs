/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	public class CancellationTokenSource : IDisposable // TypeDefIndex: 2550
	{
		// Fields
		internal static readonly CancellationTokenSource s_canceledSource; // 0x00
		internal static readonly CancellationTokenSource s_neverCanceledSource; // 0x08
		private static readonly int s_nLists; // 0x10
		private ManualResetEvent _kernelEvent; // 0x10
		private SparselyPopulatedArray<CancellationCallbackInfo>[] _registeredCallbacksLists; // 0x18
		private int _state; // 0x20
		private int _threadIDExecutingCallbacks; // 0x24
		private bool _disposed; // 0x28
		private CancellationCallbackInfo _executingCallback; // 0x30
		private Timer _timer; // 0x38
		private static readonly TimerCallback s_timerCallback; // 0x18
	
		// Properties
		public bool IsCancellationRequested { get; } // 0x0000000181665CA0-0x0000000181665CC0 
		internal bool IsCancellationCompleted { get; } // 0x0000000181665C80-0x0000000181665CA0 
		internal bool IsDisposed { get; } // 0x0000000180327270-0x0000000180327280 
		internal int ThreadIDExecutingCallbacks { get; set; } // 0x0000000181665CC0-0x0000000181665CE0 0x0000000181665D50-0x0000000181665D80
		public CancellationToken Token { get; } // 0x0000000181665CE0-0x0000000181665D50 
		internal CancellationCallbackInfo ExecutingCallback { get; } // 0x0000000181579240-0x0000000181579260 
	
		// Nested types
		private sealed class Linked1CancellationTokenSource : CancellationTokenSource // TypeDefIndex: 2551
		{
			// Fields
			private readonly CancellationTokenRegistration _reg1; // 0x40
	
			// Constructors
			internal Linked1CancellationTokenSource(CancellationToken token1); // 0x000000018166F770-0x000000018166F8C0
	
			// Methods
			protected override void Dispose(bool disposing); // 0x000000018166F730-0x000000018166F770
		}
	
		private sealed class Linked2CancellationTokenSource : CancellationTokenSource // TypeDefIndex: 2552
		{
			// Fields
			private readonly CancellationTokenRegistration _reg1; // 0x40
			private readonly CancellationTokenRegistration _reg2; // 0x58
	
			// Constructors
			internal Linked2CancellationTokenSource(CancellationToken token1, CancellationToken token2); // 0x000000018166F910-0x000000018166FAE0
	
			// Methods
			protected override void Dispose(bool disposing); // 0x000000018166F8C0-0x000000018166F910
		}
	
		private sealed class LinkedNCancellationTokenSource : CancellationTokenSource // TypeDefIndex: 2553
		{
			// Fields
			internal static readonly Action<object> s_linkedTokenCancelDelegate; // 0x00
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 2554
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x0000000181678400-0x0000000181678470
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.cctor_b__4_0(object s); // 0x0000000181678380-0x0000000181678400
			}
	
			// Constructors
			static LinkedNCancellationTokenSource(); // 0x000000018166FAE0-0x000000018166FBB0
		}
	
		// Constructors
		public CancellationTokenSource(); // 0x0000000181665C40-0x0000000181665C80
		static CancellationTokenSource(); // 0x0000000181665A90-0x0000000181665C40
	
		// Methods
		public void Cancel(); // 0x00000001816648B0-0x0000000181664910
		public void Cancel(bool throwOnFirstException); // 0x0000000181664840-0x00000001816648B0
		public void CancelAfter(int millisecondsDelay); // 0x0000000181664670-0x0000000181664840
		private static void TimerCallbackLogic(object obj); // 0x00000001816658B0-0x00000001816659B0
		public void Dispose(); // 0x0000000181664E90-0x0000000181664F00
		protected virtual void Dispose(bool disposing); // 0x0000000181664F00-0x0000000181664FB0
		internal void ThrowIfDisposed(); // 0x0000000181665800-0x0000000181665850
		private static void ThrowObjectDisposedException(); // 0x0000000181665850-0x00000001816658B0
		internal CancellationTokenRegistration InternalRegister(Action<object> callback, object stateForCallback, SynchronizationContext targetSyncContext, ExecutionContext executionContext); // 0x00000001816653D0-0x0000000181665760
		private void NotifyCancellation(bool throwOnFirstException); // 0x0000000181665760-0x0000000181665800
		private void ExecuteCallbackHandlers(bool throwOnFirstException); // 0x0000000181664FB0-0x00000001816653D0
		private void CancellationCallbackCoreWork_OnSyncContext(object obj); // 0x0000000181664910-0x0000000181664990
		private void CancellationCallbackCoreWork(CancellationCallbackCoreWorkArguments args); // 0x0000000181664990-0x0000000181664A50
		public static CancellationTokenSource CreateLinkedTokenSource(CancellationToken token1, CancellationToken token2); // 0x0000000181664A50-0x0000000181664DC0
		internal static CancellationTokenSource CreateLinkedTokenSource(CancellationToken token); // 0x0000000181664DC0-0x0000000181664E90
		internal void WaitForCallbackToComplete(CancellationCallbackInfo callbackInfo); // 0x00000001816659B0-0x0000000181665A90
	}
}
