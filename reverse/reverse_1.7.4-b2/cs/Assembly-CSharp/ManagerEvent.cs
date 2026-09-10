/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerEvent : MonoBehaviour // TypeDefIndex: 1201
{
	// Fields
	public const string PANEL_KEY = "PanelEvent"; // Metadata: 0x0068CBFC
	[Header("Panels")]
	public GameObject panelEvent; // 0x20
	public GameObject panelResult; // 0x28
	public GameObject panelPet; // 0x30
	public GameObject panelAvt; // 0x38
	[Header("Navigation Buttons - PanelEvent")]
	public Button btnBackEvent; // 0x40
	public Button btnPet; // 0x48
	public Button btnAvt; // 0x50
	[Header("Navigation Buttons - Sub Panels")]
	public Button btnBackPet; // 0x58
	public Button btnBackAvt; // 0x60

	// Constructors
	public ManagerEvent(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180583A40-0x0000000180583AC0
	private void OnBackEventClicked(); // 0x0000000180583D50-0x0000000180583E60
	private void OnPetClicked(); // 0x0000000180583EE0-0x0000000180583F60
	private void OnBackPetClicked(); // 0x0000000180583E60-0x0000000180583EE0
	private void OnAvtClicked(); // 0x0000000180583B60-0x0000000180583CD0
	private void OnBackAvtClicked(); // 0x0000000180583CD0-0x0000000180583D50
	public void OpenEventPanel(); // 0x0000000180583F60-0x00000001805843F0
	private static void Bind(Button b, UnityAction fn); // 0x0000000180583AC0-0x0000000180583B60
}

