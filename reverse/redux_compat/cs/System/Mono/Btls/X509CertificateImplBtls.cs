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
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class X509CertificateImplBtls : X509Certificate2ImplUnix // TypeDefIndex: 8641
	{
		// Fields
		private MonoBtlsX509 x509; // 0xB0
		private MonoBtlsKey nativePrivateKey; // 0xB8
		private X509CertificateImplCollection intermediateCerts; // 0xC0
	
		// Properties
		public override bool IsValid { get; } // 0x0000000181B5B2A0-0x0000000181B5B2C0 
		internal MonoBtlsX509 X509 { get; } // 0x0000000181B5B2E0-0x0000000181B5B300 
		internal MonoBtlsKey NativePrivateKey { get; } // 0x0000000181B5B2C0-0x0000000181B5B2E0 
		internal override X509CertificateImplCollection IntermediateCertificates { get; } // 0x00000001806CCB70-0x00000001806CCB80 
		public override bool HasPrivateKey { get; } // 0x0000000180D90590-0x0000000180D905A0 
		public override AsymmetricAlgorithm PrivateKey { get; set; } // 0x0000000181B5A530-0x0000000181B5A570 0x0000000181B5B300-0x0000000181B5B3D0
	
		// Constructors
		internal X509CertificateImplBtls(MonoBtlsX509 x509); // 0x0000000181B5AE80-0x0000000181B5AED0
		private X509CertificateImplBtls(X509CertificateImplBtls other); // 0x0000000181B5AED0-0x0000000181B5AFB0
		internal X509CertificateImplBtls(byte[] data, MonoBtlsX509Format format); // 0x0000000181B5AFB0-0x0000000181B5B010
		internal X509CertificateImplBtls(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x0000000181B5B010-0x0000000181B5B2A0
	
		// Methods
		public override X509CertificateImpl Clone(); // 0x0000000181B5A390-0x0000000181B5A4A0
		protected override byte[] GetRawCertData(); // 0x0000000181B5A570-0x0000000181B5A5B0
		protected override void Dispose(bool disposing); // 0x0000000181B5A4A0-0x0000000181B5A4F0
		public override RSA GetRSAPrivateKey(); // 0x0000000181B5A530-0x0000000181B5A570
		public override DSA GetDSAPrivateKey(); // 0x0000000181B5A4F0-0x0000000181B5A530
		private void Import(byte[] data); // 0x0000000181B5AB20-0x0000000181B5AB80
		private void ImportPkcs12(byte[] data, SafePasswordHandle password); // 0x0000000181B5A690-0x0000000181B5AB20
		private void ImportAuthenticode(byte[] data); // 0x0000000181B5A5B0-0x0000000181B5A690
		public override bool Verify(X509Certificate2 thisCertificate); // 0x0000000181B5AB80-0x0000000181B5AE80
	}
}
