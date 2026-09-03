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

namespace Mono.Security.Cryptography
{
	internal class MD2Managed : MD2 // TypeDefIndex: 2128
	{
		// Fields
		private byte[] state; // 0x28
		private byte[] checksum; // 0x30
		private byte[] buffer; // 0x38
		private int count; // 0x40
		private byte[] x; // 0x48
		private static readonly byte[] PI_SUBST; // 0x00
	
		// Constructors
		public MD2Managed(); // 0x000000018144B6C0-0x000000018144B7A0
		static MD2Managed(); // 0x000000018144B5E0-0x000000018144B6C0
	
		// Methods
		private byte[] Padding(int nLength); // 0x000000018144B560-0x000000018144B5E0
		public override void Initialize(); // 0x00000001814213B0-0x0000000181421420
		protected override void HashCore(byte[] array, int ibStart, int cbSize); // 0x000000018144B020-0x000000018144B120
		protected override byte[] HashFinal(); // 0x000000018144B120-0x000000018144B280
		private void MD2Transform(byte[] state, byte[] checksum, byte[] block, int index); // 0x000000018144B280-0x000000018144B560
	}
}
