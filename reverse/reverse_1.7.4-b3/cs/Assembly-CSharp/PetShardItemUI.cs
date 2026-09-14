/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class PetShardItemUI : MonoBehaviour // TypeDefIndex: 1130
{
	// Fields
	[Header("\u1EA2nh")]
	public Image imgPet; // 0x20
	[Tooltip("L\u1EDBp ph\u1EE7 m\u1EA3nh \u2014 PH\u1EA2I \u0111\u1EE9ng SAU imgPet trong hierarchy \u0111\u1EC3 v\u1EBD \u0111\u00E8 l\u00EAn.")]
	public Image imgPiece; // 0x28
	[Header("Ch\u1EEF")]
	public UnityEngine.UI.Text txtCount; // 0x30
	public UnityEngine.UI.Text txtName; // 0x38
	[Header("Ph\u1EE5")]
	public PetStarRowUI starRow; // 0x40
	[Tooltip("Vi\u1EC1n s\u00E1ng khi \u0111\u00E3 \u0111\u1EE7 m\u1EA3nh \u0111\u1EC3 n\u00E2ng sao ngay HO\u1EB6C \u0111\u00E3 \u0111\u1EE7 m\u1EA3nh \u0111\u1EC3 \u0111\u1ED5i pet.")]
	public Outline readyOutline; // 0x48
	[Header("\u0110\u1ED5i pet \u2014 ch\u1EC9 hi\u1EC7n v\u1EDBi pet CH\u01AFA s\u1EDF h\u1EEFu")]
	public Button btnExchange; // 0x50
	public UnityEngine.UI.Text txtExchange; // 0x58
	private bool _wired; // 0x60
	private long _petId; // 0x68
	private bool _pulsing; // 0x70
	[CompilerGenerated]
	private bool _CanExchange_k__BackingField; // 0x71

	// Properties
	public long PetId { get; } // 0x00000001803456F0-0x0000000180345700 
	public bool CanExchange { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8640-0x00000001802A8650 0x00000001802A8650-0x00000001802A8660

	// Constructors
	public PetShardItemUI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180693910-0x0000000180693920
	private void AutoWire(); // 0x0000000180693920-0x0000000180694230
	private Image FindImage(string n); // 0x0000000180694230-0x00000001806943C0
	private UnityEngine.UI.Text FindText(string n); // 0x00000001806943C0-0x0000000180694550
	public void SetData(PetShardDTO dto, int maxStar = 6 /* Metadata: 0x005EF42E */, int exchangeCost = 0 /* Metadata: 0x005EF42F */); // 0x0000000180694550-0x0000000180694A00
	private void ApplyExchangeState(PetShardDTO dto, int exchangeCost); // 0x0000000180694A00-0x0000000180694ED0
	private void HideExchange(); // 0x0000000180694ED0-0x0000000180695140
	private void StartPulse(); // 0x0000000180695140-0x00000001806953D0
	private void StopPulse(); // 0x00000001806953D0-0x00000001806955F0
	public void CancelFx(); // 0x00000001806955F0-0x0000000180695600
	private void OnDisable(); // 0x00000001806955F0-0x0000000180695600
	public void SetSimple(long petId, string petName, int amount); // 0x0000000180695600-0x0000000180695A50
}

