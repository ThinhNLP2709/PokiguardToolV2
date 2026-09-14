/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ToggleManager : MonoBehaviour // TypeDefIndex: 2152
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
		add; // 0x0000000180A21A10-0x0000000180A21B10
		remove; // 0x0000000180A21B10-0x0000000180A21C10
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2153
	{
		// Fields
		public ToggleManager __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterToggle_b__0(bool _p0_); // 0x0000000180A25F60-0x0000000180A25F90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2154
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RejectShake_b__0(); // 0x0000000180A25F90-0x0000000180A26100
	}

	// Constructors
	public ToggleManager(); // 0x0000000180A25BF0-0x0000000180A25F60

	// Methods
	public void RegisterToggle(Toggle toggle); // 0x0000000180A21C10-0x0000000180A22080
	public void RestoreToggle(Toggle toggle, bool isOn); // 0x0000000180A22080-0x0000000180A221C0
	private bool IsAttackCard(CardData card); // 0x0000000180A221C0-0x0000000180A22260
	private void OnToggleChanged(Toggle changedToggle); // 0x0000000180A22260-0x0000000180A226B0
	private void RejectShake(Toggle toggle); // 0x0000000180A226B0-0x0000000180A229C0
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x0000000180A229C0-0x0000000180A22DB0
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x0000000180A22DB0-0x0000000180A23370
	private void RebuildToggleIndex(); // 0x0000000180A23370-0x0000000180A23960
	private void AddSelectedImage(Toggle toggle); // 0x0000000180A23960-0x0000000180A23C60
	private void AddSelectedImage(CardSelectionData selectionData); // 0x0000000180A23C60-0x0000000180A242F0
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x0000000180A242F0-0x0000000180A245E0
	private void UpdateToggleInteractable(Toggle toggle); // 0x0000000180A245E0-0x0000000180A24870
	private void UpdateToggleCountText(int cardId); // 0x0000000180A24870-0x0000000180A24CC0
	private void UpdateToggleColor(Toggle toggle); // 0x0000000180A24CC0-0x0000000180A24E10
	public List<CardData> GetSelectedCards(); // 0x0000000180A24E10-0x0000000180A25000
	public int GetSelectedCount(); // 0x0000000180A0C1E0-0x0000000180A0C200
	public void ResetAllToggles(); // 0x0000000180A25000-0x0000000180A254C0
	public void ClearAllToggles(); // 0x0000000180A254C0-0x0000000180A25BF0
}

