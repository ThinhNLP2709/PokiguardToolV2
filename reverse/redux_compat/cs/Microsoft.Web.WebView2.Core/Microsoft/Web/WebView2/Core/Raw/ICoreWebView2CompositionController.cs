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
	[Guid("3DF9B733-B9AE-4A15-86B4-EB9EE9826469")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2CompositionController // TypeDefIndex: 10900
	{
		// Properties
		[DispId(1610678272)]
		object RootVisualTarget { get; set; } // 0x00000001813E2D80-0x00000001813E2E10 0x00000001813E2EA0-0x00000001813E2F30
		[DispId(1610678276)]
		IntPtr Cursor { get; } // 0x00000001813E2D30-0x00000001813E2D80 
		[DispId(1610678277)]
		uint SystemCursorId { get; } // 0x00000001813E2E10-0x00000001813E2E60 
	
		// Methods
		void SendMouseInput(in COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, in COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, in uint mouseData, in tagPOINT point); // 0x00000001813E2B90-0x00000001813E2BF0
		void SendPointerInput(in COREWEBVIEW2_POINTER_EVENT_KIND eventKind, in ICoreWebView2PointerInfo pointerInfo); // 0x00000001813E2BF0-0x00000001813E2C90
		void add_CursorChanged(in ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E2C90-0x00000001813E2D30
		void remove_CursorChanged(in EventRegistrationToken token); // 0x00000001813E2E60-0x00000001813E2EA0
	}
}
