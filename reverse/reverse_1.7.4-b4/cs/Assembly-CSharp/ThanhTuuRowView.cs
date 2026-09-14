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
public sealed class ThanhTuuRowView : MonoBehaviour // TypeDefIndex: 1307
{
	// Fields
	public const float X = 18f; // Metadata: 0x005F0BEA
	public const float Y0 = 12f; // Metadata: 0x005F0BEE
	public const float STEP = 186f; // Metadata: 0x005F0BF2
	public const float W = 1262f; // Metadata: 0x005F0BF6
	public const float H = 174f; // Metadata: 0x005F0BFA
	public const float TITLE_X = 34f; // Metadata: 0x005F0BFE
	public const float TITLE_Y = 6f; // Metadata: 0x005F0C02
	public const float TITLE_W = 900f; // Metadata: 0x005F0C06
	public const float TITLE_H = 36f; // Metadata: 0x005F0C0A
	public const float TITLE_FONT = 26f; // Metadata: 0x005F0C0E
	public const float TITLE_MIN = 18f; // Metadata: 0x005F0C12
	public const float BAR_X = 1012f; // Metadata: 0x005F0C16
	public const float BAR_Y = 8f; // Metadata: 0x005F0C1A
	public const float BAR_W = 150f; // Metadata: 0x005F0C1E
	public const float BAR_H = 30f; // Metadata: 0x005F0C22
	public const float BAR_FONT = 20f; // Metadata: 0x005F0C26
	public const float BAR_INSET = 3f; // Metadata: 0x005F0C2A
	public const float CHECK_X = -8f; // Metadata: 0x005F0C2E
	public const float CHECK_Y = 58f; // Metadata: 0x005F0C32
	public const float CHECK_W = 56f; // Metadata: 0x005F0C36
	public const float CHECK_H = 52f; // Metadata: 0x005F0C3A
	public const float SLOT_X = 58f; // Metadata: 0x005F0C3E
	public const float SLOT_Y = 48f; // Metadata: 0x005F0C42
	public const float SLOT_W = 118f; // Metadata: 0x005F0C46
	public const float SLOT_H = 104f; // Metadata: 0x005F0C4A
	public const float ICON = 64f; // Metadata: 0x005F0C4E
	public const float ICON_UP = 6f; // Metadata: 0x005F0C52
	public const float QTY_FONT = 22f; // Metadata: 0x005F0C56
	public const float CLAIM_X = 1000f; // Metadata: 0x005F0C5A
	public const float CLAIM_Y = 56f; // Metadata: 0x005F0C5E
	public const float CLAIM_W = 170f; // Metadata: 0x005F0C62
	public const float CLAIM_H = 60f; // Metadata: 0x005F0C66
	public const float CLAIM_FONT = 28f; // Metadata: 0x005F0C6A
	public const float CLAIM_HIT_W = 200f; // Metadata: 0x005F0C6E
	public const float CLAIM_HIT_H = 100f; // Metadata: 0x005F0C72
	public const float CLAIMED_X = 988f; // Metadata: 0x005F0C76
	public const float CLAIMED_Y = 66f; // Metadata: 0x005F0C7A
	public const float CLAIMED_W = 194f; // Metadata: 0x005F0C7E
	public const float CLAIMED_H = 46f; // Metadata: 0x005F0C82
	public const float CLAIMED_FONT = 26f; // Metadata: 0x005F0C86
	public static readonly Color TITLE_COLOR; // 0x00
	public static readonly Color NAVY_OUTLINE; // 0x10
	public static readonly Color QTY_COLOR; // 0x20
	public static readonly Color QTY_OUTLINE; // 0x30
	public static readonly Color CLAIM_OUTLINE; // 0x40
	public static readonly Color CLAIMED_COLOR; // 0x50
	private MonoBehaviour _host; // 0x20
	private RectTransform _rt; // 0x28
	private RectTransform _bar; // 0x30
	private RectTransform _fill; // 0x38
	private RectTransform _slot; // 0x40
	private RectTransform _claim; // 0x48
	private RectTransform _claimed; // 0x50
	private RectTransform _check; // 0x58
	private Image _plate; // 0x60
	private Image _barImg; // 0x68
	private Image _fillImg; // 0x70
	private Image _checkImg; // 0x78
	private Image _slotImg; // 0x80
	private Image _icon; // 0x88
	private Image _claimImg; // 0x90
	private Image _claimedImg; // 0x98
	private UnityEngine.UI.Text _title; // 0xA0
	private UnityEngine.UI.Text _barTxt; // 0xA8
	private UnityEngine.UI.Text _qty; // 0xB0
	private UnityEngine.UI.Text _claimTxt; // 0xB8
	private UnityEngine.UI.Text _claimedTxt; // 0xC0
	private ThanhTuuTask _task; // 0xC8
	private RewardDisplayHelper.Entry _entry; // 0xD0
	private int _index; // 0xD8
	private float _extra; // 0xDC
	private int _pulseId; // 0xE0
	private int _slideId; // 0xE4
	private int _popId; // 0xE8
	private bool _busy; // 0xEC
	private bool _claimEnabled; // 0xED
	private Action<ThanhTuuRowView> _onClaim; // 0xF0
	private Action<ThanhTuuRowView> _onSlot; // 0xF8

