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
public class FusionPetRowUI : MonoBehaviour // TypeDefIndex: 2310
{
	// Fields
	[SerializeField]
	private Image imgtPet; // 0x20
	[SerializeField]
	private Image imgGlow; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtRate; // 0x30
	[SerializeField]
	private Button btnSelect; // 0x38
	private Image _bg; // 0x40
	private Color _bgDefault; // 0x48
	private float _glowDefaultAlpha; // 0x58
	private bool _stateCaptured; // 0x5C
	private static readonly Color SelectedTint; // 0x00
	[CompilerGenerated]
	private long _UserPetId_k__BackingField; // 0x60
	[CompilerGenerated]
	private long _PetId_k__BackingField; // 0x68
	[CompilerGenerated]
	private string _PetName_k__BackingField; // 0x70

	// Properties
	public long UserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039E720-0x000000018039E730 0x00000001803C6060-0x00000001803C6070
	public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456F0-0x0000000180345700 0x00000001803C6070-0x00000001803C6080
	public string PetName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6080-0x00000001803C6090 0x000000018077D060-0x000000018077D0C0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 2311
	{
		// Fields
		public Action<FusionPetRowUI> onSelect; // 0x10
		public FusionPetRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x0000000180B18F40-0x0000000180B18F60
	}

	// Constructors
	public FusionPetRowUI(); // 0x0000000180B18E90-0x0000000180B18EF0
	static FusionPetRowUI(); // 0x0000000180B18EF0-0x0000000180B18F40

	// Methods
	private void Awake(); // 0x0000000180B170E0-0x0000000180B170F0
	private void AutoFindRefs(); // 0x0000000180B170F0-0x0000000180B17960
	public void Bind(long userPetId, long petId, string petName, int level, string elementType, int ratePercent, int bonusHp, int bonusAttack, int bonusMana, Action<FusionPetRowUI> onSelect, int effectiveRate = 0 /* Metadata: 0x005F0AFA */, int pityBonus = 0 /* Metadata: 0x005F0AFB */); // 0x0000000180B17960-0x0000000180B181B0
	private void EnsureClickable(); // 0x0000000180B181B0-0x0000000180B18750
	public void SetInteractable(bool on); // 0x0000000180B18750-0x0000000180B18860
	public void SetSelected(bool selected); // 0x0000000180B18860-0x0000000180B18CB0
	private void CaptureDefaultState(); // 0x0000000180B18CB0-0x0000000180B18E90
}

