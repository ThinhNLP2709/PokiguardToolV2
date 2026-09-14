/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WheelPieceTooltip : MonoBehaviour // TypeDefIndex: 1562
{
	// Fields
	public const string HIT_NODE = "hit"; // Metadata: 0x005F11F0
	public const string FLAG_KEY = "wheel.tooltip"; // Metadata: 0x005F11F4
	private const string CFG_KEY = "wheeltip"; // Metadata: 0x005F1202
	private const float OUTER_BAND = 0.6f; // Metadata: 0x005F120B
	private const float ANGLE_SAFE = 0.92f; // Metadata: 0x005F120F
	private WheelSlotVM _slot; // 0x20
	private Sprite _icon; // 0x28
	private Func<bool> _blocked; // 0x30
	private RectTransform _hit; // 0x38
	private Image _hitImage; // 0x40
	private Button _button; // 0x48

	// Properties
	public WheelSlotVM Slot { get; } // 0x00000001802A8720-0x00000001802A8730 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1563
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPressFx_b__0(); // 0x0000000180855B90-0x0000000180855D10
	}

	// Constructors
	public WheelPieceTooltip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static WheelPieceTooltip Bind(Transform holder, WheelSlotVM slot, Sprite icon, Func<bool> blocked, float pieceAngleDeg = 0f /* Metadata: 0x005F11EC */); // 0x0000000180853040-0x0000000180853360
	private void EnsureHitArea(float pieceAngleDeg); // 0x0000000180853360-0x00000001808540C0
	private void ApplyHitRect(RectTransform holder, float pieceAngleDeg); // 0x00000001808540C0-0x00000001808545E0
	private static float DeriveAngle(RectTransform holder); // 0x00000001808545E0-0x00000001808547E0
	private void OnTap(); // 0x00000001808547E0-0x0000000180854910
	private void PlayPressFx(); // 0x0000000180854910-0x0000000180854BE0
	private void OnDisable(); // 0x0000000180854BE0-0x0000000180854D20
	private string Title(); // 0x0000000180854D20-0x0000000180854DF0
	private string Body(); // 0x0000000180854DF0-0x0000000180855080
	private string HeadLine(); // 0x0000000180855080-0x00000001808552C0
	private string TypeLine(); // 0x00000001808552C0-0x00000001808556F0
	private List<RewardDisplayHelper.Entry> Entries(); // 0x00000001808556F0-0x0000000180855AF0
	private static string Str(string prop, string fallback); // 0x0000000180855AF0-0x0000000180855B90
}

