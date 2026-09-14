/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class PokyChatWindowFit : MonoBehaviour // TypeDefIndex: 557
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
	public float AppliedHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E9000-0x00000001803E9010 0x00000001803E9010-0x00000001803E9020
	public float AppliedWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E9020-0x00000001803E9030 0x00000001803E9030-0x00000001803E9040

	// Constructors
	public PokyChatWindowFit(); // 0x00000001803E9910-0x00000001803E9990

	// Methods
	private void OnEnable(); // 0x00000001803E9040-0x00000001803E9060
	private void Update(); // 0x00000001803E9060-0x00000001803E9070
	private void Apply(); // 0x00000001803E9070-0x00000001803E9910
}

