/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DotSkillManager : MonoBehaviour // TypeDefIndex: 1657
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
	public DotSkillManager(); // 0x00000001805C48B0-0x00000001805C4A90

	// Methods
	private void Start(); // 0x00000001805C45B0-0x00000001805C4720
	public void GenerateArrows(); // 0x00000001805C41A0-0x00000001805C43A0
	private void Update(); // 0x00000001805C4720-0x00000001805C48B0
	private void CheckArrow(string dir); // 0x00000001805C3D90-0x00000001805C3F10
	private void ResetCombo(); // 0x00000001805C44E0-0x00000001805C45B0
	public void OnButtonPress(string dir); // 0x00000001805C44D0-0x00000001805C44E0
	private string GetDirectionFromInput(); // 0x00000001805C43A0-0x00000001805C44D0
	private void ClearOldArrows(); // 0x00000001805C3F10-0x00000001805C41A0
}

