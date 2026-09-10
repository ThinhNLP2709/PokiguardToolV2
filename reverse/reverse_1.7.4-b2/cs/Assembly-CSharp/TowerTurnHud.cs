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

[DisallowMultipleComponent]
public class TowerTurnHud : MonoBehaviour // TypeDefIndex: 999
{
	// Fields
	public const string RES_PATH = "UI/TowerTurnHud"; // Metadata: 0x0068C00E
	public const float WIDTH = 80f; // Metadata: 0x0068C01E
	public const float HEIGHT = 40f; // Metadata: 0x0068C022
	public const float MARGIN_RIGHT = 44f; // Metadata: 0x0068C026
	public const float MARGIN_TOP = 32f; // Metadata: 0x0068C02A
	public const float FX_MARGIN = 6f; // Metadata: 0x0068C02E
	private const float BOUNCE = 1.1f; // Metadata: 0x0068C032
	private const float SHAKE_DEG = 5f; // Metadata: 0x0068C036
	private const int DANGER_TURNS = 3; // Metadata: 0x0068C03A
	[Header("Node (builder n\u1ED1i s\u1EB5n)")]
	public RectTransform body; // 0x20
	public Image imgBg; // 0x28
	public UnityEngine.UI.Text txtLabel; // 0x30
	public UnityEngine.UI.Text txtTurns; // 0x38
	private readonly List<int> _tweens; // 0x40
	private int _lastLeft; // 0x48
	private int _lastLimit; // 0x4C
	private bool _danger; // 0x50
	private Color _normalColor; // 0x54
	private static readonly Color DangerColor; // 0x00
	private int _blinkId; // 0x64

	// Constructors
	public TowerTurnHud(); // 0x00000001804F4F50-0x00000001804F4FE0
	static TowerTurnHud(); // 0x00000001804F4F10-0x00000001804F4F50

	// Methods
	private void Awake(); // 0x00000001804F3820-0x00000001804F3A70
	private UnityEngine.UI.Text FindText(string n); // 0x00000001804F3F30-0x00000001804F4040
	public void ApplyLayout(); // 0x00000001804F34F0-0x00000001804F3820
	public void SetTurns(int left, int limit); // 0x00000001804F41D0-0x00000001804F4A00
	private void Bounce(); // 0x00000001804F3BF0-0x00000001804F3DE0
	private void BlinkDanger(); // 0x00000001804F3A70-0x00000001804F3BF0
	private void CancelBlink(); // 0x00000001804F3DE0-0x00000001804F3E70
	public void ShakeOut(); // 0x00000001804F4A00-0x00000001804F4BA0
	private void Track(int id); // 0x00000001804F4BA0-0x00000001804F4C40
	private void CancelFx(); // 0x00000001804F3E70-0x00000001804F3F30
	private void OnDisable(); // 0x00000001804F4050-0x00000001804F41D0
	private void OnDestroy(); // 0x00000001804F4040-0x00000001804F4050
	[CompilerGenerated]
	private void _Bounce_b__23_0(); // 0x00000001804F4D30-0x00000001804F4E70
	[CompilerGenerated]
	private void _BlinkDanger_b__25_0(float a); // 0x00000001804F4C40-0x00000001804F4D30
	[CompilerGenerated]
	private void _ShakeOut_b__27_0(); // 0x00000001804F4E70-0x00000001804F4F10
}

