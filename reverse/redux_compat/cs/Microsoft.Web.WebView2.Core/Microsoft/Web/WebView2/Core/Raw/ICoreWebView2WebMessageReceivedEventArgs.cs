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
	[Guid("0F99A40C-E962-4207-9E92-E3D542EFF849")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2WebMessageReceivedEventArgs // TypeDefIndex: 11135
	{
		// Properties
		[DispId(1610678272)]
		string Source { get; } // 0x00000001813F7500-0x00000001813F7570 
		[DispId(1610678273)]
		string WebMessageAsJson { get; } // 0x00000001813F7570-0x00000001813F75E0 
	
		// Methods
		string TryGetWebMessageAsString(); // 0x00000001813F7490-0x00000001813F7500
	}
}
