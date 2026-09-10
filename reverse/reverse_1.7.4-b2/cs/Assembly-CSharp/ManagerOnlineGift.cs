/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerOnlineGift : MonoBehaviour // TypeDefIndex: 1331
{
	// Fields
	public const string PANEL_KEY = "PanelOnlineGift"; // Metadata: 0x0068CE9E
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
	private const float BoxW = 823.92f; // Metadata: 0x0068CEAE
	private const float BoxH = 500f; // Metadata: 0x0068CEB2
	private const float RowH = 78f; // Metadata: 0x0068CEB6
	private const float RewardCell = 66f; // Metadata: 0x0068CEBA
	private static readonly Color GoldText; // 0x08
	private static readonly Color LabelText; // 0x18
	private static readonly Color WarnText; // 0x28

	// Events
	public static event Action<OnlineGiftData> OnStatusUpdated {
		add; // 0x000000018059CB90-0x000000018059CC80
		remove; // 0x000000018059CC80-0x000000018059CD70
	}

	// Nested types
	private class RowUI // TypeDefIndex: 1332
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
		public RowUI(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 1333
	{
		// Fields
		public OnlineGiftMilestoneData milestone; // 0x10
		public ManagerOnlineGift __4__this; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildRows_b__0(); // 0x00000001805BE300-0x00000001805BE330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 1334
	{
		// Fields
		public ManagerOnlineGift __4__this; // 0x10
		public OnlineGiftMilestoneData milestone; // 0x18

		// Constructors
		public __c__DisplayClass37_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickClaim_b__0(OnlineGiftMilestoneData claimed); // 0x00000001805BE330-0x00000001805BE360
	}

	// Constructors
	public ManagerOnlineGift(); // 0x000000018059CB10-0x000000018059CB90
	static ManagerOnlineGift(); // 0x000000018059CA90-0x000000018059CB10

	// Methods
	private void OnDisable(); // 0x000000018059BAC0-0x000000018059BAD0
	private void Awake(); // 0x0000000180597C10-0x0000000180597E00
	private void Start(); // 0x000000018059C1C0-0x000000018059C3F0
	private void BindFromHierarchy(); // 0x0000000180597F10-0x0000000180598250
	public void OpenPanel(); // 0x000000018059BBA0-0x000000018059BCB0
	public void ClosePanel(); // 0x000000018059ABB0-0x000000018059AD10
	private void CloseGiftBoxPanel(); // 0x000000018059AB30-0x000000018059ABB0
	private void LoadStatus(); // 0x000000018059B1C0-0x000000018059B310
	private void OnStatusLoaded(OnlineGiftData data); // 0x000000018059BAD0-0x000000018059BBA0
	private void BuildRows(); // 0x0000000180598E80-0x0000000180599BA0
	private void ApplyRowState(RowUI row); // 0x0000000180597910-0x0000000180597C10
	private void Update(); // 0x000000018059C590-0x000000018059CA90
	private int CurrentDisplaySeconds(); // 0x000000018059AD10-0x000000018059ADB0
	private void OnClickClaim(OnlineGiftMilestoneData milestone); // 0x000000018059B7B0-0x000000018059BAC0
	private void OnClaimSuccess(OnlineGiftMilestoneData claimed, OnlineGiftMilestoneData requested); // 0x000000018059B620-0x000000018059B7B0
	private void OnClaimError(string error); // 0x000000018059B450-0x000000018059B620
	private static string ExtractServerMessage(string error); // 0x000000018059ADB0-0x000000018059AEC0
	private void ShowNotice(string message); // 0x000000018059BCB0-0x000000018059BD60
	private void ShowRewardResultPanel(OnlineGiftRewardData reward); // 0x000000018059BD60-0x000000018059C090
	public static string FormatDurationLabel(int seconds); // 0x000000018059B010-0x000000018059B1C0
	public static string FormatClock(int seconds); // 0x000000018059AEC0-0x000000018059B010
	private static Sprite Sp(string resPath, string subName = null); // 0x000000018059C090-0x000000018059C1C0
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x0000000180599BA0-0x000000018059AB30
	private GameObject BuildRowTemplate(Transform parent); // 0x0000000180598250-0x0000000180598E80
	private static void AddOutline(GameObject textGo); // 0x0000000180597630-0x0000000180597730
	private static GameObject NewGO(string name, Transform parent); // 0x000000018059B310-0x000000018059B450
	private static void Stretch(GameObject go); // 0x000000018059C3F0-0x000000018059C4F0
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0068CE7E */, float padR = 0f /* Metadata: 0x0068CE82 */, float padT = 0f /* Metadata: 0x0068CE86 */, float padB = 0f /* Metadata: 0x0068CE8A */); // 0x0000000180597E00-0x0000000180597F10
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0068CE8E */, float padR = 0f /* Metadata: 0x0068CE92 */, float padT = 0f /* Metadata: 0x0068CE96 */, float padB = 0f /* Metadata: 0x0068CE9A */); // 0x0000000180597730-0x0000000180597910
	[CompilerGenerated]
	private void _LoadStatus_b__31_0(string err); // 0x000000018059C4F0-0x000000018059C590
}

