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
	[TypeForwardedFrom("System.Core, Version=2.0.5.0, Culture=Neutral, PublicKeyToken=7cec85d7bea7798e")]
	public abstract class Aes : SymmetricAlgorithm // TypeDefIndex: 2778
	{
		// Fields
		private static KeySizes[] s_legalBlockSizes; // 0x00
		private static KeySizes[] s_legalKeySizes; // 0x08
	
		// Constructors
		protected Aes(); // 0x000000018148C780-0x000000018148C830
		static Aes(); // 0x000000018148C610-0x000000018148C780
	
		// Methods
		public static Aes Create(); // 0x000000018148C4E0-0x000000018148C610
		public static new Aes Create(string algorithmName); // 0x000000018148C3F0-0x000000018148C4E0
	}
}
