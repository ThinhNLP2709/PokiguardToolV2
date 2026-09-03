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
	[Guid("55902952-0E0D-5AAA-A7D0-E833CDB34F62")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2SaveAsUIShowingEventArgs // TypeDefIndex: 11089
	{
		// Properties
		[DispId(1610678272)]
		string ContentMimeType { get; } // 0x00000001813F37C0-0x00000001813F3830 
		[DispId(1610678273)]
		int Cancel { get; set; } // 0x00000001813F3770-0x00000001813F37C0 0x00000001813F3980-0x00000001813F39C0
		[DispId(1610678275)]
		int SuppressDefaultDialog { get; set; } // 0x00000001813F38F0-0x00000001813F3940 0x00000001813F3A50-0x00000001813F3A90
		[DispId(1610678278)]
		string SaveAsFilePath { get; set; } // 0x00000001813F3880-0x00000001813F38F0 0x00000001813F3A00-0x00000001813F3A50
		[DispId(1610678280)]
		int AllowReplace { get; set; } // 0x00000001813F3720-0x00000001813F3770 0x00000001813F3940-0x00000001813F3980
		[DispId(1610678282)]
		COREWEBVIEW2_SAVE_AS_KIND Kind { get; set; } // 0x00000001813F3830-0x00000001813F3880 0x00000001813F39C0-0x00000001813F3A00
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F3690-0x00000001813F3720
	}
}
