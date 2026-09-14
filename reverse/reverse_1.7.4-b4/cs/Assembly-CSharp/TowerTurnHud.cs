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

[DisallowMultipleComponent]
public class TowerTurnHud : MonoBehaviour // TypeDefIndex: 1371
{
	// Fields
	public const string RES_PATH = "UI/TowerTurnHud"; // Metadata: 0x005F0DCA
	public const float WIDTH = 80f; // Metadata: 0x005F0DDA
	public const float HEIGHT = 40f; // Metadata: 0x005F0DDE
	public const float MARGIN_RIGHT = 44f; // Metadata: 0x005F0DE2
	public const float MARGIN_TOP = 32f; // Metadata: 0x005F0DE6
	public const float FX_MARGIN = 6f; // Metadata: 0x005F0DEA
	private const float BOUNCE = 1.1f; // Metadata: 0x005F0DEE
	private const float SHAKE_DEG = 5f; // Metadata: 0x005F0DF2
	private const int DANGER_TURNS = 3; // Metadata: 0x005F0DF6
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
	public TowerTurnHud(); // 0x000000018077E900-0x000000018077EA00
	static TowerTurnHud(); // 0x000000018077EA00-0x000000018077EA50

	// Methods
	private void Awake(); // 0x000000018077C640-0x000000018077CD20
	private UnityEngine.UI.Text FindText(string n); // 0x000000018077CD20-0x000000018077D020
	public void ApplyLayout(); // 0x000000018077D020-0x000000018077D590
	public void SetTurns(int left, int limit); // 0x000000018077D590-0x000000018077DC00
	private void Bounce(); // 0x000000018077DC00-0x000000018077DEE0
	private void BlinkDanger(); // 0x000000018077DEE0-0x000000018077E0F0
	private void CancelBlink(); // 0x000000018077E0F0-0x000000018077E1E0
	public void ShakeOut(); // 0x000000018077E1E0-0x000000018077E400
	private void Track(int id); // 0x000000018077E400-0x000000018077E4A0
	private void CancelFx(); // 0x000000018077E4A0-0x000000018077E600
	private void OnDisable(); // 0x000000018077E600-0x000000018077E8F0
	private void OnDestroy(); // 0x000000018077E8F0-0x000000018077E900
	[CompilerGenerated]
	private void _Bounce_b__23_0(); // 0x000000018077EA50-0x000000018077EC80
	[CompilerGenerated]
	private void _BlinkDanger_b__25_0(float a); // 0x000000018077EC80-0x000000018077EE00
	[CompilerGenerated]
	private void _ShakeOut_b__27_0(); // 0x000000018077EE00-0x000000018077EFB0
}

