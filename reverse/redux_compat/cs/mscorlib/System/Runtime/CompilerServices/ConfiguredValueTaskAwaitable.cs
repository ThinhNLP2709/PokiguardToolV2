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
	public struct ConfiguredValueTaskAwaitable // TypeDefIndex: 3186
	{
		// Fields
		private readonly ValueTask _value; // 0x00
	
		// Nested types
		[IsReadOnly]
		public struct ConfiguredValueTaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3187
		{
			// Fields
			private readonly ValueTask _value; // 0x00
	
			// Properties
			public bool IsCompleted { get; } // 0x000000018150B600-0x000000018150B650 
	
			// Constructors
			internal ConfiguredValueTaskAwaiter(ValueTask value); // 0x0000000180DE2BC0-0x0000000180DE2BD0
	
			// Methods
			[StackTraceHidden]
			public void GetResult(); // 0x000000018150B0D0-0x000000018150B120
			public void OnCompleted(Action continuation); // 0x000000018150B120-0x000000018150B390
			public void UnsafeOnCompleted(Action continuation); // 0x000000018150B390-0x000000018150B600
		}
	
		// Constructors
		internal ConfiguredValueTaskAwaitable(ValueTask value); // 0x0000000180DE2BC0-0x0000000180DE2BD0
	
		// Methods
		public ConfiguredValueTaskAwaiter GetAwaiter(); // 0x0000000180DE2BA0-0x0000000180DE2BC0
	}
}
