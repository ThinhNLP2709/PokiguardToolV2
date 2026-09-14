/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DotSkillManager : MonoBehaviour // TypeDefIndex: 2296
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
	public DotSkillManager(); // 0x0000000180AE9B00-0x0000000180AE9E40

	// Methods
	private void Start(); // 0x0000000180AE8D80-0x0000000180AE8F20
	public void GenerateArrows(); // 0x0000000180AE8F20-0x0000000180AE9160
	private void Update(); // 0x0000000180AE9160-0x0000000180AE9350
	private void CheckArrow(string dir); // 0x0000000180AE9350-0x0000000180AE9560
	private void ResetCombo(); // 0x0000000180AE9560-0x0000000180AE9660
	public void OnButtonPress(string dir); // 0x0000000180AE9660-0x0000000180AE9670
	private string GetDirectionFromInput(); // 0x0000000180AE9670-0x0000000180AE97C0
	private void ClearOldArrows(); // 0x0000000180AE97C0-0x0000000180AE9B00
}

