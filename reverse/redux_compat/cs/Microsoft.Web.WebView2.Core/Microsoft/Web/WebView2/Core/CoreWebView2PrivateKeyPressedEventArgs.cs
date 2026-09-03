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
	internal class CoreWebView2PrivateKeyPressedEventArgs : EventArgs // TypeDefIndex: 10585
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2PrivateKeyPressedEventArgs _nativeICoreWebView2PrivateKeyPressedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2PrivateKeyPressedEventArgs _nativeICoreWebView2PrivateKeyPressedEventArgs { get; set; } // 0x00000001813C0B20-0x00000001813C0C30 0x00000001802FAF70-0x00000001802FAF80
		internal bool Handled { get; set; } // 0x00000001813C0330-0x00000001813C0490 0x00000001813C0C30-0x00000001813C0DA0
		internal CoreWebView2KeyEventKind KeyEventKind { get; } // 0x00000001813C0490-0x00000001813C05F0 
		internal int KeyEventLParam { get; } // 0x00000001813C05F0-0x00000001813C0750 
		internal CoreWebView2PhysicalKeyStatus PhysicalKeyStatus { get; } // 0x00000001813C0750-0x00000001813C09C0 
		internal uint VirtualKey { get; } // 0x00000001813C09C0-0x00000001813C0B20 
	
		// Constructors
		internal CoreWebView2PrivateKeyPressedEventArgs(object rawCoreWebView2PrivateKeyPressedEventArgs); // 0x00000001813C02C0-0x00000001813C0330
	}
}
