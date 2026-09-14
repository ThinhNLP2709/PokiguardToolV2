/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public static MatchTeamPanelController Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018046EA50-0x000000018046EA90 0x000000018046EA90-0x000000018046EB30

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
		static __c(); // 0x0000000180474A30-0x0000000180474AD0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _RebuildCoOp_b__21_1(int a); // 0x0000000180474AD0-0x0000000180474AE0
		internal int _RebuildPvp_b__22_1(ActivePVP.PlayerStats s); // 0x0000000180474AE0-0x0000000180474B00
		internal int _RebuildPvp_b__22_2(ActivePVP.PlayerStats s); // 0x0000000180474B00-0x0000000180474B20
		internal int _RebuildPvp_b__22_4(ActivePVP.PlayerStats s); // 0x0000000180474AE0-0x0000000180474B00
		internal int _RebuildPvp_b__22_5(ActivePVP.PlayerStats s); // 0x0000000180474B00-0x0000000180474B20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 80
	{
		// Fields
		public int enemyActor; // 0x10

		// Constructors
		public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RebuildCoOp_b__0(int a); // 0x0000000180474B20-0x0000000180474B30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 81
	{
		// Fields
		public int myTeam; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RebuildPvp_b__0(ActivePVP.PlayerStats s); // 0x0000000180474B30-0x0000000180474B50
		internal bool _RebuildPvp_b__3(ActivePVP.PlayerStats s); // 0x0000000180474B50-0x0000000180474B70
	}

	[CompilerGenerated]
	private struct __c__DisplayClass27_0 // TypeDefIndex: 82
	{
		// Fields
		public ActivePVP active; // 0x00
	}

	// Constructors
	public MatchTeamPanelController(); // 0x0000000180474370-0x0000000180474590

	// Methods
	private void Awake(); // 0x000000018046EB30-0x000000018046ED90
	private void OnDestroy(); // 0x000000018046ED90-0x000000018046EF10
	private void Start(); // 0x000000018046EF10-0x000000018046EF30
	private void OnEnable(); // 0x000000018046EF10-0x000000018046EF30
	private void OnDisable(); // 0x000000018046EF30-0x000000018046EF50
	public static void NotifyStatsReady(MatchTeamPanelMode mode); // 0x000000018046EF50-0x000000018046F130
	public void RefreshAllStats(); // 0x000000018046F130-0x000000018046F2E0
	private void Rebuild(); // 0x000000018046F2E0-0x000000018046F330
	private void RebuildCoOp(); // 0x000000018046F330-0x0000000180470180
	private void RebuildPvp(); // 0x0000000180470180-0x0000000180470EE0
	private void ApplyWeaponBadge(MatchTeamMemberSlotUI slot, int actorNumber); // 0x0000000180470EE0-0x00000001804712D0
	private int ResolveAvatarId(int actorNumber); // 0x00000001804712D0-0x0000000180471640
	private string ResolveAvatarLayers(int actorNumber); // 0x0000000180471640-0x00000001804719C0
	private void RefreshCoOpStats(); // 0x00000001804719C0-0x0000000180472470
	private void RefreshPvpStats(); // 0x0000000180472470-0x0000000180472610
	private void OnTurnStarted(int actorNumber); // 0x0000000180472610-0x0000000180472620
	private void RefreshTurnIndicators(); // 0x0000000180472620-0x0000000180472860
	private void TrySubscribeTurns(); // 0x0000000180472860-0x0000000180472B00
	private void UnsubscribeTurns(); // 0x0000000180472B00-0x0000000180472DB0
	private void SubscribeStatusModel(); // 0x0000000180472DB0-0x0000000180472FC0
	private void UnsubscribeStatusModel(); // 0x0000000180472FC0-0x00000001804731D0
	private void OnStatusModelChanged(int actorNumber); // 0x00000001804731D0-0x0000000180473320
	private void RefreshAllStatusIcons(); // 0x0000000180473320-0x00000001804737B0
	public MatchTeamMemberSlotUI FindSlotByActor(int actorNumber); // 0x00000001804737B0-0x0000000180473BD0
	private static void ClearPanel(RectTransform panel, List<MatchTeamMemberSlotUI> list); // 0x0000000180473BD0-0x0000000180473ED0
	private static MatchTeamMemberSlotUI GetOrAddSlot(GameObject go); // 0x0000000180473ED0-0x0000000180474010
	private static Sprite LoadAvatarSprite(int avatarId); // 0x0000000180474010-0x00000001804741C0
	private static Sprite LoadPetIconSprite(int petId); // 0x00000001804741C0-0x0000000180474370
	[CompilerGenerated]
	internal static void _RefreshPvpStats_g__ApplyList_27_0(List<MatchTeamMemberSlotUI> list, ref __c__DisplayClass27_0 param_000001c8); // 0x0000000180474590-0x0000000180474A30
}

