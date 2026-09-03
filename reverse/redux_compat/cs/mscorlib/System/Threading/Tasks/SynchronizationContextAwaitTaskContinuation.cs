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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	internal sealed class SynchronizationContextAwaitTaskContinuation : AwaitTaskContinuation // TypeDefIndex: 2668
	{
		// Fields
		private static readonly SendOrPostCallback s_postCallback; // 0x00
		private static ContextCallback s_postActionCallback; // 0x08
		private readonly SynchronizationContext m_syncContext; // 0x20
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2669
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001816931F0-0x0000000181693260
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__7_0(object state); // 0x0000000181693180-0x00000001816931F0
		}
	
		// Constructors
		internal SynchronizationContextAwaitTaskContinuation(SynchronizationContext context, Action action, bool flowExecutionContext); // 0x0000000181684960-0x00000001816849A0
		static SynchronizationContextAwaitTaskContinuation(); // 0x0000000181684890-0x0000000181684960
	
		// Methods
		internal sealed override void Run(Task ignored, bool canInlineContinuationTask); // 0x00000001816846E0-0x0000000181684890
		private static void PostAction(object state); // 0x0000000181684630-0x00000001816846E0
		private static ContextCallback GetPostActionCallback(); // 0x0000000181684560-0x0000000181684630
	}
}
