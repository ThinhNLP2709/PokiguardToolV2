/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Interop;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	internal class OSSpecificSynchronizationContext : SynchronizationContext // TypeDefIndex: 2584
	{
		// Fields
		private object m_OSSynchronizationContext; // 0x18
		private static readonly ConditionalWeakTable<object, OSSpecificSynchronizationContext> s_ContextCache; // 0x00
	
		// Nested types
		private delegate void InvocationEntryDelegate(IntPtr arg); // TypeDefIndex: 2585; 0x00000001804A78A0-0x00000001804A78B0
	
		private class InvocationContext // TypeDefIndex: 2586
		{
			// Fields
			private SendOrPostCallback m_Delegate; // 0x10
			private object m_State; // 0x18
	
			// Constructors
			public InvocationContext(SendOrPostCallback d, object state); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			public void Invoke(); // 0x0000000181681950-0x0000000181681980
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2587
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static ConditionalWeakTable<object, OSSpecificSynchronizationContext> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181693420-0x0000000181693490
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal OSSpecificSynchronizationContext _Get_b__3_0(object _osContext); // 0x0000000181692E10-0x0000000181692E70
		}
	
		// Constructors
		private OSSpecificSynchronizationContext(object osContext); // 0x0000000180D9D6B0-0x0000000180D9D6F0
		static OSSpecificSynchronizationContext(); // 0x0000000181672530-0x00000001816725B0
	
		// Methods
		public static OSSpecificSynchronizationContext Get(); // 0x0000000181672110-0x0000000181672270
		public override SynchronizationContext CreateCopy(); // 0x0000000181672090-0x0000000181672100
		public override void Send(SendOrPostCallback d, object state); // 0x00000001816724F0-0x0000000181672530
		public override void Post(SendOrPostCallback d, object state); // 0x00000001816723B0-0x00000001816724F0
		[MonoPInvokeCallback(typeof(InvocationEntryDelegate))]
		private static void InvocationEntry(IntPtr arg); // 0x0000000181672270-0x00000001816723A0
		private static object GetOSContext(); // 0x0000000181672100-0x0000000181672110
		private static void PostInternal(object osSynchronizationContext, IntPtr callback, IntPtr arg); // 0x00000001816723A0-0x00000001816723B0
	}
}
