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
	public abstract class RC2 : SymmetricAlgorithm // TypeDefIndex: 2808
	{
		// Fields
		protected int EffectiveKeySizeValue; // 0x48
		private static KeySizes[] s_legalBlockSizes; // 0x00
		private static KeySizes[] s_legalKeySizes; // 0x08
	
		// Properties
		public virtual int EffectiveKeySize { get; } // 0x0000000181492280-0x0000000181492290 
		public override int KeySize { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x0000000181492290-0x0000000181492310
	
		// Constructors
		protected RC2(); // 0x00000001814921E0-0x0000000181492280
		static RC2(); // 0x0000000181492070-0x00000001814921E0
	}
}
