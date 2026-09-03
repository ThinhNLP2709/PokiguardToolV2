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
	public class CoreWebView2DownloadStartingEventArgs : EventArgs // TypeDefIndex: 10541
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DownloadStartingEventArgs _nativeICoreWebView2DownloadStartingEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2DownloadStartingEventArgs _nativeICoreWebView2DownloadStartingEventArgs { get; set; } // 0x00000001813985A0-0x00000001813986B0 0x00000001802FAF70-0x00000001802FAF80
		public bool Cancel { get; set; } // 0x0000000181397FB0-0x0000000181398110 0x00000001813986B0-0x0000000181398820
		public CoreWebView2DownloadOperation DownloadOperation { get; } // 0x0000000181398110-0x00000001813982E0 
		public bool Handled { get; set; } // 0x00000001813982E0-0x0000000181398440 0x0000000181398820-0x0000000181398990
		public string ResultFilePath { get; set; } // 0x0000000181398440-0x00000001813985A0 0x0000000181398990-0x0000000181398B00
	
		// Constructors
		internal CoreWebView2DownloadStartingEventArgs(object rawCoreWebView2DownloadStartingEventArgs); // 0x0000000181397F40-0x0000000181397FB0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x0000000181397DB0-0x0000000181397F40
	}
}
