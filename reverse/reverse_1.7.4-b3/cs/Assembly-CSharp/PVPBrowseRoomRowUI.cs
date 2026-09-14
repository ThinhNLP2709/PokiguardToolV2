/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x0000000180C91840-0x0000000180C91880
	}

	// Constructors
	public PVPBrowseRoomRowUI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180C8FAF0-0x0000000180C8FB00
	private void AutoFindRefs(); // 0x0000000180C8FB00-0x0000000180C903C0
	public void Bind(RoomSummaryDTO room, int fullAtPlayerCount, Action<string> onJoin); // 0x0000000180C903C0-0x0000000180C90D20
	private void Update(); // 0x0000000180C90D20-0x0000000180C90FC0
	private void OnDisable(); // 0x0000000180B8C980-0x0000000180B8C990
	private static string BuildDisplayId(string roomId); // 0x0000000180C90FC0-0x0000000180C91080
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x0000000180C91080-0x0000000180C91290
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x0000000180C91290-0x0000000180C91330
	private static void ApplyWeaponBadge(Image petIcon, int imageId, string rarity); // 0x0000000180C91330-0x0000000180C91550
	private static void ApplyPetIcon(Image img, int petId); // 0x0000000180C91550-0x0000000180C91840
}

