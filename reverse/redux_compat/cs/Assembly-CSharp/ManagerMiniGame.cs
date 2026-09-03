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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerMiniGame : MonoBehaviour // TypeDefIndex: 1043
{
	// Fields
	public const string PANEL_KEY = "PanelMiniGame"; // Metadata: 0x0064D2EB
	public static ManagerMiniGame Instance; // 0x00
	[Header("Guide")]
	public GameObject panelGuide; // 0x20
	public Button btnOpenGuide; // 0x28
	public Button btnCloseGuide; // 0x30
	[Header("Panel")]
	public GameObject panelMiniGame; // 0x38
	public Button btnBack; // 0x40
	[Header("SlotMachine")]
	public SlotMachine slotMachine; // 0x48
	[Header("GiftBox")]
	public GameObject panelGiftBox; // 0x50
	public GameObject panelResult; // 0x58
	public Transform listReward; // 0x60
	public Button btnGet; // 0x68
	public UnityEngine.UI.Text txtTitle; // 0x70
	[Header("Multiplier UI")]
	public UnityEngine.UI.Text txtMultiplierLabel; // 0x78
	public Button btnUp; // 0x80
	public Button btnDown; // 0x88
	public UnityEngine.UI.Text txtGoldRequest; // 0x90
	[Header("Info UI")]
	public UnityEngine.UI.Text txtLuyenThe; // 0x98
	public UnityEngine.UI.Text txtGoldTarget; // 0xA0
	public UnityEngine.UI.Text txtGoldTargetRW; // 0xA8
	public UnityEngine.UI.Text txtSpinCost; // 0xB0
	public Slider sliderChallenge; // 0xB8
	[Header("Rank UI - PanelTop")]
	public UnityEngine.UI.Text[] txtTopNames; // 0xC0
	public UnityEngine.UI.Text[] txtTopDames; // 0xC8
	[Header("Rank Reward UI - RewardRank")]
	public UnityEngine.UI.Text[] txtRankGoldRW; // 0xD0
	[Header("GiftBox - Item Prefabs")]
	public GameObject goldRWPrefab; // 0xD8
	public GameObject rubyRWPrefab; // 0xE0
	public GameObject crystalRWPrefab; // 0xE8
	public GameObject eItem1RWPrefab; // 0xF0
	public GameObject eItem2RWPrefab; // 0xF8
	public GameObject eItem3RWPrefab; // 0x100
	public GameObject eItem4RWPrefab; // 0x108
	[Header("Gold Rain Effect")]
	public GameObject goldFlyPrefab; // 0x110
	public RectTransform goldRainArea; // 0x118
	public Transform goldFlyTarget; // 0x120
	[Header("Gold Earned Text Animation")]
	public GameObject goldEarnedTextPrefab; // 0x128
	public Transform goldEarnedSpawnPoint; // 0x130
	[Header("Auto Spin")]
	public Toggle toggleAutoSpin; // 0x138
	[Header("Message UI")]
	public UnityEngine.UI.Text txtMessage; // 0x140
	private const int SPIN_COST_BASE = 2000; // Metadata: 0x0064D2F9
	private int _multiplier; // 0x148
	private readonly int[] _multiplierLevels; // 0x150
	private int _multiplierIndex; // 0x158
	private bool _isSpinning; // 0x15C
	private bool _resultApplied; // 0x15D
	private bool _stopRequested; // 0x15E
	private int _completedColumns; // 0x160
	private MiniGameSpinResponse _pendingResult; // 0x168
	private Coroutine _msgCoroutine; // 0x170

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1044
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__75_1; // 0x08

		// Constructors
		static __c(); // 0x00000001804AB0F0-0x00000001804AB160
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRankOnly_b__75_1(string err); // 0x00000001804AA8D0-0x00000001804AA940
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 1045
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass70_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayGoldTextAnimation_b__0(); // 0x00000001804AA980-0x00000001804AA9F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1046
	{
		// Fields
		public GameObject coin; // 0x10

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpawnOneCoin_b__0(); // 0x00000001804AA9F0-0x00000001804AAA60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 1047
	{
		// Fields
		public ManagerMiniGame __4__this; // 0x10
		public bool wasAuto; // 0x18

		// Constructors
		public __c__DisplayClass82_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShowGiftBox_b__0(); // 0x00000001804AAA60-0x00000001804AABB0
	}

	[CompilerGenerated]
	private sealed class _AutoNextRound_d__65 : IEnumerator<object> // TypeDefIndex: 1048
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoNextRound_d__65(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A8690-0x00000001804A8880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A8880-0x00000001804A88C0
	}

	[CompilerGenerated]
	private sealed class _PlayGoldRainEffect_d__71 : IEnumerator<object> // TypeDefIndex: 1049
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int coinCount; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldRainEffect_d__71(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A95E0-0x00000001804A9750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A9750-0x00000001804A9790
	}

	[CompilerGenerated]
	private sealed class _PlayGoldTextAnimation_d__70 : IEnumerator<object> // TypeDefIndex: 1050
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int goldEarned; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldTextAnimation_d__70(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A9790-0x00000001804A9BF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A9BF0-0x00000001804A9C30
	}

	[CompilerGenerated]
	private sealed class _ShowMessageCoroutine_d__69 : IEnumerator<object> // TypeDefIndex: 1051
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public string msg; // 0x28
		public float duration; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowMessageCoroutine_d__69(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A9EE0-0x00000001804AA050
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AA050-0x00000001804AA090
	}

	[CompilerGenerated]
	private sealed class _SpawnOneCoin_d__73 : IEnumerator<object> // TypeDefIndex: 1052
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerMiniGame __4__this; // 0x28
		private __c__DisplayClass73_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpawnOneCoin_d__73(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001804AA090-0x00000001804AA720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AA720-0x00000001804AA760
	}

	// Constructors
	public ManagerMiniGame(); // 0x000000018049F4F0-0x000000018049F590

	// Methods
	private void OnDisable(); // 0x000000018049D390-0x000000018049D3A0
	private void Awake(); // 0x000000018049C500-0x000000018049C820
	private void Start(); // 0x000000018049DEC0-0x000000018049E290
	private void OnDestroy(); // 0x000000018049D320-0x000000018049D390
	public void OpenPanel(); // 0x000000018049D3B0-0x000000018049D520
	private void ClosePanel(); // 0x000000018049CC00-0x000000018049CD60
	private void StopAutoSpin(); // 0x000000018049E290-0x000000018049E3F0
	private void OnAutoToggleChanged(bool isOn); // 0x00000001802E76C0-0x00000001802E76D0
	public bool CanSpin(); // 0x000000018049CBF0-0x000000018049CC00
	public void RequestStop(); // 0x000000018049D620-0x000000018049D630
	public void OnSpinButtonClicked(); // 0x000000018049D3A0-0x000000018049D3B0
	public bool TryBeginSpin(); // 0x000000018049E3F0-0x000000018049E4A0
	private void BeginSpinRound(); // 0x000000018049C820-0x000000018049C8E0
	private void CallSpinAPI(); // 0x000000018049C9F0-0x000000018049CBF0
	private void OnColumnComplete(int index); // 0x000000018049D2E0-0x000000018049D320
	private void TryFinishRound(); // 0x000000018049E4A0-0x000000018049E720
	[IteratorStateMachine(typeof(_AutoNextRound_d__65))]
	private IEnumerator AutoNextRound(); // 0x000000018049C490-0x000000018049C500
	private bool HasEnoughGold(); // 0x000000018049CE10-0x000000018049CF50
	private void ApplyResultUI(); // 0x000000018049C1D0-0x000000018049C490
	private void ShowMessage(string msg, float duration = 2.5f /* Metadata: 0x0064D2E5 */); // 0x000000018049DBF0-0x000000018049DD10
	[IteratorStateMachine(typeof(_ShowMessageCoroutine_d__69))]
	private IEnumerator ShowMessageCoroutine(string msg, float duration); // 0x000000018049DB50-0x000000018049DBF0
	[IteratorStateMachine(typeof(_PlayGoldTextAnimation_d__70))]
	private IEnumerator PlayGoldTextAnimation(int goldEarned); // 0x000000018049D5A0-0x000000018049D620
	[IteratorStateMachine(typeof(_PlayGoldRainEffect_d__71))]
	private IEnumerator PlayGoldRainEffect(int coinCount); // 0x000000018049D520-0x000000018049D5A0
	private int GoldToCoinCount(int gold); // 0x000000018049CDC0-0x000000018049CE10
	[IteratorStateMachine(typeof(_SpawnOneCoin_d__73))]
	private IEnumerator SpawnOneCoin(float delay); // 0x000000018049DD10-0x000000018049DD90
	private void LoadInfo(); // 0x000000018049CFC0-0x000000018049D120
	private void LoadRankOnly(); // 0x000000018049D120-0x000000018049D2E0
	private string BuildLuyenTheText(int totalGoldToday, int userRank); // 0x000000018049C8E0-0x000000018049C9F0
	private void IncreaseMultiplier(); // 0x000000018049CF50-0x000000018049CFC0
	private void DecreaseMultiplier(); // 0x000000018049CD60-0x000000018049CDC0
	private void UpdateMultiplierUI(); // 0x000000018049F0E0-0x000000018049F230
	private void UpdateInfoUI(int totalGoldToday, int goldTowardTarget, int targetGold, int challengeLevel, int spinCost = 0 /* Metadata: 0x0064D2E9 */, int userRank = -1 /* Metadata: 0x0064D2EA */); // 0x000000018049EE50-0x000000018049F0E0
	private void UpdateRankUI(List<MiniGameRankDTO> top3); // 0x000000018049F230-0x000000018049F4F0
	private void ShowGiftBox(MiniGameRewardDTO reward, int completedLevel); // 0x000000018049D630-0x000000018049DB50
	private void SpawnRewardItem(GameObject prefab, int amount, string label); // 0x000000018049DD90-0x000000018049DEC0
	[CompilerGenerated]
	private void _Start_b__51_0(); // 0x000000018049EDF0-0x000000018049EE20
	[CompilerGenerated]
	private void _Start_b__51_1(); // 0x000000018049EE20-0x000000018049EE50
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_0(MiniGameSpinResponse result); // 0x000000018049E720-0x000000018049EA10
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_1(string err); // 0x000000018049EA10-0x000000018049EC10
	[CompilerGenerated]
	private void _LoadInfo_b__74_0(MiniGameInfoResponse info); // 0x000000018049EC10-0x000000018049EC80
	[CompilerGenerated]
	private void _LoadInfo_b__74_1(string err); // 0x000000018049EC80-0x000000018049ED20
	[CompilerGenerated]
	private void _LoadRankOnly_b__75_0(MiniGameInfoResponse info); // 0x000000018049ED20-0x000000018049EDF0
}

