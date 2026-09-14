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

public class ManagerMiniGame : MonoBehaviour // TypeDefIndex: 1645
{
	// Fields
	public const string PANEL_KEY = "PanelMiniGame"; // Metadata: 0x005F14AA
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
	private const int SPIN_COST_BASE = 2000; // Metadata: 0x005F14B8
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
	private sealed class __c // TypeDefIndex: 1646
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__75_1; // 0x08

		// Constructors
		static __c(); // 0x00000001808ADDD0-0x00000001808ADE70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRankOnly_b__75_1(string err); // 0x00000001808ADE70-0x00000001808ADEF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 1647
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass70_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayGoldTextAnimation_b__0(); // 0x00000001808ADEF0-0x00000001808AE020
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1648
	{
		// Fields
		public GameObject coin; // 0x10

		// Constructors
		public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnOneCoin_b__0(); // 0x00000001808AE020-0x00000001808AE150
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 1649
	{
		// Fields
		public ManagerMiniGame __4__this; // 0x10
		public bool wasAuto; // 0x18

		// Constructors
		public __c__DisplayClass82_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowGiftBox_b__0(); // 0x00000001808AE150-0x00000001808AE320
	}

	[CompilerGenerated]
	private sealed class _AutoNextRound_d__65 : IEnumerator<object> // TypeDefIndex: 1650
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoNextRound_d__65(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808AE320-0x00000001808AE5C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AE5C0-0x00000001808AE600
	}

	[CompilerGenerated]
	private sealed class _PlayGoldRainEffect_d__71 : IEnumerator<object> // TypeDefIndex: 1651
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int coinCount; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldRainEffect_d__71(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808AE600-0x00000001808AE960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AE960-0x00000001808AE9A0
	}

	[CompilerGenerated]
	private sealed class _PlayGoldTextAnimation_d__70 : IEnumerator<object> // TypeDefIndex: 1652
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int goldEarned; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldTextAnimation_d__70(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808AE9A0-0x00000001808AF1A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AF1A0-0x00000001808AF1E0
	}

	[CompilerGenerated]
	private sealed class _ShowMessageCoroutine_d__69 : IEnumerator<object> // TypeDefIndex: 1653
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public string msg; // 0x28
		public float duration; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowMessageCoroutine_d__69(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808AF1E0-0x00000001808AF430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AF430-0x00000001808AF470
	}

	[CompilerGenerated]
	private sealed class _SpawnOneCoin_d__73 : IEnumerator<object> // TypeDefIndex: 1654
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerMiniGame __4__this; // 0x28
		private __c__DisplayClass73_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpawnOneCoin_d__73(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001808AF470-0x00000001808AFEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AFEE0-0x00000001808AFF20
	}

	// Constructors
	public ManagerMiniGame(); // 0x00000001808AD1B0-0x00000001808AD2D0

	// Methods
	private void OnDisable(); // 0x00000001808A86F0-0x00000001808A8700
	private void Awake(); // 0x00000001808A8700-0x00000001808A8F80
	private void Start(); // 0x00000001808A8F80-0x00000001808A9710
	private void OnDestroy(); // 0x00000001808A9710-0x00000001808A9790
	public void OpenPanel(); // 0x00000001808A9790-0x00000001808A99B0
	private void ClosePanel(); // 0x00000001808A99B0-0x00000001808A9BB0
	private void StopAutoSpin(); // 0x00000001808A9BB0-0x00000001808A9DE0
	private void OnAutoToggleChanged(bool isOn); // 0x000000018028A320-0x000000018028A330
	public bool CanSpin(); // 0x00000001808A9DE0-0x00000001808A9DF0
	public void RequestStop(); // 0x00000001808A9DF0-0x00000001808A9E00
	public void OnSpinButtonClicked(); // 0x00000001808A9E00-0x00000001808A9E10
	public bool TryBeginSpin(); // 0x00000001808A9E10-0x00000001808A9F10
	private void BeginSpinRound(); // 0x00000001808A9F10-0x00000001808A9FB0
	private void CallSpinAPI(); // 0x00000001808A9FB0-0x00000001808AA2C0
	private void OnColumnComplete(int index); // 0x00000001808AA2C0-0x00000001808AA300
	private void TryFinishRound(); // 0x00000001808AA300-0x00000001808AA860
	[IteratorStateMachine(typeof(_AutoNextRound_d__65))]
	private IEnumerator AutoNextRound(); // 0x00000001808AA860-0x00000001808AA900
	private bool HasEnoughGold(); // 0x00000001808AA900-0x00000001808AAB70
	private void ApplyResultUI(); // 0x00000001808AAB70-0x00000001808AAD20
	private void ShowMessage(string msg, float duration = 2.5f /* Metadata: 0x005F14A4 */); // 0x00000001808AAD20-0x00000001808AAF90
	[IteratorStateMachine(typeof(_ShowMessageCoroutine_d__69))]
	private IEnumerator ShowMessageCoroutine(string msg, float duration); // 0x00000001808AAF90-0x00000001808AB0B0
	[IteratorStateMachine(typeof(_PlayGoldTextAnimation_d__70))]
	private IEnumerator PlayGoldTextAnimation(int goldEarned); // 0x00000001808AB0B0-0x00000001808AB160
	[IteratorStateMachine(typeof(_PlayGoldRainEffect_d__71))]
	private IEnumerator PlayGoldRainEffect(int coinCount); // 0x00000001808AB160-0x00000001808AB210
	private int GoldToCoinCount(int gold); // 0x00000001808AB210-0x00000001808AB260
	[IteratorStateMachine(typeof(_SpawnOneCoin_d__73))]
	private IEnumerator SpawnOneCoin(float delay); // 0x00000001808AB260-0x00000001808AB320
	private void LoadInfo(); // 0x00000001808AB320-0x00000001808AB4E0
	private void LoadRankOnly(); // 0x00000001808AB4E0-0x00000001808AB750
	private string BuildLuyenTheText(int totalGoldToday, int userRank); // 0x00000001808AB750-0x00000001808AB930
	private void IncreaseMultiplier(); // 0x00000001808AB930-0x00000001808AB9A0
	private void DecreaseMultiplier(); // 0x00000001808AB9A0-0x00000001808ABA00
	private void UpdateMultiplierUI(); // 0x00000001808ABA00-0x00000001808ABCE0
	private void UpdateInfoUI(int totalGoldToday, int goldTowardTarget, int targetGold, int challengeLevel, int spinCost = 0 /* Metadata: 0x005F14A8 */, int userRank = -1 /* Metadata: 0x005F14A9 */); // 0x00000001808ABCE0-0x00000001808AC310
	private void UpdateRankUI(List<MiniGameRankDTO> top3); // 0x00000001808AC310-0x00000001808AC720
	private void ShowGiftBox(MiniGameRewardDTO reward, int completedLevel); // 0x00000001808AC720-0x00000001808ACED0
	private void SpawnRewardItem(GameObject prefab, int amount, string label); // 0x00000001808ACED0-0x00000001808AD1B0
	[CompilerGenerated]
	private void _Start_b__51_0(); // 0x00000001808AD2D0-0x00000001808AD350
	[CompilerGenerated]
	private void _Start_b__51_1(); // 0x00000001808AD350-0x00000001808AD3D0
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_0(MiniGameSpinResponse result); // 0x00000001808AD3D0-0x00000001808AD840
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_1(string err); // 0x00000001808AD840-0x00000001808ADB50
	[CompilerGenerated]
	private void _LoadInfo_b__74_0(MiniGameInfoResponse info); // 0x00000001808ADB50-0x00000001808ADBC0
	[CompilerGenerated]
	private void _LoadInfo_b__74_1(string err); // 0x00000001808ADBC0-0x00000001808ADC80
	[CompilerGenerated]
	private void _LoadRankOnly_b__75_0(MiniGameInfoResponse info); // 0x00000001808ADC80-0x00000001808ADDD0
}

