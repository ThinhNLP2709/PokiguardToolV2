/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class CoopRoomCardUI : MonoBehaviour // TypeDefIndex: 14
{
	// Fields
	private const int COOP_CAP_FALLBACK = 3; // Metadata: 0x0068A8C4
	private Image _bg; // 0x20
	private Button _button; // 0x28
	private Image _imgBoss; // 0x30
	private UnityEngine.UI.Text _txtBoss; // 0x38
	private Image _seatChip; // 0x40
	private UnityEngine.UI.Text _txtSeat; // 0x48
	private UnityEngine.UI.Text _txtInfo; // 0x50
	private Image _stateBar; // 0x58
	private UnityEngine.UI.Text _txtState; // 0x60
	private string _roomId; // 0x68
	private int _enemyPetId; // 0x70
	private int _enemyPetLevel; // 0x74
	private Action<string, int, int> _onJoin; // 0x78
	private bool _compact; // 0x80
	private bool _twoLineInfo; // 0x81
	private string _ownerName; // 0x88

	// Constructors
	public CoopRoomCardUI(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static CoopRoomCardUI Create(Transform parent, int index); // 0x00000001802F2070-0x00000001802F2150
	private void Build(); // 0x00000001802F15F0-0x00000001802F2070
	public void Layout(Vector2 cell); // 0x00000001802F2300-0x00000001802F28C0
	public void Bind(RoomSummaryDTO room, Action<string, int, int> onJoin); // 0x00000001802F0D80-0x00000001802F1420
	private string BuildInfoText(string roomId, string owner); // 0x00000001802F1420-0x00000001802F15F0
	private void SetState(string label, Color barTint); // 0x00000001802F2920-0x00000001802F2A60
	private void OnClicked(); // 0x00000001802F28C0-0x00000001802F2920
	public static bool IsJoinable(RoomSummaryDTO room); // 0x00000001802F22D0-0x00000001802F2300
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x00000001802F2150-0x00000001802F2210
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x00000001802F2210-0x00000001802F22D0
}

