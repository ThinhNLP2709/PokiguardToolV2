/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GeneralEventsListeners : MonoBehaviour // TypeDefIndex: 282
{
	// Fields
	private Vector3 towardsRotation; // 0x20
	private float turnForLength; // 0x2C
	private float turnForIter; // 0x30
	private Color fromColor; // 0x34

	// Constructors
	public GeneralEventsListeners(); // 0x0000000180D853B0-0x0000000180D85400

	// Methods
	private void Awake(); // 0x0000000180D84460-0x0000000180D845B0
	private void Start(); // 0x0000000180D845B0-0x0000000180D846D0
	private void jumpUp(LTEvent e); // 0x0000000180D846D0-0x0000000180D847D0
	private void changeColor(LTEvent e); // 0x0000000180D847D0-0x0000000180D84BE0
	private void OnCollisionEnter(Collision collision); // 0x0000000180D84BE0-0x0000000180D84CF0
	private void OnCollisionStay(Collision collision); // 0x0000000180D84CF0-0x0000000180D84DF0
	private void FixedUpdate(); // 0x0000000180D84DF0-0x0000000180D852A0
	private void OnMouseDown(); // 0x0000000180D852A0-0x0000000180D853B0
	[CompilerGenerated]
	private void _changeColor_b__8_0(Color col); // 0x0000000180D85400-0x0000000180D85480
}

