/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class SkillLg : MonoBehaviour // TypeDefIndex: 2389
{
	// Fields
	public Slider slider; // 0x20
	public Button button; // 0x28
	private float durationSlider; // 0x30
	private float durationLogic; // 0x34
	private float elapsedTime; // 0x38
	private bool isSliding; // 0x3C
	private DotSkillManager skillManager; // 0x40
	public GameObject timeSkillLegend; // 0x48
	public GameObject arrowPanel; // 0x50
	public GameObject GroupDot; // 0x58
	public GameObject boardObj; // 0x60

	// Constructors
	public SkillLg(); // 0x0000000180B5A340-0x0000000180B5A3A0

	// Methods
	private void Start(); // 0x0000000180B59970-0x0000000180B59C00
	private void Update(); // 0x0000000180B59C00-0x0000000180B5A060
	private void StartSliding(); // 0x0000000180B5A060-0x0000000180B5A340
}

