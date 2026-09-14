/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class RoomUIGroup_ManagerPVP : MonoBehaviour // TypeDefIndex: 239
{
	// Fields
	internal static RoomUIGroup_ManagerPVP Instance; // 0x00
	[Header("Slots (index 0-1 = Team A, 2-3 = Team B)")]
	public PlayerUISlotPVP[] slots; // 0x20
	private const int MAX_SLOT = 4; // Metadata: 0x005ED9A2

	// Constructors
	public RoomUIGroup_ManagerPVP(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180D52F10-0x0000000180D52FD0
	private void ScanSlots(); // 0x0000000180D52FD0-0x0000000180D534C0
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180D534C0-0x0000000180D53660
	public Sprite LoadAvatar(int avtId); // 0x0000000180D53660-0x0000000180D53750
	public Sprite LoadLevelFrame(int level); // 0x0000000180D53750-0x0000000180D537A0
	public Sprite LoadPetIcon(int petId); // 0x0000000180D537A0-0x0000000180D53880
}

