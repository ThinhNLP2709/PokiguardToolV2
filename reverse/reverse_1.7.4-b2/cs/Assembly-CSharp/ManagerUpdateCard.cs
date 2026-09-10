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

public class ManagerUpdateCard : MonoBehaviour // TypeDefIndex: 1486
{
	// Fields
	public const string PANEL_KEY = "PanelUpdateCard"; // Metadata: 0x0068D160
	[Header("Panel References")]
	public GameObject panelUpdateCard; // 0x20
	[Header("PanelCard - Danh s\u00E1ch card")]
	public Transform panelCardContainer; // 0x28
	public GameObject btnCardPrefab; // 0x30
	[Header("PanelUpdate - Slot \u0111\u00E1 \u0111i\u1EC1u ki\u1EC7n")]
	public Transform updateSlotsContainer; // 0x38
	[Header("Set - Th\u00F4ng tin card \u0111\u01B0\u1EE3c ch\u1ECDn")]
	public Image stoneMain; // 0x40
	public UnityEngine.UI.Text txtPercent; // 0x48
	public UnityEngine.UI.Text txtResultUpdate; // 0x50
	public UnityEngine.UI.Text txtLv; // 0x58
	public UnityEngine.UI.Text txtDame; // 0x60
	public UnityEngine.UI.Text goldnl; // 0x68
	[Header("Action")]
	public Button btnUpdate; // 0x70
	public Toggle toggleB; // 0x78
	public UnityEngine.UI.Text messagetxt; // 0x80
	public GameObject anmtUpdateCard; // 0x88
	public Button btnBack; // 0x90
	private List<CardDTO> userCards; // 0x98
	private CardDTO selectedCard; // 0xA0
	private UserDTO currentUser; // 0xA8
	private bool isProcessingUpgrade; // 0xB0
	private Color originalResultColor; // 0xB4

	// Nested types
	[Serializable]
	public class CardDTO // TypeDefIndex: 1487
	{
		// Fields
		public long id; // 0x10
		public long cardId; // 0x18
		public string name; // 0x20
		public string description; // 0x28
		public string elementTypeCard; // 0x30
		public int value; // 0x38
		public int count; // 0x3C
		public int level; // 0x40
		public long conditionUse; // 0x48
		public int conditionStone; // 0x50
		public int currentStone; // 0x54
		public double upgradeRate; // 0x58
		public int upgradeCost; // 0x60

