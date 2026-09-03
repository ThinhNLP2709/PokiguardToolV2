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
public class TowerTurnHud : MonoBehaviour // TypeDefIndex: 804
{
	// Fields
	public const string RES_PATH = "UI/TowerTurnHud"; // Metadata: 0x0064C938
	public const float WIDTH = 80f; // Metadata: 0x0064C948
	public const float HEIGHT = 40f; // Metadata: 0x0064C94C
	public const float MARGIN_RIGHT = 44f; // Metadata: 0x0064C950
	public const float MARGIN_TOP = 32f; // Metadata: 0x0064C954
	public const float FX_MARGIN = 6f; // Metadata: 0x0064C958
	private const float BOUNCE = 1.1f; // Metadata: 0x0064C95C
	private const float SHAKE_DEG = 5f; // Metadata: 0x0064C960
	private const int DANGER_TURNS = 3; // Metadata: 0x0064C964
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
	public TowerTurnHud(); // 0x0000000180433E40-0x0000000180433ED0
	static TowerTurnHud(); // 0x0000000180433E00-0x0000000180433E40

	// Methods
	private void Awake(); // 0x0000000180432750-0x00000001804329A0
	private UnityEngine.UI.Text FindText(string n); // 0x0000000180432E60-0x0000000180432F70
	public void ApplyLayout(); // 0x0000000180432420-0x0000000180432750
	public void SetTurns(int left, int limit); // 0x0000000180433100-0x00000001804338F0
	private void Bounce(); // 0x0000000180432B20-0x0000000180432D10
	private void BlinkDanger(); // 0x00000001804329A0-0x0000000180432B20
	private void CancelBlink(); // 0x0000000180432D10-0x0000000180432DA0
	public void ShakeOut(); // 0x00000001804338F0-0x0000000180433A90
	private void Track(int id); // 0x0000000180433A90-0x0000000180433B30
	private void CancelFx(); // 0x0000000180432DA0-0x0000000180432E60
	private void OnDisable(); // 0x0000000180432F80-0x0000000180433100
	private void OnDestroy(); // 0x0000000180432F70-0x0000000180432F80
	[CompilerGenerated]
	private void _Bounce_b__23_0(); // 0x0000000180433C20-0x0000000180433D60
	[CompilerGenerated]
	private void _BlinkDanger_b__25_0(float a); // 0x0000000180433B30-0x0000000180433C20
	[CompilerGenerated]
	private void _ShakeOut_b__27_0(); // 0x0000000180433D60-0x0000000180433E00
}

