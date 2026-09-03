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
	public class CoreWebView2Certificate // TypeDefIndex: 10519
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Certificate _nativeICoreWebView2CertificateValue; // 0x18
		private static DateTime _unixEpoch; // 0x00
	
		// Properties
		internal ICoreWebView2Certificate _nativeICoreWebView2Certificate { get; set; } // 0x000000018136ABC0-0x000000018136ACD0 0x00000001802FAF70-0x00000001802FAF80
		public string DerEncodedSerialNumber { get; } // 0x000000018136A3F0-0x000000018136A550 
		public string DisplayName { get; } // 0x000000018136A550-0x000000018136A6B0 
		public string Issuer { get; } // 0x000000018136A6B0-0x000000018136A810 
		public IReadOnlyList<string> PemEncodedIssuerCertificateChain { get; } // 0x000000018136A810-0x000000018136A980 
		public string Subject { get; } // 0x000000018136A980-0x000000018136AAE0 
		public DateTime ValidFrom { get; } // 0x000000018136AAE0-0x000000018136AB50 
		public DateTime ValidTo { get; } // 0x000000018136AB50-0x000000018136ABC0 
	
		// Constructors
		internal CoreWebView2Certificate(object rawCoreWebView2Certificate); // 0x00000001803855F0-0x0000000180385630
		static CoreWebView2Certificate(); // 0x000000018136A360-0x000000018136A3F0
	
		// Methods
		public string ToPemEncoding(); // 0x000000018136A0D0-0x000000018136A230
		public X509Certificate2 ToX509Certificate2(); // 0x000000018136A230-0x000000018136A360
		private DateTime SecondsSinceUnixEpochToDateTime(double seconds); // 0x0000000181369F70-0x000000018136A0D0
	}
}
