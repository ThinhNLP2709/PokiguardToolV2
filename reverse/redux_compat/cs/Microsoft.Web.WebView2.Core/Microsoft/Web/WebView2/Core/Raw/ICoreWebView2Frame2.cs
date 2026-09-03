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
	[Guid("7A6A5834-D185-4DBF-B63F-4A9BC43107D4")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2Frame2 : ICoreWebView2Frame // TypeDefIndex: 10983
	{
		// Methods
		void _VtblGap1_8();
		void add_NavigationStarting(in ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA6B0-0x00000001813EA750
		void remove_NavigationStarting(in EventRegistrationToken token); // 0x00000001813EA8B0-0x00000001813EA8F0
		void add_ContentLoading(in ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA4D0-0x00000001813EA570
		void remove_ContentLoading(in EventRegistrationToken token); // 0x00000001813EA7F0-0x00000001813EA830
		void add_NavigationCompleted(in ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA610-0x00000001813EA6B0
		void remove_NavigationCompleted(in EventRegistrationToken token); // 0x00000001813EA870-0x00000001813EA8B0
		void add_DOMContentLoaded(in ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813EA570-0x00000001813EA610
		void remove_DOMContentLoaded(in EventRegistrationToken token); // 0x00000001813EA830-0x00000001813EA870
		void ExecuteScript(in string javaScript, in ICoreWebView2ExecuteScriptCompletedHandler handler); // 0x00000001813EA370-0x00000001813EA430
		void PostWebMessageAsJson(in string webMessageAsJson); // 0x00000001813EA430-0x00000001813EA480
		void PostWebMessageAsString(in string webMessageAsString); // 0x00000001813EA480-0x00000001813EA4D0
		void add_WebMessageReceived(in ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token); // 0x00000001813EA750-0x00000001813EA7F0
		void remove_WebMessageReceived(in EventRegistrationToken token); // 0x00000001813EA8F0-0x00000001813EA930
	}
}
