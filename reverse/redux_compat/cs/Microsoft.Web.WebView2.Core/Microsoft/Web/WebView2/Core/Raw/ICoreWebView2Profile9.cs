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
	[Guid("40C764D0-12FC-5D23-816D-971B353174C1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile9 : ICoreWebView2Profile8 // TypeDefIndex: 11083
	{
		// Properties
		[DispId(1611202560)]
		int AreWebViewScriptApisEnabledForServiceWorkers { get; set; } // 0x00000001813F2E70-0x00000001813F2EC0 0x00000001813F2FE0-0x00000001813F3020
		[DispId(1611202562)]
		ICoreWebView2ServiceWorkerManager ServiceWorkerManager { get; } // 0x00000001813F2EC0-0x00000001813F2F50 
		[DispId(1611202563)]
		ICoreWebView2SharedWorkerManager SharedWorkerManager { get; } // 0x00000001813F2F50-0x00000001813F2FE0 
	
		// Methods
		void _VtblGap1_24();
	}
}
