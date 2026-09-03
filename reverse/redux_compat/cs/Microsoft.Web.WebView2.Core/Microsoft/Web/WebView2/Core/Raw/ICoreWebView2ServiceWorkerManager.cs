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
	[Guid("A2D52FD4-9B10-5971-8499-C67D1560F47A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2ServiceWorkerManager // TypeDefIndex: 11104
	{
		// Methods
		void add_ServiceWorkerRegistered(in ICoreWebView2ServiceWorkerRegisteredEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F5030-0x00000001813F50D0
		void remove_ServiceWorkerRegistered(in EventRegistrationToken token); // 0x00000001813F50D0-0x00000001813F5110
		void GetServiceWorkerRegistrations(in ICoreWebView2GetServiceWorkerRegistrationsCompletedHandler handler); // 0x00000001813F4FA0-0x00000001813F5030
		void GetServiceWorkerRegistrationsForScope(in string ScopeUri, in ICoreWebView2GetServiceWorkerRegistrationsCompletedHandler handler); // 0x00000001813F4EE0-0x00000001813F4FA0
	}
}
