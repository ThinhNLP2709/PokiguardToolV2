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
	public class CoreWebView2MoveFocusRequestedEventArgs : EventArgs // TypeDefIndex: 10568
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2MoveFocusRequestedEventArgs _nativeICoreWebView2MoveFocusRequestedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2MoveFocusRequestedEventArgs _nativeICoreWebView2MoveFocusRequestedEventArgs { get; set; } // 0x00000001813AF0D0-0x00000001813AF1E0 0x00000001802FAF70-0x00000001802FAF80
		public bool Handled { get; set; } // 0x00000001813AEE10-0x00000001813AEF70 0x00000001813AF1E0-0x00000001813AF350
		public CoreWebView2MoveFocusReason Reason { get; } // 0x00000001813AEF70-0x00000001813AF0D0 
	
		// Constructors
		internal CoreWebView2MoveFocusRequestedEventArgs(object rawCoreWebView2MoveFocusRequestedEventArgs); // 0x00000001813AEDA0-0x00000001813AEE10
	}
}
