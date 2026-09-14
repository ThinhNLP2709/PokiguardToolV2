/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class PokyChatWindowFit : MonoBehaviour // TypeDefIndex: 556
{
	// Fields
	public RectTransform window; // 0x20
	public float bottomMargin; // 0x28
	public float topMargin; // 0x2C
	public float minHeight; // 0x30
	public float maxHeight; // 0x34
	public float widthFrac; // 0x38
	public float minWidth; // 0x3C
	public float maxWidth; // 0x40
	private RectTransform _canvasRect; // 0x48
	private float _lastCanvasH; // 0x50
	private float _lastCanvasW; // 0x54
	[CompilerGenerated]
	private float _AppliedHeight_k__BackingField; // 0x58
	[CompilerGenerated]
	private float _AppliedWidth_k__BackingField; // 0x5C

	// Properties
	public float AppliedHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E82C0-0x00000001803E82D0 0x00000001803E82D0-0x00000001803E82E0
	public float AppliedWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E82E0-0x00000001803E82F0 0x00000001803E82F0-0x00000001803E8300

	// Constructors
	public PokyChatWindowFit(); // 0x00000001803E8BD0-0x00000001803E8C50

	// Methods
	private void OnEnable(); // 0x00000001803E8300-0x00000001803E8320
	private void Update(); // 0x00000001803E8320-0x00000001803E8330
	private void Apply(); // 0x00000001803E8330-0x00000001803E8BD0
}

