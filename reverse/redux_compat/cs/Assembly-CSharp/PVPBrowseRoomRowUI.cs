/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class PVPBrowseRoomRowUI : MonoBehaviour // TypeDefIndex: 202
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
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 203
	{
		// Fields
		public Action<string> onJoin; // 0x10
		public PVPBrowseRoomRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180691EE0-0x0000000180691F20
	}

	// Constructors
	public PVPBrowseRoomRowUI(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001806887E0-0x00000001806887F0
	private void AutoFindRefs(); // 0x0000000180688530-0x00000001806887E0
	public void Bind(RoomSummaryDTO room, int fullAtPlayerCount, Action<string> onJoin); // 0x00000001806887F0-0x0000000180688E50
	private void Update(); // 0x0000000180689060-0x00000001806892B0
	private void OnDisable(); // 0x00000001805FB020-0x00000001805FB030
	private static string BuildDisplayId(string roomId); // 0x0000000180688E50-0x0000000180688F00
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x0000000180688F00-0x0000000180688FC0
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x0000000180688FC0-0x0000000180689060
	private static void ApplyWeaponBadge(Image petIcon, int imageId, string rarity); // 0x0000000180688450-0x0000000180688530
	private static void ApplyPetIcon(Image img, int petId); // 0x0000000180688320-0x0000000180688450
}

