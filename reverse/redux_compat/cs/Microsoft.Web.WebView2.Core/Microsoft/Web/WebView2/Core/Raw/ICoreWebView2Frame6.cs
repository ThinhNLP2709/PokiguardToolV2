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
	[Guid("0DE611FD-31E9-5DDC-9D71-95EDA26EFF32")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Frame6 : ICoreWebView2Frame5 // TypeDefIndex: 10987
	{
		// Methods
		void _VtblGap1_25();
		void add_ScreenCaptureStarting(in ICoreWebView2FrameScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EAB30-0x00000001813EABD0
		void remove_ScreenCaptureStarting(in EventRegistrationToken token); // 0x00000001813EABD0-0x00000001813EAC10
	}
}
