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

namespace Internal.Runtime.Augments
{
	internal sealed class RuntimeThread // TypeDefIndex: 2169
	{
		// Fields
		internal static readonly int OptimalMaxSpinWaitsPerSpinIteration; // 0x00
		private readonly Thread thread; // 0x10
	
		// Properties
		public bool IsBackground { set; } // 0x0000000181452F40-0x0000000181452F60
	
		// Constructors
		private RuntimeThread(Thread t); // 0x00000001803855F0-0x0000000180385630
		static RuntimeThread(); // 0x0000000181452F00-0x0000000181452F40
	
		// Methods
		public static RuntimeThread Create(ParameterizedThreadStart start, int maxStackSize); // 0x0000000181452E10-0x0000000181452EA0
		public void Start(object state); // 0x0000000181452ED0-0x0000000181452EF0
		public static void Sleep(int millisecondsTimeout); // 0x0000000181452EA0-0x0000000181452EB0
		public static bool Yield(); // 0x0000000181452EF0-0x0000000181452F00
		public static bool SpinWait(int iterations); // 0x0000000181452EB0-0x0000000181452ED0
		public static int GetCurrentProcessorId(); // 0x0000000180472790-0x00000001804727A0
	}
}
