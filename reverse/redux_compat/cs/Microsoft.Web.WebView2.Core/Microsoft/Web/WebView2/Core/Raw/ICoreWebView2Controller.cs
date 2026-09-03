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
	[Guid("4D00C0D1-9434-4EB6-8078-8697A560334F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Controller // TypeDefIndex: 10912
	{
		// Properties
		[DispId(1610678272)]
		int IsVisible { get; set; } // 0x00000001813E4DB0-0x00000001813E4E00 0x00000001813E5030-0x00000001813E5070
		[DispId(1610678274)]
		tagRECT Bounds { get; set; } // 0x00000001813E4CD0-0x00000001813E4D20 0x00000001813E4FE0-0x00000001813E5030
		[DispId(1610678276)]
		double ZoomFactor { get; set; } // 0x00000001813E4E50-0x00000001813E4EA0 0x00000001813E50B0-0x00000001813E50F0
		[DispId(1610678290)]
		IntPtr ParentWindow { get; set; } // 0x00000001813E4E00-0x00000001813E4E50 0x00000001813E5070-0x00000001813E50B0
		[DispId(1610678294)]
		ICoreWebView2 CoreWebView2 { get; } // 0x00000001813E4D20-0x00000001813E4DB0 
	
		// Methods
		void add_ZoomFactorChanged(in ICoreWebView2ZoomFactorChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E4C30-0x00000001813E4CD0
		void remove_ZoomFactorChanged(in EventRegistrationToken token); // 0x00000001813E4FA0-0x00000001813E4FE0
		void SetBoundsAndZoomFactor(in tagRECT Bounds, in double ZoomFactor); // 0x00000001813E4950-0x00000001813E49B0
		void MoveFocus(in COREWEBVIEW2_MOVE_FOCUS_REASON reason); // 0x00000001813E48D0-0x00000001813E4910
		void add_MoveFocusRequested(in ICoreWebView2MoveFocusRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E4B90-0x00000001813E4C30
		void remove_MoveFocusRequested(in EventRegistrationToken token); // 0x00000001813E4F60-0x00000001813E4FA0
		void add_GotFocus(in ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E4A50-0x00000001813E4AF0
		void remove_GotFocus(in EventRegistrationToken token); // 0x00000001813E4EE0-0x00000001813E4F20
		void add_LostFocus(in ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E4AF0-0x00000001813E4B90
		void remove_LostFocus(in EventRegistrationToken token); // 0x00000001813E4F20-0x00000001813E4F60
		void add_AcceleratorKeyPressed(in ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E49B0-0x00000001813E4A50
		void remove_AcceleratorKeyPressed(in EventRegistrationToken token); // 0x00000001813E4EA0-0x00000001813E4EE0
		void NotifyParentWindowPositionChanged(); // 0x00000001813E4910-0x00000001813E4950
		void Close(); // 0x00000001813E4890-0x00000001813E48D0
	}
}
