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
	public class CoreWebView2DevToolsProtocolEventReceiver // TypeDefIndex: 10539
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DevToolsProtocolEventReceiver _nativeICoreWebView2DevToolsProtocolEventReceiverValue; // 0x18
		private EventRegistrationToken _DevToolsProtocolEventReceivedToken; // 0x20
		private EventHandler<CoreWebView2DevToolsProtocolEventReceivedEventArgs> privateDevToolsProtocolEventReceived; // 0x28
	
		// Properties
		internal ICoreWebView2DevToolsProtocolEventReceiver _nativeICoreWebView2DevToolsProtocolEventReceiver { get; set; } // 0x0000000181395B30-0x0000000181395C40 0x00000001802FAF70-0x00000001802FAF80
	
		// Events
		public event EventHandler<CoreWebView2DevToolsProtocolEventReceivedEventArgs> DevToolsProtocolEventReceived {
			add; // 0x00000001813958A0-0x0000000181395B30
			remove; // 0x0000000181395C40-0x0000000181395E40
		}
	
		// Constructors
		internal CoreWebView2DevToolsProtocolEventReceiver(object rawCoreWebView2DevToolsProtocolEventReceiver); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnDevToolsProtocolEventReceived(CoreWebView2DevToolsProtocolEventReceivedEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
	}
}
