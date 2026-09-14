/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class CoopRoomBrowser : MonoBehaviour // TypeDefIndex: 13
{
	// Fields
	private const string ROOM_TYPE = "ChinhPhuc"; // Metadata: 0x005ED245
	private const string PANEL_PREFAB_PATH = "Prefabs/UI/CoopRoomListPanel"; // Metadata: 0x005ED24F
	private const string STATUS_CONNECTING = "\u0110ang k\u1EBFt n\u1ED1i m\u00E1y ch\u1EE7..."; // Metadata: 0x005ED26C
	private const string STATUS_LOADING = "\u0110ang t\u1EA3i danh s\u00E1ch ph\u00F2ng..."; // Metadata: 0x005ED28C
	private const string STATUS_EMPTY = "Ch\u01B0a c\u00F3 ph\u00F2ng n\u00E0o \u0111ang m\u1EDF.\nH\u00E3y t\u1EA1o ph\u00F2ng v\u00E0 r\u1EE7 b\u1EA1n b\u00E8 c\u00F9ng s\u0103n boss!"; // Metadata: 0x005ED2AD
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
	private sealed class __c // TypeDefIndex: 14
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<RoomSummaryDTO, bool> __9__25_0; // 0x08
		public static Comparison<RoomSummaryDTO> __9__25_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180297FC0-0x0000000180298060
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _RebuildList_b__25_0(RoomSummaryDTO r); // 0x0000000180298060-0x0000000180298180
		internal int _RebuildList_b__25_1(RoomSummaryDTO a, RoomSummaryDTO b); // 0x0000000180298180-0x0000000180298270
	}

	// Constructors
	public CoopRoomBrowser(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void EnsureAttached(ManagerChinhPhuc host); // 0x0000000180294DE0-0x0000000180295000
	private void OnDisable(); // 0x0000000180295000-0x0000000180295010
	private void OnDestroy(); // 0x0000000180295010-0x0000000180295020
	private void Update(); // 0x0000000180295020-0x00000001802950F0
	private void Subscribe(WsRoomService ws); // 0x00000001802950F0-0x0000000180295200
	private void EnsureConnectionAndSubscription(); // 0x0000000180295200-0x00000001802954F0
	private static void KickConnect(ChatService chat); // 0x00000001802954F0-0x0000000180295690
	private void AttachListEvents(); // 0x0000000180295690-0x0000000180295740
	private void DetachListEvents(); // 0x0000000180295740-0x00000001802957F0
	public void TogglePanel(); // 0x00000001802957F0-0x0000000180295810
	public void OpenPanel(); // 0x0000000180295810-0x0000000180295A80
	public void ClosePanel(); // 0x0000000180295A80-0x0000000180295BA0
	private void OnJoinClicked(string roomId, int enemyPetId, int enemyPetLevel); // 0x0000000180295BA0-0x0000000180295E90
	private void RebuildList(); // 0x0000000180295E90-0x00000001802963D0
	private void RefreshStatus(); // 0x00000001802963D0-0x00000001802966D0
	private void BuildView(); // 0x00000001802966D0-0x0000000180296DF0
	private void EnsureOpenButton(); // 0x0000000180296DF0-0x0000000180297D00
	private static Transform FindDeep(Transform root, string name); // 0x0000000180297D00-0x0000000180297F70
	[CompilerGenerated]
	private void _BuildView_b__27_0(); // 0x0000000180297F70-0x0000000180297FC0
}

