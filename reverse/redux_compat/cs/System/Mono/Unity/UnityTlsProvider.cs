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
using Mono.Net.Security;
using Mono.Security.Interface;
using Mono.Util;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal class UnityTlsProvider : MobileTlsProvider // TypeDefIndex: 8540
	{
		// Properties
		public override string Name { get; } // 0x0000000181827340-0x0000000181827370 
		public override Guid ID { get; } // 0x00000001818272E0-0x0000000181827340 
		public override bool SupportsSslStream { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool SupportsMonoExtensions { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool SupportsConnectionInfo { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override bool SupportsCleanShutdown { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override SslProtocols SupportedProtocols { get; } // 0x0000000181827370-0x0000000181827380 
	
		// Constructors
		public UnityTlsProvider(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal override MobileAuthenticatedStream CreateSslStream(SslStream sslStream, Stream innerStream, bool leaveInnerStreamOpen, MonoTlsSettings settings); // 0x0000000181826710-0x00000001818268F0
		[MonoPInvokeCallback(typeof(UnityTls.unitytls_x509verify_callback))]
		private static unsafe UnityTls.unitytls_x509verify_result x509verify_callback(void* userData, UnityTls.unitytls_x509_ref cert, UnityTls.unitytls_x509verify_result result, UnityTls.unitytls_errorstate* errorState); // 0x0000000181827380-0x0000000181827400
		internal override bool ValidateCertificate(ChainValidationHelper validator, string targetHost, bool serverMode, X509CertificateCollection certificates, bool wantsChain, ref X509Chain chain, ref SslPolicyErrors errors, ref int status11); // 0x00000001818268F0-0x00000001818272E0
	}
}
