/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ToggleManager : MonoBehaviour // TypeDefIndex: 2150
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
		add; // 0x0000000180A1DEA0-0x0000000180A1DFA0
		remove; // 0x0000000180A1DFA0-0x0000000180A1E0A0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2151
	{
		// Fields
		public ToggleManager __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterToggle_b__0(bool _p0_); // 0x0000000180A223F0-0x0000000180A22420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2152
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RejectShake_b__0(); // 0x0000000180A22420-0x0000000180A22590
	}

	// Constructors
	public ToggleManager(); // 0x0000000180A22080-0x0000000180A223F0

	// Methods
	public void RegisterToggle(Toggle toggle); // 0x0000000180A1E0A0-0x0000000180A1E510
	public void RestoreToggle(Toggle toggle, bool isOn); // 0x0000000180A1E510-0x0000000180A1E650
	private bool IsAttackCard(CardData card); // 0x0000000180A1E650-0x0000000180A1E6F0
	private void OnToggleChanged(Toggle changedToggle); // 0x0000000180A1E6F0-0x0000000180A1EB40
	private void RejectShake(Toggle toggle); // 0x0000000180A1EB40-0x0000000180A1EE50
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x0000000180A1EE50-0x0000000180A1F240
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x0000000180A1F240-0x0000000180A1F800
	private void RebuildToggleIndex(); // 0x0000000180A1F800-0x0000000180A1FDF0
	private void AddSelectedImage(Toggle toggle); // 0x0000000180A1FDF0-0x0000000180A200F0
	private void AddSelectedImage(CardSelectionData selectionData); // 0x0000000180A200F0-0x0000000180A20780
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x0000000180A20780-0x0000000180A20A70
	private void UpdateToggleInteractable(Toggle toggle); // 0x0000000180A20A70-0x0000000180A20D00
	private void UpdateToggleCountText(int cardId); // 0x0000000180A20D00-0x0000000180A21150
	private void UpdateToggleColor(Toggle toggle); // 0x0000000180A21150-0x0000000180A212A0
	public List<CardData> GetSelectedCards(); // 0x0000000180A212A0-0x0000000180A21490
	public int GetSelectedCount(); // 0x0000000180A086A0-0x0000000180A086C0
	public void ResetAllToggles(); // 0x0000000180A21490-0x0000000180A21950
	public void ClearAllToggles(); // 0x0000000180A21950-0x0000000180A22080
}

