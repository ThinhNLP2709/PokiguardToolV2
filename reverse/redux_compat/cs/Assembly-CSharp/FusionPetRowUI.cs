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
public class FusionPetRowUI : MonoBehaviour // TypeDefIndex: 1671
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
	public long UserPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180333260-0x0000000180333490 0x00000001805D9F00-0x00000001805D9F10
	public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x000000018033EA60-0x000000018033EA70
	public string PetName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1672
	{
		// Fields
		public Action<FusionPetRowUI> onSelect; // 0x10
		public FusionPetRowUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Bind_b__0(); // 0x00000001805E8FD0-0x00000001805E8FF0
	}

	// Constructors
	public FusionPetRowUI(); // 0x00000001805D9EE0-0x00000001805D9F00
	static FusionPetRowUI(); // 0x00000001805D9EA0-0x00000001805D9EE0

	// Methods
	private void Awake(); // 0x00000001805D9320-0x00000001805D9330
	private void AutoFindRefs(); // 0x00000001805D9090-0x00000001805D9320
	public void Bind(long userPetId, long petId, string petName, int level, string elementType, int ratePercent, int bonusHp, int bonusAttack, int bonusMana, Action<FusionPetRowUI> onSelect); // 0x00000001805D9330-0x00000001805D96D0
	private void EnsureClickable(); // 0x00000001805D97B0-0x00000001805D9AE0
	public void SetInteractable(bool on); // 0x00000001805D9AE0-0x00000001805D9B70
	public void SetSelected(bool selected); // 0x00000001805D9B70-0x00000001805D9EA0
	private void CaptureDefaultState(); // 0x00000001805D96D0-0x00000001805D97B0
}

