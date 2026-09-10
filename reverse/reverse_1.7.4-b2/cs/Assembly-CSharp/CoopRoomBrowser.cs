/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class CoopRoomBrowser : MonoBehaviour // TypeDefIndex: 12
{
	// Fields
	private const string ROOM_TYPE = "ChinhPhuc"; // Metadata: 0x0068A803
	private const string PANEL_PREFAB_PATH = "Prefabs/UI/CoopRoomListPanel"; // Metadata: 0x0068A80D
	private const string STATUS_CONNECTING = "\u0110ang k\u1EBFt n\u1ED1i m\u00E1y ch\u1EE7..."; // Metadata: 0x0068A82A
	private const string STATUS_LOADING = "\u0110ang t\u1EA3i danh s\u00E1ch ph\u00F2ng..."; // Metadata: 0x0068A84A
	private const string STATUS_EMPTY = "Ch\u01B0a c\u00F3 ph\u00F2ng n\u00E0o \u0111ang m\u1EDF.\nH\u00E3y t\u1EA1o ph\u00F2ng v\u00E0 r\u1EE7 b\u1EA1n b\u00E8 c\u00F9ng s\u0103n boss!"; // Metadata: 0x0068A86B
	private ManagerChinhPhuc _host; // 0x20
	private GameObject _openButton; // 0x28
	private CoopRoomGridView _view; // 0x30
	private bool _panelOpen; // 0x38
	private bool _listening; // 0x39
	private float _nextHealAt; // 0x3C
	private float _nextConnectKickAt; // 0x40

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 13
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<RoomSummaryDTO, bool> __9__25_0; // 0x08
		public static Comparison<RoomSummaryDTO> __9__25_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180300A30-0x0000000180300AA0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _RebuildList_b__25_0(RoomSummaryDTO r); // 0x00000001803007F0-0x0000000180300850
		internal int _RebuildList_b__25_1(RoomSummaryDTO a, RoomSummaryDTO b); // 0x0000000180300850-0x0000000180300900
	}

	// Constructors
	public CoopRoomBrowser(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void EnsureAttached(ManagerChinhPhuc host); // 0x00000001802EF590-0x00000001802EF680
	private void OnDisable(); // 0x00000001802F02E0-0x00000001802F02F0
	private void OnDestroy(); // 0x00000001802F02D0-0x00000001802F02E0
	private void Update(); // 0x00000001802F0CA0-0x00000001802F0D80
	private void Subscribe(WsRoomService ws); // 0x00000001802F0B30-0x00000001802F0C30
	private void EnsureConnectionAndSubscription(); // 0x00000001802EF680-0x00000001802EF8C0
	private static void KickConnect(ChatService chat); // 0x00000001802F0160-0x00000001802F02D0
	private void AttachListEvents(); // 0x00000001802EEEE0-0x00000001802EEF80
	private void DetachListEvents(); // 0x00000001802EF4F0-0x00000001802EF590
	public void TogglePanel(); // 0x00000001802F0C30-0x00000001802F0C50
	public void OpenPanel(); // 0x00000001802F0500-0x00000001802F06C0
	public void ClosePanel(); // 0x00000001802EF410-0x00000001802EF4F0
	private void OnJoinClicked(string roomId, int enemyPetId, int enemyPetLevel); // 0x00000001802F02F0-0x00000001802F0500
	private void RebuildList(); // 0x00000001802F06C0-0x00000001802F09D0
	private void RefreshStatus(); // 0x00000001802F09D0-0x00000001802F0B30
	private void BuildView(); // 0x00000001802EEF80-0x00000001802EF410
	private void EnsureOpenButton(); // 0x00000001802EF8C0-0x00000001802F0070
	private static Transform FindDeep(Transform root, string name); // 0x00000001802F0070-0x00000001802F0160
	[CompilerGenerated]
	private void _BuildView_b__27_0(); // 0x00000001802F0C50-0x00000001802F0CA0
}

