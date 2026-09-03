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
	public sealed class RijndaelManagedTransform : ICryptoTransform // TypeDefIndex: 2813
	{
		// Fields
		private CipherMode m_cipherMode; // 0x10
		private PaddingMode m_paddingValue; // 0x14
		private RijndaelManagedTransformMode m_transformMode; // 0x18
		private int m_blockSizeBits; // 0x1C
		private int m_blockSizeBytes; // 0x20
		private int m_inputBlockSize; // 0x24
		private int m_outputBlockSize; // 0x28
		private int[] m_encryptKeyExpansion; // 0x30
		private int[] m_decryptKeyExpansion; // 0x38
		private int m_Nr; // 0x40
		private int m_Nb; // 0x44
		private int m_Nk; // 0x48
		private int[] m_encryptindex; // 0x50
		private int[] m_decryptindex; // 0x58
		private int[] m_IV; // 0x60
		private int[] m_lastBlockBuffer; // 0x68
		private byte[] m_depadBuffer; // 0x70
		private byte[] m_shiftRegister; // 0x78
		private static readonly byte[] s_Sbox; // 0x00
		private static readonly int[] s_Rcon; // 0x08
		private static readonly int[] s_T; // 0x10
		private static readonly int[] s_TF; // 0x18
		private static readonly int[] s_iT; // 0x20
		private static readonly int[] s_iTF; // 0x28
	
		// Properties
		public int InputBlockSize { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public int OutputBlockSize { get; } // 0x0000000180377930-0x0000000180377940 
		public bool CanTransformMultipleBlocks { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		internal RijndaelManagedTransform(byte[] rgbKey, CipherMode mode, byte[] rgbIV, int blockSize, int feedbackSize, PaddingMode PaddingValue, RijndaelManagedTransformMode transformMode); // 0x0000000181499C10-0x000000018149A2E0
		static RijndaelManagedTransform(); // 0x00000001814998F0-0x0000000181499C10
	
		// Methods
		public void Dispose(); // 0x0000000181497810-0x0000000181497930
		private void Dispose(bool disposing); // 0x0000000181497930-0x0000000181497A60
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset); // 0x0000000181499100-0x0000000181499520
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x0000000181499520-0x00000001814998F0
		public void Reset(); // 0x0000000181498F90-0x0000000181499010
		private int EncryptData(byte[] inputBuffer, int inputOffset, int inputCount, ref byte[] outputBuffer, int outputOffset, PaddingMode paddingMode, bool fLast); // 0x0000000181497C60-0x0000000181498900
		private int DecryptData(byte[] inputBuffer, int inputOffset, int inputCount, ref byte[] outputBuffer, int outputOffset, PaddingMode paddingMode, bool fLast); // 0x0000000181496970-0x0000000181497810
		private unsafe void Enc(int* encryptindex, int* encryptKeyExpansion, int* T, int* TF, int* work, int* temp); // 0x0000000181497A60-0x0000000181497C60
		private unsafe void Dec(int* decryptindex, int* decryptKeyExpansion, int* iT, int* iTF, int* work, int* temp); // 0x0000000181496730-0x0000000181496970
		private void GenerateKeyExpansion(byte[] rgbKey); // 0x0000000181498900-0x0000000181498F60
		private static int rot1(int val); // 0x000000018149A2E0-0x000000018149A2F0
		private static int rot2(int val); // 0x000000018149A2F0-0x000000018149A300
		private static int rot3(int val); // 0x000000018149A300-0x000000018149A310
		private static int SubWord(int a); // 0x0000000181499010-0x0000000181499100
		private static int MulX(int x); // 0x0000000181498F60-0x0000000181498F90
	}
}
