/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerEvent : MonoBehaviour // TypeDefIndex: 1003
{
	// Fields
	public const string PANEL_KEY = "PanelEvent"; // Metadata: 0x0064D0A5
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
	public ManagerEvent(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018048F8C0-0x000000018048F940
	private void OnBackEventClicked(); // 0x000000018048FBD0-0x000000018048FCE0
	private void OnPetClicked(); // 0x000000018048FD60-0x000000018048FDE0
	private void OnBackPetClicked(); // 0x000000018048FCE0-0x000000018048FD60
	private void OnAvtClicked(); // 0x000000018048F9E0-0x000000018048FB50
	private void OnBackAvtClicked(); // 0x000000018048FB50-0x000000018048FBD0
	public void OpenEventPanel(); // 0x000000018048FDE0-0x0000000180490270
	private static void Bind(Button b, UnityAction fn); // 0x000000018048F940-0x000000018048F9E0
}

