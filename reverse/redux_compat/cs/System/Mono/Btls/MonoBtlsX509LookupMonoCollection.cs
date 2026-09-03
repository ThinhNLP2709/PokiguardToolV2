/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsX509LookupMonoCollection : MonoBtlsX509LookupMono // TypeDefIndex: 8627
	{
		// Fields
		private long[] hashes; // 0x48
		private MonoBtlsX509[] certificates; // 0x50
		private X509CertificateCollection collection; // 0x58
		private MonoBtlsX509TrustKind trust; // 0x60
	
		// Constructors
		internal MonoBtlsX509LookupMonoCollection(X509CertificateCollection collection, MonoBtlsX509TrustKind trust); // 0x0000000181B4C0E0-0x0000000181B4C130
	
		// Methods
		private void Initialize(); // 0x0000000181B4BD10-0x0000000181B4C010
		protected override MonoBtlsX509 OnGetBySubject(MonoBtlsX509Name name); // 0x0000000181B4C010-0x0000000181B4C0E0
		protected override void Close(); // 0x0000000181B4BBA0-0x0000000181B4BD10
	}
}
