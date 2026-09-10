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
public class FirstPayPanelController : MonoBehaviour // TypeDefIndex: 580
{
	// Fields
	public const string PANEL_KEY = "PanelFirstPay"; // Metadata: 0x0068B6A7
	public const int MAX_TABS = 8; // Metadata: 0x0068B6B5
	private const float GIFT_CELL = 70f; // Metadata: 0x0068B6B6
	private const float PET_FIT_W = 300f; // Metadata: 0x0068B6BA
	private const float PET_FIT_H = 330f; // Metadata: 0x0068B6BE
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
	public class TabRefs // TypeDefIndex: 581
	{
		// Fields
		public Button button; // 0x10
		public UnityEngine.UI.Text label; // 0x18
		public GameObject effect; // 0x20
		public CanvasGroup dim; // 0x28
		public GameObject tick; // 0x30

		// Constructors
		public TabRefs(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass40_0 // TypeDefIndex: 582
	{
		// Fields
		public int idx; // 0x10
		public FirstPayPanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass40_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureWired_b__0(); // 0x00000001803F6010-0x00000001803F6060
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 583
	{
		// Fields
		public FirstPayRewards r; // 0x10
		public string cardTitle; // 0x18
		public Sprite cardIcon; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AttachPetTooltip_b__0(int _); // 0x00000001803F6230-0x00000001803F6420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 584
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass75_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayPetGlow_b__0(float v); // 0x00000001803F6610-0x00000001803F6620
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 585
	{
		// Fields
		public Image img; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public Action<float> __9__2; // 0x20
		public Action __9__3; // 0x28

		// Constructors
		public __c__DisplayClass77_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayClaimCelebration_b__0(float v); // 0x00000001803F6610-0x00000001803F6620
		internal void _PlayClaimCelebration_b__1(); // 0x00000001803F6620-0x00000001803F6890
		internal void _PlayClaimCelebration_b__2(float v); // 0x00000001803F6610-0x00000001803F6620
		internal void _PlayClaimCelebration_b__3(); // 0x00000001803F6890-0x00000001803F6920
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 586
	{
		// Fields
		public GameObject go; // 0x10
		public FirstPayPanelController __4__this; // 0x18
		public int index; // 0x20
		public CanvasGroup cg; // 0x28

		// Constructors
		public __c__DisplayClass80_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlashUnlock_b__0(); // 0x00000001803F6920-0x00000001803F69F0
		internal void _FlashUnlock_b__1(float v); // 0x00000001803F69F0-0x00000001803F6A80
		internal void _FlashUnlock_b__2(); // 0x00000001803F6A80-0x00000001803F6B00
	}

	[CompilerGenerated]
	private sealed class _LoadStatus_d__44 : IEnumerator<object> // TypeDefIndex: 587
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public FirstPayPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadStatus_d__44(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803F4C10-0x00000001803F4DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803F4DF0-0x00000001803F4E30
	}

	// Constructors
	public FirstPayPanelController(); // 0x00000001803E81D0-0x00000001803E82C0

	// Methods
	private void Awake(); // 0x00000001803E0B10-0x00000001803E0B20
	public void OpenPanel(); // 0x00000001803E4140-0x00000001803E42E0
	private void OnEnable(); // 0x00000001803E3EE0-0x00000001803E3EF0
	private void OnDisable(); // 0x00000001803E3DF0-0x00000001803E3EE0
	private void Subscribe(); // 0x00000001803E78D0-0x00000001803E7950
	private void Unsubscribe(); // 0x00000001803E7F70-0x00000001803E7FF0
	private void EnsureWired(); // 0x00000001803E20F0-0x00000001803E3090
	private static void Wire(Button b, UnityAction action); // 0x00000001803E8100-0x00000001803E81D0
	private void SetPlaceholders(); // 0x00000001803E7130-0x00000001803E7550
	private void ClosePanel(); // 0x00000001803E1F60-0x00000001803E2070
	[IteratorStateMachine(typeof(_LoadStatus_d__44))]
	private IEnumerator LoadStatus(); // 0x00000001803E3630-0x00000001803E36A0
	private void OnStatusOk(FirstPayStatusData d); // 0x00000001803E4040-0x00000001803E4140
	private void OnStatusErr(string err); // 0x00000001803E3F90-0x00000001803E4040
	private static FirstPayTierState StateOf(FirstPayTierDTO t); // 0x00000001803E77B0-0x00000001803E77D0
	private int TierCount(); // 0x00000001803E7B60-0x00000001803E7CA0
	private FirstPayTierDTO TierAt(int i); // 0x00000001803E7B10-0x00000001803E7B60
	private void RenderTabs(); // 0x00000001803E6690-0x00000001803E6CC0
	private void OnClickTab(int index); // 0x00000001803E3DB0-0x00000001803E3DF0
	private void SelectTab(int index); // 0x00000001803E6CC0-0x00000001803E7050
	private void RenderGifts(FirstPayTierDTO tier); // 0x00000001803E6060-0x00000001803E6150
	private void AttachGiftTooltips(List<GameObject> slots, List<RewardDisplayHelper.Entry> entries, FirstPayRewards rewards); // 0x00000001803E03E0-0x00000001803E06C0
	private static string TooltipBodyFor(RewardDisplayHelper.Entry e, FirstPayRewards r); // 0x00000001803E7CA0-0x00000001803E7F70
	private static string ElementVn(string element); // 0x00000001803E2070-0x00000001803E20F0
	private void AttachPetTooltip(GameObject slot, FirstPayRewards r, Sprite petIcon); // 0x00000001803E06C0-0x00000001803E0B10
	private static List<RewardDisplayHelper.Entry> BuildEntries(FirstPayRewards r); // 0x00000001803E0B20-0x00000001803E10E0
	private static WeaponRewardView[] WeaponViews(FirstPayRewards r); // 0x00000001803E8090-0x00000001803E8100
	private void RenderPet(FirstPayTierDTO tier); // 0x00000001803E6150-0x00000001803E6690
	private void SyncPetGlow(); // 0x00000001803E7A20-0x00000001803E7B10
	private void RenderActionButton(FirstPayTierDTO tier); // 0x00000001803E5EF0-0x00000001803E6060
	private void OnClickAction(); // 0x00000001803E3970-0x00000001803E3A70
	private void OpenRecharge(); // 0x00000001803E42E0-0x00000001803E42F0
	private void OnClickClaim(long tierId); // 0x00000001803E3A70-0x00000001803E3DB0
	private void OnClaimOk(FirstPayClaimData d); // 0x00000001803E3730-0x00000001803E3970
	private void OnClaimErr(string err); // 0x00000001803E36A0-0x00000001803E3730
	private void SyncActionInteractable(); // 0x00000001803E7950-0x00000001803E7A20
	private void UpdateWallet(FirstPayClaimData d); // 0x00000001803E7FF0-0x00000001803E8090
	private void ShowRewards(FirstPayClaimData d); // 0x00000001803E7690-0x00000001803E77B0
	private static List<GachaRollItemDTO> BuildRevealItems(FirstPayClaimData d); // 0x00000001803E10E0-0x00000001803E1AF0
	private static void AddItem(List<GachaRollItemDTO> list, string type, int amount, string rarity = "COMMON" /* Metadata: 0x0068B6A0 */); // 0x00000001803E02C0-0x00000001803E03E0
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x00000001803E3EF0-0x00000001803E3F90
	private void PlayGlow(int index, bool on); // 0x00000001803E5460-0x00000001803E5830
	private void PlayPetGlow(); // 0x00000001803E5830-0x00000001803E5BC0
	private void StopPetGlow(); // 0x00000001803E77D0-0x00000001803E78D0
	private void PlayClaimCelebration(); // 0x00000001803E5160-0x00000001803E5460
	private static void SetImageAlpha(Image img, float a); // 0x00000001803E7050-0x00000001803E7130
	private void PlaySweep(); // 0x00000001803E5BC0-0x00000001803E5EF0
	private void FlashUnlock(int index); // 0x00000001803E31A0-0x00000001803E35B0
	private void CancelFx(); // 0x00000001803E1AF0-0x00000001803E1F60
	private static string FormatVnd(int amount); // 0x00000001803E35B0-0x00000001803E3630
	private static string ShortVnd(int amount); // 0x00000001803E7550-0x00000001803E7690
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x00000001803E42F0-0x00000001803E47D0
	private static List<KeyValuePair<long, int>> ParseWeapons(string json); // 0x00000001803E4C60-0x00000001803E5160
	private static List<KeyValuePair<long, int>> ParseStones(string json); // 0x00000001803E47D0-0x00000001803E4C60
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803E3090-0x00000001803E31A0
	[CompilerGenerated]
	private void _RenderPet_b__60_0(bool _); // 0x00000001803E7A20-0x00000001803E7B10
}

