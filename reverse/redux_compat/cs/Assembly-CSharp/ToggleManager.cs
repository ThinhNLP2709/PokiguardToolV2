/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ToggleManager : MonoBehaviour // TypeDefIndex: 1525
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
		add; // 0x0000000180579060-0x0000000180579110
		remove; // 0x0000000180579110-0x00000001805791C0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1526
	{
		// Fields
		public ToggleManager __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RegisterToggle_b__0(bool _p0_); // 0x000000018057DFE0-0x000000018057E010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1527
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RejectShake_b__0(); // 0x000000018057E010-0x000000018057E0B0
	}

	// Constructors
	public ToggleManager(); // 0x0000000180578EB0-0x0000000180579060

	// Methods
	private void Start(); // 0x00000001802E76C0-0x00000001802E76D0
	public void RegisterToggle(Toggle toggle); // 0x00000001805777B0-0x0000000180577A40
	public void RestoreToggle(Toggle toggle, bool isOn); // 0x0000000180578540-0x0000000180578720
	private bool IsAttackCard(CardData card); // 0x0000000180576D20-0x0000000180576D90
	private void OnToggleChanged(Toggle changedToggle); // 0x0000000180576D90-0x0000000180577130
	private void RejectShake(Toggle toggle); // 0x0000000180577A40-0x0000000180577C30
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x0000000180577130-0x00000001805773B0
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x0000000180578130-0x0000000180578540
	private void RebuildToggleIndex(); // 0x00000001805773B0-0x00000001805777B0
	private void AddSelectedImage(Toggle toggle); // 0x00000001805760E0-0x0000000180576230
	private void AddSelectedImage(CardSelectionData selectionData); // 0x0000000180576230-0x00000001805766F0
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x0000000180577C30-0x0000000180577E80
	private void UpdateToggleInteractable(Toggle toggle); // 0x0000000180578C30-0x0000000180578EB0
	private void UpdateToggleCountText(int cardId); // 0x0000000180578870-0x0000000180578C30
	private void UpdateToggleColor(Toggle toggle); // 0x0000000180578720-0x0000000180578870
	public List<CardData> GetSelectedCards(); // 0x0000000180576B50-0x0000000180576D00
	public int GetSelectedCount(); // 0x0000000180576D00-0x0000000180576D20
	public void ResetAllToggles(); // 0x0000000180577E80-0x0000000180578130
	public void ClearAllToggles(); // 0x00000001805766F0-0x0000000180576B50
}

