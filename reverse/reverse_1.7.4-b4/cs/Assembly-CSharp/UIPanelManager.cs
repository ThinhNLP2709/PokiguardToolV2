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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class UIPanelManager : MonoBehaviour // TypeDefIndex: 1818
{
	// Fields
	[CompilerGenerated]
	private static UIPanelManager _Instance_k__BackingField; // 0x00
	private const string PREFAB_ROOT = "UIPanels/"; // Metadata: 0x005F15BA
	private const string SKIN_SUFFIX = "_Poky"; // Metadata: 0x005F15C4
	public const string PREF_SKIN_FORCE = "PokySkinForce"; // Metadata: 0x005F15CA
	private static readonly HashSet<string> LegacyOnlyKeys; // 0x08
	public const string SKIN_ALL_FLAG = "pokyhub.skin.all"; // Metadata: 0x005F15D8
	public const string SKIN_CDN_FLAG = "pokyhub.skin.cdn"; // Metadata: 0x005F15E9
	public Transform panelRoot; // 0x20
	private readonly Dictionary<string, GameObject> _cache; // 0x28
	private readonly List<string> _openOrder; // 0x30
	[CompilerGenerated]
	private static Action<string, bool> OnPanelToggled; // 0x10
	private const float ORPHAN_DIM_GRACE = 0.5f; // Metadata: 0x005F15FA
	private readonly Dictionary<string, float> _orphanSince; // 0x38
	private readonly List<string> _orphanScratch; // 0x40
	private float _lastPruneAt; // 0x48
	private const float PruneIntervalSec = 1f; // Metadata: 0x005F15FE

	// Properties
	public static UIPanelManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808F1290-0x00000001808F12F0 0x00000001808F12F0-0x00000001808F13A0
	public bool AnyPanelOpen { get; } // 0x00000001808F3990-0x00000001808F3B80 

	// Events
	public static event Action<string, bool> OnPanelToggled {
		add; // 0x00000001808F1740-0x00000001808F1890
		remove; // 0x00000001808F1890-0x00000001808F19E0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1819
	{
		// Fields
		public GameObject prefab; // 0x10

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadAndOpen_b__0(GameObject p); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _LoadAndOpen_b__1(GameObject p); // 0x00000001802D8AB0-0x00000001802D8B10
	}

	[CompilerGenerated]
	private sealed class _LoadAndOpen_d__24 : IEnumerator<object> // TypeDefIndex: 1820
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadAndOpen_d__24(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808F4EA0-0x00000001808F4FB0
		private bool MoveNext(); // 0x00000001808F4FB0-0x00000001808F60C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F60C0-0x00000001808F6100
	}

	[CompilerGenerated]
	private sealed class _LoadRemotePrefab_d__25 : IEnumerator<object> // TypeDefIndex: 1821
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRemotePrefab_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808F6100-0x00000001808F6180
		private bool MoveNext(); // 0x00000001808F6180-0x00000001808F6A30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F6A30-0x00000001808F6A70
	}

	// Constructors
	public UIPanelManager(); // 0x00000001808F48F0-0x00000001808F4B90
	static UIPanelManager(); // 0x00000001808F4B90-0x00000001808F4EA0

	// Methods
	public static bool IsLegacyOnly(string panelKey); // 0x00000001808F13A0-0x00000001808F1460
	public static bool UseSkin(string panelKey); // 0x00000001808F1460-0x00000001808F15B0
	public static bool SkinFromCdn(string panelKey); // 0x00000001808F15B0-0x00000001808F16E0
	public static string SkinResourcePath(string panelKey); // 0x00000001808F16E0-0x00000001808F1740
	private static void RaiseToggled(string panelKey, bool open); // 0x00000001808F19E0-0x00000001808F1AE0
	public static UIPanelManager EnsureInstance(); // 0x00000001808F1AE0-0x00000001808F1CC0
	private void Awake(); // 0x00000001808F1CC0-0x00000001808F1F30
	public void Open(string panelKey, Action<GameObject> onReady = null, Transform parent = null); // 0x00000001808F1F30-0x00000001808F2490
	[IteratorStateMachine(typeof(_LoadAndOpen_d__24))]
	private IEnumerator LoadAndOpen(string panelKey, Action<GameObject> onReady); // 0x00000001808F2490-0x00000001808F25F0
	[IteratorStateMachine(typeof(_LoadRemotePrefab_d__25))]
	private IEnumerator LoadRemotePrefab(string panelKey, Action<GameObject> done); // 0x00000001808F25F0-0x00000001808F2700
	private static bool HasMissingScript(GameObject root); // 0x00000001808F2700-0x00000001808F2890
	public void Close(string panelKey, bool destroy = false /* Metadata: 0x005F15B9 */); // 0x00000001808F2890-0x00000001808F2B20
	private void LateUpdate(); // 0x00000001808F2B20-0x00000001808F3250
	private void PruneDeadEntries(); // 0x00000001808F3250-0x00000001808F3780
	public bool CloseTop(); // 0x00000001808F3780-0x00000001808F37F0
	public bool IsOpen(string panelKey); // 0x00000001808F37F0-0x00000001808F3990
	public void UnloadAll(); // 0x00000001808F3B80-0x00000001808F3E20
	private Transform ResolvePanelRoot(); // 0x00000001808F3E20-0x00000001808F4540
	public static Transform FindDeep(Transform root, string name); // 0x00000001808F4540-0x00000001808F47E0
	private void TrackOpen(string panelKey); // 0x00000001808F47E0-0x00000001808F48F0
}

