/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class ContextAwareResult : LazyAsyncResult // TypeDefIndex: 8992
	{
		// Fields
		private ExecutionContext _context; // 0x40
		private object _lock; // 0x48
		private StateFlags _flags; // 0x50
	
		// Nested types
		[Flags]
		private enum StateFlags : byte // TypeDefIndex: 8993
		{
			None = 0,
			CaptureIdentity = 1,
			CaptureContext = 2,
			ThreadSafeContextCopy = 4,
			PostBlockStarted = 8,
			PostBlockFinished = 16
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8994
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static ContextCallback __9__17_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181BDCC90-0x0000000181BDCD00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Complete_b__17_0(object s); // 0x0000000181BDCB40-0x0000000181BDCC90
		}
	
		// Constructors
		internal ContextAwareResult(object myObject, object myState, AsyncCallback myCallBack); // 0x0000000181BC2000-0x0000000181BC2020
		internal ContextAwareResult(bool captureIdentity, bool forceCaptureContext, object myObject, object myState, AsyncCallback myCallBack); // 0x0000000181BC1FA0-0x0000000181BC2000
		internal ContextAwareResult(bool captureIdentity, bool forceCaptureContext, bool threadSafeContextCopy, object myObject, object myState, AsyncCallback myCallBack); // 0x0000000181BC1F30-0x0000000181BC1FA0
	
		// Methods
		private void SafeCaptureIdentity(); // 0x00000001802E76C0-0x00000001802E76D0
		private void CleanupInternal(); // 0x00000001802E76C0-0x00000001802E76D0
		internal object StartPostingAsyncOp(); // 0x0000000181BC1E60-0x0000000181BC1F30
		internal object StartPostingAsyncOp(bool lockCapture); // 0x0000000181BC1D90-0x0000000181BC1E60
		internal bool FinishPostingAsyncOp(); // 0x0000000181BC1D50-0x0000000181BC1D90
		protected override void Cleanup(); // 0x0000000181BC1850-0x0000000181BC1930
		private bool CaptureOrComplete(ref ExecutionContext cachedContext, bool returnContext); // 0x0000000181BC1350-0x0000000181BC1850
		protected override void Complete(IntPtr userToken); // 0x0000000181BC1A20-0x0000000181BC1D50
		private void CompleteCallback(); // 0x0000000181BC1930-0x0000000181BC1A20
	}
}
