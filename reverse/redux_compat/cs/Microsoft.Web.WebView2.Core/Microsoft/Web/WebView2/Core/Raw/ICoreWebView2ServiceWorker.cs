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
	[Guid("245A7BB7-7C31-582D-95EE-0F2D99D2F5B0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ServiceWorker // TypeDefIndex: 11100
	{
		// Properties
		[DispId(1610678272)]
		string ScriptUri { get; } // 0x00000001813F5B10-0x00000001813F5B80 
	
		// Methods
		void add_Destroying(in ICoreWebView2ServiceWorkerDestroyingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F59D0-0x00000001813F5A70
		void remove_Destroying(in EventRegistrationToken token); // 0x00000001813F5B80-0x00000001813F5BC0
		void add_WebMessageReceived(in ICoreWebView2ServiceWorkerWebMessageReceivedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F5A70-0x00000001813F5B10
		void remove_WebMessageReceived(in EventRegistrationToken token); // 0x00000001813F5BC0-0x00000001813F5C00
		void PostWebMessageAsJson(in string webMessageAsJson); // 0x00000001813F5930-0x00000001813F5980
		void PostWebMessageAsString(in string webMessageAsString); // 0x00000001813F5980-0x00000001813F59D0
	}
}
