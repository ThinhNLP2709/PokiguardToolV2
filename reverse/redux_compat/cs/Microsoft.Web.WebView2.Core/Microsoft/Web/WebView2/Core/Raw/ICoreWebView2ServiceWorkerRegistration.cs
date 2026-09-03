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
	[Guid("06003F5E-AF92-5E7E-B497-3FA167DD37C2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ServiceWorkerRegistration // TypeDefIndex: 11107
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2ServiceWorker ActiveServiceWorker { get; } // 0x00000001813F55D0-0x00000001813F5660 
		[DispId(1610678273)]
		string Origin { get; } // 0x00000001813F5740-0x00000001813F57B0 
		[DispId(1610678274)]
		string ScopeUri { get; } // 0x00000001813F5660-0x00000001813F56D0 
		[DispId(1610678275)]
		string TopLevelOrigin { get; } // 0x00000001813F56D0-0x00000001813F5740 
	
		// Methods
		void add_ServiceWorkerActivated(in ICoreWebView2ServiceWorkerActivatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F5490-0x00000001813F5530
		void remove_ServiceWorkerActivated(in EventRegistrationToken token); // 0x00000001813F57B0-0x00000001813F57F0
		void add_Unregistering(in ICoreWebView2ServiceWorkerRegistrationUnregisteringEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F5530-0x00000001813F55D0
		void remove_Unregistering(in EventRegistrationToken token); // 0x00000001813F57F0-0x00000001813F5830
	}
}
