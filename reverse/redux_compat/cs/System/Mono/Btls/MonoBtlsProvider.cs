/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Mono.Net.Security;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsProvider : MobileTlsProvider // TypeDefIndex: 8599
	{
		// Properties
		public override Guid ID { get; } // 0x000000018181CF10-0x000000018181CF70 
		public override string Name { get; } // 0x000000018181CF70-0x000000018181CFA0 
		public override bool SupportsSslStream { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool SupportsMonoExtensions { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool SupportsConnectionInfo { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override bool SupportsCleanShutdown { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override SslProtocols SupportedProtocols { get; } // 0x000000018181CFA0-0x000000018181CFB0 
	
		// Constructors
		internal MonoBtlsProvider(); // 0x000000018181CE70-0x000000018181CF10
	
		// Methods
		internal override MobileAuthenticatedStream CreateSslStream(SslStream sslStream, Stream innerStream, bool leaveInnerStreamOpen, MonoTlsSettings settings); // 0x000000018181AE20-0x000000018181AEC0
		internal X509Certificate2Impl GetNativeCertificate(byte[] data, string password, X509KeyStorageFlags flags); // 0x000000018181AFF0-0x000000018181B140
		internal X509Certificate2Impl GetNativeCertificate(X509Certificate certificate); // 0x000000018181B1C0-0x000000018181B2E0
		internal X509Certificate2Impl GetNativeCertificate(byte[] data, SafePasswordHandle password, X509KeyStorageFlags flags); // 0x000000018181B140-0x000000018181B1C0
		internal static MonoBtlsX509VerifyParam GetVerifyParam(MonoTlsSettings settings, string targetHost, bool serverMode); // 0x000000018181B5E0-0x000000018181B750
		internal override bool ValidateCertificate(ChainValidationHelper validator, string targetHost, bool serverMode, X509CertificateCollection certificates, bool wantsChain, ref X509Chain chain, ref SslPolicyErrors errors, ref int status11); // 0x000000018181BDE0-0x000000018181C820
		internal static bool ValidateCertificate(MonoBtlsX509Chain chain, MonoBtlsX509VerifyParam param); // 0x000000018181C820-0x000000018181CE70
		private void CheckValidationResult(ChainValidationHelper validator, string targetHost, bool serverMode, X509CertificateCollection certificates, bool wantsChain, X509Chain chain, MonoBtlsX509StoreCtx storeCtx, bool success, ref SslPolicyErrors errors, ref int status11); // 0x000000018181A9D0-0x000000018181AD00
		internal static X509ChainStatusFlags MapVerifyErrorToChainStatus(MonoBtlsX509Error code); // 0x000000018181B750-0x000000018181B9A0
		internal static void SetupCertificateStore(MonoBtlsX509Store store, MonoTlsSettings settings, bool server); // 0x000000018181B9A0-0x000000018181BD50
		private static void SetupDefaultCertificateStore(MonoBtlsX509Store store); // 0x000000018181BD50-0x000000018181BDE0
		private static void AddUserStore(MonoBtlsX509Store store); // 0x000000018181A970-0x000000018181A9D0
		private static void AddMachineStore(MonoBtlsX509Store store); // 0x000000018181A8D0-0x000000018181A930
		private static void AddTrustedRoots(MonoBtlsX509Store store, MonoTlsSettings settings, bool server); // 0x000000018181A930-0x000000018181A970
		public static X509Certificate2 CreateCertificate(MonoBtlsX509 x509); // 0x000000018181AD00-0x000000018181AE20
		public static X509Chain GetManagedChain(MonoBtlsX509Chain chain); // 0x000000018181AF70-0x000000018181AFF0
		public static MonoBtlsX509 GetBtlsCertificate(X509Certificate certificate); // 0x000000018181AEC0-0x000000018181AF70
		public static MonoBtlsX509Chain GetNativeChain(X509CertificateCollection certificates); // 0x000000018181B2E0-0x000000018181B5E0
	}
}
