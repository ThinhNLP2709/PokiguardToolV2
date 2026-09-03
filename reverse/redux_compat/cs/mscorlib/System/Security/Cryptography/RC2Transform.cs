/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	internal class RC2Transform : SymmetricTransform // TypeDefIndex: 2842
	{
		// Fields
		private ushort R0; // 0x58
		private ushort R1; // 0x5A
		private ushort R2; // 0x5C
		private ushort R3; // 0x5E
		private ushort[] K; // 0x60
		private int j; // 0x68
		private static readonly byte[] pitable; // 0x00
	
		// Constructors
		public RC2Transform(RC2 rc2Algo, bool encryption, byte[] key, byte[] iv); // 0x00000001814A33E0-0x00000001814A3A10
		static RC2Transform(); // 0x00000001814A3300-0x00000001814A33E0
	
		// Methods
		protected override void ECB(byte[] input, byte[] output); // 0x00000001814A27D0-0x00000001814A3300
	}
}
