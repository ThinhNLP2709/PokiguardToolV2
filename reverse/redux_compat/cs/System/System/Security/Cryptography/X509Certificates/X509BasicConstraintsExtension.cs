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
	public sealed class X509BasicConstraintsExtension : X509Extension // TypeDefIndex: 8775
	{
		// Fields
		internal const string oid = "2.5.29.19"; // Metadata: 0x0069E0D8
		internal const string friendlyName = "Basic Constraints"; // Metadata: 0x0069E0E2
		private bool _certificateAuthority; // 0x28
		private bool _hasPathLengthConstraint; // 0x29
		private int _pathLengthConstraint; // 0x2C
		private AsnDecodeStatus _status; // 0x30
	
		// Properties
		public bool CertificateAuthority { get; } // 0x0000000181B92D20-0x0000000181B92D90 
		public bool HasPathLengthConstraint { get; } // 0x0000000181B92D90-0x0000000181B92E00 
		public int PathLengthConstraint { get; } // 0x0000000181B92E00-0x0000000181B92E70 
	
		// Constructors
		public X509BasicConstraintsExtension(); // 0x0000000181B92BB0-0x0000000181B92C40
		public X509BasicConstraintsExtension(AsnEncodedData encodedBasicConstraints, bool critical); // 0x0000000181B92C40-0x0000000181B92D20
		public X509BasicConstraintsExtension(bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical); // 0x0000000181B92940-0x0000000181B92BB0
	
		// Methods
		public override void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181B92220-0x0000000181B92400
		internal AsnDecodeStatus Decode(byte[] extension); // 0x0000000181B92400-0x0000000181B92570
		internal byte[] Encode(); // 0x0000000181B92570-0x0000000181B926F0
		internal override string ToString(bool multiLine); // 0x0000000181B926F0-0x0000000181B92940
	}
}
