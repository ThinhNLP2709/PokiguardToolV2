/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[RequireComponent(typeof(Image))]
public class UvAnimation : MonoBehaviour // TypeDefIndex: 1265
{
	// Fields
	private Material _material; // 0x20
	private Image _image; // 0x28
	private SlotMachine _parent; // 0x30
	private int _index; // 0x38

	// Constructors
	public UvAnimation(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001805A6850-0x00000001805A6920
	public void SetLevel(BlurLevel level); // 0x00000001805A6920-0x00000001805A6A40
	public void SetShaderSettings(float blurAmount, float speed, Vector2 tiling); // 0x00000001805A6A40-0x00000001805A72B0
	public void SetVisibility(bool status); // 0x00000001805A1A40-0x00000001805A1A70
}

