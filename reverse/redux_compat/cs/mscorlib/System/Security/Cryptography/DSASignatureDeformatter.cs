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
	public class DSASignatureDeformatter : AsymmetricSignatureDeformatter // TypeDefIndex: 2793
	{
		// Fields
		private DSA _dsaKey; // 0x10
		private string _oid; // 0x18
	
		// Constructors
		public DSASignatureDeformatter(); // 0x000000018148E450-0x000000018148E4D0
		public DSASignatureDeformatter(AsymmetricAlgorithm key); // 0x000000018148E2E0-0x000000018148E450
	
		// Methods
		public override void SetKey(AsymmetricAlgorithm key); // 0x000000018148E0A0-0x000000018148E1B0
		public override void SetHashAlgorithm(string strName); // 0x000000018148DFE0-0x000000018148E0A0
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature); // 0x000000018148E1B0-0x000000018148E2E0
	}
}
