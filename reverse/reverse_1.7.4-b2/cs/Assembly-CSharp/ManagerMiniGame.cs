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

public class ManagerMiniGame : MonoBehaviour // TypeDefIndex: 1242
{
	// Fields
	public const string PANEL_KEY = "PanelMiniGame"; // Metadata: 0x0068CE42
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
	private const int SPIN_COST_BASE = 2000; // Metadata: 0x0068CE50
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
	private sealed class __c // TypeDefIndex: 1243
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__75_1; // 0x08

		// Constructors
		static __c(); // 0x00000001805A64B0-0x00000001805A6520
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRankOnly_b__75_1(string err); // 0x00000001805A5680-0x00000001805A56F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 1244
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass70_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayGoldTextAnimation_b__0(); // 0x00000001805A57A0-0x00000001805A5810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1245
	{
		// Fields
		public GameObject coin; // 0x10

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnOneCoin_b__0(); // 0x00000001805A5840-0x00000001805A58B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 1246
	{
		// Fields
		public ManagerMiniGame __4__this; // 0x10
		public bool wasAuto; // 0x18

		// Constructors
		public __c__DisplayClass82_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShowGiftBox_b__0(); // 0x00000001805A58B0-0x00000001805A5A00
	}

	[CompilerGenerated]
	private sealed class _AutoNextRound_d__65 : IEnumerator<object> // TypeDefIndex: 1247
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoNextRound_d__65(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A2D30-0x00000001805A2F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A2F20-0x00000001805A2F60
	}

	[CompilerGenerated]
	private sealed class _PlayGoldRainEffect_d__71 : IEnumerator<object> // TypeDefIndex: 1248
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int coinCount; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldRainEffect_d__71(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A4390-0x00000001805A4500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4500-0x00000001805A4540
	}

	[CompilerGenerated]
	private sealed class _PlayGoldTextAnimation_d__70 : IEnumerator<object> // TypeDefIndex: 1249
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public int goldEarned; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayGoldTextAnimation_d__70(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A4540-0x00000001805A49A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A49A0-0x00000001805A49E0
	}

	[CompilerGenerated]
	private sealed class _ShowMessageCoroutine_d__69 : IEnumerator<object> // TypeDefIndex: 1250
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMiniGame __4__this; // 0x20
		public string msg; // 0x28
		public float duration; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowMessageCoroutine_d__69(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A4C90-0x00000001805A4E00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4E00-0x00000001805A4E40
	}

	[CompilerGenerated]
	private sealed class _SpawnOneCoin_d__73 : IEnumerator<object> // TypeDefIndex: 1251
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerMiniGame __4__this; // 0x28
		private __c__DisplayClass73_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpawnOneCoin_d__73(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001805A4E40-0x00000001805A54D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A54D0-0x00000001805A5510
	}

	// Constructors
	public ManagerMiniGame(); // 0x0000000180597590-0x0000000180597630

	// Methods
	private void OnDisable(); // 0x0000000180595430-0x0000000180595440
	private void Awake(); // 0x00000001805945A0-0x00000001805948C0
	private void Start(); // 0x0000000180595F60-0x0000000180596330
	private void OnDestroy(); // 0x00000001805953C0-0x0000000180595430
	public void OpenPanel(); // 0x0000000180595450-0x00000001805955C0
	private void ClosePanel(); // 0x0000000180594CA0-0x0000000180594E00
	private void StopAutoSpin(); // 0x0000000180596330-0x0000000180596490
	private void OnAutoToggleChanged(bool isOn); // 0x00000001802EB6C0-0x00000001802EB6D0
	public bool CanSpin(); // 0x0000000180594C90-0x0000000180594CA0
	public void RequestStop(); // 0x00000001805956C0-0x00000001805956D0
	public void OnSpinButtonClicked(); // 0x0000000180595440-0x0000000180595450
	public bool TryBeginSpin(); // 0x0000000180596490-0x0000000180596540
	private void BeginSpinRound(); // 0x00000001805948C0-0x0000000180594980
	private void CallSpinAPI(); // 0x0000000180594A90-0x0000000180594C90
	private void OnColumnComplete(int index); // 0x0000000180595380-0x00000001805953C0
	private void TryFinishRound(); // 0x0000000180596540-0x00000001805967C0
	[IteratorStateMachine(typeof(_AutoNextRound_d__65))]
	private IEnumerator AutoNextRound(); // 0x0000000180594530-0x00000001805945A0
	private bool HasEnoughGold(); // 0x0000000180594EB0-0x0000000180594FF0
	private void ApplyResultUI(); // 0x0000000180594270-0x0000000180594530
	private void ShowMessage(string msg, float duration = 2.5f /* Metadata: 0x0068CE3C */); // 0x0000000180595C90-0x0000000180595DB0
	[IteratorStateMachine(typeof(_ShowMessageCoroutine_d__69))]
	private IEnumerator ShowMessageCoroutine(string msg, float duration); // 0x0000000180595BF0-0x0000000180595C90
	[IteratorStateMachine(typeof(_PlayGoldTextAnimation_d__70))]
	private IEnumerator PlayGoldTextAnimation(int goldEarned); // 0x0000000180595640-0x00000001805956C0
	[IteratorStateMachine(typeof(_PlayGoldRainEffect_d__71))]
	private IEnumerator PlayGoldRainEffect(int coinCount); // 0x00000001805955C0-0x0000000180595640
	private int GoldToCoinCount(int gold); // 0x0000000180594E60-0x0000000180594EB0
	[IteratorStateMachine(typeof(_SpawnOneCoin_d__73))]
	private IEnumerator SpawnOneCoin(float delay); // 0x0000000180595DB0-0x0000000180595E30
	private void LoadInfo(); // 0x0000000180595060-0x00000001805951C0
	private void LoadRankOnly(); // 0x00000001805951C0-0x0000000180595380
	private string BuildLuyenTheText(int totalGoldToday, int userRank); // 0x0000000180594980-0x0000000180594A90
	private void IncreaseMultiplier(); // 0x0000000180594FF0-0x0000000180595060
	private void DecreaseMultiplier(); // 0x0000000180594E00-0x0000000180594E60
	private void UpdateMultiplierUI(); // 0x0000000180597180-0x00000001805972D0
	private void UpdateInfoUI(int totalGoldToday, int goldTowardTarget, int targetGold, int challengeLevel, int spinCost = 0 /* Metadata: 0x0068CE40 */, int userRank = -1 /* Metadata: 0x0068CE41 */); // 0x0000000180596EF0-0x0000000180597180
	private void UpdateRankUI(List<MiniGameRankDTO> top3); // 0x00000001805972D0-0x0000000180597590
	private void ShowGiftBox(MiniGameRewardDTO reward, int completedLevel); // 0x00000001805956D0-0x0000000180595BF0
	private void SpawnRewardItem(GameObject prefab, int amount, string label); // 0x0000000180595E30-0x0000000180595F60
	[CompilerGenerated]
	private void _Start_b__51_0(); // 0x0000000180596E90-0x0000000180596EC0
	[CompilerGenerated]
	private void _Start_b__51_1(); // 0x0000000180596EC0-0x0000000180596EF0
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_0(MiniGameSpinResponse result); // 0x00000001805967C0-0x0000000180596AB0
	[CompilerGenerated]
	private void _CallSpinAPI_b__62_1(string err); // 0x0000000180596AB0-0x0000000180596CB0
	[CompilerGenerated]
	private void _LoadInfo_b__74_0(MiniGameInfoResponse info); // 0x0000000180596CB0-0x0000000180596D20
	[CompilerGenerated]
	private void _LoadInfo_b__74_1(string err); // 0x0000000180596D20-0x0000000180596DC0
	[CompilerGenerated]
	private void _LoadRankOnly_b__75_0(MiniGameInfoResponse info); // 0x0000000180596DC0-0x0000000180596E90
}

