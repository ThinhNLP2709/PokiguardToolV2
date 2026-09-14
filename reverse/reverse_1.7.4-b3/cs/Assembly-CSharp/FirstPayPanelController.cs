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
public class FirstPayPanelController : MonoBehaviour // TypeDefIndex: 672
{
	// Fields
	public const string PANEL_KEY = "PanelFirstPay"; // Metadata: 0x005EE60F
	public const int MAX_TABS = 8; // Metadata: 0x005EE61D
	private const float GIFT_CELL = 70f; // Metadata: 0x005EE61E
	private const float PET_FIT_W = 300f; // Metadata: 0x005EE622
	private const float PET_FIT_H = 330f; // Metadata: 0x005EE626
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
	[Header("N\u00FAt h\u00E0nh \u0111\u1ED9ng (Donate ngay / Nh\u1EADn / \u0110\u00E3 nh\u1EADn)")]
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
	public class TabRefs // TypeDefIndex: 673
	{
		// Fields
		public Button button; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject effect; // 0x20
		public CanvasGroup dim; // 0x28
		public GameObject tick; // 0x30

		// Constructors
		public TabRefs(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 674
	{
		// Fields
		public int idx; // 0x10
		public FirstPayPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureWired_b__0(); // 0x0000000180495FB0-0x0000000180496000
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 675
	{
		// Fields
		public FirstPayRewards r; // 0x10
		public string cardTitle; // 0x18
		public Sprite cardIcon; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachPetTooltip_b__0(int _); // 0x0000000180496000-0x0000000180496210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 676
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPetGlow_b__0(float v); // 0x0000000180496210-0x0000000180496220
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 677
	{
		// Fields
		public Image img; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public Action<float> __9__2; // 0x20
		public Action __9__3; // 0x28

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayClaimCelebration_b__0(float v); // 0x0000000180496210-0x0000000180496220
		internal void _PlayClaimCelebration_b__1(); // 0x0000000180496220-0x00000001804965C0
		internal void _PlayClaimCelebration_b__2(float v); // 0x0000000180496210-0x0000000180496220
		internal void _PlayClaimCelebration_b__3(); // 0x00000001804965C0-0x0000000180496710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 678
	{
		// Fields
		public GameObject go; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public int index; // 0x20
		public CanvasGroup cg; // 0x28

		// Constructors
		public __c__DisplayClass80_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlashUnlock_b__0(); // 0x0000000180496710-0x00000001804968C0
		internal void _FlashUnlock_b__1(float v); // 0x00000001804968C0-0x0000000180496A10
		internal void _FlashUnlock_b__2(); // 0x0000000180496A10-0x0000000180496B60
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__44 : IEnumerator<object> // TypeDefIndex: 679
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public FirstPayPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180496B60-0x0000000180496E90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180496E90-0x0000000180496ED0
	}

	// Constructors
	public FirstPayPanelController(); // 0x0000000180495D90-0x0000000180495FA0

	// Methods
	private void Awake(); // 0x0000000180489FF0-0x000000018048A000
	public void OpenPanel(); // 0x000000018048A000-0x000000018048A290
	private void OnEnable(); // 0x000000018048A290-0x000000018048A2A0
	private void OnDisable(); // 0x000000018048A2A0-0x000000018048A3A0
	private void Subscribe(); // 0x000000018048A3A0-0x000000018048A430
	private void Unsubscribe(); // 0x000000018048A430-0x000000018048A4C0
	private void EnsureWired(); // 0x000000018048A4C0-0x000000018048B830
	private static void Wire(Button b, UnityAction action); // 0x000000018048B830-0x000000018048B9C0
	private void SetPlaceholders(); // 0x000000018048B9C0-0x000000018048C370
	private void ClosePanel(); // 0x000000018048C370-0x000000018048C4A0
	[IteratorStateMachine(typeof(_LoadStatus_d__44))]
	private IEnumerator LoadStatus(); // 0x000000018048C4A0-0x000000018048C540
	private void OnStatusOk(FirstPayStatusData d); // 0x000000018048C540-0x000000018048C690
	private void OnStatusErr(string err); // 0x000000018048C690-0x000000018048C760
	private static FirstPayTierState StateOf(FirstPayTierDTO t); // 0x000000018048C760-0x000000018048C780
	private int TierCount(); // 0x000000018048C780-0x000000018048C960
	private FirstPayTierDTO TierAt(int i); // 0x000000018048C960-0x000000018048C9B0
	private void RenderTabs(); // 0x000000018048C9B0-0x000000018048D290
	private void OnClickTab(int index); // 0x000000018048D290-0x000000018048D2D0
	private void SelectTab(int index); // 0x000000018048D2D0-0x000000018048D7C0
	private void RenderGifts(FirstPayTierDTO tier); // 0x000000018048D7C0-0x000000018048D940
	private void AttachGiftTooltips(List<GameObject> slots, List<RewardDisplayHelper.Entry> entries, FirstPayRewards rewards); // 0x000000018048D940-0x000000018048DDC0
	private static string TooltipBodyFor(RewardDisplayHelper.Entry e, FirstPayRewards r); // 0x000000018048DDC0-0x000000018048E250
	private static string ElementVn(string element); // 0x000000018048E250-0x000000018048E2D0
	private void AttachPetTooltip(GameObject slot, FirstPayRewards r, Sprite petIcon); // 0x000000018048E2D0-0x000000018048E9D0
	private static List<RewardDisplayHelper.Entry> BuildEntries(FirstPayRewards r); // 0x000000018048E9D0-0x000000018048F1A0
	private static WeaponRewardView[] WeaponViews(FirstPayRewards r); // 0x000000018048F1A0-0x000000018048F220
	private void RenderPet(FirstPayTierDTO tier); // 0x000000018048F220-0x000000018048FD60
	private void SyncPetGlow(); // 0x000000018048FD60-0x0000000180490060
	private void RenderActionButton(FirstPayTierDTO tier); // 0x0000000180490060-0x00000001804903F0
	private void OnClickAction(); // 0x00000001804903F0-0x0000000180490530
	private void OpenRecharge(); // 0x0000000180490530-0x0000000180490560
	private void OnClickClaim(long tierId); // 0x0000000180490560-0x00000001804909F0
	private void OnClaimOk(FirstPayClaimData d); // 0x00000001804909F0-0x0000000180490D90
	private void OnClaimErr(string err); // 0x0000000180490D90-0x0000000180490E30
	private void SyncActionInteractable(); // 0x0000000180490E30-0x0000000180490F80
	private void UpdateWallet(FirstPayClaimData d); // 0x0000000180490F80-0x00000001804910A0
	private void ShowRewards(FirstPayClaimData d); // 0x00000001804910A0-0x0000000180491200
	private static List<GachaRollItemDTO> BuildRevealItems(FirstPayClaimData d); // 0x0000000180491200-0x0000000180491EF0
	private static void AddItem(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005EE608 */); // 0x0000000180491EF0-0x0000000180492040
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x0000000180492040-0x00000001804920E0
	private void PlayGlow(int index, bool on); // 0x00000001804920E0-0x00000001804926E0
	private void PlayPetGlow(); // 0x00000001804926E0-0x0000000180492BD0
	private void StopPetGlow(); // 0x0000000180492BD0-0x0000000180492DF0
	private void PlayClaimCelebration(); // 0x0000000180492DF0-0x0000000180493320
	private static void SetImageAlpha(Image img, float a); // 0x0000000180493320-0x0000000180493470
	private void PlaySweep(); // 0x0000000180493470-0x0000000180493A60
	private void FlashUnlock(int index); // 0x0000000180493A60-0x0000000180493F80
	private void CancelFx(); // 0x0000000180493F80-0x0000000180494830
	private static string FormatVnd(int amount); // 0x0000000180494830-0x0000000180494940
	private static string ShortVnd(int amount); // 0x0000000180494940-0x0000000180494B90
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x0000000180494B90-0x00000001804950E0
	private static List<KeyValuePair<long, int>> ParseWeapons(string json); // 0x00000001804950E0-0x0000000180495640
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x0000000180495640-0x0000000180495B30
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x0000000180495B30-0x0000000180495D90
	[CompilerGenerated]
	private void _RenderPet_b__60_0(bool _); // 0x0000000180495FA0-0x0000000180495FB0
}

