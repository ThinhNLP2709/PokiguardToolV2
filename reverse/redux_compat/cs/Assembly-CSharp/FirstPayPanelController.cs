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
public class FirstPayPanelController : MonoBehaviour // TypeDefIndex: 506
{
	// Fields
	public const string PANEL_KEY = "PanelFirstPay"; // Metadata: 0x0064C4FC
	public const int MAX_TABS = 8; // Metadata: 0x0064C50A
	private const float GIFT_CELL = 70f; // Metadata: 0x0064C50B
	private const float PET_FIT_W = 300f; // Metadata: 0x0064C50F
	private const float PET_FIT_H = 330f; // Metadata: 0x0064C513
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtRecharge; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtReset; // 0x40
	[Header("N\u00FAt h\u00E0nh \u0111\u1ED9ng (N\u1EA1p ngay / Nh\u1EADn / \u0110\u00E3 nh\u1EADn)")]
	[SerializeField]
	private Button btnAction; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtAction; // 0x50
	[Header("3 m\u1ED1c")]
	[SerializeField]
	private TabRefs[] tabs; // 0x58
	[Header("Qu\u00E0 & pet")]
	[SerializeField]
	private RectTransform giftContainer; // 0x60
	[SerializeField]
	private Image imgPet; // 0x68
	[SerializeField]
	private Image petGlow; // 0x70
	[SerializeField]
	private Animator petAnimator; // 0x78
	[SerializeField]
	private Image petFlash; // 0x80
	[SerializeField]
	private RectTransform petContainer; // 0x88
	[SerializeField]
	private RectTransform sweepFx; // 0x90
	[Header("C\u00F4ng t\u1EAFc OTA (node R\u1ED6NG \u2014 admin t\u1EAFt b\u1EB1ng kho\u00E1 firstpay.fx.*)")]
	[SerializeField]
	private GameObject sweepMarker; // 0x98
	[SerializeField]
	private GameObject glowMarker; // 0xA0
	private FirstPayStatusData _status; // 0xA8
	private int _userId; // 0xB0
	private int _selected; // 0xB4
	private bool _busy; // 0xB8
	private bool _wired; // 0xB9
	private bool _subscribed; // 0xBA
	private readonly FirstPayTierState[] _prevState; // 0xC0
	private bool _hasPrevState; // 0xC8
	private readonly List<int> _tweenIds; // 0xD0
	private PetImageFit _petFit; // 0xD8
	private long _petShown; // 0xE0

	// Nested types
	[Serializable]
	public class TabRefs // TypeDefIndex: 507
	{
		// Fields
		public Button button; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject effect; // 0x20
		public CanvasGroup dim; // 0x28
		public GameObject tick; // 0x30

