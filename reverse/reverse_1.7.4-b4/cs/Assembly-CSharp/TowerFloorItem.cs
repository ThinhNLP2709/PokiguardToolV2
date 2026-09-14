/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class TowerFloorItem : MonoBehaviour // TypeDefIndex: 1330
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
	public int BossPetId { get; } // 0x000000018075B930-0x000000018075B950 

	// Constructors
	public TowerFloorItem(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Init(TowerFloorInfo info, Action<RectTransform, TowerFloorInfo> onShowGift); // 0x000000018075B950-0x000000018075BF60
	private void ApplyChestSprite(TowerFloorInfo info); // 0x000000018075BF60-0x000000018075C270
	private void ApplyBossIcon(int petId); // 0x000000018075C270-0x000000018075C4D0
	private static Sprite LoadBossIcon(int petId); // 0x000000018075C4D0-0x000000018075C5C0
	public void BindBossClips(int petId, AnimationClip[] clips); // 0x000000018075C5C0-0x000000018075CAD0
	private void ApplyStaticIconKeepImage(int petId); // 0x000000018075CAD0-0x000000018075CED0
	public void ReleaseBossAnim(); // 0x000000018075CED0-0x000000018075D2A0
	private void OnDisable(); // 0x000000018075D2A0-0x000000018075D2B0
	private void RaiseShowGift(); // 0x000000018075D2B0-0x000000018075D340
}

