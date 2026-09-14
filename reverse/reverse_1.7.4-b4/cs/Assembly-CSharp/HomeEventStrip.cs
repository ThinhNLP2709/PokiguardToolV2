/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomeEventStrip : MonoBehaviour // TypeDefIndex: 968
{
	// Fields
	private const string PREF_EXPANDED = "HomeEventStripExpanded"; // Metadata: 0x005F0543
	private const float STAGGER_SEC = 0.06f; // Metadata: 0x005F055A
	private const float FLY_SEC = 0.28f; // Metadata: 0x005F055E
	[Tooltip("C\u00E1c \u00F4 s\u1EF1 ki\u1EC7n lu\u00F4n hi\u1EC7n \u2014 d\u00F9ng cho hi\u1EC7u \u1EE9ng bay v\u00E0o.")]
	public RectTransform[] items; // 0x20
	[Tooltip("Nh\u00F3m n\u00FAt ch\u1EC9 hi\u1EC7n khi b\u1EA5m M\u1EDF r\u1ED9ng.")]
	public GameObject[] extraItems; // 0x28
	[Tooltip("\u1EA2nh tr\u00EAn n\u00FAt M\u1EDF r\u1ED9ng/Thu g\u1ECDn (\u0111\u1ED5i sprite theo tr\u1EA1ng th\u00E1i).")]
	public Image expandIcon; // 0x30
	public Sprite spriteExpand; // 0x38
	public Sprite spriteCollapse; // 0x40
	private bool _expanded; // 0x48

	// Constructors
	public HomeEventStrip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001805E2C40-0x00000001805E2CA0
	private void OnDisable(); // 0x00000001805E2CA0-0x00000001805E2F00
	public void PlayEnter(); // 0x00000001805E2F00-0x00000001805E3210
	public void ToggleExpand(); // 0x00000001805E3210-0x00000001805E32B0
	private void ApplyExpanded(bool animate); // 0x00000001805E32B0-0x00000001805E35E0
}

