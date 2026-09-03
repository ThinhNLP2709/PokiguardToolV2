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
	[Guid("E86CAC0E-5523-465C-B536-8FB9FC8C8C60")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2HttpRequestHeaders // TypeDefIndex: 11015
	{
		// Methods
		string GetHeader(in string name); // 0x00000001813EC8A0-0x00000001813EC910
		ICoreWebView2HttpHeadersCollectionIterator GetHeaders(in string name); // 0x00000001813EC910-0x00000001813EC9C0
		int Contains(in string name); // 0x00000001813EC850-0x00000001813EC8A0
		void SetHeader(in string name, in string value); // 0x00000001813ECAA0-0x00000001813ECB00
		void RemoveHeader(in string name); // 0x00000001813ECA50-0x00000001813ECAA0
		ICoreWebView2HttpHeadersCollectionIterator GetIterator(); // 0x00000001813EC9C0-0x00000001813ECA50
	}
}
