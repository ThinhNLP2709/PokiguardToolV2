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
	[Guid("20D02D59-6DF2-42DC-BD06-F98A694B1302")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2_4 : ICoreWebView2_3 // TypeDefIndex: 11172
	{
		// Methods
		void _VtblGap1_70();
		void add_FrameCreated(in ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FA530-0x00000001813FA5D0
		void remove_FrameCreated(in EventRegistrationToken token); // 0x00000001813FA610-0x00000001813FA650
		void add_DownloadStarting(in ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FA490-0x00000001813FA530
		void remove_DownloadStarting(in EventRegistrationToken token); // 0x00000001813FA5D0-0x00000001813FA610
	}
}
