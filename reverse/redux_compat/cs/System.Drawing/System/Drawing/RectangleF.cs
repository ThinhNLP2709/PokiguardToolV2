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
	public struct RectangleF : IEquatable<RectangleF> // TypeDefIndex: 15096
	{
		// Fields
		private float x; // 0x00
		private float y; // 0x04
		private float width; // 0x08
		private float height; // 0x0C
	
		// Properties
		public float X { get; } // 0x000000018035C780-0x000000018035C790 
		public float Y { get; } // 0x000000018035C790-0x000000018035C7A0 
		public float Width { get; } // 0x00000001802DB050-0x00000001802DB060 
		public float Height { get; } // 0x00000001802DB040-0x00000001802DB050 
	
		// Methods
		public override bool Equals(object obj); // 0x000000018192DCB0-0x000000018192DD70
		public bool Equals(RectangleF other); // 0x000000018192DD70-0x000000018192DDC0
		public static bool operator ==(RectangleF left, RectangleF right); // 0x000000018192E0B0-0x000000018192E0F0
		public override int GetHashCode(); // 0x000000018192DDC0-0x000000018192DEB0
		public override string ToString(); // 0x000000018192DEB0-0x000000018192E0B0
	}
}
