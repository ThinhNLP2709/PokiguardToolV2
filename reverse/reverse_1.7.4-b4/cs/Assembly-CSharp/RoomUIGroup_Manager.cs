/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class RoomUIGroup_Manager : MonoBehaviour // TypeDefIndex: 63
{
	// Fields
	internal static RoomUIGroup_Manager Instance; // 0x00
	public PlayerUISlot[] slots; // 0x20
	private const int MAX_SLOT = 3; // Metadata: 0x005EEA83
	private static readonly Dictionary<string, Sprite> _spriteCache; // 0x08

	// Constructors
	public RoomUIGroup_Manager(); // 0x000000018028A560-0x000000018028A5B0
	static RoomUIGroup_Manager(); // 0x0000000180467E00-0x0000000180467EE0

	// Methods
	private void Awake(); // 0x0000000180466E50-0x0000000180466F20
	[ContextMenu("UpdateSlots")]
	public void CallUpdate(); // 0x0000000180466F20-0x0000000180466F80
	private void ScanSlots(); // 0x0000000180466F80-0x0000000180467470
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180467470-0x0000000180467580
	private static Sprite LoadCached(string path); // 0x0000000180467580-0x00000001804678D0
	public Sprite LoadAvatar(int avtId); // 0x00000001804678D0-0x0000000180467B50
	public Sprite LoadLevelFrame(int level); // 0x0000000180467B50-0x0000000180467BA0
	public Sprite LoadPetIcon(int petId); // 0x0000000180467BA0-0x0000000180467E00
}

