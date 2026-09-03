/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal struct Range // TypeDefIndex: 11300
	{
		// Fields
		private int _min; // 0x00
		private int _max; // 0x04
		private bool _isNotNull; // 0x08
	
		// Properties
		public int Count { get; } // 0x000000018189C5A0-0x000000018189C5C0 
		public bool IsNull { get; } // 0x000000018189C5C0-0x000000018189C5D0 
		public int Min { get; } // 0x000000018189C5D0-0x000000018189C610 
	
		// Constructors
		public Range(int min, int max); // 0x000000018189C550-0x000000018189C5A0
	
		// Methods
		internal void CheckNull(); // 0x000000018189C510-0x000000018189C550
	}
}
