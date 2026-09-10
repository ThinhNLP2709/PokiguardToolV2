/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class HomeTopBar : MonoBehaviour // TypeDefIndex: 823
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
	public HomeTopBar(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180499C30-0x0000000180499D60
	private void OnEnable(); // 0x000000018049A380-0x000000018049A450
	private void OnDisable(); // 0x000000018049A320-0x000000018049A380
	private void OnDestroy(); // 0x000000018049A170-0x000000018049A320
	public void Bind(UserDTO user); // 0x0000000180499D60-0x000000018049A080
	private void SetEnergy(int current, int max); // 0x000000018049A460-0x000000018049A590
	private void RegisterEnergy(); // 0x000000018049A380-0x000000018049A450
	private void UnregisterEnergy(); // 0x000000018049A320-0x000000018049A380
	private void OnAvatarClicked(); // 0x000000018049A100-0x000000018049A170
	private void OnEnergyPlusClicked(); // 0x000000018049A450-0x000000018049A460
	public static string FormatNumber(long amount); // 0x000000018049A080-0x000000018049A100
}

