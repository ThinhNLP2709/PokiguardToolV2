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
	[Guid("7390BB70-ABE0-4843-9529-F143B31B03D6")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ScriptDialogOpeningEventArgs // TypeDefIndex: 11095
	{
		// Properties
		[DispId(1610678272)]
		string Uri { get; } // 0x00000001813F4530-0x00000001813F45A0 
		[DispId(1610678273)]
		COREWEBVIEW2_SCRIPT_DIALOG_KIND Kind { get; } // 0x00000001813F4400-0x00000001813F4450 
		[DispId(1610678274)]
		string Message { get; } // 0x00000001813F4450-0x00000001813F44C0 
		[DispId(1610678276)]
		string DefaultText { get; } // 0x00000001813F4390-0x00000001813F4400 
		[DispId(1610678277)]
		string ResultText { get; set; } // 0x00000001813F44C0-0x00000001813F4530 0x00000001813F45A0-0x00000001813F45F0
	
		// Methods
		void Accept(); // 0x00000001813F42D0-0x00000001813F4300
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F4300-0x00000001813F4390
	}
}
