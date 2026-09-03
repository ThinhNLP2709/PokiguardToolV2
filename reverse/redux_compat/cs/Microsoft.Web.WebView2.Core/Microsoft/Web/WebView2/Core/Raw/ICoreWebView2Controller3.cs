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
	[Guid("F9614724-5D2B-41DC-AEF7-73D62B51543B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Controller3 : ICoreWebView2Controller2 // TypeDefIndex: 10914
	{
		// Properties
		[DispId(1610809344)]
		double RasterizationScale { get; set; } // 0x00000001813E4320-0x00000001813E4370 0x00000001813E4440-0x00000001813E4490
		[DispId(1610809346)]
		int ShouldDetectMonitorScaleChanges { get; set; } // 0x00000001813E4370-0x00000001813E43C0 0x00000001813E4490-0x00000001813E44D0
		[DispId(1610809350)]
		COREWEBVIEW2_BOUNDS_MODE BoundsMode { get; set; } // 0x00000001813E42D0-0x00000001813E4320 0x00000001813E4400-0x00000001813E4440
	
		// Methods
		void _VtblGap1_25();
		void add_RasterizationScaleChanged(in ICoreWebView2RasterizationScaleChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E4230-0x00000001813E42D0
		void remove_RasterizationScaleChanged(in EventRegistrationToken token); // 0x00000001813E43C0-0x00000001813E4400
	}
}
