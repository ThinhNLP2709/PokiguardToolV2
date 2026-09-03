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
	public class CoreWebView2SharedWorkerManager // TypeDefIndex: 10617
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2SharedWorkerManager _nativeICoreWebView2SharedWorkerManagerValue; // 0x18
		private EventRegistrationToken _SharedWorkerCreatedToken; // 0x20
		private EventHandler<CoreWebView2SharedWorkerCreatedEventArgs> privateSharedWorkerCreated; // 0x28
	
		// Properties
		internal ICoreWebView2SharedWorkerManager _nativeICoreWebView2SharedWorkerManager { get; set; } // 0x00000001813D4C60-0x00000001813D4D70 0x00000001802FAF70-0x00000001802FAF80
	
		// Events
		public event EventHandler<CoreWebView2SharedWorkerCreatedEventArgs> SharedWorkerCreated {
			add; // 0x00000001813D49D0-0x00000001813D4C60
			remove; // 0x00000001813D4D70-0x00000001813D4F70
		}
	
		// Nested types
		[CompilerGenerated]
		private struct _GetSharedWorkersAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10618
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2SharedWorker>> __t__builder; // 0x08
			public CoreWebView2SharedWorkerManager __4__this; // 0x20
			private CoreWebView2GetSharedWorkersCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DD1F0-0x00000001813DD640
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DD640-0x00000001813DD6A0
		}
	
		// Constructors
		internal CoreWebView2SharedWorkerManager(object rawCoreWebView2SharedWorkerManager); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnSharedWorkerCreated(CoreWebView2SharedWorkerCreatedEventArgs args); // 0x000000018136EED0-0x000000018136EEF0
		public async Task<IReadOnlyList<CoreWebView2SharedWorker>> GetSharedWorkersAsync(); // 0x00000001813D4900-0x00000001813D49D0
	}
}
