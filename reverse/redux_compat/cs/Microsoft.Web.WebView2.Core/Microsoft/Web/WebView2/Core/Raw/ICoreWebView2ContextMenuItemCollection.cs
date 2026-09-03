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
	[Guid("F562A2F5-C415-45CF-B909-D4B7C1E276D3")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ContextMenuItemCollection // TypeDefIndex: 10908
	{
		// Properties
		[DispId(1610678272)]
		uint Count { get; } // 0x00000001813E3350-0x00000001813E33A0 
	
		// Methods
		ICoreWebView2ContextMenuItem GetValueAtIndex(in uint index); // 0x00000001813E31D0-0x00000001813E3270
		void RemoveValueAtIndex(in uint index); // 0x00000001813E3310-0x00000001813E3350
		void InsertValueAtIndex(in uint index, in ICoreWebView2ContextMenuItem value); // 0x00000001813E3270-0x00000001813E3310
	}
}
