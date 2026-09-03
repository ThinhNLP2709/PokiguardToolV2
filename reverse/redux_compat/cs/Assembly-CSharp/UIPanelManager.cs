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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class UIPanelManager : MonoBehaviour // TypeDefIndex: 1205
{
	// Fields
	[CompilerGenerated]
	private static UIPanelManager _Instance_k__BackingField; // 0x00
	private const string PREFAB_ROOT = "UIPanels/"; // Metadata: 0x0064D4D8
	private const string SKIN_SUFFIX = "_Poky"; // Metadata: 0x0064D4E2
	public const string PREF_SKIN_FORCE = "PokySkinForce"; // Metadata: 0x0064D4E8
	private static readonly HashSet<string> LegacyOnlyKeys; // 0x08
	public const string SKIN_ALL_FLAG = "pokyhub.skin.all"; // Metadata: 0x0064D4F6
	public const string SKIN_CDN_FLAG = "pokyhub.skin.cdn"; // Metadata: 0x0064D507
	public Transform panelRoot; // 0x20
	private readonly Dictionary<string, GameObject> _cache; // 0x28
	private readonly List<string> _openOrder; // 0x30
	[CompilerGenerated]
	private static Action<string, bool> OnPanelToggled; // 0x10
	private const float ORPHAN_DIM_GRACE = 0.5f; // Metadata: 0x0064D518
	private readonly Dictionary<string, float> _orphanSince; // 0x38
	private readonly List<string> _orphanScratch; // 0x40

	// Properties
	public static UIPanelManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804D9C60-0x00000001804D9CB0 0x00000001804D9DA0-0x00000001804D9EC0
	public bool AnyPanelOpen { get; } // 0x00000001804D9B40-0x00000001804D9C60 

	// Events
	public static event Action<string, bool> OnPanelToggled {
		add; // 0x00000001804D9A50-0x00000001804D9B40
		remove; // 0x00000001804D9CB0-0x00000001804D9DA0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1206
	{
		// Fields
		public GameObject prefab; // 0x10

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadAndOpen_b__0(GameObject p); // 0x00000001803780D0-0x00000001803780E0
		internal void _LoadAndOpen_b__1(GameObject p); // 0x00000001803780D0-0x00000001803780E0
	}

	[CompilerGenerated]
	private sealed class _LoadAndOpen_d__24 : IEnumerator<object> // TypeDefIndex: 1207
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadAndOpen_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D5EF0-0x00000001804D5F40
		private bool MoveNext(); // 0x00000001804D50D0-0x00000001804D5EB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D5EB0-0x00000001804D5EF0
	}

	[CompilerGenerated]
	private sealed class _LoadRemotePrefab_d__25 : IEnumerator<object> // TypeDefIndex: 1208
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRemotePrefab_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D66B0-0x00000001804D66F0
		private bool MoveNext(); // 0x00000001804D5F40-0x00000001804D6670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D6670-0x00000001804D66B0
	}

	// Constructors
	public UIPanelManager(); // 0x00000001804D9910-0x00000001804D9A50
	static UIPanelManager(); // 0x00000001804D9760-0x00000001804D9910

	// Methods
	public static bool IsLegacyOnly(string panelKey); // 0x00000001804D83E0-0x00000001804D8490
	public static bool UseSkin(string panelKey); // 0x00000001804D95F0-0x00000001804D9760
	public static bool SkinFromCdn(string panelKey); // 0x00000001804D91F0-0x00000001804D9310
	public static string SkinResourcePath(string panelKey); // 0x00000001804D9310-0x00000001804D9360
	private static void RaiseToggled(string panelKey, bool open); // 0x00000001804D8DA0-0x00000001804D8E90
	public static UIPanelManager EnsureInstance(); // 0x00000001804D8050-0x00000001804D81D0
	private void Awake(); // 0x00000001804D7CF0-0x00000001804D7EA0
	public void Open(string panelKey, Action<GameObject> onReady = null, Transform parent = null); // 0x00000001804D8BA0-0x00000001804D8DA0
	[IteratorStateMachine(typeof(_LoadAndOpen_d__24))]
	private IEnumerator LoadAndOpen(string panelKey, Action<GameObject> onReady); // 0x00000001804D8A60-0x00000001804D8B10
	[IteratorStateMachine(typeof(_LoadRemotePrefab_d__25))]
	private IEnumerator LoadRemotePrefab(string panelKey, Action<GameObject> done); // 0x00000001804D8B10-0x00000001804D8BA0
	private static bool HasMissingScript(GameObject root); // 0x00000001804D8300-0x00000001804D83E0
	public void Close(string panelKey, bool destroy = false /* Metadata: 0x0064D4D7 */); // 0x00000001804D7EF0-0x00000001804D8050
	private void LateUpdate(); // 0x00000001804D8550-0x00000001804D8A60
	public bool CloseTop(); // 0x00000001804D7EA0-0x00000001804D7EF0
	public bool IsOpen(string panelKey); // 0x00000001804D8490-0x00000001804D8550
	public void UnloadAll(); // 0x00000001804D9430-0x00000001804D95F0
	private Transform ResolvePanelRoot(); // 0x00000001804D8E90-0x00000001804D91F0
	public static Transform FindDeep(Transform root, string name); // 0x00000001804D81D0-0x00000001804D8300
	private void TrackOpen(string panelKey); // 0x00000001804D9360-0x00000001804D9430
}

