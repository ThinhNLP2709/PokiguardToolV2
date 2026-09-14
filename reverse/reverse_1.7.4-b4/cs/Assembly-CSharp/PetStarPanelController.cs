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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class PetStarPanelController : MonoBehaviour // TypeDefIndex: 1143
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
	[Tooltip("D\u00F2ng TH\u1EE8C T\u1EC8NH TH\u1EBA CHI\u00CAU d\u01B0\u1EDBi t\u00EAn pet (11/09/2026). \u0110\u1EC3 tr\u1ED1ng th\u00EC panel t\u1EF1 d\u1EF1ng l\u00FAc ch\u1EA1y.")]
	public UnityEngine.UI.Text txtSkillAwaken; // 0x98
	[Header("M\u1EA3nh")]
	public Image imgShardIcon; // 0xA0
	public Image imgShardPiece; // 0xA8
	public UnityEngine.UI.Text txtShardProgress; // 0xB0
	public Slider sliderShard; // 0xB8
	[Header("H\u00E0nh \u0111\u1ED9ng")]
	public Button btnUpgrade; // 0xC0
	public UnityEngine.UI.Text txtUpgradeLabel; // 0xC8
	[Header("FX")]
	[Tooltip("\u1EA2nh ph\u1EE7 to\u00E0n panel d\u00F9ng l\u00E0m nh\u00E1y s\u00E1ng khi n\u00E2ng th\u00E0nh c\u00F4ng.")]
	public Image imgFlash; // 0xD0
	[Tooltip("Ch\u1EEF bay l\u00EAn khi n\u00E2ng th\u00E0nh c\u00F4ng (vd \'+15% S\u1EE8C M\u1EA0NH\').")]
	public UnityEngine.UI.Text txtFloating; // 0xD8
	private const float GLOW_SECONDS_PER_TURN = 8f; // Metadata: 0x005F0839
	private const float FLASH_PEAK_ALPHA = 0.55f; // Metadata: 0x005F083D
	private const float PET_FIT_SIZE = 150f; // Metadata: 0x005F0841
	private Animator _petAnimator; // 0xE0
	private PetImageFit _petFit; // 0xE8
	private int _userId; // 0xF0
	private long _petId; // 0xF8
	private string _petName; // 0x100
	private int _star; // 0x108
	private int _maxStar; // 0x10C
	private int _shardCount; // 0x110
	private int _nextCost; // 0x114
	private bool _busy; // 0x118
	private bool _wired; // 0x119
	private bool _finalForm; // 0x11A
	private bool _starEligible; // 0x11B
	private string _blockedReason; // 0x120
	private const string MSG_NOT_ELIGIBLE = "Ch\u1EC9 pet Huy\u1EC1n tho\u1EA1i / Galaxy / Mega m\u1EDBi n\u00E2ng sao v\u00E0 c\u00F3 m\u1EA3nh"; // Metadata: 0x005F0845
	private CanvasGroup _cg; // 0x128
	private Vector3 _floatingHome; // 0x130
	private bool _floatingHomeSaved; // 0x13C
	private string _lastAwakenText; // 0x140
	public const string SKILL_AWAKEN_NODE = "txtSkillAwaken"; // Metadata: 0x005F088F

	// Properties
	private bool Alive { get; } // 0x000000018069A460-0x000000018069A4B0 
	public bool IsOpen { get; } // 0x000000018069AD70-0x000000018069AEC0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1144
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__57_0; // 0x08
		public static Action<string> __9__68_1; // 0x10

		// Constructors
		static __c(); // 0x00000001806A1260-0x00000001806A1300
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadInfoCo_b__57_0(string err); // 0x00000001806A1300-0x00000001806A1380
		internal void _UpgradeCo_b__68_1(string err); // 0x00000001806A1380-0x00000001806A1450
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass74_0 // TypeDefIndex: 1145
	{
		// Fields
		public PetStarPanelController __4__this; // 0x10
		public Vector3 home; // 0x18

		// Constructors
		public __c__DisplayClass74_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPressFx_b__0(); // 0x00000001806A1450-0x00000001806A15E0
	}

	[CompilerGenerated]
	private sealed class _LoadInfoCo_d__57 : IEnumerator<object> // TypeDefIndex: 1146
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetStarPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadInfoCo_d__57(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806A15E0-0x00000001806A1A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A1A50-0x00000001806A1A90
	}

	[CompilerGenerated]
	private sealed class _UpgradeCo_d__68 : IEnumerator<object> // TypeDefIndex: 1147
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PetStarPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCo_d__68(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001806A1A90-0x00000001806A1F30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A1F30-0x00000001806A1F70
	}

	// Constructors
	public PetStarPanelController(); // 0x00000001806A07C0-0x00000001806A0820

	// Methods
	private void Awake(); // 0x00000001806998C0-0x00000001806998D0
	private void WireOnce(); // 0x00000001806998D0-0x000000018069A3D0
	private void OnDisable(); // 0x000000018069A3D0-0x000000018069A460
	public void Open(long petId, string petName); // 0x000000018069A4B0-0x000000018069ABF0
	public void Close(); // 0x000000018069ABF0-0x000000018069AD70
	private void SetPlaceholders(); // 0x000000018069AEC0-0x000000018069B1E0
	private void Reload(); // 0x000000018069B1E0-0x000000018069B2B0
	[IteratorStateMachine(typeof(_LoadInfoCo_d__57))]
	private IEnumerator LoadInfoCo(); // 0x000000018069B2B0-0x000000018069B350
	private void OnInfoLoaded(PetStarInfoResponse resp); // 0x000000018069B350-0x000000018069B550
	private void PaintStars(); // 0x000000018069B550-0x000000018069B680
	private void PaintStats(int hp, int hpNext, int atk, int atkNext, int mana, int manaNext, int bonus, int nextBonus); // 0x000000018069B680-0x000000018069BB90
	private void PaintSkillAwaken(string now, string next); // 0x000000018069BB90-0x000000018069BF50
	private UnityEngine.UI.Text EnsureSkillAwakenLabel(); // 0x000000018069BF50-0x000000018069C870
	private static string Delta(int d); // 0x000000018069C870-0x000000018069CA20
	private void PaintShard(); // 0x000000018069CA20-0x000000018069D040
	private void UpdateUpgradeButton(bool owned); // 0x000000018069D040-0x000000018069D440
	private void OnUpgradeClicked(); // 0x000000018069D440-0x000000018069D790
	[IteratorStateMachine(typeof(_UpgradeCo_d__68))]
	private IEnumerator UpgradeCo(); // 0x000000018069D790-0x000000018069D830
	private void SetBusy(bool busy); // 0x000000018069D830-0x000000018069D950
	private void NotifyStarChanged(); // 0x000000018069D950-0x000000018069DB00
	private void StartGlow(); // 0x000000018069DB00-0x000000018069E010
	private void StartPulse(); // 0x000000018069E010-0x000000018069E2F0
	private void StopPulse(); // 0x000000018069E2F0-0x000000018069E510
	private void PlayPressFx(); // 0x000000018069E510-0x000000018069E8E0
	private void PlaySuccessFx(int oldStar, int newStar, int bonusPercent); // 0x000000018069E8E0-0x000000018069F5D0
	private void ShowFloating(string text); // 0x000000018069F5D0-0x000000018069FAC0
	private void CancelFx(); // 0x000000018069FAC0-0x00000001806A0440
	private static void SetText(UnityEngine.UI.Text t, string s); // 0x00000001806A0440-0x00000001806A0540
	private static void SetText(UnityEngine.UI.Text t, string s, Color c); // 0x00000001806A0540-0x00000001806A0670
	private static void SetAlpha(Graphic g, float a); // 0x00000001806A0670-0x00000001806A07C0
	[CompilerGenerated]
	private void _UpgradeCo_b__68_0(PetStarUpgradeResponse resp); // 0x00000001806A0820-0x00000001806A0CC0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__75_0(float v); // 0x00000001806A0CC0-0x00000001806A0CD0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__75_1(); // 0x00000001806A0CD0-0x00000001806A0EF0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__75_2(float v); // 0x00000001806A0CC0-0x00000001806A0CD0
	[CompilerGenerated]
	private void _PlaySuccessFx_b__75_3(); // 0x00000001806A0EF0-0x00000001806A1050
	[CompilerGenerated]
	private void _ShowFloating_b__76_0(float v); // 0x00000001806A1050-0x00000001806A1060
	[CompilerGenerated]
	private void _ShowFloating_b__76_1(); // 0x00000001806A1060-0x00000001806A1260
}

