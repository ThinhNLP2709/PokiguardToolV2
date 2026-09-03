/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class HomeGatePopup : MonoBehaviour // TypeDefIndex: 605
{
	// Fields
	[Tooltip("Node popup (b\u1EADt/t\u1EAFt b\u1EB1ng UIAnim). B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
	public GameObject panel; // 0x20
	[Tooltip("L\u1EDBp ph\u1EE7 m\u1EDD ch\u1EB7n b\u1EA5m ra ngo\u00E0i. B\u1EA5m v\u00E0o n\u00F3 = \u0111\u00F3ng popup.")]
	public GameObject dim; // 0x28
	public CanvasGroup canvasGroup; // 0x30
	[Tooltip("N\u00FAt tr\u00EAn l\u1EDBp ph\u1EE7 m\u1EDD \u2014 wire \u1EDF Awake \u0111\u1EC3 b\u1EA5m ngo\u00E0i l\u00E0 \u0111\u00F3ng.")]
	public Button dimButton; // 0x38
	private bool _open; // 0x40

	// Properties
	public bool IsOpen { get; } // 0x00000001803B1170-0x00000001803B1180 

	// Constructors
	public HomeGatePopup(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001803B0B60-0x00000001803B0D10
	private void OnDestroy(); // 0x00000001803B0E90-0x00000001803B0F60
	public void Open(); // 0x00000001803B0F60-0x00000001803B1020
	public void Close(); // 0x00000001803B0D10-0x00000001803B0DD0
	public void Toggle(); // 0x00000001803B1020-0x00000001803B10F0
	public void ForceHide(); // 0x00000001803B0DD0-0x00000001803B0E90
	[CompilerGenerated]
	private void _Close_b__10_0(); // 0x00000001803B10F0-0x00000001803B1170
}

