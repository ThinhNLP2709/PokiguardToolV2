/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerOnlineGift : MonoBehaviour // TypeDefIndex: 1720
{
	// Fields
	public const string PANEL_KEY = "PanelOnlineGift"; // Metadata: 0x005F0132
	[CompilerGenerated]
	private static Action<OnlineGiftData> OnStatusUpdated; // 0x00
	[Header("Refs (builder t\u1EF1 g\u00E1n \u2014 fallback bind theo t\u00EAn node)")]
	public GameObject panelRoot; // 0x20
	public UnityEngine.UI.Text txtTitle; // 0x28
	public UnityEngine.UI.Text txtToday; // 0x30
	public UnityEngine.UI.Text txtNotice; // 0x38
	public Transform content; // 0x40
	public GameObject rowTemplate; // 0x48
	public Button btnClose; // 0x50
	public Font customFont; // 0x58
	[Header("Result Panel (m\u01B0\u1EE3n PanelGiftBox c\u1EE7a hub l\u00FAc runtime)")]
	public GameObject panelGiftBox; // 0x60
	public Transform listRewardContainer; // 0x68
	public Button btnGetClose; // 0x70
	private int userId; // 0x78
	private OnlineGiftData _data; // 0x80
	private float _fetchAtRealtime; // 0x88
	private float _nextUiTick; // 0x8C
	private float _nextAutoRefetchAt; // 0x90
	private bool _loading; // 0x94
	private float _noticeHideAt; // 0x98
	private readonly List<RowUI> _rows; // 0xA0
	private const float BoxW = 823.92f; // Metadata: 0x005F0142
	private const float BoxH = 500f; // Metadata: 0x005F0146
	private const float RowH = 78f; // Metadata: 0x005F014A
	private const float RewardCell = 66f; // Metadata: 0x005F014E
	private static readonly Color GoldText; // 0x08
	private static readonly Color LabelText; // 0x18
	private static readonly Color WarnText; // 0x28

	// Events
	public static event Action<OnlineGiftData> OnStatusUpdated {
		add; // 0x00000001808B3E70-0x00000001808B3FC0
		remove; // 0x00000001808B3FC0-0x00000001808B4110
	}

	// Nested types
	private class RowUI // TypeDefIndex: 1721
	{
		// Fields
		public OnlineGiftMilestoneData milestone; // 0x10
		public GameObject root; // 0x18
		public Button btn; // 0x20
		public UnityEngine.UI.Text btnTxt; // 0x28
		public GameObject point; // 0x30
		public GameObject tick; // 0x38
		public Image btnImg; // 0x40

		// Constructors
		public RowUI(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 1722
	{
		// Fields
		public OnlineGiftMilestoneData milestone; // 0x10
		public ManagerOnlineGift __4__this; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildRows_b__0(); // 0x00000001808BC700-0x00000001808BC730
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 1723
	{
		// Fields
		public ManagerOnlineGift __4__this; // 0x10
		public OnlineGiftMilestoneData milestone; // 0x18

		// Constructors
		public __c__DisplayClass37_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickClaim_b__0(OnlineGiftMilestoneData claimed); // 0x00000001808BC730-0x00000001808BC760
	}

	// Constructors
	public ManagerOnlineGift(); // 0x00000001808BC420-0x00000001808BC520
	static ManagerOnlineGift(); // 0x00000001808BC520-0x00000001808BC5A0

	// Methods
	private void OnDisable(); // 0x00000001808B4110-0x00000001808B4120
	private void Awake(); // 0x00000001808B4120-0x00000001808B45D0
	private void Start(); // 0x00000001808B45D0-0x00000001808B49C0
	private void BindFromHierarchy(); // 0x00000001808B49C0-0x00000001808B5450
	public void OpenPanel(); // 0x00000001808B5450-0x00000001808B5690
	public void ClosePanel(); // 0x00000001808B5690-0x00000001808B5900
	private void CloseGiftBoxPanel(); // 0x00000001808B5900-0x00000001808B5A40
	private void LoadStatus(); // 0x00000001808B5A40-0x00000001808B5BC0
	private void OnStatusLoaded(OnlineGiftData data); // 0x00000001808B5BC0-0x00000001808B5D10
	private void BuildRows(); // 0x00000001808B5D10-0x00000001808B7300
	private void ApplyRowState(RowUI row); // 0x00000001808B7300-0x00000001808B79F0
	private void Update(); // 0x00000001808B79F0-0x00000001808B8140
	private int CurrentDisplaySeconds(); // 0x00000001808B8140-0x00000001808B81D0
	private void OnClickClaim(OnlineGiftMilestoneData milestone); // 0x00000001808B81D0-0x00000001808B8770
	private void OnClaimSuccess(OnlineGiftMilestoneData claimed, OnlineGiftMilestoneData requested); // 0x00000001808B8770-0x00000001808B89D0
	private void OnClaimError(string error); // 0x00000001808B89D0-0x00000001808B8AC0
	private static string ExtractServerMessage(string error); // 0x00000001808B8AC0-0x00000001808B8DF0
	private void ShowNotice(string message); // 0x00000001808B8DF0-0x00000001808B8F50
	private void ShowRewardResultPanel(OnlineGiftRewardData reward); // 0x00000001808B8F50-0x00000001808B93B0
	public static string FormatDurationLabel(int seconds); // 0x00000001808B93B0-0x00000001808B95C0
	public static string FormatClock(int seconds); // 0x00000001808B95C0-0x00000001808B97A0
	private static Sprite Sp(string resPath, string subName = null); // 0x00000001808B97A0-0x00000001808B9960
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x00000001808B9960-0x00000001808BAD30
	private GameObject BuildRowTemplate(Transform parent); // 0x00000001808BAD30-0x00000001808BBBB0
	private static void AddOutline(GameObject textGo); // 0x00000001808BBBB0-0x00000001808BBDB0
	private static GameObject NewGO(string name, Transform parent); // 0x00000001808BBDB0-0x00000001808BBF70
	private static void Stretch(GameObject go); // 0x00000001808BBF70-0x00000001808BC080
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005F0112 */, float padR = 0f /* Metadata: 0x005F0116 */, float padT = 0f /* Metadata: 0x005F011A */, float padB = 0f /* Metadata: 0x005F011E */); // 0x00000001808BC080-0x00000001808BC190
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x005F0122 */, float padR = 0f /* Metadata: 0x005F0126 */, float padT = 0f /* Metadata: 0x005F012A */, float padB = 0f /* Metadata: 0x005F012E */); // 0x00000001808BC190-0x00000001808BC420
	[CompilerGenerated]
	private void _LoadStatus_b__31_0(string err); // 0x00000001808BC5A0-0x00000001808BC700
}

