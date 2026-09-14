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

[DisallowMultipleComponent]
public class TowerTurnHud : MonoBehaviour // TypeDefIndex: 1369
{
	// Fields
	public const string RES_PATH = "UI/TowerTurnHud"; // Metadata: 0x005EF9FD
	public const float WIDTH = 80f; // Metadata: 0x005EFA0D
	public const float HEIGHT = 40f; // Metadata: 0x005EFA11
	public const float MARGIN_RIGHT = 44f; // Metadata: 0x005EFA15
	public const float MARGIN_TOP = 32f; // Metadata: 0x005EFA19
	public const float FX_MARGIN = 6f; // Metadata: 0x005EFA1D
	private const float BOUNCE = 1.1f; // Metadata: 0x005EFA21
	private const float SHAKE_DEG = 5f; // Metadata: 0x005EFA25
	private const int DANGER_TURNS = 3; // Metadata: 0x005EFA29
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
	public TowerTurnHud(); // 0x000000018077C9B0-0x000000018077CAB0
	static TowerTurnHud(); // 0x000000018077CAB0-0x000000018077CB00

	// Methods
	private void Awake(); // 0x000000018077A6F0-0x000000018077ADD0
	private UnityEngine.UI.Text FindText(string n); // 0x000000018077ADD0-0x000000018077B0D0
	public void ApplyLayout(); // 0x000000018077B0D0-0x000000018077B640
	public void SetTurns(int left, int limit); // 0x000000018077B640-0x000000018077BCB0
	private void Bounce(); // 0x000000018077BCB0-0x000000018077BF90
	private void BlinkDanger(); // 0x000000018077BF90-0x000000018077C1A0
	private void CancelBlink(); // 0x000000018077C1A0-0x000000018077C290
	public void ShakeOut(); // 0x000000018077C290-0x000000018077C4B0
	private void Track(int id); // 0x000000018077C4B0-0x000000018077C550
	private void CancelFx(); // 0x000000018077C550-0x000000018077C6B0
	private void OnDisable(); // 0x000000018077C6B0-0x000000018077C9A0
	private void OnDestroy(); // 0x000000018077C9A0-0x000000018077C9B0
	[CompilerGenerated]
	private void _Bounce_b__23_0(); // 0x000000018077CB00-0x000000018077CD30
	[CompilerGenerated]
	private void _BlinkDanger_b__25_0(float a); // 0x000000018077CD30-0x000000018077CEB0
	[CompilerGenerated]
	private void _ShakeOut_b__27_0(); // 0x000000018077CEB0-0x000000018077D060
}

