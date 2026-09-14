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

[DisallowMultipleComponent]
public sealed class ThanhTuuPreviewPopup : MonoBehaviour // TypeDefIndex: 1301
{
	// Fields
	public const float W = 720f; // Metadata: 0x005F0AE5
	public const float H = 470f; // Metadata: 0x005F0AE9
	public const float TITLE_Y = 18f; // Metadata: 0x005F0AED
	public const float TITLE_H = 48f; // Metadata: 0x005F0AF1
	public const float TITLE_FONT = 30f; // Metadata: 0x005F0AF5
	public const float LINE_Y = 70f; // Metadata: 0x005F0AF9
	public const float LINE_W = 420f; // Metadata: 0x005F0AFD
	public const float LINE_H = 3f; // Metadata: 0x005F0B01
	public const float X_W = 84f; // Metadata: 0x005F0B05
	public const float X_H = 72f; // Metadata: 0x005F0B09
	public const float X_PAD = -6f; // Metadata: 0x005F0B0D
	public const float X_HIT = 96f; // Metadata: 0x005F0B11
	public const float SLOT_W = 128f; // Metadata: 0x005F0B15
	public const float SLOT_H = 112f; // Metadata: 0x005F0B19
	public const float SLOT_X0 = 36f; // Metadata: 0x005F0B1D
	public const float SLOT_Y0 = 96f; // Metadata: 0x005F0B21
	public const float SLOT_STEP_X = 144f; // Metadata: 0x005F0B25
	public const float SLOT_STEP_Y = 128f; // Metadata: 0x005F0B29
	public const int PER_ROW = 4; // Metadata: 0x005F0B2D
	public const int MAX_SLOTS = 12; // Metadata: 0x005F0B2E
	public const float ICON = 72f; // Metadata: 0x005F0B2F
	public const float QTY_FONT = 22f; // Metadata: 0x005F0B33
	public static readonly Color TITLE_COLOR; // 0x00
	public static readonly Color QTY_COLOR; // 0x10
	public static readonly Color QTY_OUTLINE; // 0x20
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private RectTransform _slotsRoot; // 0x30
	private Image _dim; // 0x38
	private Image _frame; // 0x40
	private Image _line; // 0x48
	private Image _btnX; // 0x50
	private UnityEngine.UI.Text _title; // 0x58
	private readonly List<Slot> _slots; // 0x60
	private readonly List<RewardDisplayHelper.Entry> _entries; // 0x68
	private Action<RectTransform, RewardDisplayHelper.Entry> _onSlotTap; // 0x70

	// Properties
	public bool IsShowing { get; } // 0x0000000180734380-0x00000001807344E0 

	// Nested types
	private sealed class Slot // TypeDefIndex: 1302
	{
		// Fields
		public RectTransform rt; // 0x10
		public Image bg; // 0x18
		public Image icon; // 0x20
		public UnityEngine.UI.Text qty; // 0x28

		// Constructors
		public Slot(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 1303
	{
		// Fields
		public Slot captured; // 0x10
		public ThanhTuuPreviewPopup __4__this; // 0x18

		// Constructors
		public __c__DisplayClass44_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureSlot_b__0(); // 0x00000001807371C0-0x00000001807372A0
	}

	// Constructors
	public ThanhTuuPreviewPopup(); // 0x0000000180736DB0-0x0000000180737010
	static ThanhTuuPreviewPopup(); // 0x0000000180737010-0x00000001807371C0

	// Methods
	public static ThanhTuuPreviewPopup Build(MonoBehaviour host, RectTransform parent, Action<RectTransform, RewardDisplayHelper.Entry> onSlotTap); // 0x00000001807344E0-0x0000000180734820
	private void BuildBody(float w, float h); // 0x0000000180734820-0x00000001807351D0
	public void Rebind(); // 0x00000001807351D0-0x00000001807353F0
	public void Show(string title, RechargeEventReward reward); // 0x00000001807353F0-0x0000000180735A70
	public void Hide(); // 0x0000000180735A70-0x0000000180735CF0
	private Slot EnsureSlot(int i); // 0x0000000180735CF0-0x0000000180736790
	private void FillSlot(Slot s, RewardDisplayHelper.Entry e, int i); // 0x0000000180736790-0x0000000180736B50
	private void OnSlot(Slot s); // 0x0000000180736B50-0x0000000180736C20
	public static Sprite IconOf(RewardDisplayHelper.Entry e); // 0x0000000180736C20-0x0000000180736DB0
}

