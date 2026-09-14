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
public class TowerPetPicker : MonoBehaviour // TypeDefIndex: 1362
{
	// Fields
	public const int PETS_PER_PAGE = 12; // Metadata: 0x005EF9F4
	private const float WS_TIMEOUT = 6f; // Metadata: 0x005EF9F5
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
	public bool IsOpen { get; } // 0x00000001807713B0-0x0000000180771500 

	// Events
	public event Action<int> OnPetChosen {
		add; // 0x0000000180770E80-0x0000000180770FA0
		remove; // 0x0000000180770FA0-0x00000001807710C0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 1363
	{
		// Fields
		public TowerPetPicker __4__this; // 0x10
		public int petId; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRow_b__0(); // 0x0000000180774C60-0x0000000180774C90
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__36 : IEnumerator<object> // TypeDefIndex: 1364
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TowerPetPicker __4__this; // 0x20
		public int page; // 0x28
		private float _deadline_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPage_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180774C90-0x0000000180775470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180775470-0x00000001807754B0
	}

	[CompilerGenerated]
	private sealed class _Render_d__38 : IEnumerator<object> // TypeDefIndex: 1365
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Render_d__38(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001807754B0-0x0000000180775B00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180775B00-0x0000000180775B40
	}

	// Constructors
	public TowerPetPicker(); // 0x000000018028A560-0x000000018028A5B0
	static TowerPetPicker(); // 0x0000000180774AF0-0x0000000180774BD0

	// Methods
	private static void EnsureOwner(); // 0x00000001807710C0-0x0000000180771250
	public static PetUserDTO Seen(int petId); // 0x0000000180771250-0x0000000180771300
	private static void Remember(PetUserDTO pet); // 0x0000000180771300-0x00000001807713B0
	private void EnsureWired(); // 0x0000000180771500-0x00000001807716A0
	private static void Bind(Button b, UnityAction action); // 0x00000001807716A0-0x00000001807717B0
	private void OnDestroy(); // 0x00000001807717B0-0x0000000180771930
	public void Open(); // 0x0000000180771930-0x0000000180771F80
	public void Close(); // 0x0000000180771F80-0x0000000180772140
	private void GoToPage(int page); // 0x0000000180772140-0x00000001807722B0
	[IteratorStateMachine(typeof(_LoadPage_d__36))]
	private IEnumerator LoadPage(int page); // 0x00000001807722B0-0x0000000180772360
	private void EnsureSubscription(); // 0x0000000180772360-0x0000000180772540
	[IteratorStateMachine(typeof(_Render_d__38))]
	private IEnumerator Render(PetsPaginatedDataDTO data); // 0x0000000180772540-0x0000000180772650
	private void BuildRow(PetUserDTO pet, int selectedPetId); // 0x0000000180772650-0x00000001807735C0
	private static void ApplyIcon(Image target, string resourcePath); // 0x00000001807735C0-0x0000000180773780
	private static void SetRowHighlight(GameObject row, bool selected); // 0x0000000180773780-0x0000000180773B20
	private void ShowEmpty(string message); // 0x0000000180773B20-0x0000000180774120
	private void UpdatePagingUi(PetsPaginatedDataDTO data); // 0x0000000180774120-0x0000000180774470
	private void SetPagingInteractable(bool on); // 0x0000000180774470-0x0000000180774630
	private void Choose(int petId); // 0x0000000180774630-0x0000000180774AF0
	[CompilerGenerated]
	private void _EnsureWired_b__30_0(); // 0x0000000180774BD0-0x0000000180774BE0
	[CompilerGenerated]
	private void _EnsureWired_b__30_1(); // 0x0000000180774BE0-0x0000000180774BF0
	[CompilerGenerated]
	private void _EnsureSubscription_b__37_0(PetsPaginatedDataDTO d); // 0x0000000180774BF0-0x0000000180774C60
}

