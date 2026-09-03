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
	public class RIPEMD160Managed : RIPEMD160 // TypeDefIndex: 2815
	{
		// Fields
		private byte[] _buffer; // 0x28
		private long _count; // 0x30
		private uint[] _stateMD160; // 0x38
		private uint[] _blockDWords; // 0x40
	
		// Constructors
		public RIPEMD160Managed(); // 0x0000000181494820-0x0000000181494960
	
		// Methods
		public override void Initialize(); // 0x0000000181492400-0x0000000181492460
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x0000000181492340-0x0000000181492350
		protected override byte[] HashFinal(); // 0x0000000181492350-0x0000000181492360
		private void InitializeState(); // 0x0000000181492370-0x0000000181492400
		private void _HashData(byte[] partIn, int ibStart, int cbSize); // 0x0000000181494680-0x0000000181494820
		private byte[] _EndHash(); // 0x00000001814944D0-0x0000000181494680
		private static unsafe void MDTransform(uint* blockDWords, uint* state, byte* block); // 0x0000000181492470-0x00000001814944D0
		private static uint F(uint x, uint y, uint z); // 0x0000000181492310-0x0000000181492320
		private static uint G(uint x, uint y, uint z); // 0x0000000181492320-0x0000000181492330
		private static uint H(uint x, uint y, uint z); // 0x0000000181492330-0x0000000181492340
		private static uint I(uint x, uint y, uint z); // 0x0000000181492360-0x0000000181492370
		private static uint J(uint x, uint y, uint z); // 0x0000000181492460-0x0000000181492470
	}
}
