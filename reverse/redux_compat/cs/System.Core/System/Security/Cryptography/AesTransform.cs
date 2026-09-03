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

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Security.Cryptography
{
	internal class AesTransform : SymmetricTransform // TypeDefIndex: 11975
	{
		// Fields
		private uint[] expandedKey; // 0x58
		private int Nk; // 0x60
		private int Nr; // 0x64
		private static readonly uint[] Rcon; // 0x00
		private static readonly byte[] SBox; // 0x08
		private static readonly byte[] iSBox; // 0x10
		private static readonly uint[] T0; // 0x18
		private static readonly uint[] T1; // 0x20
		private static readonly uint[] T2; // 0x28
		private static readonly uint[] T3; // 0x30
		private static readonly uint[] iT0; // 0x38
		private static readonly uint[] iT1; // 0x40
		private static readonly uint[] iT2; // 0x48
		private static readonly uint[] iT3; // 0x50
	
		// Constructors
		public AesTransform(Aes algo, bool encryption, byte[] key, byte[] iv); // 0x0000000181788EF0-0x0000000181789700
		static AesTransform(); // 0x0000000181788730-0x0000000181788EF0
	
		// Methods
		protected override void ECB(byte[] input, byte[] output); // 0x00000001817858A0-0x00000001817858D0
		private uint SubByte(uint a); // 0x0000000181788630-0x0000000181788730
		private void Encrypt128(byte[] indata, byte[] outdata, uint[] ekey); // 0x00000001817858D0-0x0000000181788630
		private void Decrypt128(byte[] indata, byte[] outdata, uint[] ekey); // 0x0000000181782B10-0x00000001817858A0
	}
}
