/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public sealed class ThanhTuuPreviewPopup : MonoBehaviour // TypeDefIndex: 1299
{
	// Fields
	public const float W = 720f; // Metadata: 0x005EF718
	public const float H = 470f; // Metadata: 0x005EF71C
	public const float TITLE_Y = 18f; // Metadata: 0x005EF720
	public const float TITLE_H = 48f; // Metadata: 0x005EF724
	public const float TITLE_FONT = 30f; // Metadata: 0x005EF728
	public const float LINE_Y = 70f; // Metadata: 0x005EF72C
	public const float LINE_W = 420f; // Metadata: 0x005EF730
	public const float LINE_H = 3f; // Metadata: 0x005EF734
	public const float X_W = 84f; // Metadata: 0x005EF738
	public const float X_H = 72f; // Metadata: 0x005EF73C
	public const float X_PAD = -6f; // Metadata: 0x005EF740
	public const float X_HIT = 96f; // Metadata: 0x005EF744
	public const float SLOT_W = 128f; // Metadata: 0x005EF748
	public const float SLOT_H = 112f; // Metadata: 0x005EF74C
	public const float SLOT_X0 = 36f; // Metadata: 0x005EF750
	public const float SLOT_Y0 = 96f; // Metadata: 0x005EF754
	public const float SLOT_STEP_X = 144f; // Metadata: 0x005EF758
	public const float SLOT_STEP_Y = 128f; // Metadata: 0x005EF75C
	public const int PER_ROW = 4; // Metadata: 0x005EF760
	public const int MAX_SLOTS = 12; // Metadata: 0x005EF761
	public const float ICON = 72f; // Metadata: 0x005EF762
	public const float QTY_FONT = 22f; // Metadata: 0x005EF766
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
	public bool IsShowing { get; } // 0x00000001807325D0-0x0000000180732730 

	// Nested types
	private sealed class Slot // TypeDefIndex: 1300
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
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 1301
	{
		// Fields
		public Slot captured; // 0x10
		public ThanhTuuPreviewPopup __4__this; // 0x18

		// Constructors
		public __c__DisplayClass44_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureSlot_b__0(); // 0x0000000180735410-0x00000001807354F0
	}

	// Constructors
	public ThanhTuuPreviewPopup(); // 0x0000000180735000-0x0000000180735260
	static ThanhTuuPreviewPopup(); // 0x0000000180735260-0x0000000180735410

	// Methods
	public static ThanhTuuPreviewPopup Build(MonoBehaviour host, RectTransform parent, Action<RectTransform, RewardDisplayHelper.Entry> onSlotTap); // 0x0000000180732730-0x0000000180732A70
	private void BuildBody(float w, float h); // 0x0000000180732A70-0x0000000180733420
	public void Rebind(); // 0x0000000180733420-0x0000000180733640
	public void Show(string title, RechargeEventReward reward); // 0x0000000180733640-0x0000000180733CC0
	public void Hide(); // 0x0000000180733CC0-0x0000000180733F40
	private Slot EnsureSlot(int i); // 0x0000000180733F40-0x00000001807349E0
	private void FillSlot(Slot s, RewardDisplayHelper.Entry e, int i); // 0x00000001807349E0-0x0000000180734DA0
	private void OnSlot(Slot s); // 0x0000000180734DA0-0x0000000180734E70
	public static Sprite IconOf(RewardDisplayHelper.Entry e); // 0x0000000180734E70-0x0000000180735000
}

