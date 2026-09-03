/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security.Cryptography
{
	internal abstract class SymmetricTransform : ICryptoTransform // TypeDefIndex: 2134
	{
		// Fields
		protected SymmetricAlgorithm algo; // 0x10
		protected bool encrypt; // 0x18
		protected int BlockSizeByte; // 0x1C
		protected byte[] temp; // 0x20
		protected byte[] temp2; // 0x28
		private byte[] workBuff; // 0x30
		private byte[] workout; // 0x38
		protected PaddingMode padmode; // 0x40
		protected int FeedBackByte; // 0x44
		private bool m_disposed; // 0x48
		protected bool lastBlock; // 0x49
		private RandomNumberGenerator _rng; // 0x50
	
		// Properties
		public virtual bool CanTransformMultipleBlocks { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public virtual int InputBlockSize { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public virtual int OutputBlockSize { get; } // 0x0000000180B232F0-0x0000000180B23300 
		private bool KeepLastBlock { get; } // 0x0000000181460A80-0x0000000181460AA0 
	
		// Constructors
		public SymmetricTransform(SymmetricAlgorithm symmAlgo, bool encryption, byte[] rgbIV); // 0x0000000181460720-0x0000000181460A80
	
		// Methods
		~SymmetricTransform(); // 0x000000018145FC70-0x000000018145FCF0
		void IDisposable.Dispose(); // 0x0000000181460000-0x0000000181460070
		protected virtual void Dispose(bool disposing); // 0x000000018145F570-0x000000018145F5E0
		protected virtual void Transform(byte[] input, byte[] output); // 0x00000001814605A0-0x0000000181460720
		protected abstract void ECB(byte[] input, byte[] output);
		protected virtual void CBC(byte[] input, byte[] output); // 0x000000018145F040-0x000000018145F190
		protected virtual void CFB(byte[] input, byte[] output); // 0x000000018145F190-0x000000018145F380
		protected virtual void OFB(byte[] input, byte[] output); // 0x000000018145FEE0-0x000000018145FF30
		protected virtual void CTS(byte[] input, byte[] output); // 0x000000018145F380-0x000000018145F3D0
		private void CheckInput(byte[] inputBuffer, int inputOffset, int inputCount); // 0x000000018145F3D0-0x000000018145F570
		public virtual int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset); // 0x00000001814601B0-0x00000001814604D0
		private int InternalTransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset); // 0x000000018145FCF0-0x000000018145FEE0
		private void Random(byte[] buffer, int start, int length); // 0x000000018145FF30-0x0000000181460000
		private void ThrowBadPaddingException(PaddingMode padding, int length, int position); // 0x0000000181460070-0x00000001814601B0
		protected virtual byte[] FinalEncrypt(byte[] inputBuffer, int inputOffset, int inputCount); // 0x000000018145F920-0x000000018145FC70
		protected virtual byte[] FinalDecrypt(byte[] inputBuffer, int inputOffset, int inputCount); // 0x000000018145F5E0-0x000000018145F920
		public virtual byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x00000001814604D0-0x00000001814605A0
	}
}
