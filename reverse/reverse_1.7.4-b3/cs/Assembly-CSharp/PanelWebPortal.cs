/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PanelWebPortal : MonoBehaviour // TypeDefIndex: 1507
{
	// Fields
	public const string PANEL_KEY = "PanelWebPortal"; // Metadata: 0x005EFDE5
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
	private const float TitleBarH = 56f; // Metadata: 0x005EFDF4
	private const float BtnSize = 46f; // Metadata: 0x005EFDF8
	private static readonly Color BgColor; // 0x00
	private static readonly Color BarColor; // 0x10
	private static readonly Color GoldText; // 0x20
	private RectTransform _spinnerRT; // 0x88

	// Constructors
	public PanelWebPortal(); // 0x000000018028A560-0x000000018028A5B0
	static PanelWebPortal(); // 0x00000001808318C0-0x0000000180831940

	// Methods
	private void Update(); // 0x000000018082D920-0x000000018082DCC0
	public void SetTitle(string title); // 0x000000018082DCC0-0x000000018082DDD0
	public void ShowSpinner(bool on); // 0x000000018082DDD0-0x000000018082DF20
	public void ShowError(string message); // 0x000000018082DF20-0x000000018082E220
	public void HideError(); // 0x000000018082E220-0x000000018082E360
	public void ShowGuide(string message); // 0x000000018082E360-0x000000018082E590
	public void PlayOpenFx(); // 0x000000018082E590-0x000000018082E9C0
	public void FlashGold(); // 0x000000018082E9C0-0x000000018082ED70
	public bool TryGetWebMargins(out int left, out int top, out int right, out int bottom); // 0x000000018082ED70-0x000000018082F1D0
	[ContextMenu("Tao UI")]
	public void BuildUI(); // 0x000000018082F1D0-0x0000000180830770
	private static GameObject NewGO(string name, Transform parent); // 0x0000000180830770-0x0000000180830930
	private static void Stretch(GameObject go); // 0x0000000180830930-0x0000000180830A40
	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax); // 0x0000000180830A40-0x0000000180830B50
	private static GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax); // 0x0000000180830B50-0x0000000180830E40
	private static void AddOutline(GameObject textGo); // 0x0000000180830E40-0x0000000180831040
	private static Button AddIconButton(GameObject parent, string name, string glyph, Vector2 anchor, Vector2 offset); // 0x0000000180831040-0x0000000180831310
	private static Button AddWideButton(GameObject parent, string name, string label, float xMin, float xMax, float yMin, float yMax); // 0x0000000180831310-0x0000000180831700
	private static Sprite Sp(string resPath, string subName = null); // 0x0000000180831700-0x00000001808318C0
	[CompilerGenerated]
	private void _FlashGold_b__27_0(float a); // 0x0000000180831940-0x0000000180831AC0
	[CompilerGenerated]
	private void _FlashGold_b__27_1(); // 0x0000000180831AC0-0x0000000180831C20
}

