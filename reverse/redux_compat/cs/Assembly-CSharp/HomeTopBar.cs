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
public class HomeTopBar : MonoBehaviour // TypeDefIndex: 627
{
	// Fields
	[Header("Ng\u01B0\u1EDDi ch\u01A1i")]
	public Image avatarImage; // 0x20
	public UnityEngine.UI.Text levelText; // 0x28
	public UnityEngine.UI.Text nameText; // 0x30
	public HomePressScale avatarPress; // 0x38
	[Header("T\u00E0i nguy\u00EAn")]
	public UnityEngine.UI.Text goldText; // 0x40
	public UnityEngine.UI.Text safiaText; // 0x48
	public UnityEngine.UI.Text energyText; // 0x50
	public UnityEngine.UI.Text energyCountdownText; // 0x58
	public Image energyBar; // 0x60
	public HomePressScale energyPlusPress; // 0x68
	private bool _energyRegistered; // 0x70
	private bool _hooked; // 0x71

	// Constructors
	public HomeTopBar(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001803B85E0-0x00000001803B8710
	private void OnEnable(); // 0x00000001803B8CE0-0x00000001803B8DA0
	private void OnDisable(); // 0x00000001803B8C80-0x00000001803B8CE0
	private void OnDestroy(); // 0x00000001803B8B10-0x00000001803B8C80
	public void Bind(UserDTO user); // 0x00000001803B8710-0x00000001803B8A00
	private void SetEnergy(int current, int max); // 0x00000001803B8DB0-0x00000001803B8EE0
	private void RegisterEnergy(); // 0x00000001803B8CE0-0x00000001803B8DA0
	private void UnregisterEnergy(); // 0x00000001803B8C80-0x00000001803B8CE0
	private void OnAvatarClicked(); // 0x00000001803B8A80-0x00000001803B8B10
	private void OnEnergyPlusClicked(); // 0x00000001803B8DA0-0x00000001803B8DB0
	public static string FormatNumber(long amount); // 0x00000001803B8A00-0x00000001803B8A80
}

