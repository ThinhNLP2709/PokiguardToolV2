/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class TowerFloorItem : MonoBehaviour // TypeDefIndex: 769
{
	// Fields
	[Header("N\u00FAt r\u01B0\u01A1ng")]
	public Button btnChest; // 0x20
	public Image imgChest; // 0x28
	[Header("Ch\u1EEF")]
	public UnityEngine.UI.Text txtFloor; // 0x30
	public GameObject received; // 0x38
	public UnityEngine.UI.Text txtLevel; // 0x40
	[Header("Boss")]
	public Image imgBoss; // 0x48
	public Animator animBoss; // 0x50
	private int _animPetBound; // 0x58
	[Header("Sprite r\u01B0\u01A1ng (0 = \u0111\u00F3ng b\u1EADc 1, 1 = \u0110\u00C3 NH\u1EACN, 2 = b\u1EADc 2, 3 = b\u1EADc 3)")]
	public Sprite chestClosed; // 0x60
	public Sprite chestOpened; // 0x68
	public Sprite chestTier2; // 0x70
	public Sprite chestTier3; // 0x78
	private TowerFloorInfo _data; // 0x80
	private Action<RectTransform, TowerFloorInfo> _onShowGift; // 0x88

	// Properties
	public int BossPetId { get; } // 0x00000001803FEE20-0x00000001803FEE40 

	// Constructors
	public TowerFloorItem(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Init(TowerFloorInfo info, Action<RectTransform, TowerFloorInfo> onShowGift); // 0x00000001803FE6E0-0x00000001803FEBC0
	private void ApplyChestSprite(TowerFloorInfo info); // 0x00000001803FE130-0x00000001803FE270
	private void ApplyBossIcon(int petId); // 0x00000001803FE020-0x00000001803FE130
	private static Sprite LoadBossIcon(int petId); // 0x00000001803FEBC0-0x00000001803FEC50
	public void BindBossClips(int petId, AnimationClip[] clips); // 0x00000001803FE3B0-0x00000001803FE6E0
	private void ApplyStaticIconKeepImage(int petId); // 0x00000001803FE270-0x00000001803FE3B0
	public void ReleaseBossAnim(); // 0x00000001803FECF0-0x00000001803FEE20
	private void OnDisable(); // 0x00000001803FEC50-0x00000001803FEC60
	private void RaiseShowGift(); // 0x00000001803FEC60-0x00000001803FECF0
}

