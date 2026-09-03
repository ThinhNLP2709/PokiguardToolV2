/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class X509Chain // TypeDefIndex: 13825
	{
		// Fields
		private X509CertificateCollection roots; // 0x10
		private X509CertificateCollection certs; // 0x18
		private X509Certificate _root; // 0x20
		private X509CertificateCollection _chain; // 0x28
		private X509ChainStatusFlags _status; // 0x30
	
		// Properties
		public X509CertificateCollection TrustAnchors { get; } // 0x0000000181415390-0x0000000181415430 
	
		// Constructors
		public X509Chain(); // 0x0000000181415320-0x0000000181415390
	
		// Methods
		public void LoadCertificates(X509CertificateCollection collection); // 0x00000001814152B0-0x00000001814152D0
		public bool Build(X509Certificate leaf); // 0x0000000181414740-0x0000000181414B40
		public void Reset(); // 0x00000001814152D0-0x0000000181415320
		private bool IsValid(X509Certificate cert); // 0x0000000181415120-0x00000001814152B0
		private X509Certificate FindCertificateParent(X509Certificate child); // 0x0000000181414B40-0x0000000181414D50
		private X509Certificate FindCertificateRoot(X509Certificate potentialRoot); // 0x0000000181414D50-0x0000000181414F60
		private bool IsTrusted(X509Certificate potentialTrusted); // 0x00000001814150E0-0x0000000181415120
		private bool IsParent(X509Certificate child, X509Certificate parent); // 0x0000000181414F60-0x00000001814150E0
	}
}
