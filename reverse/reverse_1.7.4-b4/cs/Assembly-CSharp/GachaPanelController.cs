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
public class GachaPanelController : MonoBehaviour // TypeDefIndex: 735
{
	// Fields
	public const string PANEL_KEY = "PanelGacha"; // Metadata: 0x005EFA1A
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[Header("Tab")]
	[SerializeField]
	private Button tabShard; // 0x30
	[SerializeField]
	private Button tabWeapon; // 0x38
	[Header("Banner")]
	[SerializeField]
	private Image bannerArt; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtBannerName; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtBannerDesc; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtCountdown; // 0x58
	[SerializeField]
	private Image chest; // 0x60
	[SerializeField]
	private Image chestGlow; // 0x68
	[SerializeField]
	private Image chestBurst; // 0x70
	[Header("Pity")]
	[SerializeField]
	private GameObject pityGroup; // 0x78
	[SerializeField]
	private Image pityFill; // 0x80
	[SerializeField]
	private UnityEngine.UI.Text txtPity; // 0x88
	[SerializeField]
	private RectTransform softMark; // 0x90
	[SerializeField]
	private UnityEngine.UI.Text txtDaily; // 0x98
	[Header("N\u00FAt quay")]
	[SerializeField]
	private Button btnRoll1; // 0xA0
	[SerializeField]
	private UnityEngine.UI.Text txtCost1; // 0xA8
	[SerializeField]
	private Button btnRoll10; // 0xB0
	[SerializeField]
	private UnityEngine.UI.Text txtCost10; // 0xB8
	[SerializeField]
	private UnityEngine.UI.Text txtCost10Old; // 0xC0
	[SerializeField]
	private Image imgCost1; // 0xC8
	[SerializeField]
	private Image imgCost10; // 0xD0
	[Header("Ph\u1EE5")]
	[SerializeField]
	private Button btnRates; // 0xD8
	[SerializeField]
	private Button btnHistory; // 0xE0
	[SerializeField]
	private UnityEngine.UI.Text txtWallet; // 0xE8
	[SerializeField]
	private UnityEngine.UI.Text txtGold; // 0xF0
	[SerializeField]
	private UnityEngine.UI.Text txtRuby; // 0xF8
	[SerializeField]
	private UnityEngine.UI.Text txtTicket; // 0x100
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x108
	[Header("M\u00E0n con")]
	[SerializeField]
	private GachaResultGridView resultGrid; // 0x110
	[SerializeField]
	private GachaRatesView ratesView; // 0x118
	[SerializeField]
	private GachaHistoryView historyView; // 0x120
	private GachaBannersData _data; // 0x128
	private GachaBannerDTO _current; // 0x130
	private string _wantType; // 0x138
	private int _userId; // 0x140
	private bool _busy; // 0x144
	private bool _wired; // 0x145
	private float _countdownLeft; // 0x148
	private readonly List<WeaponDropDTO> _pendingWeaponDrops; // 0x150
	private long _lastShownSecond; // 0x158
	private bool _chestOpen; // 0x160

	// Properties
	private bool IsWeaponBanner { get; } // 0x00000001804CA2F0-0x00000001804CA380 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 736
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__50_0; // 0x08

