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
	public class CoreWebView2NavigationCompletedEventArgs : EventArgs // TypeDefIndex: 10569
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2NavigationCompletedEventArgs _nativeICoreWebView2NavigationCompletedEventArgsValue; // 0x18
		internal ICoreWebView2NavigationCompletedEventArgs2 _nativeICoreWebView2NavigationCompletedEventArgs2Value; // 0x20
	
		// Properties
		internal ICoreWebView2NavigationCompletedEventArgs _nativeICoreWebView2NavigationCompletedEventArgs { get; set; } // 0x00000001813AFA50-0x00000001813AFB60 0x00000001802FAF70-0x00000001802FAF80
		public bool IsSuccess { get; } // 0x00000001813AF520-0x00000001813AF680 
		public ulong NavigationId { get; } // 0x00000001813AF680-0x00000001813AF7E0 
		public CoreWebView2WebErrorStatus WebErrorStatus { get; } // 0x00000001813AF7E0-0x00000001813AF940 
		internal ICoreWebView2NavigationCompletedEventArgs2 _nativeICoreWebView2NavigationCompletedEventArgs2 { get; set; } // 0x00000001813AF940-0x00000001813AFA50 0x000000018033E830-0x000000018033E840
		public int HttpStatusCode { get; } // 0x00000001813AF3C0-0x00000001813AF520 
	
		// Constructors
		internal CoreWebView2NavigationCompletedEventArgs(object rawCoreWebView2NavigationCompletedEventArgs); // 0x00000001813AF350-0x00000001813AF3C0
	}
}
