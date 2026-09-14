/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PanelVongQuayManager : MonoBehaviour // TypeDefIndex: 2112
{
	// Fields
	public const string PANEL_KEY = "PanelVongQuay"; // Metadata: 0x005F198C
	[Header("Panels")]
	public GameObject panelVongQuay; // 0x20
	public GameObject panelKhamHT; // 0x28
	[Header("Buttons")]
	public Button btnEvent4; // 0x30
	public Button btnClosePanelVongQuay; // 0x38
	public Button btnOpenPanelHT; // 0x40
	public Button btnClosePanelKhamHT; // 0x48

	// Constructors
	public PanelVongQuayManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180A021F0-0x0000000180A027B0
	public void OpenPanelVongQuay(); // 0x0000000180A027B0-0x0000000180A028F0
	public void ClosePanelVongQuay(); // 0x0000000180A028F0-0x0000000180A02CC0
	private void OpenPanelKhamHT(); // 0x0000000180A02CC0-0x0000000180A02F60
	private void ClosePanelKhamHT(); // 0x0000000180A02F60-0x0000000180A031B0
	private void OnDestroy(); // 0x0000000180A031B0-0x0000000180A03680
}

