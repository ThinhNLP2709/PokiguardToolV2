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
	public class X509Extension : AsnEncodedData // TypeDefIndex: 8794
	{
		// Fields
		private bool _critical; // 0x20
	
		// Properties
		public bool Critical { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		protected X509Extension(); // 0x00000001802F4070-0x00000001802F4080
		public X509Extension(string oid, byte[] rawData, bool critical); // 0x0000000181BA0E90-0x0000000181BA0EC0
	
		// Methods
		public override void CopyFrom(AsnEncodedData asnEncodedData); // 0x0000000181BA0C80-0x0000000181BA0DA0
		internal string FormatUnkownData(byte[] data); // 0x0000000181BA0DA0-0x0000000181BA0E90
	}
}
