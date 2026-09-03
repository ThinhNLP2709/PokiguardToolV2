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
	[Guid("CF4FF1D1-5A67-5660-8D63-EF699881EA65")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2SaveFileSecurityCheckStartingEventArgs // TypeDefIndex: 11091
	{
		// Properties
		[DispId(1610678272)]
		int CancelSave { get; set; } // 0x00000001813F3C20-0x00000001813F3C70 0x00000001813F3E10-0x00000001813F3E50
		[DispId(1610678274)]
		string DocumentOriginUri { get; } // 0x00000001813F3C70-0x00000001813F3CE0 
		[DispId(1610678275)]
		string FileExtension { get; } // 0x00000001813F3CE0-0x00000001813F3D50 
		[DispId(1610678276)]
		string FilePath { get; } // 0x00000001813F3D50-0x00000001813F3DC0 
		[DispId(1610678277)]
		int SuppressDefaultPolicy { get; set; } // 0x00000001813F3DC0-0x00000001813F3E10 0x00000001813F3E50-0x00000001813F3E90
	
		// Methods
		ICoreWebView2Deferral GetDeferral(); // 0x00000001813F3B90-0x00000001813F3C20
	}
}
