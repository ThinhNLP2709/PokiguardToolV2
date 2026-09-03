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
	[Guid("453E667F-12C7-49D4-BE6D-DDBE7956F57A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2WebResourceRequestedEventArgs // TypeDefIndex: 11139
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2WebResourceRequest Request { get; } // 0x00000001813F7AF0-0x00000001813F7B80 
		[DispId(1610678273)]
		ICoreWebView2WebResourceResponse Response { get; set; } // 0x00000001813F7BD0-0x00000001813F7C60 0x00000001813F7C60-0x00000001813F7CF0
		[DispId(1610678276)]
		COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext { get; } // 0x00000001813F7B80-0x00000001813F7BD0 
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F7A60-0x00000001813F7AF0
	}
}
