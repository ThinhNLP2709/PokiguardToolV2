/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class RoomUIGroup_ManagerPVP : MonoBehaviour // TypeDefIndex: 213
{
	// Fields
	internal static RoomUIGroup_ManagerPVP Instance; // 0x00
	[Header("Slots (index 0-1 = Team A, 2-3 = Team B)")]
	public PlayerUISlotPVP[] slots; // 0x20
	private const int MAX_SLOT = 4; // Metadata: 0x0064C05F

	// Constructors
	public RoomUIGroup_ManagerPVP(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018069D750-0x000000018069D7D0
	private void ScanSlots(); // 0x000000018069D960-0x000000018069DBA0
	public void SetPlayers(List<PlayerUIModel> models); // 0x000000018069DBA0-0x000000018069DCC0
	public Sprite LoadAvatar(int avtId); // 0x000000018069D7D0-0x000000018069D880
	public Sprite LoadLevelFrame(int level); // 0x000000018069D880-0x000000018069D8D0
	public Sprite LoadPetIcon(int petId); // 0x000000018069D8D0-0x000000018069D960
}

