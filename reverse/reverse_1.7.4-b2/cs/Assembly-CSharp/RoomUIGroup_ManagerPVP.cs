/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class RoomUIGroup_ManagerPVP : MonoBehaviour // TypeDefIndex: 239
{
	// Fields
	internal static RoomUIGroup_ManagerPVP Instance; // 0x00
	[Header("Slots (index 0-1 = Team A, 2-3 = Team B)")]
	public PlayerUISlotPVP[] slots; // 0x20
	private const int MAX_SLOT = 4; // Metadata: 0x0068AD77

	// Constructors
	public RoomUIGroup_ManagerPVP(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x000000018084AC70-0x000000018084ACF0
	private void ScanSlots(); // 0x000000018084AE80-0x000000018084B0C0
	public void SetPlayers(List<PlayerUIModel> models); // 0x000000018084B0C0-0x000000018084B1E0
	public Sprite LoadAvatar(int avtId); // 0x000000018084ACF0-0x000000018084ADA0
	public Sprite LoadLevelFrame(int level); // 0x000000018084ADA0-0x000000018084ADF0
	public Sprite LoadPetIcon(int petId); // 0x000000018084ADF0-0x000000018084AE80
}

