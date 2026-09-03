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
	[Guid("A5E9FAD9-C875-59DA-9BD7-473AA5CA1CEF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Environment14 : ICoreWebView2Environment13 // TypeDefIndex: 10951
	{
		// Methods
		void _VtblGap1_23();
		ICoreWebView2FileSystemHandle CreateWebFileSystemFileHandle(in string Path, in COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION Permission); // 0x00000001813E7FC0-0x00000001813E8080
		ICoreWebView2FileSystemHandle CreateWebFileSystemDirectoryHandle(in string Path, in COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION Permission); // 0x00000001813E7F00-0x00000001813E7FC0
	}
}
