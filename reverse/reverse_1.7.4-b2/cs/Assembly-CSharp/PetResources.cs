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

public static class PetResources // TypeDefIndex: 1055
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
	private const int MIN_RESIDENT_PETS = 8; // Metadata: 0x0068C35D
	private const int MAX_ATTEMPTS_PER_PATH = 6; // Metadata: 0x0068C35E
	private static CoroutineRunner _runner; // 0x48
	private static readonly Dictionary<string, List<Action<AnimationClip[]>>> _inFlight; // 0x50
	private static bool _warmStarted; // 0x58

	// Properties
	public static int ResidentCount { get; } // 0x0000000180507230-0x0000000180507290 
	private static CoroutineRunner Runner { get; } // 0x0000000180507290-0x00000001805073D0 

	// Nested types
	private class CoroutineRunner : MonoBehaviour // TypeDefIndex: 1056
	{
		// Constructors
		public CoroutineRunner(); // 0x00000001802EBA70-0x00000001802EBAF0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1057
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<string> __9__18_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180521110-0x0000000180521180
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _TrimResident_b__18_0(string a, string b); // 0x0000000180520DC0-0x0000000180520EA0
	}

	[CompilerGenerated]
	private sealed class _CollectClipsAsync_d__46 : IEnumerator<object> // TypeDefIndex: 1058
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CollectClipsAsync_d__46(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018051F840-0x000000018051F920
		private bool MoveNext(); // 0x000000018051EF00-0x000000018051F800
		private void __m__Finally1(); // 0x000000018051F920-0x000000018051F940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018051F800-0x000000018051F840
	}

	[CompilerGenerated]
	private sealed class _LoadAllAsync_d__45 : IEnumerator<object> // TypeDefIndex: 1059
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string petPath; // 0x20
		public Action<AnimationClip[]> onComplete; // 0x28
		private int[] _counter_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllAsync_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x000000018051F940-0x000000018051FDD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018051FDD0-0x000000018051FE10
	}

	[CompilerGenerated]
	private sealed class _WarmRoutine_d__44 : IEnumerator<object> // TypeDefIndex: 1060
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperationHandle<IResourceLocator> _initHandle_5__2; // 0x20
		private AsyncOperationHandle<IList<IResourceLocation>> _locationsHandle_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WarmRoutine_d__44(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180522660-0x0000000180522680
		private bool MoveNext(); // 0x0000000180522390-0x0000000180522620
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180522620-0x0000000180522660
	}

	// Constructors
	static PetResources(); // 0x0000000180506EC0-0x0000000180507230

	// Methods
	public static T Load<T>(string path)
		where T : UnityEngine.Object;
	public static void Pin(string petPath); // 0x0000000180505F00-0x0000000180505F90
	public static void Unpin(string petPath); // 0x0000000180506D10-0x0000000180506DA0
	private static void Touch(string petPath); // 0x0000000180506800-0x00000001805068A0
	private static void KeepLoaded(string petPath, Dictionary<string, AnimationClip> bucket, string locationKey, AsyncOperationHandle<AnimationClip> handle); // 0x0000000180505650-0x0000000180505860
	private static HashSet<string> ProtectedPaths(); // 0x0000000180505FE0-0x0000000180506780
	public static int TrimResident(int maxResident); // 0x00000001805068A0-0x0000000180506C60
	private static bool EvictOne(string petPath); // 0x00000001805046A0-0x0000000180504B30
	public static void ResetAttempts(); // 0x0000000180506780-0x0000000180506800
	private static Dictionary<string, AnimationClip> LoadedBucket(string petPath); // 0x0000000180505B60-0x0000000180505C80
	private static AnimationClip[] Harvest(string petPath, int expected, out bool complete); // 0x0000000180504D00-0x0000000180504EC0
	private static bool ClearBrokenBundleCacheOnce(string petPath, object key); // 0x0000000180503750-0x0000000180503A10
	private static bool LooksLikeBrokenBundle(Exception ex); // 0x0000000180505C80-0x0000000180505D90
	public static AnimationClip[] LoadAll<T>(string petPath)
		where T : UnityEngine.Object;
	private static int CollectClipsSync(string petPath); // 0x0000000180503DD0-0x00000001805046A0
	private static bool IsOverBudget(string petPath); // 0x00000001805055C0-0x0000000180505650
	private static void NoteFailedAttempt(string petPath); // 0x0000000180505D90-0x0000000180505F00
	private static List<IResourceLocation> ClipLocationsFor(string fullPath); // 0x0000000180503A10-0x0000000180503D40
	private static int IdleFirstRank(IResourceLocation loc); // 0x0000000180504EC0-0x0000000180504FA0
	public static void LoadAllAsyncSafe(string petPath, Action<AnimationClip[]> onComplete); // 0x0000000180505860-0x0000000180505AD0
	private static void FlushWaiters(string petPath, AnimationClip[] arr); // 0x0000000180504B30-0x0000000180504D00
	public static bool TryGetCachedClips(string petPath, out AnimationClip[] clips); // 0x0000000180506C60-0x0000000180506D10
	public static void Prewarm(string petPath); // 0x0000000180505F90-0x0000000180505FE0
	public static void WarmAddressables(); // 0x0000000180506DA0-0x0000000180506E70
	public static void InvalidateCatalogCaches(); // 0x0000000180504FA0-0x00000001805055C0
	[IteratorStateMachine(typeof(_WarmRoutine_d__44))]
	private static IEnumerator WarmRoutine(); // 0x0000000180506E70-0x0000000180506EC0
	[IteratorStateMachine(typeof(_LoadAllAsync_d__45))]
	public static IEnumerator LoadAllAsync(string petPath, Action<AnimationClip[]> onComplete); // 0x0000000180505AD0-0x0000000180505B60
	[IteratorStateMachine(typeof(_CollectClipsAsync_d__46))]
	private static IEnumerator CollectClipsAsync(string petPath, int[] expected); // 0x0000000180503D40-0x0000000180503DD0
}

