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

public static class PetResources // TypeDefIndex: 1436
{
	// Fields
	private static IList<IResourceLocation> _cachedPetClipLocations; // 0x00
	private static readonly Dictionary<string, AnimationClip[]> _clipCache; // 0x08
	private static readonly HashSet<string> _rescannedEmptyPaths; // 0x10
	private static readonly Dictionary<string, Dictionary<string, AnimationClip>> _loadedByKey; // 0x18
	private static readonly Dictionary<string, int> _attempts; // 0x20
	private static readonly HashSet<string> _cacheCleared; // 0x28
	private static readonly Dictionary<string, List<AsyncOperationHandle<AnimationClip>>> _handles; // 0x30
	private static readonly Dictionary<string, float> _lastUsed; // 0x38
	private static readonly HashSet<string> _pinned; // 0x40
	private static CoroutineRunner _runner; // 0x48
	private static readonly Dictionary<string, List<Action<AnimationClip[]>>> _inFlight; // 0x50
	private static bool _warmStarted; // 0x58

	// Properties
	private static CoroutineRunner Runner { get; } // 0x00000001807D1B20-0x00000001807D1D40 

	// Nested types
	private class CoroutineRunner : MonoBehaviour // TypeDefIndex: 1437
	{
		// Constructors
		public CoroutineRunner(); // 0x000000018028A560-0x000000018028A5B0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1438
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<string> __9__18_0; // 0x08

		// Constructors
		static __c(); // 0x00000001807D3500-0x00000001807D35A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _TrimResident_b__18_0(string a, string b); // 0x00000001807D35A0-0x00000001807D3750
	}

	[CompilerGenerated]
	private sealed class _CollectClipsAsync_d__46 : IEnumerator<object> // TypeDefIndex: 1439
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int[] expected; // 0x20
		public string petPath; // 0x28
		private string _fullPath_5__2; // 0x30
		private Dictionary<string, AnimationClip> _bucket_5__3; // 0x38
		private bool _overBudget_5__4; // 0x40
		private AsyncOperationHandle<IList<IResourceLocation>> _locationsHandle_5__5; // 0x48
		private List<IResourceLocation> __7__wrap5; // 0x60
		private IResourceLocation _loc_5__7; // 0x78
		private AsyncOperationHandle<AnimationClip> _handle_5__8; // 0x80

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CollectClipsAsync_d__46(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807D3750-0x00000001807D38E0
		private bool MoveNext(); // 0x00000001807D38E0-0x00000001807D4530
		private void __m__Finally1(); // 0x0000000180379490-0x00000001803794A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807D4530-0x00000001807D4570
	}

	[CompilerGenerated]
	private sealed class _LoadAllAsync_d__45 : IEnumerator<object> // TypeDefIndex: 1440
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string petPath; // 0x20
		public Action<AnimationClip[]> onComplete; // 0x28
		private int[] _counter_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllAsync_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001807D4570-0x00000001807D49F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807D49F0-0x00000001807D4A30
	}

	[CompilerGenerated]
	private sealed class _WarmRoutine_d__44 : IEnumerator<object> // TypeDefIndex: 1441
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<IResourceLocator> _initHandle_5__2; // 0x20
		private AsyncOperationHandle<IList<IResourceLocation>> _locationsHandle_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WarmRoutine_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807D4A30-0x00000001807D4A50
		private bool MoveNext(); // 0x00000001807D4A50-0x00000001807D4E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807D4E00-0x00000001807D4E40
	}

	// Constructors
	static PetResources(); // 0x00000001807D2EB0-0x00000001807D3500

	// Methods
	public static T Load<T>(string path)
		where T : UnityEngine.Object;
	private static void Touch(string petPath); // 0x00000001807CDC10-0x00000001807CDD10
	private static void KeepLoaded(string petPath, Dictionary<string, AnimationClip> bucket, string locationKey, AsyncOperationHandle<AnimationClip> handle); // 0x00000001807CDD10-0x00000001807CDFA0
	private static HashSet<string> ProtectedPaths(); // 0x00000001807CDFA0-0x00000001807CEB30
	public static int TrimResident(int maxResident); // 0x00000001807CEB30-0x00000001807CF090
	private static bool EvictOne(string petPath); // 0x00000001807CF090-0x00000001807CF600
	public static void ResetAttempts(); // 0x00000001807CF600-0x00000001807CF690
	private static Dictionary<string, AnimationClip> LoadedBucket(string petPath); // 0x00000001807CF690-0x00000001807CF7F0
	private static AnimationClip[] Harvest(string petPath, int expected, out bool complete); // 0x00000001807CF7F0-0x00000001807CF9E0
	private static bool ClearBrokenBundleCacheOnce(string petPath, object key); // 0x00000001807CF9E0-0x00000001807CFD10
	private static bool LooksLikeBrokenBundle(Exception ex); // 0x00000001807CFD10-0x00000001807D0470
	public static AnimationClip[] LoadAll<T>(string petPath)
		where T : UnityEngine.Object;
	private static int CollectClipsSync(string petPath); // 0x00000001807D0470-0x00000001807D10F0
	private static bool IsOverBudget(string petPath); // 0x00000001807D10F0-0x00000001807D11D0
	private static void NoteFailedAttempt(string petPath); // 0x00000001807D11D0-0x00000001807D13F0
	private static List<IResourceLocation> ClipLocationsFor(string fullPath); // 0x00000001807D13F0-0x00000001807D18A0
	private static int IdleFirstRank(IResourceLocation loc); // 0x00000001807D18A0-0x00000001807D1B20
	public static void LoadAllAsyncSafe(string petPath, Action<AnimationClip[]> onComplete); // 0x00000001807D1D40-0x00000001807D2060
	private static void FlushWaiters(string petPath, AnimationClip[] arr); // 0x00000001807D2060-0x00000001807D2270
	public static bool TryGetCachedClips(string petPath, out AnimationClip[] clips); // 0x00000001807D2270-0x00000001807D2330
	public static void Prewarm(string petPath); // 0x00000001807D2330-0x00000001807D2390
	public static void WarmAddressables(); // 0x00000001807D2390-0x00000001807D2460
	public static void InvalidateCatalogCaches(); // 0x00000001807D2460-0x00000001807D2C50
	[IteratorStateMachine(typeof(_WarmRoutine_d__44))]
	private static IEnumerator WarmRoutine(); // 0x00000001807D2C50-0x00000001807D2C90
	[IteratorStateMachine(typeof(_LoadAllAsync_d__45))]
	public static IEnumerator LoadAllAsync(string petPath, Action<AnimationClip[]> onComplete); // 0x00000001807D2C90-0x00000001807D2DA0
	[IteratorStateMachine(typeof(_CollectClipsAsync_d__46))]
	private static IEnumerator CollectClipsAsync(string petPath, int[] expected); // 0x00000001807D2DA0-0x00000001807D2EB0
}

