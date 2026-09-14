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
public class CoopRoomRowUI : MonoBehaviour // TypeDefIndex: 19
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
	private const int COOP_CAP_FALLBACK = 3; // Metadata: 0x005ED51E

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 20
	{
		// Fields
		public Action<string, int, int> onJoin; // 0x10
		public int enemyPetId; // 0x18
		public int enemyPetLevel; // 0x1C
		public string capturedId; // 0x20

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001802A5150-0x00000001802A5190
	}

	// Constructors
	public CoopRoomRowUI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001802A3460-0x00000001802A3470
	private void AutoFindRefs(); // 0x00000001802A3470-0x00000001802A4190
	public void Bind(RoomSummaryDTO room, Action<string, int, int> onJoin); // 0x00000001802A4190-0x00000001802A4E80
	private static int GetPropInt(Dictionary<string, object> props, string key); // 0x00000001802A4E80-0x00000001802A5090
	private static string GetPropString(Dictionary<string, object> props, string key); // 0x00000001802A5090-0x00000001802A5150
}

