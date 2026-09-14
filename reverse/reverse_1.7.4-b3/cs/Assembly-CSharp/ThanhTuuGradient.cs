/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public sealed class ThanhTuuGradient : BaseMeshEffect // TypeDefIndex: 1268
{
	// Fields
	[SerializeField]
	private Color _top; // 0x28
	[SerializeField]
	private Color _bottom; // 0x38

	// Properties
	public Color Top { get; set; } // 0x0000000180710720-0x0000000180710730 0x0000000180710730-0x0000000180710740
	public Color Bottom { get; set; } // 0x0000000180710740-0x0000000180710750 0x0000000180710750-0x0000000180710760

	// Constructors
	public ThanhTuuGradient(); // 0x0000000180710DD0-0x0000000180710F10

	// Methods
	public void SetColors(Color top, Color bottom); // 0x0000000180710760-0x0000000180710780
	private new void MarkDirty(); // 0x0000000180710780-0x00000001807108A0
	public override void ModifyMesh(VertexHelper vh); // 0x00000001807108A0-0x0000000180710DD0
}

