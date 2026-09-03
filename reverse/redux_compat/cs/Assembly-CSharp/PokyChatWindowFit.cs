/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class PokyChatWindowFit : MonoBehaviour // TypeDefIndex: 434
{
	// Fields
	public RectTransform window; // 0x20
	public float bottomMargin; // 0x28
	public float topMargin; // 0x2C
	public float minHeight; // 0x30
	public float maxHeight; // 0x34
	private RectTransform _canvasRect; // 0x38
	private float _lastCanvasH; // 0x40
	[CompilerGenerated]
	private float _AppliedHeight_k__BackingField; // 0x44

	// Properties
	public float AppliedHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180349420-0x0000000180349430 0x0000000180349430-0x0000000180349440

	// Constructors
	public PokyChatWindowFit(); // 0x00000001803493F0-0x0000000180349420

	// Methods
	private void OnEnable(); // 0x00000001803493D0-0x00000001803493E0
	private void Update(); // 0x00000001803493E0-0x00000001803493F0
	private void Apply(); // 0x00000001803490F0-0x00000001803493D0
}

