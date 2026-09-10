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

[DisallowMultipleComponent]
public class TowerPetPicker : MonoBehaviour // TypeDefIndex: 993
{
	// Fields
	public const int PETS_PER_PAGE = 12; // Metadata: 0x0068C009
	private const float WS_TIMEOUT = 6f; // Metadata: 0x0068C00A
	[Header("Khung")]
	[SerializeField]
	private GameObject dim; // 0x20
	[SerializeField]
	private GameObject frame; // 0x28
	[SerializeField]
	private Button btnClose; // 0x30
	[SerializeField]
	private Button btnDimClose; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x40
	[Header("Danh s\u00E1ch")]
	[SerializeField]
	private Transform listContainer; // 0x48
	[SerializeField]
	private GameObject rowPrefab; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x58
	[Header("Ph\u00E2n trang")]
	[SerializeField]
	private Button btnPrev; // 0x60
	[SerializeField]
	private Button btnNext; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtPage; // 0x70
	[CompilerGenerated]
	private Action<int> OnPetChosen; // 0x78
	private static readonly Dictionary<int, PetUserDTO> _seen; // 0x00
	private static string _seenOwner; // 0x08
	private PetsPaginatedDataDTO _page; // 0x80
	private int _requestedPage; // 0x88
	private Coroutine _loadCo; // 0x90
	private Action<PetsPaginatedDataDTO> _pageHandler; // 0x98
	private bool _pageReady; // 0xA0
	private PetsPaginatedDataDTO _pageData; // 0xA8
	private bool _wired; // 0xB0

	// Properties
	public bool IsOpen { get; } // 0x00000001804F0850-0x00000001804F08D0 

	// Events
	public event Action<int> OnPetChosen {
		add; // 0x00000001804F0790-0x00000001804F0850
		remove; // 0x00000001804F08D0-0x00000001804F0990
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 994
	{
		// Fields
		public TowerPetPicker __4__this; // 0x10
		public int petId; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildRow_b__0(); // 0x00000001804F8AB0-0x00000001804F8AE0
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__36 : IEnumerator<object> // TypeDefIndex: 995
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPetPicker __4__this; // 0x20
		public int page; // 0x28
		private float _deadline_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPage_d__36(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804F5C20-0x00000001804F6020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F6020-0x00000001804F6060
	}

	[CompilerGenerated]
	private sealed class _Render_d__38 : IEnumerator<object> // TypeDefIndex: 996
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPetPicker __4__this; // 0x20
		public PetsPaginatedDataDTO data; // 0x28
		private PetUserDTO[] _pets_5__2; // 0x30
		private int _selected_5__3; // 0x38
		private int _i_5__4; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Render_d__38(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001804F6990-0x00000001804F6E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F6E00-0x00000001804F6E40
	}

	// Constructors
	public TowerPetPicker(); // 0x00000001802EBA70-0x00000001802EBAF0
	static TowerPetPicker(); // 0x00000001804F0700-0x00000001804F0790

	// Methods
	private static void EnsureOwner(); // 0x00000001804EF400-0x00000001804EF510
	public static PetUserDTO Seen(int petId); // 0x00000001804EFF30-0x00000001804EFFD0
	private static void Remember(PetUserDTO pet); // 0x00000001804EFE00-0x00000001804EFEA0
	private void EnsureWired(); // 0x00000001804EF620-0x00000001804EF950
	private static void Bind(Button b, UnityAction action); // 0x00000001804EE750-0x00000001804EE7F0
	private void OnDestroy(); // 0x00000001804EFAC0-0x00000001804EFB90
	public void Open(); // 0x00000001804EFB90-0x00000001804EFE00
	public void Close(); // 0x00000001804EF350-0x00000001804EF400
	private void GoToPage(int page); // 0x00000001804EF950-0x00000001804EFA40
	[IteratorStateMachine(typeof(_LoadPage_d__36))]
	private IEnumerator LoadPage(int page); // 0x00000001804EFA40-0x00000001804EFAC0
	private void EnsureSubscription(); // 0x00000001804EF510-0x00000001804EF620
	[IteratorStateMachine(typeof(_Render_d__38))]
	private IEnumerator Render(PetsPaginatedDataDTO data); // 0x00000001804EFEA0-0x00000001804EFF30
	private void BuildRow(PetUserDTO pet, int selectedPetId); // 0x00000001804EE7F0-0x00000001804EEFE0
	private static void ApplyIcon(Image target, string resourcePath); // 0x00000001804EE650-0x00000001804EE750
	private static void SetRowHighlight(GameObject row, bool selected); // 0x00000001804F0080-0x00000001804F01D0
	private void ShowEmpty(string message); // 0x00000001804F01D0-0x00000001804F0550
	private void UpdatePagingUi(PetsPaginatedDataDTO data); // 0x00000001804F05B0-0x00000001804F0700
	private void SetPagingInteractable(bool on); // 0x00000001804EFFD0-0x00000001804F0080
	private void Choose(int petId); // 0x00000001804EEFE0-0x00000001804EF350
	[CompilerGenerated]
	private void _EnsureWired_b__30_0(); // 0x00000001804F0590-0x00000001804F05A0
	[CompilerGenerated]
	private void _EnsureWired_b__30_1(); // 0x00000001804F05A0-0x00000001804F05B0
	[CompilerGenerated]
	private void _EnsureSubscription_b__37_0(PetsPaginatedDataDTO d); // 0x00000001804F0550-0x00000001804F0590
}

