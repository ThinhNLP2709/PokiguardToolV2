/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Frame // TypeDefIndex: 10559
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Frame _nativeICoreWebView2FrameValue; // 0x18
		private EventRegistrationToken _DestroyedToken; // 0x20
		private EventHandler<object> privateDestroyed; // 0x28
		private EventRegistrationToken _NameChangedToken; // 0x30
		private EventHandler<object> privateNameChanged; // 0x38
		internal ICoreWebView2Frame2 _nativeICoreWebView2Frame2Value; // 0x40
		private EventRegistrationToken _ContentLoadingToken; // 0x48
		private EventHandler<CoreWebView2ContentLoadingEventArgs> privateContentLoading; // 0x50
		private EventRegistrationToken _DOMContentLoadedToken; // 0x58
		private EventHandler<CoreWebView2DOMContentLoadedEventArgs> privateDOMContentLoaded; // 0x60
		private EventRegistrationToken _NavigationCompletedToken; // 0x68
		private EventHandler<CoreWebView2NavigationCompletedEventArgs> privateNavigationCompleted; // 0x70
		private EventRegistrationToken _NavigationStartingToken; // 0x78
		private EventHandler<CoreWebView2NavigationStartingEventArgs> privateNavigationStarting; // 0x80
		private EventRegistrationToken _WebMessageReceivedToken; // 0x88
		private EventHandler<CoreWebView2WebMessageReceivedEventArgs> privateWebMessageReceived; // 0x90
		internal ICoreWebView2Frame3 _nativeICoreWebView2Frame3Value; // 0x98
		private EventRegistrationToken _PermissionRequestedToken; // 0xA0
		private EventHandler<CoreWebView2PermissionRequestedEventArgs> privatePermissionRequested; // 0xA8
		internal ICoreWebView2Frame4 _nativeICoreWebView2Frame4Value; // 0xB0
		internal ICoreWebView2Frame5 _nativeICoreWebView2Frame5Value; // 0xB8
		internal ICoreWebView2Frame6 _nativeICoreWebView2Frame6Value; // 0xC0
		private EventRegistrationToken _ScreenCaptureStartingToken; // 0xC8
		private EventHandler<CoreWebView2ScreenCaptureStartingEventArgs> privateScreenCaptureStarting; // 0xD0
		internal ICoreWebView2Frame7 _nativeICoreWebView2Frame7Value; // 0xD8
		private EventRegistrationToken _FrameCreatedToken; // 0xE0
		private EventHandler<CoreWebView2FrameCreatedEventArgs> privateFrameCreated; // 0xE8
		internal ICoreWebView2Frame8 _nativeICoreWebView2Frame8Value; // 0xF0
		private EventRegistrationToken _DedicatedWorkerCreatedToken; // 0xF8
		private EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> privateDedicatedWorkerCreated; // 0x100
	
		// Properties
		internal ICoreWebView2Frame _nativeICoreWebView2Frame { get; set; } // 0x00000001813AB300-0x00000001813AB410 0x00000001802FAF70-0x00000001802FAF80
		public string Name { get; } // 0x00000001813AA9D0-0x00000001813AAB30 
		internal ICoreWebView2Frame2 _nativeICoreWebView2Frame2 { get; set; } // 0x00000001813AAB30-0x00000001813AAC40 0x0000000180378120-0x0000000180378130
		internal ICoreWebView2Frame3 _nativeICoreWebView2Frame3 { get; set; } // 0x00000001813AAC40-0x00000001813AAD60 0x00000001806CCE20-0x00000001806CCE40
		internal ICoreWebView2Frame4 _nativeICoreWebView2Frame4 { get; set; } // 0x00000001813AAD60-0x00000001813AAE80 0x00000001806C0C00-0x00000001806C0C20
		internal ICoreWebView2Frame5 _nativeICoreWebView2Frame5 { get; set; } // 0x00000001813AAE80-0x00000001813AAFA0 0x00000001806CCDE0-0x00000001806CCE00
		public uint FrameId { get; } // 0x00000001813AA870-0x00000001813AA9D0 
		internal ICoreWebView2Frame6 _nativeICoreWebView2Frame6 { get; set; } // 0x00000001813AAFA0-0x00000001813AB0C0 0x00000001806CCDA0-0x00000001806CCDC0
		internal ICoreWebView2Frame7 _nativeICoreWebView2Frame7 { get; set; } // 0x00000001813AB0C0-0x00000001813AB1E0 0x00000001806CCE00-0x00000001806CCE20
		internal ICoreWebView2Frame8 _nativeICoreWebView2Frame8 { get; set; } // 0x00000001813AB1E0-0x00000001813AB300 0x0000000180CC3C60-0x0000000180CC3C80
	
		// Events
		public event EventHandler<object> Destroyed {
			add; // 0x00000001813A93A0-0x00000001813A9630
			remove; // 0x00000001813ABA30-0x00000001813ABC30
		}
		public event EventHandler<object> NameChanged {
			add; // 0x00000001813A98D0-0x00000001813A9B60
			remove; // 0x00000001813ABE50-0x00000001813AC050
		}
		public event EventHandler<CoreWebView2ContentLoadingEventArgs> ContentLoading {
			add; // 0x00000001813A8BE0-0x00000001813A8E70
			remove; // 0x00000001813AB410-0x00000001813AB610
		}
		public event EventHandler<CoreWebView2DOMContentLoadedEventArgs> DOMContentLoaded {
			add; // 0x00000001813A8E70-0x00000001813A9100
			remove; // 0x00000001813AB610-0x00000001813AB810
		}
		public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted {
			add; // 0x00000001813A9B60-0x00000001813A9DF0
			remove; // 0x00000001813AC050-0x00000001813AC250
		}
		public event EventHandler<CoreWebView2NavigationStartingEventArgs> NavigationStarting {
			add; // 0x00000001813A9DF0-0x00000001813AA090
			remove; // 0x00000001813AC250-0x00000001813AC460
		}
		public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived {
			add; // 0x00000001813AA5D0-0x00000001813AA870
			remove; // 0x00000001813AC8A0-0x00000001813ACAC0
		}
		public event EventHandler<CoreWebView2PermissionRequestedEventArgs> PermissionRequested {
			add; // 0x00000001813AA090-0x00000001813AA330
			remove; // 0x00000001813AC460-0x00000001813AC680
		}
		public event EventHandler<CoreWebView2ScreenCaptureStartingEventArgs> ScreenCaptureStarting {
			add; // 0x00000001813AA330-0x00000001813AA5D0
			remove; // 0x00000001813AC680-0x00000001813AC8A0
		}
		public event EventHandler<CoreWebView2FrameCreatedEventArgs> FrameCreated {
			add; // 0x00000001813A9630-0x00000001813A98D0
			remove; // 0x00000001813ABC30-0x00000001813ABE50
		}
		public event EventHandler<CoreWebView2DedicatedWorkerCreatedEventArgs> DedicatedWorkerCreated {
			add; // 0x00000001813A9100-0x00000001813A93A0
			remove; // 0x00000001813AB810-0x00000001813ABA30
		}
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10560
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<string, string> __9__111_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001813C6FF0-0x00000001813C7060
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _AddHostObjectToScript_b__111_0(string origin); // 0x0000000180A68C50-0x0000000180A68C60
		}
	
		[CompilerGenerated]
		private struct _ExecuteScriptAsync_d__57 : IAsyncStateMachine // TypeDefIndex: 10561
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			public CoreWebView2Frame __4__this; // 0x20
			public string javaScript; // 0x28
			private CoreWebView2ExecuteScriptCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813C62A0-0x00000001813C6760
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813C6760-0x00000001813C67C0
		}
	
		// Constructors
		internal CoreWebView2Frame(object rawCoreWebView2Frame); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnDestroyed(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnNameChanged(object args); // 0x000000018136EEF0-0x000000018136EF10
		public void RemoveHostObjectFromScript(string name); // 0x00000001813A8A70-0x00000001813A8BE0
		public int IsDestroyed(); // 0x00000001813A8320-0x00000001813A8480
		internal void OnContentLoading(CoreWebView2ContentLoadingEventArgs args); // 0x00000001813A8480-0x00000001813A84A0
		internal void OnDOMContentLoaded(CoreWebView2DOMContentLoadedEventArgs args); // 0x00000001813A84A0-0x00000001813A84C0
		internal void OnNavigationCompleted(CoreWebView2NavigationCompletedEventArgs args); // 0x00000001813A84F0-0x00000001813A8510
		internal void OnNavigationStarting(CoreWebView2NavigationStartingEventArgs args); // 0x000000018139ED60-0x000000018139ED90
		internal void OnWebMessageReceived(CoreWebView2WebMessageReceivedEventArgs args); // 0x00000001813A8540-0x00000001813A8570
		public async Task<string> ExecuteScriptAsync(string javaScript); // 0x00000001813A8220-0x00000001813A8320
		public void PostWebMessageAsJson(string webMessageAsJson); // 0x00000001813A8790-0x00000001813A8900
		public void PostWebMessageAsString(string webMessageAsString); // 0x00000001813A8900-0x00000001813A8A70
		internal void OnPermissionRequested(CoreWebView2PermissionRequestedEventArgs args); // 0x000000018136F1D0-0x000000018136F200
		public void PostSharedBufferToScript(CoreWebView2SharedBuffer sharedBuffer, CoreWebView2SharedBufferAccess access, string additionalDataAsJson); // 0x00000001813A8570-0x00000001813A8790
		internal void OnScreenCaptureStarting(CoreWebView2ScreenCaptureStartingEventArgs args); // 0x00000001813A8510-0x00000001813A8540
		internal void OnFrameCreated(CoreWebView2FrameCreatedEventArgs args); // 0x000000018136F380-0x000000018136F3B0
		internal void OnDedicatedWorkerCreated(CoreWebView2DedicatedWorkerCreatedEventArgs args); // 0x00000001813A84C0-0x00000001813A84F0
		public void AddHostObjectToScript(string name, object rawObject, IEnumerable<string> origins); // 0x00000001813A8020-0x00000001813A8220
	}
}
