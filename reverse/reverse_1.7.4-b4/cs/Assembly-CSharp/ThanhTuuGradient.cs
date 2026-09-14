/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public sealed class ThanhTuuGradient : BaseMeshEffect // TypeDefIndex: 1270
{
	// Fields
	[SerializeField]
	private Color _top; // 0x28
	[SerializeField]
	private Color _bottom; // 0x38

	// Properties
	public Color Top { get; set; } // 0x00000001807124D0-0x00000001807124E0 0x00000001807124E0-0x00000001807124F0
	public Color Bottom { get; set; } // 0x00000001807124F0-0x0000000180712500 0x0000000180712500-0x0000000180712510

	// Constructors
	public ThanhTuuGradient(); // 0x0000000180712B80-0x0000000180712CC0

	// Methods
	public void SetColors(Color top, Color bottom); // 0x0000000180712510-0x0000000180712530
	private new void MarkDirty(); // 0x0000000180712530-0x0000000180712650
	public override void ModifyMesh(VertexHelper vh); // 0x0000000180712650-0x0000000180712B80
}

