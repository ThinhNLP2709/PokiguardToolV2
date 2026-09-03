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
using Mono.Security.X509;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal class X509ChainImplMono : X509ChainImpl // TypeDefIndex: 8790
	{
		// Fields
		private StoreLocation location; // 0x10
		private X509ChainElementCollection elements; // 0x18
		private X509ChainPolicy policy; // 0x20
		private X509ChainStatus[] status; // 0x28
		private static X509ChainStatus[] Empty; // 0x00
		private int max_path_length; // 0x30
		private X500DistinguishedName working_issuer_name; // 0x38
		private AsymmetricAlgorithm working_public_key; // 0x40
		private X509ChainElement bce_restriction; // 0x48
		private X509Certificate2Collection roots; // 0x50
		private X509Certificate2Collection cas; // 0x58
		private X509Store root_store; // 0x60
		private X509Store ca_store; // 0x68
		private X509Store user_root_store; // 0x70
		private X509Store user_ca_store; // 0x78
		private X509Certificate2Collection collection; // 0x80
	
		// Properties
		public override bool IsValid { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override X509ChainElementCollection ChainElements { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override X509ChainPolicy ChainPolicy { get; } // 0x00000001802F8630-0x00000001802F8640 
		private X509Certificate2Collection Roots { get; } // 0x0000000181B9E6F0-0x0000000181B9E8A0 
		private X509Certificate2Collection CertificateAuthorities { get; } // 0x0000000181B9E1C0-0x0000000181B9E370 
		private X509Store LMRootStore { get; } // 0x0000000181B9E650-0x0000000181B9E6F0 
		private X509Store UserRootStore { get; } // 0x0000000181B9E940-0x0000000181B9E9E0 
		private X509Store LMCAStore { get; } // 0x0000000181B9E5B0-0x0000000181B9E650 
		private X509Store UserCAStore { get; } // 0x0000000181B9E8A0-0x0000000181B9E940 
		private X509Certificate2Collection CertificateCollection { get; } // 0x0000000181B9E370-0x0000000181B9E5B0 
	
		// Constructors
		public X509ChainImplMono(bool useMachineContext); // 0x0000000181B9DFC0-0x0000000181B9E1C0
		static X509ChainImplMono(); // 0x0000000181B9DF50-0x0000000181B9DFC0
	
		// Methods
		public override void AddStatus(X509ChainStatusFlags error); // 0x00000001802E76C0-0x00000001802E76D0
		[MonoTODO("Not totally RFC3280 compliant, but neither is MS implementation...")]
		public override bool Build(X509Certificate2 certificate); // 0x0000000181B9B0F0-0x0000000181B9B840
		public override void Reset(); // 0x0000000181B9D630-0x0000000181B9D810
		private X509ChainStatusFlags BuildChainFrom(X509Certificate2 certificate); // 0x0000000181B9AD60-0x0000000181B9B0F0
		private X509Certificate2 SelectBestFromCollection(X509Certificate2 child, X509Certificate2Collection c); // 0x0000000181B9D810-0x0000000181B9DB40
		private X509Certificate2 FindParent(X509Certificate2 certificate); // 0x0000000181B9C320-0x0000000181B9C4D0
		private bool IsChainComplete(X509Certificate2 certificate); // 0x0000000181B9C7E0-0x0000000181B9C930
		private bool IsSelfIssued(X509Certificate2 certificate); // 0x0000000181B9C930-0x0000000181B9C980
		private void ValidateChain(X509ChainStatusFlags flag); // 0x0000000181B9DB40-0x0000000181B9DDE0
		private void Process(int n); // 0x0000000181B9D2D0-0x0000000181B9D630
		private void PrepareForNextCertificate(int n); // 0x0000000181B9C9D0-0x0000000181B9CD00
		private void WrapUp(); // 0x0000000181B9DDE0-0x0000000181B9DF50
		private void ProcessCertificateExtensions(X509ChainElement element); // 0x0000000181B9CD00-0x0000000181B9CEB0
		private bool IsSignedWith(X509Certificate2 signed, AsymmetricAlgorithm pubkey); // 0x0000000181B9C980-0x0000000181B9C9D0
		private string GetSubjectKeyIdentifier(X509Certificate2 certificate); // 0x0000000181B9C740-0x0000000181B9C7E0
		private static string GetAuthorityKeyIdentifier(X509Certificate2 certificate); // 0x0000000181B9C4D0-0x0000000181B9C560
		private static string GetAuthorityKeyIdentifier(X509Crl crl); // 0x0000000181B9C560-0x0000000181B9C5E0
		private static string GetAuthorityKeyIdentifier(X509Extension ext); // 0x0000000181B9C5E0-0x0000000181B9C740
		private void CheckRevocationOnChain(X509ChainStatusFlags flag); // 0x0000000181B9BAB0-0x0000000181B9BD10
		private X509ChainStatusFlags CheckRevocation(X509Certificate2 certificate, int ca, bool online); // 0x0000000181B9BF40-0x0000000181B9C080
		private X509ChainStatusFlags CheckRevocation(X509Certificate2 certificate, X509Certificate2 ca_cert, bool online); // 0x0000000181B9BD10-0x0000000181B9BF40
		private static X509Crl CheckCrls(string subject, string ski, X509Store store); // 0x0000000181B9B840-0x0000000181B9BAB0
		private X509Crl FindCrl(X509Certificate2 caCertificate); // 0x0000000181B9C080-0x0000000181B9C320
		private bool ProcessCrlExtensions(X509Crl crl); // 0x0000000181B9D0A0-0x0000000181B9D2D0
		private bool ProcessCrlEntryExtensions(X509Crl.X509CrlEntry entry); // 0x0000000181B9CEB0-0x0000000181B9D0A0
	}
}
