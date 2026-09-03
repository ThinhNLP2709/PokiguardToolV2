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
	[Guid("B8611D99-EED6-4F3F-902C-A198502AD472")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ContextMenuTarget // TypeDefIndex: 10911
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND Kind { get; } // 0x00000001813E3F20-0x00000001813E3F70 
		[DispId(1610678273)]
		int IsEditable { get; } // 0x00000001813E3E80-0x00000001813E3ED0 
		[DispId(1610678274)]
		int IsRequestedForMainFrame { get; } // 0x00000001813E3ED0-0x00000001813E3F20 
		[DispId(1610678275)]
		string PageUri { get; } // 0x00000001813E4050-0x00000001813E40C0 
		[DispId(1610678276)]
		string FrameUri { get; } // 0x00000001813E3CD0-0x00000001813E3D40 
		[DispId(1610678277)]
		int HasLinkUri { get; } // 0x00000001813E3D90-0x00000001813E3DE0 
		[DispId(1610678278)]
		string LinkUri { get; } // 0x00000001813E3FE0-0x00000001813E4050 
		[DispId(1610678279)]
		int HasLinkText { get; } // 0x00000001813E3D40-0x00000001813E3D90 
		[DispId(1610678280)]
		string LinkText { get; } // 0x00000001813E3F70-0x00000001813E3FE0 
		[DispId(1610678281)]
		int HasSourceUri { get; } // 0x00000001813E3E30-0x00000001813E3E80 
		[DispId(1610678282)]
		string SourceUri { get; } // 0x00000001813E4130-0x00000001813E41A0 
		[DispId(1610678283)]
		int HasSelection { get; } // 0x00000001813E3DE0-0x00000001813E3E30 
		[DispId(1610678284)]
		string SelectionText { get; } // 0x00000001813E40C0-0x00000001813E4130 
	}
}
