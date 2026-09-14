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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerUpdateCard : MonoBehaviour // TypeDefIndex: 1869
{
	// Fields
	public const string PANEL_KEY = "PanelUpdateCard"; // Metadata: 0x005F028A
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
	public class CardDTO // TypeDefIndex: 1870
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
	public class UserDTO // TypeDefIndex: 1871
	{
		// Fields
		public int id; // 0x10
		public int gold; // 0x14

		// Constructors
		public UserDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class CardUpgradeRequestDTO // TypeDefIndex: 1872
	{
		// Fields
		public long userId; // 0x10
		public long userCardId; // 0x18
		public bool useGold; // 0x20

		// Constructors
		public CardUpgradeRequestDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class CardUpgradeResponseDTO // TypeDefIndex: 1873
	{
		// Fields
		public string message; // 0x10
		public bool upgraded; // 0x18

		// Constructors
		public CardUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1874
	{
		// Fields
		public CardDTO captured; // 0x10
		public ManagerUpdateCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderCardList_b__0(); // 0x000000018091AE90-0x000000018091AEC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 1875
	{
		// Fields
		public CardUpgradeResponseDTO response; // 0x10
		public bool apiDone; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass43_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpgradeCardAPI_b__0(CardUpgradeResponseDTO res); // 0x000000018076D550-0x000000018076D5B0
		internal void _UpgradeCardAPI_b__1(string err); // 0x000000018091AEC0-0x000000018091AF20
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__54 : IEnumerator<object> // TypeDefIndex: 1876
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018091AF20-0x000000018091B3C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091B3C0-0x000000018091B400
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__53 : IEnumerator<object> // TypeDefIndex: 1877
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018091B400-0x000000018091B650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091B650-0x000000018091B690
	}

	[CompilerGenerated]
	private sealed class _LoadAllData_d__32 : IEnumerator<object> // TypeDefIndex: 1878
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
		private bool MoveNext(); // 0x000000018091B690-0x000000018091BA20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091BA20-0x000000018091BA60
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__48 : IEnumerator<object> // TypeDefIndex: 1879
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
		private bool MoveNext(); // 0x000000018091BA60-0x000000018091C0D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091C0D0-0x000000018091C110
	}

	[CompilerGenerated]
	private sealed class _UpgradeCardAPI_d__43 : IEnumerator<object> // TypeDefIndex: 1880
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
		private bool MoveNext(); // 0x000000018091C110-0x000000018091C6B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091C6B0-0x000000018091C6F0
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenShowResult_d__45 : IEnumerator<object> // TypeDefIndex: 1881
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018091C6F0-0x000000018091CA90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018091CA90-0x000000018091CAD0
	}

	// Constructors
	public ManagerUpdateCard(); // 0x000000018091ABF0-0x000000018091ACF0

	// Methods
	private void OnDisable(); // 0x0000000180916330-0x0000000180916340
	private void Start(); // 0x0000000180916340-0x0000000180916490
	private void SetupInitialStates(); // 0x0000000180916490-0x0000000180916810
	private void SetupButtons(); // 0x0000000180916810-0x0000000180916B70
	public void OpenPanel(); // 0x0000000180916B70-0x0000000180916DE0
	public void ClosePanel(); // 0x0000000180916DE0-0x0000000180917050
	private void LoadData(); // 0x0000000180917050-0x0000000180917190
	[IteratorStateMachine(typeof(_LoadAllData_d__32))]
	private IEnumerator LoadAllData(int userId); // 0x0000000180917190-0x0000000180917240
	private void OnCardsReceived(List<CardDTO> cards); // 0x0000000180917240-0x00000001809173B0
	private void RenderCardList(); // 0x00000001809173B0-0x0000000180917F50
	private Sprite LoadCardSprite(long cardId); // 0x0000000180917F50-0x0000000180918020
	private void SelectCard(CardDTO card); // 0x0000000180918020-0x0000000180918760
	private int CalculateDame(CardDTO card); // 0x0000000180918760-0x00000001809187B0
	public static int ValueAtLevel(int baseValue, int level); // 0x00000001809187B0-0x00000001809187F0
	public static string FormatVND(long amount); // 0x00000001809187F0-0x0000000180918900
	private void UpdateStoneSlotUI(CardDTO card); // 0x0000000180918900-0x0000000180918CC0
	private void OnToggleBChanged(bool isOn); // 0x0000000180918CC0-0x0000000180918E00
	private void OnUpgradeButtonClicked(); // 0x0000000180918E00-0x0000000180919370
	[IteratorStateMachine(typeof(_UpgradeCardAPI_d__43))]
	private IEnumerator UpgradeCardAPI(CardUpgradeRequestDTO request); // 0x0000000180919370-0x0000000180919480
	private void OnUpgradeSuccess(CardUpgradeResponseDTO response); // 0x0000000180919480-0x0000000180919720
	[IteratorStateMachine(typeof(_WaitForAnimationThenShowResult_d__45))]
	private IEnumerator WaitForAnimationThenShowResult(CardUpgradeResponseDTO response); // 0x0000000180919720-0x0000000180919830
	private void HandleUpgradeResult(CardUpgradeResponseDTO response); // 0x0000000180919830-0x0000000180919C80
	private void OnUpgradeError(string error); // 0x0000000180919C80-0x0000000180919F20
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__48))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x0000000180919F20-0x0000000180919FC0
	private void SetSetPanelVisible(bool visible); // 0x0000000180919FC0-0x000000018091A510
	private void ShowMessage(string msg); // 0x000000018091A510-0x000000018091A6A0
	private void HideMessage(); // 0x000000018091A6A0-0x000000018091A800
	private void ShowResult(string msg, Color color); // 0x000000018091A800-0x000000018091A9F0
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__53))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x000000018091A9F0-0x000000018091AAB0
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__54))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x005F0282 */, float moveDistance = 80f /* Metadata: 0x005F0286 */); // 0x000000018091AAB0-0x000000018091AB70
	private void OnError(string error); // 0x000000018091AB70-0x000000018091ABF0
	[CompilerGenerated]
	private void _LoadAllData_b__32_0(UserDTO user); // 0x00000001802D8EA0-0x00000001802D8F00
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_0(UserDTO user); // 0x00000001802D8EA0-0x00000001802D8F00
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__48_1(List<CardDTO> cards); // 0x000000018091ACF0-0x000000018091AE60
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__48_2(CardDTO c); // 0x000000018091AE60-0x000000018091AE90
}

