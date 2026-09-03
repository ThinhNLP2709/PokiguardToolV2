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
	public abstract class TripleDES : SymmetricAlgorithm // TypeDefIndex: 2835
	{
		// Fields
		private static KeySizes[] s_legalBlockSizes; // 0x00
		private static KeySizes[] s_legalKeySizes; // 0x08
	
		// Properties
		public override byte[] Key { get; set; } // 0x00000001814ACBA0-0x00000001814ACC80 0x00000001814ACC80-0x00000001814ACEA0
	
		// Constructors
		protected TripleDES(); // 0x00000001814ACAF0-0x00000001814ACBA0
		static TripleDES(); // 0x00000001814AC980-0x00000001814ACAF0
	
		// Methods
		public static TripleDES Create(); // 0x00000001814AC4D0-0x00000001814AC520
		public static bool IsWeakKey(byte[] rgbKey); // 0x00000001814AC7A0-0x00000001814AC980
		private static bool EqualBytes(byte[] rgbKey, int start1, int start2, int count); // 0x00000001814AC520-0x00000001814AC780
		private static bool IsLegalKeySize(byte[] rgbKey); // 0x00000001814AC780-0x00000001814AC7A0
	}
}
