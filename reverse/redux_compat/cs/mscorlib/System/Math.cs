/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	public static class Math // TypeDefIndex: 2298
	{
		// Fields
		private static double doubleRoundLimit; // 0x00
		private static double[] roundPower10Double; // 0x08
	
		// Constructors
		static Math(); // 0x0000000181600150-0x0000000181600230
	
		// Methods
		public static int Abs(int value); // 0x00000001815FF4B0-0x00000001815FF510
		public static long Abs(long value); // 0x00000001815FF450-0x00000001815FF4B0
		public static decimal Abs(decimal value); // 0x00000001815FF530-0x00000001815FF5A0
		[StackTraceHidden]
		private static void ThrowAbsOverflow(); // 0x0000000181600020-0x0000000181600070
		public static int DivRem(int a, int b, out int result); // 0x00000001815FF750-0x00000001815FF770
		public static int Clamp(int value, int min, int max); // 0x00000001815FF6A0-0x00000001815FF740
		public static float Clamp(float value, float min, float max); // 0x00000001815FF5F0-0x00000001815FF6A0
		public static double Log(double a, double newBase); // 0x00000001815FF7B0-0x00000001815FF8B0
		[NonVersionable]
		public static byte Max(byte val1, byte val2); // 0x00000001815FF8B0-0x00000001815FF8C0
		public static decimal Max(decimal val1, decimal val2); // 0x00000001815FF980-0x00000001815FFA40
		public static double Max(double val1, double val2); // 0x00000001815FF8F0-0x00000001815FF920
		[NonVersionable]
		public static short Max(short val1, short val2); // 0x00000001815FF920-0x00000001815FF930
		[NonVersionable]
		public static int Max(int val1, int val2); // 0x00000001815FF8C0-0x00000001815FF8D0
		[NonVersionable]
		public static long Max(long val1, long val2); // 0x00000001815FF970-0x00000001815FF980
		[CLSCompliant(false)]
		[NonVersionable]
		public static sbyte Max(sbyte val1, sbyte val2); // 0x00000001815FF930-0x00000001815FF940
		public static float Max(float val1, float val2); // 0x00000001815FF950-0x00000001815FF970
		[CLSCompliant(false)]
		[NonVersionable]
		public static ushort Max(ushort val1, ushort val2); // 0x00000001815FF8E0-0x00000001815FF8F0
		[CLSCompliant(false)]
		[NonVersionable]
		public static uint Max(uint val1, uint val2); // 0x00000001815FF8D0-0x00000001815FF8E0
		[CLSCompliant(false)]
		[NonVersionable]
		public static ulong Max(ulong val1, ulong val2); // 0x00000001815FF940-0x00000001815FF950
		[NonVersionable]
		public static byte Min(byte val1, byte val2); // 0x00000001815FFAE0-0x00000001815FFAF0
		public static decimal Min(decimal val1, decimal val2); // 0x00000001815FFA60-0x00000001815FFAD0
		public static double Min(double val1, double val2); // 0x00000001815FFB10-0x00000001815FFB40
		[NonVersionable]
		public static short Min(short val1, short val2); // 0x00000001815FFAD0-0x00000001815FFAE0
		[NonVersionable]
		public static int Min(int val1, int val2); // 0x00000001815FFAF0-0x00000001815FFB00
		[NonVersionable]
		public static long Min(long val1, long val2); // 0x00000001815FFB50-0x00000001815FFB60
		[CLSCompliant(false)]
		[NonVersionable]
		public static sbyte Min(sbyte val1, sbyte val2); // 0x00000001815FFA40-0x00000001815FFA50
		public static float Min(float val1, float val2); // 0x00000001815FFB60-0x00000001815FFB80
		[CLSCompliant(false)]
		[NonVersionable]
		public static ushort Min(ushort val1, ushort val2); // 0x00000001815FFB40-0x00000001815FFB50
		[CLSCompliant(false)]
		[NonVersionable]
		public static uint Min(uint val1, uint val2); // 0x00000001815FFB00-0x00000001815FFB10
		[CLSCompliant(false)]
		[NonVersionable]
		public static ulong Min(ulong val1, ulong val2); // 0x00000001815FFA50-0x00000001815FFA60
		public static decimal Round(decimal d); // 0x00000001815FFEB0-0x00000001815FFF30
		public static double Round(double a); // 0x00000001815FFEA0-0x00000001815FFEB0
		public static double Round(double value, MidpointRounding mode); // 0x00000001815FFE40-0x00000001815FFEA0
		public static double Round(double value, int digits, MidpointRounding mode); // 0x00000001815FFBA0-0x00000001815FFE40
		public static int Sign(double value); // 0x00000001815FFF30-0x00000001815FFFC0
		public static int Sign(long value); // 0x00000001815FFFC0-0x00000001815FFFE0
		public static decimal Truncate(decimal d); // 0x00000001816000E0-0x0000000181600150
		public static double Truncate(double d); // 0x0000000181600070-0x00000001816000E0
		private static void ThrowMinMaxException<T>(T min, T max);
		public static double Abs(double value); // 0x00000001815FF520-0x00000001815FF530
		public static float Abs(float value); // 0x00000001815FF510-0x00000001815FF520
		public static double Acos(double d); // 0x00000001815FF5A0-0x00000001815FF5B0
		public static double Asin(double d); // 0x00000001815FF5B0-0x00000001815FF5C0
		public static double Atan(double d); // 0x00000001815FF5D0-0x00000001815FF5E0
		public static double Atan2(double y, double x); // 0x00000001815FF5C0-0x00000001815FF5D0
		public static double Ceiling(double a); // 0x00000001815FF5E0-0x00000001815FF5F0
		public static double Cos(double d); // 0x00000001815FF740-0x00000001815FF750
		public static double Exp(double d); // 0x00000001815FF770-0x00000001815FF780
		public static double Floor(double d); // 0x00000001815FF780-0x00000001815FF790
		public static double Log(double d); // 0x00000001815FF7A0-0x00000001815FF7B0
		public static double Log10(double d); // 0x00000001815FF790-0x00000001815FF7A0
		public static double Pow(double x, double y); // 0x00000001815FFB90-0x00000001815FFBA0
		public static double Sin(double a); // 0x00000001815FFFE0-0x00000001815FFFF0
		public static double Sqrt(double d); // 0x00000001815FFFF0-0x0000000181600010
		public static double Tan(double a); // 0x0000000181600010-0x0000000181600020
		private static unsafe double ModF(double x, double* intptr); // 0x00000001815FFB80-0x00000001815FFB90
	}
}
