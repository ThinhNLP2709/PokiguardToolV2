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

public class ToggleManagerPVP : MonoBehaviour // TypeDefIndex: 240
{
	// Fields
	[Header("Card Toggle List")]
	public GameObject listToggle; // 0x20
	public GameObject togglePrefab; // 0x28
	public int maxSelected; // 0x30
	[Header("Selected Card Display")]
	public GameObject selectedImagePrefab; // 0x38
	[Header("Panel Card theo Slot (index 0-3)")]
	public RectTransform panelCardUser0; // 0x40
	public RectTransform panelCardUser1; // 0x48
	public RectTransform panelCardUser2; // 0x50
	public RectTransform panelCardUser3; // 0x58
	[Header("Colors")]
	public Color selectedColor; // 0x60
	public Color defaultColor; // 0x70
	[HideInInspector]
	public int LocalSlotUIIndex; // 0x80
	private List<Toggle> registeredToggles; // 0x88
	private List<CardSelectionData> selectedCardsList; // 0x90
	private Dictionary<int, int> selectedCountByCardId; // 0x98
	private Dictionary<int, Toggle> togglesByCardId; // 0xA0
	private Dictionary<string, GameObject> selectedImagesBySelectionId; // 0xA8
	private HashSet<int> selectedAttackCardIds; // 0xB0
	private bool isRestoring; // 0xB8
	[CompilerGenerated]
	private Action OnSelectionChanged; // 0xC0

	// Events
	public event Action OnSelectionChanged {
		add; // 0x000000018084FF60-0x0000000180850010
		remove; // 0x0000000180850010-0x00000001808500C0
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 241
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<CardSelectionData, CardData> __9__23_0; // 0x08

		// Constructors
		static __c(); // 0x00000001808539D0-0x0000000180853A40
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal CardData _GetSelectedCards_b__23_0(CardSelectionData s); // 0x000000018065AD90-0x000000018065ADB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 242
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RegisterToggle_b__0(bool _); // 0x0000000180853270-0x00000001808532A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 243
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RejectShake_b__0(); // 0x00000001808532A0-0x0000000180853340
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 244
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public CardSelectionData captured; // 0x18
		public GameObject obj; // 0x20

		// Constructors
		public __c__DisplayClass30_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AddSelectedImage_b__0(); // 0x0000000180853430-0x00000001808534A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 245
	{
		// Fields
		public CardSelectionData captured; // 0x10
		public GameObject capturedObj; // 0x18
		public ToggleManagerPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshLocalPlayerCardPanel_b__0(); // 0x00000001808534A0-0x0000000180853510
	}

	// Constructors
	public ToggleManagerPVP(); // 0x000000018084FD30-0x000000018084FF60

	// Methods
	public void RegisterToggle(Toggle toggle); // 0x000000018084ECC0-0x000000018084EF90
	public void ClearAllToggles(); // 0x000000018084D320-0x000000018084D7C0
	public List<CardData> GetSelectedCards(); // 0x000000018084D9C0-0x000000018084DAE0
	private void OnToggleChanged(Toggle changedToggle); // 0x000000018084DB50-0x000000018084DE80
	private void RejectShake(Toggle toggle); // 0x000000018084EF90-0x000000018084F180
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x000000018084DE80-0x000000018084E100
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x000000018084F3B0-0x000000018084F7A0
	private void RebuildToggleIndex(); // 0x000000018084E100-0x000000018084E510
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x000000018084F180-0x000000018084F3B0
	private void AddSelectedImage(CardSelectionData selectionData); // 0x000000018084CE90-0x000000018084D320
	public void RefreshLocalPlayerCardPanel(); // 0x000000018084E510-0x000000018084ECC0
	private bool IsAttackCard(CardData card); // 0x000000018084DAE0-0x000000018084DB50
	private void UpdateToggleInteractable(Toggle toggle); // 0x000000018084FC10-0x000000018084FD30
	private void UpdateToggleCountText(int cardId); // 0x000000018084F8F0-0x000000018084FC10
	private void UpdateToggleColor(Toggle toggle); // 0x000000018084F7A0-0x000000018084F8F0
	private RectTransform GetPanelByIndex(int index); // 0x000000018084D990-0x000000018084D9C0
	private GameObject CreateCardIconById(int cardId); // 0x000000018084D7C0-0x000000018084D990
}