		// Constructors
		static __c(); // 0x00000001804CABD0-0x00000001804CAC70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadBanners_b__50_0(string err); // 0x00000001804CAC70-0x00000001804CAD00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 737
	{
		// Fields
		public Image target; // 0x10

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderPity_b__0(float v); // 0x00000001804CAD00-0x00000001804CAE10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 738
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public GachaRollItemDTO[] results; // 0x18
		public int bulk; // 0x20
		public string againCost; // 0x28

		// Constructors
		public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRollOk_b__0(); // 0x00000001804CAE10-0x00000001804CB3B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_1 // TypeDefIndex: 739
	{
		// Fields
		public int again; // 0x10
		public __c__DisplayClass66_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass66_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRollOk_b__1(); // 0x00000001804CB3B0-0x00000001804CB3E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 740
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001804CB3E0-0x00000001804CB530
		internal void _ShakeButton_b__1(); // 0x00000001804CB530-0x00000001804CB640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 741
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayChestOpenFx_b__0(); // 0x00000001804CB640-0x00000001804CB7F0
		internal void _PlayChestOpenFx_b__1(); // 0x0000000180336CC0-0x0000000180336CE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_1 // TypeDefIndex: 742
	{
		// Fields
		public Image burst; // 0x10

		// Constructors
		public __c__DisplayClass77_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayChestOpenFx_b__2(float v); // 0x00000001804CB7F0-0x00000001804CB970
		internal void _PlayChestOpenFx_b__3(); // 0x00000001804CB970-0x00000001804CBAC0
	}

	[CompilerGenerated]
	private sealed class _FlushWeaponDropsAfterReveal_d__68 : IEnumerator<object> // TypeDefIndex: 743
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FlushWeaponDropsAfterReveal_d__68(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804CBAC0-0x00000001804CBBC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804CBBC0-0x00000001804CBC00
	}

	[CompilerGenerated]
	private sealed class _LoadBanners_d__50 : IEnumerator<object> // TypeDefIndex: 744
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadBanners_d__50(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804CBC00-0x00000001804CBEF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804CBEF0-0x00000001804CBF30
	}

	// Constructors
	public GachaPanelController(); // 0x00000001804CA5E0-0x00000001804CA780

	// Methods
	private void Awake(); // 0x00000001804C1580-0x00000001804C1590
	public void OpenPanel(); // 0x00000001804C1590-0x00000001804C1800
	private void OnDisable(); // 0x00000001804C1800-0x00000001804C1860
	private void EnsureWired(); // 0x00000001804C1860-0x00000001804C2AF0
	private static void Wire(Button b, UnityAction action); // 0x00000001804C2AF0-0x00000001804C2C00
	private void ClosePanel(); // 0x00000001804C2C00-0x00000001804C2CE0
	private void HideSubViews(); // 0x00000001804C2CE0-0x00000001804C3030
	private void SetPlaceholders(); // 0x00000001804C3030-0x00000001804C3620
	[IteratorStateMachine(typeof(_LoadBanners_d__50))]
	private IEnumerator LoadBanners(); // 0x00000001804C3620-0x00000001804C36C0
	private void OnBanners(GachaBannersData data); // 0x00000001804C36C0-0x00000001804C3850
	private GachaBannerDTO PickBanner(string type); // 0x00000001804C3850-0x00000001804C3910
	private void SwitchTab(string type); // 0x00000001804C3910-0x00000001804C3D70
	private void UpdateTabVisual(); // 0x00000001804C3D70-0x00000001804C3E80
	private void ApplyTabSprite(Button tab, bool selected); // 0x00000001804C3E80-0x00000001804C4260
	private void ShowEmpty(string msg); // 0x00000001804C4260-0x00000001804C47B0
	private void RenderBanner(GachaBannerDTO b); // 0x00000001804C47B0-0x00000001804C4B40
	private void RenderCost(GachaBannerDTO b); // 0x00000001804C4B40-0x00000001804C53E0
	private void RenderPity(GachaBannerDTO b); // 0x00000001804C53E0-0x00000001804C5C90
	private void RenderDailyQuota(GachaBannerDTO b); // 0x00000001804C5C90-0x00000001804C5F90
	private static void ApplyCostIcon(Image img, GachaBannerDTO b); // 0x00000001804C5F90-0x00000001804C62D0
	private void UpdateWalletText(); // 0x00000001804C62D0-0x00000001804C66A0
	private void SetRollInteractable(bool on); // 0x00000001804C66A0-0x00000001804C6880
	public void OnClickRoll(int rollCount); // 0x00000001804C6880-0x00000001804C6E00
	private long WalletOf(string currency); // 0x00000001804C6E00-0x00000001804C6FD0
	private void OnRollOk(GachaRollResultData d); // 0x00000001804C6FD0-0x00000001804C77A0
	private void OnRollErr(string err); // 0x00000001804C77A0-0x00000001804C7850
	[IteratorStateMachine(typeof(_FlushWeaponDropsAfterReveal_d__68))]
	private IEnumerator FlushWeaponDropsAfterReveal(); // 0x00000001804C7850-0x00000001804C78F0
	private void FlushWeaponDrops(); // 0x00000001804C78F0-0x00000001804C7AF0
	private void PlayIdleFx(); // 0x00000001804C7AF0-0x00000001804C7FA0
	private void PlayPressFx(Button b); // 0x00000001804C7FA0-0x00000001804C8480
	private void ShakeButton(Button b); // 0x00000001804C8480-0x00000001804C8800
	private void CancelFx(); // 0x00000001804C8800-0x00000001804C9110
	private void Update(); // 0x00000001804C9110-0x00000001804C92F0
	private void UpdateCountdownText(); // 0x00000001804C92F0-0x00000001804C94E0
	private void PlayChestOpenFx(Action onDone); // 0x00000001804C94E0-0x00000001804C9F40
	private void ResetChestSprite(); // 0x00000001804C9F40-0x00000001804CA2F0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804CA380-0x00000001804CA5E0
	[CompilerGenerated]
	private void _EnsureWired_b__45_0(); // 0x00000001804CA780-0x00000001804CA7D0
	[CompilerGenerated]
	private void _EnsureWired_b__45_1(); // 0x00000001804CA7D0-0x00000001804CA820
	[CompilerGenerated]
	private void _EnsureWired_b__45_2(); // 0x00000001804CA820-0x00000001804CA830
	[CompilerGenerated]
	private void _EnsureWired_b__45_3(); // 0x00000001804CA830-0x00000001804CA860
	[CompilerGenerated]
	private void _EnsureWired_b__45_4(); // 0x00000001804CA860-0x00000001804CA980
	[CompilerGenerated]
	private void _EnsureWired_b__45_5(); // 0x00000001804CA980-0x00000001804CAA90
	[CompilerGenerated]
	private void _EnsureWired_b__45_6(); // 0x00000001804CA830-0x00000001804CA860
	[CompilerGenerated]
	private void _PlayPressFx_b__71_0(); // 0x00000001804CAA90-0x00000001804CABD0
}

