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
	public class MD4Managed : MD4 // TypeDefIndex: 13881
	{
		// Fields
		private uint[] state; // 0x28
		private byte[] buffer; // 0x30
		private uint[] count; // 0x38
		private uint[] x; // 0x40
		private byte[] digest; // 0x48
	
		// Constructors
		public MD4Managed(); // 0x0000000181422D10-0x0000000181422E20
	
		// Methods
		public override void Initialize(); // 0x0000000181422110-0x00000001814221E0
		protected override void HashCore(byte[] array, int ibStart, int cbSize); // 0x0000000181421CD0-0x0000000181421E50
		protected override byte[] HashFinal(); // 0x0000000181421E50-0x0000000181422110
		private byte[] Padding(int nLength); // 0x0000000181422C90-0x0000000181422CF0
		private uint F(uint x, uint y, uint z); // 0x0000000181421C10-0x0000000181421C20
		private uint G(uint x, uint y, uint z); // 0x0000000181421C70-0x0000000181421C80
		private uint H(uint x, uint y, uint z); // 0x0000000181421CC0-0x0000000181421CD0
		private uint ROL(uint x, byte n); // 0x0000000181422CF0-0x0000000181422D10
		private void FF(ref uint a, uint b, uint c, uint d, uint x, byte s); // 0x0000000181421BD0-0x0000000181421C10
		private void GG(ref uint a, uint b, uint c, uint d, uint x, byte s); // 0x0000000181421C20-0x0000000181421C70
		private void HH(ref uint a, uint b, uint c, uint d, uint x, byte s); // 0x0000000181421C80-0x0000000181421CC0
		private void Encode(byte[] output, uint[] input); // 0x0000000181421B20-0x0000000181421BD0
		private void Decode(uint[] output, byte[] input, int index); // 0x0000000181421A70-0x0000000181421B20
		private void MD4Transform(uint[] state, byte[] block, int index); // 0x00000001814221E0-0x0000000181422C90
	}
}
