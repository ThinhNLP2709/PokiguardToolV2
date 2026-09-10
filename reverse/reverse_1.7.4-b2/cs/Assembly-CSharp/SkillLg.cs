/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class SkillLg : MonoBehaviour // TypeDefIndex: 1992
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
	public SkillLg(); // 0x00000001807213A0-0x00000001807213C0

	// Methods
	private void Start(); // 0x0000000180721070-0x00000001807211A0
	private void Update(); // 0x00000001807211A0-0x00000001807213A0
	private void StartSliding(); // 0x0000000180720F60-0x0000000180721070
}

