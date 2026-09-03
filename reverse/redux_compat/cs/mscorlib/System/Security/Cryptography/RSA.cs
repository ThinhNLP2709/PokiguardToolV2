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
	public abstract class RSA : AsymmetricAlgorithm // TypeDefIndex: 2817
	{
		// Constructors
		protected RSA(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static RSA Create(); // 0x0000000181495C90-0x0000000181495CF0
		public virtual byte[] EncryptValue(byte[] rgb); // 0x0000000181495CF0-0x0000000181495D50
		public override void FromXmlString(string xmlString); // 0x0000000181495D50-0x00000001814962D0
		public override string ToXmlString(bool includePrivateParameters); // 0x00000001814962D0-0x0000000181496670
		public abstract RSAParameters ExportParameters(bool includePrivateParameters);
		public abstract void ImportParameters(RSAParameters parameters);
	}
}
