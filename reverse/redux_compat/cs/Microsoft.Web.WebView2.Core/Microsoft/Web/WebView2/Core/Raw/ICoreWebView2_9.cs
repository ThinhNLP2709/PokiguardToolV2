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
	[Guid("4D7B2EAB-9FDC-468D-B998-A9260B5ED651")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_9 : ICoreWebView2_8 // TypeDefIndex: 11177
	{
		// Properties
		[DispId(1611202562)]
		int IsDefaultDownloadDialogOpen { get; } // 0x00000001813FACE0-0x00000001813FAD30 
		[DispId(1611202565)]
		COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT DefaultDownloadDialogCornerAlignment { get; set; } // 0x00000001813FAC40-0x00000001813FAC90 0x00000001813FAD70-0x00000001813FADB0
		[DispId(1611202567)]
		tagPOINT DefaultDownloadDialogMargin { get; set; } // 0x00000001813FAC90-0x00000001813FACE0 0x00000001813FADB0-0x00000001813FADF0
	
		// Methods
		void _VtblGap1_85();
		void add_IsDefaultDownloadDialogOpenChanged(in ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token); // 0x00000001813FABA0-0x00000001813FAC40
		void remove_IsDefaultDownloadDialogOpenChanged(in EventRegistrationToken token); // 0x00000001813FAD30-0x00000001813FAD70
		void OpenDefaultDownloadDialog(); // 0x00000001813FAB60-0x00000001813FABA0
		void CloseDefaultDownloadDialog(); // 0x00000001813FAB20-0x00000001813FAB60
	}
}
