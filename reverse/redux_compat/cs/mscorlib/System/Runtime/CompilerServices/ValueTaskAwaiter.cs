/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.CompilerServices
{
	[IsReadOnly]
	public struct ValueTaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3214
	{
		// Fields
		internal static readonly Action<object> s_invokeActionDelegate; // 0x00
		private readonly ValueTask _value; // 0x00
	
		// Properties
		public bool IsCompleted { get; } // 0x000000018151CC50-0x000000018151CCA0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3215
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018151C1D0-0x000000018151C240
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__9_0(object state); // 0x000000018151BF00-0x000000018151BF70
		}
	
		// Constructors
		internal ValueTaskAwaiter(ValueTask value); // 0x0000000180DE2BC0-0x0000000180DE2BD0
		static ValueTaskAwaiter(); // 0x000000018151CB80-0x000000018151CC50
	
		// Methods
		[StackTraceHidden]
		public void GetResult(); // 0x000000018151C6D0-0x000000018151C720
		public void OnCompleted(Action continuation); // 0x000000018151C720-0x000000018151C950
		public void UnsafeOnCompleted(Action continuation); // 0x000000018151C950-0x000000018151CB80
	}
}
