/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Security.Cryptography
{
	public sealed class AesManaged : Aes // TypeDefIndex: 11973
	{
		// Fields
		private RijndaelManaged m_rijndael; // 0x48
	
		// Properties
		public override int FeedbackSize { get; } // 0x0000000181782880-0x00000001817828B0 
		public override byte[] IV { get; set; } // 0x00000001817828B0-0x00000001817828E0 0x00000001817829A0-0x00000001817829D0
		public override byte[] Key { get; set; } // 0x0000000181782910-0x0000000181782940 0x0000000181782A00-0x0000000181782A30
		public override int KeySize { get; set; } // 0x00000001817828E0-0x0000000181782910 0x00000001817829D0-0x0000000181782A00
		public override CipherMode Mode { get; set; } // 0x0000000181782940-0x0000000181782970 0x0000000181782A30-0x0000000181782AE0
		public override PaddingMode Padding { get; set; } // 0x0000000181782970-0x00000001817829A0 0x0000000181782AE0-0x0000000181782B10
	
		// Constructors
		public AesManaged(); // 0x00000001817826F0-0x0000000181782880
	
		// Methods
		public override ICryptoTransform CreateDecryptor(); // 0x00000001817823D0-0x0000000181782400
		public override ICryptoTransform CreateDecryptor(byte[] key, byte[] iv); // 0x0000000181782230-0x00000001817823D0
		public override ICryptoTransform CreateEncryptor(); // 0x00000001817825A0-0x00000001817825D0
		public override ICryptoTransform CreateEncryptor(byte[] key, byte[] iv); // 0x0000000181782400-0x00000001817825A0
		protected override void Dispose(bool disposing); // 0x00000001817825D0-0x0000000181782690
		public override void GenerateIV(); // 0x0000000181782690-0x00000001817826C0
		public override void GenerateKey(); // 0x00000001817826C0-0x00000001817826F0
	}
}
