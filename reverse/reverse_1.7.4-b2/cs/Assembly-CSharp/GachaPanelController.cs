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
public class GachaPanelController : MonoBehaviour // TypeDefIndex: 643
{
	// Fields
	public const string PANEL_KEY = "PanelGacha"; // Metadata: 0x0068B6E8
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
	private bool IsWeaponBanner { get; } // 0x00000001803FF420-0x00000001803FF480 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 644
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__50_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180411280-0x00000001804112F0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadBanners_b__50_0(string err); // 0x000000018040F810-0x000000018040F890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 645
	{
		// Fields
		public Image target; // 0x10

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RenderPity_b__0(float v); // 0x000000018040FFE0-0x0000000180410070
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 646
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public GachaRollItemDTO[] results; // 0x18
		public int bulk; // 0x20
		public string againCost; // 0x28

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnRollOk_b__0(); // 0x0000000180410270-0x0000000180410600
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_1 // TypeDefIndex: 647
	{
		// Fields
		public int again; // 0x10
		public __c__DisplayClass66_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass66_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnRollOk_b__1(); // 0x0000000180410BB0-0x0000000180410BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 648
	{
		// Fields
		public RectTransform rt; // 0x10
		public Vector2 basePos; // 0x18

		// Constructors
		public __c__DisplayClass72_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakeButton_b__0(float t); // 0x0000000180410DE0-0x0000000180410EB0
		internal void _ShakeButton_b__1(); // 0x0000000180410EB0-0x0000000180410F40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 649
	{
		// Fields
		public GachaPanelController __4__this; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass77_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayChestOpenFx_b__0(); // 0x0000000180410F40-0x0000000180411070
		internal void _PlayChestOpenFx_b__1(); // 0x0000000180411070-0x0000000180411090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_1 // TypeDefIndex: 650
	{
		// Fields
		public Image burst; // 0x10

		// Constructors
		public __c__DisplayClass77_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayChestOpenFx_b__2(float v); // 0x0000000180411090-0x0000000180411180
		internal void _PlayChestOpenFx_b__3(); // 0x0000000180411180-0x0000000180411210
	}

	[CompilerGenerated]
	private sealed class _FlushWeaponDropsAfterReveal_d__68 : IEnumerator<object> // TypeDefIndex: 651
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FlushWeaponDropsAfterReveal_d__68(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018040EA30-0x000000018040EAE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040EAE0-0x000000018040EB20
	}

	[CompilerGenerated]
	private sealed class _LoadBanners_d__50 : IEnumerator<object> // TypeDefIndex: 652
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadBanners_d__50(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018040EB20-0x000000018040ED60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040ED60-0x000000018040EDA0
	}

	// Constructors
	public GachaPanelController(); // 0x00000001803FF350-0x00000001803FF420

	// Methods
	private void Awake(); // 0x00000001803F93D0-0x00000001803F93E0
	public void OpenPanel(); // 0x00000001803FBBB0-0x00000001803FBE20
	private void OnDisable(); // 0x00000001803FB500-0x00000001803FB560
	private void EnsureWired(); // 0x00000001803F9850-0x00000001803FA8F0
	private static void Wire(Button b, UnityAction action); // 0x00000001803FF2B0-0x00000001803FF350
	private void ClosePanel(); // 0x00000001803F9780-0x00000001803F9850
	private void HideSubViews(); // 0x00000001803FAC10-0x00000001803FAD20
	private void SetPlaceholders(); // 0x00000001803FDCE0-0x00000001803FDFA0
	[IteratorStateMachine(typeof(_LoadBanners_d__50))]
	private IEnumerator LoadBanners(); // 0x00000001803FAD20-0x00000001803FAD90
	private void OnBanners(GachaBannersData data); // 0x00000001803FAD90-0x00000001803FAEA0
	private GachaBannerDTO PickBanner(string type); // 0x00000001803FBE20-0x00000001803FBEC0
	private void SwitchTab(string type); // 0x00000001803FE550-0x00000001803FE720
	private void UpdateTabVisual(); // 0x00000001803FED30-0x00000001803FEDD0
	private void ApplyTabSprite(Button tab, bool selected); // 0x00000001803F91E0-0x00000001803F93D0
	private void ShowEmpty(string msg); // 0x00000001803FE2D0-0x00000001803FE550
	private void RenderBanner(GachaBannerDTO b); // 0x00000001803FCB80-0x00000001803FCF40
	private void RenderCost(GachaBannerDTO b); // 0x00000001803FCF40-0x00000001803FD420
	private void RenderPity(GachaBannerDTO b); // 0x00000001803FD5F0-0x00000001803FDB20
	private void RenderDailyQuota(GachaBannerDTO b); // 0x00000001803FD420-0x00000001803FD5F0
	private static void ApplyCostIcon(Image img, GachaBannerDTO b); // 0x00000001803F9090-0x00000001803F91E0
	private void UpdateWalletText(); // 0x00000001803FEDD0-0x00000001803FF040
	private void SetRollInteractable(bool on); // 0x00000001803FDFA0-0x00000001803FE080
	public void OnClickRoll(int rollCount); // 0x00000001803FAEA0-0x00000001803FB500
	private long WalletOf(string currency); // 0x00000001803FF160-0x00000001803FF2B0
	private void OnRollOk(GachaRollResultData d); // 0x00000001803FB600-0x00000001803FBBB0
	private void OnRollErr(string err); // 0x00000001803FB560-0x00000001803FB600
	[IteratorStateMachine(typeof(_FlushWeaponDropsAfterReveal_d__68))]
	private IEnumerator FlushWeaponDropsAfterReveal(); // 0x00000001803FAA00-0x00000001803FAA70
	private void FlushWeaponDrops(); // 0x00000001803FAA70-0x00000001803FAC10
	private void PlayIdleFx(); // 0x00000001803FC5C0-0x00000001803FC890
	private void PlayPressFx(Button b); // 0x00000001803FC890-0x00000001803FCB80
	private void ShakeButton(Button b); // 0x00000001803FE080-0x00000001803FE2D0
	private void CancelFx(); // 0x00000001803F93E0-0x00000001803F9780
	private void Update(); // 0x00000001803FF040-0x00000001803FF160
	private void UpdateCountdownText(); // 0x00000001803FEBE0-0x00000001803FED30
	private void PlayChestOpenFx(Action onDone); // 0x00000001803FBEC0-0x00000001803FC5C0
	private void ResetChestSprite(); // 0x00000001803FDB20-0x00000001803FDCE0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803FA8F0-0x00000001803FAA00
	[CompilerGenerated]
	private void _EnsureWired_b__45_0(); // 0x00000001803FE720-0x00000001803FE760
	[CompilerGenerated]
	private void _EnsureWired_b__45_1(); // 0x00000001803FE760-0x00000001803FE7A0
	[CompilerGenerated]
	private void _EnsureWired_b__45_2(); // 0x00000001803FE7A0-0x00000001803FE7B0
	[CompilerGenerated]
	private void _EnsureWired_b__45_3(); // 0x00000001803FE7B0-0x00000001803FE7E0
	[CompilerGenerated]
	private void _EnsureWired_b__45_4(); // 0x00000001803FE7E0-0x00000001803FE9A0
	[CompilerGenerated]
	private void _EnsureWired_b__45_5(); // 0x00000001803FE9A0-0x00000001803FEB20
	[CompilerGenerated]
	private void _EnsureWired_b__45_6(); // 0x00000001803FE7B0-0x00000001803FE7E0
	[CompilerGenerated]
	private void _PlayPressFx_b__71_0(); // 0x00000001803FEB20-0x00000001803FEBE0
}

