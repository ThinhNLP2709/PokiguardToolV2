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

public class WheelPieceTooltip : MonoBehaviour // TypeDefIndex: 1155
{
	// Fields
	public const string HIT_NODE = "hit"; // Metadata: 0x0068C623
	public const string FLAG_KEY = "wheel.tooltip"; // Metadata: 0x0068C627
	private const string CFG_KEY = "wheeltip"; // Metadata: 0x0068C635
	private const float OUTER_BAND = 0.6f; // Metadata: 0x0068C63E
	private const float ANGLE_SAFE = 0.92f; // Metadata: 0x0068C642
	private WheelSlotVM _slot; // 0x20
	private Sprite _icon; // 0x28
	private Func<bool> _blocked; // 0x30
	private RectTransform _hit; // 0x38
	private Image _hitImage; // 0x40
	private Button _button; // 0x48

	// Properties
	public WheelSlotVM Slot { get; } // 0x00000001802FF660-0x00000001802FF670 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1156
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayPressFx_b__0(); // 0x0000000180563040-0x00000001805630F0
	}

	// Constructors
	public WheelPieceTooltip(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static WheelPieceTooltip Bind(Transform holder, WheelSlotVM slot, Sprite icon, Func<bool> blocked, float pieceAngleDeg = 0f /* Metadata: 0x0068C61F */); // 0x000000018056CDA0-0x000000018056CEF0
	private void EnsureHitArea(float pieceAngleDeg); // 0x000000018056D330-0x000000018056D940
	private void ApplyHitRect(RectTransform holder, float pieceAngleDeg); // 0x000000018056C940-0x000000018056CDA0
	private static float DeriveAngle(RectTransform holder); // 0x000000018056D260-0x000000018056D330
	private void OnTap(); // 0x000000018056DE70-0x000000018056DF90
	private void PlayPressFx(); // 0x000000018056DF90-0x000000018056E190
	private void OnDisable(); // 0x000000018056DDC0-0x000000018056DE70
	private string Title(); // 0x000000018056E230-0x000000018056E300
	private string Body(); // 0x000000018056CEF0-0x000000018056D260
	private string HeadLine(); // 0x000000018056DC70-0x000000018056DDC0
	private string TypeLine(); // 0x000000018056E300-0x000000018056E5B0
	private List<RewardDisplayHelper.Entry> Entries(); // 0x000000018056D940-0x000000018056DC70
	private static string Str(string prop, string fallback); // 0x000000018056E190-0x000000018056E230
}

