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
	public abstract class HashAlgorithm : ICryptoTransform // TypeDefIndex: 2777
	{
		// Fields
		private bool _disposed; // 0x10
		protected int HashSizeValue; // 0x14
		protected internal byte[] HashValue; // 0x18
		protected int State; // 0x20
	
		// Properties
		public virtual int HashSize { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public virtual byte[] Hash { get; } // 0x0000000181491030-0x0000000181491140 
		public virtual int InputBlockSize { get; } // 0x0000000180472790-0x00000001804727A0 
		public virtual int OutputBlockSize { get; } // 0x0000000180472790-0x00000001804727A0 
		public virtual bool CanTransformMultipleBlocks { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected HashAlgorithm(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static HashAlgorithm Create(string hashName); // 0x0000000181490B90-0x0000000181490C10
		public byte[] ComputeHash(byte[] buffer); // 0x00000001814908D0-0x00000001814909A0
		public byte[] ComputeHash(byte[] buffer, int offset, int count); // 0x00000001814909A0-0x0000000181490B90
		private byte[] CaptureHashCodeAndReinitialize(); // 0x00000001814907D0-0x0000000181490890
		public void Dispose(); // 0x0000000181490C20-0x0000000181490C90
		public void Clear(); // 0x0000000181490890-0x00000001814908D0
		protected virtual void Dispose(bool disposing); // 0x0000000181490C10-0x0000000181490C20
		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset); // 0x0000000181490C90-0x0000000181490D40
		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x0000000181490D40-0x0000000181490E70
		private void ValidateTransformBlock(byte[] inputBuffer, int inputOffset, int inputCount); // 0x0000000181490E70-0x0000000181491030
		protected abstract void HashCore(byte[] array, int ibStart, int cbSize);
		protected abstract byte[] HashFinal();
		public abstract void Initialize();
	}
}
