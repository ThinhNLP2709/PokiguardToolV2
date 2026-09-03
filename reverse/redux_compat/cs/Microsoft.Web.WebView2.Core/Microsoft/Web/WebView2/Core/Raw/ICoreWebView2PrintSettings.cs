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
	[Guid("377F3721-C74E-48CA-8DB1-DF68E51D60E2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2PrintSettings // TypeDefIndex: 11051
	{
		// Properties
		[DispId(1610678272)]
		COREWEBVIEW2_PRINT_ORIENTATION Orientation { get; set; } // 0x00000001813F0D50-0x00000001813F0DA0 0x00000001813F1140-0x00000001813F1180
		[DispId(1610678274)]
		double ScaleFactor { get; set; } // 0x00000001813F0E40-0x00000001813F0E90 0x00000001813F1200-0x00000001813F1240
		[DispId(1610678276)]
		double PageWidth { get; set; } // 0x00000001813F0DF0-0x00000001813F0E40 0x00000001813F11C0-0x00000001813F1200
		[DispId(1610678278)]
		double PageHeight { get; set; } // 0x00000001813F0DA0-0x00000001813F0DF0 0x00000001813F1180-0x00000001813F11C0
		[DispId(1610678280)]
		double MarginTop { get; set; } // 0x00000001813F0D00-0x00000001813F0D50 0x00000001813F1100-0x00000001813F1140
		[DispId(1610678282)]
		double MarginBottom { get; set; } // 0x00000001813F0C10-0x00000001813F0C60 0x00000001813F1020-0x00000001813F1060
		[DispId(1610678284)]
		double MarginLeft { get; set; } // 0x00000001813F0C60-0x00000001813F0CB0 0x00000001813F1060-0x00000001813F10B0
		[DispId(1610678286)]
		double MarginRight { get; set; } // 0x00000001813F0CB0-0x00000001813F0D00 0x00000001813F10B0-0x00000001813F1100
		[DispId(1610678288)]
		int ShouldPrintBackgrounds { get; set; } // 0x00000001813F0E90-0x00000001813F0EE0 0x00000001813F1240-0x00000001813F1280
		[DispId(1610678290)]
		int ShouldPrintSelectionOnly { get; set; } // 0x00000001813F0F30-0x00000001813F0F80 0x00000001813F12C0-0x00000001813F1300
		[DispId(1610678292)]
		int ShouldPrintHeaderAndFooter { get; set; } // 0x00000001813F0EE0-0x00000001813F0F30 0x00000001813F1280-0x00000001813F12C0
		[DispId(1610678294)]
		string HeaderTitle { get; set; } // 0x00000001813F0BA0-0x00000001813F0C10 0x00000001813F0FD0-0x00000001813F1020
		[DispId(1610678296)]
		string FooterUri { get; set; } // 0x00000001813F0B30-0x00000001813F0BA0 0x00000001813F0F80-0x00000001813F0FD0
	}
}
