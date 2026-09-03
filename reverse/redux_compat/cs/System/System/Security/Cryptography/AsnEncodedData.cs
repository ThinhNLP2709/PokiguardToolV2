/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography
{
	public class AsnEncodedData // TypeDefIndex: 8760
	{
		// Fields
		internal Oid _oid; // 0x10
		internal byte[] _raw; // 0x18
	
		// Properties
		public Oid Oid { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181B744A0-0x0000000181B74550
		public byte[] RawData { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181B74550-0x0000000181B74650
	
		// Constructors
		protected AsnEncodedData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public AsnEncodedData(string oid, byte[] rawData); // 0x0000000181B742A0-0x0000000181B74390
		public AsnEncodedData(Oid oid, byte[] rawData); // 0x0000000181B741E0-0x0000000181B742A0
		public AsnEncodedData(AsnEncodedData asnEncodedData); // 0x0000000181B74390-0x0000000181B744A0
	
		// Methods
		public virtual void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181B73510-0x0000000181B73650
		public virtual string Format(bool multiLine); // 0x0000000181B73810-0x0000000181B73850
		internal virtual string ToString(bool multiLine); // 0x0000000181B74010-0x0000000181B741E0
		internal string Default(bool multiLine); // 0x0000000181B73650-0x0000000181B73770
		internal string BasicConstraintsExtension(bool multiLine); // 0x0000000181B73470-0x0000000181B73510
		internal string EnhancedKeyUsageExtension(bool multiLine); // 0x0000000181B73770-0x0000000181B73810
		internal string KeyUsageExtension(bool multiLine); // 0x0000000181B73850-0x0000000181B738F0
		internal string SubjectKeyIdentifierExtension(bool multiLine); // 0x0000000181B73F70-0x0000000181B74010
		internal string SubjectAltName(bool multiLine); // 0x0000000181B73CA0-0x0000000181B73F70
		internal string NetscapeCertType(bool multiLine); // 0x0000000181B738F0-0x0000000181B73CA0
	}
}
