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

public class ManagerUpdateCard : MonoBehaviour // TypeDefIndex: 1256
{
	// Fields
	public const string PANEL_KEY = "PanelUpdateCard"; // Metadata: 0x0064D556
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
	public class CardDTO // TypeDefIndex: 1257
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
		public CardDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class UserDTO // TypeDefIndex: 1258
	{
		// Fields
		public int id; // 0x10
		public int gold; // 0x14

		// Constructors
		public UserDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class CardUpgradeRequestDTO // TypeDefIndex: 1259
	{
		// Fields
		public long userId; // 0x10
		public long userCardId; // 0x18
		public bool useGold; // 0x20

		// Constructors
		public CardUpgradeRequestDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class CardUpgradeResponseDTO // TypeDefIndex: 1260
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int newLevel; // 0x20
		public bool upgraded; // 0x24

		// Constructors
		public CardUpgradeResponseDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 1261
	{
		// Fields
		public CardDTO captured; // 0x10
		public ManagerUpdateCard __4__this; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RenderCardList_b__0(); // 0x00000001804EA970-0x00000001804EA9A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 1262
	{
		// Fields
		public CardUpgradeResponseDTO response; // 0x10
		public bool apiDone; // 0x18
		public string errorMsg; // 0x20

		// Constructors
		public __c__DisplayClass42_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpgradeCardAPI_b__0(CardUpgradeResponseDTO res); // 0x0000000180439DF0-0x0000000180439E10
		internal void _UpgradeCardAPI_b__1(string err); // 0x00000001804EA9A0-0x00000001804EA9C0
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__53 : IEnumerator<object> // TypeDefIndex: 1263
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__53(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E4570-0x00000001804E48D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E48D0-0x00000001804E4910
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__52 : IEnumerator<object> // TypeDefIndex: 1264
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerUpdateCard __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__52(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804E5390-0x00000001804E54D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E54D0-0x00000001804E5510
	}

	[CompilerGenerated]
	private sealed class _LoadAllData_d__32 : IEnumerator<object> // TypeDefIndex: 1265
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerUpdateCard __4__this; // 0x28
		private IEnumerator _cardsRequest_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadAllData_d__32(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001804E5510-0x00000001804E5780
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E5780-0x00000001804E57C0
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__47 : IEnumerator<object> // TypeDefIndex: 1266
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		private IEnumerator _cardsRequest_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__47(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804E60E0-0x00000001804E6520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E6520-0x00000001804E6560
	}

	[CompilerGenerated]
	private sealed class _UpgradeCardAPI_d__42 : IEnumerator<object> // TypeDefIndex: 1267
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUpgradeRequestDTO request; // 0x20
		private __c__DisplayClass42_0 __8__1; // 0x28
		public ManagerUpdateCard __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeCardAPI_d__42(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804EB780-0x00000001804EBBE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EBBE0-0x00000001804EBC20
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenShowResult_d__44 : IEnumerator<object> // TypeDefIndex: 1268
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerUpdateCard __4__this; // 0x20
		public CardUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenShowResult_d__44(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804EBFA0-0x00000001804EC1B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EC1B0-0x00000001804EC1F0
	}

	// Constructors
	public ManagerUpdateCard(); // 0x00000001804E44F0-0x00000001804E4570

	// Methods
	private void OnDisable(); // 0x00000001804E22E0-0x00000001804E22F0
	private void Start(); // 0x00000001804E3F40-0x00000001804E40E0
	private void SetupInitialStates(); // 0x00000001804E3C30-0x00000001804E3D60
	private void SetupButtons(); // 0x00000001804E3A50-0x00000001804E3C30
	public void OpenPanel(); // 0x00000001804E2B80-0x00000001804E2CE0
	public void ClosePanel(); // 0x00000001804E1A60-0x00000001804E1BC0
	private void LoadData(); // 0x00000001804E20D0-0x00000001804E21D0
	[IteratorStateMachine(typeof(_LoadAllData_d__32))]
	private IEnumerator LoadAllData(int userId); // 0x00000001804E1FC0-0x00000001804E2040
	private void OnCardsReceived(List<CardDTO> cards); // 0x00000001804E21D0-0x00000001804E22E0
	private void RenderCardList(); // 0x00000001804E2D50-0x00000001804E3440
	private Sprite LoadCardSprite(long cardId); // 0x00000001804E2040-0x00000001804E20D0
	private void SelectCard(CardDTO card); // 0x00000001804E3440-0x00000001804E38C0
	private int CalculateDame(CardDTO card); // 0x00000001804E1A20-0x00000001804E1A60
	public static string FormatVND(long amount); // 0x00000001804E1BC0-0x00000001804E1C40
	private void UpdateStoneSlotUI(CardDTO card); // 0x00000001804E4230-0x00000001804E43D0
	private void OnToggleBChanged(bool isOn); // 0x00000001804E2360-0x00000001804E2480
	private void OnUpgradeButtonClicked(); // 0x00000001804E2480-0x00000001804E27E0
	[IteratorStateMachine(typeof(_UpgradeCardAPI_d__42))]
	private IEnumerator UpgradeCardAPI(CardUpgradeRequestDTO request); // 0x00000001804E43D0-0x00000001804E4460
	private void OnUpgradeSuccess(CardUpgradeResponseDTO response); // 0x00000001804E2A40-0x00000001804E2B80
	[IteratorStateMachine(typeof(_WaitForAnimationThenShowResult_d__44))]
	private IEnumerator WaitForAnimationThenShowResult(CardUpgradeResponseDTO response); // 0x00000001804E4460-0x00000001804E44F0
	private void HandleUpgradeResult(CardUpgradeResponseDTO response); // 0x00000001804E1C40-0x00000001804E1EB0
	private void OnUpgradeError(string error); // 0x00000001804E27E0-0x00000001804E2A40
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__47))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x00000001804E2CE0-0x00000001804E2D50
	private void SetSetPanelVisible(bool visible); // 0x00000001804E38C0-0x00000001804E3A50
	private void ShowMessage(string msg); // 0x00000001804E3D60-0x00000001804E3E20
	private void HideMessage(); // 0x00000001804E1EB0-0x00000001804E1F40
	private void ShowResult(string msg, Color color); // 0x00000001804E3E20-0x00000001804E3F40
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__52))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x00000001804E1F40-0x00000001804E1FC0
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__53))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x0064D54E */, float moveDistance = 80f /* Metadata: 0x0064D552 */); // 0x00000001804E1990-0x00000001804E1A20
	private void OnError(string error); // 0x00000001804E22F0-0x00000001804E2360
	[CompilerGenerated]
	private void _LoadAllData_b__32_0(UserDTO user); // 0x000000018033EAB0-0x000000018033EAD0
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__47_0(UserDTO user); // 0x000000018033EAB0-0x000000018033EAD0
	[CompilerGenerated]
	private void _ReloadDataAfterUpgrade_b__47_1(List<CardDTO> cards); // 0x00000001804E40E0-0x00000001804E4200
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__47_2(CardDTO c); // 0x00000001804E4200-0x00000001804E4230
}

