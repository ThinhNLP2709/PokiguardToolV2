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
	[Guid("F8B289CB-421C-4A9A-97CC-2870B0AC1798")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrivatePartialController // TypeDefIndex: 11063
	{
		// Properties
		[DispId(1610678274)]
		int IsBrowserHitTransparent { get; } // 0x00000001813F1B20-0x00000001813F1B70 
	
		// Methods
		void add_KeyPressed(in ICoreWebView2PrivateKeyPressedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F1A80-0x00000001813F1B20
		void remove_KeyPressed(in EventRegistrationToken token); // 0x00000001813F1B70-0x00000001813F1BB0
	}
}
