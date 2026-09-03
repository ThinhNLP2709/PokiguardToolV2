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

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class SHA256Managed : SHA256 // TypeDefIndex: 2822
	{
		// Fields
		private byte[] _buffer; // 0x28
		private long _count; // 0x30
		private uint[] _stateSHA256; // 0x38
		private uint[] _W; // 0x40
		private static readonly uint[] _K; // 0x00
	
		// Constructors
		public SHA256Managed(); // 0x00000001814A7EA0-0x00000001814A7F80
		static SHA256Managed(); // 0x00000001814A7DC0-0x00000001814A7EA0
	
		// Methods
		public override void Initialize(); // 0x00000001814A6A20-0x00000001814A6A80
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A6910-0x00000001814A6920
		protected override byte[] HashFinal(); // 0x00000001814A6920-0x00000001814A6930
		private void InitializeState(); // 0x00000001814A6930-0x00000001814A6A20
		private void _HashData(byte[] partIn, int ibStart, int cbSize); // 0x00000001814A7BC0-0x00000001814A7DC0
		private byte[] _EndHash(); // 0x00000001814A7980-0x00000001814A7BC0
		private static unsafe void SHATransform(uint* expandedBuffer, uint* state, byte* block); // 0x00000001814A6C10-0x00000001814A78A0
		private static uint RotateRight(uint x, int n); // 0x00000001814A6A90-0x00000001814A6AB0
		private static uint Ch(uint x, uint y, uint z); // 0x00000001814A6900-0x00000001814A6910
		private static uint Maj(uint x, uint y, uint z); // 0x00000001814A6A80-0x00000001814A6A90
		private static uint sigma_0(uint x); // 0x00000001814A7F80-0x00000001814A7FE0
		private static uint sigma_1(uint x); // 0x00000001814A7FE0-0x00000001814A8040
		private static uint Sigma_0(uint x); // 0x00000001814A78A0-0x00000001814A7910
		private static uint Sigma_1(uint x); // 0x00000001814A7910-0x00000001814A7980
		private static unsafe void SHA256Expand(uint* x); // 0x00000001814A6AB0-0x00000001814A6C10
	}
}
