/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 39: System.Drawing.dll - Assembly: System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a - Types 15087-15098

namespace System.Drawing
{
	[Serializable]
	public struct Rectangle : IEquatable<Rectangle> // TypeDefIndex: 15095
	{
		// Fields
		public static readonly Rectangle Empty; // 0x00
		private int x; // 0x00
		private int y; // 0x04
		private int width; // 0x08
		private int height; // 0x0C
	
		// Properties
		public int X { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int Y { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public int Width { get; } // 0x0000000180732D20-0x0000000180732D30 
		public int Height { get; } // 0x0000000180732D30-0x0000000180732D40 
		[Browsable(false)]
		public int Left { get; } // 0x0000000180732D10-0x0000000180732D20 
		[Browsable(false)]
		public int Top { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		[Browsable(false)]
		public int Right { get; } // 0x000000018192E4B0-0x000000018192E4C0 
		[Browsable(false)]
		public int Bottom { get; } // 0x000000018192E4A0-0x000000018192E4B0 
	
		// Constructors
		public Rectangle(int x, int y, int width, int height); // 0x000000018192E480-0x000000018192E4A0
	
		// Methods
		public override bool Equals(object obj); // 0x000000018192E0F0-0x000000018192E1B0
		public bool Equals(Rectangle other); // 0x000000018192E1B0-0x000000018192E200
		public static bool operator ==(Rectangle left, Rectangle right); // 0x00000001815FB130-0x00000001815FB160
		public override int GetHashCode(); // 0x000000018192E200-0x000000018192E290
		public override string ToString(); // 0x000000018192E290-0x000000018192E480
	}
}
