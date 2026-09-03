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
	public class CoreWebView2DevToolsProtocolEventReceivedEventArgs : EventArgs // TypeDefIndex: 10538
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue; // 0x18
		internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs2 _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value; // 0x20
	
		// Properties
		internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs { get; set; } // 0x0000000181395790-0x00000001813958A0 0x00000001802FAF70-0x00000001802FAF80
		public string ParameterObjectAsJson { get; } // 0x00000001813953C0-0x0000000181395520 
		internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs2 _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2 { get; set; } // 0x0000000181395680-0x0000000181395790 0x000000018033E830-0x000000018033E840
		public string SessionId { get; } // 0x0000000181395520-0x0000000181395680 
	
		// Constructors
		internal CoreWebView2DevToolsProtocolEventReceivedEventArgs(object rawCoreWebView2DevToolsProtocolEventReceivedEventArgs); // 0x0000000181395350-0x00000001813953C0
	}
}
