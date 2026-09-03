/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GeneralEventsListeners : MonoBehaviour // TypeDefIndex: 256
{
	// Fields
	private Vector3 towardsRotation; // 0x20
	private float turnForLength; // 0x2C
	private float turnForIter; // 0x30
	private Color fromColor; // 0x34

	// Nested types
	public enum MyEvents // TypeDefIndex: 257
	{
		CHANGE_COLOR = 0,
		JUMP = 1,
		LENGTH = 2
	}

	// Constructors
	public GeneralEventsListeners(); // 0x00000001806AF2A0-0x00000001806AF2B0

	// Methods
	private void Awake(); // 0x00000001806AEBD0-0x00000001806AEC90
	private void Start(); // 0x00000001806AF120-0x00000001806AF220
	private void jumpUp(LTEvent e); // 0x00000001806AF5B0-0x00000001806AF650
	private void changeColor(LTEvent e); // 0x00000001806AF2B0-0x00000001806AF5B0
	private void OnCollisionEnter(Collision collision); // 0x00000001806AEF90-0x00000001806AF010
	private void OnCollisionStay(Collision collision); // 0x00000001806AF010-0x00000001806AF070
	private void FixedUpdate(); // 0x00000001806AEC90-0x00000001806AEF90
	private void OnMouseDown(); // 0x00000001806AF070-0x00000001806AF120
	[CompilerGenerated]
	private void _changeColor_b__8_0(Color col); // 0x00000001806AF220-0x00000001806AF2A0
}

