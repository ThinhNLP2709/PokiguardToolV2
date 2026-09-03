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
	public class CoreWebView2ScreenCaptureStartingEventArgs : EventArgs // TypeDefIndex: 10601
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ScreenCaptureStartingEventArgs _nativeICoreWebView2ScreenCaptureStartingEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ScreenCaptureStartingEventArgs _nativeICoreWebView2ScreenCaptureStartingEventArgs { get; set; } // 0x00000001813CB030-0x00000001813CB140 0x00000001802FAF70-0x00000001802FAF80
		public bool Cancel { get; set; } // 0x00000001813CABB0-0x00000001813CAD10 0x00000001813CB140-0x00000001813CB2B0
		public bool Handled { get; set; } // 0x00000001813CAD10-0x00000001813CAE70 0x00000001813CB2B0-0x00000001813CB420
		public CoreWebView2FrameInfo OriginalSourceFrameInfo { get; } // 0x00000001813CAE70-0x00000001813CB030 
	
		// Constructors
		internal CoreWebView2ScreenCaptureStartingEventArgs(object rawCoreWebView2ScreenCaptureStartingEventArgs); // 0x00000001813CAB40-0x00000001813CABB0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813CA9B0-0x00000001813CAB40
	}
}
