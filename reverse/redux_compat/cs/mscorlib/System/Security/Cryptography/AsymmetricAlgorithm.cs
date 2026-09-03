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
	public abstract class AsymmetricAlgorithm : IDisposable // TypeDefIndex: 2779
	{
		// Fields
		protected int KeySizeValue; // 0x10
		protected KeySizes[] LegalKeySizesValue; // 0x18
	
		// Properties
		public virtual int KeySize { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x000000018148C920-0x000000018148CA40
	
		// Constructors
		protected AsymmetricAlgorithm(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x000000018148C830-0x000000018148C8A0
		public void Clear(); // 0x000000018148C830-0x000000018148C8A0
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void FromXmlString(string xmlString); // 0x000000018148C8A0-0x000000018148C8E0
		public virtual string ToXmlString(bool includePrivateParameters); // 0x000000018148C8E0-0x000000018148C920
	}
}
