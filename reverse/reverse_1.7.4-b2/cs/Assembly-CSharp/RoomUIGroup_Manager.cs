/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class RoomUIGroup_Manager : MonoBehaviour // TypeDefIndex: 63
{
	// Fields
	internal static RoomUIGroup_Manager Instance; // 0x00
	public PlayerUISlot[] slots; // 0x20
	private const int MAX_SLOT = 3; // Metadata: 0x0068AA96
	private static readonly Dictionary<string, Sprite> _spriteCache; // 0x08

	// Constructors
	public RoomUIGroup_Manager(); // 0x00000001802EBA70-0x00000001802EBAF0
	static RoomUIGroup_Manager(); // 0x0000000180421EF0-0x0000000180421F80

	// Methods
	private void Awake(); // 0x00000001804215A0-0x0000000180421630
	[ContextMenu("UpdateSlots")]
	public void CallUpdate(); // 0x0000000180421630-0x00000001804216A0
	private void ScanSlots(); // 0x0000000180421BA0-0x0000000180421DE0
	public void SetPlayers(List<PlayerUIModel> models); // 0x0000000180421DE0-0x0000000180421EF0
	private static Sprite LoadCached(string path); // 0x00000001804217F0-0x0000000180421A10
	public Sprite LoadAvatar(int avtId); // 0x00000001804216A0-0x00000001804217F0
	public Sprite LoadLevelFrame(int level); // 0x0000000180421A10-0x0000000180421A60
	public Sprite LoadPetIcon(int petId); // 0x0000000180421A60-0x0000000180421BA0
}

