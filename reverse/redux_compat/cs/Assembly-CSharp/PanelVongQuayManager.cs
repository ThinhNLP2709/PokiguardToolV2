/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PanelVongQuayManager : MonoBehaviour // TypeDefIndex: 1498
{
	// Fields
	public const string PANEL_KEY = "PanelVongQuay"; // Metadata: 0x0064D71C
	[Header("Panels")]
	public GameObject panelVongQuay; // 0x20
	public GameObject panelKhamHT; // 0x28
	[Header("Buttons")]
	public Button btnEvent4; // 0x30
	public Button btnClosePanelVongQuay; // 0x38
	public Button btnOpenPanelHT; // 0x40
	public Button btnClosePanelKhamHT; // 0x48

	// Constructors
	public PanelVongQuayManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018056E3F0-0x000000018056E660
	public void OpenPanelVongQuay(); // 0x000000018056EC40-0x000000018056ECC0
	public void ClosePanelVongQuay(); // 0x000000018056E750-0x000000018056E8F0
	private void OpenPanelKhamHT(); // 0x000000018056EB00-0x000000018056EC40
	private void ClosePanelKhamHT(); // 0x000000018056E660-0x000000018056E750
	private void OnDestroy(); // 0x000000018056E8F0-0x000000018056EB00
}

