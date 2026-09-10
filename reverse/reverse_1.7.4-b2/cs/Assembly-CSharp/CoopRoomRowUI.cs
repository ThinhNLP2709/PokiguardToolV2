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
public class CoopRoomRowUI : MonoBehaviour // TypeDefIndex: 16
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtRoomId; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtOwner; // 0x28
	[SerializeField]
	private Image imgBoss; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtBossName; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtMembers; // 0x40
	[SerializeField]
	private Image imgLock; // 0x48
	[SerializeField]
	private Button btnJoin; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text btnJoinLabel; // 0x58
	private const int COOP_CAP_FALLBACK = 3; // Metadata: 0x0068A8C8

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 17
	{
		// Fields
		public Action<string, int, int> onJoin; // 0x10
		public int enemyPetId; // 0x18
		public int enemyPetLevel; // 0x1C
		public string capturedId; // 0x20

		// Constructors
		public __c__DisplayClass11_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180300900-0x0000000180300940
	}

	// Constructors
	public CoopRoomRowUI(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001802F61F0-0x00000001802F6200
	private void AutoFindRefs(); // 0x00000001802F5E00-0x00000001802F61F0
	public void Bind(RoomSummaryDTO room, Action<string, int, int> onJoin); // 0x00000001802F6200-0x00000001802F6AC0
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x00000001802F6AC0-0x00000001802F6B80
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x00000001802F6B80-0x00000001802F6C40
}

