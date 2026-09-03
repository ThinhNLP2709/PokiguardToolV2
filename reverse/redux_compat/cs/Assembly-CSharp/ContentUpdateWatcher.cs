/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ContentUpdateWatcher : MonoBehaviour // TypeDefIndex: 1169
{
	// Fields
	private const float CHECK_INTERVAL_SECONDS = 600f; // Metadata: 0x0064D402
	private const float FIRST_CHECK_DELAY = 20f; // Metadata: 0x0064D406
	private const float TICK_SECONDS = 2f; // Metadata: 0x0064D40A
	private const string HUB_SCENE = "QuangTruong"; // Metadata: 0x0064D40E
	private static readonly string[] BACKGROUND_LABELS; // 0x00
	private static ContentUpdateWatcher _instance; // 0x08
	private static bool _checkRequested; // 0x10
	private bool _busy; // 0x20
	private float _nextCheckAt; // 0x24
	private bool _wasInMatch; // 0x28
	[CompilerGenerated]
	private static bool _IsDownloadingInBackground_k__BackingField; // 0x11

	// Properties
	public static bool IsDownloadingInBackground { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AF4A0-0x00000001804AF4F0 0x00000001804AF4F0-0x00000001804AF550

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1170
	{
		// Fields
		public List<string> pending; // 0x10
		public bool applied; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RunCheck_b__0(List<string> list); // 0x00000001803780D0-0x00000001803780E0
		internal void _RunCheck_b__1(bool ok); // 0x00000001804C2E10-0x00000001804C2E20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1171
	{
		// Fields
		public bool exists; // 0x10
		public long size; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DownloadInBackground_b__0(bool v); // 0x00000001804C2E20-0x00000001804C2E30
		internal void _DownloadInBackground_b__1(long v); // 0x00000001804C2E30-0x00000001804C2E40
	}

	[CompilerGenerated]
	private sealed class _ApplyCatalogs_d__21 : IEnumerator<object> // TypeDefIndex: 1172
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<string> catalogs; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<List<IResourceLocator>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCatalogs_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804B9F50-0x00000001804B9F70
		private bool MoveNext(); // 0x00000001804B9BB0-0x00000001804B9F10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804B9F10-0x00000001804B9F50
	}

	[CompilerGenerated]
	private sealed class _CheckCatalogs_d__20 : IEnumerator<object> // TypeDefIndex: 1173
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<List<string>> done; // 0x20
		private AsyncOperationHandle<List<string>> _h_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckCatalogs_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BCF20-0x00000001803BCF40
		private bool MoveNext(); // 0x00000001804B9F70-0x00000001804BA330
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BA330-0x00000001804BA370
	}

	[CompilerGenerated]
	private sealed class _CleanCache_d__22 : IEnumerator<object> // TypeDefIndex: 1174
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<bool> _h_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CleanCache_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BA960-0x00000001804BA980
		private bool MoveNext(); // 0x00000001804BA710-0x00000001804BA920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BA920-0x00000001804BA960
	}

	[CompilerGenerated]
	private sealed class _DownloadInBackground_d__23 : IEnumerator<object> // TypeDefIndex: 1175
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28
		private string[] __7__wrap1; // 0x30
		private int __7__wrap2; // 0x38
		private string _label_5__4; // 0x40
		private AsyncOperationHandle _h_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DownloadInBackground_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BB1A0-0x00000001804BB200
		private bool MoveNext(); // 0x00000001804BAA80-0x00000001804BB160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BB160-0x00000001804BB1A0
	}

	[CompilerGenerated]
	private sealed class _DownloadSize_d__25 : IEnumerator<object> // TypeDefIndex: 1176
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<long> done; // 0x28
		private AsyncOperationHandle<long> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DownloadSize_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804B9F50-0x00000001804B9F70
		private bool MoveNext(); // 0x00000001804BB200-0x00000001804BB440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BB440-0x00000001804BB480
	}

	[CompilerGenerated]
	private sealed class _LabelExists_d__24 : IEnumerator<object> // TypeDefIndex: 1177
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<IList<IResourceLocation>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LabelExists_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804B9F50-0x00000001804B9F70
		private bool MoveNext(); // 0x00000001804BD250-0x00000001804BD4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BD4D0-0x00000001804BD510
	}

	[CompilerGenerated]
	private sealed class _RunCheck_d__19 : IEnumerator<object> // TypeDefIndex: 1178
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private __c__DisplayClass19_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunCheck_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804C1B30-0x00000001804C2180
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C2180-0x00000001804C21C0
	}

	[CompilerGenerated]
	private sealed class _WatchLoop_d__17 : IEnumerator<object> // TypeDefIndex: 1179
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private WaitForSecondsRealtime _tick_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchLoop_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804C31A0-0x00000001804C33D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C33D0-0x00000001804C39F0
	}

	// Constructors
	public ContentUpdateWatcher(); // 0x00000001802E7A70-0x00000001802E7BC0
	static ContentUpdateWatcher(); // 0x00000001804AF380-0x00000001804AF4A0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001804AED10-0x00000001804AEE30
	public static void RequestCheckNow(); // 0x00000001804AF1C0-0x00000001804AF210
	private void Start(); // 0x00000001804AF280-0x00000001804AF310
	[IteratorStateMachine(typeof(_WatchLoop_d__17))]
	private IEnumerator WatchLoop(); // 0x00000001804AF310-0x00000001804AF380
	private bool IsSafeMoment(); // 0x00000001804AEFF0-0x00000001804AF0E0
	[IteratorStateMachine(typeof(_RunCheck_d__19))]
	private IEnumerator RunCheck(); // 0x00000001804AF210-0x00000001804AF280
	[IteratorStateMachine(typeof(_CheckCatalogs_d__20))]
	private IEnumerator CheckCatalogs(Action<List<string>> done); // 0x00000001804AEE30-0x00000001804AEEA0
	[IteratorStateMachine(typeof(_ApplyCatalogs_d__21))]
	private IEnumerator ApplyCatalogs(List<string> catalogs, Action<bool> done); // 0x00000001804AEC80-0x00000001804AED10
	[IteratorStateMachine(typeof(_CleanCache_d__22))]
	private IEnumerator CleanCache(); // 0x00000001804AEEA0-0x00000001804AEEF0
	[IteratorStateMachine(typeof(_DownloadInBackground_d__23))]
	private IEnumerator DownloadInBackground(); // 0x00000001804AEEF0-0x00000001804AEF60
	[IteratorStateMachine(typeof(_LabelExists_d__24))]
	private IEnumerator LabelExists(string label, Action<bool> done); // 0x00000001804AF130-0x00000001804AF1C0
	[IteratorStateMachine(typeof(_DownloadSize_d__25))]
	private IEnumerator DownloadSize(string label, Action<long> done); // 0x00000001804AEF60-0x00000001804AEFF0
	private static bool IsWifi(); // 0x00000001804AF0E0-0x00000001804AF130
}

