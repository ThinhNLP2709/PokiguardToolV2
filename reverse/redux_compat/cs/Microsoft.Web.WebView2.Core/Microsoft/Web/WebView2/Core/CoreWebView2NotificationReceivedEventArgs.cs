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
	public class CoreWebView2NotificationReceivedEventArgs : EventArgs // TypeDefIndex: 10574
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2NotificationReceivedEventArgs _nativeICoreWebView2NotificationReceivedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2NotificationReceivedEventArgs _nativeICoreWebView2NotificationReceivedEventArgs { get; set; } // 0x00000001813B2A30-0x00000001813B2B40 0x00000001802FAF70-0x00000001802FAF80
		public bool Handled { get; set; } // 0x00000001813B25A0-0x00000001813B2700 0x00000001813B2B40-0x00000001813B2CB0
		public CoreWebView2Notification Notification { get; } // 0x00000001813B2700-0x00000001813B28D0 
		public string SenderOrigin { get; } // 0x00000001813B28D0-0x00000001813B2A30 
	
		// Constructors
		internal CoreWebView2NotificationReceivedEventArgs(object rawCoreWebView2NotificationReceivedEventArgs); // 0x00000001813B2530-0x00000001813B25A0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813B23A0-0x00000001813B2530
	}
}
