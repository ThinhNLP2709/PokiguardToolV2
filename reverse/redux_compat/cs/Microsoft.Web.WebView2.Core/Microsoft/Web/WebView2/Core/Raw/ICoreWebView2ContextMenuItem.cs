/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("7AED49E3-A93F-497A-811C-749C6B6B6C65")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ContextMenuItem // TypeDefIndex: 10907
	{
		// Properties
		[DispId(1610678272)]
		string Name { get; } // 0x00000001813E3780-0x00000001813E37F0 
		[DispId(1610678273)]
		string Label { get; } // 0x00000001813E36A0-0x00000001813E3710 
		[DispId(1610678274)]
		int CommandId { get; } // 0x00000001813E34D0-0x00000001813E3520 
		[DispId(1610678275)]
		string ShortcutKeyDescription { get; } // 0x00000001813E3710-0x00000001813E3780 
		[DispId(1610678276)]
		IStream Icon { get; } // 0x00000001813E3520-0x00000001813E35B0 
		[DispId(1610678277)]
		COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind { get; } // 0x00000001813E3650-0x00000001813E36A0 
		[DispId(1610678278)]
		int IsEnabled { get; set; } // 0x00000001813E3600-0x00000001813E3650 0x00000001813E3870-0x00000001813E38B0
		[DispId(1610678280)]
		int IsChecked { get; set; } // 0x00000001813E35B0-0x00000001813E3600 0x00000001813E3830-0x00000001813E3870
		[DispId(1610678282)]
		ICoreWebView2ContextMenuItemCollection Children { get; } // 0x00000001813E3440-0x00000001813E34D0 
	
		// Methods
		void add_CustomItemSelected(in ICoreWebView2CustomItemSelectedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E33A0-0x00000001813E3440
		void remove_CustomItemSelected(in EventRegistrationToken token); // 0x00000001813E37F0-0x00000001813E3830
	}
}
