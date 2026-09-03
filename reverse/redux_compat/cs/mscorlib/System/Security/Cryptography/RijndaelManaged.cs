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
	public sealed class RijndaelManaged : Rijndael // TypeDefIndex: 2811
	{
		// Constructors
		public RijndaelManaged(); // 0x000000018149A660-0x000000018149A7C0
	
		// Methods
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV); // 0x000000018149A400-0x000000018149A4F0
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV); // 0x000000018149A310-0x000000018149A400
		public override void GenerateKey(); // 0x000000018149A530-0x000000018149A570
		public override void GenerateIV(); // 0x000000018149A4F0-0x000000018149A530
		private ICryptoTransform NewEncryptor(byte[] rgbKey, CipherMode mode, byte[] rgbIV, int feedbackSize, RijndaelManagedTransformMode encryptMode); // 0x000000018149A570-0x000000018149A660
	}
}
