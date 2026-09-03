/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2ServerCertificateErrorDetectedEventArgs : EventArgs // TypeDefIndex: 10604
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServerCertificateErrorDetectedEventArgs _nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ServerCertificateErrorDetectedEventArgs _nativeICoreWebView2ServerCertificateErrorDetectedEventArgs { get; set; } // 0x00000001813CD180-0x00000001813CD290 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ServerCertificateErrorAction Action { get; set; } // 0x00000001813CCBA0-0x00000001813CCD00 0x00000001813CD290-0x00000001813CD400
		public CoreWebView2WebErrorStatus ErrorStatus { get; } // 0x00000001813CCD00-0x00000001813CCE60 
		public string RequestUri { get; } // 0x00000001813CCE60-0x00000001813CCFC0 
		public CoreWebView2Certificate ServerCertificate { get; } // 0x00000001813CCFC0-0x00000001813CD180 
	
		// Constructors
		internal CoreWebView2ServerCertificateErrorDetectedEventArgs(object rawCoreWebView2ServerCertificateErrorDetectedEventArgs); // 0x00000001813CCB30-0x00000001813CCBA0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813CC9A0-0x00000001813CCB30
	}
}
