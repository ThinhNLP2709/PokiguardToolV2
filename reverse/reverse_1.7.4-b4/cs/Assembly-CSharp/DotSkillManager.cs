/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class DotSkillManager : MonoBehaviour // TypeDefIndex: 2303
{
	// Fields
	public Transform parentPanel; // 0x20
	public GameObject arrowPrefab; // 0x28
	public int arrowCount; // 0x30
	public int correctCount; // 0x34
	private List<Image> currentArrows; // 0x38
	private string[] directions; // 0x40
	private int currentIndex; // 0x48
	private Dictionary<string, Sprite> blueArrows; // 0x50
	private Dictionary<string, Sprite> purpleArrows; // 0x58

	// Constructors
	public DotSkillManager(); // 0x0000000180B13C20-0x0000000180B13F60

	// Methods
	private void Start(); // 0x0000000180B12EA0-0x0000000180B13040
	public void GenerateArrows(); // 0x0000000180B13040-0x0000000180B13280
	private void Update(); // 0x0000000180B13280-0x0000000180B13470
	private void CheckArrow(string dir); // 0x0000000180B13470-0x0000000180B13680
	private void ResetCombo(); // 0x0000000180B13680-0x0000000180B13780
	public void OnButtonPress(string dir); // 0x0000000180B13780-0x0000000180B13790
	private string GetDirectionFromInput(); // 0x0000000180B13790-0x0000000180B138E0
	private void ClearOldArrows(); // 0x0000000180B138E0-0x0000000180B13C20
}

