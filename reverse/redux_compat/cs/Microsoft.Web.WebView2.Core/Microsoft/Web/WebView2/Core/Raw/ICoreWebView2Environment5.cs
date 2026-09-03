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
	[Guid("319E423D-E0D7-4B8D-9254-AE9475DE9B17")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Environment5 : ICoreWebView2Environment4 // TypeDefIndex: 10956
	{
		// Methods
		void _VtblGap1_9();
		void add_BrowserProcessExited(in ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E8390-0x00000001813E8430
		void remove_BrowserProcessExited(in EventRegistrationToken token); // 0x00000001813E8430-0x00000001813E8470
	}
}
