/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class FusionPetRowUI : MonoBehaviour // TypeDefIndex: 1944
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
	public long UserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180385A10-0x0000000180385A20 0x0000000180704310-0x0000000180704320
	public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180365440-0x0000000180365450 0x000000018050D100-0x000000018050D110
	public string PetName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018046EFB0-0x000000018046EFC0 0x000000018050D110-0x000000018050D120

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1945
	{
		// Fields
		public Action<FusionPetRowUI> onSelect; // 0x10
		public FusionPetRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180710620-0x0000000180710640
	}

	// Constructors
	public FusionPetRowUI(); // 0x00000001807042F0-0x0000000180704310
	static FusionPetRowUI(); // 0x00000001807042B0-0x00000001807042F0

	// Methods
	private void Awake(); // 0x0000000180703730-0x0000000180703740
	private void AutoFindRefs(); // 0x00000001807034A0-0x0000000180703730
	public void Bind(long userPetId, long petId, string petName, int level, string elementType, int ratePercent, int bonusHp, int bonusAttack, int bonusMana, Action<FusionPetRowUI> onSelect); // 0x0000000180703740-0x0000000180703AE0
	private void EnsureClickable(); // 0x0000000180703BC0-0x0000000180703EF0
	public void SetInteractable(bool on); // 0x0000000180703EF0-0x0000000180703F80
	public void SetSelected(bool selected); // 0x0000000180703F80-0x00000001807042B0
	private void CaptureDefaultState(); // 0x0000000180703AE0-0x0000000180703BC0
}

