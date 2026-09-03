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
	public sealed class MD5CryptoServiceProvider : MD5 // TypeDefIndex: 2841
	{
		// Fields
		private uint[] _H; // 0x28
		private uint[] buff; // 0x30
		private ulong count; // 0x38
		private byte[] _ProcessingBuffer; // 0x40
		private int _ProcessingBufferCount; // 0x48
		private static readonly uint[] K; // 0x00
	
		// Constructors
		public MD5CryptoServiceProvider(); // 0x00000001814A2710-0x00000001814A27D0
		static MD5CryptoServiceProvider(); // 0x00000001814A2630-0x00000001814A2710
	
		// Methods
		~MD5CryptoServiceProvider(); // 0x00000001814A0E60-0x00000001814A0EE0
		protected override void Dispose(bool disposing); // 0x00000001814A0DE0-0x00000001814A0E60
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814A0EE0-0x00000001814A1020
		protected override byte[] HashFinal(); // 0x00000001814A1020-0x00000001814A1110
		public override void Initialize(); // 0x00000001814A1110-0x00000001814A1190
		private void ProcessBlock(byte[] inputBuffer, int inputOffset); // 0x00000001814A1190-0x00000001814A23F0
		private void ProcessFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x00000001814A23F0-0x00000001814A2630
		internal void AddLength(ulong length, byte[] buffer, int position); // 0x00000001814A0D00-0x00000001814A0DE0
	}
}
