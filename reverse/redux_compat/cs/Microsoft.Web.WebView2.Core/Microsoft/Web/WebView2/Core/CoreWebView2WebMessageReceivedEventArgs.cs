/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2WebMessageReceivedEventArgs : EventArgs // TypeDefIndex: 10620
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebMessageReceivedEventArgs _nativeICoreWebView2WebMessageReceivedEventArgsValue; // 0x18
		internal ICoreWebView2WebMessageReceivedEventArgs2 _nativeICoreWebView2WebMessageReceivedEventArgs2Value; // 0x20
		private long _memoryUsage; // 0x28
	
		// Properties
		internal ICoreWebView2WebMessageReceivedEventArgs _nativeICoreWebView2WebMessageReceivedEventArgs { get; set; } // 0x00000001813D6630-0x00000001813D6740 0x00000001802FAF70-0x00000001802FAF80
		public string Source { get; } // 0x00000001813D6260-0x00000001813D63C0 
		public string WebMessageAsJson { get; } // 0x00000001813D63C0-0x00000001813D6520 
		internal ICoreWebView2WebMessageReceivedEventArgs2 _nativeICoreWebView2WebMessageReceivedEventArgs2 { get; set; } // 0x00000001813D6520-0x00000001813D6630 0x000000018033E830-0x000000018033E840
		public IReadOnlyList<object> AdditionalObjects { get; } // 0x00000001813D60F0-0x00000001813D6260 
	
		// Constructors
		internal CoreWebView2WebMessageReceivedEventArgs(object rawCoreWebView2WebMessageReceivedEventArgs); // 0x00000001813D6000-0x00000001813D60F0
	
		// Methods
		private void Initialize(); // 0x00000001813D5E00-0x00000001813D5EA0
		public string TryGetWebMessageAsString(); // 0x00000001813D5EA0-0x00000001813D6000
		~CoreWebView2WebMessageReceivedEventArgs(); // 0x00000001813D5D50-0x00000001813D5E00
	}
}
