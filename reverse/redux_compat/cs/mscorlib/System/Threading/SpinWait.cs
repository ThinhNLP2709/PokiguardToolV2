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
	public struct SpinWait // TypeDefIndex: 2546
	{
		// Fields
		internal static readonly int SpinCountforSpinBeforeWait; // 0x00
		private int _count; // 0x00
	
		// Properties
		public int Count { get; } // 0x0000000180732D10-0x0000000180732D20 
		public bool NextSpinWillYield { get; } // 0x00000001816757B0-0x0000000181675820 
	
		// Constructors
		static SpinWait(); // 0x0000000181675730-0x00000001816757B0
	
		// Methods
		public void SpinOnce(); // 0x00000001816755F0-0x0000000181675640
		public void SpinOnce(int sleep1Threshold); // 0x0000000181675640-0x0000000181675730
		private void SpinOnceCore(int sleep1Threshold); // 0x0000000181675470-0x00000001816755F0
		public void Reset(); // 0x00000001812C86B0-0x00000001812C86C0
	}
}
