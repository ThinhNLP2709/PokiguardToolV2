/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Numerics
{
	internal static class BigIntegerCalculator // TypeDefIndex: 15306
	{
		// Fields
		private static int ReducerThreshold; // 0x00
		private static int SquareThreshold; // 0x04
		private static int AllocationThreshold; // 0x08
		private static int MultiplyThreshold; // 0x0C
	
		// Constructors
		static BigIntegerCalculator(); // 0x00000001819307E0-0x0000000181930860
	
		// Methods
		public static uint[] Add(uint[] left, uint right); // 0x000000018192ECA0-0x000000018192ED70
		public static uint[] Add(uint[] left, uint[] right); // 0x000000018192ED70-0x000000018192EE90
		private static unsafe void Add(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength); // 0x000000018192EBF0-0x000000018192ECA0
		private static unsafe void AddSelf(uint* left, int leftLength, uint* right, int rightLength); // 0x000000018192EB80-0x000000018192EBF0
		public static uint[] Subtract(uint[] left, uint right); // 0x0000000181930720-0x00000001819307E0
		public static uint[] Subtract(uint[] left, uint[] right); // 0x00000001819304E0-0x0000000181930670
		private static unsafe void Subtract(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength); // 0x0000000181930670-0x0000000181930720
		public static int Compare(uint[] left, uint[] right); // 0x000000018192EE90-0x000000018192EF10
		public static uint[] Divide(uint[] left, uint right); // 0x000000018192F350-0x000000018192F430
		public static uint Remainder(uint[] left, uint right); // 0x000000018192FE40-0x000000018192FEB0
		public static uint[] Divide(uint[] left, uint[] right); // 0x000000018192F430-0x000000018192F570
		public static uint[] Remainder(uint[] left, uint[] right); // 0x000000018192FD40-0x000000018192FE40
		private static unsafe void Divide(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength); // 0x000000018192EFD0-0x000000018192F350
		private static unsafe uint AddDivisor(uint* left, int leftLength, uint* right, int rightLength); // 0x000000018192EB50-0x000000018192EB80
		private static unsafe uint SubtractDivisor(uint* left, int leftLength, uint* right, int rightLength, ulong q); // 0x0000000181930490-0x00000001819304E0
		private static bool DivideGuessTooBig(ulong q, ulong valHi, uint valLo, uint divHi, uint divLo); // 0x000000018192EF90-0x000000018192EFD0
		private static uint[] CreateCopy(uint[] value); // 0x000000018192EF10-0x000000018192EF90
		private static int LeadingZeros(uint value); // 0x000000018192F570-0x000000018192F5E0
		public static uint[] Square(uint[] value); // 0x0000000181930280-0x0000000181930380
		private static unsafe void Square(uint* value, int valueLength, uint* bits, int bitsLength); // 0x000000018192FEB0-0x0000000181930280
		public static uint[] Multiply(uint[] left, uint right); // 0x000000018192FC70-0x000000018192FD40
		public static uint[] Multiply(uint[] left, uint[] right); // 0x000000018192F5E0-0x000000018192F720
		private static unsafe void Multiply(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength); // 0x000000018192F720-0x000000018192FC70
		private static unsafe void SubtractCore(uint* left, int leftLength, uint* right, int rightLength, uint* core, int coreLength); // 0x0000000181930380-0x0000000181930490
	}
}
