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
	public class CoreWebView2ServiceWorkerManager // TypeDefIndex: 10607
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ServiceWorkerManager _nativeICoreWebView2ServiceWorkerManagerValue; // 0x18
		private EventRegistrationToken _ServiceWorkerRegisteredToken; // 0x20
		private EventHandler<CoreWebView2ServiceWorkerRegisteredEventArgs> privateServiceWorkerRegistered; // 0x28
	
		// Properties
		internal ICoreWebView2ServiceWorkerManager _nativeICoreWebView2ServiceWorkerManager { get; set; } // 0x00000001813CDBB0-0x00000001813CDCC0 0x00000001802FAF70-0x00000001802FAF80
	
		// Events
		public event EventHandler<CoreWebView2ServiceWorkerRegisteredEventArgs> ServiceWorkerRegistered {
			add; // 0x00000001813CD920-0x00000001813CDBB0
			remove; // 0x00000001813CDCC0-0x00000001813CDEC0
		}
	
		// Nested types
		[CompilerGenerated]
		private struct _GetServiceWorkerRegistrationsAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10608
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2ServiceWorkerRegistration>> __t__builder; // 0x08
			public CoreWebView2ServiceWorkerManager __4__this; // 0x20
			private CoreWebView2GetServiceWorkerRegistrationsCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DC880-0x00000001813DCCD0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DCCD0-0x00000001813DCD30
		}
	
		[CompilerGenerated]
		private struct _GetServiceWorkerRegistrationsAsync_d__14 : IAsyncStateMachine // TypeDefIndex: 10609
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2ServiceWorkerRegistration>> __t__builder; // 0x08
			public CoreWebView2ServiceWorkerManager __4__this; // 0x20
			public string scope; // 0x28
			private CoreWebView2GetServiceWorkerRegistrationsCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813DCD30-0x00000001813DD190
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DD190-0x00000001813DD1F0
		}
	
		// Constructors
		internal CoreWebView2ServiceWorkerManager(object rawCoreWebView2ServiceWorkerManager); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnServiceWorkerRegistered(CoreWebView2ServiceWorkerRegisteredEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
		public async Task<IReadOnlyList<CoreWebView2ServiceWorkerRegistration>> GetServiceWorkerRegistrationsAsync(); // 0x00000001813CD750-0x00000001813CD820
		public async Task<IReadOnlyList<CoreWebView2ServiceWorkerRegistration>> GetServiceWorkerRegistrationsAsync(string scope); // 0x00000001813CD820-0x00000001813CD920
	}
}