		// Constructors
		public CardDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class UserDTO // TypeDefIndex: 1488
	{
		// Fields
		public int id; // 0x10
		public int gold; // 0x14

		// Constructors
		public UserDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class CardUpgradeRequestDTO // TypeDefIndex: 1489
	{
		// Fields
		public long userId; // 0x10
		public long userCardId; // 0x18
		public bool useGold; // 0x20

		// Constructors
		public CardUpgradeRequestDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class CardUpgradeResponseDTO // TypeDefIndex: 1490
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int newLevel; // 0x20
		public bool upgraded; // 0x24

		// Constructors
		public CardUpgradeResponseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1491
	{
		// Fields
		public CardDTO captured; // 0x10
		public ManagerUpdateCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RenderCardList_b__0(); // 0x00000001805EAEF0-0x00000001805EAF20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 1492
	{
		// Fields
		public CardUpgradeResponseDTO response; // 0x10
		public bool apiDone; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass43_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpgradeCardAPI_b__0(CardUpgradeResponseDTO res); // 0x00000001804F8C00-0x00000001804F8C20
		internal void _UpgradeCardAPI_b__1(string err); // 0x00000001805EAF20-0x00000001805EAF40
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__54 : IEnumerator<object> // TypeDefIndex: 1493
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public UnityEngine.UI.Text textComponent; // 0x20
		public float moveDistance; // 0x28
		public float duration; // 0x2C
		private Vector3 _startPos_5__2; // 0x30
		private Vector3 _targetPos_5__3; // 0x3C
		private float _elapsed_5__4; // 0x48
		private Color _originalColor_5__5; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__54(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E5950-0x00000001805E5CB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E5CB0-0x00000001805E5CF0
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__53 : IEnumerator<object> // TypeDefIndex: 1494
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerUpdateCard __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__53(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805E85A0-0x00000001805E86E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E86E0-0x00000001805E8720
	}

	[CompilerGenerated]
	private sealed class _LoadAllData_d__32 : IEnumerator<object> // TypeDefIndex: 1495
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerUpdateCard __4__this; // 0x28
		private IEnumerator _cardsRequest_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllData_d__32(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001805E8720-0x00000001805E8990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E8990-0x00000001805E89D0
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__48 : IEnumerator<object> // TypeDefIndex: 1496
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		private IEnumerator _cardsRequest_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__48(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805E9780-0x00000001805E9BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9BC0-0x00000001805E9C00
	}

	[CompilerGenerated]
	private sealed class _UpgradeCardAPI_d__43 : IEnumerator<object> // TypeDefIndex: 1497
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUpgradeRequestDTO request; // 0x20
		private __c__DisplayClass43_0 __8__1; // 0x28
		public ManagerUpdateCard __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCardAPI_d__43(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805EB7F0-0x00000001805EBC50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EBC50-0x00000001805EBC90
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenShowResult_d__45 : IEnumerator<object> // TypeDefIndex: 1498
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		public CardUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenShowResult_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805EBC90-0x00000001805EBEA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805EBEA0-0x00000001805EBEE0
	}

	// Constructors
	public ManagerUpdateCard(); // 0x00000001805E5520-0x00000001805E55A0

	// Methods
	private void OnDisable(); // 0x00000001805E32A0-0x00000001805E32B0
	private void Start(); // 0x00000001805E4F30-0x00000001805E50D0
	private void SetupInitialStates(); // 0x00000001805E4C20-0x00000001805E4D50
	private void SetupButtons(); // 0x00000001805E4A40-0x00000001805E4C20
	public void OpenPanel(); // 0x00000001805E3B40-0x00000001805E3CA0
	public void ClosePanel(); // 0x00000001805E2A20-0x00000001805E2B80
	private void LoadData(); // 0x00000001805E3090-0x00000001805E3190
	[IteratorStateMachine(typeof(_LoadAllData_d__32))]
	private IEnumerator LoadAllData(int userId); // 0x00000001805E2F80-0x00000001805E3000
	private void OnCardsReceived(List<CardDTO> cards); // 0x00000001805E3190-0x00000001805E32A0
	private void RenderCardList(); // 0x00000001805E3D10-0x00000001805E4400
	private Sprite LoadCardSprite(long cardId); // 0x00000001805E3000-0x00000001805E3090
	private void SelectCard(CardDTO card); // 0x00000001805E4400-0x00000001805E48B0
	private int CalculateDame(CardDTO card); // 0x00000001805E29D0-0x00000001805E2A20
	public static int ValueAtLevel(int baseValue, int level); // 0x00000001805E5450-0x00000001805E5490
	public static string FormatVND(long amount); // 0x00000001805E2B80-0x00000001805E2C00
	private void UpdateStoneSlotUI(CardDTO card); // 0x00000001805E5220-0x00000001805E53C0
	private void OnToggleBChanged(bool isOn); // 0x00000001805E3320-0x00000001805E3440
	private void OnUpgradeButtonClicked(); // 0x00000001805E3440-0x00000001805E37A0
	[IteratorStateMachine(typeof(_UpgradeCardAPI_d__43))]
	private IEnumerator UpgradeCardAPI(CardUpgradeRequestDTO request); // 0x00000001805E53C0-0x00000001805E5450
	private void OnUpgradeSuccess(CardUpgradeResponseDTO response); // 0x00000001805E3A00-0x00000001805E3B40
	[IteratorStateMachine(typeof(_WaitForAnimationThenShowResult_d__45))]
	private IEnumerator WaitForAnimationThenShowResult(CardUpgradeResponseDTO response); // 0x00000001805E5490-0x00000001805E5520
	private void HandleUpgradeResult(CardUpgradeResponseDTO response); // 0x00000001805E2C00-0x00000001805E2E70
	private void OnUpgradeError(string error); // 0x00000001805E37A0-0x00000001805E3A00
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__48))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x00000001805E3CA0-0x00000001805E3D10
	private void SetSetPanelVisible(bool visible); // 0x00000001805E48B0-0x00000001805E4A40
	private void ShowMessage(string msg); // 0x00000001805E4D50-0x00000001805E4E10
	private void HideMessage(); // 0x00000001805E2E70-0x00000001805E2F00
	private void ShowResult(string msg, Color color); // 0x00000001805E4E10-0x00000001805E4F30
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__53))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x00000001805E2F00-0x00000001805E2F80
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__54))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x0068D158 */, float moveDistance = 80f /* Metadata: 0x0068D15C */); // 0x00000001805E2940-0x00000001805E29D0
	private void OnError(string error); // 0x00000001805E32B0-0x00000001805E3320
	[CompilerGenerated]
	private void _LoadAllData_b__32_0(UserDTO user); // 0x0000000180319C80-0x0000000180319CA0
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_0(UserDTO user); // 0x0000000180319C80-0x0000000180319CA0
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_1(List<CardDTO> cards); // 0x00000001805E50D0-0x00000001805E51F0
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__48_2(CardDTO c); // 0x00000001805E51F0-0x00000001805E5220
}

