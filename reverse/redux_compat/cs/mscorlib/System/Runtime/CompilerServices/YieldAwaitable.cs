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

namespace System.Runtime.CompilerServices
{
	[IsReadOnly]
	public struct YieldAwaitable // TypeDefIndex: 3234
	{
		// Nested types
		[IsReadOnly]
		public struct YieldAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3235
		{
			// Fields
			private static readonly WaitCallback s_waitCallbackRunAction; // 0x00
			private static readonly SendOrPostCallback s_sendOrPostCallbackRunAction; // 0x08
	
			// Properties
			public bool IsCompleted { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			static YieldAwaiter(); // 0x000000018151D080-0x000000018151D170
	
			// Methods
			public void OnCompleted(Action continuation); // 0x000000018151CCA0-0x000000018151CCF0
			public void UnsafeOnCompleted(Action continuation); // 0x000000018151D030-0x000000018151D080
			private static void QueueContinuation(Action continuation, bool flowContext); // 0x000000018151CCF0-0x000000018151CFC0
			private static void RunAction(object state); // 0x000000018151CFC0-0x000000018151D030
			public void GetResult(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Methods
		public YieldAwaiter GetAwaiter(); // 0x00000001802E7840-0x00000001802E7850
	}
}
