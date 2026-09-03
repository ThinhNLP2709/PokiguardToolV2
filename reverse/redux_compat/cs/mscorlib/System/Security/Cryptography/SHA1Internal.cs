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
	internal class SHA1Internal // TypeDefIndex: 2846
	{
		// Fields
		private uint[] _H; // 0x10
		private ulong count; // 0x18
		private byte[] _ProcessingBuffer; // 0x20
		private int _ProcessingBufferCount; // 0x28
		private uint[] buff; // 0x30
	
		// Constructors
		public SHA1Internal(); // 0x00000001814A5C40-0x00000001814A5D70
	
		// Methods
		public void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A4840-0x00000001814A4980
		public byte[] HashFinal(); // 0x00000001814A4980-0x00000001814A4A70
		public void Initialize(); // 0x00000001814A51F0-0x00000001814A5280
		private void ProcessBlock(byte[] inputBuffer, uint inputOffset); // 0x00000001814A5280-0x00000001814A59F0
		private static void InitialiseBuff(uint[] buff, byte[] input, uint inputOffset); // 0x00000001814A4A70-0x00000001814A51F0
		private static void FillBuff(uint[] buff); // 0x00000001814A4510-0x00000001814A4840
		private void ProcessFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x00000001814A59F0-0x00000001814A5C40
		internal void AddLength(ulong length, byte[] buffer, int position); // 0x00000001814A4430-0x00000001814A4510
	}
}
