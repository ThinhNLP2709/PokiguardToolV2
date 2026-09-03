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
	public class CoreWebView2ServiceWorkerRegistration // TypeDefIndex: 10611
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServiceWorkerRegistration _nativeICoreWebView2ServiceWorkerRegistrationValue; // 0x18
		private EventRegistrationToken _ServiceWorkerActivatedToken; // 0x20
		private EventHandler<CoreWebView2ServiceWorkerActivatedEventArgs> privateServiceWorkerActivated; // 0x28
		private EventRegistrationToken _UnregisteringToken; // 0x30
		private EventHandler<object> privateUnregistering; // 0x38
	
		// Properties
		internal ICoreWebView2ServiceWorkerRegistration _nativeICoreWebView2ServiceWorkerRegistration { get; set; } // 0x00000001813CED20-0x00000001813CEE30 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ServiceWorker ActiveServiceWorker { get; } // 0x00000001813CE730-0x00000001813CE900 
		public string Origin { get; } // 0x00000001813CE900-0x00000001813CEA60 
		public string ScopeUri { get; } // 0x00000001813CEA60-0x00000001813CEBC0 
		public string TopLevelOrigin { get; } // 0x00000001813CEBC0-0x00000001813CED20 
	
		// Events
		public event EventHandler<CoreWebView2ServiceWorkerActivatedEventArgs> ServiceWorkerActivated {
			add; // 0x00000001813CE210-0x00000001813CE4A0
			remove; // 0x00000001813CEE30-0x00000001813CF030
		}
		public event EventHandler<object> Unregistering {
			add; // 0x00000001813CE4A0-0x00000001813CE730
			remove; // 0x00000001813CF030-0x00000001813CF230
		}
	
		// Constructors
		internal CoreWebView2ServiceWorkerRegistration(object rawCoreWebView2ServiceWorkerRegistration); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnServiceWorkerActivated(CoreWebView2ServiceWorkerActivatedEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnUnregistering(object args); // 0x000000018136EEF0-0x000000018136EF10
	}
}
