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
	internal static class ParameterizedStrings // TypeDefIndex: 2485
	{
		// Fields
		[ThreadStatic]
		private static LowLevelStack _cachedStack; // 0x80000000
	
		// Nested types
		public struct FormatParam // TypeDefIndex: 2486
		{
			// Fields
			private readonly int _int32; // 0x00
			private readonly string _string; // 0x08
	
			// Properties
			public int Int32 { get; } // 0x0000000180732D10-0x0000000180732D20 
			public string String { get; } // 0x0000000181652730-0x0000000181652750 
			public object Object { get; } // 0x0000000181652700-0x0000000181652730 
	
			// Constructors
			public FormatParam(int value); // 0x0000000180DFAAD0-0x0000000180DFAAF0
			private FormatParam(int intValue, string stringValue); // 0x0000000180F37790-0x0000000180F377B0
	
			// Methods
			public static implicit operator FormatParam(int value); // 0x0000000180DFAE00-0x0000000180DFAE30
		}
	
		private sealed class LowLevelStack // TypeDefIndex: 2487
		{
			// Fields
			private FormatParam[] _arr; // 0x10
			private int _count; // 0x18
	
			// Constructors
			public LowLevelStack(); // 0x0000000181652C70-0x0000000181652CC0
	
			// Methods
			public FormatParam Pop(); // 0x0000000181652AB0-0x0000000181652B80
			public void Push(FormatParam item); // 0x0000000181652B80-0x0000000181652C70
			public void Clear(); // 0x0000000181652A80-0x0000000181652AB0
		}
	
		// Methods
		public static string Evaluate(string format, params FormatParam[] args); // 0x00000001816581D0-0x00000001816583B0
		private static string EvaluateInternal(string format, ref int pos, FormatParam[] args, LowLevelStack stack, ref FormatParam[] dynamicVars, ref FormatParam[] staticVars); // 0x0000000181657580-0x00000001816581D0
		private static bool AsBool(int i); // 0x0000000181564FE0-0x0000000181564FF0
		private static int AsInt(bool b); // 0x00000001815669B0-0x00000001815669C0
		private static string StringFromAsciiBytes(byte[] buffer, int offset, int length); // 0x0000000181658750-0x0000000181658830
		private static unsafe extern int snprintf(byte* str, IntPtr size, string format, string arg1); // 0x0000000181658830-0x0000000181658910
		private static unsafe extern int snprintf(byte* str, IntPtr size, string format, int arg1); // 0x0000000181658910-0x00000001816589D0
		private static string FormatPrintF(string format, object arg); // 0x00000001816583B0-0x0000000181658640
		private static FormatParam[] GetDynamicOrStaticVariables(char c, ref FormatParam[] dynamicVars, ref FormatParam[] staticVars, out int index); // 0x0000000181658640-0x0000000181658750
	}
}
