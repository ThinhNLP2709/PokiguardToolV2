/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2ClientCertificateRequestedEventArgs : EventArgs // TypeDefIndex: 10521
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ClientCertificateRequestedEventArgs _nativeICoreWebView2ClientCertificateRequestedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ClientCertificateRequestedEventArgs _nativeICoreWebView2ClientCertificateRequestedEventArgs { get; set; } // 0x000000018136BA60-0x000000018136BB70 0x00000001802FAF70-0x00000001802FAF80
		public IReadOnlyList<string> AllowedCertificateAuthorities { get; } // 0x000000018136AED0-0x000000018136B040 
		public bool Cancel { get; set; } // 0x000000018136B040-0x000000018136B1A0 0x000000018136BB70-0x000000018136BCE0
		public bool Handled { get; set; } // 0x000000018136B1A0-0x000000018136B300 0x000000018136BCE0-0x000000018136BE50
		public string Host { get; } // 0x000000018136B300-0x000000018136B460 
		public bool IsProxy { get; } // 0x000000018136B460-0x000000018136B5C0 
		public IReadOnlyList<CoreWebView2ClientCertificate> MutuallyTrustedCertificates { get; } // 0x000000018136B5C0-0x000000018136B730 
		public int Port { get; } // 0x000000018136B730-0x000000018136B890 
		public CoreWebView2ClientCertificate SelectedCertificate { get; set; } // 0x000000018136B890-0x000000018136BA60 0x000000018136BE50-0x000000018136BFE0
	
		// Constructors
		internal CoreWebView2ClientCertificateRequestedEventArgs(object rawCoreWebView2ClientCertificateRequestedEventArgs); // 0x000000018136AE60-0x000000018136AED0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x000000018136ACD0-0x000000018136AE60
	}
}
