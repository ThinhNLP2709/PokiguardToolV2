/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MatchTeamPanelController : MonoBehaviour // TypeDefIndex: 68
{
	// Fields
	[CompilerGenerated]
	private static MatchTeamPanelController _Instance_k__BackingField; // 0x00
	[Header("Mode")]
	[SerializeField]
	private MatchTeamPanelMode panelMode; // 0x20
	[Header("Containers (RectTransform)")]
	[SerializeField]
	private RectTransform pnlTeam; // 0x28
	[SerializeField]
	private RectTransform pnlTeam2; // 0x30
	[Header("Prefabs")]
	[SerializeField]
	private GameObject prefabAllySlot; // 0x38
	[SerializeField]
	private GameObject prefabOpponentSlot; // 0x40
	private readonly List<MatchTeamMemberSlotUI> _allySlots; // 0x48
	private readonly List<MatchTeamMemberSlotUI> _enemySlots; // 0x50
	private int _currentTurnActor; // 0x58
	private bool _subscribed; // 0x5C

	// Properties
	public static MatchTeamPanelController Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180303600-0x0000000180303640 0x0000000180303640-0x00000001803036A0

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 69
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int> __9__21_1; // 0x08
		public static Func<ActivePVP.PlayerStats, int> __9__22_1; // 0x10
		public static Func<ActivePVP.PlayerStats, int> __9__22_2; // 0x18
		public static Func<ActivePVP.PlayerStats, int> __9__22_4; // 0x20
		public static Func<ActivePVP.PlayerStats, int> __9__22_5; // 0x28

		// Constructors
		static __c(); // 0x000000018030FAE0-0x000000018030FB50
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _RebuildCoOp_b__21_1(int a); // 0x000000018030F1D0-0x000000018030F1E0
		internal int _RebuildPvp_b__22_1(ActivePVP.PlayerStats s); // 0x000000018030F1E0-0x000000018030F200
		internal int _RebuildPvp_b__22_2(ActivePVP.PlayerStats s); // 0x000000018030F200-0x000000018030F220
		internal int _RebuildPvp_b__22_4(ActivePVP.PlayerStats s); // 0x000000018030F1E0-0x000000018030F200
		internal int _RebuildPvp_b__22_5(ActivePVP.PlayerStats s); // 0x000000018030F200-0x000000018030F220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 70
	{
		// Fields
		public int enemyActor; // 0x10

		// Constructors
		public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _RebuildCoOp_b__0(int a); // 0x000000018030F2D0-0x000000018030F2E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 71
	{
		// Fields
		public int myTeam; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _RebuildPvp_b__0(ActivePVP.PlayerStats s); // 0x000000018030F2E0-0x000000018030F300
		internal bool _RebuildPvp_b__3(ActivePVP.PlayerStats s); // 0x000000018030F300-0x000000018030F320
	}

	[CompilerGenerated]
	private struct __c__DisplayClass26_0 // TypeDefIndex: 72
	{
		// Fields
		public ActivePVP active; // 0x00
	}

	// Constructors
	public MatchTeamPanelController(); // 0x0000000180303550-0x0000000180303600

	// Methods
	private void Awake(); // 0x0000000180300590-0x00000001803006C0
	private void OnDestroy(); // 0x0000000180300D90-0x0000000180300E70
	private void Start(); // 0x0000000180300E80-0x0000000180300E90
	private void OnEnable(); // 0x0000000180300E80-0x0000000180300E90
	private void OnDisable(); // 0x0000000180300E70-0x0000000180300E80
	public static void NotifyStatsReady(MatchTeamPanelMode mode); // 0x0000000180300C60-0x0000000180300D90
	public void RefreshAllStats(); // 0x0000000180302160-0x0000000180302250
	private void Rebuild(); // 0x0000000180302120-0x0000000180302160
	private void RebuildCoOp(); // 0x0000000180300EA0-0x00000001803016E0
	private void RebuildPvp(); // 0x00000001803016E0-0x0000000180302120
	private void ApplyWeaponBadge(MatchTeamMemberSlotUI slot, int actorNumber); // 0x0000000180300300-0x0000000180300590
	private int ResolveAvatarId(int actorNumber); // 0x0000000180302C00-0x0000000180302E20
	private void RefreshCoOpStats(); // 0x0000000180302250-0x00000001803028A0
	private void RefreshPvpStats(); // 0x00000001803028A0-0x0000000180302970
	private void OnTurnStarted(int actorNumber); // 0x0000000180300E90-0x0000000180300EA0
	private void RefreshTurnIndicators(); // 0x0000000180302970-0x0000000180302C00
	private void TrySubscribeTurns(); // 0x0000000180302E20-0x0000000180303040
	private void UnsubscribeTurns(); // 0x0000000180303320-0x0000000180303550
	public MatchTeamMemberSlotUI FindSlotByActor(int actorNumber); // 0x0000000180300790-0x00000001803009F0
	private static void ClearPanel(RectTransform panel, List<MatchTeamMemberSlotUI> list); // 0x00000001803006C0-0x0000000180300790
	private static MatchTeamMemberSlotUI GetOrAddSlot(GameObject go); // 0x00000001803009F0-0x0000000180300AA0
	private static Sprite LoadAvatarSprite(int avatarId); // 0x0000000180300AA0-0x0000000180300B80
	private static Sprite LoadPetIconSprite(int petId); // 0x0000000180300B80-0x0000000180300C60
	[CompilerGenerated]
	internal static void _RefreshPvpStats_g__ApplyList_26_0(List<MatchTeamMemberSlotUI> list, ref __c__DisplayClass26_0 param_0000010e); // 0x0000000180303040-0x0000000180303320
}

