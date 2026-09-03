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
	[Guid("CA7F0E1F-3484-41D1-8C1A-65CD44A63F8D")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrintSettings2 : ICoreWebView2PrintSettings // TypeDefIndex: 11052
	{
		// Properties
		[DispId(1610743808)]
		string PageRanges { get; set; } // 0x00000001813F07E0-0x00000001813F0850 0x00000001813F0A50-0x00000001813F0AA0
		[DispId(1610743810)]
		int PagesPerSide { get; set; } // 0x00000001813F0850-0x00000001813F08A0 0x00000001813F0AA0-0x00000001813F0AE0
		[DispId(1610743812)]
		int Copies { get; set; } // 0x00000001813F06F0-0x00000001813F0740 0x00000001813F0990-0x00000001813F09D0
		[DispId(1610743814)]
		COREWEBVIEW2_PRINT_COLLATION Collation { get; set; } // 0x00000001813F0650-0x00000001813F06A0 0x00000001813F0910-0x00000001813F0950
		[DispId(1610743816)]
		COREWEBVIEW2_PRINT_COLOR_MODE ColorMode { get; set; } // 0x00000001813F06A0-0x00000001813F06F0 0x00000001813F0950-0x00000001813F0990
		[DispId(1610743818)]
		COREWEBVIEW2_PRINT_DUPLEX Duplex { get; set; } // 0x00000001813F0740-0x00000001813F0790 0x00000001813F09D0-0x00000001813F0A10
		[DispId(1610743820)]
		COREWEBVIEW2_PRINT_MEDIA_SIZE MediaSize { get; set; } // 0x00000001813F0790-0x00000001813F07E0 0x00000001813F0A10-0x00000001813F0A50
		[DispId(1610743822)]
		string PrinterName { get; set; } // 0x00000001813F08A0-0x00000001813F0910 0x00000001813F0AE0-0x00000001813F0B30
	
		// Methods
		void _VtblGap1_26();
	}
}
