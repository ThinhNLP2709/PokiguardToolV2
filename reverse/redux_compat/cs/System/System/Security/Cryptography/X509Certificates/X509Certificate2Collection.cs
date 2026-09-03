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

namespace System.Security.Cryptography.X509Certificates
{
	public class X509Certificate2Collection : X509CertificateCollection // TypeDefIndex: 8777
	{
		// Fields
		private static string[] newline_split; // 0x00
	
		// Properties
		public new X509Certificate2 this[int index] { get => default; } // 0x0000000181B94520-0x0000000181B94680 
	
		// Constructors
		public X509Certificate2Collection(); // 0x0000000181412020-0x0000000181412030
		public X509Certificate2Collection(X509Certificate2Collection certificates); // 0x0000000181B94480-0x0000000181B94520
		static X509Certificate2Collection(); // 0x0000000181B943E0-0x0000000181B94480
	
		// Methods
		public int Add(X509Certificate2 certificate); // 0x0000000181B92F00-0x0000000181B92F90
		[MonoTODO("Method isn\'t transactional (like documented)")]
		public void AddRange(X509Certificate2Collection certificates); // 0x0000000181B92E70-0x0000000181B92F00
		public bool Contains(X509Certificate2 certificate); // 0x0000000181B92F90-0x0000000181B931D0
		private string GetKeyIdentifier(X509Certificate2 x); // 0x0000000181B94300-0x0000000181B943E0
		[MonoTODO("Does not support X509FindType.FindByTemplateName, FindByApplicationPolicy and FindByCertificatePolicy")]
		public X509Certificate2Collection Find(X509FindType findType, object findValue, bool validOnly); // 0x0000000181B931D0-0x0000000181B94260
		public new X509Certificate2Enumerator GetEnumerator(); // 0x0000000181B94260-0x0000000181B94300
	}
}
