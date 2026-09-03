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
	[Guid("03C5FF5A-9B45-4A88-881C-89A9F328619C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2HttpResponseHeaders // TypeDefIndex: 11016
	{
		// Methods
		void AppendHeader(in string name, in string value); // 0x00000001813ECB00-0x00000001813ECB60
		int Contains(in string name); // 0x00000001813ECB60-0x00000001813ECBB0
		string GetHeader(in string name); // 0x00000001813ECBB0-0x00000001813ECC20
		ICoreWebView2HttpHeadersCollectionIterator GetHeaders(in string name); // 0x00000001813ECC20-0x00000001813ECCD0
		ICoreWebView2HttpHeadersCollectionIterator GetIterator(); // 0x00000001813ECCD0-0x00000001813ECD60
	}
}
