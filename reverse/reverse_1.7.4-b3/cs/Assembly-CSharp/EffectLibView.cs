/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class EffectLibView : LibPagedViewBase // TypeDefIndex: 2132
{
	// Fields
	private const string CELL_ICON = "icon"; // Metadata: 0x005F060C
	private const string CELL_NAME = "txtName"; // Metadata: 0x005F0611
	private static readonly Color DebuffName; // 0x00
	private static readonly Color BuffName; // 0x10

	// Properties
	protected override int TotalCount { get; } // 0x0000000180A0DC80-0x0000000180A0DD10 
	protected override string EmptyMessage { get; } // 0x0000000180A0DD10-0x0000000180A0DD50 

	// Constructors
	public EffectLibView(); // 0x0000000180A0E6C0-0x0000000180A0E710
	static EffectLibView(); // 0x0000000180A0E710-0x0000000180A0E770

	// Methods
	private void Reset(); // 0x0000000180A0DC70-0x0000000180A0DC80
	private void OnEnable(); // 0x0000000180A0DD50-0x0000000180A0DD70
	private void OnDisable(); // 0x0000000180A0DD70-0x0000000180A0DD80
	protected override void BindCell(GameObject cell, int index); // 0x0000000180A0DD80-0x0000000180A0E6C0
}

