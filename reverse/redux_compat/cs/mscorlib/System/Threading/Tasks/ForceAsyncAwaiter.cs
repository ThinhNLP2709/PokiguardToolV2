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

namespace System.Threading.Tasks
{
	[IsReadOnly]
	internal struct ForceAsyncAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 2638
	{
		// Fields
		private readonly Task _task; // 0x00
	
		// Properties
		public bool IsCompleted { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		internal ForceAsyncAwaiter(Task task); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		public ForceAsyncAwaiter GetAwaiter(); // 0x00000001808BADD0-0x00000001808BADE0
		public void GetResult(); // 0x0000000181681000-0x0000000181681050
		public void OnCompleted(Action action); // 0x0000000181681050-0x00000001816810B0
		public void UnsafeOnCompleted(Action action); // 0x00000001816810B0-0x0000000181681110
	}
}
