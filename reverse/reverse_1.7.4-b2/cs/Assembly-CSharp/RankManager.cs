/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class RankManager : MonoBehaviour // TypeDefIndex: 256
{
	// Fields
	[CompilerGenerated]
	private static RankManager _Instance_k__BackingField; // 0x00
	[Header("UI References")]
	public Slider rankSlider; // 0x20
	public UnityEngine.UI.Text txtCurrentPoints; // 0x28
	public UnityEngine.UI.Text txtPointsToNextRank; // 0x30
	public UnityEngine.UI.Text txtRankName; // 0x38
	public Image imgRankIcon; // 0x40
	[Header("Testing")]
	public bool isTesting; // 0x48
	[Header("Rank Tiers - Load t\u1EEB server, fallback hardcode")]
	public List<RankTier> rankTiers; // 0x50
	private bool _tiersLoaded; // 0x58
	private static readonly List<RankTier> FALLBACK_TIERS; // 0x08
	private const string PREFS_KEY = "RankPoints"; // Metadata: 0x0068AD85
	private int _currentPoints; // 0x5C

	// Properties
	public static RankManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018084ABB0-0x000000018084AC00 0x000000018084AC00-0x000000018084AC70
	public int CurrentPoints { get; } // 0x000000018039C0E0-0x000000018039C0F0 

	// Nested types
	[Serializable]
	public class RankTier // TypeDefIndex: 257
	{
		// Fields
		public int minPoints; // 0x10
		public int maxPoints; // 0x14
		public string rankName; // 0x18
		public string iconName; // 0x20

		// Constructors
		public RankTier(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _LoadFromCurrentUser_d__22 : IEnumerator<object> // TypeDefIndex: 258
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RankManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadFromCurrentUser_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001808521F0-0x0000000180852300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180852300-0x0000000180852340
	}

	[CompilerGenerated]
	private sealed class _LoadRankTiersFromServer_d__21 : IEnumerator<object> // TypeDefIndex: 259
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RankManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRankTiersFromServer_d__21(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180852340-0x0000000180852630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180852630-0x0000000180852670
	}

	// Constructors
	public RankManager(); // 0x000000018084AB30-0x000000018084ABB0
	static RankManager(); // 0x0000000180849F80-0x000000018084AB30

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x0000000180849240-0x0000000180849370
	private void Awake(); // 0x0000000180849370-0x00000001808495C0
	private void OnEnable(); // 0x0000000180849740-0x00000001808497C0
	[IteratorStateMachine(typeof(_LoadRankTiersFromServer_d__21))]
	private IEnumerator LoadRankTiersFromServer(); // 0x00000001808496D0-0x0000000180849740
	[IteratorStateMachine(typeof(_LoadFromCurrentUser_d__22))]
	private IEnumerator LoadFromCurrentUser(); // 0x0000000180849660-0x00000001808496D0
	public void UpdateRankPoints(int delta); // 0x0000000180849EF0-0x0000000180849F80
	private void OnRankUp(RankTier newTier); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void RefreshUI(); // 0x00000001808497C0-0x0000000180849AB0
	public RankTier GetCurrentTier(int points); // 0x00000001808495C0-0x0000000180849660
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_0(PvpRankTierResponse response); // 0x0000000180849AB0-0x0000000180849DD0
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_1(string err); // 0x0000000180849DD0-0x0000000180849EF0
}

