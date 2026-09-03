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
	public class SHA1Managed : SHA1 // TypeDefIndex: 2820
	{
		// Fields
		private byte[] _buffer; // 0x28
		private long _count; // 0x30
		private uint[] _stateSHA1; // 0x38
		private uint[] _expandedBuffer; // 0x40
	
		// Constructors
		public SHA1Managed(); // 0x00000001814A67B0-0x00000001814A6890
	
		// Methods
		public override void Initialize(); // 0x00000001814A5D90-0x00000001814A5DF0
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A5D70-0x00000001814A5D80
		protected override byte[] HashFinal(); // 0x00000001814A5D80-0x00000001814A5D90
		private void InitializeState(); // 0x0000000181492370-0x0000000181492400
		private void _HashData(byte[] partIn, int ibStart, int cbSize); // 0x00000001814A6610-0x00000001814A67B0
		private byte[] _EndHash(); // 0x00000001814A63D0-0x00000001814A6610
		private static unsafe void SHATransform(uint* expandedBuffer, uint* state, byte* block); // 0x00000001814A5E30-0x00000001814A63D0
		private static unsafe void SHAExpand(uint* x); // 0x00000001814A5DF0-0x00000001814A5E30
	}
}
