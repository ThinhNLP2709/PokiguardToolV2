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
using Microsoft.Win32.SafeHandles;
using Mono.Security.X509;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal class X509Certificate2ImplMono : X509Certificate2ImplUnix // TypeDefIndex: 8780
	{
		// Fields
		private X509CertificateImplCollection intermediateCerts; // 0xB0
		private X509Certificate _cert; // 0xB8
		private static string empty_error; // 0x00
		private static byte[] signedData; // 0x08
	
		// Properties
		public override bool IsValid { get; } // 0x0000000180D90590-0x0000000180D905A0 
		private X509Certificate Cert { get; } // 0x0000000181B5B2C0-0x0000000181B5B2E0 
		public override bool HasPrivateKey { get; } // 0x0000000181B958A0-0x0000000181B958D0 
		public override AsymmetricAlgorithm PrivateKey { get; set; } // 0x0000000181B958D0-0x0000000181B95D20 0x0000000181B95D20-0x0000000181B95F90
		internal override X509CertificateImplCollection IntermediateCertificates { get; } // 0x00000001806BAE60-0x00000001806BAE70 
		internal X509Certificate MonoCertificate { get; } // 0x00000001806CCB90-0x00000001806CCBA0 
	
		// Constructors
		public X509Certificate2ImplMono(X509Certificate cert); // 0x0000000181B957A0-0x0000000181B957E0
		private X509Certificate2ImplMono(X509Certificate2ImplMono other); // 0x0000000181B957E0-0x0000000181B958A0
		public X509Certificate2ImplMono(byte[] rawData, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x0000000181B95550-0x0000000181B957A0
		static X509Certificate2ImplMono(); // 0x0000000181B95470-0x0000000181B95550
	
		// Methods
		public override X509CertificateImpl Clone(); // 0x0000000181B948D0-0x0000000181B949C0
		protected override byte[] GetRawCertData(); // 0x0000000181B94AE0-0x0000000181B94B30
		public override RSA GetRSAPrivateKey(); // 0x0000000181B94A50-0x0000000181B94AE0
		public override DSA GetDSAPrivateKey(); // 0x0000000181B949C0-0x0000000181B94A50
		private X509Certificate ImportPkcs12(byte[] rawData, SafePasswordHandle password); // 0x0000000181B95260-0x0000000181B952D0
		private X509Certificate ImportPkcs12(byte[] rawData, string password); // 0x0000000181B94B30-0x0000000181B95260
		[MonoTODO("by default this depends on the incomplete X509Chain")]
		public override bool Verify(X509Certificate2 thisCertificate); // 0x0000000181B952D0-0x0000000181B95470
	}
}
