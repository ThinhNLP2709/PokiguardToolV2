/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MatchTeamPanelController : MonoBehaviour // TypeDefIndex: 78
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
	private bool _statusSubscribed; // 0x5D
	private readonly List<string> _statusBuffer; // 0x60

	// Properties
	public static MatchTeamPanelController Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018046FCC0-0x000000018046FD00 0x000000018046FD00-0x000000018046FDA0

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 79
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<int, int> __9__21_1; // 0x08
		public static Func<ActivePVP.PlayerStats, int> __9__22_1; // 0x10
		public static Func<ActivePVP.PlayerStats, int> __9__22_2; // 0x18
		public static Func<ActivePVP.PlayerStats, int> __9__22_4; // 0x20
		public static Func<ActivePVP.PlayerStats, int> __9__22_5; // 0x28

		// Constructors
		static __c(); // 0x0000000180475CA0-0x0000000180475D40
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _RebuildCoOp_b__21_1(int a); // 0x0000000180475D40-0x0000000180475D50
		internal int _RebuildPvp_b__22_1(ActivePVP.PlayerStats s); // 0x0000000180475D50-0x0000000180475D70
		internal int _RebuildPvp_b__22_2(ActivePVP.PlayerStats s); // 0x0000000180475D70-0x0000000180475D90
		internal int _RebuildPvp_b__22_4(ActivePVP.PlayerStats s); // 0x0000000180475D50-0x0000000180475D70
		internal int _RebuildPvp_b__22_5(ActivePVP.PlayerStats s); // 0x0000000180475D70-0x0000000180475D90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 80
	{
		// Fields
		public int enemyActor; // 0x10

		// Constructors
		public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RebuildCoOp_b__0(int a); // 0x0000000180475D90-0x0000000180475DA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 81
	{
		// Fields
		public int myTeam; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RebuildPvp_b__0(ActivePVP.PlayerStats s); // 0x0000000180475DA0-0x0000000180475DC0
		internal bool _RebuildPvp_b__3(ActivePVP.PlayerStats s); // 0x0000000180475DC0-0x0000000180475DE0
	}

	[CompilerGenerated]
	private struct __c__DisplayClass27_0 // TypeDefIndex: 82
	{
		// Fields
		public ActivePVP active; // 0x00
	}

	// Constructors
	public MatchTeamPanelController(); // 0x00000001804755E0-0x0000000180475800

	// Methods
	private void Awake(); // 0x000000018046FDA0-0x0000000180470000
	private void OnDestroy(); // 0x0000000180470000-0x0000000180470180
	private void Start(); // 0x0000000180470180-0x00000001804701A0
	private void OnEnable(); // 0x0000000180470180-0x00000001804701A0
	private void OnDisable(); // 0x00000001804701A0-0x00000001804701C0
	public static void NotifyStatsReady(MatchTeamPanelMode mode); // 0x00000001804701C0-0x00000001804703A0
	public void RefreshAllStats(); // 0x00000001804703A0-0x0000000180470550
	private void Rebuild(); // 0x0000000180470550-0x00000001804705A0
	private void RebuildCoOp(); // 0x00000001804705A0-0x00000001804713F0
	private void RebuildPvp(); // 0x00000001804713F0-0x0000000180472150
	private void ApplyWeaponBadge(MatchTeamMemberSlotUI slot, int actorNumber); // 0x0000000180472150-0x0000000180472540
	private int ResolveAvatarId(int actorNumber); // 0x0000000180472540-0x00000001804728B0
	private string ResolveAvatarLayers(int actorNumber); // 0x00000001804728B0-0x0000000180472C30
	private void RefreshCoOpStats(); // 0x0000000180472C30-0x00000001804736E0
	private void RefreshPvpStats(); // 0x00000001804736E0-0x0000000180473880
	private void OnTurnStarted(int actorNumber); // 0x0000000180473880-0x0000000180473890
	private void RefreshTurnIndicators(); // 0x0000000180473890-0x0000000180473AD0
	private void TrySubscribeTurns(); // 0x0000000180473AD0-0x0000000180473D70
	private void UnsubscribeTurns(); // 0x0000000180473D70-0x0000000180474020
	private void SubscribeStatusModel(); // 0x0000000180474020-0x0000000180474230
	private void UnsubscribeStatusModel(); // 0x0000000180474230-0x0000000180474440
	private void OnStatusModelChanged(int actorNumber); // 0x0000000180474440-0x0000000180474590
	private void RefreshAllStatusIcons(); // 0x0000000180474590-0x0000000180474A20
	public MatchTeamMemberSlotUI FindSlotByActor(int actorNumber); // 0x0000000180474A20-0x0000000180474E40
	private static void ClearPanel(RectTransform panel, List<MatchTeamMemberSlotUI> list); // 0x0000000180474E40-0x0000000180475140
	private static MatchTeamMemberSlotUI GetOrAddSlot(GameObject go); // 0x0000000180475140-0x0000000180475280
	private static Sprite LoadAvatarSprite(int avatarId); // 0x0000000180475280-0x0000000180475430
	private static Sprite LoadPetIconSprite(int petId); // 0x0000000180475430-0x00000001804755E0
	[CompilerGenerated]
	internal static void _RefreshPvpStats_g__ApplyList_27_0(List<MatchTeamMemberSlotUI> list, ref __c__DisplayClass27_0 param_000001c8); // 0x0000000180475800-0x0000000180475CA0
}

