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
	public class CoreWebView2ServiceWorker // TypeDefIndex: 10605
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServiceWorker _nativeICoreWebView2ServiceWorkerValue; // 0x18
		private EventRegistrationToken _DestroyingToken; // 0x20
		private EventHandler<object> privateDestroying; // 0x28
		private EventRegistrationToken _WebMessageReceivedToken; // 0x30
		private EventHandler<CoreWebView2WebMessageReceivedEventArgs> privateWebMessageReceived; // 0x38
	
		// Properties
		internal ICoreWebView2ServiceWorker _nativeICoreWebView2ServiceWorker { get; set; } // 0x00000001813CFB90-0x00000001813CFCA0 0x00000001802FAF70-0x00000001802FAF80
		public string ScriptUri { get; } // 0x00000001813CFA30-0x00000001813CFB90 
	
		// Events
		public event EventHandler<object> Destroying {
			add; // 0x00000001813CF510-0x00000001813CF7A0
			remove; // 0x00000001813CFCA0-0x00000001813CFEA0
		}
		public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived {
			add; // 0x00000001813CF7A0-0x00000001813CFA30
			remove; // 0x00000001813CFEA0-0x00000001813D00A0
		}
	
		// Constructors
		internal CoreWebView2ServiceWorker(object rawCoreWebView2ServiceWorker); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnDestroying(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnWebMessageReceived(CoreWebView2WebMessageReceivedEventArgs args); // 0x000000018136EEF0-0x000000018136EF10
		public void PostWebMessageAsJson(string webMessageAsJson); // 0x00000001813CF230-0x00000001813CF3A0
		public void PostWebMessageAsString(string webMessageAsString); // 0x00000001813CF3A0-0x00000001813CF510
	}
}
