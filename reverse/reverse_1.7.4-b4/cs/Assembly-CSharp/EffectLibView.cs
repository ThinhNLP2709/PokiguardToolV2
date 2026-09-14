/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class EffectLibView : LibPagedViewBase // TypeDefIndex: 2134
{
	// Fields
	private const string CELL_ICON = "icon"; // Metadata: 0x005F19DD
	private const string CELL_NAME = "txtName"; // Metadata: 0x005F19E2
	private static readonly Color DebuffName; // 0x00
	private static readonly Color BuffName; // 0x10

	// Properties
	protected override int TotalCount { get; } // 0x0000000180A11870-0x0000000180A11900 
	protected override string EmptyMessage { get; } // 0x0000000180A11900-0x0000000180A11940 

	// Constructors
	public EffectLibView(); // 0x0000000180A122B0-0x0000000180A12300
	static EffectLibView(); // 0x0000000180A12300-0x0000000180A12360

	// Methods
	private void Reset(); // 0x0000000180A11860-0x0000000180A11870
	private void OnEnable(); // 0x0000000180A11940-0x0000000180A11960
	private void OnDisable(); // 0x0000000180A11960-0x0000000180A11970
	protected override void BindCell(GameObject cell, int index); // 0x0000000180A11970-0x0000000180A122B0
}

