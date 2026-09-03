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
	public class CoreWebView2FrameCreatedEventArgs : EventArgs // TypeDefIndex: 10562
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2FrameCreatedEventArgs _nativeICoreWebView2FrameCreatedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2FrameCreatedEventArgs _nativeICoreWebView2FrameCreatedEventArgs { get; set; } // 0x00000001813A75A0-0x00000001813A76B0 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2Frame Frame { get; } // 0x00000001813A73D0-0x00000001813A75A0 
	
		// Constructors
		internal CoreWebView2FrameCreatedEventArgs(object rawCoreWebView2FrameCreatedEventArgs); // 0x00000001813A7360-0x00000001813A73D0
	}
}
