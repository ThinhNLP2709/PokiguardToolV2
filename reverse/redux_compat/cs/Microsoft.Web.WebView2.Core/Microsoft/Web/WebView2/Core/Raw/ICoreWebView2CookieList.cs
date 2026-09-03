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
	[Guid("F7F6F714-5D2A-43C6-9503-346ECE02D186")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2CookieList // TypeDefIndex: 10921
	{
		// Properties
		[DispId(1610678272)]
		uint Count { get; } // 0x00000001813E5190-0x00000001813E51E0 
	
		// Methods
		ICoreWebView2Cookie GetValueAtIndex(in uint index); // 0x00000001813E50F0-0x00000001813E5190
	}
}
