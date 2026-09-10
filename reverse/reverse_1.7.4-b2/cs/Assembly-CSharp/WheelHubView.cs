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

public class WheelHubView // TypeDefIndex: 1141
{
	// Fields
	public const string EXCLUDED_SUBTREE = "galaxyEmbed"; // Metadata: 0x0068C600
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
	public bool InfoOpen { get; } // 0x0000000180569EA0-0x0000000180569F30 
	public bool HasCountdown { get; } // 0x0000000180569E90-0x0000000180569EA0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1142
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<TreasureWheelBonusView> __9__49_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180563640-0x00000001805636B0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _Wire_b__49_0(TreasureWheelBonusView a, TreasureWheelBonusView b); // 0x0000000180563010-0x0000000180563040
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass72_0 // TypeDefIndex: 1143
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Sprite sprite; // 0x18
		public GameObject go; // 0x20
		public float a0; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass72_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyBackground_b__0(float v); // 0x0000000180563210-0x0000000180563230
		internal void _ApplyBackground_b__1(); // 0x0000000180563230-0x00000001805633F0
		internal void _ApplyBackground_b__2(float v); // 0x0000000180563210-0x0000000180563230
		internal void _ApplyBackground_b__3(); // 0x00000001805633F0-0x0000000180563430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass73_0 // TypeDefIndex: 1144
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Color from; // 0x18
		public Color target; // 0x28

		// Constructors
		public __c__DisplayClass73_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplySolid_b__0(float v); // 0x0000000180563430-0x0000000180563580
		internal void _ApplySolid_b__1(); // 0x0000000180563580-0x0000000180563640
	}

	// Constructors
	public WheelHubView(); // 0x0000000180569DD0-0x0000000180569E90
	static WheelHubView(); // 0x0000000180569C20-0x0000000180569DD0

	// Methods
	public void Wire(Transform root); // 0x0000000180569010-0x0000000180569C20
	public void Apply(WheelBoardVM vm); // 0x0000000180565480-0x0000000180565910
	public void Refresh(WheelBoardVM vm); // 0x0000000180567A50-0x0000000180567B50
	private void ApplyCost(WheelBoardVM vm); // 0x0000000180564580-0x0000000180564820
	private void ApplyWallet(WheelBoardVM vm); // 0x0000000180565260-0x0000000180565480
	private void ApplyFreeSpins(WheelBoardVM vm); // 0x0000000180564900-0x0000000180564A30
	private void WirePity(); // 0x0000000180568E50-0x0000000180569010
	private void BuildPityGroup(); // 0x0000000180566E60-0x0000000180567340
	private static GameObject NewNode(string nodeName, Transform parent, Vector2 pos, Vector2 size); // 0x0000000180567640-0x0000000180567880
	private void ApplyPity(WheelBoardVM vm); // 0x0000000180564B10-0x0000000180564F20
	private static string RarityLabel(string rarity); // 0x00000001805679E0-0x0000000180567A50
	private void WireInfo(); // 0x0000000180568B80-0x0000000180568E50
	private void BuildInfoButton(); // 0x0000000180565910-0x0000000180565CE0
	private void BuildInfoPopup(); // 0x0000000180565CE0-0x0000000180566E60
	public void ShowInfo(WheelBoardVM vm); // 0x0000000180568410-0x0000000180568780
	public void HideInfo(); // 0x00000001805674D0-0x0000000180567550
	public void ScrollInfoToTop(); // 0x0000000180567C60-0x0000000180567DA0
	private static UnityEngine.UI.Text NewText(GameObject go, int size, TextAnchor align, Color color); // 0x0000000180567880-0x00000001805679E0
	private void ApplyCountdown(WheelBoardVM vm); // 0x0000000180564820-0x0000000180564900
	private void ApplyBonuses(TreasureWheelBonusDTO[] data); // 0x00000001805643F0-0x0000000180564580
	public void SetBonusHandler(Action<TreasureWheelBonusView> handler); // 0x0000000180568120-0x00000001805681A0
	public bool TickCountdown(float unscaledDt); // 0x0000000180568A50-0x0000000180568B80
	private void RenderCountdown(); // 0x0000000180567B50-0x0000000180567C60
	public void ApplyBackground(WheelKind kind, bool crossFade); // 0x0000000180563E60-0x00000001805643F0
	private void ApplySolid(Color target, bool crossFade); // 0x0000000180564F20-0x0000000180565260
	private void SwapBackground(Sprite sprite); // 0x0000000180568950-0x0000000180568A50
	private float CurrentAlpha(); // 0x0000000180567340-0x0000000180567400
	private void SetAlpha(float a); // 0x0000000180567FE0-0x0000000180568120
	public void StopBackgroundFx(); // 0x0000000180568780-0x0000000180568950
	public void SetSpinInteractable(bool on); // 0x00000001805682A0-0x0000000180568350
	private static void SetText(UnityEngine.UI.Text t, string value); // 0x0000000180568350-0x0000000180568410
	private static void SetOptionalText(UnityEngine.UI.Text t, string value, Color color); // 0x00000001805681A0-0x00000001805682A0
	private static void SetActive(Button b, bool on); // 0x0000000180567F50-0x0000000180567FE0
	private static void ApplyIcon(Image target, Sprite sprite, bool show); // 0x0000000180564A30-0x0000000180564B10
	private T Find<T>(string nodeName)
		where T : Component;
	private static T FindIn<T>(Transform root, string nodeName)
		where T : Component;
	private Transform FindTransform(string nodeName); // 0x0000000180567400-0x00000001805674D0
	private static bool IsSkipped(string nodeName); // 0x0000000180567550-0x0000000180567640
	private static Transform Search(Transform node, string nodeName); // 0x0000000180567DA0-0x0000000180567F50
}

