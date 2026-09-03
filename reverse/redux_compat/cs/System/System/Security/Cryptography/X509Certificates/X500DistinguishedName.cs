/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	[MonoTODO("Some X500DistinguishedNameFlags options aren\'t supported, like DoNotUsePlusSign, DoNotUseQuotes and ForceUTF8Encoding")]
	public sealed class X500DistinguishedName : AsnEncodedData // TypeDefIndex: 8774
	{
		// Fields
		private string name; // 0x20
		private byte[] canonEncoding; // 0x28
	
		// Properties
		public string Name { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public X500DistinguishedName(byte[] encodedDistinguishedName); // 0x0000000181B92110-0x0000000181B92220
		public X500DistinguishedName(string distinguishedName); // 0x0000000181B91E60-0x0000000181B91E70
		public X500DistinguishedName(string distinguishedName, X500DistinguishedNameFlags flag); // 0x0000000181B91E70-0x0000000181B92110
	
		// Methods
		public string Decode(X500DistinguishedNameFlags flag); // 0x0000000181B91BD0-0x0000000181B91D80
		public override string Format(bool multiLine); // 0x0000000181B91D80-0x0000000181B91DF0
		private static string GetSeparator(X500DistinguishedNameFlags flag); // 0x0000000181B91DF0-0x0000000181B91E60
		private void DecodeRawData(); // 0x0000000181B91AF0-0x0000000181B91BD0
		private static string Canonize(string s); // 0x0000000181B91920-0x0000000181B91AF0
		internal static bool AreEqual(X500DistinguishedName name1, X500DistinguishedName name2); // 0x0000000181B91700-0x0000000181B91920
	}
}
