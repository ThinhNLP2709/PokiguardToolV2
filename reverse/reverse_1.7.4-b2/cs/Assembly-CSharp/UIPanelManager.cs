/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class UIPanelManager : MonoBehaviour // TypeDefIndex: 1433
{
	// Fields
	[CompilerGenerated]
	private static UIPanelManager _Instance_k__BackingField; // 0x00
	private const string PREFAB_ROOT = "UIPanels/"; // Metadata: 0x0068D0BF
	private const string SKIN_SUFFIX = "_Poky"; // Metadata: 0x0068D0C9
	public const string PREF_SKIN_FORCE = "PokySkinForce"; // Metadata: 0x0068D0CF
	private static readonly HashSet<string> LegacyOnlyKeys; // 0x08
	public const string SKIN_ALL_FLAG = "pokyhub.skin.all"; // Metadata: 0x0068D0DD
	public const string SKIN_CDN_FLAG = "pokyhub.skin.cdn"; // Metadata: 0x0068D0EE
	public Transform panelRoot; // 0x20
	private readonly Dictionary<string, GameObject> _cache; // 0x28
	private readonly List<string> _openOrder; // 0x30
	[CompilerGenerated]
	private static Action<string, bool> OnPanelToggled; // 0x10
	private const float ORPHAN_DIM_GRACE = 0.5f; // Metadata: 0x0068D0FF
	private readonly Dictionary<string, float> _orphanSince; // 0x38
	private readonly List<string> _orphanScratch; // 0x40
	private float _lastPruneAt; // 0x48
	private const float PruneIntervalSec = 1f; // Metadata: 0x0068D103

	// Properties
	public static UIPanelManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805D8C60-0x00000001805D8CB0 0x00000001805D8DA0-0x00000001805D8E10
	public bool AnyPanelOpen { get; } // 0x00000001805D8B40-0x00000001805D8C60 

	// Events
	public static event Action<string, bool> OnPanelToggled {
		add; // 0x00000001805D8A50-0x00000001805D8B40
		remove; // 0x00000001805D8CB0-0x00000001805D8DA0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1434
	{
		// Fields
		public GameObject prefab; // 0x10

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadAndOpen_b__0(GameObject p); // 0x0000000180317090-0x00000001803170A0
		internal void _LoadAndOpen_b__1(GameObject p); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class _LoadAndOpen_d__24 : IEnumerator<object> // TypeDefIndex: 1435
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string panelKey; // 0x20
		public UIPanelManager __4__this; // 0x28
		private __c__DisplayClass24_0 __8__1; // 0x30
		public Action<GameObject> onReady; // 0x38
		private Transform _parent_5__2; // 0x40
		private ResourceRequest _skinReq_5__3; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadAndOpen_d__24(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D38F0-0x00000001805D3940
		private bool MoveNext(); // 0x00000001805D2AF0-0x00000001805D38B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D38B0-0x00000001805D38F0
	}

	[CompilerGenerated]
	private sealed class _LoadRemotePrefab_d__25 : IEnumerator<object> // TypeDefIndex: 1436
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string panelKey; // 0x20
		public Action<GameObject> done; // 0x28
		private string _address_5__2; // 0x30
		private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__3; // 0x38
		private AsyncOperationHandle<GameObject> _loadHandle_5__4; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRemotePrefab_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D40B0-0x00000001805D40F0
		private bool MoveNext(); // 0x00000001805D3940-0x00000001805D4070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D4070-0x00000001805D40B0
	}

	// Constructors
	public UIPanelManager(); // 0x00000001805D8910-0x00000001805D8A50
	static UIPanelManager(); // 0x00000001805D86F0-0x00000001805D8910

	// Methods
	public static bool IsLegacyOnly(string panelKey); // 0x00000001805D7070-0x00000001805D7120
	public static bool UseSkin(string panelKey); // 0x00000001805D85C0-0x00000001805D86F0
	public static bool SkinFromCdn(string panelKey); // 0x00000001805D81C0-0x00000001805D82E0
	public static string SkinResourcePath(string panelKey); // 0x00000001805D82E0-0x00000001805D8330
	private static void RaiseToggled(string panelKey, bool open); // 0x00000001805D7D70-0x00000001805D7E60
	public static UIPanelManager EnsureInstance(); // 0x00000001805D6CE0-0x00000001805D6E60
	private void Awake(); // 0x00000001805D6980-0x00000001805D6B30
	public void Open(string panelKey, Action<GameObject> onReady = null, Transform parent = null); // 0x00000001805D7850-0x00000001805D7A50
	[IteratorStateMachine(typeof(_LoadAndOpen_d__24))]
	private IEnumerator LoadAndOpen(string panelKey, Action<GameObject> onReady); // 0x00000001805D7710-0x00000001805D77C0
	[IteratorStateMachine(typeof(_LoadRemotePrefab_d__25))]
	private IEnumerator LoadRemotePrefab(string panelKey, Action<GameObject> done); // 0x00000001805D77C0-0x00000001805D7850
	private static bool HasMissingScript(GameObject root); // 0x00000001805D6F90-0x00000001805D7070
	public void Close(string panelKey, bool destroy = false /* Metadata: 0x0068D0BE */); // 0x00000001805D6B80-0x00000001805D6CE0
	private void LateUpdate(); // 0x00000001805D71E0-0x00000001805D7710
	private void PruneDeadEntries(); // 0x00000001805D7A50-0x00000001805D7D70
	public bool CloseTop(); // 0x00000001805D6B30-0x00000001805D6B80
	public bool IsOpen(string panelKey); // 0x00000001805D7120-0x00000001805D71E0
	public void UnloadAll(); // 0x00000001805D8400-0x00000001805D85C0
	private Transform ResolvePanelRoot(); // 0x00000001805D7E60-0x00000001805D81C0
	public static Transform FindDeep(Transform root, string name); // 0x00000001805D6E60-0x00000001805D6F90
	private void TrackOpen(string panelKey); // 0x00000001805D8330-0x00000001805D8400
}

