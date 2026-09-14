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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class UIPanelManager : MonoBehaviour // TypeDefIndex: 1816
{
	// Fields
	[CompilerGenerated]
	private static UIPanelManager _Instance_k__BackingField; // 0x00
	private const string PREFAB_ROOT = "UIPanels/"; // Metadata: 0x005F01E9
	private const string SKIN_SUFFIX = "_Poky"; // Metadata: 0x005F01F3
	public const string PREF_SKIN_FORCE = "PokySkinForce"; // Metadata: 0x005F01F9
	private static readonly HashSet<string> LegacyOnlyKeys; // 0x08
	public const string SKIN_ALL_FLAG = "pokyhub.skin.all"; // Metadata: 0x005F0207
	public const string SKIN_CDN_FLAG = "pokyhub.skin.cdn"; // Metadata: 0x005F0218
	public Transform panelRoot; // 0x20
	private readonly Dictionary<string, GameObject> _cache; // 0x28
	private readonly List<string> _openOrder; // 0x30
	[CompilerGenerated]
	private static Action<string, bool> OnPanelToggled; // 0x10
	private const float ORPHAN_DIM_GRACE = 0.5f; // Metadata: 0x005F0229
	private readonly Dictionary<string, float> _orphanSince; // 0x38
	private readonly List<string> _orphanScratch; // 0x40
	private float _lastPruneAt; // 0x48
	private const float PruneIntervalSec = 1f; // Metadata: 0x005F022D

	// Properties
	public static UIPanelManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808EE360-0x00000001808EE3C0 0x00000001808EE3C0-0x00000001808EE470
	public bool AnyPanelOpen { get; } // 0x00000001808F0A60-0x00000001808F0C50 

	// Events
	public static event Action<string, bool> OnPanelToggled {
		add; // 0x00000001808EE810-0x00000001808EE960
		remove; // 0x00000001808EE960-0x00000001808EEAB0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1817
	{
		// Fields
		public GameObject prefab; // 0x10

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadAndOpen_b__0(GameObject p); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _LoadAndOpen_b__1(GameObject p); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class _LoadAndOpen_d__24 : IEnumerator<object> // TypeDefIndex: 1818
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
		void IDisposable.Dispose(); // 0x00000001808F1F70-0x00000001808F2080
		private bool MoveNext(); // 0x00000001808F2080-0x00000001808F3190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F3190-0x00000001808F31D0
	}

	[CompilerGenerated]
	private sealed class _LoadRemotePrefab_d__25 : IEnumerator<object> // TypeDefIndex: 1819
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
		void IDisposable.Dispose(); // 0x00000001808F31D0-0x00000001808F3250
		private bool MoveNext(); // 0x00000001808F3250-0x00000001808F3B00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F3B00-0x00000001808F3B40
	}

	// Constructors
	public UIPanelManager(); // 0x00000001808F19C0-0x00000001808F1C60
	static UIPanelManager(); // 0x00000001808F1C60-0x00000001808F1F70

	// Methods
	public static bool IsLegacyOnly(string panelKey); // 0x00000001808EE470-0x00000001808EE530
	public static bool UseSkin(string panelKey); // 0x00000001808EE530-0x00000001808EE680
	public static bool SkinFromCdn(string panelKey); // 0x00000001808EE680-0x00000001808EE7B0
	public static string SkinResourcePath(string panelKey); // 0x00000001808EE7B0-0x00000001808EE810
	private static void RaiseToggled(string panelKey, bool open); // 0x00000001808EEAB0-0x00000001808EEBB0
	public static UIPanelManager EnsureInstance(); // 0x00000001808EEBB0-0x00000001808EED90
	private void Awake(); // 0x00000001808EED90-0x00000001808EF000
	public void Open(string panelKey, Action<GameObject> onReady = null, Transform parent = null); // 0x00000001808EF000-0x00000001808EF560
	[IteratorStateMachine(typeof(_LoadAndOpen_d__24))]
	private IEnumerator LoadAndOpen(string panelKey, Action<GameObject> onReady); // 0x00000001808EF560-0x00000001808EF6C0
	[IteratorStateMachine(typeof(_LoadRemotePrefab_d__25))]
	private IEnumerator LoadRemotePrefab(string panelKey, Action<GameObject> done); // 0x00000001808EF6C0-0x00000001808EF7D0
	private static bool HasMissingScript(GameObject root); // 0x00000001808EF7D0-0x00000001808EF960
	public void Close(string panelKey, bool destroy = false /* Metadata: 0x005F01E8 */); // 0x00000001808EF960-0x00000001808EFBF0
	private void LateUpdate(); // 0x00000001808EFBF0-0x00000001808F0320
	private void PruneDeadEntries(); // 0x00000001808F0320-0x00000001808F0850
	public bool CloseTop(); // 0x00000001808F0850-0x00000001808F08C0
	public bool IsOpen(string panelKey); // 0x00000001808F08C0-0x00000001808F0A60
	public void UnloadAll(); // 0x00000001808F0C50-0x00000001808F0EF0
	private Transform ResolvePanelRoot(); // 0x00000001808F0EF0-0x00000001808F1610
	public static Transform FindDeep(Transform root, string name); // 0x00000001808F1610-0x00000001808F18B0
	private void TrackOpen(string panelKey); // 0x00000001808F18B0-0x00000001808F19C0
}

