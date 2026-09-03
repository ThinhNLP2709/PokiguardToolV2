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

namespace System.Globalization
{
	internal class Bootstring // TypeDefIndex: 3454
	{
		// Fields
		private readonly char delimiter; // 0x10
		private readonly int base_num; // 0x14
		private readonly int tmin; // 0x18
		private readonly int tmax; // 0x1C
		private readonly int skew; // 0x20
		private readonly int damp; // 0x24
		private readonly int initial_bias; // 0x28
		private readonly int initial_n; // 0x2C
	
		// Constructors
		public Bootstring(char delimiter, int baseNum, int tmin, int tmax, int skew, int damp, int initialBias, int initialN); // 0x0000000181591DC0-0x0000000181591E30
	
		// Methods
		public string Encode(string s, int offset); // 0x00000001815919C0-0x0000000181591DC0
		private char EncodeDigit(int d); // 0x00000001815919A0-0x00000001815919C0
		private int DecodeDigit(char c); // 0x00000001815916E0-0x0000000181591710
		private int Adapt(int delta, int numPoints, bool firstTime); // 0x0000000181591660-0x00000001815916E0
		public string Decode(string s, int offset); // 0x0000000181591710-0x00000001815919A0
	}
}
