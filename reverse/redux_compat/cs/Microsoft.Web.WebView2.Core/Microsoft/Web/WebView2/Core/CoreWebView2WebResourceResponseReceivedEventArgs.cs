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
	public class CoreWebView2WebResourceResponseReceivedEventArgs : EventArgs // TypeDefIndex: 10624
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebResourceResponseReceivedEventArgs _nativeICoreWebView2WebResourceResponseReceivedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2WebResourceResponseReceivedEventArgs _nativeICoreWebView2WebResourceResponseReceivedEventArgs { get; set; } // 0x00000001813D8430-0x00000001813D8540 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2WebResourceRequest Request { get; } // 0x00000001813D8090-0x00000001813D8260 
		public CoreWebView2WebResourceResponseView Response { get; } // 0x00000001813D8260-0x00000001813D8430 
	
		// Constructors
		internal CoreWebView2WebResourceResponseReceivedEventArgs(object rawCoreWebView2WebResourceResponseReceivedEventArgs); // 0x00000001813D8020-0x00000001813D8090
	}
}
