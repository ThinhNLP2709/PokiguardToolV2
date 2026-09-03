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
	public abstract class KeyedHashAlgorithm : HashAlgorithm // TypeDefIndex: 2803
	{
		// Fields
		protected byte[] KeyValue; // 0x28
	
		// Properties
		public virtual byte[] Key { get; set; } // 0x00000001814912A0-0x0000000181491320 0x0000000181491320-0x0000000181491440
	
		// Constructors
		protected KeyedHashAlgorithm(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected override void Dispose(bool disposing); // 0x0000000181491250-0x00000001814912A0
	}
}
