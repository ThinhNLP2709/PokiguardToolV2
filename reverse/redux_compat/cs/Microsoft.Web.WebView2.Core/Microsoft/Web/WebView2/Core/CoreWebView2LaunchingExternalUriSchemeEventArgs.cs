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
	public class CoreWebView2LaunchingExternalUriSchemeEventArgs : EventArgs // TypeDefIndex: 10567
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2LaunchingExternalUriSchemeEventArgs _nativeICoreWebView2LaunchingExternalUriSchemeEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2LaunchingExternalUriSchemeEventArgs _nativeICoreWebView2LaunchingExternalUriSchemeEventArgs { get; set; } // 0x00000001813AEB20-0x00000001813AEC30 0x00000001802FAF70-0x00000001802FAF80
		public bool Cancel { get; set; } // 0x00000001813AE5A0-0x00000001813AE700 0x00000001813AEC30-0x00000001813AEDA0
		public string InitiatingOrigin { get; } // 0x00000001813AE700-0x00000001813AE860 
		public bool IsUserInitiated { get; } // 0x00000001813AE860-0x00000001813AE9C0 
		public string Uri { get; } // 0x00000001813AE9C0-0x00000001813AEB20 
	
		// Constructors
		internal CoreWebView2LaunchingExternalUriSchemeEventArgs(object rawCoreWebView2LaunchingExternalUriSchemeEventArgs); // 0x00000001813AE530-0x00000001813AE5A0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813AE3A0-0x00000001813AE530
	}
}
