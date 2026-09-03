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
	public class CoreWebView2BrowserExtension // TypeDefIndex: 10515
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2BrowserExtension _nativeICoreWebView2BrowserExtensionValue; // 0x18
	
		// Properties
		internal ICoreWebView2BrowserExtension _nativeICoreWebView2BrowserExtension { get; set; } // 0x0000000181369A20-0x0000000181369B30 0x00000001802FAF70-0x00000001802FAF80
		public string Id { get; } // 0x0000000181369600-0x0000000181369760 
		public bool IsEnabled { get; } // 0x0000000181369760-0x00000001813698C0 
		public string Name { get; } // 0x00000001813698C0-0x0000000181369A20 
	
		// Nested types
		[CompilerGenerated]
		private struct _EnableAsync_d__14 : IAsyncStateMachine // TypeDefIndex: 10516
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2BrowserExtension __4__this; // 0x20
			public bool IsEnabled; // 0x28
			private CoreWebView2BrowserExtensionEnableCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181381C30-0x0000000181382060
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181382060-0x00000001813820C0
		}
	
		[CompilerGenerated]
		private struct _RemoveAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10517
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2BrowserExtension __4__this; // 0x20
			private CoreWebView2BrowserExtensionRemoveCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181383DE0-0x0000000181384200
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181384200-0x0000000181384260
		}
	
		// Constructors
		internal CoreWebView2BrowserExtension(object rawCoreWebView2BrowserExtension); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public async Task RemoveAsync(); // 0x0000000181369540-0x0000000181369600
		public async Task EnableAsync(bool IsEnabled); // 0x0000000181369460-0x0000000181369540
	}
}
