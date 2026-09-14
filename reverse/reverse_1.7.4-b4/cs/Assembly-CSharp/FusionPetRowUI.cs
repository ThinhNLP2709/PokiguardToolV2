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
public class FusionPetRowUI : MonoBehaviour // TypeDefIndex: 2317
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
	public long UserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039E8F0-0x000000018039E900 0x00000001803C6D30-0x00000001803C6D40
	public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345810-0x0000000180345820 0x00000001803C6D40-0x00000001803C6D50
	public string PetName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D50-0x00000001803C6D60 0x000000018077EFB0-0x000000018077F010

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 2318
	{
		// Fields
		public Action<FusionPetRowUI> onSelect; // 0x10
		public FusionPetRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x0000000180B26120-0x0000000180B26140
	}

	// Constructors
	public FusionPetRowUI(); // 0x0000000180B26070-0x0000000180B260D0
	static FusionPetRowUI(); // 0x0000000180B260D0-0x0000000180B26120

	// Methods
	private void Awake(); // 0x0000000180B242C0-0x0000000180B242D0
	private void AutoFindRefs(); // 0x0000000180B242D0-0x0000000180B24B40
	public void Bind(long userPetId, long petId, string petName, int level, string elementType, int ratePercent, int bonusHp, int bonusAttack, int bonusMana, Action<FusionPetRowUI> onSelect, int effectiveRate = 0 /* Metadata: 0x005F1F11 */, int pityBonus = 0 /* Metadata: 0x005F1F12 */); // 0x0000000180B24B40-0x0000000180B25390
	private void EnsureClickable(); // 0x0000000180B25390-0x0000000180B25930
	public void SetInteractable(bool on); // 0x0000000180B25930-0x0000000180B25A40
	public void SetSelected(bool selected); // 0x0000000180B25A40-0x0000000180B25E90
	private void CaptureDefaultState(); // 0x0000000180B25E90-0x0000000180B26070
}

