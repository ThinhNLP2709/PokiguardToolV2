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
	public abstract class SymmetricAlgorithm : IDisposable // TypeDefIndex: 2834
	{
		// Fields
		protected int BlockSizeValue; // 0x10
		protected int FeedbackSizeValue; // 0x14
		protected byte[] IVValue; // 0x18
		protected byte[] KeyValue; // 0x20
		protected KeySizes[] LegalBlockSizesValue; // 0x28
		protected KeySizes[] LegalKeySizesValue; // 0x30
		protected int KeySizeValue; // 0x38
		protected CipherMode ModeValue; // 0x3C
		protected PaddingMode PaddingValue; // 0x40
	
		// Properties
		public virtual int BlockSize { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001814ABA50-0x00000001814ABBA0
		public virtual int FeedbackSize { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public virtual byte[] IV { get; set; } // 0x00000001814AB890-0x00000001814AB930 0x00000001814ABBA0-0x00000001814ABD10
		public virtual byte[] Key { get; set; } // 0x00000001814AB930-0x00000001814AB9D0 0x00000001814ABDB0-0x00000001814ABF40
		public virtual KeySizes[] LegalKeySizes { get; } // 0x00000001814AB9D0-0x00000001814ABA50 
		public virtual int KeySize { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001814ABD10-0x00000001814ABDB0
		public virtual CipherMode Mode { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001814ABF40-0x00000001814ABFC0
		public virtual PaddingMode Padding { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x00000001814ABFC0-0x00000001814AC040
	
		// Constructors
		protected SymmetricAlgorithm(); // 0x00000001814AB860-0x00000001814AB890
	
		// Methods
		public void Dispose(); // 0x00000001814AB750-0x00000001814AB7C0
		public void Clear(); // 0x00000001814AB470-0x00000001814AB520
		protected virtual void Dispose(bool disposing); // 0x00000001814AB6D0-0x00000001814AB750
		public bool ValidKeySize(int bitLength); // 0x00000001814AB7C0-0x00000001814AB860
		public static SymmetricAlgorithm Create(string algName); // 0x00000001814AB600-0x00000001814AB6D0
		public virtual ICryptoTransform CreateEncryptor(); // 0x00000001814AB590-0x00000001814AB600
		public abstract ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV);
		public virtual ICryptoTransform CreateDecryptor(); // 0x00000001814AB520-0x00000001814AB590
		public abstract ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV);
		public abstract void GenerateKey();
		public abstract void GenerateIV();
	}
}
