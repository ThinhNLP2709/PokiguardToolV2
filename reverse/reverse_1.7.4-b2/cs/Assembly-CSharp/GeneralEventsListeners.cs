/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GeneralEventsListeners : MonoBehaviour // TypeDefIndex: 282
{
	// Fields
	private Vector3 towardsRotation; // 0x20
	private float turnForLength; // 0x2C
	private float turnForIter; // 0x30
	private Color fromColor; // 0x34

	// Nested types
	public enum MyEvents // TypeDefIndex: 283
	{
		CHANGE_COLOR = 0,
		JUMP = 1,
		LENGTH = 2
	}

	// Constructors
	public GeneralEventsListeners(); // 0x00000001808590D0-0x00000001808590E0

	// Methods
	private void Awake(); // 0x0000000180858A00-0x0000000180858AC0
	private void Start(); // 0x0000000180858F50-0x0000000180859050
	private void jumpUp(LTEvent e); // 0x00000001808593E0-0x0000000180859480
	private void changeColor(LTEvent e); // 0x00000001808590E0-0x00000001808593E0
	private void OnCollisionEnter(Collision collision); // 0x0000000180858DC0-0x0000000180858E40
	private void OnCollisionStay(Collision collision); // 0x0000000180858E40-0x0000000180858EA0
	private void FixedUpdate(); // 0x0000000180858AC0-0x0000000180858DC0
	private void OnMouseDown(); // 0x0000000180858EA0-0x0000000180858F50
	[CompilerGenerated]
	private void _changeColor_b__8_0(Color col); // 0x0000000180859050-0x00000001808590D0
}

