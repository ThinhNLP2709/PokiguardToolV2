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
	public sealed class RC2CryptoServiceProvider : RC2 // TypeDefIndex: 2809
	{
		// Fields
		private bool m_use40bitSalt; // 0x50
		private static KeySizes[] s_legalKeySizes; // 0x00
	
		// Properties
		public override int EffectiveKeySize { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
		// Constructors
		public RC2CryptoServiceProvider(); // 0x0000000181491E50-0x0000000181492070
		static RC2CryptoServiceProvider(); // 0x0000000181491D70-0x0000000181491E50
	
		// Methods
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV); // 0x0000000181491BA0-0x0000000181491C70
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV); // 0x0000000181491AD0-0x0000000181491BA0
		public override void GenerateKey(); // 0x0000000181491CF0-0x0000000181491D70
		public override void GenerateIV(); // 0x0000000181491C70-0x0000000181491CF0
	}
}
