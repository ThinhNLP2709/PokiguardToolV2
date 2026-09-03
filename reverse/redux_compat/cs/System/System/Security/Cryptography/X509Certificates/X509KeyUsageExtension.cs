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
	public sealed class X509KeyUsageExtension : X509Extension // TypeDefIndex: 8798
	{
		// Fields
		internal const string oid = "2.5.29.15"; // Metadata: 0x0069E0F4
		internal const string friendlyName = "Key Usage"; // Metadata: 0x0069E0FE
		internal const X509KeyUsageFlags all = X509KeyUsageFlags.None | X509KeyUsageFlags.EncipherOnly | X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.KeyAgreement | X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.DecipherOnly; // Metadata: 0x0069E108
		private X509KeyUsageFlags _keyUsages; // 0x28
		private AsnDecodeStatus _status; // 0x2C
	
		// Properties
		public X509KeyUsageFlags KeyUsages { get; } // 0x0000000181BA1D10-0x0000000181BA1D80 
	
		// Constructors
		public X509KeyUsageExtension(); // 0x0000000181BA1C80-0x0000000181BA1D10
		public X509KeyUsageExtension(AsnEncodedData encodedKeyUsage, bool critical); // 0x0000000181BA1AC0-0x0000000181BA1BA0
		public X509KeyUsageExtension(X509KeyUsageFlags keyUsages, bool critical); // 0x0000000181BA1BA0-0x0000000181BA1C80
	
		// Methods
		public override void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181BA1100-0x0000000181BA12E0
		internal X509KeyUsageFlags GetValidFlags(X509KeyUsageFlags flags); // 0x0000000181BA15B0-0x0000000181BA15C0
		internal AsnDecodeStatus Decode(byte[] extension); // 0x0000000181BA12E0-0x0000000181BA1440
		internal byte[] Encode(); // 0x0000000181BA1440-0x0000000181BA15B0
		internal override string ToString(bool multiLine); // 0x0000000181BA15C0-0x0000000181BA1AC0
	}
}
