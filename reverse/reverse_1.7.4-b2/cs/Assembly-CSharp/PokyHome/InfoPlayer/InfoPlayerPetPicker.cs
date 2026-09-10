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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerPetPicker : MonoBehaviour // TypeDefIndex: 2394
	{
		// Fields
		public const string FLAG_PICK = "infoplayer.petpick"; // Metadata: 0x0068EE59
		public const int PETS_PER_PAGE = 20; // Metadata: 0x0068EE6C
		private const int COLS = 5; // Metadata: 0x0068EE6D
		private const float WS_TIMEOUT = 6f; // Metadata: 0x0068EE6E
		private const string N_ROOT = "sec_PetPicker"; // Metadata: 0x0068EE72
		private const string N_DIM = "img_PickerDim"; // Metadata: 0x0068EE80
		private const string N_CARD = "frm_PickerCard"; // Metadata: 0x0068EE8E
		private const string N_GRID = "grid_PetCells"; // Metadata: 0x0068EE9D
		private const string N_EMPTY = "txt_PickerEmpty"; // Metadata: 0x0068EEAB
		private const string CELL_FRAME_SPRITE = "Image/Poky/ThuVien/cellFramePet"; // Metadata: 0x0068EEBB
		private const string CARD_SPRITE = "Image/Poky/PanelFramePoky"; // Metadata: 0x0068EEDB
		private static readonly Vector2 CARD; // 0x00
		private static readonly Vector2 CELL; // 0x08
		private static readonly Vector2 CELL_GAP; // 0x10
		private const float K = 1.0727273f; // Metadata: 0x0068EEF5
		private static readonly Color DimColor; // 0x18
		private static readonly Color NamePlate; // 0x28
		private static readonly Color NameText; // 0x38
		private static readonly Color FramePicked; // 0x48
		[CompilerGenerated]
		private Action<PetUserDTO> PetChosen; // 0x20
		private RectTransform _root; // 0x28
		private RectTransform _card; // 0x30
		private RectTransform _grid; // 0x38
		private UnityEngine.UI.Text _txtEmpty; // 0x40
		private UnityEngine.UI.Text _txtPage; // 0x48
		private Button _btnPrev; // 0x50
		private Button _btnNext; // 0x58
		private Font _font; // 0x60
		private Sprite _cellFrame; // 0x68
		private PetsPaginatedDataDTO _page; // 0x70
		private int _requestedPage; // 0x78
		private Action<PetsPaginatedDataDTO> _pageHandler; // 0x80
		private bool _pageReady; // 0x88
		private PetsPaginatedDataDTO _pageData; // 0x90
		private Coroutine _loadCo; // 0x98
		private Coroutine _renderCo; // 0xA0
		private bool _writeInFlight; // 0xA8
		private bool _built; // 0xA9
		private long _currentPetId; // 0xB0
	
		// Properties
		public bool IsOpen { get; } // 0x00000001807E2C10-0x00000001807E2CA0 
	
		// Events
		public event Action<PetUserDTO> PetChosen {
			add; // 0x00000001807E2B50-0x00000001807E2C10
			remove; // 0x00000001807E2CA0-0x00000001807E2D60
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass51_0 // TypeDefIndex: 2395
		{
			// Fields
			public Image icon; // 0x10
			public InfoPlayerPetPicker __4__this; // 0x18
			public PetUserDTO captured; // 0x20
	
			// Constructors
			public __c__DisplayClass51_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _BuildCell_b__1(Sprite sp); // 0x00000001807F58D0-0x00000001807F5980
			internal void _BuildCell_b__0(); // 0x00000001807F5750-0x00000001807F58D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass53_0 // TypeDefIndex: 2396
		{
			// Fields
			public InfoPlayerPetPicker __4__this; // 0x10
			public PetUserDTO pet; // 0x18
	
			// Constructors
			public __c__DisplayClass53_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _EquipPet_b__0(EquipResponse resp); // 0x00000001807F5980-0x00000001807F5C30
			internal void _EquipPet_b__1(string error); // 0x00000001807F5C30-0x00000001807F5D40
		}
	
		[CompilerGenerated]
		private sealed class _EquipPet_d__53 : IEnumerator<object> // TypeDefIndex: 2397
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public PetUserDTO pet; // 0x28
			public int userId; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _EquipPet_d__53(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807F46C0-0x00000001807F48E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F48E0-0x00000001807F4920
		}
	
		[CompilerGenerated]
		private sealed class _LoadPage_d__48 : IEnumerator<object> // TypeDefIndex: 2398
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public int page; // 0x28
			private float _deadline_5__2; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadPage_d__48(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807F4D40-0x00000001807F5180
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F5180-0x00000001807F51C0
		}
	
		[CompilerGenerated]
		private sealed class _Render_d__50 : IEnumerator<object> // TypeDefIndex: 2399
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public PetsPaginatedDataDTO data; // 0x28
			private PetUserDTO[] _pets_5__2; // 0x30
			private int _i_5__3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Render_d__50(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x00000001807F51C0-0x00000001807F5420
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F5420-0x00000001807F5460
		}
	
		// Constructors
		public InfoPlayerPetPicker(); // 0x00000001802EBA70-0x00000001802EBAF0
		static InfoPlayerPetPicker(); // 0x00000001807E2A70-0x00000001807E2B50
	
		// Methods
		private void OnDestroy(); // 0x00000001807E1FD0-0x00000001807E20B0
		private void OnDisable(); // 0x00000001807E20B0-0x00000001807E2170
		public void Open(long currentPetId); // 0x00000001807E2170-0x00000001807E2430
		public void Close(); // 0x00000001807E01B0-0x00000001807E02F0
		private void GoToPage(int page); // 0x00000001807E1DD0-0x00000001807E1EB0
		[IteratorStateMachine(typeof(_LoadPage_d__48))]
		private IEnumerator LoadPage(int page); // 0x00000001807E1F50-0x00000001807E1FD0
		private void EnsureSubscription(); // 0x00000001807E1950-0x00000001807E1A60
		[IteratorStateMachine(typeof(_Render_d__50))]
		private IEnumerator Render(PetsPaginatedDataDTO data); // 0x00000001807E2430-0x00000001807E24C0
		private void BuildCell(PetUserDTO pet); // 0x00000001807DF290-0x00000001807DFF40
		private void Choose(PetUserDTO pet); // 0x00000001807E0030-0x00000001807E01B0
		[IteratorStateMachine(typeof(_EquipPet_d__53))]
		private IEnumerator EquipPet(int userId, PetUserDTO pet); // 0x00000001807E1A60-0x00000001807E1B00
		private void UpdatePaging(PetsPaginatedDataDTO data); // 0x00000001807E2920-0x00000001807E2A70
		private void SetPagingInteractable(bool on); // 0x00000001807E24C0-0x00000001807E2570
		private void ShowEmpty(string message); // 0x00000001807E2570-0x00000001807E26A0
		public void EnsureBuilt(); // 0x00000001807E02F0-0x00000001807E1950
		private Sprite BorrowSprite(string nodeName); // 0x00000001807DF1A0-0x00000001807DF290
		private void SkinButton(Image img, string borrowFrom, Color fallback); // 0x00000001807E26A0-0x00000001807E27A0
		private Font BorrowFont(); // 0x00000001807DF110-0x00000001807DF1A0
		private static void Stretch(RectTransform rt); // 0x00000001807E27A0-0x00000001807E28C0
		private static void Center(RectTransform rt, Vector2 size, Vector2 pos); // 0x00000001807DFF40-0x00000001807E0030
		private static Image FindOrAddImage(Transform parent, string node); // 0x00000001807E1BB0-0x00000001807E1DD0
		private static Button FindOrAddButton(GameObject go); // 0x00000001807E1B00-0x00000001807E1BB0
		private static void Hook(Button b, UnityAction call); // 0x00000001807E1EB0-0x00000001807E1F50
		private Image AddImage(Transform parent, string node, Vector2 size, Vector2 pos); // 0x00000001807DECC0-0x00000001807DED60
		private UnityEngine.UI.Text AddText(Transform parent, string node, Vector2 size, Vector2 pos, int fontSize, TextAnchor align); // 0x00000001807DED60-0x00000001807DF110
		[CompilerGenerated]
		private void _EnsureSubscription_b__49_0(PetsPaginatedDataDTO d); // 0x00000001807E28E0-0x00000001807E2920
		[CompilerGenerated]
		private void _EnsureBuilt_b__57_0(); // 0x00000001807E28C0-0x00000001807E28D0
		[CompilerGenerated]
		private void _EnsureBuilt_b__57_1(); // 0x00000001807E28D0-0x00000001807E28E0
	}
}
