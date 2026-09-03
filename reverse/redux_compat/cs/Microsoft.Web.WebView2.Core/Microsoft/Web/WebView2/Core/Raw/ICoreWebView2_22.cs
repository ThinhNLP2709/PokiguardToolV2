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
	[Guid("DB75DFC7-A857-4632-A398-6969DDE26C0A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_22 : ICoreWebView2_21 // TypeDefIndex: 11163
	{
		// Methods
		void _VtblGap1_120();
		void AddWebResourceRequestedFilterWithRequestSourceKinds(in string uri, in COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext, in COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds); // 0x00000001813F9820-0x00000001813F9890
		void RemoveWebResourceRequestedFilterWithRequestSourceKinds(in string uri, in COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext, in COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds); // 0x00000001813F9890-0x00000001813F9900
	}
}
