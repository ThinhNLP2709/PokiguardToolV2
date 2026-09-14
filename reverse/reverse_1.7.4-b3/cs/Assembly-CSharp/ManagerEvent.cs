/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerEvent : MonoBehaviour // TypeDefIndex: 1602
{
	// Fields
	public const string PANEL_KEY = "PanelEvent"; // Metadata: 0x005EFE97
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
	public ManagerEvent(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180881EE0-0x0000000180882020
	private void OnBackEventClicked(); // 0x0000000180882020-0x0000000180882220
	private void OnPetClicked(); // 0x0000000180882220-0x0000000180882360
	private void OnBackPetClicked(); // 0x0000000180882360-0x00000001808824A0
	private void OnAvtClicked(); // 0x00000001808824A0-0x0000000180882840
	private void OnBackAvtClicked(); // 0x0000000180882840-0x0000000180882980
	public void OpenEventPanel(); // 0x0000000180882980-0x0000000180882F20
	private static void Bind(Button b, UnityAction fn); // 0x0000000180882F20-0x0000000180883080
}

