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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class GuildRaidLoadoutPopup : GuildInfoPopup // TypeDefIndex: 892
{
	// Fields
	public const string NODE = "RaidLoadoutPopup"; // Metadata: 0x005EFFC2
	private const float BOX_W = 1240f; // Metadata: 0x005EFFD3
	private const float BOX_H = 700f; // Metadata: 0x005EFFD7
	private const int COLS = 6; // Metadata: 0x005EFFDB
	private const int ROWS = 2; // Metadata: 0x005EFFDC
	private const int PER_PAGE = 12; // Metadata: 0x005EFFDD
	private const float GRID_X = 40f; // Metadata: 0x005EFFDE
	private const float GRID_Y = 166f; // Metadata: 0x005EFFE2
	private const float CELL_W = 180f; // Metadata: 0x005EFFE6
	private const float CELL_H = 170f; // Metadata: 0x005EFFEA
	private const float CELL_GAP = 16f; // Metadata: 0x005EFFEE
	private const float TAB_Y = 92f; // Metadata: 0x005EFFF2
	private const float TAB_W = 260f; // Metadata: 0x005EFFF6
	private const float TAB_H = 58f; // Metadata: 0x005EFFFA
	private const float PAGE_Y = 532f; // Metadata: 0x005EFFFE
	private const float PAGE_H = 50f; // Metadata: 0x005F0002
	private const float ROW_X = 40f; // Metadata: 0x005F0006
	private const float ROW_Y = 596f; // Metadata: 0x005F000A
	private const float ROW_W = 1000f; // Metadata: 0x005F000E
	private const float ROW_H = 86f; // Metadata: 0x005F0012
	private const float WS_TIMEOUT = 6f; // Metadata: 0x005F0016
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
	private enum Tab // TypeDefIndex: 893
	{
		PET = 0,
		CARD = 1
	}

	private class Cell // TypeDefIndex: 894
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

	private class Slot // TypeDefIndex: 895
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public Button btn; // 0x20

		// Constructors
		public Slot(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 896
	{
		// Fields
		public int idx; // 0x10
		public GuildRaidLoadoutPopup __4__this; // 0x18

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildOnce_b__6(); // 0x0000000180572350-0x00000001805724C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass58_0 // TypeDefIndex: 897
	{
		// Fields
		public GuildRaidLoadoutPopup __4__this; // 0x10
		public int captured; // 0x18

		// Constructors
		public __c__DisplayClass58_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildCell_b__0(); // 0x00000001805724C0-0x0000000180572660
	}

	[CompilerGenerated]
	private sealed class _LoadPetPage_d__66 : IEnumerator<object> // TypeDefIndex: 898
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180572660-0x0000000180572C30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180572C30-0x0000000180572C70
	}

	// Constructors
	public GuildRaidLoadoutPopup(); // 0x0000000180571D90-0x0000000180571EE0
	static GuildRaidLoadoutPopup(); // 0x0000000180571EE0-0x0000000180571F90

	// Methods
	public static GuildRaidLoadoutPopup Ensure(Transform host); // 0x000000018056BF80-0x000000018056BFE0
	private void Open(Tab startTab, Action onChanged); // 0x000000018056BFE0-0x000000018056C0B0
	public void OpenPet(Action onChanged); // 0x000000018056C0B0-0x000000018056C0C0
	public void OpenCards(Action onChanged); // 0x000000018056C0C0-0x000000018056C0D0
	protected override void OnDisable(); // 0x000000018056C0D0-0x000000018056C2F0
	private void BuildOnce(); // 0x000000018056C2F0-0x000000018056DC90
	private Cell BuildCell(Transform parent, int index); // 0x000000018056DC90-0x000000018056E860
	private Slot BuildSlot(Transform parent, string name, float x, float y, float w, float h, UnityAction onTap); // 0x000000018056E860-0x000000018056EBA0
	private static Image NewArt(Transform parent, string name, float x, float y, float w, float h); // 0x000000018056EBA0-0x000000018056ED10
	private void SwitchTab(Tab tab); // 0x000000018056ED10-0x000000018056ED90
	private void Turn(int delta); // 0x000000018056ED90-0x000000018056EE40
	private int CardPageCount(); // 0x000000018056EE40-0x000000018056EEB0
	private void EnsureInventory(); // 0x000000018056EEB0-0x000000018056F040
	private void GoPetPage(int page); // 0x000000018056F040-0x000000018056F200
	[IteratorStateMachine(typeof(_LoadPetPage_d__66))]
	private IEnumerator LoadPetPage(int page); // 0x000000018056F200-0x000000018056F2B0
	private void SubscribeWs(); // 0x000000018056F2B0-0x000000018056F490
	private void UnsubscribeWs(); // 0x000000018056F490-0x000000018056F610
	private void OnCellTap(int index); // 0x000000018056F610-0x000000018056F7B0
	private void PickPet(int index); // 0x000000018056F7B0-0x000000018056F940
	private void ToggleCard(int index); // 0x000000018056F940-0x000000018056FBE0
	private void DropFromDeck(int slotIndex); // 0x000000018056FBE0-0x000000018056FD40
	private void AfterDeckChange(); // 0x000000018056FD40-0x000000018056FD80
	private void NotifyChanged(); // 0x000000018056FD80-0x000000018056FDB0
	private void RenderAll(); // 0x000000018056FDB0-0x0000000180570080
	private void RenderPetGrid(); // 0x0000000180570080-0x00000001805707E0
	private void RenderCardGrid(); // 0x00000001805707E0-0x00000001805712B0
	private void RenderLoadoutRow(); // 0x00000001805712B0-0x0000000180571870
	private void SetHint(string s); // 0x0000000180571870-0x00000001805718E0
	private void SetPagingInteractable(bool on); // 0x00000001805718E0-0x0000000180571970
	private static void Tint(Button btn, Color tint); // 0x0000000180571970-0x0000000180571C90
	private PetUserDTO PetAt(int index); // 0x0000000180571C90-0x0000000180571CE0
	private CardData CardAt(int index); // 0x0000000180571CE0-0x0000000180571D90
	[CompilerGenerated]
	private void _BuildOnce_b__57_0(); // 0x0000000180571F90-0x0000000180572000
	[CompilerGenerated]
	private void _BuildOnce_b__57_1(); // 0x0000000180572000-0x0000000180572050
	[CompilerGenerated]
	private void _BuildOnce_b__57_2(); // 0x0000000180572050-0x0000000180572060
	[CompilerGenerated]
	private void _BuildOnce_b__57_3(); // 0x0000000180572060-0x0000000180572070
	[CompilerGenerated]
	private void _BuildOnce_b__57_4(); // 0x0000000180571F90-0x0000000180572000
	[CompilerGenerated]
	private void _BuildOnce_b__57_5(); // 0x0000000180572070-0x0000000180572090
	[CompilerGenerated]
	private void _EnsureInventory_b__64_0(List<CardData> _); // 0x0000000180572090-0x00000001805721B0
	[CompilerGenerated]
	private void _EnsureInventory_b__64_1(string err); // 0x00000001805721B0-0x00000001805722E0
	[CompilerGenerated]
	private void _SubscribeWs_b__67_0(PetsPaginatedDataDTO d); // 0x00000001805722E0-0x0000000180572350
}

