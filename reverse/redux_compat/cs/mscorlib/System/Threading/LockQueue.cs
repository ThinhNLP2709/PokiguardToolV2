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
	internal class LockQueue // TypeDefIndex: 2608
	{
		// Fields
		private ReaderWriterLock rwlock; // 0x10
		private int lockCount; // 0x18
	
		// Properties
		public bool IsEmpty { get; } // 0x0000000181681B80-0x0000000181681C30 
	
		// Constructors
		public LockQueue(ReaderWriterLock rwlock); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public bool Wait(int timeout); // 0x0000000181681A20-0x0000000181681B80
		public void Pulse(); // 0x0000000181681980-0x0000000181681A20
	}
}
