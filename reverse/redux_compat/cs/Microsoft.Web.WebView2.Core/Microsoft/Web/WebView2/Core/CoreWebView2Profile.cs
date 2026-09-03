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
	public class CoreWebView2Profile // TypeDefIndex: 10590
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Profile _nativeICoreWebView2ProfileValue; // 0x18
		internal ICoreWebView2Profile9 _nativeICoreWebView2Profile9Value; // 0x20
		internal ICoreWebView2Profile2 _nativeICoreWebView2Profile2Value; // 0x28
		internal ICoreWebView2Profile3 _nativeICoreWebView2Profile3Value; // 0x30
		internal ICoreWebView2Profile4 _nativeICoreWebView2Profile4Value; // 0x38
		internal ICoreWebView2Profile5 _nativeICoreWebView2Profile5Value; // 0x40
		internal ICoreWebView2Profile6 _nativeICoreWebView2Profile6Value; // 0x48
		internal ICoreWebView2Profile7 _nativeICoreWebView2Profile7Value; // 0x50
		internal ICoreWebView2Profile8 _nativeICoreWebView2Profile8Value; // 0x58
		private EventRegistrationToken _DeletedToken; // 0x60
		private EventHandler<object> privateDeleted; // 0x68
		private const int UI_E_WRONG_THREAD = -2147417842; // Metadata: 0x006A150F
		private const int RPC_E_WRONG_THREAD = -2147019873; // Metadata: 0x006A1514
	
		// Properties
		internal ICoreWebView2Profile _nativeICoreWebView2Profile { get; set; } // 0x00000001813C4D20-0x00000001813C4E30 0x00000001802FAF70-0x00000001802FAF80
		public string DefaultDownloadFolderPath { get; set; } // 0x00000001813C3620-0x00000001813C3780 0x00000001813C51A0-0x00000001813C5310
		public bool IsInPrivateModeEnabled { get; } // 0x00000001813C38E0-0x00000001813C3A40 
		public CoreWebView2PreferredColorScheme PreferredColorScheme { get; set; } // 0x00000001813C3BA0-0x00000001813C3D00 0x00000001813C55F0-0x00000001813C5760
		public string ProfileName { get; } // 0x00000001813C3E60-0x00000001813C3FC0 
		public string ProfilePath { get; } // 0x00000001813C3FC0-0x00000001813C4120 
		internal ICoreWebView2Profile9 _nativeICoreWebView2Profile9 { get; set; } // 0x00000001813C4C10-0x00000001813C4D20 0x000000018033E830-0x000000018033E840
		public bool AreWebViewScriptApisEnabledForServiceWorkers { get; set; } // 0x00000001813C3300-0x00000001813C3460 0x00000001813C5030-0x00000001813C51A0
		public CoreWebView2ServiceWorkerManager ServiceWorkerManager { get; } // 0x00000001813C4120-0x00000001813C42E0 
		public CoreWebView2SharedWorkerManager SharedWorkerManager { get; } // 0x00000001813C42E0-0x00000001813C44A0 
		internal ICoreWebView2Profile2 _nativeICoreWebView2Profile2 { get; set; } // 0x00000001813C44A0-0x00000001813C45B0 0x000000018033E840-0x000000018033E850
		internal ICoreWebView2Profile3 _nativeICoreWebView2Profile3 { get; set; } // 0x00000001813C45B0-0x00000001813C46C0 0x0000000180378110-0x0000000180378120
		public CoreWebView2TrackingPreventionLevel PreferredTrackingPreventionLevel { get; set; } // 0x00000001813C3D00-0x00000001813C3E60 0x00000001813C5760-0x00000001813C58D0
		internal ICoreWebView2Profile4 _nativeICoreWebView2Profile4 { get; set; } // 0x00000001813C46C0-0x00000001813C47D0 0x000000018033E850-0x000000018033E860
		internal ICoreWebView2Profile5 _nativeICoreWebView2Profile5 { get; set; } // 0x00000001813C47D0-0x00000001813C48E0 0x0000000180378120-0x0000000180378130
		public CoreWebView2CookieManager CookieManager { get; } // 0x00000001813C3460-0x00000001813C3620 
		internal ICoreWebView2Profile6 _nativeICoreWebView2Profile6 { get; set; } // 0x00000001813C48E0-0x00000001813C49F0 0x00000001803780C0-0x00000001803780D0
		public bool IsGeneralAutofillEnabled { get; set; } // 0x00000001813C3780-0x00000001813C38E0 0x00000001813C5310-0x00000001813C5480
		public bool IsPasswordAutosaveEnabled { get; set; } // 0x00000001813C3A40-0x00000001813C3BA0 0x00000001813C5480-0x00000001813C55F0
		internal ICoreWebView2Profile7 _nativeICoreWebView2Profile7 { get; set; } // 0x00000001813C49F0-0x00000001813C4B00 0x00000001806CCE80-0x00000001806CCE90
		internal ICoreWebView2Profile8 _nativeICoreWebView2Profile8 { get; set; } // 0x00000001813C4B00-0x00000001813C4C10 0x00000001802F4050-0x00000001802F4060
	
		// Events
		public event EventHandler<object> Deleted {
			add; // 0x00000001813C3070-0x00000001813C3300
			remove; // 0x00000001813C4E30-0x00000001813C5030
		}
	
		// Nested types
		[CompilerGenerated]
		private struct _AddBrowserExtensionAsync_d__69 : IAsyncStateMachine // TypeDefIndex: 10591
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2BrowserExtension> __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			public string extensionFolderPath; // 0x28
			private CoreWebView2ProfileAddBrowserExtensionCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813DA700-0x00000001813DAB60
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DAB60-0x00000001813DABC0
		}
	
		[CompilerGenerated]
		private struct _ClearBrowsingDataAsync_d__34 : IAsyncStateMachine // TypeDefIndex: 10592
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			public CoreWebView2BrowsingDataKinds dataKinds; // 0x28
			private CoreWebView2ClearBrowsingDataCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813DABC0-0x00000001813DB030
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DB030-0x00000001813DB090
		}
	
		[CompilerGenerated]
		private struct _ClearBrowsingDataAsync_d__35 : IAsyncStateMachine // TypeDefIndex: 10593
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			private CoreWebView2ClearBrowsingDataCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DB090-0x00000001813DB490
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DB490-0x00000001813DB4F0
		}
	
		[CompilerGenerated]
		private struct _ClearBrowsingDataAsync_d__84 : IAsyncStateMachine // TypeDefIndex: 10594
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public DateTime startTime; // 0x20
			public DateTime endTime; // 0x28
			public CoreWebView2Profile __4__this; // 0x30
			public CoreWebView2BrowsingDataKinds dataKinds; // 0x38
			private CoreWebView2ClearBrowsingDataCompletedHandler _handler_5__2; // 0x40
			private object __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001813DB4F0-0x00000001813DBA30
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DBA30-0x00000001813DBA90
		}
	
		[CompilerGenerated]
		private struct _GetBrowserExtensionsAsync_d__70 : IAsyncStateMachine // TypeDefIndex: 10595
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2BrowserExtension>> __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			private CoreWebView2ProfileGetBrowserExtensionsCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DBA90-0x00000001813DBEE0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DBEE0-0x00000001813DBF40
		}
	
		[CompilerGenerated]
		private struct _GetNonDefaultPermissionSettingsAsync_d__48 : IAsyncStateMachine // TypeDefIndex: 10596
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2PermissionSetting>> __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			private CoreWebView2GetNonDefaultPermissionSettingsCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DC3F0-0x00000001813DC820
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DC820-0x00000001813DC880
		}
	
		[CompilerGenerated]
		private struct _SetPermissionStateAsync_d__47 : IAsyncStateMachine // TypeDefIndex: 10597
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CoreWebView2Profile __4__this; // 0x20
			public CoreWebView2PermissionKind PermissionKind; // 0x28
			public string origin; // 0x30
			public CoreWebView2PermissionState State; // 0x38
			private CoreWebView2SetPermissionStateCompletedHandler _handler_5__2; // 0x40
			private object __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001813DD6A0-0x00000001813DDB20
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DDB20-0x00000001813DDB80
		}
	
		// Constructors
		internal CoreWebView2Profile(object rawCoreWebView2Profile); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public async Task ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds dataKinds); // 0x00000001813C29B0-0x00000001813C2A90
		public async Task ClearBrowsingDataAsync(); // 0x00000001813C2B90-0x00000001813C2C50
		public async Task SetPermissionStateAsync(CoreWebView2PermissionKind PermissionKind, string origin, CoreWebView2PermissionState State); // 0x00000001813C2F60-0x00000001813C3070
		public async Task<IReadOnlyList<CoreWebView2PermissionSetting>> GetNonDefaultPermissionSettingsAsync(); // 0x00000001813C2E90-0x00000001813C2F60
		public async Task<CoreWebView2BrowserExtension> AddBrowserExtensionAsync(string extensionFolderPath); // 0x00000001813C28B0-0x00000001813C29B0
		public async Task<IReadOnlyList<CoreWebView2BrowserExtension>> GetBrowserExtensionsAsync(); // 0x00000001813C2DC0-0x00000001813C2E90
		internal void OnDeleted(object args); // 0x000000018136F070-0x000000018136F090
		public void Delete(); // 0x00000001813C2C50-0x00000001813C2DC0
		public async Task ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds dataKinds, DateTime startTime, DateTime endTime); // 0x00000001813C2A90-0x00000001813C2B90
	}
}
