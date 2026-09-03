/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2DownloadOperation // TypeDefIndex: 10540
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DownloadOperation _nativeICoreWebView2DownloadOperationValue; // 0x18
		private EventRegistrationToken _BytesReceivedChangedToken; // 0x20
		private EventHandler<object> privateBytesReceivedChanged; // 0x28
		private EventRegistrationToken _EstimatedEndTimeChangedToken; // 0x30
		private EventHandler<object> privateEstimatedEndTimeChanged; // 0x38
		private EventRegistrationToken _StateChangedToken; // 0x40
		private EventHandler<object> privateStateChanged; // 0x48
	
		// Properties
		internal ICoreWebView2DownloadOperation _nativeICoreWebView2DownloadOperation { get; set; } // 0x00000001813976A0-0x00000001813977B0 0x00000001802FAF70-0x00000001802FAF80
		public long BytesReceived { get; } // 0x0000000181396A40-0x0000000181396BA0 
		public bool CanResume { get; } // 0x0000000181396BA0-0x0000000181396D00 
		public string ContentDisposition { get; } // 0x0000000181396D00-0x0000000181396E60 
		public CoreWebView2DownloadInterruptReason InterruptReason { get; } // 0x0000000181396EF0-0x0000000181397050 
		public string MimeType { get; } // 0x0000000181397050-0x00000001813971B0 
		public string ResultFilePath { get; } // 0x00000001813971B0-0x0000000181397310 
		public CoreWebView2DownloadState State { get; } // 0x0000000181397310-0x0000000181397470 
		public string Uri { get; } // 0x0000000181397540-0x00000001813976A0 
		public DateTime EstimatedEndTime { get; } // 0x0000000181396E60-0x0000000181396EF0 
		public ulong? TotalBytesToReceive { get; } // 0x0000000181397470-0x0000000181397540 
	
		// Events
		public event EventHandler<object> BytesReceivedChanged {
			add; // 0x0000000181396290-0x0000000181396520
			remove; // 0x00000001813977B0-0x00000001813979B0
		}
		public event EventHandler<object> EstimatedEndTimeChanged {
			add; // 0x0000000181396520-0x00000001813967B0
			remove; // 0x00000001813979B0-0x0000000181397BB0
		}
		public event EventHandler<object> StateChanged {
			add; // 0x00000001813967B0-0x0000000181396A40
			remove; // 0x0000000181397BB0-0x0000000181397DB0
		}
	
		// Constructors
		internal CoreWebView2DownloadOperation(object rawCoreWebView2DownloadOperation); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnBytesReceivedChanged(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnEstimatedEndTimeChanged(object args); // 0x000000018136EEF0-0x000000018136EF10
		internal void OnStateChanged(object args); // 0x000000018136EFA0-0x000000018136EFC0
		public void Cancel(); // 0x0000000181395E40-0x0000000181395FB0
		public void Pause(); // 0x0000000181395FB0-0x0000000181396120
		public void Resume(); // 0x0000000181396120-0x0000000181396290
	}
}
