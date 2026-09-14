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
public class FirstPayPanelController : MonoBehaviour // TypeDefIndex: 673
{
	// Fields
	public const string PANEL_KEY = "PanelFirstPay"; // Metadata: 0x005EF9E0
	public const int MAX_TABS = 8; // Metadata: 0x005EF9EE
	private const float GIFT_CELL = 70f; // Metadata: 0x005EF9EF
	private const float PET_FIT_W = 300f; // Metadata: 0x005EF9F3
	private const float PET_FIT_H = 330f; // Metadata: 0x005EF9F7
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
	public class TabRefs // TypeDefIndex: 674
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
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 675
	{
		// Fields
		public int idx; // 0x10
		public FirstPayPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureWired_b__0(); // 0x00000001804972B0-0x0000000180497300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 676
	{
		// Fields
		public FirstPayRewards r; // 0x10
		public string cardTitle; // 0x18
		public Sprite cardIcon; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachPetTooltip_b__0(int _); // 0x0000000180497300-0x0000000180497510
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 677
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPetGlow_b__0(float v); // 0x0000000180497510-0x0000000180497520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 678
	{
		// Fields
		public Image img; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public Action<float> __9__2; // 0x20
		public Action __9__3; // 0x28

		// Constructors
		public __c__DisplayClass77_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayClaimCelebration_b__0(float v); // 0x0000000180497510-0x0000000180497520
		internal void _PlayClaimCelebration_b__1(); // 0x0000000180497520-0x00000001804978C0
		internal void _PlayClaimCelebration_b__2(float v); // 0x0000000180497510-0x0000000180497520
		internal void _PlayClaimCelebration_b__3(); // 0x00000001804978C0-0x0000000180497A10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 679
	{
		// Fields
		public GameObject go; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public int index; // 0x20
		public CanvasGroup cg; // 0x28

		// Constructors
		public __c__DisplayClass80_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlashUnlock_b__0(); // 0x0000000180497A10-0x0000000180497BC0
		internal void _FlashUnlock_b__1(float v); // 0x0000000180497BC0-0x0000000180497D10
		internal void _FlashUnlock_b__2(); // 0x0000000180497D10-0x0000000180497E60
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__44 : IEnumerator<object> // TypeDefIndex: 680
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180497E60-0x00000001804981B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804981B0-0x00000001804981F0
	}

	// Constructors
	public FirstPayPanelController(); // 0x0000000180497090-0x00000001804972A0

	// Methods
	private void Awake(); // 0x000000018048B2D0-0x000000018048B2E0
	public void OpenPanel(); // 0x000000018048B2E0-0x000000018048B570
	private void OnEnable(); // 0x000000018048B570-0x000000018048B580
	private void OnDisable(); // 0x000000018048B580-0x000000018048B680
	private void Subscribe(); // 0x000000018048B680-0x000000018048B710
	private void Unsubscribe(); // 0x000000018048B710-0x000000018048B7A0
	private void EnsureWired(); // 0x000000018048B7A0-0x000000018048CB10
	private static void Wire(Button b, UnityAction action); // 0x000000018048CB10-0x000000018048CCA0
	private void SetPlaceholders(); // 0x000000018048CCA0-0x000000018048D650
	private void ClosePanel(); // 0x000000018048D650-0x000000018048D780
	[IteratorStateMachine(typeof(_LoadStatus_d__44))]
	private IEnumerator LoadStatus(); // 0x000000018048D780-0x000000018048D820
	private void OnStatusOk(FirstPayStatusData d); // 0x000000018048D820-0x000000018048D970
	private void OnStatusErr(string err); // 0x000000018048D970-0x000000018048DA40
	private static FirstPayTierState StateOf(FirstPayTierDTO t); // 0x000000018048DA40-0x000000018048DA60
	private int TierCount(); // 0x000000018048DA60-0x000000018048DC40
	private FirstPayTierDTO TierAt(int i); // 0x000000018048DC40-0x000000018048DC90
	private void RenderTabs(); // 0x000000018048DC90-0x000000018048E570
	private void OnClickTab(int index); // 0x000000018048E570-0x000000018048E5B0
	private void SelectTab(int index); // 0x000000018048E5B0-0x000000018048EAA0
	private void RenderGifts(FirstPayTierDTO tier); // 0x000000018048EAA0-0x000000018048EC20
	private void AttachGiftTooltips(List<GameObject> slots, List<RewardDisplayHelper.Entry> entries, FirstPayRewards rewards); // 0x000000018048EC20-0x000000018048F0A0
	private static string TooltipBodyFor(RewardDisplayHelper.Entry e, FirstPayRewards r); // 0x000000018048F0A0-0x000000018048F530
	private static string ElementVn(string element); // 0x000000018048F530-0x000000018048F5B0
	private void AttachPetTooltip(GameObject slot, FirstPayRewards r, Sprite petIcon); // 0x000000018048F5B0-0x000000018048FCB0
	private static List<RewardDisplayHelper.Entry> BuildEntries(FirstPayRewards r); // 0x000000018048FCB0-0x0000000180490480
	private static WeaponRewardView[] WeaponViews(FirstPayRewards r); // 0x0000000180490480-0x0000000180490500
	private void RenderPet(FirstPayTierDTO tier); // 0x0000000180490500-0x0000000180491040
	private void SyncPetGlow(); // 0x0000000180491040-0x0000000180491340
	private void RenderActionButton(FirstPayTierDTO tier); // 0x0000000180491340-0x00000001804916D0
	private void OnClickAction(); // 0x00000001804916D0-0x0000000180491810
	private void OpenRecharge(); // 0x0000000180491810-0x0000000180491840
	private void OnClickClaim(long tierId); // 0x0000000180491840-0x0000000180491CF0
	private void OnClaimOk(FirstPayClaimData d); // 0x0000000180491CF0-0x0000000180492090
	private void OnClaimErr(string err); // 0x0000000180492090-0x0000000180492130
	private void SyncActionInteractable(); // 0x0000000180492130-0x0000000180492280
	private void UpdateWallet(FirstPayClaimData d); // 0x0000000180492280-0x00000001804923A0
	private void ShowRewards(FirstPayClaimData d); // 0x00000001804923A0-0x0000000180492500
	private static List<GachaRollItemDTO> BuildRevealItems(FirstPayClaimData d); // 0x0000000180492500-0x00000001804931F0
	private static void AddItem(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x005EF9D9 */); // 0x00000001804931F0-0x0000000180493340
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x0000000180493340-0x00000001804933E0
	private void PlayGlow(int index, bool on); // 0x00000001804933E0-0x00000001804939E0
	private void PlayPetGlow(); // 0x00000001804939E0-0x0000000180493ED0
	private void StopPetGlow(); // 0x0000000180493ED0-0x00000001804940F0
	private void PlayClaimCelebration(); // 0x00000001804940F0-0x0000000180494620
	private static void SetImageAlpha(Image img, float a); // 0x0000000180494620-0x0000000180494770
	private void PlaySweep(); // 0x0000000180494770-0x0000000180494D60
	private void FlashUnlock(int index); // 0x0000000180494D60-0x0000000180495280
	private void CancelFx(); // 0x0000000180495280-0x0000000180495B30
	private static string FormatVnd(int amount); // 0x0000000180495B30-0x0000000180495C40
	private static string ShortVnd(int amount); // 0x0000000180495C40-0x0000000180495E90
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x0000000180495E90-0x00000001804963E0
	private static List<KeyValuePair<long, int>> ParseWeapons(string json); // 0x00000001804963E0-0x0000000180496940
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x0000000180496940-0x0000000180496E30
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x0000000180496E30-0x0000000180497090
	[CompilerGenerated]
	private void _RenderPet_b__60_0(bool _); // 0x00000001804972A0-0x00000001804972B0
}

