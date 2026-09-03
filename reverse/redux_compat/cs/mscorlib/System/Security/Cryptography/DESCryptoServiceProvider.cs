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
	public sealed class DESCryptoServiceProvider : DES // TypeDefIndex: 2790
	{
		// Constructors
		public DESCryptoServiceProvider(); // 0x000000018148D3F0-0x000000018148D540
	
		// Methods
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV); // 0x000000018148D0E0-0x000000018148D270
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV); // 0x000000018148CF50-0x000000018148D0E0
		public override void GenerateKey(); // 0x000000018148D2F0-0x000000018148D3F0
		public override void GenerateIV(); // 0x000000018148D270-0x000000018148D2F0
	}
}
