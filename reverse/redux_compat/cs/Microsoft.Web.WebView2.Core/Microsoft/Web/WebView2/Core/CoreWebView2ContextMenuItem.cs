/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2ContextMenuItem // TypeDefIndex: 10524
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ContextMenuItem _nativeICoreWebView2ContextMenuItemValue; // 0x18
		private EventRegistrationToken _CustomItemSelectedToken; // 0x20
		private EventHandler<object> privateCustomItemSelected; // 0x28
	
		// Properties
		internal ICoreWebView2ContextMenuItem _nativeICoreWebView2ContextMenuItem { get; set; } // 0x0000000181388060-0x0000000181388170 0x00000001802FAF70-0x00000001802FAF80
		public IList<CoreWebView2ContextMenuItem> Children { get; } // 0x00000001813873E0-0x0000000181387550 
		public int CommandId { get; } // 0x0000000181387550-0x00000001813876B0 
		public Stream Icon { get; } // 0x00000001813876B0-0x0000000181387820 
		public bool IsChecked { get; set; } // 0x0000000181387820-0x0000000181387980 0x0000000181388370-0x00000001813884E0
		public bool IsEnabled { get; set; } // 0x0000000181387980-0x0000000181387AE0 0x00000001813884E0-0x0000000181388650
		public CoreWebView2ContextMenuItemKind Kind { get; } // 0x0000000181387AE0-0x0000000181387C40 
		public string Label { get; } // 0x0000000181387C40-0x0000000181387DA0 
		public string Name { get; } // 0x0000000181387DA0-0x0000000181387F00 
		public string ShortcutKeyDescription { get; } // 0x0000000181387F00-0x0000000181388060 
	
		// Events
		public event EventHandler<object> CustomItemSelected {
			add; // 0x0000000181387150-0x00000001813873E0
			remove; // 0x0000000181388170-0x0000000181388370
		}
	
		// Constructors
		internal CoreWebView2ContextMenuItem(object rawCoreWebView2ContextMenuItem); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnCustomItemSelected(object args); // 0x000000018136EED0-0x000000018136EEF0
	}
}
