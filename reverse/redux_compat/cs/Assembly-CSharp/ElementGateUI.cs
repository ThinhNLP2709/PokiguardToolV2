/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ElementGateUI : MonoBehaviour // TypeDefIndex: 14
{
	// Fields
	private const string ROOT_NAME = "elementGateBar"; // Metadata: 0x0064BF2D
	private const float CELL_SIZE = 56f; // Metadata: 0x0064BF3C
	private const float CELL_GAP = 10f; // Metadata: 0x0064BF40
	private readonly List<string> _required; // 0x20
	private readonly List<Image> _cellIcons; // 0x28
	private readonly List<Image> _cellBgs; // 0x30
	private readonly List<bool> _cellFilled; // 0x38
	private UnityEngine.UI.Text _statusText; // 0x40
	private RectTransform _root; // 0x48
	private bool _subscribed; // 0x50
	[CompilerGenerated]
	private bool _Satisfied_k__BackingField; // 0x51
	[CompilerGenerated]
	private string _MissingSummary_k__BackingField; // 0x58

	// Properties
	public bool Satisfied { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F4040-0x00000001802F4050 0x00000001802F4060-0x00000001802F4070
	public bool IsApplicable { get; } // 0x00000001802F3FE0-0x00000001802F4000 
	public bool SatisfiedOrNotApplicable { get; } // 0x00000001802F4010-0x00000001802F4040 
	public string MissingSummary { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 15
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass33_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayCellPunch_b__0(); // 0x00000001802FAF80-0x00000001802FB060
	}

	// Constructors
	public ElementGateUI(); // 0x00000001802F3E90-0x00000001802F3FE0

	// Methods
	public static ElementGateUI EnsureAttached(GameObject roomPanel); // 0x00000001802F28F0-0x00000001802F29C0
	private void OnEnable(); // 0x00000001802F3080-0x00000001802F30A0
	private void OnDisable(); // 0x00000001802F3070-0x00000001802F3080
	private void OnDestroy(); // 0x00000001802F3070-0x00000001802F3080
	private void Subscribe(); // 0x00000001802F3CF0-0x00000001802F3DC0
	private void Unsubscribe(); // 0x00000001802F3DC0-0x00000001802F3E90
	public void SetRequirement(string[] required); // 0x00000001802F3C10-0x00000001802F3CF0
	public void Refresh(); // 0x00000001802F3650-0x00000001802F3C10
	private void EnsureBuilt(); // 0x00000001802F29C0-0x00000001802F3070
	private void BuildCell(int index, float x); // 0x00000001802F22B0-0x00000001802F28F0
	private void ApplyCellState(int index, bool filled); // 0x00000001802F2070-0x00000001802F22B0
	private void PlayCellPunch(int index); // 0x00000001802F30A0-0x00000001802F3310
	private void PlaySatisfiedFx(); // 0x00000001802F3310-0x00000001802F3650
}

