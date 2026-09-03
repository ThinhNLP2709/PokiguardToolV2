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
	public sealed class X509SubjectKeyIdentifierExtension : X509Extension // TypeDefIndex: 8800
	{
		// Fields
		internal const string oid = "2.5.29.14"; // Metadata: 0x0069E10C
		internal const string friendlyName = "Subject Key Identifier"; // Metadata: 0x0069E116
		private byte[] _subjectKeyIdentifier; // 0x28
		private string _ski; // 0x30
		private AsnDecodeStatus _status; // 0x38
	
		// Properties
		public string SubjectKeyIdentifier { get; } // 0x0000000181BA3640-0x0000000181BA3730 
	
		// Constructors
		public X509SubjectKeyIdentifierExtension(); // 0x0000000181BA35B0-0x0000000181BA3640
		public X509SubjectKeyIdentifierExtension(AsnEncodedData encodedSubjectKeyIdentifier, bool critical); // 0x0000000181BA3010-0x0000000181BA30F0
		public X509SubjectKeyIdentifierExtension(byte[] subjectKeyIdentifier, bool critical); // 0x0000000181BA30F0-0x0000000181BA32E0
		public X509SubjectKeyIdentifierExtension(string subjectKeyIdentifier, bool critical); // 0x0000000181BA32E0-0x0000000181BA35B0
		public X509SubjectKeyIdentifierExtension(PublicKey key, bool critical); // 0x0000000181BA2FF0-0x0000000181BA3010
		public X509SubjectKeyIdentifierExtension(PublicKey key, X509SubjectKeyIdentifierHashAlgorithm algorithm, bool critical); // 0x0000000181BA2BD0-0x0000000181BA2FF0
	
		// Methods
		public override void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181BA23B0-0x0000000181BA2590
		internal static byte FromHexChar(char c); // 0x0000000181BA2750-0x0000000181BA2780
		internal static byte FromHexChars(char c1, char c2); // 0x0000000181BA2780-0x0000000181BA2800
		internal static byte[] FromHex(string hex); // 0x0000000181BA2800-0x0000000181BA2990
		internal AsnDecodeStatus Decode(byte[] extension); // 0x0000000181BA2590-0x0000000181BA26D0
		internal byte[] Encode(); // 0x0000000181BA26D0-0x0000000181BA2750
		internal override string ToString(bool multiLine); // 0x0000000181BA2990-0x0000000181BA2BD0
	}
}
