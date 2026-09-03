/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Cryptography
{
	public class MD2Managed : MD2 // TypeDefIndex: 13879
	{
		// Fields
		private byte[] state; // 0x28
		private byte[] checksum; // 0x30
		private byte[] buffer; // 0x38
		private int count; // 0x40
		private byte[] x; // 0x48
		private static readonly byte[] PI_SUBST; // 0x00
	
		// Constructors
		public MD2Managed(); // 0x0000000181421860-0x0000000181421940
		static MD2Managed(); // 0x0000000181421780-0x0000000181421860
	
		// Methods
		private byte[] Padding(int nLength); // 0x0000000181421700-0x0000000181421780
		public override void Initialize(); // 0x00000001814213B0-0x0000000181421420
		protected override void HashCore(byte[] array, int ibStart, int cbSize); // 0x0000000181421150-0x0000000181421250
		protected override byte[] HashFinal(); // 0x0000000181421250-0x00000001814213B0
		private void MD2Transform(byte[] state, byte[] checksum, byte[] block, int index); // 0x0000000181421420-0x0000000181421700
	}
}
