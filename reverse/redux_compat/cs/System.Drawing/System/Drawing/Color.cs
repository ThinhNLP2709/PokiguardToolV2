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
	[DebuggerDisplay("{NameAndARGBValue}")]
	[IsReadOnly]
	public struct Color : IEquatable<Color> // TypeDefIndex: 15092
	{
		// Fields
		private readonly string name; // 0x00
		private readonly long value; // 0x08
		private readonly short knownColor; // 0x10
		private readonly short state; // 0x12
	
		// Properties
		public byte R { get; } // 0x000000018192A410-0x000000018192A430 
		public byte G { get; } // 0x000000018192A2E0-0x000000018192A300 
		public byte B { get; } // 0x000000018192A2D0-0x000000018192A2E0 
		public byte A { get; } // 0x000000018192A2B0-0x000000018192A2D0 
		public bool IsKnownColor { get; } // 0x000000018192A300-0x000000018192A310 
		public string Name { get; } // 0x000000018192A310-0x000000018192A410 
		private long Value { get; } // 0x000000018192A430-0x000000018192A4F0 
	
		// Constructors
		private Color(long value, short state, string name, KnownColor knownColor); // 0x000000018192A280-0x000000018192A2B0
	
		// Methods
		private static void CheckByte(int value, string name); // 0x00000001819299F0-0x0000000181929B70
		private static long MakeArgb(byte alpha, byte red, byte green, byte blue); // 0x0000000181929F00-0x0000000181929F30
		public static Color FromArgb(int alpha, int red, int green, int blue); // 0x0000000181929D00-0x0000000181929E20
		public override string ToString(); // 0x0000000181929F30-0x000000018192A280
		public static bool operator ==(Color left, Color right); // 0x000000018192A4F0-0x000000018192A570
		public override bool Equals(object obj); // 0x0000000181929B70-0x0000000181929C60
		public bool Equals(Color other); // 0x0000000181929C60-0x0000000181929D00
		public override int GetHashCode(); // 0x0000000181929E20-0x0000000181929F00
	}
}
