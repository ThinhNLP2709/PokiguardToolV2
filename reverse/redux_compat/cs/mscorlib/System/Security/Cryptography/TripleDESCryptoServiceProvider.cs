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
	public sealed class TripleDESCryptoServiceProvider : TripleDES // TypeDefIndex: 2836
	{
		// Constructors
		public TripleDESCryptoServiceProvider(); // 0x00000001814AC3E0-0x00000001814AC4D0
	
		// Methods
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV); // 0x00000001814AC160-0x00000001814AC280
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV); // 0x00000001814AC040-0x00000001814AC160
		public override void GenerateKey(); // 0x00000001814AC300-0x00000001814AC3E0
		public override void GenerateIV(); // 0x00000001814AC280-0x00000001814AC300
	}
}
