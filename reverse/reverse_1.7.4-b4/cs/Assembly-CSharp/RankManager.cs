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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	private const string PREFS_KEY = "RankPoints"; // Metadata: 0x005EED80
	private int _currentPoints; // 0x5C

	// Properties
	public static RankManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D72CC0-0x0000000180D72D20 0x0000000180D72D20-0x0000000180D72DD0
	public int CurrentPoints { get; } // 0x0000000180D72DD0-0x0000000180D72DE0 

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
		public RankTier(); // 0x000000018028A320-0x000000018028A330
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadFromCurrentUser_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D75510-0x0000000180D75660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D75660-0x0000000180D756A0
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRankTiersFromServer_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D756A0-0x0000000180D75BE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D75BE0-0x0000000180D75C20
	}

	// Constructors
	public RankManager(); // 0x0000000180D73D70-0x0000000180D73E70
	static RankManager(); // 0x0000000180D73E70-0x0000000180D74F30

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x0000000180D72DE0-0x0000000180D72FB0
	private void Awake(); // 0x0000000180D72FB0-0x0000000180D733B0
	private void OnEnable(); // 0x0000000180D733B0-0x0000000180D73460
	[IteratorStateMachine(typeof(_LoadRankTiersFromServer_d__21))]
	private IEnumerator LoadRankTiersFromServer(); // 0x0000000180D73460-0x0000000180D73500
	[IteratorStateMachine(typeof(_LoadFromCurrentUser_d__22))]
	private IEnumerator LoadFromCurrentUser(); // 0x0000000180D73500-0x0000000180D735A0
	public void UpdateRankPoints(int delta); // 0x0000000180D735A0-0x0000000180D73670
	private void OnRankUp(RankTier newTier); // 0x000000018028A320-0x000000018028A330
	public void RefreshUI(); // 0x0000000180D73670-0x0000000180D73CB0
	public RankTier GetCurrentTier(int points); // 0x0000000180D73CB0-0x0000000180D73D70
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_0(PvpRankTierResponse response); // 0x0000000180D74F30-0x0000000180D75380
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_1(string err); // 0x0000000180D75380-0x0000000180D75510
}

