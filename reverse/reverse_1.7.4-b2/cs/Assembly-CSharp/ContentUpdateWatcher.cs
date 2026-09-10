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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ContentUpdateWatcher : MonoBehaviour // TypeDefIndex: 1385
{
	// Fields
	private const float CHECK_INTERVAL_SECONDS = 600f; // Metadata: 0x0068CF5F
	private const float FIRST_CHECK_DELAY = 20f; // Metadata: 0x0068CF63
	private const float TICK_SECONDS = 2f; // Metadata: 0x0068CF67
	private const string HUB_SCENE = "QuangTruong"; // Metadata: 0x0068CF6B
	private static readonly string[] BACKGROUND_LABELS; // 0x00
	private static ContentUpdateWatcher _instance; // 0x08
	private static bool _checkRequested; // 0x10
	private bool _busy; // 0x20
	private float _nextCheckAt; // 0x24
	private bool _wasInMatch; // 0x28
	[CompilerGenerated]
	private static bool _IsDownloadingInBackground_k__BackingField; // 0x11

	// Properties
	public static bool IsDownloadingInBackground { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805AACC0-0x00000001805AAD10 0x00000001805AAD10-0x00000001805AAD70

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1386
	{
		// Fields
		public List<string> pending; // 0x10
		public bool applied; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RunCheck_b__0(List<string> list); // 0x0000000180317090-0x00000001803170A0
		internal void _RunCheck_b__1(bool ok); // 0x00000001805BE090-0x00000001805BE0A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1387
	{
		// Fields
		public bool exists; // 0x10
		public long size; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DownloadInBackground_b__0(bool v); // 0x0000000180300940-0x0000000180300950
		internal void _DownloadInBackground_b__1(long v); // 0x00000001805BE0A0-0x00000001805BE0B0
	}

	[CompilerGenerated]
	private sealed class _ApplyCatalogs_d__21 : IEnumerator<object> // TypeDefIndex: 1388
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<string> catalogs; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<List<IResourceLocator>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCatalogs_d__21(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B5A70-0x00000001805B5A90
		private bool MoveNext(); // 0x00000001805B56D0-0x00000001805B5A30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B5A30-0x00000001805B5A70
	}

	[CompilerGenerated]
	private sealed class _CheckCatalogs_d__20 : IEnumerator<object> // TypeDefIndex: 1389
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<List<string>> done; // 0x20
		private AsyncOperationHandle<List<string>> _h_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckCatalogs_d__20(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AA250-0x00000001804AA270
		private bool MoveNext(); // 0x00000001805B5A90-0x00000001805B5E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B5E50-0x00000001805B5E90
	}

	[CompilerGenerated]
	private sealed class _CleanCache_d__22 : IEnumerator<object> // TypeDefIndex: 1390
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<bool> _h_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CleanCache_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B6480-0x00000001805B64A0
		private bool MoveNext(); // 0x00000001805B6230-0x00000001805B6440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B6440-0x00000001805B6480
	}

	[CompilerGenerated]
	private sealed class _DownloadInBackground_d__23 : IEnumerator<object> // TypeDefIndex: 1391
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DownloadInBackground_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B6BC0-0x00000001805B6C20
		private bool MoveNext(); // 0x00000001805B64A0-0x00000001805B6B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B6B80-0x00000001805B6BC0
	}

	[CompilerGenerated]
	private sealed class _DownloadSize_d__25 : IEnumerator<object> // TypeDefIndex: 1392
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<long> done; // 0x28
		private AsyncOperationHandle<long> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DownloadSize_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B5A70-0x00000001805B5A90
		private bool MoveNext(); // 0x00000001805B6C20-0x00000001805B6E60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B6E60-0x00000001805B6EA0
	}

	[CompilerGenerated]
	private sealed class _LabelExists_d__24 : IEnumerator<object> // TypeDefIndex: 1393
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<IList<IResourceLocation>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LabelExists_d__24(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B5A70-0x00000001805B5A90
		private bool MoveNext(); // 0x00000001805B84A0-0x00000001805B8720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B8720-0x00000001805B8760
	}

	[CompilerGenerated]
	private sealed class _RunCheck_d__19 : IEnumerator<object> // TypeDefIndex: 1394
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private __c__DisplayClass19_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunCheck_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805BD240-0x00000001805BD890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BD890-0x00000001805BD8D0
	}

	[CompilerGenerated]
	private sealed class _WatchLoop_d__17 : IEnumerator<object> // TypeDefIndex: 1395
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private WaitForSecondsRealtime _tick_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchLoop_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805BEBC0-0x00000001805BEDF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BEDF0-0x00000001805BF650
	}

	// Constructors
	public ContentUpdateWatcher(); // 0x00000001802EBA70-0x00000001802EBAF0
	static ContentUpdateWatcher(); // 0x00000001805AABA0-0x00000001805AACC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001805AA530-0x00000001805AA650
	public static void RequestCheckNow(); // 0x00000001805AA9E0-0x00000001805AAA30
	private void Start(); // 0x00000001805AAAA0-0x00000001805AAB30
	[IteratorStateMachine(typeof(_WatchLoop_d__17))]
	private IEnumerator WatchLoop(); // 0x00000001805AAB30-0x00000001805AABA0
	private bool IsSafeMoment(); // 0x00000001805AA810-0x00000001805AA900
	[IteratorStateMachine(typeof(_RunCheck_d__19))]
	private IEnumerator RunCheck(); // 0x00000001805AAA30-0x00000001805AAAA0
	[IteratorStateMachine(typeof(_CheckCatalogs_d__20))]
	private IEnumerator CheckCatalogs(Action<List<string>> done); // 0x00000001805AA650-0x00000001805AA6C0
	[IteratorStateMachine(typeof(_ApplyCatalogs_d__21))]
	private IEnumerator ApplyCatalogs(List<string> catalogs, Action<bool> done); // 0x00000001805AA4A0-0x00000001805AA530
	[IteratorStateMachine(typeof(_CleanCache_d__22))]
	private IEnumerator CleanCache(); // 0x00000001805AA6C0-0x00000001805AA710
	[IteratorStateMachine(typeof(_DownloadInBackground_d__23))]
	private IEnumerator DownloadInBackground(); // 0x00000001805AA710-0x00000001805AA780
	[IteratorStateMachine(typeof(_LabelExists_d__24))]
	private IEnumerator LabelExists(string label, Action<bool> done); // 0x00000001805AA950-0x00000001805AA9E0
	[IteratorStateMachine(typeof(_DownloadSize_d__25))]
	private IEnumerator DownloadSize(string label, Action<long> done); // 0x00000001805AA780-0x00000001805AA810
	private static bool IsWifi(); // 0x00000001805AA900-0x00000001805AA950
}

