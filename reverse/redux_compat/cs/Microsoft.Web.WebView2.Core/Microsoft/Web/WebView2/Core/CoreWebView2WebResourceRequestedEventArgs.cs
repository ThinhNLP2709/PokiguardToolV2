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
	public class CoreWebView2WebResourceRequestedEventArgs : EventArgs // TypeDefIndex: 10622
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebResourceRequestedEventArgs _nativeICoreWebView2WebResourceRequestedEventArgsValue; // 0x18
		internal ICoreWebView2WebResourceRequestedEventArgs2 _nativeICoreWebView2WebResourceRequestedEventArgs2Value; // 0x20
	
		// Properties
		internal ICoreWebView2WebResourceRequestedEventArgs _nativeICoreWebView2WebResourceRequestedEventArgs { get; set; } // 0x00000001813D7CC0-0x00000001813D7DD0 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2WebResourceRequest Request { get; } // 0x00000001813D7550-0x00000001813D7720 
		public CoreWebView2WebResourceContext ResourceContext { get; } // 0x00000001813D7880-0x00000001813D79E0 
		public CoreWebView2WebResourceResponse Response { get; set; } // 0x00000001813D79E0-0x00000001813D7BB0 0x00000001813D7DD0-0x00000001813D7F60
		internal ICoreWebView2WebResourceRequestedEventArgs2 _nativeICoreWebView2WebResourceRequestedEventArgs2 { get; set; } // 0x00000001813D7BB0-0x00000001813D7CC0 0x000000018033E830-0x000000018033E840
		public CoreWebView2WebResourceRequestSourceKinds RequestedSourceKind { get; } // 0x00000001813D7720-0x00000001813D7880 
	
		// Constructors
		internal CoreWebView2WebResourceRequestedEventArgs(object rawCoreWebView2WebResourceRequestedEventArgs); // 0x00000001813D74E0-0x00000001813D7550
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813D7350-0x00000001813D74E0
	}
}
