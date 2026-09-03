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
	public abstract class DSA : AsymmetricAlgorithm // TypeDefIndex: 2792
	{
		// Constructors
		protected DSA(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static DSA Create(); // 0x000000018148E550-0x000000018148E5A0
		public abstract bool VerifySignature(byte[] rgbHash, byte[] rgbSignature);
		public override void FromXmlString(string xmlString); // 0x000000018148E5A0-0x000000018148EEE0
		public override string ToXmlString(bool includePrivateParameters); // 0x000000018148EEE0-0x000000018148F290
		public abstract DSAParameters ExportParameters(bool includePrivateParameters);
		public abstract void ImportParameters(DSAParameters parameters);
	}
}
