/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PanelWebPortal : MonoBehaviour // TypeDefIndex: 902
{
	// Fields
	public const string PANEL_KEY = "PanelWebPortal"; // Metadata: 0x0064CD51
	[Header("Thanh ti\u00EAu \u0111\u1EC1")]
	public UnityEngine.UI.Text txtTitle; // 0x20
	public Button btnClose; // 0x28
	public Button btnReload; // 0x30
	public RectTransform titleBar; // 0x38
	[Header("V\u00F9ng webview (native view ph\u1EE7 l\u00EAn \u0111\u00FAng \u00F4 n\u00E0y)")]
	public RectTransform webArea; // 0x40
	[Header("Tr\u1EA1ng th\u00E1i")]
	public GameObject spinner; // 0x48
	public GameObject errorOverlay; // 0x50
	public UnityEngine.UI.Text txtError; // 0x58
	public Button btnRetry; // 0x60
	[Header("H\u01B0\u1EDBng d\u1EABn (n\u1EC1n t\u1EA3ng kh\u00F4ng c\u00F3 webview nh\u00FAng)")]
	public GameObject guideOverlay; // 0x68
	public UnityEngine.UI.Text txtGuide; // 0x70
	public Button btnRefresh; // 0x78
	[Header("FX")]
	public Image flashOverlay; // 0x80
	private const float TitleBarH = 56f; // Metadata: 0x0064CD60
	private const float BtnSize = 46f; // Metadata: 0x0064CD64
	private static readonly Color BgColor; // 0x00
	private static readonly Color BarColor; // 0x10
	private static readonly Color GoldText; // 0x20
	private RectTransform _spinnerRT; // 0x88

	// Constructors
	public PanelWebPortal(); // 0x00000001802E7A70-0x00000001802E7BC0
	static PanelWebPortal(); // 0x0000000180454F70-0x0000000180454FF0

	// Methods
	private void Update(); // 0x0000000180454E40-0x0000000180454F70
	public void SetTitle(string title); // 0x0000000180454470-0x0000000180454500
	public void ShowSpinner(bool on); // 0x00000001804546F0-0x0000000180454780
	public void ShowError(string message); // 0x0000000180454500-0x0000000180454610
	public void HideError(); // 0x0000000180454070-0x00000001804540F0
	public void ShowGuide(string message); // 0x0000000180454610-0x00000001804546F0
	public void PlayOpenFx(); // 0x0000000180454230-0x0000000180454470
	public void FlashGold(); // 0x0000000180453E00-0x0000000180454070
	public bool TryGetWebMargins(out int left, out int top, out int right, out int bottom); // 0x00000001804549B0-0x0000000180454CB0
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x0000000180452FF0-0x0000000180453E00
	private static GameObject NewGO(string name, Transform parent); // 0x00000001804540F0-0x0000000180454230
	private static void Stretch(GameObject go); // 0x00000001804548B0-0x00000001804549B0
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax); // 0x0000000180452EE0-0x0000000180452FF0
	private static GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax); // 0x0000000180452A60-0x0000000180452C20
	private static void AddOutline(GameObject textGo); // 0x0000000180452960-0x0000000180452A60
	private static Button AddIconButton(GameObject parent, string name, string glyph, Vector2 anchor, Vector2 offset); // 0x00000001804526F0-0x0000000180452960
	private static Button AddWideButton(GameObject parent, string name, string label, float xMin, float xMax, float yMin, float yMax); // 0x0000000180452C20-0x0000000180452EE0
	private static Sprite Sp(string resPath, string subName = null); // 0x0000000180454780-0x00000001804548B0
	[CompilerGenerated]
	private void _FlashGold_b__27_0(float a); // 0x0000000180454CB0-0x0000000180454DB0
	[CompilerGenerated]
	private void _FlashGold_b__27_1(); // 0x0000000180454DB0-0x0000000180454E40
}

