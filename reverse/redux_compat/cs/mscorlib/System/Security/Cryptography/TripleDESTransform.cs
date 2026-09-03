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
	internal class TripleDESTransform : SymmetricTransform // TypeDefIndex: 2848
	{
		// Fields
		private DESTransform E1; // 0x58
		private DESTransform D2; // 0x60
		private DESTransform E3; // 0x68
		private DESTransform D1; // 0x70
		private DESTransform E2; // 0x78
		private DESTransform D3; // 0x80
	
		// Constructors
		public TripleDESTransform(TripleDES algo, bool encryption, byte[] key, byte[] iv); // 0x00000001814C9AF0-0x00000001814C9F40
	
		// Methods
		protected override void ECB(byte[] input, byte[] output); // 0x00000001814C9900-0x00000001814C9A40
		internal static byte[] GetStrongKey(); // 0x00000001814C9A40-0x00000001814C9AF0
	}
}
