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
	[Guid("0EB34DC9-9F91-41E1-8639-95CD5943906B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_16 : ICoreWebView2_15 // TypeDefIndex: 11156
	{
		// Methods
		void _VtblGap1_110();
		void Print(in ICoreWebView2PrintSettings printSettings, in ICoreWebView2PrintCompletedHandler handler); // 0x00000001813F9390-0x00000001813F9490
		void ShowPrintUI(in COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind); // 0x00000001813F9490-0x00000001813F94D0
		void PrintToPdfStream(in ICoreWebView2PrintSettings printSettings, in ICoreWebView2PrintToPdfStreamCompletedHandler handler); // 0x00000001813F9290-0x00000001813F9390
	}
}
