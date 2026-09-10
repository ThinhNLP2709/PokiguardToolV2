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

public class QuangTruongWeather : MonoBehaviour // TypeDefIndex: 1751
{
	// Fields
	[Header("B\u1EADt/t\u1EAFt")]
	[Tooltip("B\u1ECF tick = t\u1EAFt h\u1EB3n th\u1EDDi ti\u1EBFt (kh\u00F4ng sinh h\u1EA1t, kh\u00F4ng ch\u1EA1y Update).")]
	public bool weatherEnabled; // 0x20
	[Header("Ch\u1EBF \u0111\u1ED9")]
	public Mode mode; // 0x24
	[Tooltip("Th\u1EDDi ti\u1EBFt khi Manual")]
	public Weather manualWeather; // 0x28
	[Header("L\u1ECBch theo gi\u1EDD (0-23)")]
	[Tooltip("T\u1EEB gi\u1EDD n\u00E0y b\u1EAFt \u0111\u1EA7u TUY\u1EBET (m\u1EB7c \u0111\u1ECBnh 5h)")]
	public int snowStartHour; // 0x2C
	[Tooltip("T\u1EEB gi\u1EDD n\u00E0y b\u1EAFt \u0111\u1EA7u N\u1EAENG (m\u1EB7c \u0111\u1ECBnh 8h)")]
	public int sunStartHour; // 0x30
	[Tooltip("T\u1EEB gi\u1EDD n\u00E0y b\u1EAFt \u0111\u1EA7u M\u01AFA (m\u1EB7c \u0111\u1ECBnh 18h)")]
	public int rainStartHour; // 0x34
	[Header("S\u1ED1 h\u1EA1t")]
	public int rainCount; // 0x38
	public int snowCount; // 0x3C
	[Header("Tint n\u1EAFng")]
	[Range(0f, 0.4f)]
	[Tooltip("\u0110\u1ED9 \u0111\u1EADm \u00E1nh n\u1EAFng \u1EA5m ban ng\u00E0y (0 = t\u1EAFt)")]
	public float sunTintStrength; // 0x40
	public float tintFadeTime; // 0x44
	[Header("V\u1ECB tr\u00ED render trong hub Canvas")]
	[Tooltip("Ch\u00E8n hi\u1EC7u \u1EE9ng NGAY TR\u00CAN object n\u00E0y (n\u1EC1n \'Panel\'). M\u1ECDi UI/panel sau n\u00F3 s\u1EBD \u0111\u00E8 l\u00EAn.")]
	public string insertAfterChildName; // 0x48
	private RectTransform _hubRect; // 0x50
	private RectTransform _dropRoot; // 0x58
	private Canvas _hubCanvas; // 0x60
	private Canvas _dropCanvas; // 0x68
	private bool _wasVisible; // 0x70
	private Image _tint; // 0x78
	private Sprite _dotSprite; // 0x80
	private Sprite _lineSprite; // 0x88
	private Color _targetTint; // 0x90
	private float _hourTimer; // 0xA0
	private Weather _active; // 0xA4
	private readonly List<Drop> _drops; // 0xA8
	private static Sprite _cachedDot; // 0x00
	private static Sprite _cachedLine; // 0x08

	// Nested types
	public enum Weather // TypeDefIndex: 1752
	{
		None = 0,
		Rain = 1,
		Snow = 2,
		Sun = 3
	}

	public enum Mode // TypeDefIndex: 1753
	{
		AutoByHour = 0,
		Manual = 1
	}

	private class Drop // TypeDefIndex: 1754
	{
		// Fields
		public RectTransform rt; // 0x10
		public float speed; // 0x18
		public float drift; // 0x1C
		public float phase; // 0x20
		public float sway; // 0x24
		public float baseX; // 0x28

		// Constructors
		public Drop(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	// Constructors
	public QuangTruongWeather(); // 0x000000018067FF80-0x0000000180680060

	// Methods
	private void Start(); // 0x000000018067F620-0x000000018067F700
	private void ShutdownWeather(); // 0x000000018067F390-0x000000018067F620
	public void SetWeatherEnabled(bool on); // 0x000000018067F180-0x000000018067F390
	private bool IsWeatherVisible(); // 0x000000018067E4D0-0x000000018067E5C0
	private void Update(); // 0x000000018067FB80-0x000000018067FF10
	public void Apply(); // 0x000000018067DE60-0x000000018067DF80
	private Weather WeatherForHour(int hour); // 0x000000018067FF10-0x000000018067FF80
	private static bool InRange(int hour, int start, int end); // 0x000000018067E420-0x000000018067E4D0
	private bool BuildContainer(); // 0x000000018067DF80-0x000000018067E390
	private static void Stretch(RectTransform rt); // 0x000000018067FA80-0x000000018067FB80
	private void RebuildDrops(Weather w); // 0x000000018067EEA0-0x000000018067F180
	private Vector2 CanvasSize(); // 0x000000018067E390-0x000000018067E420
	private Drop MakeDrop(Weather w); // 0x000000018067E5C0-0x000000018067EA10
	private void StepDrops(); // 0x000000018067F700-0x000000018067FA80
	private Sprite MakeSprite(bool line); // 0x000000018067EA10-0x000000018067EEA0
}

