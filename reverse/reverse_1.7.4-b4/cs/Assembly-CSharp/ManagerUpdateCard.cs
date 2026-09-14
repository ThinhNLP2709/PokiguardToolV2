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

public class ManagerUpdateCard : MonoBehaviour // TypeDefIndex: 1871
{
	// Fields
	public const string PANEL_KEY = "PanelUpdateCard"; // Metadata: 0x005F165B
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
	public class CardDTO // TypeDefIndex: 1872
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
		public CardDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class UserDTO // TypeDefIndex: 1873
	{
		// Fields
		public int id; // 0x10
		public int gold; // 0x14

		// Constructors
		public UserDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class CardUpgradeRequestDTO // TypeDefIndex: 1874
	{
		// Fields
		public long userId; // 0x10
		public long userCardId; // 0x18
		public bool useGold; // 0x20

		// Constructors
		public CardUpgradeRequestDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class CardUpgradeResponseDTO // TypeDefIndex: 1875
	{
		// Fields
		public string message; // 0x10
		public bool upgraded; // 0x18

		// Constructors
		public CardUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1876
	{
		// Fields
		public CardDTO captured; // 0x10
		public ManagerUpdateCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderCardList_b__0(); // 0x000000018091E360-0x000000018091E390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 1877
	{
		// Fields
		public CardUpgradeResponseDTO response; // 0x10
		public bool apiDone; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass43_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpgradeCardAPI_b__0(CardUpgradeResponseDTO res); // 0x000000018076F420-0x000000018076F480
		internal void _UpgradeCardAPI_b__1(string err); // 0x000000018091E390-0x000000018091E3F0
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__54 : IEnumerator<object> // TypeDefIndex: 1878
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__54(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018091E3F0-0x000000018091E890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091E890-0x000000018091E8D0
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__53 : IEnumerator<object> // TypeDefIndex: 1879
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerUpdateCard __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__53(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018091E8D0-0x000000018091EB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091EB20-0x000000018091EB60
	}

	[CompilerGenerated]
	private sealed class _LoadAllData_d__32 : IEnumerator<object> // TypeDefIndex: 1880
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerUpdateCard __4__this; // 0x28
		private IEnumerator _cardsRequest_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllData_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x000000018091EB60-0x000000018091EF10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091EF10-0x000000018091EF50
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__48 : IEnumerator<object> // TypeDefIndex: 1881
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		private IEnumerator _cardsRequest_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__48(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018091EF50-0x000000018091F5F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091F5F0-0x000000018091F630
	}

	[CompilerGenerated]
	private sealed class _UpgradeCardAPI_d__43 : IEnumerator<object> // TypeDefIndex: 1882
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUpgradeRequestDTO request; // 0x20
		private __c__DisplayClass43_0 __8__1; // 0x28
		public ManagerUpdateCard __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCardAPI_d__43(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018091F630-0x000000018091FBF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091FBF0-0x000000018091FC30
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenShowResult_d__45 : IEnumerator<object> // TypeDefIndex: 1883
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		public CardUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenShowResult_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018091FC30-0x000000018091FFD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091FFD0-0x0000000180920010
	}

	// Constructors
	public ManagerUpdateCard(); // 0x000000018091E0C0-0x000000018091E1C0

	// Methods
	private void OnDisable(); // 0x0000000180919790-0x00000001809197A0
	private void Start(); // 0x00000001809197A0-0x00000001809198F0
	private void SetupInitialStates(); // 0x00000001809198F0-0x0000000180919C70
	private void SetupButtons(); // 0x0000000180919C70-0x0000000180919FD0
	public void OpenPanel(); // 0x0000000180919FD0-0x000000018091A240
	public void ClosePanel(); // 0x000000018091A240-0x000000018091A4B0
	private void LoadData(); // 0x000000018091A4B0-0x000000018091A5F0
	[IteratorStateMachine(typeof(_LoadAllData_d__32))]
	private IEnumerator LoadAllData(int userId); // 0x000000018091A5F0-0x000000018091A6A0
	private void OnCardsReceived(List<CardDTO> cards); // 0x000000018091A6A0-0x000000018091A810
	private void RenderCardList(); // 0x000000018091A810-0x000000018091B3B0
	private Sprite LoadCardSprite(long cardId); // 0x000000018091B3B0-0x000000018091B480
	private void SelectCard(CardDTO card); // 0x000000018091B480-0x000000018091BBC0
	private int CalculateDame(CardDTO card); // 0x000000018091BBC0-0x000000018091BC10
	public static int ValueAtLevel(int baseValue, int level); // 0x000000018091BC10-0x000000018091BC50
	public static string FormatVND(long amount); // 0x000000018091BC50-0x000000018091BD60
	private void UpdateStoneSlotUI(CardDTO card); // 0x000000018091BD60-0x000000018091C120
	private void OnToggleBChanged(bool isOn); // 0x000000018091C120-0x000000018091C260
	private void OnUpgradeButtonClicked(); // 0x000000018091C260-0x000000018091C800
	[IteratorStateMachine(typeof(_UpgradeCardAPI_d__43))]
	private IEnumerator UpgradeCardAPI(CardUpgradeRequestDTO request); // 0x000000018091C800-0x000000018091C910
	private void OnUpgradeSuccess(CardUpgradeResponseDTO response); // 0x000000018091C910-0x000000018091CBD0
	[IteratorStateMachine(typeof(_WaitForAnimationThenShowResult_d__45))]
	private IEnumerator WaitForAnimationThenShowResult(CardUpgradeResponseDTO response); // 0x000000018091CBD0-0x000000018091CCE0
	private void HandleUpgradeResult(CardUpgradeResponseDTO response); // 0x000000018091CCE0-0x000000018091D130
	private void OnUpgradeError(string error); // 0x000000018091D130-0x000000018091D3F0
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__48))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x000000018091D3F0-0x000000018091D490
	private void SetSetPanelVisible(bool visible); // 0x000000018091D490-0x000000018091D9E0
	private void ShowMessage(string msg); // 0x000000018091D9E0-0x000000018091DB70
	private void HideMessage(); // 0x000000018091DB70-0x000000018091DCD0
	private void ShowResult(string msg, Color color); // 0x000000018091DCD0-0x000000018091DEC0
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__53))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x000000018091DEC0-0x000000018091DF80
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__54))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x005F1653 */, float moveDistance = 80f /* Metadata: 0x005F1657 */); // 0x000000018091DF80-0x000000018091E040
	private void OnError(string error); // 0x000000018091E040-0x000000018091E0C0
	[CompilerGenerated]
	private void _LoadAllData_b__32_0(UserDTO user); // 0x00000001802D8ED0-0x00000001802D8F30
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_0(UserDTO user); // 0x00000001802D8ED0-0x00000001802D8F30
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_1(List<CardDTO> cards); // 0x000000018091E1C0-0x000000018091E330
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__48_2(CardDTO c); // 0x000000018091E330-0x000000018091E360
}

