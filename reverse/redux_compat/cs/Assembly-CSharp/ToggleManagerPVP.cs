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

public class ToggleManagerPVP : MonoBehaviour // TypeDefIndex: 214
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
		add; // 0x00000001806A2900-0x00000001806A29B0
		remove; // 0x00000001806A29B0-0x00000001806A2A60
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 215
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<CardSelectionData, CardData> __9__23_0; // 0x08

		// Constructors
		static __c(); // 0x00000001806A5F20-0x00000001806A5F90
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal CardData _GetSelectedCards_b__23_0(CardSelectionData s); // 0x000000018052BA80-0x000000018052BAA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 216
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public Toggle toggle; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RegisterToggle_b__0(bool _); // 0x00000001806A5920-0x00000001806A5950
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 217
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RejectShake_b__0(); // 0x00000001806A5950-0x00000001806A59F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 218
	{
		// Fields
		public ToggleManagerPVP __4__this; // 0x10
		public CardSelectionData captured; // 0x18
		public GameObject obj; // 0x20

		// Constructors
		public __c__DisplayClass30_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AddSelectedImage_b__0(); // 0x00000001806A59F0-0x00000001806A5A60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 219
	{
		// Fields
		public CardSelectionData captured; // 0x10
		public GameObject capturedObj; // 0x18
		public ToggleManagerPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RefreshLocalPlayerCardPanel_b__0(); // 0x00000001806A5A60-0x00000001806A5AD0
	}

	// Constructors
	public ToggleManagerPVP(); // 0x00000001806A26D0-0x00000001806A2900

	// Methods
	public void RegisterToggle(Toggle toggle); // 0x00000001806A1660-0x00000001806A1930
	public void ClearAllToggles(); // 0x000000018069FCC0-0x00000001806A0160
	public List<CardData> GetSelectedCards(); // 0x00000001806A0360-0x00000001806A0480
	private void OnToggleChanged(Toggle changedToggle); // 0x00000001806A04F0-0x00000001806A0820
	private void RejectShake(Toggle toggle); // 0x00000001806A1930-0x00000001806A1B20
	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle); // 0x00000001806A0820-0x00000001806A0AA0
	public int RestoreSelectionByCardIds(List<int> cardIds); // 0x00000001806A1D50-0x00000001806A2140
	private void RebuildToggleIndex(); // 0x00000001806A0AA0-0x00000001806A0EB0
	public void RemoveSelectedCard(CardSelectionData selectionData); // 0x00000001806A1B20-0x00000001806A1D50
	private void AddSelectedImage(CardSelectionData selectionData); // 0x000000018069F830-0x000000018069FCC0
	public void RefreshLocalPlayerCardPanel(); // 0x00000001806A0EB0-0x00000001806A1660
	private bool IsAttackCard(CardData card); // 0x00000001806A0480-0x00000001806A04F0
	private void UpdateToggleInteractable(Toggle toggle); // 0x00000001806A25B0-0x00000001806A26D0
	private void UpdateToggleCountText(int cardId); // 0x00000001806A2290-0x00000001806A25B0
	private void UpdateToggleColor(Toggle toggle); // 0x00000001806A2140-0x00000001806A2290
	private RectTransform GetPanelByIndex(int index); // 0x00000001806A0330-0x00000001806A0360
	private GameObject CreateCardIconById(int cardId); // 0x00000001806A0160-0x00000001806A0330
}

