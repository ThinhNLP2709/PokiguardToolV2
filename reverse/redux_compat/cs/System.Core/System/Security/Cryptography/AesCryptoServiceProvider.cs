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
	public sealed class AesCryptoServiceProvider : Aes // TypeDefIndex: 11974
	{
		// Properties
		public override byte[] IV { get; set; } // 0x0000000181782160-0x0000000181782170 0x0000000181782180-0x0000000181782190
		public override byte[] Key { get; set; } // 0x0000000181782170-0x0000000181782180 0x00000001817821A0-0x00000001817821B0
		public override int KeySize { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x0000000181782190-0x00000001817821A0
		public override int FeedbackSize { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public override CipherMode Mode { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001817821B0-0x0000000181782220
		public override PaddingMode Padding { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x0000000181782220-0x0000000181782230
	
		// Constructors
		public AesCryptoServiceProvider(); // 0x0000000181782100-0x0000000181782160
	
		// Methods
		public override void GenerateIV(); // 0x00000001817820A0-0x00000001817820D0
		public override void GenerateKey(); // 0x00000001817820D0-0x0000000181782100
		public override ICryptoTransform CreateDecryptor(byte[] key, byte[] iv); // 0x0000000181781E90-0x0000000181781F90
		public override ICryptoTransform CreateEncryptor(byte[] key, byte[] iv); // 0x0000000181781F90-0x0000000181782090
		public override ICryptoTransform CreateDecryptor(); // 0x00000001814AB520-0x00000001814AB590
		public override ICryptoTransform CreateEncryptor(); // 0x00000001814AB590-0x00000001814AB600
		protected override void Dispose(bool disposing); // 0x0000000181782090-0x00000001817820A0
	}
}
