/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PanelVongQuayManager : MonoBehaviour // TypeDefIndex: 1750
{
	// Fields
	public const string PANEL_KEY = "PanelVongQuay"; // Metadata: 0x0068D770
	[Header("Panels")]
	public GameObject panelVongQuay; // 0x20
	public GameObject panelKhamHT; // 0x28
	[Header("Buttons")]
	public Button btnEvent4; // 0x30
	public Button btnClosePanelVongQuay; // 0x38
	public Button btnOpenPanelHT; // 0x40
	public Button btnClosePanelKhamHT; // 0x48

	// Constructors
	public PanelVongQuayManager(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180679140-0x00000001806793B0
	public void OpenPanelVongQuay(); // 0x0000000180679990-0x0000000180679A10
	public void ClosePanelVongQuay(); // 0x00000001806794A0-0x0000000180679640
	private void OpenPanelKhamHT(); // 0x0000000180679850-0x0000000180679990
	private void ClosePanelKhamHT(); // 0x00000001806793B0-0x00000001806794A0
	private void OnDestroy(); // 0x0000000180679640-0x0000000180679850
}

