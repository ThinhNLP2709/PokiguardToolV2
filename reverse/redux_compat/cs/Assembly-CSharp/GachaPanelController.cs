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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class GachaPanelController : MonoBehaviour // TypeDefIndex: 566
{
	// Fields
	public const string PANEL_KEY = "PanelGacha"; // Metadata: 0x0064C535
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
	private bool IsWeaponBanner { get; } // 0x0000000180395DB0-0x0000000180395E10 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 567
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__50_0; // 0x08

		// Constructors
		static __c(); // 0x00000001803A7980-0x00000001803A7CD0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadBanners_b__50_0(string err); // 0x00000001803A6030-0x00000001803A60B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 568
	{
		// Fields
		public Image target; // 0x10

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RenderPity_b__0(float v); // 0x00000001803A66E0-0x00000001803A6770
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 569
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public GachaRollItemDTO[] results; // 0x18
		public int bulk; // 0x20
		public string againCost; // 0x28

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnRollOk_b__0(); // 0x00000001803A6970-0x00000001803A6D00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_1 // TypeDefIndex: 570
	{
		// Fields
		public int again; // 0x10
		public __c__DisplayClass66_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass66_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnRollOk_b__1(); // 0x00000001803A72B0-0x00000001803A72E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 571
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass72_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x00000001803A74E0-0x00000001803A75B0
		internal void _ShakeButton_b__1(); // 0x00000001803A75B0-0x00000001803A7640
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 572
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayChestOpenFx_b__0(); // 0x00000001803A7640-0x00000001803A7770
		internal void _PlayChestOpenFx_b__1(); // 0x00000001803A7770-0x00000001803A7790
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_1 // TypeDefIndex: 573
	{
		// Fields
		public Image burst; // 0x10

		// Constructors
		public __c__DisplayClass77_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayChestOpenFx_b__2(float v); // 0x00000001803A7790-0x00000001803A7880
		internal void _PlayChestOpenFx_b__3(); // 0x00000001803A7880-0x00000001803A7910
	}

	[CompilerGenerated]
	private sealed class _FlushWeaponDropsAfterReveal_d__68 : IEnumerator<object> // TypeDefIndex: 574
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FlushWeaponDropsAfterReveal_d__68(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803A5250-0x00000001803A5300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A5300-0x00000001803A5340
	}

	[CompilerGenerated]
	private sealed class _LoadBanners_d__50 : IEnumerator<object> // TypeDefIndex: 575
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadBanners_d__50(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803A5340-0x00000001803A5580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A5580-0x00000001803A55C0
	}

	// Constructors
	public GachaPanelController(); // 0x0000000180395CE0-0x0000000180395DB0

	// Methods
	private void Awake(); // 0x000000018038FD90-0x000000018038FDA0
	public void OpenPanel(); // 0x0000000180392540-0x00000001803927B0
	private void OnDisable(); // 0x0000000180391EC0-0x0000000180391F20
	private void EnsureWired(); // 0x0000000180390210-0x00000001803912B0
	private static void Wire(Button b, UnityAction action); // 0x0000000180395C40-0x0000000180395CE0
	private void ClosePanel(); // 0x0000000180390140-0x0000000180390210
	private void HideSubViews(); // 0x00000001803915D0-0x00000001803916E0
	private void SetPlaceholders(); // 0x0000000180394670-0x0000000180394930
	[IteratorStateMachine(typeof(_LoadBanners_d__50))]
	private IEnumerator LoadBanners(); // 0x00000001803916E0-0x0000000180391750
	private void OnBanners(GachaBannersData data); // 0x0000000180391750-0x0000000180391860
	private GachaBannerDTO PickBanner(string type); // 0x00000001803927B0-0x0000000180392850
	private void SwitchTab(string type); // 0x0000000180394EE0-0x00000001803950B0
	private void UpdateTabVisual(); // 0x00000001803956C0-0x0000000180395760
	private void ApplyTabSprite(Button tab, bool selected); // 0x000000018038FBA0-0x000000018038FD90
	private void ShowEmpty(string msg); // 0x0000000180394C60-0x0000000180394EE0
	private void RenderBanner(GachaBannerDTO b); // 0x0000000180393510-0x00000001803938D0
	private void RenderCost(GachaBannerDTO b); // 0x00000001803938D0-0x0000000180393DB0
	private void RenderPity(GachaBannerDTO b); // 0x0000000180393F80-0x00000001803944B0
	private void RenderDailyQuota(GachaBannerDTO b); // 0x0000000180393DB0-0x0000000180393F80
	private static void ApplyCostIcon(Image img, GachaBannerDTO b); // 0x000000018038FA50-0x000000018038FBA0
	private void UpdateWalletText(); // 0x0000000180395760-0x00000001803959D0
	private void SetRollInteractable(bool on); // 0x0000000180394930-0x0000000180394A10
	public void OnClickRoll(int rollCount); // 0x0000000180391860-0x0000000180391EC0
	private long WalletOf(string currency); // 0x0000000180395AF0-0x0000000180395C40
	private void OnRollOk(GachaRollResultData d); // 0x0000000180391FC0-0x0000000180392540
	private void OnRollErr(string err); // 0x0000000180391F20-0x0000000180391FC0
	[IteratorStateMachine(typeof(_FlushWeaponDropsAfterReveal_d__68))]
	private IEnumerator FlushWeaponDropsAfterReveal(); // 0x00000001803913C0-0x0000000180391430
	private void FlushWeaponDrops(); // 0x0000000180391430-0x00000001803915D0
	private void PlayIdleFx(); // 0x0000000180392F50-0x0000000180393220
	private void PlayPressFx(Button b); // 0x0000000180393220-0x0000000180393510
	private void ShakeButton(Button b); // 0x0000000180394A10-0x0000000180394C60
	private void CancelFx(); // 0x000000018038FDA0-0x0000000180390140
	private void Update(); // 0x00000001803959D0-0x0000000180395AF0
	private void UpdateCountdownText(); // 0x0000000180395570-0x00000001803956C0
	private void PlayChestOpenFx(Action onDone); // 0x0000000180392850-0x0000000180392F50
	private void ResetChestSprite(); // 0x00000001803944B0-0x0000000180394670
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803912B0-0x00000001803913C0
	[CompilerGenerated]
	private void _EnsureWired_b__45_0(); // 0x00000001803950B0-0x00000001803950F0
	[CompilerGenerated]
	private void _EnsureWired_b__45_1(); // 0x00000001803950F0-0x0000000180395130
	[CompilerGenerated]
	private void _EnsureWired_b__45_2(); // 0x0000000180395130-0x0000000180395140
	[CompilerGenerated]
	private void _EnsureWired_b__45_3(); // 0x0000000180395140-0x0000000180395170
	[CompilerGenerated]
	private void _EnsureWired_b__45_4(); // 0x0000000180395170-0x0000000180395330
	[CompilerGenerated]
	private void _EnsureWired_b__45_5(); // 0x0000000180395330-0x00000001803954B0
	[CompilerGenerated]
	private void _EnsureWired_b__45_6(); // 0x0000000180395140-0x0000000180395170
	[CompilerGenerated]
	private void _PlayPressFx_b__71_0(); // 0x00000001803954B0-0x0000000180395570
}

