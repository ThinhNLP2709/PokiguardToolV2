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
	public sealed class X509EnhancedKeyUsageExtension : X509Extension // TypeDefIndex: 8793
	{
		// Fields
		private OidCollection _enhKeyUsage; // 0x28
		private AsnDecodeStatus _status; // 0x30
	
		// Constructors
		public X509EnhancedKeyUsageExtension(); // 0x0000000181BA0080-0x0000000181BA0110
		public X509EnhancedKeyUsageExtension(AsnEncodedData encodedEnhancedKeyUsages, bool critical); // 0x0000000181BA0110-0x0000000181BA01F0
		public X509EnhancedKeyUsageExtension(OidCollection enhancedKeyUsages, bool critical); // 0x0000000181BA01F0-0x0000000181BA0450
	
		// Methods
		public override void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181B9F940-0x0000000181B9FB20
		internal AsnDecodeStatus Decode(byte[] extension); // 0x0000000181B9FB20-0x0000000181B9FD00
		internal byte[] Encode(); // 0x0000000181B9FD00-0x0000000181B9FDD0
		internal override string ToString(bool multiLine); // 0x0000000181B9FDD0-0x0000000181BA0080
	}
}
