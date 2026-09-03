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

[DisallowMultipleComponent]
public class WheelTabSwitcher : MonoBehaviour // TypeDefIndex: 962
{
	// Fields
	[Tooltip("Tab hi\u1EC7n khi panel v\u1EEBa m\u1EDF (tr\u1EEB khi PendingKind y\u00EAu c\u1EA7u kh\u00E1c).")]
	public WheelKind current; // 0x20
	public Button tabWheel; // 0x28
	public Button tabGalaxy; // 0x30
	public Button tabTreasure; // 0x38
	[Header("Hi\u1EC7u \u1EE9ng chuy\u1EC3n tab")]
	[Tooltip("Th\u1EDDi l\u01B0\u1EE3ng n\u1ED9i dung tab m\u1EDBi tr\u01B0\u1EE3t v\u00E0o + hi\u1EC7n r\u00F5 (gi\u00E2y TH\u1EACT). 0 = t\u1EAFt hi\u1EC7u \u1EE9ng.")]
	public float transitionTime; // 0x40
	[Range(0f, 0.5f)]
	[Tooltip("Qu\u00E3ng tr\u01B0\u1EE3t ngang = t\u1EC9 l\u1EC7 n\u00E0y \u00D7 b\u1EC1 r\u1ED9ng khung CHA c\u1EE7a node \u0111\u01B0\u1EE3c d\u1ECBch.")]
	public float slideRatio; // 0x44
	[Tooltip("B\u1EC1 r\u1ED9ng h\u1EC7 to\u1EA1 \u0111\u1ED9 m\u00E0 builder \u0110O v\u1ECB tr\u00ED d\u1EA3i tab (bundle Poky n\u00E0o c\u0169ng 1300).")]
	public float pokyReferenceWidth; // 0x48
	public static WheelKind PendingKind; // 0x00
	private static readonly Color InactiveLabel; // 0x04
	private bool _wired; // 0x4C
	private RectTransform _rt; // 0x50
	private RectTransform _rootRect; // 0x58
	private Vector2 _designPos; // 0x60
	private Vector3 _designScale; // 0x68
	private float _lastCanvasW; // 0x74
	private readonly List<EnterFx> _fx; // 0x78

	// Properties
	private ManagerWheelDay Host { get; } // 0x0000000180480950-0x0000000180480990 

	// Nested types
	private struct EnterFx // TypeDefIndex: 963
	{
		// Fields
		public RectTransform rt; // 0x00
		public Vector2 basePos; // 0x08
		public CanvasGroup cg; // 0x10
		public float baseAlpha; // 0x18
		public int moveId; // 0x1C
		public int fadeId; // 0x20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 964
	{
		// Fields
		public WheelTabSwitcher __4__this; // 0x10
		public WheelKind kind; // 0x18

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Wire_b__0(); // 0x0000000180479B00-0x0000000180479C20
	}

	// Constructors
	public WheelTabSwitcher(); // 0x0000000180480890-0x0000000180480950
	static WheelTabSwitcher(); // 0x0000000180480830-0x0000000180480890

	// Methods
	public static WheelKind ConsumePending(); // 0x000000018047F0A0-0x000000018047F100
	private void Awake(); // 0x000000018047F090-0x000000018047F0A0
	private void OnEnable(); // 0x000000018047F9C0-0x000000018047FAC0
	private void OnDisable(); // 0x000000018047F9B0-0x000000018047F9C0
	private void LateUpdate(); // 0x000000018047F7F0-0x000000018047F800
	private void EnsureWired(); // 0x000000018047F100-0x000000018047F3A0
	private Button Find(string nodeName); // 0x000000018047F3A0-0x000000018047F450
	private void Wire(Button b, WheelKind kind); // 0x0000000180480700-0x0000000180480830
	private void Switch(WheelKind target); // 0x00000001804805F0-0x0000000180480700
	public void Show(WheelKind target); // 0x0000000180480070-0x0000000180480120
	public void SetActiveTab(WheelKind kind, bool animate); // 0x000000018047FFE0-0x0000000180480070
	private void ApplyFlags(); // 0x000000018047EF10-0x000000018047F000
	private static void GateIfNeeded(Button tab, string flagKey); // 0x000000018047F700-0x000000018047F7F0
	private void FitToPokyFrame(); // 0x000000018047F450-0x000000018047F700
	private RectTransform MotionNode(); // 0x000000018047F800-0x000000018047F9B0
	private void PlayEnterFx(float dirX); // 0x000000018047FAC0-0x000000018047FFE0
	private void StopFx(); // 0x0000000180480120-0x00000001804803D0
	private void ApplyVisual(); // 0x000000018047F000-0x000000018047F090
	private static void Style(Button tab, bool selected); // 0x00000001804803D0-0x00000001804805F0
}

