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
		add; // 0x0000000180D53880-0x0000000180D53980
		remove; // 0x0000000180D53980-0x0000000180D53A80
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
		static __c(); // 0x0000000180D581D0-0x0000000180D58270
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal CardData _GetSelectedCards_b__23_0(CardSelectionData s); // 0x00000001807A7FF0-0x00000001807A8010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 242
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RegisterToggle_b__0(bool _); // 0x0000000180D58270-0x0000000180D582A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 243
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RejectShake_b__0(); // 0x0000000180D582A0-0x0000000180D58410
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 244
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public CardSelectionData captured; // 0x18
		public GameObject obj; // 0x20

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AddSelectedImage_b__0(); // 0x0000000180D58410-0x0000000180D584D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 245
	{
		// Fields
		public CardSelectionData captured; // 0x10
		public GameObject capturedObj; // 0x18
		public ToggleManagerPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshLocalPlayerCardPanel_b__0(); // 0x0000000180D584D0-0x0000000180D58590
	}

	// Constructors
	public ToggleManagerPVP(); // 0x0000000180D57DA0-0x0000000180D581D0

	// Methods
	public void RegisterToggle(Toggle toggle); // 0x0000000180D53A80-0x0000000180D53E80
	public void ClearAllToggles(); // 0x0000000180D53E80-0x0000000180D545F0
	public List<CardData> GetSelectedCards(); // 0x0000000180D545F0-0x0000000180D547C0
	private void OnToggleChanged(Toggle changedToggle); // 0x0000000180D547C0-0x0000000180D54B60
	private void RejectShake(Toggle toggle); // 0x0000000180D54B60-0x0000000180D54E70
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x0000000180D54E70-0x0000000180D55260
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x0000000180D55260-0x0000000180D55820
	private void RebuildToggleIndex(); // 0x0000000180D55820-0x0000000180D55E20
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x0000000180D55E20-0x0000000180D560B0
	private void AddSelectedImage(CardSelectionData selectionData); // 0x0000000180D560B0-0x0000000180D56820
	public void RefreshLocalPlayerCardPanel(); // 0x0000000180D56820-0x0000000180D57410
	private bool IsAttackCard(CardData card); // 0x0000000180D57410-0x0000000180D57480
	private void UpdateToggleInteractable(Toggle toggle); // 0x0000000180D57480-0x0000000180D575B0
	private void UpdateToggleCountText(int cardId); // 0x0000000180D575B0-0x0000000180D57920
	private void UpdateToggleColor(Toggle toggle); // 0x0000000180D57920-0x0000000180D57A70
	private RectTransform GetPanelByIndex(int index); // 0x0000000180D57A70-0x0000000180D57AA0
	private GameObject CreateCardIconById(int cardId); // 0x0000000180D57AA0-0x0000000180D57DA0
}

