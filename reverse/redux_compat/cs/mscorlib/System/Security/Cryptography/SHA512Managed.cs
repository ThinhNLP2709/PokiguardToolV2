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
	public class SHA512Managed : SHA512 // TypeDefIndex: 2826
	{
		// Fields
		private byte[] _buffer; // 0x28
		private ulong _count; // 0x30
		private ulong[] _stateSHA512; // 0x38
		private ulong[] _W; // 0x40
		private static readonly ulong[] _K; // 0x00
	
		// Constructors
		public SHA512Managed(); // 0x00000001814AB240-0x00000001814AB320
		static SHA512Managed(); // 0x00000001814AB160-0x00000001814AB240
	
		// Methods
		public override void Initialize(); // 0x00000001814A9C00-0x00000001814A9C60
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A9AB0-0x00000001814A9AC0
		protected override byte[] HashFinal(); // 0x00000001814A9AC0-0x00000001814A9AD0
		private void InitializeState(); // 0x00000001814A9AD0-0x00000001814A9C00
		private void _HashData(byte[] partIn, int ibStart, int cbSize); // 0x00000001814AAF50-0x00000001814AB160
		private byte[] _EndHash(); // 0x00000001814AAC80-0x00000001814AAF50
		private static unsafe void SHATransform(ulong* expandedBuffer, ulong* state, byte* block); // 0x00000001814A9DE0-0x00000001814AAB80
		private static ulong RotateRight(ulong x, int n); // 0x00000001814A8280-0x00000001814A82A0
		private static ulong Ch(ulong x, ulong y, ulong z); // 0x00000001814A80B0-0x00000001814A80C0
		private static ulong Maj(ulong x, ulong y, ulong z); // 0x00000001814A8270-0x00000001814A8280
		private static ulong Sigma_0(ulong x); // 0x00000001814AAB80-0x00000001814AAC00
		private static ulong Sigma_1(ulong x); // 0x00000001814AAC00-0x00000001814AAC80
		private static ulong sigma_0(ulong x); // 0x00000001814AB320-0x00000001814AB390
		private static ulong sigma_1(ulong x); // 0x00000001814AB390-0x00000001814AB400
		private static unsafe void SHA512Expand(ulong* x); // 0x00000001814A9C60-0x00000001814A9DE0
	}
}
