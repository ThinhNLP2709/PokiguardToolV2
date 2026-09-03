/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Find // TypeDefIndex: 10556
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Find _nativeICoreWebView2FindValue; // 0x18
		private EventRegistrationToken _ActiveMatchIndexChangedToken; // 0x20
		private EventHandler<object> privateActiveMatchIndexChanged; // 0x28
		private EventRegistrationToken _MatchCountChangedToken; // 0x30
		private EventHandler<object> privateMatchCountChanged; // 0x38
	
		// Properties
		internal ICoreWebView2Find _nativeICoreWebView2Find { get; set; } // 0x00000001813A2C80-0x00000001813A2D90 0x00000001802FAF70-0x00000001802FAF80
		public int ActiveMatchIndex { get; } // 0x00000001813A29C0-0x00000001813A2B20 
		public int MatchCount { get; } // 0x00000001813A2B20-0x00000001813A2C80 
	
		// Events
		public event EventHandler<object> ActiveMatchIndexChanged {
			add; // 0x00000001813A24A0-0x00000001813A2730
			remove; // 0x00000001813A2D90-0x00000001813A2F90
		}
		public event EventHandler<object> MatchCountChanged {
			add; // 0x00000001813A2730-0x00000001813A29C0
			remove; // 0x00000001813A2F90-0x00000001813A3190
		}
	
		// Nested types
		[CompilerGenerated]
		private struct _StartAsync_d__23 : IAsyncStateMachine // TypeDefIndex: 10557
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2Find __4__this; // 0x20
			public CoreWebView2FindOptions options; // 0x28
			private CoreWebView2FindStartCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813C67C0-0x00000001813C6C70
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813C6C70-0x00000001813C6CD0
		}
	
		// Constructors
		internal CoreWebView2Find(object rawCoreWebView2Find); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnActiveMatchIndexChanged(object args); // 0x000000018136EED0-0x000000018136EEF0
		internal void OnMatchCountChanged(object args); // 0x000000018136EEF0-0x000000018136EF10
		public async Task StartAsync(CoreWebView2FindOptions options); // 0x00000001813A2240-0x00000001813A2330
		public void FindNext(); // 0x00000001813A1F60-0x00000001813A20D0
		public void FindPrevious(); // 0x00000001813A20D0-0x00000001813A2240
		public void Stop(); // 0x00000001813A2330-0x00000001813A24A0
	}
}
