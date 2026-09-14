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

public class WheelPieceTooltip : MonoBehaviour // TypeDefIndex: 1560
{
	// Fields
	public const string HIT_NODE = "hit"; // Metadata: 0x005EFE23
	public const string FLAG_KEY = "wheel.tooltip"; // Metadata: 0x005EFE27
	private const string CFG_KEY = "wheeltip"; // Metadata: 0x005EFE35
	private const float OUTER_BAND = 0.6f; // Metadata: 0x005EFE3E
	private const float ANGLE_SAFE = 0.92f; // Metadata: 0x005EFE42
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
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1561
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPressFx_b__0(); // 0x0000000180853900-0x0000000180853A80
	}

	// Constructors
	public WheelPieceTooltip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static WheelPieceTooltip Bind(Transform holder, WheelSlotVM slot, Sprite icon, Func<bool> blocked, float pieceAngleDeg = 0f /* Metadata: 0x005EFE1F */); // 0x0000000180850DB0-0x00000001808510D0
	private void EnsureHitArea(float pieceAngleDeg); // 0x00000001808510D0-0x0000000180851E30
	private void ApplyHitRect(RectTransform holder, float pieceAngleDeg); // 0x0000000180851E30-0x0000000180852350
	private static float DeriveAngle(RectTransform holder); // 0x0000000180852350-0x0000000180852550
	private void OnTap(); // 0x0000000180852550-0x0000000180852680
	private void PlayPressFx(); // 0x0000000180852680-0x0000000180852950
	private void OnDisable(); // 0x0000000180852950-0x0000000180852A90
	private string Title(); // 0x0000000180852A90-0x0000000180852B60
	private string Body(); // 0x0000000180852B60-0x0000000180852DF0
	private string HeadLine(); // 0x0000000180852DF0-0x0000000180853030
	private string TypeLine(); // 0x0000000180853030-0x0000000180853460
	private List<RewardDisplayHelper.Entry> Entries(); // 0x0000000180853460-0x0000000180853860
	private static string Str(string prop, string fallback); // 0x0000000180853860-0x0000000180853900
}

