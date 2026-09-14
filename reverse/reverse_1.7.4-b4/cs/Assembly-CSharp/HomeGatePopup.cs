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
public class HomeGatePopup : MonoBehaviour // TypeDefIndex: 970
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
	public bool IsOpen { get; } // 0x00000001805E46D0-0x00000001805E46E0 

	// Constructors
	public HomeGatePopup(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001805E46E0-0x00000001805E4910
	private void OnDestroy(); // 0x00000001805E4910-0x00000001805E4AA0
	public void Open(); // 0x00000001805E4AA0-0x00000001805E4C30
	public void Close(); // 0x00000001805E4C30-0x00000001805E4D10
	public void Toggle(); // 0x00000001805E4D10-0x00000001805E4EC0
	public void ForceHide(); // 0x00000001805E4EC0-0x00000001805E5200
	[CompilerGenerated]
	private void _Close_b__10_0(); // 0x00000001805E5200-0x00000001805E5340
}

