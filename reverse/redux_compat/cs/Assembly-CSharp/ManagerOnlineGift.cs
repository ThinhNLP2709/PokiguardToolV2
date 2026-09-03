/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerOnlineGift : MonoBehaviour // TypeDefIndex: 1117
{
	// Fields
	public const string PANEL_KEY = "PanelOnlineGift"; // Metadata: 0x0064D347
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
	private const float BoxW = 823.92f; // Metadata: 0x0064D357
	private const float BoxH = 500f; // Metadata: 0x0064D35B
	private const float RowH = 78f; // Metadata: 0x0064D35F
	private const float RewardCell = 66f; // Metadata: 0x0064D363
	private static readonly Color GoldText; // 0x08
	private static readonly Color LabelText; // 0x18
	private static readonly Color WarnText; // 0x28

	// Events
	public static event Action<OnlineGiftData> OnStatusUpdated {
		add; // 0x00000001804A4A40-0x00000001804A4B30
		remove; // 0x00000001804A4B30-0x00000001804A4C20
	}

	// Nested types
	private class RowUI // TypeDefIndex: 1118
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
		public RowUI(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 1119
	{
		// Fields
		public OnlineGiftMilestoneData milestone; // 0x10
		public ManagerOnlineGift __4__this; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildRows_b__0(); // 0x00000001804C3010-0x00000001804C3040
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 1120
	{
		// Fields
		public ManagerOnlineGift __4__this; // 0x10
		public OnlineGiftMilestoneData milestone; // 0x18

		// Constructors
		public __c__DisplayClass37_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnClickClaim_b__0(OnlineGiftMilestoneData claimed); // 0x00000001804C3040-0x00000001804C3070
	}

	// Constructors
	public ManagerOnlineGift(); // 0x00000001804A49C0-0x00000001804A4A40
	static ManagerOnlineGift(); // 0x00000001804A4940-0x00000001804A49C0

	// Methods
	private void OnDisable(); // 0x00000001804A3A80-0x00000001804A3A90
	private void Awake(); // 0x000000018049FB70-0x000000018049FD60
	private void Start(); // 0x00000001804A4070-0x00000001804A42A0
	private void BindFromHierarchy(); // 0x000000018049FE70-0x00000001804A01B0
	public void OpenPanel(); // 0x00000001804A3B60-0x00000001804A3C70
	public void ClosePanel(); // 0x00000001804A2990-0x00000001804A2AF0
	private void CloseGiftBoxPanel(); // 0x00000001804A2910-0x00000001804A2990
	private void LoadStatus(); // 0x00000001804A2FA0-0x00000001804A30F0
	private void OnStatusLoaded(OnlineGiftData data); // 0x00000001804A3A90-0x00000001804A3B60
	private void BuildRows(); // 0x00000001804A0DE0-0x00000001804A1980
	private void ApplyRowState(RowUI row); // 0x000000018049F870-0x000000018049FB70
	private void Update(); // 0x00000001804A4440-0x00000001804A4940
	private int CurrentDisplaySeconds(); // 0x00000001804A2AF0-0x00000001804A2B90
	private void OnClickClaim(OnlineGiftMilestoneData milestone); // 0x00000001804A3770-0x00000001804A3A80
	private void OnClaimSuccess(OnlineGiftMilestoneData claimed, OnlineGiftMilestoneData requested); // 0x00000001804A3400-0x00000001804A3770
	private void OnClaimError(string error); // 0x00000001804A3230-0x00000001804A3400
	private static string ExtractServerMessage(string error); // 0x00000001804A2B90-0x00000001804A2CA0
	private void ShowNotice(string message); // 0x00000001804A3C70-0x00000001804A3D20
	private void ShowRewardResultPanel(OnlineGiftRewardData reward); // 0x00000001804A3D20-0x00000001804A3F40
	public static string FormatDurationLabel(int seconds); // 0x00000001804A2DF0-0x00000001804A2FA0
	public static string FormatClock(int seconds); // 0x00000001804A2CA0-0x00000001804A2DF0
	private static Sprite Sp(string resPath, string subName = null); // 0x00000001804A3F40-0x00000001804A4070
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x00000001804A1980-0x00000001804A2910
	private GameObject BuildRowTemplate(Transform parent); // 0x00000001804A01B0-0x00000001804A0DE0
	private static void AddOutline(GameObject textGo); // 0x000000018049F590-0x000000018049F690
	private static GameObject NewGO(string name, Transform parent); // 0x00000001804A30F0-0x00000001804A3230
	private static void Stretch(GameObject go); // 0x00000001804A42A0-0x00000001804A43A0
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0064D327 */, float padR = 0f /* Metadata: 0x0064D32B */, float padT = 0f /* Metadata: 0x0064D32F */, float padB = 0f /* Metadata: 0x0064D333 */); // 0x000000018049FD60-0x000000018049FE70
	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0f /* Metadata: 0x0064D337 */, float padR = 0f /* Metadata: 0x0064D33B */, float padT = 0f /* Metadata: 0x0064D33F */, float padB = 0f /* Metadata: 0x0064D343 */); // 0x000000018049F690-0x000000018049F870
	[CompilerGenerated]
	private void _LoadStatus_b__31_0(string err); // 0x00000001804A43A0-0x00000001804A4440
}

