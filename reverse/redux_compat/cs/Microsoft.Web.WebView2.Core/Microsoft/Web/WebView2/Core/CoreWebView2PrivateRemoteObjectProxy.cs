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
	internal class CoreWebView2PrivateRemoteObjectProxy // TypeDefIndex: 10586
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2PrivateRemoteObjectProxy _nativeICoreWebView2PrivateRemoteObjectProxyValue; // 0x18
		private EventRegistrationToken _PassivatedToken; // 0x20
		private EventHandler<object> privatePassivated; // 0x28
	
		// Properties
		internal ICoreWebView2PrivateRemoteObjectProxy _nativeICoreWebView2PrivateRemoteObjectProxy { get; set; } // 0x00000001813C1190-0x00000001813C12A0 0x00000001802FAF70-0x00000001802FAF80
	
		// Events
		internal event EventHandler<object> Passivated {
			add; // 0x00000001813C0F00-0x00000001813C1190
			remove; // 0x00000001813C12A0-0x00000001813C14A0
		}
	
		// Constructors
		internal CoreWebView2PrivateRemoteObjectProxy(object rawCoreWebView2PrivateRemoteObjectProxy); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnPassivated(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal int GetId(); // 0x00000001813C0DA0-0x00000001813C0F00
	}
}
