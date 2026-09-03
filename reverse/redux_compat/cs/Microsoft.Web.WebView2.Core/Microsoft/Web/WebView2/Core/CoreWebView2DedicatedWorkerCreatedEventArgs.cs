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
	public class CoreWebView2DedicatedWorkerCreatedEventArgs : EventArgs // TypeDefIndex: 10536
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2DedicatedWorkerCreatedEventArgs _nativeICoreWebView2DedicatedWorkerCreatedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2DedicatedWorkerCreatedEventArgs _nativeICoreWebView2DedicatedWorkerCreatedEventArgs { get; set; } // 0x0000000181393B80-0x0000000181393C90 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2FrameInfo OriginalSourceFrameInfo { get; } // 0x00000001813937F0-0x00000001813939B0 
		public CoreWebView2DedicatedWorker Worker { get; } // 0x00000001813939B0-0x0000000181393B80 
	
		// Constructors
		internal CoreWebView2DedicatedWorkerCreatedEventArgs(object rawCoreWebView2DedicatedWorkerCreatedEventArgs); // 0x0000000181393780-0x00000001813937F0
	}
}
