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
	[Guid("9B897103-D035-551F-892E-3E8F2916D03E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2SharedWorkerManager // TypeDefIndex: 11127
	{
		// Methods
		void add_SharedWorkerCreated(in ICoreWebView2SharedWorkerCreatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813F6C50-0x00000001813F6CF0
		void remove_SharedWorkerCreated(in EventRegistrationToken token); // 0x00000001813F6CF0-0x00000001813F6D30
		void GetSharedWorkers(in ICoreWebView2GetSharedWorkersCompletedHandler handler); // 0x00000001813F6BC0-0x00000001813F6C50
	}
}
