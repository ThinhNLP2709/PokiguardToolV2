/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class CryptoConfig // TypeDefIndex: 2838
	{
		// Fields
		private static readonly object lockObject; // 0x00
		private static Dictionary<string, Type> algorithms; // 0x08
	
		// Properties
		[MonoLimitation("nothing is FIPS certified so it never make sense to restrict to this (empty) subset")]
		public static bool AllowOnlyFipsAlgorithms { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		static CryptoConfig(); // 0x000000018149F0C0-0x000000018149F130
	
		// Methods
		public static object CreateFromName(string name); // 0x000000018149E3C0-0x000000018149E410
		public static object CreateFromName(string name, params object[] args); // 0x000000018149C590-0x000000018149E3C0
		public static string MapNameToOID(string name); // 0x000000018149EA00-0x000000018149F0C0
		public static byte[] EncodeOID(string str); // 0x000000018149E5D0-0x000000018149EA00
		private static byte[] EncodeLongNumber(long x); // 0x000000018149E410-0x000000018149E5D0
	}
}
