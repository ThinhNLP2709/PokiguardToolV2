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
	[Guid("4DAB9422-46FA-4C3E-A5D2-41D2071D3680")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ProcessFailedEventArgs2 : ICoreWebView2ProcessFailedEventArgs // TypeDefIndex: 11069
	{
		// Properties
		[DispId(1610743808)]
		COREWEBVIEW2_PROCESS_FAILED_REASON Reason { get; } // 0x00000001813F21D0-0x00000001813F2220 
		[DispId(1610743809)]
		int ExitCode { get; } // 0x00000001813F2080-0x00000001813F20D0 
		[DispId(1610743810)]
		string ProcessDescription { get; } // 0x00000001813F2160-0x00000001813F21D0 
		[DispId(1610743811)]
		ICoreWebView2FrameInfoCollection FrameInfosForFailedProcess { get; } // 0x00000001813F20D0-0x00000001813F2160 
	
		// Methods
		void _VtblGap1_1();
	}
}
