/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ElementGateUI : MonoBehaviour // TypeDefIndex: 19
{
	// Fields
	private const string ROOT_NAME = "elementGateBar"; // Metadata: 0x0068A93E
	private const float CELL_SIZE = 48f; // Metadata: 0x0068A94D
	private const float CELL_GAP = 6f; // Metadata: 0x0068A951
	private const float BUTTON_GAP = 16f; // Metadata: 0x0068A955
	private const float FALLBACK_TOP_OFFSET = -178f; // Metadata: 0x0068A959
	private readonly List<string> _required; // 0x20
	private readonly List<string> _missing; // 0x28
	private readonly List<Image> _cellIcons; // 0x30
	private readonly List<Image> _cellBgs; // 0x38
	private readonly List<Image> _cellGlows; // 0x40
	private readonly List<CanvasGroup> _cellGroups; // 0x48
	private readonly List<bool> _cellFilled; // 0x50
	private RectTransform _root; // 0x58
	private bool _subscribed; // 0x60
	private Room_Handler _handler; // 0x68
	private bool _blinking; // 0x70
	[CompilerGenerated]
	private bool _Satisfied_k__BackingField; // 0x71
	[CompilerGenerated]
	private string _MissingSummary_k__BackingField; // 0x78

	// Properties
	public bool Satisfied { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF6A0-0x00000001802FF6B0 0x00000001802FF6C0-0x00000001802FF6D0
	public bool IsApplicable { get; } // 0x00000001802FF620-0x00000001802FF640 
	public bool SatisfiedOrNotApplicable { get; } // 0x00000001802FF670-0x00000001802FF6A0 
	public string MissingSummary { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF650-0x00000001802FF660 0x00000001802FF6B0-0x00000001802FF6C0
	public IList<string> RequiredElements { get; } // 0x00000001802FF660-0x00000001802FF670 
	public IList<string> MissingElements { get; } // 0x00000001802FF640-0x00000001802FF650 
	public int FilledCount { get; } // 0x00000001802FF5F0-0x00000001802FF620 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 20
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayCellPunch_b__0(); // 0x0000000180300950-0x0000000180300A30
	}

	// Constructors
	public ElementGateUI(); // 0x00000001802FF3F0-0x00000001802FF5F0

	// Methods
	public static ElementGateUI EnsureAttached(GameObject roomPanel); // 0x00000001802FD9B0-0x00000001802FDAD0
	private void OnEnable(); // 0x00000001802FDB50-0x00000001802FDB70
	private void OnDisable(); // 0x00000001802FDB40-0x00000001802FDB50
	private void OnDestroy(); // 0x00000001802FDB40-0x00000001802FDB50
	private void Subscribe(); // 0x00000001802FF110-0x00000001802FF1E0
	private void Unsubscribe(); // 0x00000001802FF1E0-0x00000001802FF2B0
	private void Update(); // 0x00000001802FF2B0-0x00000001802FF3F0
	public void SetRequirement(string[] required); // 0x00000001802FF030-0x00000001802FF110
	public void Refresh(); // 0x00000001802FEB80-0x00000001802FF030
	private void EnsureBuilt(); // 0x00000001802FDAD0-0x00000001802FDB40
	private void Rebuild(); // 0x00000001802FE690-0x00000001802FEB80
	private Transform ReadyButtonParent(); // 0x00000001802FE500-0x00000001802FE580
	private RectTransform ReadyButtonRect(); // 0x00000001802FE580-0x00000001802FE690
	private void PlaceBar(); // 0x00000001802FDB70-0x00000001802FDF20
	private void BuildCell(int index, float x); // 0x00000001802FD050-0x00000001802FD9B0
	private void ApplyCellState(int index, bool filled); // 0x00000001802FCD40-0x00000001802FD050
	private void PlayCellPunch(int index); // 0x00000001802FDF20-0x00000001802FE190
	private void PlaySatisfiedFx(); // 0x00000001802FE190-0x00000001802FE500
}