		// Constructors
		public TabRefs(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 508
	{
		// Fields
		public int idx; // 0x10
		public FirstPayPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EnsureWired_b__0(); // 0x000000018038D7D0-0x000000018038D820
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 509
	{
		// Fields
		public FirstPayRewards r; // 0x10
		public string cardTitle; // 0x18
		public Sprite cardIcon; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AttachPetTooltip_b__0(int _); // 0x000000018038D9F0-0x000000018038DBE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass74_0 // TypeDefIndex: 510
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass74_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayPetGlow_b__0(float v); // 0x000000018038DCF0-0x000000018038DD00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass76_0 // TypeDefIndex: 511
	{
		// Fields
		public Image img; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public Action<float> __9__2; // 0x20
		public Action __9__3; // 0x28

		// Constructors
		public __c__DisplayClass76_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayClaimCelebration_b__0(float v); // 0x000000018038DCF0-0x000000018038DD00
		internal void _PlayClaimCelebration_b__1(); // 0x000000018038DD00-0x000000018038DF70
		internal void _PlayClaimCelebration_b__2(float v); // 0x000000018038DCF0-0x000000018038DD00
		internal void _PlayClaimCelebration_b__3(); // 0x000000018038DF70-0x000000018038E000
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass79_0 // TypeDefIndex: 512
	{
		// Fields
		public GameObject go; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public int index; // 0x20
		public CanvasGroup cg; // 0x28

		// Constructors
		public __c__DisplayClass79_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlashUnlock_b__0(); // 0x000000018038E000-0x000000018038E0D0
		internal void _FlashUnlock_b__1(float v); // 0x000000018038E0D0-0x000000018038E160
		internal void _FlashUnlock_b__2(); // 0x000000018038E160-0x000000018038E1E0
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__44 : IEnumerator<object> // TypeDefIndex: 513
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public FirstPayPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018038C5C0-0x000000018038C7A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038C7A0-0x000000018038C7E0
	}

	// Constructors
	public FirstPayPanelController(); // 0x0000000180380440-0x0000000180380530

	// Methods
	private void Awake(); // 0x0000000180378BA0-0x0000000180378BB0
	public void OpenPanel(); // 0x000000018037C470-0x000000018037C610
	private void OnEnable(); // 0x000000018037C210-0x000000018037C220
	private void OnDisable(); // 0x000000018037C120-0x000000018037C210
	private void Subscribe(); // 0x000000018037FBB0-0x000000018037FC30
	private void Unsubscribe(); // 0x0000000180380250-0x00000001803802D0
	private void EnsureWired(); // 0x000000018037A420-0x000000018037B3C0
	private static void Wire(Button b, UnityAction action); // 0x0000000180380370-0x0000000180380440
	private void SetPlaceholders(); // 0x000000018037F410-0x000000018037F830
	private void ClosePanel(); // 0x000000018037A190-0x000000018037A2A0
	[IteratorStateMachine(typeof(_LoadStatus_d__44))]
	private IEnumerator LoadStatus(); // 0x000000018037B960-0x000000018037B9D0
	private void OnStatusOk(FirstPayStatusData d); // 0x000000018037C370-0x000000018037C470
	private void OnStatusErr(string err); // 0x000000018037C2C0-0x000000018037C370
	private static FirstPayTierState StateOf(FirstPayTierDTO t); // 0x000000018037FA90-0x000000018037FAB0
	private int TierCount(); // 0x000000018037FE40-0x000000018037FF80
	private FirstPayTierDTO TierAt(int i); // 0x000000018037FDF0-0x000000018037FE40
	private void RenderTabs(); // 0x000000018037E990-0x000000018037EFC0
	private void OnClickTab(int index); // 0x000000018037C0E0-0x000000018037C120
	private void SelectTab(int index); // 0x000000018037EFC0-0x000000018037F330
	private void RenderGifts(FirstPayTierDTO tier); // 0x000000018037E390-0x000000018037E450
	private void AttachGiftTooltips(List<GameObject> slots, List<RewardDisplayHelper.Entry> entries, FirstPayRewards rewards); // 0x00000001803784A0-0x0000000180378750
	private static string TooltipBodyFor(RewardDisplayHelper.Entry e, FirstPayRewards r); // 0x000000018037FF80-0x0000000180380250
	private static string ElementVn(string element); // 0x000000018037A2A0-0x000000018037A420
	private void AttachPetTooltip(GameObject slot, FirstPayRewards r, Sprite petIcon); // 0x0000000180378750-0x0000000180378BA0
	private static List<RewardDisplayHelper.Entry> BuildEntries(FirstPayRewards r); // 0x0000000180378BB0-0x00000001803791F0
	private void RenderPet(FirstPayTierDTO tier); // 0x000000018037E450-0x000000018037E990
	private void SyncPetGlow(); // 0x000000018037FD00-0x000000018037FDF0
	private void RenderActionButton(FirstPayTierDTO tier); // 0x000000018037E220-0x000000018037E390
	private void OnClickAction(); // 0x000000018037BCA0-0x000000018037BDA0
	private void OpenRecharge(); // 0x000000018037C610-0x000000018037C620
	private void OnClickClaim(long tierId); // 0x000000018037BDA0-0x000000018037C0E0
	private void OnClaimOk(FirstPayClaimData d); // 0x000000018037BA60-0x000000018037BCA0
	private void OnClaimErr(string err); // 0x000000018037B9D0-0x000000018037BA60
	private void SyncActionInteractable(); // 0x000000018037FC30-0x000000018037FD00
	private void UpdateWallet(FirstPayClaimData d); // 0x00000001803802D0-0x0000000180380370
	private void ShowRewards(FirstPayClaimData d); // 0x000000018037F970-0x000000018037FA90
	private static List<GachaRollItemDTO> BuildRevealItems(FirstPayClaimData d); // 0x00000001803791F0-0x0000000180379D20
	private static void AddItem(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0064C4F5 */); // 0x0000000180378380-0x00000001803784A0
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x000000018037C220-0x000000018037C2C0
	private void PlayGlow(int index, bool on); // 0x000000018037D790-0x000000018037DB60
	private void PlayPetGlow(); // 0x000000018037DB60-0x000000018037DEF0
	private void StopPetGlow(); // 0x000000018037FAB0-0x000000018037FBB0
	private void PlayClaimCelebration(); // 0x000000018037D490-0x000000018037D790
	private static void SetImageAlpha(Image img, float a); // 0x000000018037F330-0x000000018037F410
	private void PlaySweep(); // 0x000000018037DEF0-0x000000018037E220
	private void FlashUnlock(int index); // 0x000000018037B4D0-0x000000018037B8E0
	private void CancelFx(); // 0x0000000180379D20-0x000000018037A190
	private static string FormatVnd(int amount); // 0x000000018037B8E0-0x000000018037B960
	private static string ShortVnd(int amount); // 0x000000018037F830-0x000000018037F970
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x000000018037C620-0x000000018037CB00
	private static List<KeyValuePair<long, int>> ParseWeapons(string json); // 0x000000018037CF90-0x000000018037D490
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x000000018037CB00-0x000000018037CF90
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018037B3C0-0x000000018037B4D0
	[CompilerGenerated]
	private void _RenderPet_b__59_0(bool _); // 0x000000018037FD00-0x000000018037FDF0
}

