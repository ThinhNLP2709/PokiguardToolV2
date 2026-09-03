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
	public class CoreWebView2NavigationStartingEventArgs : EventArgs // TypeDefIndex: 10570
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2NavigationStartingEventArgs _nativeICoreWebView2NavigationStartingEventArgsValue; // 0x18
		internal ICoreWebView2NavigationStartingEventArgs2 _nativeICoreWebView2NavigationStartingEventArgs2Value; // 0x20
		internal ICoreWebView2NavigationStartingEventArgs3 _nativeICoreWebView2NavigationStartingEventArgs3Value; // 0x28
	
		// Properties
		internal ICoreWebView2NavigationStartingEventArgs _nativeICoreWebView2NavigationStartingEventArgs { get; set; } // 0x00000001813B0960-0x00000001813B0A70 0x00000001802FAF70-0x00000001802FAF80
		public bool Cancel { get; set; } // 0x00000001813AFD30-0x00000001813AFE90 0x00000001813B0BE0-0x00000001813B0D50
		public bool IsRedirected { get; } // 0x00000001813AFE90-0x00000001813AFFF0 
		public bool IsUserInitiated { get; } // 0x00000001813AFFF0-0x00000001813B0150 
		public ulong NavigationId { get; } // 0x00000001813B0150-0x00000001813B02B0 
		public CoreWebView2HttpRequestHeaders RequestHeaders { get; } // 0x00000001813B0410-0x00000001813B05E0 
		public string Uri { get; } // 0x00000001813B05E0-0x00000001813B0740 
		internal ICoreWebView2NavigationStartingEventArgs2 _nativeICoreWebView2NavigationStartingEventArgs2 { get; set; } // 0x00000001813B0740-0x00000001813B0850 0x000000018033E830-0x000000018033E840
		public string AdditionalAllowedFrameAncestors { get; set; } // 0x00000001813AFBD0-0x00000001813AFD30 0x00000001813B0A70-0x00000001813B0BE0
		internal ICoreWebView2NavigationStartingEventArgs3 _nativeICoreWebView2NavigationStartingEventArgs3 { get; set; } // 0x00000001813B0850-0x00000001813B0960 0x000000018033E840-0x000000018033E850
		public CoreWebView2NavigationKind NavigationKind { get; } // 0x00000001813B02B0-0x00000001813B0410 
	
		// Constructors
		internal CoreWebView2NavigationStartingEventArgs(object rawCoreWebView2NavigationStartingEventArgs); // 0x00000001813AFB60-0x00000001813AFBD0
	}
}
