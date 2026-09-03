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
	public class CoreWebView2SharedWorker // TypeDefIndex: 10615
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2SharedWorker _nativeICoreWebView2SharedWorkerValue; // 0x18
		private EventRegistrationToken _DestroyingToken; // 0x20
		private EventHandler<object> privateDestroying; // 0x28
	
		// Properties
		internal ICoreWebView2SharedWorker _nativeICoreWebView2SharedWorker { get; set; } // 0x00000001813D5620-0x00000001813D5730 0x00000001802FAF70-0x00000001802FAF80
		public string Origin { get; } // 0x00000001813D5200-0x00000001813D5360 
		public string ScriptUri { get; } // 0x00000001813D5360-0x00000001813D54C0 
		public string TopLevelOrigin { get; } // 0x00000001813D54C0-0x00000001813D5620 
	
		// Events
		public event EventHandler<object> Destroying {
			add; // 0x00000001813D4F70-0x00000001813D5200
			remove; // 0x00000001813D5730-0x00000001813D5930
		}
	
		// Constructors
		internal CoreWebView2SharedWorker(object rawCoreWebView2SharedWorker); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnDestroying(object args); // 0x000000018136EED0-0x000000018136EEF0
	}
}
