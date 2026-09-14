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

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerPetPicker : MonoBehaviour // TypeDefIndex: 2839
	{
		// Fields
		public const string FLAG_PICK = "infoplayer.petpick"; // Metadata: 0x005F1CD5
		public const int PETS_PER_PAGE = 20; // Metadata: 0x005F1CE8
		private const int COLS = 5; // Metadata: 0x005F1CE9
		private const float WS_TIMEOUT = 6f; // Metadata: 0x005F1CEA
		private const string N_ROOT = "sec_PetPicker"; // Metadata: 0x005F1CEE
		private const string N_DIM = "img_PickerDim"; // Metadata: 0x005F1CFC
		private const string N_CARD = "frm_PickerCard"; // Metadata: 0x005F1D0A
		private const string N_GRID = "grid_PetCells"; // Metadata: 0x005F1D19
		private const string N_EMPTY = "txt_PickerEmpty"; // Metadata: 0x005F1D27
		private const string CELL_FRAME_SPRITE = "Image/Poky/ThuVien/cellFramePet"; // Metadata: 0x005F1D37
		private const string CARD_SPRITE = "Image/Poky/PanelFramePoky"; // Metadata: 0x005F1D57
		private static readonly Vector2 CARD; // 0x00
		private static readonly Vector2 CELL; // 0x08
		private static readonly Vector2 CELL_GAP; // 0x10
		private const float K = 1.0727273f; // Metadata: 0x005F1D71
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
		public bool IsOpen { get; } // 0x0000000180CF7E90-0x0000000180CF7FF0 
	
		// Events
		public event Action<PetUserDTO> PetChosen {
			add; // 0x0000000180CF7C50-0x0000000180CF7D70
			remove; // 0x0000000180CF7D70-0x0000000180CF7E90
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass51_0 // TypeDefIndex: 2840
		{
			// Fields
			public Image icon; // 0x10
			public InfoPlayerPetPicker __4__this; // 0x18
			public PetUserDTO captured; // 0x20
	
			// Constructors
			public __c__DisplayClass51_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BuildCell_b__1(Sprite sp); // 0x0000000180CFE540-0x0000000180CFE740
			internal void _BuildCell_b__0(); // 0x0000000180CFE740-0x0000000180CFE770
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass53_0 // TypeDefIndex: 2841
		{
			// Fields
			public InfoPlayerPetPicker __4__this; // 0x10
			public PetUserDTO pet; // 0x18
	
			// Constructors
			public __c__DisplayClass53_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EquipPet_b__0(EquipResponse resp); // 0x0000000180CFE770-0x0000000180CFEAB0
			internal void _EquipPet_b__1(string error); // 0x0000000180CFEAB0-0x0000000180CFEBE0
		}
	
		[CompilerGenerated]
		private sealed class _EquipPet_d__53 : IEnumerator<object> // TypeDefIndex: 2842
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public PetUserDTO pet; // 0x28
			public int userId; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _EquipPet_d__53(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180CFEBE0-0x0000000180CFF010
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CFF010-0x0000000180CFF050
		}
	
		[CompilerGenerated]
		private sealed class _LoadPage_d__48 : IEnumerator<object> // TypeDefIndex: 2843
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public int page; // 0x28
			private float _deadline_5__2; // 0x2C
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadPage_d__48(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180CFF050-0x0000000180CFF830
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CFF830-0x0000000180CFF870
		}
	
		[CompilerGenerated]
		private sealed class _Render_d__50 : IEnumerator<object> // TypeDefIndex: 2844
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InfoPlayerPetPicker __4__this; // 0x20
			public PetsPaginatedDataDTO data; // 0x28
			private PetUserDTO[] _pets_5__2; // 0x30
			private int _i_5__3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Render_d__50(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180CFF870-0x0000000180CFFF40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CFFF40-0x0000000180CFFF80
		}
	
		// Constructors
		public InfoPlayerPetPicker(); // 0x000000018028A560-0x000000018028A5B0
		static InfoPlayerPetPicker(); // 0x0000000180CFE3C0-0x0000000180CFE4B0
	
		// Methods
		private void OnDestroy(); // 0x0000000180CF7FF0-0x0000000180CF81D0
		private void OnDisable(); // 0x0000000180CF81D0-0x0000000180CF83E0
		public void Open(long currentPetId); // 0x0000000180CF83E0-0x0000000180CF88C0
		public void Close(); // 0x0000000180CF88C0-0x0000000180CF8C40
		private void GoToPage(int page); // 0x0000000180CF8C40-0x0000000180CF8DA0
		[IteratorStateMachine(typeof(_LoadPage_d__48))]
		private IEnumerator LoadPage(int page); // 0x0000000180CF8DA0-0x0000000180CF8E50
		private void EnsureSubscription(); // 0x0000000180CF8E50-0x0000000180CF9030
		[IteratorStateMachine(typeof(_Render_d__50))]
		private IEnumerator Render(PetsPaginatedDataDTO data); // 0x0000000180CF9030-0x0000000180CF9140
		private void BuildCell(PetUserDTO pet); // 0x0000000180CF9140-0x0000000180CFA4E0
		private void Choose(PetUserDTO pet); // 0x0000000180CFA4E0-0x0000000180CFA760
		[IteratorStateMachine(typeof(_EquipPet_d__53))]
		private IEnumerator EquipPet(int userId, PetUserDTO pet); // 0x0000000180CFA760-0x0000000180CFA870
		private void UpdatePaging(PetsPaginatedDataDTO data); // 0x0000000180CFA870-0x0000000180CFABC0
		private void SetPagingInteractable(bool on); // 0x0000000180CFABC0-0x0000000180CFAD80
		private void ShowEmpty(string message); // 0x0000000180CFAD80-0x0000000180CFB260
		public void EnsureBuilt(); // 0x0000000180CFB260-0x0000000180CFCCD0
		private Sprite BorrowSprite(string nodeName); // 0x0000000180CFCCD0-0x0000000180CFCEC0
		private void SkinButton(Image img, string borrowFrom, Color fallback); // 0x0000000180CFCEC0-0x0000000180CFD090
		private Font BorrowFont(); // 0x0000000180CFD090-0x0000000180CFD1B0
		private static void Stretch(RectTransform rt); // 0x0000000180CFD1B0-0x0000000180CFD320
		private static void Center(RectTransform rt, Vector2 size, Vector2 pos); // 0x0000000180CFD320-0x0000000180CFD460
		private static Image FindOrAddImage(Transform parent, string node); // 0x0000000180CFD460-0x0000000180CFD8E0
		private static Button FindOrAddButton(GameObject go); // 0x0000000180CFD8E0-0x0000000180CFDA20
		private static void Hook(Button b, UnityAction call); // 0x0000000180CFDA20-0x0000000180CFDB30
		private Image AddImage(Transform parent, string node, Vector2 size, Vector2 pos); // 0x0000000180CFDB30-0x0000000180CFDBD0
		private UnityEngine.UI.Text AddText(Transform parent, string node, Vector2 size, Vector2 pos, int fontSize, TextAnchor align); // 0x0000000180CFDBD0-0x0000000180CFE3C0
		[CompilerGenerated]
		private void _EnsureSubscription_b__49_0(PetsPaginatedDataDTO d); // 0x0000000180CFE4B0-0x0000000180CFE520
		[CompilerGenerated]
		private void _EnsureBuilt_b__57_0(); // 0x0000000180CFE520-0x0000000180CFE530
		[CompilerGenerated]
		private void _EnsureBuilt_b__57_1(); // 0x0000000180CFE530-0x0000000180CFE540
	}
}
