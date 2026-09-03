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
	public class CoreWebView2DedicatedWorker // TypeDefIndex: 10535
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DedicatedWorker _nativeICoreWebView2DedicatedWorkerValue; // 0x18
		private EventRegistrationToken _DedicatedWorkerCreatedToken; // 0x20
		private EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> privateDedicatedWorkerCreated; // 0x28
		private EventRegistrationToken _DestroyingToken; // 0x30
		private EventHandler<object> privateDestroying; // 0x38
		private EventRegistrationToken _WebMessageReceivedToken; // 0x40
		private EventHandler<CoreWebView2WebMessageReceivedEventArgs> privateWebMessageReceived; // 0x48
	
		// Properties
		internal ICoreWebView2DedicatedWorker _nativeICoreWebView2DedicatedWorker { get; set; } // 0x0000000181394880-0x0000000181394990 0x00000001802FAF70-0x00000001802FAF80
		public string ScriptUri { get; } // 0x0000000181394720-0x0000000181394880 
	
		// Events
		public event EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> DedicatedWorkerCreated {
			add; // 0x0000000181393F70-0x0000000181394200
			remove; // 0x0000000181394990-0x0000000181394B90
		}
		public event EventHandler<object> Destroying {
			add; // 0x0000000181394200-0x0000000181394490
			remove; // 0x0000000181394B90-0x0000000181394D90
		}
		public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived {
			add; // 0x0000000181394490-0x0000000181394720
			remove; // 0x0000000181394D90-0x0000000181394F90
		}
	
		// Constructors
		internal CoreWebView2DedicatedWorker(object rawCoreWebView2DedicatedWorker); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnDedicatedWorkerCreated(CoreWebView2DedicatedWorkerCreatedEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnDestroying(object args); // 0x000000018136EEF0-0x000000018136EF10
		internal void OnWebMessageReceived(CoreWebView2WebMessageReceivedEventArgs args); // 0x000000018136EFA0-0x000000018136EFC0
		public void PostWebMessageAsJson(string webMessageAsJson); // 0x0000000181393C90-0x0000000181393E00
		public void PostWebMessageAsString(string webMessageAsString); // 0x0000000181393E00-0x0000000181393F70
	}
}
