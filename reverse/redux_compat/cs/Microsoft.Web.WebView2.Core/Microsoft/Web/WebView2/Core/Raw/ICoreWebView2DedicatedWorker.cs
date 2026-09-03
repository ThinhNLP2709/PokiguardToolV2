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
	[Guid("66833876-EDBA-5A60-8508-7DA64504A9D2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2DedicatedWorker // TypeDefIndex: 10931
	{
		// Properties
		[DispId(1610678272)]
		string ScriptUri { get; } // 0x00000001813E6A70-0x00000001813E6AE0 
	
		// Methods
		void add_DedicatedWorkerCreated(in ICoreWebView2DedicatedWorkerDedicatedWorkerCreatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E6890-0x00000001813E6930
		void remove_DedicatedWorkerCreated(in EventRegistrationToken token); // 0x00000001813E6AE0-0x00000001813E6B20
		void add_Destroying(in ICoreWebView2DedicatedWorkerDestroyingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E6930-0x00000001813E69D0
		void remove_Destroying(in EventRegistrationToken token); // 0x00000001813E6B20-0x00000001813E6B60
		void add_WebMessageReceived(in ICoreWebView2DedicatedWorkerWebMessageReceivedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813E69D0-0x00000001813E6A70
		void remove_WebMessageReceived(in EventRegistrationToken token); // 0x00000001813E6B60-0x00000001813E6BA0
		void PostWebMessageAsJson(in string webMessageAsJson); // 0x00000001813E67F0-0x00000001813E6840
		void PostWebMessageAsString(in string webMessageAsString); // 0x00000001813E6840-0x00000001813E6890
	}
}
