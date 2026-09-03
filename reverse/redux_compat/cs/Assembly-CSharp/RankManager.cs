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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class RankManager : MonoBehaviour // TypeDefIndex: 230
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
	private const string PREFS_KEY = "RankPoints"; // Metadata: 0x0064C06D
	private int _currentPoints; // 0x5C

	// Properties
	public static RankManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180698340-0x0000000180698390 0x0000000180698390-0x0000000180698400
	public int CurrentPoints { get; } // 0x000000018033D270-0x000000018033D280 

	// Nested types
	[Serializable]
	public class RankTier // TypeDefIndex: 231
	{
		// Fields
		public int minPoints; // 0x10
		public int maxPoints; // 0x14
		public string rankName; // 0x18
		public string iconName; // 0x20

		// Constructors
		public RankTier(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class _LoadFromCurrentUser_d__22 : IEnumerator<object> // TypeDefIndex: 232
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RankManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadFromCurrentUser_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4AB0-0x00000001806A4BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A4BC0-0x00000001806A4C00
	}

	[CompilerGenerated]
	private sealed class _LoadRankTiersFromServer_d__21 : IEnumerator<object> // TypeDefIndex: 233
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RankManager __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRankTiersFromServer_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4C00-0x00000001806A4EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A4EF0-0x00000001806A4F30
	}

	// Constructors
	public RankManager(); // 0x00000001806982C0-0x0000000180698340
	static RankManager(); // 0x0000000180697710-0x00000001806982C0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001806969D0-0x0000000180696B00
	private void Awake(); // 0x0000000180696B00-0x0000000180696D50
	private void OnEnable(); // 0x0000000180696ED0-0x0000000180696F50
	[IteratorStateMachine(typeof(_LoadRankTiersFromServer_d__21))]
	private IEnumerator LoadRankTiersFromServer(); // 0x0000000180696E60-0x0000000180696ED0
	[IteratorStateMachine(typeof(_LoadFromCurrentUser_d__22))]
	private IEnumerator LoadFromCurrentUser(); // 0x0000000180696DF0-0x0000000180696E60
	public void UpdateRankPoints(int delta); // 0x0000000180697680-0x0000000180697710
	private void OnRankUp(RankTier newTier); // 0x00000001802E76C0-0x00000001802E76D0
	public void RefreshUI(); // 0x0000000180696F50-0x0000000180697240
	public RankTier GetCurrentTier(int points); // 0x0000000180696D50-0x0000000180696DF0
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_0(PvpRankTierResponse response); // 0x0000000180697240-0x0000000180697560
	[CompilerGenerated]
	private void _LoadRankTiersFromServer_b__21_1(string err); // 0x0000000180697560-0x0000000180697680
}

