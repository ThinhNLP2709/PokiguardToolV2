/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[RequireComponent(typeof(Image))]
public class UvAnimation : MonoBehaviour // TypeDefIndex: 1066
{
	// Fields
	private Material _material; // 0x20
	private Image _image; // 0x28
	private SlotMachine _parent; // 0x30
	private int _index; // 0x38

	// Constructors
	public UvAnimation(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001804AB420-0x00000001804AB4F0
	public void SetLevel(BlurLevel level); // 0x00000001804AB4F0-0x00000001804AB610
	public void SetShaderSettings(float blurAmount, float speed, Vector2 tiling); // 0x00000001804AB610-0x00000001804ABEB0
	public void SetVisibility(bool status); // 0x00000001804A7390-0x00000001804A73C0
}

