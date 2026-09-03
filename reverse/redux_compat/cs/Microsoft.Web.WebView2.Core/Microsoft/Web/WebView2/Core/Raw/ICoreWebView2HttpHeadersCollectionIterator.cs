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
	[Guid("0702FC30-F43B-47BB-AB52-A42CB552AD9F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2HttpHeadersCollectionIterator // TypeDefIndex: 11014
	{
		// Properties
		[DispId(1610678273)]
		int HasCurrentHeader { get; } // 0x00000001813EC800-0x00000001813EC850 
	
		// Methods
		void GetCurrentHeader(out string name, out string value); // 0x00000001813EC700-0x00000001813EC7B0
		int MoveNext(); // 0x00000001813EC7B0-0x00000001813EC800
	}
}
