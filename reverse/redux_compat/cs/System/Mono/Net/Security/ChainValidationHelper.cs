/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal class ChainValidationHelper : ICertificateValidator // TypeDefIndex: 8555
	{
		// Fields
		private readonly WeakReference<SslStream> owner; // 0x10
		private readonly MonoTlsSettings settings; // 0x18
		private readonly MobileTlsProvider provider; // 0x20
		private readonly ServerCertValidationCallback certValidationCallback; // 0x28
		private readonly LocalCertSelectionCallback certSelectionCallback; // 0x30
		private readonly MonoTlsStream tlsStream; // 0x38
		private readonly HttpWebRequest request; // 0x40
	
		// Properties
		public MonoTlsSettings Settings { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 8556
		{
			// Fields
			public MonoTlsSettings settings; // 0x10
	
			// Constructors
			public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetValidationCallback_b__0(object s, X509Certificate c, X509Chain ch, SslPolicyErrors e); // 0x0000000181823690-0x00000001818237E0
		}
	
		// Constructors
		private ChainValidationHelper(SslStream owner, MobileTlsProvider provider, MonoTlsSettings settings, bool cloneSettings, MonoTlsStream stream); // 0x0000000181811130-0x0000000181811530
	
		// Methods
		internal static ChainValidationHelper GetInternalValidator(SslStream owner, MobileTlsProvider provider, MonoTlsSettings settings); // 0x0000000181810800-0x00000001818108F0
		internal static ChainValidationHelper Create(MobileTlsProvider provider, ref MonoTlsSettings settings, MonoTlsStream stream); // 0x0000000181810710-0x00000001818107C0
		private static ServerCertValidationCallback GetValidationCallback(MonoTlsSettings settings); // 0x00000001818108F0-0x00000001818109E0
		private static X509Certificate DefaultSelectionCallback(string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers); // 0x00000001818107C0-0x0000000181810800
		public bool SelectClientCertificate(string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers, out X509Certificate clientCertificate); // 0x0000000181810AA0-0x0000000181810B00
		public ValidationResult ValidateCertificate(string host, bool serverMode, X509Certificate leaf, X509Chain chain); // 0x0000000181810B00-0x0000000181810BA0
		private ValidationResult ValidateChain(string host, bool server, X509Certificate leaf, X509Chain chain, X509CertificateCollection certs, SslPolicyErrors errors); // 0x0000000181810BA0-0x0000000181810CA0
		private ValidationResult ValidateChain(string host, bool server, X509Certificate leaf, ref X509Chain chain, X509CertificateCollection certs, SslPolicyErrors errors); // 0x0000000181810CA0-0x0000000181811130
		private bool InvokeCallback(X509Certificate leaf, X509Chain chain, SslPolicyErrors errors); // 0x00000001818109E0-0x0000000181810AA0
	}
}
