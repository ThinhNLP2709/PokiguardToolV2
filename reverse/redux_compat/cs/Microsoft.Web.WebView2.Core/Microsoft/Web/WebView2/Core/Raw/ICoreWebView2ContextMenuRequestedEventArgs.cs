/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("A1D309EE-C03F-11EB-8529-0242AC130003")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ContextMenuRequestedEventArgs // TypeDefIndex: 10909
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2ContextMenuItemCollection MenuItems { get; } // 0x00000001813E3A70-0x00000001813E3B00 
		[DispId(1610678273)]
		ICoreWebView2ContextMenuTarget ContextMenuTarget { get; } // 0x00000001813E3940-0x00000001813E39D0 
		[DispId(1610678274)]
		tagPOINT Location { get; } // 0x00000001813E3A20-0x00000001813E3A70 
		[DispId(1610678275)]
		int SelectedCommandId { get; set; } // 0x00000001813E3B00-0x00000001813E3B50 0x00000001813E3B90-0x00000001813E3BD0
		[DispId(1610678277)]
		int Handled { get; set; } // 0x00000001813E39D0-0x00000001813E3A20 0x00000001813E3B50-0x00000001813E3B90
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813E38B0-0x00000001813E3940
	}
}
