/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[RequireComponent(typeof(Image))]
public class UvAnimation : MonoBehaviour // TypeDefIndex: 1668
{
	// Fields
	private Material _material; // 0x20
	private Image _image; // 0x28
	private SlotMachine _parent; // 0x30
	private int _index; // 0x38

	// Constructors
	public UvAnimation(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Initialize(SlotMachine parent, int index); // 0x00000001808B25B0-0x00000001808B27A0
	public void SetLevel(BlurLevel level); // 0x00000001808B27A0-0x00000001808B27E0
	public void SetShaderSettings(float blurAmount, float speed, Vector2 tiling); // 0x00000001808B27E0-0x00000001808B2960
	public void SetVisibility(bool status); // 0x00000001808B0B80-0x00000001808B0C10
}

