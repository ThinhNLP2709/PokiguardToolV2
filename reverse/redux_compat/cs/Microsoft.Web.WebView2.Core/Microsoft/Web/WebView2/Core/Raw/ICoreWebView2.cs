/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ComImport]
	[CompilerGenerated]
	[Guid("76ECEACB-0462-4D94-AC83-423A6793775E")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	public interface ICoreWebView2 // TypeDefIndex: 10876
	{
		// Properties
		[DispId(1610678272)]
		ICoreWebView2Settings Settings { get; } // 0x00000001813FC210-0x00000001813FC2A0 
		[DispId(1610678273)]
		string Source { get; } // 0x00000001813FC2A0-0x00000001813FC310 
		[DispId(1610678306)]
		uint BrowserProcessId { get; } // 0x00000001813FC060-0x00000001813FC0B0 
		[DispId(1610678307)]
		int CanGoBack { get; } // 0x00000001813FC0B0-0x00000001813FC100 
		[DispId(1610678308)]
		int CanGoForward { get; } // 0x00000001813FC100-0x00000001813FC150 
		[DispId(1610678317)]
		string DocumentTitle { get; } // 0x00000001813FC1A0-0x00000001813FC210 
		[DispId(1610678323)]
		int ContainsFullScreenElement { get; } // 0x00000001813FC150-0x00000001813FC1A0 
	
		// Methods
		void Navigate(in string uri); // 0x00000001813FB3B0-0x00000001813FB400
		void NavigateToString(in string htmlContent); // 0x00000001813FB360-0x00000001813FB3B0
		void add_NavigationStarting(in ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBAC0-0x00000001813FBB60
		void remove_NavigationStarting(in EventRegistrationToken token); // 0x00000001813FC4D0-0x00000001813FC510
		void add_ContentLoading(in ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB700-0x00000001813FB7A0
		void remove_ContentLoading(in EventRegistrationToken token); // 0x00000001813FC350-0x00000001813FC390
		void add_SourceChanged(in ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBDE0-0x00000001813FBE80
		void remove_SourceChanged(in EventRegistrationToken token); // 0x00000001813FC610-0x00000001813FC650
		void add_HistoryChanged(in ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB980-0x00000001813FBA20
		void remove_HistoryChanged(in EventRegistrationToken token); // 0x00000001813FC450-0x00000001813FC490
		void add_NavigationCompleted(in ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBA20-0x00000001813FBAC0
		void remove_NavigationCompleted(in EventRegistrationToken token); // 0x00000001813FC490-0x00000001813FC4D0
		void add_FrameNavigationStarting(in ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB8E0-0x00000001813FB980
		void remove_FrameNavigationStarting(in EventRegistrationToken token); // 0x00000001813FC410-0x00000001813FC450
		void add_FrameNavigationCompleted(in ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB840-0x00000001813FB8E0
		void remove_FrameNavigationCompleted(in EventRegistrationToken token); // 0x00000001813FC3D0-0x00000001813FC410
		void add_ScriptDialogOpening(in ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBD40-0x00000001813FBDE0
		void remove_ScriptDialogOpening(in EventRegistrationToken token); // 0x00000001813FC5D0-0x00000001813FC610
		void add_PermissionRequested(in ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBC00-0x00000001813FBCA0
		void remove_PermissionRequested(in EventRegistrationToken token); // 0x00000001813FC550-0x00000001813FC590
		void add_ProcessFailed(in ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBCA0-0x00000001813FBD40
		void remove_ProcessFailed(in EventRegistrationToken token); // 0x00000001813FC590-0x00000001813FC5D0
		void AddScriptToExecuteOnDocumentCreated(in string javaScript, in ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler); // 0x00000001813FAE70-0x00000001813FAF30
		void RemoveScriptToExecuteOnDocumentCreated(in string id); // 0x00000001813FB570-0x00000001813FB5C0
		void ExecuteScript(in string javaScript, in ICoreWebView2ExecuteScriptCompletedHandler handler); // 0x00000001813FB170-0x00000001813FB230
		void CapturePreview(in COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, in IStream imageStream, in ICoreWebView2CapturePreviewCompletedHandler handler); // 0x00000001813FB060-0x00000001813FB170
		void Reload(); // 0x00000001813FB4E0-0x00000001813FB520
		void PostWebMessageAsJson(in string webMessageAsJson); // 0x00000001813FB440-0x00000001813FB490
		void PostWebMessageAsString(in string webMessageAsString); // 0x00000001813FB490-0x00000001813FB4E0
		void add_WebMessageReceived(in ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token); // 0x00000001813FBE80-0x00000001813FBF20
		void remove_WebMessageReceived(in EventRegistrationToken token); // 0x00000001813FC650-0x00000001813FC690
		void CallDevToolsProtocolMethod(in string methodName, in string parametersAsJson, in ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler); // 0x00000001813FAF90-0x00000001813FB060
		void GoBack(); // 0x00000001813FB2E0-0x00000001813FB320
		void GoForward(); // 0x00000001813FB320-0x00000001813FB360
		ICoreWebView2DevToolsProtocolEventReceiver GetDevToolsProtocolEventReceiver(in string eventName); // 0x00000001813FB230-0x00000001813FB2E0
		void Stop(); // 0x00000001813FB620-0x00000001813FB660
		void add_NewWindowRequested(in ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBB60-0x00000001813FBC00
		void remove_NewWindowRequested(in EventRegistrationToken token); // 0x00000001813FC510-0x00000001813FC550
		void add_DocumentTitleChanged(in ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB7A0-0x00000001813FB840
		void remove_DocumentTitleChanged(in EventRegistrationToken token); // 0x00000001813FC390-0x00000001813FC3D0
		void AddHostObjectToScript(in string name, in object @object); // 0x00000001813FADF0-0x00000001813FAE70
		void RemoveHostObjectFromScript(in string name); // 0x00000001813FB520-0x00000001813FB570
		void OpenDevToolsWindow(); // 0x00000001813FB400-0x00000001813FB440
		void add_ContainsFullScreenElementChanged(in ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FB660-0x00000001813FB700
		void remove_ContainsFullScreenElementChanged(in EventRegistrationToken token); // 0x00000001813FC310-0x00000001813FC350
		void add_WebResourceRequested(in ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBF20-0x00000001813FBFC0
		void remove_WebResourceRequested(in EventRegistrationToken token); // 0x00000001813FC690-0x00000001813FC6D0
		void AddWebResourceRequestedFilter(in string uri, in COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext); // 0x00000001813FAF30-0x00000001813FAF90
		void RemoveWebResourceRequestedFilter(in string uri, in COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext); // 0x00000001813FB5C0-0x00000001813FB620
		void add_WindowCloseRequested(in ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token); // 0x00000001813FBFC0-0x00000001813FC060
		void remove_WindowCloseRequested(in EventRegistrationToken token); // 0x00000001813FC6D0-0x00000001813FC710
	}
}
