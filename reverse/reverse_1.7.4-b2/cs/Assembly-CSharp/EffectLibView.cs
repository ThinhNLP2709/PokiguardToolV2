/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class EffectLibView : LibPagedViewBase // TypeDefIndex: 1769
{
	// Fields
	private const string CELL_ICON = "icon"; // Metadata: 0x0068D7D9
	private const string CELL_NAME = "txtName"; // Metadata: 0x0068D7DE
	private static readonly Color DebuffName; // 0x00
	private static readonly Color BuffName; // 0x10

	// Properties
	protected override int TotalCount { get; } // 0x0000000180673CB0-0x0000000180673D30 
	protected override string EmptyMessage { get; } // 0x0000000180673C80-0x0000000180673CB0 

	// Constructors
	public EffectLibView(); // 0x0000000180673C70-0x0000000180673C80
	static EffectLibView(); // 0x0000000180673C10-0x0000000180673C70

	// Methods
	private void Reset(); // 0x0000000180673C00-0x0000000180673C10
	private void OnEnable(); // 0x0000000180673BE0-0x0000000180673C00
	private void OnDisable(); // 0x0000000180673BD0-0x0000000180673BE0
	protected override void BindCell(GameObject cell, int index); // 0x00000001806736E0-0x0000000180673BD0
}

