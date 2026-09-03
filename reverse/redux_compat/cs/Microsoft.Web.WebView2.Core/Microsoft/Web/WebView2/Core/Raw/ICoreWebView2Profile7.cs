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
	[Guid("7B4C7906-A1AA-4CB4-B723-DB09F813D541")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Profile7 : ICoreWebView2Profile6 // TypeDefIndex: 11081
	{
		// Methods
		void _VtblGap1_19();
		void AddBrowserExtension(in string extensionFolderPath, in ICoreWebView2ProfileAddBrowserExtensionCompletedHandler handler); // 0x00000001813F2C00-0x00000001813F2CC0
		void GetBrowserExtensions(in ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler handler); // 0x00000001813F2CC0-0x00000001813F2D50
	}
}
