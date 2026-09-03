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

public class WheelHubView // TypeDefIndex: 947
{
	// Fields
	public const string EXCLUDED_SUBTREE = "galaxyEmbed"; // Metadata: 0x0064CE5A
	private static readonly string[] SkipSubtrees; // 0x00
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
	public GameObject bonusStrip; // 0xB8
	public readonly List<TreasureWheelBonusView> bonuses; // 0xC0
	public Image wheelFlash; // 0xC8
	public RectTransform pointer; // 0xD0
	private Transform _root; // 0xD8
	private long _countdownLeft; // 0xE0
	private float _countdownFrac; // 0xE8
	private long _lastShownSecond; // 0xF0
	private int _bgFadeId; // 0xF8
	private int _solidFadeId; // 0xFC
	private Color _solidTarget; // 0x100

	// Properties
	public bool HasCountdown { get; } // 0x000000018047DC90-0x000000018047DCA0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 948
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<TreasureWheelBonusView> __9__36_0; // 0x08

		// Constructors
		static __c(); // 0x000000018047A0C0-0x000000018047A130
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _Wire_b__36_0(TreasureWheelBonusView a, TreasureWheelBonusView b); // 0x0000000180479AD0-0x0000000180479B00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 949
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Sprite sprite; // 0x18
		public GameObject go; // 0x20
		public float a0; // 0x28
		public Action<float> __9__2; // 0x30
		public Action __9__3; // 0x38

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyBackground_b__0(float v); // 0x0000000180479C20-0x0000000180479C40
		internal void _ApplyBackground_b__1(); // 0x0000000180479C40-0x0000000180479E00
		internal void _ApplyBackground_b__2(float v); // 0x0000000180479C20-0x0000000180479C40
		internal void _ApplyBackground_b__3(); // 0x0000000180479E00-0x0000000180479E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass48_0 // TypeDefIndex: 950
	{
		// Fields
		public WheelHubView __4__this; // 0x10
		public Color from; // 0x18
		public Color target; // 0x28

		// Constructors
		public __c__DisplayClass48_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplySolid_b__0(float v); // 0x0000000180479E40-0x0000000180479F90
		internal void _ApplySolid_b__1(); // 0x0000000180479F90-0x000000018047A050
	}

	// Constructors
	public WheelHubView(); // 0x000000018047DBD0-0x000000018047DC90
	static WheelHubView(); // 0x000000018047DA50-0x000000018047DBD0

	// Methods
	public void Wire(Transform root); // 0x000000018047CE50-0x000000018047DA50
	public void Apply(WheelBoardVM vm); // 0x000000018047BAF0-0x000000018047BF60
	public void Refresh(WheelBoardVM vm); // 0x000000018047C1E0-0x000000018047C2D0
	private void ApplyCost(WheelBoardVM vm); // 0x000000018047B000-0x000000018047B2A0
	private void ApplyWallet(WheelBoardVM vm); // 0x000000018047B8D0-0x000000018047BAF0
	private void ApplyFreeSpins(WheelBoardVM vm); // 0x000000018047B380-0x000000018047B4B0
	private void ApplyCountdown(WheelBoardVM vm); // 0x000000018047B2A0-0x000000018047B380
	private void ApplyBonuses(TreasureWheelBonusDTO[] data); // 0x000000018047AE70-0x000000018047B000
	public void SetBonusHandler(Action<TreasureWheelBonusView> handler); // 0x000000018047C760-0x000000018047C7E0
	public bool TickCountdown(float unscaledDt); // 0x000000018047CD20-0x000000018047CE50
	private void RenderCountdown(); // 0x000000018047C2D0-0x000000018047C3E0
	public void ApplyBackground(WheelKind kind, bool crossFade); // 0x000000018047A8E0-0x000000018047AE70
	private void ApplySolid(Color target, bool crossFade); // 0x000000018047B590-0x000000018047B8D0
	private void SwapBackground(Sprite sprite); // 0x000000018047CC20-0x000000018047CD20
	private float CurrentAlpha(); // 0x000000018047BF60-0x000000018047C020
	private void SetAlpha(float a); // 0x000000018047C620-0x000000018047C760
	public void StopBackgroundFx(); // 0x000000018047CA50-0x000000018047CC20
	public void SetSpinInteractable(bool on); // 0x000000018047C8E0-0x000000018047C990
	private static void SetText(UnityEngine.UI.Text t, string value); // 0x000000018047C990-0x000000018047CA50
	private static void SetOptionalText(UnityEngine.UI.Text t, string value, Color color); // 0x000000018047C7E0-0x000000018047C8E0
	private static void SetActive(Button b, bool on); // 0x000000018047C590-0x000000018047C620
	private static void ApplyIcon(Image target, Sprite sprite, bool show); // 0x000000018047B4B0-0x000000018047B590
	private T Find<T>(string nodeName)
		where T : Component;
	private static T FindIn<T>(Transform root, string nodeName)
		where T : Component;
	private Transform FindTransform(string nodeName); // 0x000000018047C020-0x000000018047C0F0
	private static bool IsSkipped(string nodeName); // 0x000000018047C0F0-0x000000018047C1E0
	private static Transform Search(Transform node, string nodeName); // 0x000000018047C3E0-0x000000018047C590
}

