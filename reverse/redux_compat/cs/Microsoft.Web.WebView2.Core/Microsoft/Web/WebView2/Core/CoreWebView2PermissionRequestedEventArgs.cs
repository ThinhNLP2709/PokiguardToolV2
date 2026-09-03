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
	public class CoreWebView2PermissionRequestedEventArgs : EventArgs // TypeDefIndex: 10576
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2PermissionRequestedEventArgs _nativeICoreWebView2PermissionRequestedEventArgsValue; // 0x18
		internal ICoreWebView2PermissionRequestedEventArgs2 _nativeICoreWebView2PermissionRequestedEventArgs2Value; // 0x20
		internal ICoreWebView2PermissionRequestedEventArgs3 _nativeICoreWebView2PermissionRequestedEventArgs3Value; // 0x28
	
		// Properties
		internal ICoreWebView2PermissionRequestedEventArgs _nativeICoreWebView2PermissionRequestedEventArgs { get; set; } // 0x00000001813B5550-0x00000001813B5660 0x00000001802FAF70-0x00000001802FAF80
		public bool IsUserInitiated { get; } // 0x00000001813B4C50-0x00000001813B4DB0 
		public CoreWebView2PermissionKind PermissionKind { get; } // 0x00000001813B4DB0-0x00000001813B4F10 
		public CoreWebView2PermissionState State { get; set; } // 0x00000001813B5070-0x00000001813B51D0 0x00000001813B5940-0x00000001813B5AB0
		public string Uri { get; } // 0x00000001813B51D0-0x00000001813B5330 
		internal ICoreWebView2PermissionRequestedEventArgs2 _nativeICoreWebView2PermissionRequestedEventArgs2 { get; set; } // 0x00000001813B5330-0x00000001813B5440 0x000000018033E830-0x000000018033E840
		public bool Handled { get; set; } // 0x00000001813B4AF0-0x00000001813B4C50 0x00000001813B5660-0x00000001813B57D0
		internal ICoreWebView2PermissionRequestedEventArgs3 _nativeICoreWebView2PermissionRequestedEventArgs3 { get; set; } // 0x00000001813B5440-0x00000001813B5550 0x000000018033E840-0x000000018033E850
		public bool SavesInProfile { get; set; } // 0x00000001813B4F10-0x00000001813B5070 0x00000001813B57D0-0x00000001813B5940
	
		// Constructors
		internal CoreWebView2PermissionRequestedEventArgs(object rawCoreWebView2PermissionRequestedEventArgs); // 0x00000001813B4A80-0x00000001813B4AF0
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813B48F0-0x00000001813B4A80
	}
}