	// Properties
	public ThanhTuuTask Task { get; } // 0x00000001802D9080-0x00000001802D9090 
	public RewardDisplayHelper.Entry Entry { get; } // 0x00000001802D90F0-0x00000001802D9100 
	public RectTransform Rect { get; } // 0x00000001802A8730-0x00000001802A8740 
	public RectTransform SlotRect { get; } // 0x00000001802BA640-0x00000001802BA650 
	public RectTransform ClaimRect { get; } // 0x00000001802D8BB0-0x00000001802D8BC0 
	public int Index { get; } // 0x00000001803C7100-0x00000001803C7110 

	// Constructors
	public ThanhTuuRowView(); // 0x0000000180741940-0x00000001807419B0
	static ThanhTuuRowView(); // 0x00000001807419B0-0x0000000180741CD0

	// Methods
	public static ThanhTuuRowView Build(MonoBehaviour host, RectTransform content, int index, Action<ThanhTuuRowView> onClaim, Action<ThanhTuuRowView> onSlot); // 0x000000018073DF80-0x000000018073E2A0
	private void BuildBody(); // 0x000000018073E2A0-0x000000018073F7C0
	public void Rebind(); // 0x000000018073F7C0-0x000000018073FA50
	public static Vector4 Geometry(); // 0x000000018073FA50-0x000000018073FB00
	public static float StepOf(Vector4 g); // 0x000000018073FB00-0x000000018073FB10
	public static float TopOf(int index); // 0x000000018073FB10-0x000000018073FB90
	public static float RowHeight(); // 0x000000018073FB90-0x000000018073FBF0
	public static float TopPad(); // 0x000000018073FBF0-0x000000018073FC50
	public static float ContentHeight(int count); // 0x000000018073FC50-0x000000018073FCE0
	public void Layout(int index, float extraW); // 0x000000018073FCE0-0x00000001807400F0
	public void SlideIn(float delay); // 0x00000001807400F0-0x00000001807401B0
	public void Bind(ThanhTuuTask task, ThanhTuuStrings str, bool claimEnabled); // 0x00000001807401B0-0x0000000180740670
	private void SetState(ThanhTuuTask task, bool claimEnabled); // 0x0000000180740670-0x0000000180740B40
	private void SetBarFill(ThanhTuuTask task); // 0x0000000180740B40-0x0000000180740F70
	public void PopCheck(); // 0x0000000180740F70-0x0000000180741140
	public void SetBusy(bool busy); // 0x0000000180741140-0x0000000180741420
	public void StopFx(); // 0x0000000180741420-0x0000000180741700
	private void OnDisable(); // 0x0000000180741700-0x0000000180741710
	private static void SetOn(Component c, bool on); // 0x0000000180741710-0x00000001807418E0
	public static RewardDisplayHelper.Entry FirstEntry(RechargeEventReward reward); // 0x00000001807418E0-0x0000000180741940
	[CompilerGenerated]
	private void _BuildBody_b__91_0(); // 0x0000000180741CD0-0x0000000180741D00
	[CompilerGenerated]
	private void _BuildBody_b__91_1(); // 0x0000000180741D00-0x0000000180741D30
}

