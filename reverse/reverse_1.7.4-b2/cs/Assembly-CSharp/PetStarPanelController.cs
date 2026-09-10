/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class PetStarPanelController : MonoBehaviour // TypeDefIndex: 885
{
	// Fields
	[Header("Root")]
	public GameObject panelRoot; // 0x20
	public Button btnBack; // 0x28
	[Header("Kh\u1ED1i tr\u01B0ng b\u00E0y pet")]
	public Image imgPetBig; // 0x30
	[Tooltip("Qu\u1EA7ng s\u00E1ng xoay sau pet \u2014 t\u1ED1c \u0111\u1ED9 t\u0103ng theo s\u1ED1 sao.")]
	public Image imgGlow; // 0x38
	public Transform starRow; // 0x40
	public UnityEngine.UI.Text txtStarLabel; // 0x48
	public UnityEngine.UI.Text txtPetName; // 0x50
	[Header("Preview ch\u1EC9 s\u1ED1")]
	public UnityEngine.UI.Text txtHpNow; // 0x58
	public UnityEngine.UI.Text txtHpNext; // 0x60
	public UnityEngine.UI.Text txtAtkNow; // 0x68
	public UnityEngine.UI.Text txtAtkNext; // 0x70
	public UnityEngine.UI.Text txtManaNow; // 0x78
	public UnityEngine.UI.Text txtManaNext; // 0x80
	public UnityEngine.UI.Text txtBonusNow; // 0x88
	public UnityEngine.UI.Text txtBonusNext; // 0x90
	[Header("M\u1EA3nh")]
	public Image imgShardIcon; // 0x98
	public Image imgShardPiece; // 0xA0
	public UnityEngine.UI.Text txtShardProgress; // 0xA8
	public Slider sliderShard; // 0xB0
	[Header("H\u00E0nh \u0111\u1ED9ng")]
	public Button btnUpgrade; // 0xB8
	public UnityEngine.UI.Text txtUpgradeLabel; // 0xC0
	[Header("FX")]
	[Tooltip("\u1EA2nh ph\u1EE7 to\u00E0n panel d\u00F9ng l\u00E0m nh\u00E1y s\u00E1ng khi n\u00E2ng th\u00E0nh c\u00F4ng.")]
	public Image imgFlash; // 0xC8
	[Tooltip("Ch\u1EEF bay l\u00EAn khi n\u00E2ng th\u00E0nh c\u00F4ng (vd \'+15% S\u1EE8C M\u1EA0NH\').")]
	public UnityEngine.UI.Text txtFloating; // 0xD0
	private const float GLOW_SECONDS_PER_TURN = 8f; // Metadata: 0x0068BE0B
	private const float FLASH_PEAK_ALPHA = 0.55f; // Metadata: 0x0068BE0F
	private const float PET_FIT_SIZE = 150f; // Metadata: 0x0068BE13
	private Animator _petAnimator; // 0xD8
	private PetImageFit _petFit; // 0xE0
	private int _userId; // 0xE8
	private long _petId; // 0xF0
	private string _petName; // 0xF8
	private int _star; // 0x100
	private int _maxStar; // 0x104
	private int _shardCount; // 0x108
	private int _nextCost; // 0x10C
	private bool _busy; // 0x110
	private bool _wired; // 0x111
	private bool _finalForm; // 0x112
	private bool _starEligible; // 0x113
	private string _blockedReason; // 0x118
	private const string MSG_NOT_ELIGIBLE = "Ch\u1EC9 pet Huy\u1EC1n tho\u1EA1i / Galaxy / Mega m\u1EDBi n\u00E2ng sao v\u00E0 c\u00F3 m\u1EA3nh"; // Metadata: 0x0068BE17
	private CanvasGroup _cg; // 0x120
	private Vector3 _floatingHome; // 0x128
	private bool _floatingHomeSaved; // 0x134

	// Properties
	private bool Alive { get; } // 0x00000001804C2690-0x00000001804C26A0 
	public bool IsOpen { get; } // 0x00000001804C26A0-0x00000001804C2720 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 886
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__55_0; // 0x08
		public static Action<string> __9__63_1; // 0x10

		// Constructors
		static __c(); // 0x00000001804C8010-0x00000001804C8080
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadInfoCo_b__55_0(string err); // 0x00000001804C7A70-0x00000001804C7AE0
		internal void _UpgradeCo_b__63_1(string err); // 0x00000001804C7AE0-0x00000001804C7B90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 887
	{
		// Fields
		public PetStarPanelController __4__this; // 0x10
		public Vector3 home; // 0x18

		// Constructors
		public __c__DisplayClass69_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayPressFx_b__0(); // 0x00000001804C7F60-0x00000001804C8010
	}

	[CompilerGenerated]
	private sealed class _LoadInfoCo_d__55 : IEnumerator<object> // TypeDefIndex: 888
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetStarPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadInfoCo_d__55(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C6E40-0x00000001804C7080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C7080-0x00000001804C70C0
	}

	[CompilerGenerated]
	private sealed class _UpgradeCo_d__63 : IEnumerator<object> // TypeDefIndex: 889
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetStarPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCo_d__63(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804C8080-0x00000001804C8320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C8320-0x00000001804C8440
	}

	// Constructors
	public PetStarPanelController(); // 0x00000001804C2670-0x00000001804C2690

	// Methods
	private void Awake(); // 0x00000001804BE020-0x00000001804BE030
	private void WireOnce(); // 0x00000001804C21D0-0x00000001804C2670
	private void OnDisable(); // 0x00000001804BE640-0x00000001804BE6C0
	public void Open(long petId, string petName); // 0x00000001804BEA60-0x00000001804BEDB0
	public void Close(); // 0x00000001804BE3A0-0x00000001804BE490
	private void SetPlaceholders(); // 0x00000001804C0500-0x00000001804C0A50
	private void Reload(); // 0x00000001804C02F0-0x00000001804C0380
	[IteratorStateMachine(typeof(_LoadInfoCo_d__55))]
	private IEnumerator LoadInfoCo(); // 0x00000001804BE530-0x00000001804BE5A0
	private void OnInfoLoaded(PetStarInfoResponse resp); // 0x00000001804BE6C0-0x00000001804BE810
	private void PaintStars(); // 0x00000001804BF210-0x00000001804BF350
	private void PaintStats(int hp, int hpNext, int atk, int atkNext, int mana, int manaNext, int bonus, int nextBonus); // 0x00000001804BF350-0x00000001804BFA00
	private static string Delta(int d); // 0x00000001804BE490-0x00000001804BE530
	private void PaintShard(); // 0x00000001804BEDB0-0x00000001804BF210
	private void UpdateUpgradeButton(bool owned); // 0x00000001804C1B50-0x00000001804C2160
	private void OnUpgradeClicked(); // 0x00000001804BE810-0x00000001804BEA60
	[IteratorStateMachine(typeof(_UpgradeCo_d__63))]
	private IEnumerator UpgradeCo(); // 0x00000001804C2160-0x00000001804C21D0
	private void SetBusy(bool busy); // 0x00000001804C0460-0x00000001804C0500
	private void NotifyStarChanged(); // 0x00000001804BE5A0-0x00000001804BE640
	private void StartGlow(); // 0x00000001804C0EA0-0x00000001804C1340
	private void StartPulse(); // 0x00000001804C1340-0x00000001804C14E0
	private void StopPulse(); // 0x00000001804C14E0-0x00000001804C15D0
	private void PlayPressFx(); // 0x00000001804BFA00-0x00000001804BFC20
	private void PlaySuccessFx(int oldStar, int newStar, int bonusPercent); // 0x00000001804BFC20-0x00000001804C02F0
	private void ShowFloating(string text); // 0x00000001804C0BA0-0x00000001804C0EA0
	private void CancelFx(); // 0x00000001804BE030-0x00000001804BE3A0
	private static void SetText(UnityEngine.UI.Text t, string s); // 0x00000001804C0A50-0x00000001804C0AE0
	private static void SetText(UnityEngine.UI.Text t, string s, Color c); // 0x00000001804C0AE0-0x00000001804C0BA0
	private static void SetAlpha(Graphic g, float a); // 0x00000001804C0380-0x00000001804C0460
	[CompilerGenerated]
	private void _UpgradeCo_b__63_0(PetStarUpgradeResponse resp); // 0x00000001804C18D0-0x00000001804C1B50
	[CompilerGenerated]
	private void _PlaySuccessFx_b__70_0(float v); // 0x00000001804C15D0-0x00000001804C15E0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__70_1(); // 0x00000001804C15E0-0x00000001804C1760
	[CompilerGenerated]
	private void _PlaySuccessFx_b__70_2(float v); // 0x00000001804C15D0-0x00000001804C15E0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__70_3(); // 0x00000001804C1760-0x00000001804C17F0
	[CompilerGenerated]
	private void _ShowFloating_b__71_0(float v); // 0x00000001804C17F0-0x00000001804C1800
	[CompilerGenerated]
	private void _ShowFloating_b__71_1(); // 0x00000001804C1800-0x00000001804C18D0
}

