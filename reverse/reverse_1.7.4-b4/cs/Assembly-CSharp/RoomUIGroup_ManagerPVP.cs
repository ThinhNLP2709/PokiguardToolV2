/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class RoomUIGroup_ManagerPVP : MonoBehaviour // TypeDefIndex: 239
{
	// Fields
	internal static RoomUIGroup_ManagerPVP Instance; // 0x00
	[Header("Slots (index 0-1 = Team A, 2-3 = Team B)")]
	public PlayerUISlotPVP[] slots; // 0x20
	private const int MAX_SLOT = 4; // Metadata: 0x005EED72

	// Constructors
	public RoomUIGroup_ManagerPVP(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180D60CD0-0x0000000180D60D90
	private void ScanSlots(); // 0x0000000180D60D90-0x0000000180D61280
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180D61280-0x0000000180D61420
	public Sprite LoadAvatar(int avtId); // 0x0000000180D61420-0x0000000180D61510
	public Sprite LoadLevelFrame(int level); // 0x0000000180D61510-0x0000000180D61560
	public Sprite LoadPetIcon(int petId); // 0x0000000180D61560-0x0000000180D61640
}

