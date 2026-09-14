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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ContentUpdateWatcher : MonoBehaviour // TypeDefIndex: 1769
{
	// Fields
	private const float CHECK_INTERVAL_SECONDS = 600f; // Metadata: 0x005F1557
	private const float FIRST_CHECK_DELAY = 20f; // Metadata: 0x005F155B
	private const float TICK_SECONDS = 2f; // Metadata: 0x005F155F
	private const string HUB_SCENE = "QuangTruong"; // Metadata: 0x005F1563
	private static readonly string[] BACKGROUND_LABELS; // 0x00
	private static ContentUpdateWatcher _instance; // 0x08
	private static bool _checkRequested; // 0x10
	private bool _busy; // 0x20
	private float _nextCheckAt; // 0x24
	private bool _wasInMatch; // 0x28
	[CompilerGenerated]
	private static bool _IsDownloadingInBackground_k__BackingField; // 0x11

	// Properties
	public static bool IsDownloadingInBackground { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808D9E00-0x00000001808D9E60 0x00000001808D9E60-0x00000001808D9EC0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 1770
	{
		// Fields
		public List<string> pending; // 0x10
		public bool applied; // 0x18

		// Constructors
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunCheck_b__0(List<string> list); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _RunCheck_b__1(bool ok); // 0x00000001808DABD0-0x00000001808DABE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1771
	{
		// Fields
		public bool exists; // 0x10
		public long size; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DownloadInBackground_b__0(bool v); // 0x0000000180290F20-0x0000000180290F30
		internal void _DownloadInBackground_b__1(long v); // 0x00000001808DABE0-0x00000001808DABF0
	}

	[CompilerGenerated]
	private sealed class _ApplyCatalogs_d__21 : IEnumerator<object> // TypeDefIndex: 1772
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<string> catalogs; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<List<IResourceLocator>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyCatalogs_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DABF0-0x00000001808DAC10
		private bool MoveNext(); // 0x00000001808DAC10-0x00000001808DB0C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DB0C0-0x00000001808DB100
	}

	[CompilerGenerated]
	private sealed class _CheckCatalogs_d__20 : IEnumerator<object> // TypeDefIndex: 1773
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<List<string>> done; // 0x20
		private AsyncOperationHandle<List<string>> _h_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckCatalogs_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180676AD0-0x0000000180676AF0
		private bool MoveNext(); // 0x00000001808DB100-0x00000001808DB610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DB610-0x00000001808DB650
	}

	[CompilerGenerated]
	private sealed class _CleanCache_d__22 : IEnumerator<object> // TypeDefIndex: 1774
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<bool> _h_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CleanCache_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DB650-0x00000001808DB670
		private bool MoveNext(); // 0x00000001808DB670-0x00000001808DB9A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DB9A0-0x00000001808DB9E0
	}

	[CompilerGenerated]
	private sealed class _DownloadInBackground_d__23 : IEnumerator<object> // TypeDefIndex: 1775
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DownloadInBackground_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DB9E0-0x00000001808DBAF0
		private bool MoveNext(); // 0x00000001808DBAF0-0x00000001808DC560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DC560-0x00000001808DC5A0
	}

	[CompilerGenerated]
	private sealed class _DownloadSize_d__25 : IEnumerator<object> // TypeDefIndex: 1776
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<long> done; // 0x28
		private AsyncOperationHandle<long> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DownloadSize_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DABF0-0x00000001808DAC10
		private bool MoveNext(); // 0x00000001808DC5A0-0x00000001808DC9A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DC9A0-0x00000001808DC9E0
	}

	[CompilerGenerated]
	private sealed class _LabelExists_d__24 : IEnumerator<object> // TypeDefIndex: 1777
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string label; // 0x20
		public Action<bool> done; // 0x28
		private AsyncOperationHandle<IList<IResourceLocation>> _h_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LabelExists_d__24(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DABF0-0x00000001808DAC10
		private bool MoveNext(); // 0x00000001808DC9E0-0x00000001808DCDA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DCDA0-0x00000001808DCDE0
	}

	[CompilerGenerated]
	private sealed class _RunCheck_d__19 : IEnumerator<object> // TypeDefIndex: 1778
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private __c__DisplayClass19_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunCheck_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001808DCDE0-0x00000001808DD5A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DD5A0-0x00000001808DD5E0
	}

	[CompilerGenerated]
	private sealed class _WatchLoop_d__17 : IEnumerator<object> // TypeDefIndex: 1779
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ContentUpdateWatcher __4__this; // 0x20
		private WaitForSecondsRealtime _tick_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchLoop_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001808DD5E0-0x00000001808DD900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DD900-0x00000001808DD940
	}

	// Constructors
	public ContentUpdateWatcher(); // 0x000000018028A560-0x000000018028A5B0
	static ContentUpdateWatcher(); // 0x00000001808DAA70-0x00000001808DABD0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001808D9EC0-0x00000001808DA0C0
	public static void RequestCheckNow(); // 0x00000001808DA0C0-0x00000001808DA120
	private void Start(); // 0x00000001808DA120-0x00000001808DA210
	[IteratorStateMachine(typeof(_WatchLoop_d__17))]
	private IEnumerator WatchLoop(); // 0x00000001808DA210-0x00000001808DA2B0
	private bool IsSafeMoment(); // 0x00000001808DA2B0-0x00000001808DA490
	[IteratorStateMachine(typeof(_RunCheck_d__19))]
	private IEnumerator RunCheck(); // 0x00000001808DA490-0x00000001808DA530
	[IteratorStateMachine(typeof(_CheckCatalogs_d__20))]
	private IEnumerator CheckCatalogs(Action<List<string>> done); // 0x00000001808DA530-0x00000001808DA5D0
	[IteratorStateMachine(typeof(_ApplyCatalogs_d__21))]
	private IEnumerator ApplyCatalogs(List<string> catalogs, Action<bool> done); // 0x00000001808DA5D0-0x00000001808DA6E0
	[IteratorStateMachine(typeof(_CleanCache_d__22))]
	private IEnumerator CleanCache(); // 0x00000001808DA6E0-0x00000001808DA720
	[IteratorStateMachine(typeof(_DownloadInBackground_d__23))]
	private IEnumerator DownloadInBackground(); // 0x00000001808DA720-0x00000001808DA7C0
	[IteratorStateMachine(typeof(_LabelExists_d__24))]
	private IEnumerator LabelExists(string label, Action<bool> done); // 0x00000001808DA7C0-0x00000001808DA8D0
	[IteratorStateMachine(typeof(_DownloadSize_d__25))]
	private IEnumerator DownloadSize(string label, Action<long> done); // 0x00000001808DA8D0-0x00000001808DA9E0
	private static bool IsWifi(); // 0x00000001808DA9E0-0x00000001808DAA70
}

