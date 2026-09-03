/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	internal class DESTransform : SymmetricTransform // TypeDefIndex: 2839
	{
		// Fields
		internal static readonly int KEY_BIT_SIZE; // 0x00
		internal static readonly int KEY_BYTE_SIZE; // 0x04
		internal static readonly int BLOCK_BIT_SIZE; // 0x08
		internal static readonly int BLOCK_BYTE_SIZE; // 0x0C
		private byte[] keySchedule; // 0x58
		private byte[] byteBuff; // 0x60
		private uint[] dwordBuff; // 0x68
		private static readonly uint[] spBoxes; // 0x10
		private static readonly byte[] PC1; // 0x18
		private static readonly byte[] leftRotTotal; // 0x20
		private static readonly byte[] PC2; // 0x28
		internal static readonly uint[] ipTab; // 0x30
		internal static readonly uint[] fpTab; // 0x38
	
		// Constructors
		internal DESTransform(SymmetricAlgorithm symmAlgo, bool encryption, byte[] key, byte[] iv); // 0x00000001814A0490-0x00000001814A07C0
		static DESTransform(); // 0x00000001814A0180-0x00000001814A0490
	
		// Methods
		private uint CipherFunct(uint r, int n); // 0x000000018149F1C0-0x000000018149F490
		internal static void Permutation(byte[] input, byte[] output, uint[] permTab, bool preSwap); // 0x000000018149F640-0x000000018149F9E0
		private static void BSwap(byte[] byteBuff); // 0x000000018149F130-0x000000018149F1C0
		internal void SetKey(byte[] key); // 0x000000018149FE10-0x00000001814A0180
		public void ProcessBlock(byte[] input, byte[] output); // 0x000000018149F9E0-0x000000018149FE10
		protected override void ECB(byte[] input, byte[] output); // 0x000000018149F490-0x000000018149F560
		internal static byte[] GetStrongKey(); // 0x000000018149F560-0x000000018149F640
	}
}
