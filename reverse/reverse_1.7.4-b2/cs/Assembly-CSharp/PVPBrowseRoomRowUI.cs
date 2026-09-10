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
public class PVPBrowseRoomRowUI : MonoBehaviour // TypeDefIndex: 224
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text roomNameText; // 0x20
	[SerializeField]
	private Image imgUser1Pet; // 0x28
	[SerializeField]
	private Image imgUser12Pet; // 0x30
	[SerializeField]
	private Button btnJoin; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text btnJoinLabel; // 0x40
	private string _roomId; // 0x48
	private bool _twinkleActive; // 0x50
	private float _twinkleTimer; // 0x54
	private ColorBlock _originalColors; // 0x58

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 225
	{
		// Fields
		public Action<string> onJoin; // 0x10
		public PVPBrowseRoomRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180840D10-0x0000000180840D50
	}

	// Constructors
	public PVPBrowseRoomRowUI(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180833850-0x0000000180833860
	private void AutoFindRefs(); // 0x00000001808335A0-0x0000000180833850
	public void Bind(RoomSummaryDTO room, int fullAtPlayerCount, Action<string> onJoin); // 0x0000000180833860-0x0000000180833EC0
	private void Update(); // 0x00000001808340D0-0x0000000180834320
	private void OnDisable(); // 0x000000018072EF10-0x000000018072EF20
	private static string BuildDisplayId(string roomId); // 0x0000000180833EC0-0x0000000180833F70
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x0000000180833F70-0x0000000180834030
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x0000000180834030-0x00000001808340D0
	private static void ApplyWeaponBadge(Image petIcon, int imageId, string rarity); // 0x00000001808334C0-0x00000001808335A0
	private static void ApplyPetIcon(Image img, int petId); // 0x0000000180833390-0x00000001808334C0
}

