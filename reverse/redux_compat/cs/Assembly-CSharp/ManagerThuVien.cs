/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerThuVien : MonoBehaviour // TypeDefIndex: 1492
{
	// Fields
	public const string PANEL_KEY = "PanelThuVien"; // Metadata: 0x0064D6F9
	[Header("Pet List")]
	public GameObject petUIPrefab; // 0x20
	public Transform petListContainer; // 0x28
	[Header("Pagination")]
	public Button btnPrevPetPage; // 0x30
	public Button btnNextPetPage; // 0x38
	public UnityEngine.UI.Text txtPetPageNum; // 0x40
	public UnityEngine.UI.Text txtSummary; // 0x48
	[Header("Pet Detail")]
	public GameObject banner; // 0x50
	public UnityEngine.UI.Text namePet; // 0x58
	public UnityEngine.UI.Text txtHp; // 0x60
	public UnityEngine.UI.Text txtMana; // 0x68
	public UnityEngine.UI.Text txtDame; // 0x70
	public UnityEngine.UI.Text txtWee; // 0x78
	public UnityEngine.UI.Text txtLv; // 0x80
	public UnityEngine.UI.Text des; // 0x88
	public Image imgAtribute; // 0x90
	public Image imgAtributeOther; // 0x98
	[Header("Close")]
	public Button btnClose; // 0xA0
	private const int PETS_PER_PAGE = 20; // Metadata: 0x0064D706
	private const string ELEMENT_BADGE = "imgElement"; // Metadata: 0x0064D707
	private const string CELL_FRAME = "cellFrame"; // Metadata: 0x0064D712
	private static readonly Color OwnedNameColor; // 0x00
	private static readonly Color LockedIconColor; // 0x10
	private static readonly Color LockedNameColor; // 0x20
	private static readonly Color LockedFrameColor; // 0x30
	private int currentPetPage; // 0xA8
	private PetLibraryPageResponse currentPetPageData; // 0xB0
	private bool hasLoadedPetsOnce; // 0xB8
	private bool isLoadingPetPage; // 0xB9

	// Nested types
	[Serializable]
	public class PetLibraryPageResponse // TypeDefIndex: 1493
	{
		// Fields
		public PetLibDTO[] content; // 0x10
		public int totalPages; // 0x18
		public int totalElements; // 0x1C
		public int number; // 0x20
		public int size; // 0x24
		public bool first; // 0x28
		public bool last; // 0x29
		public int numberOfElements; // 0x2C

		// Constructors
		public PetLibraryPageResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1494
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__34_1; // 0x08

		// Constructors
		static __c(); // 0x000000018057E0E0-0x000000018057E150
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetsPage_b__34_1(string error); // 0x000000018057DE90-0x000000018057DF00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass36_0 // TypeDefIndex: 1495
	{
		// Fields
		public ManagerThuVien __4__this; // 0x10
		public Sprite capturedIcon; // 0x18
		public PetLibDTO captured; // 0x20

		// Constructors
		public __c__DisplayClass36_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _InstantiatePetItem_b__0(); // 0x000000018057E0B0-0x000000018057E0E0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__34 : IEnumerator<object> // TypeDefIndex: 1496
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThuVien __4__this; // 0x20
		public int page; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__34(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057A900-0x000000018057AC90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057AC90-0x000000018057ACD0
	}

	// Constructors
	public ManagerThuVien(); // 0x00000001802E7A70-0x00000001802E7BC0
	static ManagerThuVien(); // 0x000000018056E090-0x000000018056E120

	// Methods
	private void OnDisable(); // 0x000000018056D200-0x000000018056D210
	private void Awake(); // 0x000000018056C170-0x000000018056C320
	public void Open(); // 0x000000018056D700-0x000000018056D740
	public void Close(); // 0x000000018056C320-0x000000018056C480
	[IteratorStateMachine(typeof(_LoadPetsPage_d__34))]
	private IEnumerator LoadPetsPage(int page); // 0x000000018056D180-0x000000018056D200
	private void DisplayCurrentPetPage(); // 0x000000018056C480-0x000000018056C780
	private void InstantiatePetItem(PetLibDTO pet); // 0x000000018056CD00-0x000000018056D180
	private void FitCellContent(Transform cell); // 0x000000018056CA10-0x000000018056CD00
	private static void ApplyOwnedLook(GameObject cell, Image petIcon, UnityEngine.UI.Text txtNamePet, bool owned); // 0x000000018056BEA0-0x000000018056C170
	private void AddElementBadge(Transform cell, string elementType); // 0x000000018056BA70-0x000000018056BEA0
	private void UpdatePetPaginationButtons(); // 0x000000018056DE50-0x000000018056E090
	private void SetPetPaginationButtonsState(bool enabled); // 0x000000018056D740-0x000000018056D7F0
	private void ShowPreviousPetPage(); // 0x000000018056D850-0x000000018056D8B0
	private void ShowNextPetPage(); // 0x000000018056D7F0-0x000000018056D850
	private void OnPetClicked(Sprite petSprite, PetLibDTO pet); // 0x000000018056D210-0x000000018056D700
	private static bool StatsHidden(PetLibDTO p); // 0x000000018056D900-0x000000018056D920
	private static string StatText(int v, bool hidden); // 0x000000018056D8B0-0x000000018056D900
	private static string ElementVi(string code); // 0x000000018056C780-0x000000018056CA10
	private static string TooltipTitle(PetLibDTO pet); // 0x000000018056DD10-0x000000018056DDA0
	private static string TooltipBody(PetLibDTO pet); // 0x000000018056D920-0x000000018056DD10
	[CompilerGenerated]
	private void _LoadPetsPage_b__34_0(PetLibraryPageResponse data); // 0x000000018056DDA0-0x000000018056DE50
}

