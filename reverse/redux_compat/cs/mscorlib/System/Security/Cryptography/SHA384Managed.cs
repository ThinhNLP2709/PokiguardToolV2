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
	public class SHA384Managed : SHA384 // TypeDefIndex: 2824
	{
		// Fields
		private byte[] _buffer; // 0x28
		private ulong _count; // 0x30
		private ulong[] _stateSHA384; // 0x38
		private ulong[] _W; // 0x40
		private static readonly ulong[] _K; // 0x00
	
		// Constructors
		public SHA384Managed(); // 0x00000001814A9880-0x00000001814A9960
		static SHA384Managed(); // 0x00000001814A97A0-0x00000001814A9880
	
		// Methods
		public override void Initialize(); // 0x00000001814A8210-0x00000001814A8270
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A80C0-0x00000001814A80D0
		protected override byte[] HashFinal(); // 0x00000001814A80D0-0x00000001814A80E0
		private void InitializeState(); // 0x00000001814A80E0-0x00000001814A8210
		private void _HashData(byte[] partIn, int ibStart, int cbSize); // 0x00000001814A9590-0x00000001814A97A0
		private byte[] _EndHash(); // 0x00000001814A92C0-0x00000001814A9590
		private static unsafe void SHATransform(ulong* expandedBuffer, ulong* state, byte* block); // 0x00000001814A8420-0x00000001814A91C0
		private static ulong RotateRight(ulong x, int n); // 0x00000001814A8280-0x00000001814A82A0
		private static ulong Ch(ulong x, ulong y, ulong z); // 0x00000001814A80B0-0x00000001814A80C0
		private static ulong Maj(ulong x, ulong y, ulong z); // 0x00000001814A8270-0x00000001814A8280
		private static ulong Sigma_0(ulong x); // 0x00000001814A91C0-0x00000001814A9240
		private static ulong Sigma_1(ulong x); // 0x00000001814A9240-0x00000001814A92C0
		private static ulong sigma_0(ulong x); // 0x00000001814A9960-0x00000001814A99D0
		private static ulong sigma_1(ulong x); // 0x00000001814A99D0-0x00000001814A9A40
		private static unsafe void SHA384Expand(ulong* x); // 0x00000001814A82A0-0x00000001814A8420
	}
}
