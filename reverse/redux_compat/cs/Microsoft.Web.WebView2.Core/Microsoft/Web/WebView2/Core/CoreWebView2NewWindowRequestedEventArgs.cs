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
	public class CoreWebView2NewWindowRequestedEventArgs : EventArgs // TypeDefIndex: 10571
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2NewWindowRequestedEventArgs _nativeICoreWebView2NewWindowRequestedEventArgsValue; // 0x18
		internal ICoreWebView2NewWindowRequestedEventArgs2 _nativeICoreWebView2NewWindowRequestedEventArgs2Value; // 0x20
		internal ICoreWebView2NewWindowRequestedEventArgs3 _nativeICoreWebView2NewWindowRequestedEventArgs3Value; // 0x28
	
		// Properties
		internal ICoreWebView2NewWindowRequestedEventArgs _nativeICoreWebView2NewWindowRequestedEventArgs { get; set; } // 0x00000001813B1C40-0x00000001813B1D50 0x00000001802FAF70-0x00000001802FAF80
		public bool Handled { get; set; } // 0x00000001813B0F50-0x00000001813B10B0 0x00000001813B1D50-0x00000001813B1EC0
		public bool IsUserInitiated { get; } // 0x00000001813B10B0-0x00000001813B1210 
		public CoreWebView2 NewWindow { get; set; } // 0x00000001813B1370-0x00000001813B1530 0x00000001813B1EC0-0x00000001813B20C0
		public string Uri { get; } // 0x00000001813B1700-0x00000001813B1860 
		public CoreWebView2WindowFeatures WindowFeatures { get; } // 0x00000001813B1860-0x00000001813B1A20 
		internal ICoreWebView2NewWindowRequestedEventArgs2 _nativeICoreWebView2NewWindowRequestedEventArgs2 { get; set; } // 0x00000001813B1A20-0x00000001813B1B30 0x000000018033E830-0x000000018033E840
		public string Name { get; } // 0x00000001813B1210-0x00000001813B1370 
		internal ICoreWebView2NewWindowRequestedEventArgs3 _nativeICoreWebView2NewWindowRequestedEventArgs3 { get; set; } // 0x00000001813B1B30-0x00000001813B1C40 0x000000018033E840-0x000000018033E850
		public CoreWebView2FrameInfo OriginalSourceFrameInfo { get; } // 0x00000001813B1530-0x00000001813B1700 
	
		// Constructors
		internal CoreWebView2NewWindowRequestedEventArgs(object rawCoreWebView2NewWindowRequestedEventArgs); // 0x00000001813B0EE0-0x00000001813B0F50
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x00000001813B0D50-0x00000001813B0EE0
	}
}
