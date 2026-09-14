/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ElementGateUI : MonoBehaviour // TypeDefIndex: 22
{
	// Fields
	private const string ROOT_NAME = "elementGateBar"; // Metadata: 0x005EE964
	private const float CELL_SIZE = 48f; // Metadata: 0x005EE973
	private const float CELL_GAP = 6f; // Metadata: 0x005EE977
	private const float BUTTON_GAP = 16f; // Metadata: 0x005EE97B
	private const float FALLBACK_TOP_OFFSET = -178f; // Metadata: 0x005EE97F
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
	public bool Satisfied { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8640-0x00000001802A8650 0x00000001802A8650-0x00000001802A8660
	public bool IsApplicable { get; } // 0x00000001802A8660-0x00000001802A8680 
	public bool SatisfiedOrNotApplicable { get; } // 0x00000001802A8680-0x00000001802A86B0 
	public string MissingSummary { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A86B0-0x00000001802A86C0 0x00000001802A86C0-0x00000001802A8720
	public IList<string> RequiredElements { get; } // 0x00000001802A8720-0x00000001802A8730 
	public IList<string> MissingElements { get; } // 0x00000001802A8730-0x00000001802A8740 
	public int FilledCount { get; } // 0x00000001802A8740-0x00000001802A8770 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 23
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass50_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayCellPunch_b__0(); // 0x00000001802AC8C0-0x00000001802ACA20
	}

	// Constructors
	public ElementGateUI(); // 0x00000001802AC430-0x00000001802AC8C0

	// Methods
	public static ElementGateUI EnsureAttached(GameObject roomPanel); // 0x00000001802A8770-0x00000001802A8A20
	private void OnEnable(); // 0x00000001802A8A20-0x00000001802A8A40
	private void OnDisable(); // 0x00000001802A8A40-0x00000001802A8A50
	private void OnDestroy(); // 0x00000001802A8A40-0x00000001802A8A50
	private void Subscribe(); // 0x00000001802A8A50-0x00000001802A8B30
	private void Unsubscribe(); // 0x00000001802A8B30-0x00000001802A8C10
	private void Update(); // 0x00000001802A8C10-0x00000001802A8E10
	public void SetRequirement(string[] required); // 0x00000001802A8E10-0x00000001802A8F00
	public void Refresh(); // 0x00000001802A8F00-0x00000001802A97D0
	private void EnsureBuilt(); // 0x00000001802A97D0-0x00000001802A98C0
	private void Rebuild(); // 0x00000001802A98C0-0x00000001802AA1C0
	private Transform ReadyButtonParent(); // 0x00000001802AA1C0-0x00000001802AA2B0
	private RectTransform ReadyButtonRect(); // 0x00000001802AA2B0-0x00000001802AA560
	private void PlaceBar(); // 0x00000001802AA560-0x00000001802AAE30
	private void BuildCell(int index, float x); // 0x00000001802AAE30-0x00000001802AB990
	private void ApplyCellState(int index, bool filled); // 0x00000001802AB990-0x00000001802ABF90
	private void PlayCellPunch(int index); // 0x00000001802ABF90-0x00000001802AC300
	private void PlaySatisfiedFx(); // 0x00000001802AC300-0x00000001802AC430
}

