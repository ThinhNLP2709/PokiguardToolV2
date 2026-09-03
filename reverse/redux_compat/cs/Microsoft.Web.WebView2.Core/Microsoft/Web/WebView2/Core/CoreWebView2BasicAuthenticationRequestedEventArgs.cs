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
	public class CoreWebView2BasicAuthenticationRequestedEventArgs : EventArgs // TypeDefIndex: 10513
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2BasicAuthenticationRequestedEventArgs _nativeICoreWebView2BasicAuthenticationRequestedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2BasicAuthenticationRequestedEventArgs _nativeICoreWebView2BasicAuthenticationRequestedEventArgs { get; set; } // 0x0000000181368B30-0x0000000181368C40 0x00000001802FAF70-0x00000001802FAF80
		public bool Cancel { get; set; } // 0x0000000181368540-0x00000001813686A0 0x0000000181368C40-0x0000000181368DB0
		public string Challenge { get; } // 0x00000001813686A0-0x0000000181368800 
		public CoreWebView2BasicAuthenticationResponse Response { get; } // 0x0000000181368800-0x00000001813689D0 
		public string Uri { get; } // 0x00000001813689D0-0x0000000181368B30 
	
		// Constructors
		internal CoreWebView2BasicAuthenticationRequestedEventArgs(object rawCoreWebView2BasicAuthenticationRequestedEventArgs); // 0x00000001813684D0-0x0000000181368540
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x0000000181368340-0x00000001813684D0
	}
}
