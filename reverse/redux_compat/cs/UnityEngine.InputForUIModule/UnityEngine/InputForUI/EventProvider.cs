/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal static class EventProvider // TypeDefIndex: 15281
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static IEventProviderImpl s_impl; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static EventSanitizer s_sanitizer; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static IEventProviderImpl s_implMockBackup; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_focusStateBeforeMock; // 0x18
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_focusChangedRegistered; // 0x19
		[AutoStaticsCleanupOnCodeReload]
		private static bool m_IsEnabled; // 0x1A
		[AutoStaticsCleanupOnCodeReload]
		private static bool m_IsInitialized; // 0x1B
		[AutoStaticsCleanupOnCodeReload]
		private static readonly List<Registration> _registrations; // 0x20
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x28
	
		// Nested types
		private struct Registration // TypeDefIndex: 15282
		{
			// Fields
			public EventConsumer handler; // 0x00
			public int priority; // 0x08
			public int? playerId; // 0x0C
			public HashSet<Event.Type> _types; // 0x18
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15283
		{
			// Fields
			public static Action<bool> _0___OnFocusChanged; // 0x00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 15284
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<Registration> __9__7_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001822AC880-0x00000001822AC8F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Subscribe_b__7_0(Registration a, Registration b); // 0x00000001822AC840-0x00000001822AC860
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 15285
		{
			// Fields
			public EventConsumer handler; // 0x10
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _Unsubscribe_b__0(Registration x); // 0x00000001822AC860-0x00000001822AC880
		}
	
		// Constructors
		static EventProvider(); // 0x00000001822A46D0-0x00000001822A48F0
	
		// Methods
		public static void Subscribe(EventConsumer handler, int priority = 0 /* Metadata: 0x006A9F54 */, int? playerId = default, params Event.Type[] type); // 0x00000001822A4150-0x00000001822A4460
		public static void Unsubscribe(EventConsumer handler); // 0x00000001822A4460-0x00000001822A4560
		public static void SetEnabled(bool enable); // 0x00000001822A3ED0-0x00000001822A3F40
		internal static void Dispatch([IsReadOnly] in Event ev); // 0x00000001822A3630-0x00000001822A3970
		private static void Bootstrap(); // 0x00000001822A35D0-0x00000001822A3630
		private static void Initialize(); // 0x00000001822A3970-0x00000001822A3B00
		private static void Shutdown(); // 0x00000001822A3FE0-0x00000001822A4150
		private static void OnFocusChanged(bool focus); // 0x00000001822A3DE0-0x00000001822A3ED0
		[RequiredByNativeCode]
		internal static void NotifyUpdate(); // 0x00000001822A3B00-0x00000001822A3DE0
		internal static void SetInputSystemProvider(IEventProviderImpl impl); // 0x00000001822A3F40-0x00000001822A3FE0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822A4560-0x00000001822A46D0
	}
}
