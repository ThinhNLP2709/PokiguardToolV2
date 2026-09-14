/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VipBadgeFollower : MonoBehaviour // TypeDefIndex: 1464
{
	// Fields
	private VipBadge _badge; // 0x20
	private UnityEngine.UI.Text _label; // 0x28
	private TMP_Text _tmp; // 0x30
	private string _lastText; // 0x38
	private float _lastFontSize; // 0x40
	private float _lastWidth; // 0x44

	// Constructors
	public VipBadgeFollower(); // 0x00000001807FA470-0x00000001807FA4D0

	// Methods
	public void Bind(VipBadge badge, Component label); // 0x00000001807F9BE0-0x00000001807F9FB0
	private void LateUpdate(); // 0x00000001807F9FB0-0x00000001807FA470
}

