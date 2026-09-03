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
	public class CoreWebView2ProcessFailedEventArgs : EventArgs // TypeDefIndex: 10588
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ProcessFailedEventArgs _nativeICoreWebView2ProcessFailedEventArgsValue; // 0x18
		internal ICoreWebView2ProcessFailedEventArgs2 _nativeICoreWebView2ProcessFailedEventArgs2Value; // 0x20
		internal ICoreWebView2ProcessFailedEventArgs3 _nativeICoreWebView2ProcessFailedEventArgs3Value; // 0x28
	
		// Properties
		internal ICoreWebView2ProcessFailedEventArgs _nativeICoreWebView2ProcessFailedEventArgs { get; set; } // 0x00000001813C23D0-0x00000001813C24E0 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ProcessFailedKind ProcessFailedKind { get; } // 0x00000001813C1EF0-0x00000001813C2050 
		internal ICoreWebView2ProcessFailedEventArgs2 _nativeICoreWebView2ProcessFailedEventArgs2 { get; set; } // 0x00000001813C21B0-0x00000001813C22C0 0x000000018033E830-0x000000018033E840
		public int ExitCode { get; } // 0x00000001813C1960-0x00000001813C1AC0 
		public IReadOnlyList<CoreWebView2FrameInfo> FrameInfosForFailedProcess { get; } // 0x00000001813C1C20-0x00000001813C1D90 
		public string ProcessDescription { get; } // 0x00000001813C1D90-0x00000001813C1EF0 
		public CoreWebView2ProcessFailedReason Reason { get; } // 0x00000001813C2050-0x00000001813C21B0 
		internal ICoreWebView2ProcessFailedEventArgs3 _nativeICoreWebView2ProcessFailedEventArgs3 { get; set; } // 0x00000001813C22C0-0x00000001813C23D0 0x000000018033E840-0x000000018033E850
		public string FailureSourceModulePath { get; } // 0x00000001813C1AC0-0x00000001813C1C20 
	
		// Constructors
		internal CoreWebView2ProcessFailedEventArgs(object rawCoreWebView2ProcessFailedEventArgs); // 0x00000001813C18F0-0x00000001813C1960
	}
}
