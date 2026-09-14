/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildRaidLoadoutPopup : GuildInfoPopup // TypeDefIndex: 890
{
	// Fields
	public const string NODE = "RaidLoadoutPopup"; // Metadata: 0x005EEBF4
	private const float BOX_W = 1240f; // Metadata: 0x005EEC05
	private const float BOX_H = 700f; // Metadata: 0x005EEC09
	private const int COLS = 6; // Metadata: 0x005EEC0D
	private const int ROWS = 2; // Metadata: 0x005EEC0E
	private const int PER_PAGE = 12; // Metadata: 0x005EEC0F
	private const float GRID_X = 40f; // Metadata: 0x005EEC10
	private const float GRID_Y = 166f; // Metadata: 0x005EEC14
	private const float CELL_W = 180f; // Metadata: 0x005EEC18
	private const float CELL_H = 170f; // Metadata: 0x005EEC1C
	private const float CELL_GAP = 16f; // Metadata: 0x005EEC20
	private const float TAB_Y = 92f; // Metadata: 0x005EEC24
	private const float TAB_W = 260f; // Metadata: 0x005EEC28
	private const float TAB_H = 58f; // Metadata: 0x005EEC2C
	private const float PAGE_Y = 532f; // Metadata: 0x005EEC30
	private const float PAGE_H = 50f; // Metadata: 0x005EEC34
	private const float ROW_X = 40f; // Metadata: 0x005EEC38
	private const float ROW_Y = 596f; // Metadata: 0x005EEC3C
	private const float ROW_W = 1000f; // Metadata: 0x005EEC40
	private const float ROW_H = 86f; // Metadata: 0x005EEC44
	private const float WS_TIMEOUT = 6f; // Metadata: 0x005EEC48
	private static readonly Color RING_ON; // 0x00
	private static readonly Color RING_OFF; // 0x10
	private static readonly Color SLOT_EMPTY; // 0x20
	private readonly Cell[] _cells; // 0x70
	private readonly Slot[] _cardSlots; // 0x78
	private Slot _petSlot; // 0x80
	private Button _tabPet; // 0x88
	private Button _tabCard; // 0x90
	private UnityEngine.UI.Text _tabPetLbl; // 0x98
	private UnityEngine.UI.Text _tabCardLbl; // 0xA0
	private UnityEngine.UI.Text _txtHint; // 0xA8
	private UnityEngine.UI.Text _txtPage; // 0xB0
	private UnityEngine.UI.Text _txtDeckLabel; // 0xB8
	private UnityEngine.UI.Text _txtPetLabel; // 0xC0
	private Button _btnPrev; // 0xC8
	private Button _btnNext; // 0xD0
	private Button _btnDone; // 0xD8
	private Tab _tab; // 0xE0
	private Action _onChanged; // 0xE8
	private PetsPaginatedDataDTO _petPage; // 0xF0
	private int _petPageIndex; // 0xF8
	private bool _petPageReady; // 0xFC
	private PetsPaginatedDataDTO _petPageData; // 0x100
	private Action<PetsPaginatedDataDTO> _petHandler; // 0x108
	private Coroutine _petLoadCo; // 0x110
	private int _cardPageIndex; // 0x118
	private bool _cardLoading; // 0x11C
	private bool _built; // 0x11D

	// Nested types
	private enum Tab // TypeDefIndex: 891
	{
		PET = 0,
		CARD = 1
	}

	private class Cell // TypeDefIndex: 892
	{
		// Fields
		public RectTransform root; // 0x10
		public Image ring; // 0x18
		public Image icon; // 0x20
		public UnityEngine.UI.Text title; // 0x28
		public UnityEngine.UI.Text sub; // 0x30
		public Image badgeBg; // 0x38
		public UnityEngine.UI.Text badgeTxt; // 0x40
		public Button btn; // 0x48

		// Constructors
		public Cell(); // 0x000000018028A320-0x000000018028A330
	}

	private class Slot // TypeDefIndex: 893
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public Button btn; // 0x20

		// Constructors
		public Slot(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 894
	{
		// Fields
		public int idx; // 0x10
		public GuildRaidLoadoutPopup __4__this; // 0x18

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildOnce_b__6(); // 0x00000001805709F0-0x0000000180570B60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass58_0 // TypeDefIndex: 895
	{
		// Fields
		public GuildRaidLoadoutPopup __4__this; // 0x10
		public int captured; // 0x18

		// Constructors
		public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildCell_b__0(); // 0x0000000180570B60-0x0000000180570D00
	}

	[CompilerGenerated]
	private sealed class _LoadPetPage_d__66 : IEnumerator<object> // TypeDefIndex: 896
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRaidLoadoutPopup __4__this; // 0x20
		public int page; // 0x28
		private float _deadline_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetPage_d__66(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180570D00-0x00000001805712D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805712D0-0x0000000180571310
	}

	// Constructors
	public GuildRaidLoadoutPopup(); // 0x0000000180570430-0x0000000180570580
	static GuildRaidLoadoutPopup(); // 0x0000000180570580-0x0000000180570630

	// Methods
	public static GuildRaidLoadoutPopup Ensure(Transform host); // 0x000000018056A620-0x000000018056A680
	private void Open(Tab startTab, Action onChanged); // 0x000000018056A680-0x000000018056A750
	public void OpenPet(Action onChanged); // 0x000000018056A750-0x000000018056A760
	public void OpenCards(Action onChanged); // 0x000000018056A760-0x000000018056A770
	protected override void OnDisable(); // 0x000000018056A770-0x000000018056A990
	private void BuildOnce(); // 0x000000018056A990-0x000000018056C330
	private Cell BuildCell(Transform parent, int index); // 0x000000018056C330-0x000000018056CF00
	private Slot BuildSlot(Transform parent, string name, float x, float y, float w, float h, UnityAction onTap); // 0x000000018056CF00-0x000000018056D240
	private static Image NewArt(Transform parent, string name, float x, float y, float w, float h); // 0x000000018056D240-0x000000018056D3B0
	private void SwitchTab(Tab tab); // 0x000000018056D3B0-0x000000018056D430
	private void Turn(int delta); // 0x000000018056D430-0x000000018056D4E0
	private int CardPageCount(); // 0x000000018056D4E0-0x000000018056D550
	private void EnsureInventory(); // 0x000000018056D550-0x000000018056D6E0
	private void GoPetPage(int page); // 0x000000018056D6E0-0x000000018056D8A0
	[IteratorStateMachine(typeof(_LoadPetPage_d__66))]
	private IEnumerator LoadPetPage(int page); // 0x000000018056D8A0-0x000000018056D950
	private void SubscribeWs(); // 0x000000018056D950-0x000000018056DB30
	private void UnsubscribeWs(); // 0x000000018056DB30-0x000000018056DCB0
	private void OnCellTap(int index); // 0x000000018056DCB0-0x000000018056DE50
	private void PickPet(int index); // 0x000000018056DE50-0x000000018056DFE0
	private void ToggleCard(int index); // 0x000000018056DFE0-0x000000018056E280
	private void DropFromDeck(int slotIndex); // 0x000000018056E280-0x000000018056E3E0
	private void AfterDeckChange(); // 0x000000018056E3E0-0x000000018056E420
	private void NotifyChanged(); // 0x000000018056E420-0x000000018056E450
	private void RenderAll(); // 0x000000018056E450-0x000000018056E720
	private void RenderPetGrid(); // 0x000000018056E720-0x000000018056EE80
	private void RenderCardGrid(); // 0x000000018056EE80-0x000000018056F950
	private void RenderLoadoutRow(); // 0x000000018056F950-0x000000018056FF10
	private void SetHint(string s); // 0x000000018056FF10-0x000000018056FF80
	private void SetPagingInteractable(bool on); // 0x000000018056FF80-0x0000000180570010
	private static void Tint(Button btn, Color tint); // 0x0000000180570010-0x0000000180570330
	private PetUserDTO PetAt(int index); // 0x0000000180570330-0x0000000180570380
	private CardData CardAt(int index); // 0x0000000180570380-0x0000000180570430
	[CompilerGenerated]
	private void _BuildOnce_b__57_0(); // 0x0000000180570630-0x00000001805706A0
	[CompilerGenerated]
	private void _BuildOnce_b__57_1(); // 0x00000001805706A0-0x00000001805706F0
	[CompilerGenerated]
	private void _BuildOnce_b__57_2(); // 0x00000001805706F0-0x0000000180570700
	[CompilerGenerated]
	private void _BuildOnce_b__57_3(); // 0x0000000180570700-0x0000000180570710
	[CompilerGenerated]
	private void _BuildOnce_b__57_4(); // 0x0000000180570630-0x00000001805706A0
	[CompilerGenerated]
	private void _BuildOnce_b__57_5(); // 0x0000000180570710-0x0000000180570730
	[CompilerGenerated]
	private void _EnsureInventory_b__64_0(List<CardData> _); // 0x0000000180570730-0x0000000180570850
	[CompilerGenerated]
	private void _EnsureInventory_b__64_1(string err); // 0x0000000180570850-0x0000000180570980
	[CompilerGenerated]
	private void _SubscribeWs_b__67_0(PetsPaginatedDataDTO d); // 0x0000000180570980-0x00000001805709F0
}

