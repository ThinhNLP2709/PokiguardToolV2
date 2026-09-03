/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Controller // TypeDefIndex: 10527
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Controller _nativeICoreWebView2ControllerValue; // 0x18
		private EventRegistrationToken _AcceleratorKeyPressedToken; // 0x20
		private EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs> privateAcceleratorKeyPressed; // 0x28
		private EventRegistrationToken _GotFocusToken; // 0x30
		private EventHandler<object> privateGotFocus; // 0x38
		private EventRegistrationToken _LostFocusToken; // 0x40
		private EventHandler<object> privateLostFocus; // 0x48
		private EventRegistrationToken _MoveFocusRequestedToken; // 0x50
		private EventHandler<CoreWebView2MoveFocusRequestedEventArgs> privateMoveFocusRequested; // 0x58
		private EventRegistrationToken _ZoomFactorChangedToken; // 0x60
		private EventHandler<object> privateZoomFactorChanged; // 0x68
		internal ICoreWebView2Controller2 _nativeICoreWebView2Controller2Value; // 0x70
		internal ICoreWebView2Controller3 _nativeICoreWebView2Controller3Value; // 0x78
		private EventRegistrationToken _RasterizationScaleChangedToken; // 0x80
		private EventHandler<object> privateRasterizationScaleChanged; // 0x88
		internal ICoreWebView2Controller4 _nativeICoreWebView2Controller4Value; // 0x90
		internal ICoreWebView2PrivatePartialController _nativeICoreWebView2PrivatePartialControllerValue; // 0x98
		private EventRegistrationToken _KeyPressedToken; // 0xA0
		private EventHandler<CoreWebView2PrivateKeyPressedEventArgs> privateKeyPressed; // 0xA8
		private const string HostObjectHelperName = "{60A417CA-F1AB-4307-801B-F96003F8938B} Host Object Helper"; // Metadata: 0x006A14B6
		private CoreWebView2 _coreWebView2; // 0xB0
	
		// Properties
		internal ICoreWebView2Controller _nativeICoreWebView2Controller { get; set; } // 0x000000018138E7C0-0x000000018138E8D0 0x00000001802FAF70-0x00000001802FAF80
		public Rectangle Bounds { get; set; } // 0x000000018138D750-0x000000018138D980 0x000000018138FB10-0x000000018138FD20
		public bool IsVisible { get; set; } // 0x000000018138DDA0-0x000000018138DF00 0x000000018138FEB0-0x0000000181390020
		public IntPtr ParentWindow { get; set; } // 0x000000018138DF00-0x000000018138E060 0x0000000181390020-0x00000001813901F0
		public double ZoomFactor { get; set; } // 0x000000018138E320-0x000000018138E480 0x00000001813904E0-0x0000000181390660
		internal ICoreWebView2Controller2 _nativeICoreWebView2Controller2 { get; set; } // 0x000000018138E480-0x000000018138E590 0x0000000180434A10-0x0000000180434A20
		public Color DefaultBackgroundColor { get; set; } // 0x000000018138DA80-0x000000018138DC40 0x000000018138FD20-0x000000018138FEB0
		internal ICoreWebView2Controller3 _nativeICoreWebView2Controller3 { get; set; } // 0x000000018138E590-0x000000018138E6A0 0x000000018033EA70-0x000000018033EA80
		public CoreWebView2BoundsMode BoundsMode { get; set; } // 0x000000018138D5F0-0x000000018138D750 0x000000018138F9A0-0x000000018138FB10
		public double RasterizationScale { get; set; } // 0x000000018138E060-0x000000018138E1C0 0x00000001813901F0-0x0000000181390370
		public bool ShouldDetectMonitorScaleChanges { get; set; } // 0x000000018138E1C0-0x000000018138E320 0x0000000181390370-0x00000001813904E0
		internal ICoreWebView2Controller4 _nativeICoreWebView2Controller4 { get; set; } // 0x000000018138E6A0-0x000000018138E7C0 0x0000000180664160-0x0000000180664180
		public bool AllowExternalDrop { get; set; } // 0x000000018138D490-0x000000018138D5F0 0x000000018138F830-0x000000018138F9A0
		internal ICoreWebView2PrivatePartialController _nativeICoreWebView2PrivatePartialController { get; set; } // 0x000000018138E8D0-0x000000018138E9F0 0x00000001806CCE20-0x00000001806CCE40
		internal bool IsBrowserHitTransparent { get; } // 0x000000018138DC40-0x000000018138DDA0 
		public CoreWebView2 CoreWebView2 { get; } // 0x000000018138D980-0x000000018138DA80 
	
		// Events
		public event EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs> AcceleratorKeyPressed {
			add; // 0x000000018138C280-0x000000018138C510
			remove; // 0x000000018138E9F0-0x000000018138EBF0
		}
		public event EventHandler<object> GotFocus {
			add; // 0x000000018138C510-0x000000018138C7A0
			remove; // 0x000000018138EBF0-0x000000018138EDF0
		}
		public event EventHandler<object> LostFocus {
			add; // 0x000000018138CA40-0x000000018138CCD0
			remove; // 0x000000018138F010-0x000000018138F210
		}
		public event EventHandler<CoreWebView2MoveFocusRequestedEventArgs> MoveFocusRequested {
			add; // 0x000000018138CCD0-0x000000018138CF60
			remove; // 0x000000018138F210-0x000000018138F410
		}
		public event EventHandler<object> ZoomFactorChanged {
			add; // 0x000000018138D200-0x000000018138D490
			remove; // 0x000000018138F630-0x000000018138F830
		}
		public event EventHandler<object> RasterizationScaleChanged {
			add; // 0x000000018138CF60-0x000000018138D200
			remove; // 0x000000018138F410-0x000000018138F630
		}
		internal event EventHandler<CoreWebView2PrivateKeyPressedEventArgs> KeyPressed {
			add; // 0x000000018138C7A0-0x000000018138CA40
			remove; // 0x000000018138EDF0-0x000000018138F010
		}
	
		// Constructors
		internal CoreWebView2Controller(object rawCoreWebView2Controller); // 0x00000001813858E0-0x0000000181385920
	
		// Methods
		private void Initialize(); // 0x000000018138BB40-0x000000018138BD50
		internal void OnAcceleratorKeyPressed(CoreWebView2AcceleratorKeyPressedEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnGotFocus(object args); // 0x000000018136EEF0-0x000000018136EF10
		internal void OnLostFocus(object args); // 0x000000018136EFA0-0x000000018136EFC0
		internal void OnMoveFocusRequested(CoreWebView2MoveFocusRequestedEventArgs args); // 0x000000018136F050-0x000000018136F070
		internal void OnZoomFactorChanged(object args); // 0x000000018136F070-0x000000018136F090
		public void SetBoundsAndZoomFactor(Rectangle Bounds, double ZoomFactor); // 0x000000018138C060-0x000000018138C280
		public void MoveFocus(CoreWebView2MoveFocusReason reason); // 0x000000018138BD50-0x000000018138BEF0
		public void NotifyParentWindowPositionChanged(); // 0x000000018138BEF0-0x000000018138C060
		public void Close(); // 0x000000018138B9D0-0x000000018138BB40
		internal void OnRasterizationScaleChanged(object args); // 0x000000018136F170-0x000000018136F1A0
		internal void OnKeyPressed(CoreWebView2PrivateKeyPressedEventArgs args); // 0x000000018136F1D0-0x000000018136F200
	}
}
