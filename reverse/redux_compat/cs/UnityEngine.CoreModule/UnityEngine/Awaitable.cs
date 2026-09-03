/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Threading;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Pool;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[AsyncMethodBuilder(typeof(AwaitableAsyncMethodBuilder))]
	[NativeHeader("Runtime/Mono/AsyncOperationAwaitable.h")]
	[NativeHeader("Runtime/Mono/Awaitable.h")]
	[NativeHeader("Runtime/Mono/DelayedCallAwaitable.h")]
	public class Awaitable : IEnumerator // TypeDefIndex: 7723
	{
		// Fields
		private SpinLock _spinLock; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly ThreadLocal<ObjectPool<Awaitable>> _pool; // 0x00
		private AwaitableHandle _handle; // 0x18
		private ExceptionDispatchInfo _exceptionToRethrow; // 0x20
		private bool _managedAwaitableDone; // 0x28
		private AwaiterCompletionThreadAffinity _completionThreadAffinity; // 0x2C
		private Action _continuation; // 0x30
		private CancellationTokenRegistration? _cancelTokenRegistration; // 0x38
		private DoubleBufferedAwaitableList _managedCompletionQueue; // 0x58
		[AutoStaticsCleanupOnCodeReload]
		private static bool _nextFrameAndEndOfFrameWiredUp; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static CancellationTokenRegistration _nextFrameAndEndOfFrameWiredUpCTRegistration; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly DoubleBufferedAwaitableList _nextFrameAwaitables; // 0x28
		[NoAutoStaticsCleanup]
		private static readonly DoubleBufferedAwaitableList _endOfFrameAwaitables; // 0x30
		[AutoStaticsCleanupOnCodeReload]
		private static SynchronizationContext _synchronizationContext; // 0x38
		[NoAutoStaticsCleanup]
		private static int _mainThreadId; // 0x40
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x48
	
		// Properties
		private bool IsCompletedNoLock { get; } // 0x00000001821E3FF0-0x00000001821E4130 
		public bool IsCompleted { get; } // 0x00000001821E4130-0x00000001821E4340 
		internal bool IsDettachedOrCompleted { get; } // 0x00000001821E4340-0x00000001821E4560 
		object IEnumerator.Current { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		internal enum AwaiterCompletionThreadAffinity // TypeDefIndex: 7724
		{
			None = 0,
			MainThread = 1,
			BackgroundThread = 2
		}
	
		[ExcludeFromDocs]
		public struct AwaitableAsyncMethodBuilder // TypeDefIndex: 7725
		{
			// Fields
			private IStateMachineBox _stateMachineBox; // 0x00
			private Awaitable _resultingCoroutine; // 0x08
	
			// Nested types
			private interface IStateMachineBox : IDisposable // TypeDefIndex: 7726
			{
			}
		}
	
		[IsReadOnly]
		private struct AwaitableHandle // TypeDefIndex: 7727
		{
			// Fields
			private readonly IntPtr _handle; // 0x00
			public static readonly AwaitableHandle ManagedHandle; // 0x00
			public static readonly AwaitableHandle NullHandle; // 0x08
	
			// Properties
			public bool IsNull { get; } // 0x0000000180E87410-0x0000000180E87420 
			public bool IsManaged { get; } // 0x00000001821E2D80-0x00000001821E2DE0 
	
			// Constructors
			public AwaitableHandle(IntPtr handle); // 0x0000000180CBE820-0x0000000180CBE830
			static AwaitableHandle(); // 0x00000001821E2D10-0x00000001821E2D80
	
			// Methods
			public static implicit operator IntPtr(AwaitableHandle handle); // 0x0000000180370C60-0x0000000180370C70
		}
	
		private struct AwaitableAndFrameIndex // TypeDefIndex: 7728
		{
			// Fields
			[CompilerGenerated]
			private readonly Awaitable _Awaitable_k__BackingField; // 0x00
			[CompilerGenerated]
			private readonly int _FrameIndex_k__BackingField; // 0x08
	
			// Properties
			public Awaitable Awaitable { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public int FrameIndex { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180732D20-0x0000000180732D30 
		}
	
		private class DoubleBufferedAwaitableList // TypeDefIndex: 7729
		{
			// Fields
			private List<AwaitableAndFrameIndex> _awaitables; // 0x10
			private List<AwaitableAndFrameIndex> _scratch; // 0x18
	
			// Constructors
			public DoubleBufferedAwaitableList(); // 0x00000001821E5950-0x00000001821E5A00
	
			// Methods
			public void SwapAndComplete(); // 0x00000001821E5710-0x00000001821E5950
			public void Clear(); // 0x0000000181E3A9B0-0x0000000181E3A9F0
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 7730
		{
			// Fields
			public static SendOrPostCallback _0___DoRunContinuationOnSynchonizationContext; // 0x00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 7731
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Awaitable> __9__81_1; // 0x08
	
			// Constructors
			static __c(); // 0x00000001821FB1D0-0x00000001821FB240
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ObjectPool<Awaitable> _.cctor_b__81_0(); // 0x00000001821FB050-0x00000001821FB180
			internal Awaitable _.cctor_b__81_1(); // 0x00000001821FB180-0x00000001821FB1D0
		}
	
		// Constructors
		private Awaitable(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Awaitable(); // 0x00000001821E3D30-0x00000001821E3FF0
	
		// Methods
		[RequiredByNativeCode]
		private static void SetExceptionFromNative(Awaitable self, Exception ex); // 0x00000001821E3A80-0x00000001821E3AA0
		private void SetException(Exception ex); // 0x00000001821E3AA0-0x00000001821E3BB0
		[RequiredByNativeCode]
		private static void RunContinuationFromNative(Awaitable self); // 0x00000001821E37A0-0x00000001821E37C0
		private void RunContinuation(); // 0x00000001821E37C0-0x00000001821E38F0
		[FreeFunction("Scripting::Awaitables::Release", IsThreadSafe = true)]
		private static void ReleaseNativeAwaitable(IntPtr nativeAwaitable); // 0x00000001821E3760-0x00000001821E37A0
		[FreeFunction("Scripting::Awaitables::IsCompleted", IsThreadSafe = true)]
		private static int IsNativeAwaitableCompleted(IntPtr nativeAwaitable); // 0x00000001821E2EE0-0x00000001821E2F20
		private static bool MatchCompletionThreadAffinity(AwaiterCompletionThreadAffinity awaiterCompletionThreadAffinity); // 0x00000001821E2F20-0x00000001821E2FF0
		private void RunOrScheduleContinuation(AwaiterCompletionThreadAffinity awaiterCompletionThreadAffinity, Action continuation); // 0x00000001821E38F0-0x00000001821E3A80
		private static void DoRunContinuationOnSynchonizationContext(object continuation); // 0x00000001821E2E80-0x00000001821E2EE0
		internal void RaiseManagedCompletion(); // 0x00000001821E35F0-0x00000001821E3760
		internal void PropagateExceptionAndRelease(); // 0x00000001821E3190-0x00000001821E35F0
		private AwaitableHandle CheckPointerValidity(); // 0x00000001821E2DE0-0x00000001821E2E80
		bool IEnumerator.MoveNext(); // 0x00000001821E3C40-0x00000001821E3C70
		void IEnumerator.Reset(); // 0x00000001802E76C0-0x00000001802E76D0
		[RequiredByNativeCode]
		private static void OnDelayedCallManagerCleared(); // 0x00000001821E2FF0-0x00000001821E30D0
		[RequiredByNativeCode]
		private static void OnUpdate(); // 0x00000001821E3130-0x00000001821E3190
		[RequiredByNativeCode]
		private static void OnEndOfFrame(); // 0x00000001821E30D0-0x00000001821E3130
		internal static void SetSynchronizationContext(UnitySynchronizationContext synchronizationContext); // 0x00000001821E3BB0-0x00000001821E3C40
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001821E3C70-0x00000001821E3D30
	}
}
