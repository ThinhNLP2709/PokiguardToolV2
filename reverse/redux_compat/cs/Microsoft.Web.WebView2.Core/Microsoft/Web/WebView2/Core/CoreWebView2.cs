/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2 // TypeDefIndex: 10498
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2 _nativeICoreWebView2Value; // 0x18
		private EventRegistrationToken _ContainsFullScreenElementChangedToken; // 0x20
		private EventHandler<object> privateContainsFullScreenElementChanged; // 0x28
		private EventRegistrationToken _ContentLoadingToken; // 0x30
		private EventHandler<CoreWebView2ContentLoadingEventArgs> privateContentLoading; // 0x38
		private EventRegistrationToken _DocumentTitleChangedToken; // 0x40
		private EventHandler<object> privateDocumentTitleChanged; // 0x48
		private EventRegistrationToken _FrameNavigationCompletedToken; // 0x50
		private EventHandler<CoreWebView2NavigationCompletedEventArgs> privateFrameNavigationCompleted; // 0x58
		private EventRegistrationToken _FrameNavigationStartingToken; // 0x60
		private EventHandler<CoreWebView2NavigationStartingEventArgs> privateFrameNavigationStarting; // 0x68
		private EventRegistrationToken _HistoryChangedToken; // 0x70
		private EventHandler<object> privateHistoryChanged; // 0x78
		private EventRegistrationToken _NavigationCompletedToken; // 0x80
		private EventHandler<CoreWebView2NavigationCompletedEventArgs> privateNavigationCompleted; // 0x88
		private EventRegistrationToken _NavigationStartingToken; // 0x90
		private EventHandler<CoreWebView2NavigationStartingEventArgs> privateNavigationStarting; // 0x98
		private EventRegistrationToken _NewWindowRequestedToken; // 0xA0
		private EventHandler<CoreWebView2NewWindowRequestedEventArgs> privateNewWindowRequested; // 0xA8
		private EventRegistrationToken _PermissionRequestedToken; // 0xB0
		private EventHandler<CoreWebView2PermissionRequestedEventArgs> privatePermissionRequested; // 0xB8
		private EventRegistrationToken _ProcessFailedToken; // 0xC0
		private EventHandler<CoreWebView2ProcessFailedEventArgs> privateProcessFailed; // 0xC8
		private EventRegistrationToken _ScriptDialogOpeningToken; // 0xD0
		private EventHandler<CoreWebView2ScriptDialogOpeningEventArgs> privateScriptDialogOpening; // 0xD8
		private EventRegistrationToken _SourceChangedToken; // 0xE0
		private EventHandler<CoreWebView2SourceChangedEventArgs> privateSourceChanged; // 0xE8
		private EventRegistrationToken _WebMessageReceivedToken; // 0xF0
		private EventHandler<CoreWebView2WebMessageReceivedEventArgs> privateWebMessageReceived; // 0xF8
		private EventRegistrationToken _WebResourceRequestedToken; // 0x100
		private EventHandler<CoreWebView2WebResourceRequestedEventArgs> privateWebResourceRequested; // 0x108
		private EventRegistrationToken _WindowCloseRequestedToken; // 0x110
		private EventHandler<object> privateWindowCloseRequested; // 0x118
		internal ICoreWebView2PrivatePartial _nativeICoreWebView2PrivatePartialValue; // 0x120
		internal ICoreWebView2_10 _nativeICoreWebView2_10Value; // 0x128
		private EventRegistrationToken _BasicAuthenticationRequestedToken; // 0x130
		private EventHandler<CoreWebView2BasicAuthenticationRequestedEventArgs> privateBasicAuthenticationRequested; // 0x138
		internal ICoreWebView2_11 _nativeICoreWebView2_11Value; // 0x140
		private EventRegistrationToken _ContextMenuRequestedToken; // 0x148
		private EventHandler<CoreWebView2ContextMenuRequestedEventArgs> privateContextMenuRequested; // 0x150
		internal ICoreWebView2_12 _nativeICoreWebView2_12Value; // 0x158
		private EventRegistrationToken _StatusBarTextChangedToken; // 0x160
		private EventHandler<object> privateStatusBarTextChanged; // 0x168
		internal ICoreWebView2_13 _nativeICoreWebView2_13Value; // 0x170
		internal ICoreWebView2_14 _nativeICoreWebView2_14Value; // 0x178
		private EventRegistrationToken _ServerCertificateErrorDetectedToken; // 0x180
		private EventHandler<CoreWebView2ServerCertificateErrorDetectedEventArgs> privateServerCertificateErrorDetected; // 0x188
		internal ICoreWebView2_15 _nativeICoreWebView2_15Value; // 0x190
		private EventRegistrationToken _FaviconChangedToken; // 0x198
		private EventHandler<object> privateFaviconChanged; // 0x1A0
		internal ICoreWebView2_16 _nativeICoreWebView2_16Value; // 0x1A8
		internal ICoreWebView2_17 _nativeICoreWebView2_17Value; // 0x1B0
		internal ICoreWebView2_18 _nativeICoreWebView2_18Value; // 0x1B8
		private EventRegistrationToken _LaunchingExternalUriSchemeToken; // 0x1C0
		private EventHandler<CoreWebView2LaunchingExternalUriSchemeEventArgs> privateLaunchingExternalUriScheme; // 0x1C8
		internal ICoreWebView2_19 _nativeICoreWebView2_19Value; // 0x1D0
		internal ICoreWebView2_2 _nativeICoreWebView2_2Value; // 0x1D8
		private EventRegistrationToken _DOMContentLoadedToken; // 0x1E0
		private EventHandler<CoreWebView2DOMContentLoadedEventArgs> privateDOMContentLoaded; // 0x1E8
		private EventRegistrationToken _WebResourceResponseReceivedToken; // 0x1F0
		private EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs> privateWebResourceResponseReceived; // 0x1F8
		internal ICoreWebView2_20 _nativeICoreWebView2_20Value; // 0x200
		internal ICoreWebView2_21 _nativeICoreWebView2_21Value; // 0x208
		internal ICoreWebView2_22 _nativeICoreWebView2_22Value; // 0x210
		internal ICoreWebView2_25 _nativeICoreWebView2_25Value; // 0x218
		private EventRegistrationToken _SaveAsUIShowingToken; // 0x220
		private EventHandler<CoreWebView2SaveAsUIShowingEventArgs> privateSaveAsUIShowing; // 0x228
		internal ICoreWebView2_23 _nativeICoreWebView2_23Value; // 0x230
		internal ICoreWebView2_27 _nativeICoreWebView2_27Value; // 0x238
		private EventRegistrationToken _ScreenCaptureStartingToken; // 0x240
		private EventHandler<CoreWebView2ScreenCaptureStartingEventArgs> privateScreenCaptureStarting; // 0x248
		internal ICoreWebView2_28 _nativeICoreWebView2_28Value; // 0x250
		internal ICoreWebView2_26 _nativeICoreWebView2_26Value; // 0x258
		private EventRegistrationToken _SaveFileSecurityCheckStartingToken; // 0x260
		private EventHandler<CoreWebView2SaveFileSecurityCheckStartingEventArgs> privateSaveFileSecurityCheckStarting; // 0x268
		internal ICoreWebView2_24 _nativeICoreWebView2_24Value; // 0x270
		private EventRegistrationToken _NotificationReceivedToken; // 0x278
		private EventHandler<CoreWebView2NotificationReceivedEventArgs> privateNotificationReceived; // 0x280
		internal ICoreWebView2_3 _nativeICoreWebView2_3Value; // 0x288
		internal ICoreWebView2_29 _nativeICoreWebView2_29Value; // 0x290
		private EventRegistrationToken _DedicatedWorkerCreatedToken; // 0x298
		private EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> privateDedicatedWorkerCreated; // 0x2A0
		internal ICoreWebView2_4 _nativeICoreWebView2_4Value; // 0x2A8
		private EventRegistrationToken _DownloadStartingToken; // 0x2B0
		private EventHandler<CoreWebView2DownloadStartingEventArgs> privateDownloadStarting; // 0x2B8
		private EventRegistrationToken _FrameCreatedToken; // 0x2C0
		private EventHandler<CoreWebView2FrameCreatedEventArgs> privateFrameCreated; // 0x2C8
		internal ICoreWebView2_5 _nativeICoreWebView2_5Value; // 0x2D0
		private EventRegistrationToken _ClientCertificateRequestedToken; // 0x2D8
		private EventHandler<CoreWebView2ClientCertificateRequestedEventArgs> privateClientCertificateRequested; // 0x2E0
		internal ICoreWebView2_6 _nativeICoreWebView2_6Value; // 0x2E8
		internal ICoreWebView2_7 _nativeICoreWebView2_7Value; // 0x2F0
		internal ICoreWebView2_8 _nativeICoreWebView2_8Value; // 0x2F8
		private EventRegistrationToken _IsDocumentPlayingAudioChangedToken; // 0x300
		private EventHandler<object> privateIsDocumentPlayingAudioChanged; // 0x308
		private EventRegistrationToken _IsMutedChangedToken; // 0x310
		private EventHandler<object> privateIsMutedChanged; // 0x318
		internal ICoreWebView2_9 _nativeICoreWebView2_9Value; // 0x320
		private EventRegistrationToken _IsDefaultDownloadDialogOpenChangedToken; // 0x328
		private EventHandler<object> privateIsDefaultDownloadDialogOpenChanged; // 0x330
	
		// Properties
		internal ICoreWebView2 _nativeICoreWebView2 { get; set; } // 0x000000018137AF20-0x000000018137B030 0x00000001802FAF70-0x00000001802FAF80
		public uint BrowserProcessId { get; } // 0x0000000181376F30-0x0000000181377090 
		public bool CanGoBack { get; } // 0x0000000181377090-0x00000001813771F0 
		public bool CanGoForward { get; } // 0x00000001813771F0-0x0000000181377350 
		public bool ContainsFullScreenElement { get; } // 0x0000000181377350-0x00000001813774B0 
		public string DocumentTitle { get; } // 0x00000001813779C0-0x0000000181377B20 
		public CoreWebView2Settings Settings { get; } // 0x0000000181378A00-0x0000000181378BC0 
		public string Source { get; } // 0x0000000181378BC0-0x0000000181378D20 
		internal ICoreWebView2PrivatePartial _nativeICoreWebView2PrivatePartial { get; set; } // 0x0000000181378E80-0x0000000181378FA0 0x0000000181380050-0x0000000181380070
		internal ICoreWebView2_10 _nativeICoreWebView2_10 { get; set; } // 0x0000000181378FA0-0x00000001813790C0 0x0000000181380070-0x0000000181380090
		internal ICoreWebView2_11 _nativeICoreWebView2_11 { get; set; } // 0x00000001813790C0-0x00000001813791E0 0x0000000181380090-0x00000001813800B0
		internal ICoreWebView2_12 _nativeICoreWebView2_12 { get; set; } // 0x00000001813791E0-0x0000000181379300 0x00000001813800B0-0x00000001813800D0
		public string StatusBarText { get; } // 0x0000000181378D20-0x0000000181378E80 
		internal ICoreWebView2_13 _nativeICoreWebView2_13 { get; set; } // 0x0000000181379300-0x0000000181379420 0x00000001813800D0-0x00000001813800F0
		public CoreWebView2Profile Profile { get; } // 0x0000000181378840-0x0000000181378A00 
		internal ICoreWebView2_14 _nativeICoreWebView2_14 { get; set; } // 0x0000000181379420-0x0000000181379540 0x00000001813800F0-0x0000000181380110
		internal ICoreWebView2_15 _nativeICoreWebView2_15 { get; set; } // 0x0000000181379540-0x0000000181379660 0x0000000181380110-0x0000000181380130
		public string FaviconUri { get; } // 0x0000000181377CE0-0x0000000181377E40 
		internal ICoreWebView2_16 _nativeICoreWebView2_16 { get; set; } // 0x0000000181379660-0x0000000181379780 0x000000018033A5B0-0x000000018033A5D0
		internal ICoreWebView2_17 _nativeICoreWebView2_17 { get; set; } // 0x0000000181379780-0x00000001813798A0 0x0000000181380130-0x0000000181380150
		internal ICoreWebView2_18 _nativeICoreWebView2_18 { get; set; } // 0x00000001813798A0-0x00000001813799C0 0x000000018033ECB0-0x000000018033ECD0
		internal ICoreWebView2_19 _nativeICoreWebView2_19 { get; set; } // 0x00000001813799C0-0x0000000181379AE0 0x0000000181380150-0x0000000181380170
		public CoreWebView2MemoryUsageTargetLevel MemoryUsageTargetLevel { get; set; } // 0x00000001813786E0-0x0000000181378840 0x000000018137FEE0-0x0000000181380050
		internal ICoreWebView2_2 _nativeICoreWebView2_2 { get; set; } // 0x000000018137A620-0x000000018137A740 0x0000000181380210-0x0000000181380230
		public CoreWebView2CookieManager CookieManager { get; } // 0x00000001813774B0-0x0000000181377670 
		public CoreWebView2Environment Environment { get; } // 0x0000000181377B20-0x0000000181377CE0 
		internal ICoreWebView2_20 _nativeICoreWebView2_20 { get; set; } // 0x0000000181379AE0-0x0000000181379C00 0x000000018033EC50-0x000000018033EC70
		public uint FrameId { get; } // 0x0000000181378000-0x0000000181378160 
		internal ICoreWebView2_21 _nativeICoreWebView2_21 { get; set; } // 0x0000000181379C00-0x0000000181379D20 0x0000000181380170-0x0000000181380190
		internal ICoreWebView2_22 _nativeICoreWebView2_22 { get; set; } // 0x0000000181379D20-0x0000000181379E40 0x0000000181380190-0x00000001813801B0
		internal ICoreWebView2_25 _nativeICoreWebView2_25 { get; set; } // 0x000000018137A080-0x000000018137A1A0 0x00000001813801D0-0x00000001813801F0
		internal ICoreWebView2_23 _nativeICoreWebView2_23 { get; set; } // 0x0000000181379E40-0x0000000181379F60 0x0000000180BBDE30-0x0000000180BBDE50
		internal ICoreWebView2_27 _nativeICoreWebView2_27 { get; set; } // 0x000000018137A2C0-0x000000018137A3E0 0x000000018033E920-0x000000018033E940
		internal ICoreWebView2_28 _nativeICoreWebView2_28 { get; set; } // 0x000000018137A3E0-0x000000018137A500 0x000000018033E940-0x000000018033E960
		public CoreWebView2Find Find { get; } // 0x0000000181377E40-0x0000000181378000 
		internal ICoreWebView2_26 _nativeICoreWebView2_26 { get; set; } // 0x000000018137A1A0-0x000000018137A2C0 0x0000000180BBDE80-0x0000000180BBDEA0
		internal ICoreWebView2_24 _nativeICoreWebView2_24 { get; set; } // 0x0000000181379F60-0x000000018137A080 0x00000001813801B0-0x00000001813801D0
		internal ICoreWebView2_3 _nativeICoreWebView2_3 { get; set; } // 0x000000018137A740-0x000000018137A860 0x0000000181380230-0x0000000181380250
		public bool IsSuspended { get; } // 0x0000000181378580-0x00000001813786E0 
		internal ICoreWebView2_29 _nativeICoreWebView2_29 { get; set; } // 0x000000018137A500-0x000000018137A620 0x00000001813801F0-0x0000000181380210
		internal ICoreWebView2_4 _nativeICoreWebView2_4 { get; set; } // 0x000000018137A860-0x000000018137A980 0x0000000181380250-0x0000000181380270
		internal ICoreWebView2_5 _nativeICoreWebView2_5 { get; set; } // 0x000000018137A980-0x000000018137AAA0 0x0000000181380270-0x0000000181380290
		internal ICoreWebView2_6 _nativeICoreWebView2_6 { get; set; } // 0x000000018137AAA0-0x000000018137ABC0 0x0000000181380290-0x00000001813802B0
		internal ICoreWebView2_7 _nativeICoreWebView2_7 { get; set; } // 0x000000018137ABC0-0x000000018137ACE0 0x00000001813802B0-0x00000001813802D0
		internal ICoreWebView2_8 _nativeICoreWebView2_8 { get; set; } // 0x000000018137ACE0-0x000000018137AE00 0x00000001813802D0-0x00000001813802F0
		public bool IsDocumentPlayingAudio { get; } // 0x00000001813782C0-0x0000000181378420 
		public bool IsMuted { get; set; } // 0x0000000181378420-0x0000000181378580 0x000000018137FD70-0x000000018137FEE0
		internal ICoreWebView2_9 _nativeICoreWebView2_9 { get; set; } // 0x000000018137AE00-0x000000018137AF20 0x00000001813802F0-0x0000000181380310
		public CoreWebView2DefaultDownloadDialogCornerAlignment DefaultDownloadDialogCornerAlignment { get; set; } // 0x0000000181377670-0x00000001813777D0 0x000000018137F9D0-0x000000018137FB40
		public Point DefaultDownloadDialogMargin { get; set; } // 0x00000001813777D0-0x00000001813779C0 0x000000018137FB40-0x000000018137FD70
		public bool IsDefaultDownloadDialogOpen { get; } // 0x0000000181378160-0x00000001813782C0 
	
		// Events
		public event EventHandler<object> ContainsFullScreenElementChanged {
			add; // 0x00000001813718F0-0x0000000181371B80
			remove; // 0x000000018137B470-0x000000018137B670
		}
		public event EventHandler<CoreWebView2ContentLoadingEventArgs> ContentLoading {
			add; // 0x0000000181371B80-0x0000000181371E10
			remove; // 0x000000018137B670-0x000000018137B870
		}
		public event EventHandler<object> DocumentTitleChanged {
			add; // 0x00000001813725F0-0x0000000181372880
			remove; // 0x000000018137BED0-0x000000018137C0D0
		}
		public event EventHandler<CoreWebView2NavigationCompletedEventArgs> FrameNavigationCompleted {
			add; // 0x0000000181373060-0x00000001813732F0
			remove; // 0x000000018137C730-0x000000018137C930
		}
		public event EventHandler<CoreWebView2NavigationStartingEventArgs> FrameNavigationStarting {
			add; // 0x00000001813732F0-0x0000000181373580
			remove; // 0x000000018137C930-0x000000018137CB30
		}
		public event EventHandler<object> HistoryChanged {
			add; // 0x0000000181373580-0x0000000181373810
			remove; // 0x000000018137CB30-0x000000018137CD30
		}
		public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted {
			add; // 0x0000000181374290-0x0000000181374530
			remove; // 0x000000018137D5B0-0x000000018137D7D0
		}
		public event EventHandler<CoreWebView2NavigationStartingEventArgs> NavigationStarting {
			add; // 0x0000000181374530-0x00000001813747D0
			remove; // 0x000000018137D7D0-0x000000018137D9F0
		}
		public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> NewWindowRequested {
			add; // 0x00000001813747D0-0x0000000181374A70
			remove; // 0x000000018137D9F0-0x000000018137DC10
		}
		public event EventHandler<CoreWebView2PermissionRequestedEventArgs> PermissionRequested {
			add; // 0x0000000181374D10-0x0000000181374FB0
			remove; // 0x000000018137DE30-0x000000018137E050
		}
		public event EventHandler<CoreWebView2ProcessFailedEventArgs> ProcessFailed {
			add; // 0x0000000181374FB0-0x0000000181375250
			remove; // 0x000000018137E050-0x000000018137E270
		}
		public event EventHandler<CoreWebView2ScriptDialogOpeningEventArgs> ScriptDialogOpening {
			add; // 0x0000000181375A30-0x0000000181375CD0
			remove; // 0x000000018137E8D0-0x000000018137EAF0
		}
		public event EventHandler<CoreWebView2SourceChangedEventArgs> SourceChanged {
			add; // 0x0000000181375F70-0x0000000181376210
			remove; // 0x000000018137ED10-0x000000018137EF30
		}
		public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived {
			add; // 0x00000001813764B0-0x0000000181376750
			remove; // 0x000000018137F150-0x000000018137F370
		}
		public event EventHandler<CoreWebView2WebResourceRequestedEventArgs> WebResourceRequested {
			add; // 0x0000000181376750-0x00000001813769F0
			remove; // 0x000000018137F370-0x000000018137F590
		}
		public event EventHandler<object> WindowCloseRequested {
			add; // 0x0000000181376C90-0x0000000181376F30
			remove; // 0x000000018137F7B0-0x000000018137F9D0
		}
		public event EventHandler<CoreWebView2BasicAuthenticationRequestedEventArgs> BasicAuthenticationRequested {
			add; // 0x00000001813713B0-0x0000000181371650
			remove; // 0x000000018137B030-0x000000018137B250
		}
		public event EventHandler<CoreWebView2ContextMenuRequestedEventArgs> ContextMenuRequested {
			add; // 0x0000000181371E10-0x00000001813720B0
			remove; // 0x000000018137B870-0x000000018137BA90
		}
		public event EventHandler<object> StatusBarTextChanged {
			add; // 0x0000000181376210-0x00000001813764B0
			remove; // 0x000000018137EF30-0x000000018137F150
		}
		public event EventHandler<CoreWebView2ServerCertificateErrorDetectedEventArgs> ServerCertificateErrorDetected {
			add; // 0x0000000181375CD0-0x0000000181375F70
			remove; // 0x000000018137EAF0-0x000000018137ED10
		}
		public event EventHandler<object> FaviconChanged {
			add; // 0x0000000181372B20-0x0000000181372DC0
			remove; // 0x000000018137C2F0-0x000000018137C510
		}
		public event EventHandler<CoreWebView2LaunchingExternalUriSchemeEventArgs> LaunchingExternalUriScheme {
			add; // 0x0000000181373FF0-0x0000000181374290
			remove; // 0x000000018137D390-0x000000018137D5B0
		}
		public event EventHandler<CoreWebView2DOMContentLoadedEventArgs> DOMContentLoaded {
			add; // 0x00000001813720B0-0x0000000181372350
			remove; // 0x000000018137BA90-0x000000018137BCB0
		}
		public event EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs> WebResourceResponseReceived {
			add; // 0x00000001813769F0-0x0000000181376C90
			remove; // 0x000000018137F590-0x000000018137F7B0
		}
		public event EventHandler<CoreWebView2SaveAsUIShowingEventArgs> SaveAsUIShowing {
			add; // 0x0000000181375250-0x00000001813754F0
			remove; // 0x000000018137E270-0x000000018137E490
		}
		public event EventHandler<CoreWebView2ScreenCaptureStartingEventArgs> ScreenCaptureStarting {
			add; // 0x0000000181375790-0x0000000181375A30
			remove; // 0x000000018137E6B0-0x000000018137E8D0
		}
		public event EventHandler<CoreWebView2SaveFileSecurityCheckStartingEventArgs> SaveFileSecurityCheckStarting {
			add; // 0x00000001813754F0-0x0000000181375790
			remove; // 0x000000018137E490-0x000000018137E6B0
		}
		public event EventHandler<CoreWebView2NotificationReceivedEventArgs> NotificationReceived {
			add; // 0x0000000181374A70-0x0000000181374D10
			remove; // 0x000000018137DC10-0x000000018137DE30
		}
		public event EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> DedicatedWorkerCreated {
			add; // 0x0000000181372350-0x00000001813725F0
			remove; // 0x000000018137BCB0-0x000000018137BED0
		}
		public event EventHandler<CoreWebView2DownloadStartingEventArgs> DownloadStarting {
			add; // 0x0000000181372880-0x0000000181372B20
			remove; // 0x000000018137C0D0-0x000000018137C2F0
		}
		public event EventHandler<CoreWebView2FrameCreatedEventArgs> FrameCreated {
			add; // 0x0000000181372DC0-0x0000000181373060
			remove; // 0x000000018137C510-0x000000018137C730
		}
		public event EventHandler<CoreWebView2ClientCertificateRequestedEventArgs> ClientCertificateRequested {
			add; // 0x0000000181371650-0x00000001813718F0
			remove; // 0x000000018137B250-0x000000018137B470
		}
		public event EventHandler<object> IsDocumentPlayingAudioChanged {
			add; // 0x0000000181373AB0-0x0000000181373D50
			remove; // 0x000000018137CF50-0x000000018137D170
		}
		public event EventHandler<object> IsMutedChanged {
			add; // 0x0000000181373D50-0x0000000181373FF0
			remove; // 0x000000018137D170-0x000000018137D390
		}
		public event EventHandler<object> IsDefaultDownloadDialogOpenChanged {
			add; // 0x0000000181373810-0x0000000181373AB0
			remove; // 0x000000018137CD30-0x000000018137CF50
		}
	
		// Nested types
		[CompilerGenerated]
		private struct _AddScriptToExecuteOnDocumentCreatedAsync_d__119 : IAsyncStateMachine // TypeDefIndex: 10499
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string javaScript; // 0x28
			private CoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181380340-0x00000001813807A0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813807A0-0x0000000181380800
		}
	
		[CompilerGenerated]
		private struct _CallDevToolsProtocolMethodAsync_d__126 : IAsyncStateMachine // TypeDefIndex: 10500
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string methodName; // 0x28
			public string parametersAsJson; // 0x30
			private CoreWebView2CallDevToolsProtocolMethodCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181380800-0x0000000181380CE0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181380CE0-0x0000000181380D40
		}
	
		[CompilerGenerated]
		private struct _CallDevToolsProtocolMethodForSessionAsync_d__161 : IAsyncStateMachine // TypeDefIndex: 10501
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string sessionId; // 0x28
			public string methodName; // 0x30
			public string parametersAsJson; // 0x38
			private CoreWebView2CallDevToolsProtocolMethodCompletedHandler _handler_5__2; // 0x40
			private object __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181380D40-0x0000000181381220
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181381220-0x0000000181381280
		}
	
		[CompilerGenerated]
		private struct _CapturePreviewAsync_d__122 : IAsyncStateMachine // TypeDefIndex: 10502
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public CoreWebView2CapturePreviewImageFormat imageFormat; // 0x28
			public Stream imageStream; // 0x30
			private CoreWebView2CapturePreviewCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181381280-0x0000000181381750
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181381750-0x00000001813817B0
		}
	
		[CompilerGenerated]
		private struct _ClearServerCertificateErrorActionsAsync_d__190 : IAsyncStateMachine // TypeDefIndex: 10503
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			private CoreWebView2ClearServerCertificateErrorActionsCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813817B0-0x0000000181381BD0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181381BD0-0x0000000181381C30
		}
	
		[CompilerGenerated]
		private struct _ExecuteScriptAsync_d__121 : IAsyncStateMachine // TypeDefIndex: 10504
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string javaScript; // 0x28
			private CoreWebView2ExecuteScriptCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813820C0-0x0000000181382520
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181382520-0x0000000181382580
		}
	
		[CompilerGenerated]
		private struct _ExecuteScriptWithResultAsync_d__264 : IAsyncStateMachine // TypeDefIndex: 10505
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2ExecuteScriptResult> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string javaScript; // 0x28
			private CoreWebView2ExecuteScriptWithResultCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181382580-0x00000001813829E0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813829E0-0x0000000181382A40
		}
	
		[CompilerGenerated]
		private struct _GetFaviconAsync_d__203 : IAsyncStateMachine // TypeDefIndex: 10506
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<Stream> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public CoreWebView2FaviconImageFormat format; // 0x28
			private CoreWebView2GetFaviconCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181382A40-0x0000000181382EA0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181382EA0-0x0000000181382F00
		}
	
		[CompilerGenerated]
		private struct _PrintAsync_d__208 : IAsyncStateMachine // TypeDefIndex: 10507
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2PrintStatus> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public CoreWebView2PrintSettings printSettings; // 0x28
			private CoreWebView2PrintCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181382F00-0x0000000181383370
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181383370-0x00000001813833D0
		}
	
		[CompilerGenerated]
		private struct _PrintToPdfAsync_d__377 : IAsyncStateMachine // TypeDefIndex: 10508
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public string ResultFilePath; // 0x28
			public CoreWebView2PrintSettings printSettings; // 0x30
			private CoreWebView2PrintToPdfCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001813833D0-0x00000001813838B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813838B0-0x0000000181383910
		}
	
		[CompilerGenerated]
		private struct _PrintToPdfStreamAsync_d__210 : IAsyncStateMachine // TypeDefIndex: 10509
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<Stream> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			public CoreWebView2PrintSettings printSettings; // 0x28
			private CoreWebView2PrintToPdfStreamCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181383910-0x0000000181383D80
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181383D80-0x0000000181383DE0
		}
	
		[CompilerGenerated]
		private struct _ShowSaveAsUIAsync_d__281 : IAsyncStateMachine // TypeDefIndex: 10510
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2SaveAsUIResult> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			private CoreWebView2ShowSaveAsUICompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181384260-0x00000001813846B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813846B0-0x0000000181384710
		}
	
		[CompilerGenerated]
		private struct _TrySuspendAsync_d__328 : IAsyncStateMachine // TypeDefIndex: 10511
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			public CoreWebView2 __4__this; // 0x20
			private CoreWebView2TrySuspendCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181384710-0x0000000181384B60
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181384B60-0x0000000181384BC0
		}
	
		// Constructors
		internal CoreWebView2(object rawCoreWebView2); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnContainsFullScreenElementChanged(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnContentLoading(CoreWebView2ContentLoadingEventArgs args); // 0x000000018136EEF0-0x000000018136EF10
		internal void OnDocumentTitleChanged(object args); // 0x000000018136EFA0-0x000000018136EFC0
		internal void OnFrameNavigationCompleted(CoreWebView2NavigationCompletedEventArgs args); // 0x000000018136F050-0x000000018136F070
		internal void OnFrameNavigationStarting(CoreWebView2NavigationStartingEventArgs args); // 0x000000018136F070-0x000000018136F090
		internal void OnHistoryChanged(object args); // 0x000000018136F090-0x000000018136F0B0
		internal void OnNavigationCompleted(CoreWebView2NavigationCompletedEventArgs args); // 0x000000018136F170-0x000000018136F1A0
		internal void OnNavigationStarting(CoreWebView2NavigationStartingEventArgs args); // 0x000000018136F1A0-0x000000018136F1D0
		internal void OnNewWindowRequested(CoreWebView2NewWindowRequestedEventArgs args); // 0x000000018136F1D0-0x000000018136F200
		internal void OnPermissionRequested(CoreWebView2PermissionRequestedEventArgs args); // 0x000000018136F230-0x000000018136F260
		internal void OnProcessFailed(CoreWebView2ProcessFailedEventArgs args); // 0x000000018136F260-0x000000018136F290
		internal void OnScriptDialogOpening(CoreWebView2ScriptDialogOpeningEventArgs args); // 0x000000018136F320-0x000000018136F350
		internal void OnSourceChanged(CoreWebView2SourceChangedEventArgs args); // 0x000000018136F380-0x000000018136F3B0
		internal void OnWebMessageReceived(CoreWebView2WebMessageReceivedEventArgs args); // 0x000000018136F3E0-0x000000018136F410
		internal void OnWebResourceRequested(CoreWebView2WebResourceRequestedEventArgs args); // 0x000000018136F410-0x000000018136F440
		internal void OnWindowCloseRequested(object args); // 0x000000018136F470-0x000000018136F4A0
		public void Navigate(string uri); // 0x000000018136ED00-0x000000018136EE70
		public void NavigateToString(string htmlContent); // 0x000000018136EA00-0x000000018136EB70
		public async Task<string> AddScriptToExecuteOnDocumentCreatedAsync(string javaScript); // 0x000000018136D240-0x000000018136D340
		public void RemoveScriptToExecuteOnDocumentCreated(string id); // 0x00000001813705C0-0x0000000181370730
		public async Task<string> ExecuteScriptAsync(string javaScript); // 0x000000018136E1C0-0x000000018136E2C0
		public async Task CapturePreviewAsync(CoreWebView2CapturePreviewImageFormat imageFormat, Stream imageStream); // 0x000000018136D8B0-0x000000018136D9B0
		public void Reload(); // 0x00000001813702E0-0x0000000181370450
		public void PostWebMessageAsJson(string webMessageAsJson); // 0x000000018136FB10-0x000000018136FC80
		public void PostWebMessageAsString(string webMessageAsString); // 0x000000018136FE50-0x000000018136FFC0
		public async Task<string> CallDevToolsProtocolMethodAsync(string methodName, string parametersAsJson); // 0x000000018136D650-0x000000018136D770
		public void GoBack(); // 0x000000018136E720-0x000000018136E890
		public void GoForward(); // 0x000000018136E890-0x000000018136EA00
		public CoreWebView2DevToolsProtocolEventReceiver GetDevToolsProtocolEventReceiver(string eventName); // 0x000000018136E430-0x000000018136E630
		public void Stop(); // 0x0000000181371170-0x00000001813712E0
		public void AddHostObjectToScript(string name, object rawObject); // 0x000000018136D040-0x000000018136D240
		public void RemoveHostObjectFromScript(string name); // 0x0000000181370450-0x00000001813705C0
		public void OpenDevToolsWindow(); // 0x000000018136F610-0x000000018136F780
		public void AddWebResourceRequestedFilter(string uri, CoreWebView2WebResourceContext ResourceContext); // 0x000000018136D4D0-0x000000018136D650
		public void RemoveWebResourceRequestedFilter(string uri, CoreWebView2WebResourceContext ResourceContext); // 0x00000001813708D0-0x0000000181370A50
		internal void AddHostObjectHelper(CoreWebView2PrivateHostObjectHelper hostObjectHelper); // 0x000000018136CEC0-0x000000018136D040
		internal void OnBasicAuthenticationRequested(CoreWebView2BasicAuthenticationRequestedEventArgs args); // 0x000000018136EE70-0x000000018136EEA0
		internal void OnContextMenuRequested(CoreWebView2ContextMenuRequestedEventArgs args); // 0x000000018136EF10-0x000000018136EF40
		public async Task<string> CallDevToolsProtocolMethodForSessionAsync(string sessionId, string methodName, string parametersAsJson); // 0x000000018136D770-0x000000018136D8B0
		internal void OnStatusBarTextChanged(object args); // 0x000000018136F3B0-0x000000018136F3E0
		internal void OnServerCertificateErrorDetected(CoreWebView2ServerCertificateErrorDetectedEventArgs args); // 0x000000018136F350-0x000000018136F380
		public async Task ClearServerCertificateErrorActionsAsync(); // 0x000000018136D9B0-0x000000018136DA70
		internal void OnFaviconChanged(object args); // 0x000000018136EFF0-0x000000018136F020
		public async Task<Stream> GetFaviconAsync(CoreWebView2FaviconImageFormat format); // 0x000000018136E630-0x000000018136E720
		public async Task<CoreWebView2PrintStatus> PrintAsync(CoreWebView2PrintSettings printSettings); // 0x000000018136FFC0-0x00000001813700C0
		public void ShowPrintUI(CoreWebView2PrintDialogKind printDialogKind); // 0x0000000181370F30-0x00000001813710A0
		public async Task<Stream> PrintToPdfStreamAsync(CoreWebView2PrintSettings printSettings); // 0x00000001813701E0-0x00000001813702E0
		public void PostSharedBufferToScript(CoreWebView2SharedBuffer sharedBuffer, CoreWebView2SharedBufferAccess access, string additionalDataAsJson); // 0x000000018136F8F0-0x000000018136FB10
		internal void OnLaunchingExternalUriScheme(CoreWebView2LaunchingExternalUriSchemeEventArgs args); // 0x000000018136F140-0x000000018136F170
		internal void OnDOMContentLoaded(CoreWebView2DOMContentLoadedEventArgs args); // 0x000000018136EF40-0x000000018136EF70
		internal void OnWebResourceResponseReceived(CoreWebView2WebResourceResponseReceivedEventArgs args); // 0x000000018136F440-0x000000018136F470
		public void NavigateWithWebResourceRequest(CoreWebView2WebResourceRequest Request); // 0x000000018136EB70-0x000000018136ED00
		public async Task<CoreWebView2ExecuteScriptResult> ExecuteScriptWithResultAsync(string javaScript); // 0x000000018136E2C0-0x000000018136E3C0
		public void AddWebResourceRequestedFilter(string uri, CoreWebView2WebResourceContext ResourceContext, CoreWebView2WebResourceRequestSourceKinds requestSourceKinds); // 0x000000018136D340-0x000000018136D4D0
		public void RemoveWebResourceRequestedFilter(string uri, CoreWebView2WebResourceContext ResourceContext, CoreWebView2WebResourceRequestSourceKinds requestSourceKinds); // 0x0000000181370730-0x00000001813708D0
		internal void OnSaveAsUIShowing(CoreWebView2SaveAsUIShowingEventArgs args); // 0x000000018136F290-0x000000018136F2C0
		public async Task<CoreWebView2SaveAsUIResult> ShowSaveAsUIAsync(); // 0x00000001813710A0-0x0000000181371170
		internal void OnScreenCaptureStarting(CoreWebView2ScreenCaptureStartingEventArgs args); // 0x000000018136F2F0-0x000000018136F320
		internal void OnSaveFileSecurityCheckStarting(CoreWebView2SaveFileSecurityCheckStartingEventArgs args); // 0x000000018136F2C0-0x000000018136F2F0
		internal void OnNotificationReceived(CoreWebView2NotificationReceivedEventArgs args); // 0x000000018136F200-0x000000018136F230
		public async Task<bool> TrySuspendAsync(); // 0x00000001813712E0-0x00000001813713B0
		public void Resume(); // 0x0000000181370A50-0x0000000181370BC0
		public void SetVirtualHostNameToFolderMapping(string hostName, string folderPath, CoreWebView2HostResourceAccessKind accessKind); // 0x0000000181370BC0-0x0000000181370DC0
		public void ClearVirtualHostNameToFolderMapping(string hostName); // 0x000000018136DA70-0x000000018136DBE0
		internal void OnDedicatedWorkerCreated(CoreWebView2DedicatedWorkerCreatedEventArgs args); // 0x000000018136EF70-0x000000018136EFA0
		internal void OnDownloadStarting(CoreWebView2DownloadStartingEventArgs args); // 0x000000018136EFC0-0x000000018136EFF0
		internal void OnFrameCreated(CoreWebView2FrameCreatedEventArgs args); // 0x000000018136F020-0x000000018136F050
		internal void OnClientCertificateRequested(CoreWebView2ClientCertificateRequestedEventArgs args); // 0x000000018136EEA0-0x000000018136EED0
		public void OpenTaskManagerWindow(); // 0x000000018136F780-0x000000018136F8F0
		public async Task<bool> PrintToPdfAsync(string ResultFilePath, CoreWebView2PrintSettings printSettings = null); // 0x00000001813700C0-0x00000001813701E0
		internal void OnIsDocumentPlayingAudioChanged(object args); // 0x000000018136F0E0-0x000000018136F110
		internal void OnIsMutedChanged(object args); // 0x000000018136F110-0x000000018136F140
		internal void OnIsDefaultDownloadDialogOpenChanged(object args); // 0x000000018136F0B0-0x000000018136F0E0
		public void OpenDefaultDownloadDialog(); // 0x000000018136F4A0-0x000000018136F610
		public void CloseDefaultDownloadDialog(); // 0x000000018136DBE0-0x000000018136DD50
		public static CoreWebView2 CreateFromComICoreWebView2(IntPtr value); // 0x000000018136DD50-0x000000018136E1C0
		public IntPtr GetComICoreWebView2(); // 0x000000018136E3C0-0x000000018136E430
		public void PostWebMessageAsJson(string webMessageAsJson, List<object> additionalObjects); // 0x000000018136FC80-0x000000018136FE50
		public void ShowPrintUI(); // 0x0000000181370DC0-0x0000000181370F30
	}
}
