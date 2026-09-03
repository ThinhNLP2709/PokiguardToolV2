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

public static class PetResources // TypeDefIndex: 855
{
	// Fields
	private static IList<IResourceLocation> _cachedPetClipLocations; // 0x00
	private static readonly Dictionary<string, AnimationClip[]> _clipCache; // 0x08
	private static readonly HashSet<string> _rescannedEmptyPaths; // 0x10
	private static readonly Dictionary<string, Dictionary<string, AnimationClip>> _loadedByKey; // 0x18
	private static readonly Dictionary<string, int> _attempts; // 0x20
	private static readonly HashSet<string> _cacheCleared; // 0x28
	private const int MAX_ATTEMPTS_PER_PATH = 6; // Metadata: 0x0064CBC8
	private static CoroutineRunner _runner; // 0x30
	private static readonly Dictionary<string, List<Action<AnimationClip[]>>> _inFlight; // 0x38
	private static bool _warmStarted; // 0x40

	// Properties
	private static CoroutineRunner Runner { get; } // 0x000000018043CCB0-0x000000018043CDF0 

	// Nested types
	private class CoroutineRunner : MonoBehaviour // TypeDefIndex: 856
	{
		// Constructors
		public CoroutineRunner(); // 0x00000001802E7A70-0x00000001802E7BC0
	}

	[CompilerGenerated]
	private sealed class _CollectClipsAsync_d__32 : IEnumerator<object> // TypeDefIndex: 857
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CollectClipsAsync_d__32(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180448880-0x0000000180448960
		private bool MoveNext(); // 0x0000000180447FB0-0x0000000180448840
		private void __m__Finally1(); // 0x0000000180448960-0x0000000180448980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180448840-0x0000000180448880
	}

	[CompilerGenerated]
	private sealed class _LoadAllAsync_d__31 : IEnumerator<object> // TypeDefIndex: 858
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string petPath; // 0x20
		public Action<AnimationClip[]> onComplete; // 0x28
		private int[] _counter_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllAsync_d__31(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x0000000180448980-0x0000000180449080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180449080-0x00000001804490C0
	}

	[CompilerGenerated]
	private sealed class _WarmRoutine_d__30 : IEnumerator<object> // TypeDefIndex: 859
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<IResourceLocator> _initHandle_5__2; // 0x20
		private AsyncOperationHandle<IList<IResourceLocation>> _locationsHandle_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WarmRoutine_d__30(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018044B6B0-0x000000018044B6D0
		private bool MoveNext(); // 0x000000018044B3E0-0x000000018044B670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044B670-0x000000018044B6B0
	}

	// Constructors
	static PetResources(); // 0x000000018043CA50-0x000000018043CCB0

	// Methods
	public static T Load<T>(string path)
		where T : UnityEngine.Object;
	public static void ResetAttempts(); // 0x000000018043C820-0x000000018043C8A0
	private static Dictionary<string, AnimationClip> LoadedBucket(string petPath); // 0x000000018043C540-0x000000018043C660
	private static AnimationClip[] Harvest(string petPath, int expected, out bool complete); // 0x000000018043BD90-0x000000018043BF30
	private static void ClearBrokenBundleCacheOnce(string petPath, object key); // 0x000000018043AF50-0x000000018043B1C0
	public static AnimationClip[] LoadAll<T>(string petPath)
		where T : UnityEngine.Object;
	private static int CollectClipsSync(string petPath); // 0x000000018043B580-0x000000018043BBC0
	private static bool IsOverBudget(string petPath); // 0x000000018043C1D0-0x000000018043C260
	private static void NoteFailedAttempt(string petPath); // 0x000000018043C660-0x000000018043C7D0
	private static List<IResourceLocation> ClipLocationsFor(string fullPath); // 0x000000018043B1C0-0x000000018043B4F0
	private static int IdleFirstRank(IResourceLocation loc); // 0x000000018043BF30-0x000000018043C010
	public static void LoadAllAsyncSafe(string petPath, Action<AnimationClip[]> onComplete); // 0x000000018043C260-0x000000018043C4B0
	private static void FlushWaiters(string petPath, AnimationClip[] arr); // 0x000000018043BBC0-0x000000018043BD90
	public static bool TryGetCachedClips(string petPath, out AnimationClip[] clips); // 0x000000018043C8A0-0x000000018043C930
	public static void Prewarm(string petPath); // 0x000000018043C7D0-0x000000018043C820
	public static void WarmAddressables(); // 0x000000018043C930-0x000000018043CA00
	public static void InvalidateCatalogCaches(); // 0x000000018043C010-0x000000018043C1D0
	[IteratorStateMachine(typeof(_WarmRoutine_d__30))]
	private static IEnumerator WarmRoutine(); // 0x000000018043CA00-0x000000018043CA50
	[IteratorStateMachine(typeof(_LoadAllAsync_d__31))]
	public static IEnumerator LoadAllAsync(string petPath, Action<AnimationClip[]> onComplete); // 0x000000018043C4B0-0x000000018043C540
	[IteratorStateMachine(typeof(_CollectClipsAsync_d__32))]
	private static IEnumerator CollectClipsAsync(string petPath, int[] expected); // 0x000000018043B4F0-0x000000018043B580
}

