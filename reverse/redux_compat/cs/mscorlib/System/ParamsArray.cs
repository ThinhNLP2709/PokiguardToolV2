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

namespace System
{
	[IsReadOnly]
	internal struct ParamsArray // TypeDefIndex: 2322
	{
		// Fields
		private static readonly object[] s_oneArgArray; // 0x00
		private static readonly object[] s_twoArgArray; // 0x08
		private static readonly object[] s_threeArgArray; // 0x10
		private readonly object _arg0; // 0x00
		private readonly object _arg1; // 0x08
		private readonly object _arg2; // 0x10
		private readonly object[] _args; // 0x18
	
		// Properties
		public int Length { get; } // 0x00000001814EA450-0x00000001814EA470 
		public object this[int index] { get => default; } // 0x0000000181617B30-0x0000000181617BE0 
	
		// Constructors
		public ParamsArray(object arg0); // 0x0000000181617920-0x00000001816179C0
		public ParamsArray(object arg0, object arg1); // 0x0000000181617A80-0x0000000181617B30
		public ParamsArray(object arg0, object arg1, object arg2); // 0x00000001816179C0-0x0000000181617A80
		public ParamsArray(object[] args); // 0x0000000181617850-0x0000000181617920
		static ParamsArray(); // 0x0000000181617760-0x0000000181617850
	
		// Methods
		private object GetAtSlow(int index); // 0x0000000181617710-0x0000000181617760
	}
}
