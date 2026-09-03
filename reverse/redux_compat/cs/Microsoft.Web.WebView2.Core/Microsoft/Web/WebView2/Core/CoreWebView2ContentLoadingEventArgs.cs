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
	public class CoreWebView2ContentLoadingEventArgs : EventArgs // TypeDefIndex: 10523
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ContentLoadingEventArgs _nativeICoreWebView2ContentLoadingEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ContentLoadingEventArgs _nativeICoreWebView2ContentLoadingEventArgs { get; set; } // 0x0000000181387040-0x0000000181387150 0x00000001802FAF70-0x00000001802FAF80
		public bool IsErrorPage { get; } // 0x0000000181386D80-0x0000000181386EE0 
		public ulong NavigationId { get; } // 0x0000000181386EE0-0x0000000181387040 
	
		// Constructors
		internal CoreWebView2ContentLoadingEventArgs(object rawCoreWebView2ContentLoadingEventArgs); // 0x0000000181386D10-0x0000000181386D80
	}
}
