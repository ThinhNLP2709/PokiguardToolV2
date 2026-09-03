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
	public class CoreWebView2CompositionController : CoreWebView2Controller // TypeDefIndex: 10522
	{
		// Fields
		internal ICoreWebView2CompositionController _nativeICoreWebView2CompositionControllerValue; // 0xB8
		private EventRegistrationToken _CursorChangedToken; // 0xC0
		private EventHandler<object> privateCursorChanged; // 0xC8
		internal ICoreWebView2CompositionController2 _nativeICoreWebView2CompositionController2Value; // 0xD0
		internal ICoreWebView2CompositionController3 _nativeICoreWebView2CompositionController3Value; // 0xD8
		internal ICoreWebView2CompositionController4 _nativeICoreWebView2CompositionController4Value; // 0xE0
		private EventRegistrationToken _NonClientRegionChangedToken; // 0xE8
		private EventHandler<CoreWebView2NonClientRegionChangedEventArgs> privateNonClientRegionChanged; // 0xF0
	
		// Properties
		internal ICoreWebView2CompositionController _nativeICoreWebView2CompositionController { get; set; } // 0x0000000181386640-0x0000000181386760 0x00000001806CCDE0-0x00000001806CCE00
		public IntPtr Cursor { get; } // 0x0000000181385E60-0x0000000181385FC0 
		public object RootVisualTarget { get; set; } // 0x0000000181385FC0-0x0000000181386120 0x0000000181386BA0-0x0000000181386D10
		public uint SystemCursorId { get; } // 0x0000000181386120-0x00000001813862E0 
		internal ICoreWebView2CompositionController2 _nativeICoreWebView2CompositionController2 { get; set; } // 0x00000001813862E0-0x0000000181386400 0x00000001806CCD80-0x00000001806CCDA0
		internal ICoreWebView2CompositionController3 _nativeICoreWebView2CompositionController3 { get; set; } // 0x0000000181386400-0x0000000181386520 0x00000001806CCE00-0x00000001806CCE20
		internal ICoreWebView2CompositionController4 _nativeICoreWebView2CompositionController4 { get; set; } // 0x0000000181386520-0x0000000181386640 0x00000001806CCDC0-0x00000001806CCDE0
	
		// Events
		public event EventHandler<object> CursorChanged {
			add; // 0x0000000181385920-0x0000000181385BC0
			remove; // 0x0000000181386760-0x0000000181386980
		}
		public event EventHandler<CoreWebView2NonClientRegionChangedEventArgs> NonClientRegionChanged {
			add; // 0x0000000181385BC0-0x0000000181385E60
			remove; // 0x0000000181386980-0x0000000181386BA0
		}
	
		// Constructors
		internal CoreWebView2CompositionController(object rawCoreWebView2CompositionController); // 0x00000001813858E0-0x0000000181385920
	
		// Methods
		internal void OnCursorChanged(object args); // 0x000000018136F260-0x000000018136F290
		public void SendMouseInput(CoreWebView2MouseEventKind eventKind, CoreWebView2MouseEventVirtualKeys virtualKeys, uint mouseData, Point point); // 0x00000001813854C0-0x00000001813856E0
		public void SendPointerInput(CoreWebView2PointerEventKind eventKind, CoreWebView2PointerInfo pointerInfo); // 0x00000001813856E0-0x00000001813858E0
		public void DragLeave(); // 0x0000000181384F80-0x00000001813850F0
		internal void OnNonClientRegionChanged(CoreWebView2NonClientRegionChangedEventArgs args); // 0x00000001813852C0-0x00000001813852F0
		public CoreWebView2NonClientRegionKind GetNonClientRegionAtPoint(Point point); // 0x00000001813850F0-0x00000001813852C0
		public IReadOnlyList<Rectangle> QueryNonClientRegion(CoreWebView2NonClientRegionKind Kind); // 0x00000001813852F0-0x00000001813854C0
	}
}
