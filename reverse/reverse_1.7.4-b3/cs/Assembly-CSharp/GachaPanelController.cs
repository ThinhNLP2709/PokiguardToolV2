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
public class GachaPanelController : MonoBehaviour // TypeDefIndex: 734
{
	// Fields
	public const string PANEL_KEY = "PanelGacha"; // Metadata: 0x005EE649
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
	private bool IsWeaponBanner { get; } // 0x00000001804C8CD0-0x00000001804C8D60 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 735
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__50_0; // 0x08

		// Constructors
		static __c(); // 0x00000001804C95B0-0x00000001804C9650
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadBanners_b__50_0(string err); // 0x00000001804C9650-0x00000001804C96E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 736
	{
		// Fields
		public Image target; // 0x10

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderPity_b__0(float v); // 0x00000001804C96E0-0x00000001804C97F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 737
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public GachaRollItemDTO[] results; // 0x18
		public int bulk; // 0x20
		public string againCost; // 0x28

		// Constructors
		public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRollOk_b__0(); // 0x00000001804C97F0-0x00000001804C9D90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_1 // TypeDefIndex: 738
	{
		// Fields
		public int again; // 0x10
		public __c__DisplayClass66_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass66_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnRollOk_b__1(); // 0x00000001804C9D90-0x00000001804C9DC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 739
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001804C9DC0-0x00000001804C9F10
		internal void _ShakeButton_b__1(); // 0x00000001804C9F10-0x00000001804CA020
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 740
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayChestOpenFx_b__0(); // 0x00000001804CA020-0x00000001804CA1D0
		internal void _PlayChestOpenFx_b__1(); // 0x0000000180336BA0-0x0000000180336BC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_1 // TypeDefIndex: 741
	{
		// Fields
		public Image burst; // 0x10

		// Constructors
		public __c__DisplayClass77_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayChestOpenFx_b__2(float v); // 0x00000001804CA1D0-0x00000001804CA350
		internal void _PlayChestOpenFx_b__3(); // 0x00000001804CA350-0x00000001804CA4A0
	}

	[CompilerGenerated]
	private sealed class _FlushWeaponDropsAfterReveal_d__68 : IEnumerator<object> // TypeDefIndex: 742
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804CA4A0-0x00000001804CA5A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804CA5A0-0x00000001804CA5E0
	}

	[CompilerGenerated]
	private sealed class _LoadBanners_d__50 : IEnumerator<object> // TypeDefIndex: 743
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804CA5E0-0x00000001804CA8A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804CA8A0-0x00000001804CA8E0
	}

	// Constructors
	public GachaPanelController(); // 0x00000001804C8FC0-0x00000001804C9160

	// Methods
	private void Awake(); // 0x00000001804BFF90-0x00000001804BFFA0
	public void OpenPanel(); // 0x00000001804BFFA0-0x00000001804C0210
	private void OnDisable(); // 0x00000001804C0210-0x00000001804C0270
	private void EnsureWired(); // 0x00000001804C0270-0x00000001804C1500
	private static void Wire(Button b, UnityAction action); // 0x00000001804C1500-0x00000001804C1610
	private void ClosePanel(); // 0x00000001804C1610-0x00000001804C16F0
	private void HideSubViews(); // 0x00000001804C16F0-0x00000001804C1A40
	private void SetPlaceholders(); // 0x00000001804C1A40-0x00000001804C2030
	[IteratorStateMachine(typeof(_LoadBanners_d__50))]
	private IEnumerator LoadBanners(); // 0x00000001804C2030-0x00000001804C20D0
	private void OnBanners(GachaBannersData data); // 0x00000001804C20D0-0x00000001804C2260
	private GachaBannerDTO PickBanner(string type); // 0x00000001804C2260-0x00000001804C2320
	private void SwitchTab(string type); // 0x00000001804C2320-0x00000001804C2780
	private void UpdateTabVisual(); // 0x00000001804C2780-0x00000001804C2890
	private void ApplyTabSprite(Button tab, bool selected); // 0x00000001804C2890-0x00000001804C2C70
	private void ShowEmpty(string msg); // 0x00000001804C2C70-0x00000001804C31C0
	private void RenderBanner(GachaBannerDTO b); // 0x00000001804C31C0-0x00000001804C3550
	private void RenderCost(GachaBannerDTO b); // 0x00000001804C3550-0x00000001804C3DF0
	private void RenderPity(GachaBannerDTO b); // 0x00000001804C3DF0-0x00000001804C46A0
	private void RenderDailyQuota(GachaBannerDTO b); // 0x00000001804C46A0-0x00000001804C49A0
	private static void ApplyCostIcon(Image img, GachaBannerDTO b); // 0x00000001804C49A0-0x00000001804C4CE0
	private void UpdateWalletText(); // 0x00000001804C4CE0-0x00000001804C50B0
	private void SetRollInteractable(bool on); // 0x00000001804C50B0-0x00000001804C5290
	public void OnClickRoll(int rollCount); // 0x00000001804C5290-0x00000001804C57E0
	private long WalletOf(string currency); // 0x00000001804C57E0-0x00000001804C59B0
	private void OnRollOk(GachaRollResultData d); // 0x00000001804C59B0-0x00000001804C6180
	private void OnRollErr(string err); // 0x00000001804C6180-0x00000001804C6230
	[IteratorStateMachine(typeof(_FlushWeaponDropsAfterReveal_d__68))]
	private IEnumerator FlushWeaponDropsAfterReveal(); // 0x00000001804C6230-0x00000001804C62D0
	private void FlushWeaponDrops(); // 0x00000001804C62D0-0x00000001804C64D0
	private void PlayIdleFx(); // 0x00000001804C64D0-0x00000001804C6980
	private void PlayPressFx(Button b); // 0x00000001804C6980-0x00000001804C6E60
	private void ShakeButton(Button b); // 0x00000001804C6E60-0x00000001804C71E0
	private void CancelFx(); // 0x00000001804C71E0-0x00000001804C7AF0
	private void Update(); // 0x00000001804C7AF0-0x00000001804C7CD0
	private void UpdateCountdownText(); // 0x00000001804C7CD0-0x00000001804C7EC0
	private void PlayChestOpenFx(Action onDone); // 0x00000001804C7EC0-0x00000001804C8920
	private void ResetChestSprite(); // 0x00000001804C8920-0x00000001804C8CD0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804C8D60-0x00000001804C8FC0
	[CompilerGenerated]
	private void _EnsureWired_b__45_0(); // 0x00000001804C9160-0x00000001804C91B0
	[CompilerGenerated]
	private void _EnsureWired_b__45_1(); // 0x00000001804C91B0-0x00000001804C9200
	[CompilerGenerated]
	private void _EnsureWired_b__45_2(); // 0x00000001804C9200-0x00000001804C9210
	[CompilerGenerated]
	private void _EnsureWired_b__45_3(); // 0x00000001804C9210-0x00000001804C9240
	[CompilerGenerated]
	private void _EnsureWired_b__45_4(); // 0x00000001804C9240-0x00000001804C9360
	[CompilerGenerated]
	private void _EnsureWired_b__45_5(); // 0x00000001804C9360-0x00000001804C9470
	[CompilerGenerated]
	private void _EnsureWired_b__45_6(); // 0x00000001804C9210-0x00000001804C9240
	[CompilerGenerated]
	private void _PlayPressFx_b__71_0(); // 0x00000001804C9470-0x00000001804C95B0
}

