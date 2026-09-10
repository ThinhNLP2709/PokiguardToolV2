/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ToggleManager : MonoBehaviour // TypeDefIndex: 1788
{
	// Fields
	[Header("Toggle Settings")]
	public GameObject listToggle; // 0x20
	public GameObject togglePrefab; // 0x28
	[Header("Display Settings")]
	public GameObject selectedImagePrefab; // 0x30
	public Transform[] displayPanel; // 0x38
	public int maxSelected; // 0x40
	internal int LocalSlot; // 0x44
	[Header("Colors")]
	public Color selectedColor; // 0x48
	public Color defaultColor; // 0x58
	private List<CardSelectionData> selectedCardsList; // 0x68
	private Dictionary<int, int> selectedCountByCardId; // 0x70
	private Dictionary<int, Toggle> togglesByCardId; // 0x78
	private Dictionary<string, GameObject> selectedImagesBySelectionId; // 0x80
	private HashSet<int> selectedAttackCardIds; // 0x88
	private bool isRestoring; // 0x90
	[CompilerGenerated]
	private Action OnSelectionChanged; // 0x98

	// Events
	public event Action OnSelectionChanged {
		add; // 0x0000000180696F50-0x0000000180697000
		remove; // 0x0000000180697000-0x00000001806970B0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1789
	{
		// Fields
		public ToggleManager __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RegisterToggle_b__0(bool _p0_); // 0x000000018069C140-0x000000018069C170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1790
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RejectShake_b__0(); // 0x000000018069C170-0x000000018069C210
	}

	// Constructors
	public ToggleManager(); // 0x0000000180696DA0-0x0000000180696F50

	// Methods
	private void Start(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void RegisterToggle(Toggle toggle); // 0x00000001806956A0-0x0000000180695930
	public void RestoreToggle(Toggle toggle, bool isOn); // 0x0000000180696430-0x0000000180696610
	private bool IsAttackCard(CardData card); // 0x0000000180694C10-0x0000000180694C80
	private void OnToggleChanged(Toggle changedToggle); // 0x0000000180694C80-0x0000000180695020
	private void RejectShake(Toggle toggle); // 0x0000000180695930-0x0000000180695B20
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x0000000180695020-0x00000001806952A0
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x0000000180696020-0x0000000180696430
	private void RebuildToggleIndex(); // 0x00000001806952A0-0x00000001806956A0
	private void AddSelectedImage(Toggle toggle); // 0x0000000180693FF0-0x0000000180694140
	private void AddSelectedImage(CardSelectionData selectionData); // 0x0000000180694140-0x0000000180694600
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x0000000180695B20-0x0000000180695D70
	private void UpdateToggleInteractable(Toggle toggle); // 0x0000000180696B20-0x0000000180696DA0
	private void UpdateToggleCountText(int cardId); // 0x0000000180696760-0x0000000180696B20
	private void UpdateToggleColor(Toggle toggle); // 0x0000000180696610-0x0000000180696760
	public List<CardData> GetSelectedCards(); // 0x0000000180694A60-0x0000000180694C10
	public int GetSelectedCount(); // 0x00000001806729A0-0x00000001806729C0
	public void ResetAllToggles(); // 0x0000000180695D70-0x0000000180696020
	public void ClearAllToggles(); // 0x0000000180694600-0x0000000180694A60
}

