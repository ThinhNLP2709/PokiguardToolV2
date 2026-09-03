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
	public class CoreWebView2ServiceWorkerActivatedEventArgs : EventArgs // TypeDefIndex: 10606
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServiceWorkerActivatedEventArgs _nativeICoreWebView2ServiceWorkerActivatedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ServiceWorkerActivatedEventArgs _nativeICoreWebView2ServiceWorkerActivatedEventArgs { get; set; } // 0x00000001813CD640-0x00000001813CD750 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ServiceWorker ActiveServiceWorker { get; } // 0x00000001813CD470-0x00000001813CD640 
	
		// Constructors
		internal CoreWebView2ServiceWorkerActivatedEventArgs(object rawCoreWebView2ServiceWorkerActivatedEventArgs); // 0x00000001813CD400-0x00000001813CD470
	}
}
