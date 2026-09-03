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
	[Guid("07D1A6C3-7175-4BA1-9306-E593CA07E46C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2LaunchingExternalUriSchemeEventArgs // TypeDefIndex: 11020
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813ED200-0x00000001813ED270 
		[DispId(1610678273)]
		string InitiatingOrigin { get; } // 0x00000001813ED140-0x00000001813ED1B0 
		[DispId(1610678274)]
		int IsUserInitiated { get; } // 0x00000001813ED1B0-0x00000001813ED200 
		[DispId(1610678275)]
		int Cancel { get; set; } // 0x00000001813ED0F0-0x00000001813ED140 0x00000001813ED270-0x00000001813ED2B0
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813ED060-0x00000001813ED0F0
	}
}
