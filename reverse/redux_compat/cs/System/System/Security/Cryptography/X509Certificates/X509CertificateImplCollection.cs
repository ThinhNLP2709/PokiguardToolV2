/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal class X509CertificateImplCollection : IDisposable // TypeDefIndex: 8784
	{
		// Fields
		private List<X509CertificateImpl> list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		public X509CertificateImpl this[int index] { get => default; } // 0x0000000180CAFA00-0x0000000180CAFA20 
	
		// Constructors
		public X509CertificateImplCollection(); // 0x0000000181B99510-0x0000000181B99590
		private X509CertificateImplCollection(X509CertificateImplCollection other); // 0x0000000181B99590-0x0000000181B99780
	
		// Methods
		public void Add(X509CertificateImpl impl, bool takeOwnership); // 0x0000000181B99260-0x0000000181B99340
		public X509CertificateImplCollection Clone(); // 0x0000000181B99340-0x0000000181B993A0
		public void Dispose(); // 0x0000000181B994A0-0x0000000181B99510
		protected virtual void Dispose(bool disposing); // 0x0000000181B993A0-0x0000000181B994A0
		~X509CertificateImplCollection(); // 0x0000000181428550-0x00000001814285D0
	}
}
