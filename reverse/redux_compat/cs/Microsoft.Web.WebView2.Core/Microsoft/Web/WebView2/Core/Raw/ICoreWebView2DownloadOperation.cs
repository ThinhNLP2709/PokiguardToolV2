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
	[Guid("3D6B6CF2-AFE1-44C7-A995-C65117714336")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2DownloadOperation // TypeDefIndex: 10943
	{
		// Properties
		[DispId(1610678278)]
		string Uri { get; } // 0x00000001813E7580-0x00000001813E75F0 
		[DispId(1610678279)]
		string ContentDisposition { get; } // 0x00000001813E72D0-0x00000001813E7340 
		[DispId(1610678280)]
		string MimeType { get; } // 0x00000001813E7400-0x00000001813E7470 
		[DispId(1610678281)]
		long TotalBytesToReceive { get; } // 0x00000001813E7530-0x00000001813E7580 
		[DispId(1610678282)]
		long BytesReceived { get; } // 0x00000001813E7230-0x00000001813E7280 
		[DispId(1610678283)]
		string EstimatedEndTime { get; } // 0x00000001813E7340-0x00000001813E73B0 
		[DispId(1610678284)]
		string ResultFilePath { get; } // 0x00000001813E7470-0x00000001813E74E0 
		[DispId(1610678285)]
		COREWEBVIEW2_DOWNLOAD_STATE State { get; } // 0x00000001813E74E0-0x00000001813E7530 
		[DispId(1610678286)]
		COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON InterruptReason { get; } // 0x00000001813E73B0-0x00000001813E7400 
		[DispId(1610678290)]
		int CanResume { get; } // 0x00000001813E7280-0x00000001813E72D0 
	
		// Methods
		void add_BytesReceivedChanged(in ICoreWebView2BytesReceivedChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E7050-0x00000001813E70F0
		void remove_BytesReceivedChanged(in EventRegistrationToken token); // 0x00000001813E75F0-0x00000001813E7630
		void add_EstimatedEndTimeChanged(in ICoreWebView2EstimatedEndTimeChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E70F0-0x00000001813E7190
		void remove_EstimatedEndTimeChanged(in EventRegistrationToken token); // 0x00000001813E7630-0x00000001813E7670
		void add_StateChanged(in ICoreWebView2StateChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E7190-0x00000001813E7230
		void remove_StateChanged(in EventRegistrationToken token); // 0x00000001813E7670-0x00000001813E76B0
		void Cancel(); // 0x00000001813E6F90-0x00000001813E6FD0
		void Pause(); // 0x00000001813E6FD0-0x00000001813E7010
		void Resume(); // 0x00000001813E7010-0x00000001813E7050
	}
}
