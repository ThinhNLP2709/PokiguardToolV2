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
	public class CoreWebView2ServiceWorkerRegisteredEventArgs : EventArgs // TypeDefIndex: 10610
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServiceWorkerRegisteredEventArgs _nativeICoreWebView2ServiceWorkerRegisteredEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ServiceWorkerRegisteredEventArgs _nativeICoreWebView2ServiceWorkerRegisteredEventArgs { get; set; } // 0x00000001813CE100-0x00000001813CE210 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ServiceWorkerRegistration ServiceWorkerRegistration { get; } // 0x00000001813CDF30-0x00000001813CE100 
	
		// Constructors
		internal CoreWebView2ServiceWorkerRegisteredEventArgs(object rawCoreWebView2ServiceWorkerRegisteredEventArgs); // 0x00000001813CDEC0-0x00000001813CDF30
	}
}
