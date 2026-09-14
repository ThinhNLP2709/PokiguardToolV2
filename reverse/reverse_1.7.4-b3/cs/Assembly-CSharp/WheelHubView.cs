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

public class WheelHubView // TypeDefIndex: 1546
{
	// Fields
	private static readonly Color COL_PITY_NORMAL; // 0x00
	private static readonly Color COL_PITY_SOON; // 0x10
	private static readonly string[] SkipSubtrees; // 0x20
	public RawImage wheelBg; // 0x10
	public Image wheelBgImage; // 0x18
	public Image wheelBgSolid; // 0x20
	public UnityEngine.UI.Text txtTitleWheel; // 0x28
	public Button btnOne; // 0x30
	public Button btnTen; // 0x38
	public UnityEngine.UI.Text txtCost1; // 0x40
	public UnityEngine.UI.Text txtCost10; // 0x48
	public Image iconCost1; // 0x50
	public Image iconCost10; // 0x58
	public UnityEngine.UI.Text lblCost1; // 0x60
	public UnityEngine.UI.Text lblCost10; // 0x68
	public UnityEngine.UI.Text txtFreeSpins; // 0x70
	public UnityEngine.UI.Text lblFreeSpins; // 0x78
	public UnityEngine.UI.Text txtCountdown; // 0x80
	public UnityEngine.UI.Text txtDaily; // 0x88
	public UnityEngine.UI.Text txtWallet; // 0x90
	public Image iconWallet; // 0x98
	public UnityEngine.UI.Text txtEmpty; // 0xA0
	public Button btnRates; // 0xA8
	public Button btnHistory; // 0xB0
	public GameObject pityGroup; // 0xB8
	public Image pityFill; // 0xC0
	public UnityEngine.UI.Text txtPity; // 0xC8
	public Button btnInfo; // 0xD0
	public GameObject infoPopup; // 0xD8
	public ScrollRect infoScroll; // 0xE0
	public UnityEngine.UI.Text txtInfoBody; // 0xE8
	public UnityEngine.UI.Text txtInfoTitle; // 0xF0
	public Button btnInfoClose; // 0xF8
	public GameObject bonusStrip; // 0x100
	public readonly List<TreasureWheelBonusView> bonuses; // 0x108
	public Image wheelFlash; // 0x110
	public RectTransform pointer; // 0x118
	private Transform _root; // 0x120
	private long _countdownLeft; // 0x128
	private float _countdownFrac; // 0x130
	private long _lastShownSecond; // 0x138
	private int _bgFadeId; // 0x140
	private int _solidFadeId; // 0x144
	private Color _solidTarget; // 0x148

	// Properties
	public bool InfoOpen { get; } // 0x0000000180843C60-0x0000000180843DC0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1547
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<TreasureWheelBonusView> __9__49_0; // 0x08

		// Constructors
		static __c(); // 0x000000018084DAF0-0x000000018084DB90
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _Wire_b__49_0(TreasureWheelBonusView a, TreasureWheelBonusView b); // 0x000000018084DB90-0x000000018084DBD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 1548
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Sprite sprite; // 0x18
		public GameObject go; // 0x20
		public float a0; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass72_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyBackground_b__0(float v); // 0x000000018084DBD0-0x000000018084DBF0
		internal void _ApplyBackground_b__1(); // 0x000000018084DBF0-0x000000018084DE60
		internal void _ApplyBackground_b__2(float v); // 0x000000018084DBD0-0x000000018084DBF0
		internal void _ApplyBackground_b__3(); // 0x000000018084DE60-0x000000018084DEA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1549
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Color from; // 0x18
		public Color target; // 0x28

