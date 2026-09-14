/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class CoopRoomCardUI : MonoBehaviour // TypeDefIndex: 15
{
	// Fields
	private const int COOP_CAP_FALLBACK = 3; // Metadata: 0x005EE6D6
	public const float CARD_W = 318f; // Metadata: 0x005EE6D7
	public const float CARD_H = 143f; // Metadata: 0x005EE6DB
	private const float ICON_X = 8f; // Metadata: 0x005EE6DF
	private const float ICON_Y = 10f; // Metadata: 0x005EE6E3
	private const float ICON_D = 86f; // Metadata: 0x005EE6E7
	private const float ICON_PAD = 6f; // Metadata: 0x005EE6EB
	private const float COL_X = 102f; // Metadata: 0x005EE6EF
	private const float NAME_Y = 8f; // Metadata: 0x005EE6F3
	private const float NAME_W = 208f; // Metadata: 0x005EE6F7
	private const float NAME_H = 36f; // Metadata: 0x005EE6FB
	private const float NAME_FS = 26f; // Metadata: 0x005EE6FF
	private const float LV_Y = 46f; // Metadata: 0x005EE703
	private const float LV_W = 100f; // Metadata: 0x005EE707
	private const float LV_H = 28f; // Metadata: 0x005EE70B
	private const float LV_FS = 23f; // Metadata: 0x005EE70F
	private const float CODE_X = 206f; // Metadata: 0x005EE713
	private const float CODE_W = 104f; // Metadata: 0x005EE717
	private const float CODE_FS = 21f; // Metadata: 0x005EE71B
	private const float OWNER_Y = 76f; // Metadata: 0x005EE71F
	private const float OWNER_W = 208f; // Metadata: 0x005EE723
	private const float OWNER_H = 28f; // Metadata: 0x005EE727
	private const float OWNER_FS = 21f; // Metadata: 0x005EE72B
	private const float BAR_X = 10f; // Metadata: 0x005EE72F
	private const float BAR_Y = 106f; // Metadata: 0x005EE733
	private const float BAR_W = 298f; // Metadata: 0x005EE737
	private const float BAR_H = 31f; // Metadata: 0x005EE73B
	private const float BAR_FS = 23f; // Metadata: 0x005EE73F
	private const float SEAT_W = 84f; // Metadata: 0x005EE743
	private const float SEAT_PAD = 10f; // Metadata: 0x005EE747
	private const float SEAT_FS = 22f; // Metadata: 0x005EE74B
	private const int OWNER_MAX_CHARS = 16; // Metadata: 0x005EE74F
	private const int BOSS_MAX_CHARS = 22; // Metadata: 0x005EE750
	private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x005EE751
	private static readonly Color LOCK_TINT; // 0x00
	private static readonly Color SEAT_FREE; // 0x10
	private static readonly Color SEAT_FULL; // 0x20
	private Image _bg; // 0x20
	private Button _button; // 0x28
	private Image _imgBoss; // 0x30
	private UnityEngine.UI.Text _txtBoss; // 0x38
	private UnityEngine.UI.Text _txtSeat; // 0x40
	private UnityEngine.UI.Text _txtLevel; // 0x48
	private UnityEngine.UI.Text _txtCode; // 0x50
	private UnityEngine.UI.Text _txtOwner; // 0x58
	private Image _barState; // 0x60
	private UnityEngine.UI.Text _txtState; // 0x68
	private Image _imgLock; // 0x70
	private string _roomId; // 0x78
	private int _enemyPetId; // 0x80
	private int _enemyPetLevel; // 0x84
	private Action<string, int, int> _onJoin; // 0x88
	private static Sprite _blankIcon; // 0x30

	// Constructors
	public CoopRoomCardUI(); // 0x000000018028A560-0x000000018028A5B0
	static CoopRoomCardUI(); // 0x000000018029AA40-0x000000018029AAF0

	// Methods
	public static CoopRoomCardUI Create(Transform parent, int index); // 0x0000000180298270-0x00000001802983D0
	private void Build(); // 0x00000001802983D0-0x0000000180299200
	public void Bind(RoomSummaryDTO room, Action<string, int, int> onJoin); // 0x0000000180299200-0x0000000180299BB0
	private void ApplyBossIcon(int petId); // 0x0000000180299BB0-0x0000000180299EA0
	private static string ShortCode(string roomId); // 0x0000000180299EA0-0x000000018029A010
	private void SetState(string label, Color tint); // 0x000000018029A010-0x000000018029A1F0
	private void OnClicked(); // 0x000000018029A1F0-0x000000018029A330
	public static bool IsJoinable(RoomSummaryDTO room); // 0x000000018029A330-0x000000018029A360
	private static Sprite BlankIcon(); // 0x000000018029A360-0x000000018029A770
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x000000018029A770-0x000000018029A980
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x000000018029A980-0x000000018029AA40
}

