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
	public struct Point : IEquatable<Point> // TypeDefIndex: 15093
	{
		// Fields
		private int x; // 0x00
		private int y; // 0x04
	
		// Properties
		public int X { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int Y { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
		// Constructors
		public Point(int x, int y); // 0x0000000180C55C70-0x0000000180C55C80
	
		// Methods
		public static bool operator ==(Point left, Point right); // 0x000000018192DC90-0x000000018192DCB0
		public override bool Equals(object obj); // 0x000000018192DA60-0x000000018192DAF0
		public bool Equals(Point other); // 0x000000018192DA40-0x000000018192DA60
		public override int GetHashCode(); // 0x000000018192DAF0-0x000000018192DB50
		public override string ToString(); // 0x000000018192DB50-0x000000018192DC90
	}
}
