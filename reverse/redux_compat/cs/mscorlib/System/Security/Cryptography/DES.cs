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
	public abstract class DES : SymmetricAlgorithm // TypeDefIndex: 2789
	{
		// Fields
		private static KeySizes[] s_legalBlockSizes; // 0x00
		private static KeySizes[] s_legalKeySizes; // 0x08
	
		// Properties
		public override byte[] Key { get; set; } // 0x000000018148DC30-0x000000018148DD40 0x000000018148DD40-0x000000018148DFE0
	
		// Constructors
		protected DES(); // 0x000000018148DB90-0x000000018148DC30
		static DES(); // 0x000000018148DA30-0x000000018148DB90
	
		// Methods
		public static DES Create(); // 0x000000018148D540-0x000000018148D6C0
		public static bool IsWeakKey(byte[] rgbKey); // 0x000000018148D860-0x000000018148D970
		public static bool IsSemiWeakKey(byte[] rgbKey); // 0x000000018148D6D0-0x000000018148D860
		private static bool IsLegalKeySize(byte[] rgbKey); // 0x000000018148D6C0-0x000000018148D6D0
		private static ulong QuadWordFromBigEndian(byte[] block); // 0x000000018148D970-0x000000018148DA30
	}
}
