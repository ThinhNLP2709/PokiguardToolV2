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
public class PetShardItemUI : MonoBehaviour // TypeDefIndex: 677
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
	public long PetId { get; } // 0x0000000180316960-0x0000000180316970 
	public bool CanExchange { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018030D9D0-0x000000018030D9E0 0x00000001803CB1F0-0x00000001803CB200

	// Constructors
	public PetShardItemUI(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001803CA830-0x00000001803CA840
	private void AutoWire(); // 0x00000001803CA580-0x00000001803CA830
	private Image FindImage(string n); // 0x00000001803CA850-0x00000001803CA900
	private UnityEngine.UI.Text FindText(string n); // 0x00000001803CA900-0x00000001803CA9B0
	public void SetData(PetShardDTO dto, int maxStar = 6 /* Metadata: 0x0064C753 */, int exchangeCost = 0 /* Metadata: 0x0064C754 */); // 0x00000001803CAA80-0x00000001803CACF0
	private void ApplyExchangeState(PetShardDTO dto, int exchangeCost); // 0x00000001803CA180-0x00000001803CA580
	private void HideExchange(); // 0x00000001803CA9B0-0x00000001803CAA80
	private void StartPulse(); // 0x00000001803CAF60-0x00000001803CB100
	private void StopPulse(); // 0x00000001803CB100-0x00000001803CB1F0
	public void CancelFx(); // 0x00000001803CA840-0x00000001803CA850
	private void OnDisable(); // 0x00000001803CA840-0x00000001803CA850
	public void SetSimple(long petId, string petName, int amount); // 0x00000001803CACF0-0x00000001803CAF60
}

