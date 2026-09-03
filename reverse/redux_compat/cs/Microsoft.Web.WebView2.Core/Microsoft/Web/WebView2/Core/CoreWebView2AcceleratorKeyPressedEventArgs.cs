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
	public class CoreWebView2AcceleratorKeyPressedEventArgs : EventArgs // TypeDefIndex: 10512
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2AcceleratorKeyPressedEventArgs _nativeICoreWebView2AcceleratorKeyPressedEventArgsValue; // 0x18
		internal ICoreWebView2AcceleratorKeyPressedEventArgs2 _nativeICoreWebView2AcceleratorKeyPressedEventArgs2Value; // 0x20
	
		// Properties
		internal ICoreWebView2AcceleratorKeyPressedEventArgs _nativeICoreWebView2AcceleratorKeyPressedEventArgs { get; set; } // 0x0000000181367F50-0x0000000181368060 0x00000001802FAF70-0x00000001802FAF80
		public bool Handled { get; set; } // 0x00000001813674F0-0x0000000181367650 0x0000000181368060-0x00000001813681D0
		public CoreWebView2KeyEventKind KeyEventKind { get; } // 0x00000001813677B0-0x0000000181367910 
		public int KeyEventLParam { get; } // 0x0000000181367910-0x0000000181367A70 
		public CoreWebView2PhysicalKeyStatus PhysicalKeyStatus { get; } // 0x0000000181367A70-0x0000000181367CE0 
		public uint VirtualKey { get; } // 0x0000000181367CE0-0x0000000181367E40 
		internal ICoreWebView2AcceleratorKeyPressedEventArgs2 _nativeICoreWebView2AcceleratorKeyPressedEventArgs2 { get; set; } // 0x0000000181367E40-0x0000000181367F50 0x000000018033E830-0x000000018033E840
		public bool IsBrowserAcceleratorKeyEnabled { get; set; } // 0x0000000181367650-0x00000001813677B0 0x00000001813681D0-0x0000000181368340
	
		// Constructors
		internal CoreWebView2AcceleratorKeyPressedEventArgs(object rawCoreWebView2AcceleratorKeyPressedEventArgs); // 0x0000000181367480-0x00000001813674F0
	}
}
