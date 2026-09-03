/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2ContextMenuRequestedEventArgs : EventArgs // TypeDefIndex: 10525
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ContextMenuRequestedEventArgs _nativeICoreWebView2ContextMenuRequestedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2ContextMenuRequestedEventArgs _nativeICoreWebView2ContextMenuRequestedEventArgs { get; set; } // 0x0000000181389020-0x0000000181389130 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2ContextMenuTarget ContextMenuTarget { get; } // 0x0000000181388850-0x0000000181388A20 
		public bool Handled { get; set; } // 0x0000000181388A20-0x0000000181388B80 0x0000000181389130-0x00000001813892A0
		public Point Location { get; } // 0x0000000181388B80-0x0000000181388D50 
		public IList<CoreWebView2ContextMenuItem> MenuItems { get; } // 0x0000000181388D50-0x0000000181388EC0 
		public int SelectedCommandId { get; set; } // 0x0000000181388EC0-0x0000000181389020 0x00000001813892A0-0x0000000181389410
	
		// Constructors
		internal CoreWebView2ContextMenuRequestedEventArgs(object rawCoreWebView2ContextMenuRequestedEventArgs); // 0x00000001813887E0-0x0000000181388850
	
		// Methods
		public CoreWebView2Deferral GetDeferral(); // 0x0000000181388650-0x00000001813887E0
	}
}
