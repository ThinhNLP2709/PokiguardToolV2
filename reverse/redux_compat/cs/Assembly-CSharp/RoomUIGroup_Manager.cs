/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class RoomUIGroup_Manager : MonoBehaviour // TypeDefIndex: 53
{
	// Fields
	internal static RoomUIGroup_Manager Instance; // 0x00
	public PlayerUISlot[] slots; // 0x20
	private const int MAX_SLOT = 3; // Metadata: 0x0064BF80
	private static readonly Dictionary<string, Sprite> _spriteCache; // 0x08

	// Constructors
	public RoomUIGroup_Manager(); // 0x00000001802E7A70-0x00000001802E7BC0
	static RoomUIGroup_Manager(); // 0x0000000180307240-0x00000001803072D0

	// Methods
	private void Awake(); // 0x0000000180306910-0x00000001803069A0
	[ContextMenu("UpdateSlots")]
	public void CallUpdate(); // 0x00000001803069A0-0x00000001803069F0
	private void ScanSlots(); // 0x0000000180306EF0-0x0000000180307130
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180307130-0x0000000180307240
	private static Sprite LoadCached(string path); // 0x0000000180306B40-0x0000000180306D60
	public Sprite LoadAvatar(int avtId); // 0x00000001803069F0-0x0000000180306B40
	public Sprite LoadLevelFrame(int level); // 0x0000000180306D60-0x0000000180306DB0
	public Sprite LoadPetIcon(int petId); // 0x0000000180306DB0-0x0000000180306EF0
}

