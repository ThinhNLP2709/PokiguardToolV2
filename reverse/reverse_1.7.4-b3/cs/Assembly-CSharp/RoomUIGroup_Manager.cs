/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class RoomUIGroup_Manager : MonoBehaviour // TypeDefIndex: 63
{
	// Fields
	internal static RoomUIGroup_Manager Instance; // 0x00
	public PlayerUISlot[] slots; // 0x20
	private const int MAX_SLOT = 3; // Metadata: 0x005ED6B3
	private static readonly Dictionary<string, Sprite> _spriteCache; // 0x08

	// Constructors
	public RoomUIGroup_Manager(); // 0x000000018028A560-0x000000018028A5B0
	static RoomUIGroup_Manager(); // 0x0000000180466B90-0x0000000180466C70

	// Methods
	private void Awake(); // 0x0000000180465BE0-0x0000000180465CB0
	[ContextMenu("UpdateSlots")]
	public void CallUpdate(); // 0x0000000180465CB0-0x0000000180465D10
	private void ScanSlots(); // 0x0000000180465D10-0x0000000180466200
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180466200-0x0000000180466310
	private static Sprite LoadCached(string path); // 0x0000000180466310-0x0000000180466660
	public Sprite LoadAvatar(int avtId); // 0x0000000180466660-0x00000001804668E0
	public Sprite LoadLevelFrame(int level); // 0x00000001804668E0-0x0000000180466930
	public Sprite LoadPetIcon(int petId); // 0x0000000180466930-0x0000000180466B90
}