		// Constructors
		public __c__DisplayClass73_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplySolid_b__0(float v); // 0x000000018084DEA0-0x000000018084E080
		internal void _ApplySolid_b__1(); // 0x000000018084E080-0x000000018084E1C0
	}

	// Constructors
	public WheelHubView(); // 0x000000018084D800-0x000000018084D900
	static WheelHubView(); // 0x000000018084D900-0x000000018084DAF0

	// Methods
	public void Wire(Transform root); // 0x0000000180843DC0-0x0000000180845080
	public void Apply(WheelBoardVM vm); // 0x0000000180845080-0x00000001808455D0
	public void Refresh(WheelBoardVM vm); // 0x00000001808455D0-0x00000001808456D0
	private void ApplyCost(WheelBoardVM vm); // 0x00000001808456D0-0x0000000180845A70
	private void ApplyWallet(WheelBoardVM vm); // 0x0000000180845A70-0x0000000180845CF0
	private void ApplyFreeSpins(WheelBoardVM vm); // 0x0000000180845CF0-0x0000000180845FA0
	private void WirePity(); // 0x0000000180845FA0-0x0000000180846530
	private void BuildPityGroup(); // 0x0000000180846530-0x0000000180846CE0
	private static GameObject NewNode(string nodeName, Transform parent, Vector2 pos, Vector2 size); // 0x0000000180846CE0-0x0000000180846FE0
	private void ApplyPity(WheelBoardVM vm); // 0x0000000180846FE0-0x00000001808476B0
	private static string RarityLabel(string rarity); // 0x00000001808476B0-0x0000000180847760
	private void WireInfo(); // 0x0000000180847760-0x00000001808480A0
	private void BuildInfoButton(); // 0x00000001808480A0-0x0000000180848710
	private void BuildInfoPopup(); // 0x0000000180848710-0x0000000180849F30
	public void ShowInfo(WheelBoardVM vm); // 0x0000000180849F30-0x000000018084A410
	public void HideInfo(); // 0x000000018084A410-0x000000018084A560
	public void ScrollInfoToTop(); // 0x000000018084A560-0x000000018084A840
	private static UnityEngine.UI.Text NewText(GameObject go, int size, TextAnchor align, Color color); // 0x000000018084A840-0x000000018084AA20
	private void ApplyCountdown(WheelBoardVM vm); // 0x000000018084AA20-0x000000018084ABD0
	private void ApplyBonuses(TreasureWheelBonusDTO[] data); // 0x000000018084ABD0-0x000000018084AE30
	public void SetBonusHandler(Action<TreasureWheelBonusView> handler); // 0x000000018084AE30-0x000000018084AF50
	public bool TickCountdown(float unscaledDt); // 0x000000018084AF50-0x000000018084B110
	private void RenderCountdown(); // 0x000000018084B110-0x000000018084B2B0
	public void ApplyBackground(WheelKind kind, bool crossFade); // 0x000000018084B2B0-0x000000018084BA80
	private void ApplySolid(Color target, bool crossFade); // 0x000000018084BA80-0x000000018084BEE0
	private void SwapBackground(Sprite sprite); // 0x000000018084BEE0-0x000000018084C170
	private float CurrentAlpha(); // 0x000000018084C170-0x000000018084C330
	private void SetAlpha(float a); // 0x000000018084C330-0x000000018084C560
	public void StopBackgroundFx(); // 0x000000018084C560-0x000000018084C8F0
	public void SetSpinInteractable(bool on); // 0x000000018084C8F0-0x000000018084CAB0
	private static void SetText(UnityEngine.UI.Text t, string value); // 0x000000018084CAB0-0x000000018084CCA0
	private static void SetOptionalText(UnityEngine.UI.Text t, string value, Color color); // 0x000000018084CCA0-0x000000018084CE80
	private static void SetActive(Button b, bool on); // 0x000000018084CE80-0x000000018084CFD0
	private static void ApplyIcon(Image target, Sprite sprite, bool show); // 0x000000018084CFD0-0x000000018084D250
	private T Find<T>(string nodeName)
		where T : Component;
	private static T FindIn<T>(Transform root, string nodeName)
		where T : Component;
	private Transform FindTransform(string nodeName); // 0x000000018084D250-0x000000018084D3A0
	private static bool IsSkipped(string nodeName); // 0x000000018084D3A0-0x000000018084D4D0
	private static Transform Search(Transform node, string nodeName); // 0x000000018084D4D0-0x000000018084D800
}

