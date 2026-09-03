/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 39: System.Drawing.dll - Assembly: System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a - Types 15087-15098

namespace System.Drawing
{
	[Serializable]
	public struct Size : IEquatable<Size> // TypeDefIndex: 15097
	{
		// Fields
		private int width; // 0x00
		private int height; // 0x04
	
		// Properties
		public int Width { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int Height { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
		// Methods
		public static bool operator ==(Size sz1, Size sz2); // 0x000000018192DC90-0x000000018192DCB0
		public override bool Equals(object obj); // 0x000000018192E710-0x000000018192E7A0
		public bool Equals(Size other); // 0x000000018192DA40-0x000000018192DA60
		public override int GetHashCode(); // 0x000000018192E7A0-0x000000018192E800
		public override string ToString(); // 0x000000018192E800-0x000000018192E920
	}
}
