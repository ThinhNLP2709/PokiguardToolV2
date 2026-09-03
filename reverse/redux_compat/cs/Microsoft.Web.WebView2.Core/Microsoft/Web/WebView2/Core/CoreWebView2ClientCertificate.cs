/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2ClientCertificate // TypeDefIndex: 10520
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ClientCertificate _nativeICoreWebView2ClientCertificateValue; // 0x18
		private static DateTime _unixEpoch; // 0x00
	
		// Properties
		internal ICoreWebView2ClientCertificate _nativeICoreWebView2ClientCertificate { get; set; } // 0x000000018136CD90-0x000000018136CEA0 0x00000001802FAF70-0x00000001802FAF80
		public string DerEncodedSerialNumber { get; } // 0x000000018136C460-0x000000018136C5C0 
		public string DisplayName { get; } // 0x000000018136C5C0-0x000000018136C720 
		public string Issuer { get; } // 0x000000018136C720-0x000000018136C880 
		public CoreWebView2ClientCertificateKind Kind { get; } // 0x000000018136C880-0x000000018136C9E0 
		public IReadOnlyList<string> PemEncodedIssuerCertificateChain { get; } // 0x000000018136C9E0-0x000000018136CB50 
		public string Subject { get; } // 0x000000018136CB50-0x000000018136CCB0 
		public DateTime ValidFrom { get; } // 0x000000018136CCB0-0x000000018136CD20 
		public DateTime ValidTo { get; } // 0x000000018136CD20-0x000000018136CD90 
	
		// Constructors
		internal CoreWebView2ClientCertificate(object rawCoreWebView2ClientCertificate); // 0x00000001803855F0-0x0000000180385630
		static CoreWebView2ClientCertificate(); // 0x000000018136C3D0-0x000000018136C460
	
		// Methods
		public string ToPemEncoding(); // 0x000000018136C140-0x000000018136C2A0
		public X509Certificate2 ToX509Certificate2(); // 0x000000018136C2A0-0x000000018136C3D0
		private DateTime SecondsSinceUnixEpochToDateTime(double seconds); // 0x000000018136BFE0-0x000000018136C140
	}
}
