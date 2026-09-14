/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public sealed class ThanhTuuRowView : MonoBehaviour // TypeDefIndex: 1305
{
	// Fields
	public const float X = 18f; // Metadata: 0x005EF81D
	public const float Y0 = 12f; // Metadata: 0x005EF821
	public const float STEP = 186f; // Metadata: 0x005EF825
	public const float W = 1262f; // Metadata: 0x005EF829
	public const float H = 174f; // Metadata: 0x005EF82D
	public const float TITLE_X = 34f; // Metadata: 0x005EF831
	public const float TITLE_Y = 6f; // Metadata: 0x005EF835
	public const float TITLE_W = 900f; // Metadata: 0x005EF839
	public const float TITLE_H = 36f; // Metadata: 0x005EF83D
	public const float TITLE_FONT = 26f; // Metadata: 0x005EF841
	public const float TITLE_MIN = 18f; // Metadata: 0x005EF845
	public const float BAR_X = 1012f; // Metadata: 0x005EF849
	public const float BAR_Y = 8f; // Metadata: 0x005EF84D
	public const float BAR_W = 150f; // Metadata: 0x005EF851
	public const float BAR_H = 30f; // Metadata: 0x005EF855
	public const float BAR_FONT = 20f; // Metadata: 0x005EF859
	public const float BAR_INSET = 3f; // Metadata: 0x005EF85D
	public const float CHECK_X = -8f; // Metadata: 0x005EF861
	public const float CHECK_Y = 58f; // Metadata: 0x005EF865
	public const float CHECK_W = 56f; // Metadata: 0x005EF869
	public const float CHECK_H = 52f; // Metadata: 0x005EF86D
	public const float SLOT_X = 58f; // Metadata: 0x005EF871
	public const float SLOT_Y = 48f; // Metadata: 0x005EF875
	public const float SLOT_W = 118f; // Metadata: 0x005EF879
	public const float SLOT_H = 104f; // Metadata: 0x005EF87D
	public const float ICON = 64f; // Metadata: 0x005EF881
	public const float ICON_UP = 6f; // Metadata: 0x005EF885
	public const float QTY_FONT = 22f; // Metadata: 0x005EF889
	public const float CLAIM_X = 1000f; // Metadata: 0x005EF88D
	public const float CLAIM_Y = 56f; // Metadata: 0x005EF891
	public const float CLAIM_W = 170f; // Metadata: 0x005EF895
	public const float CLAIM_H = 60f; // Metadata: 0x005EF899
	public const float CLAIM_FONT = 28f; // Metadata: 0x005EF89D
	public const float CLAIM_HIT_W = 200f; // Metadata: 0x005EF8A1
	public const float CLAIM_HIT_H = 100f; // Metadata: 0x005EF8A5
	public const float CLAIMED_X = 988f; // Metadata: 0x005EF8A9
	public const float CLAIMED_Y = 66f; // Metadata: 0x005EF8AD
	public const float CLAIMED_W = 194f; // Metadata: 0x005EF8B1
	public const float CLAIMED_H = 46f; // Metadata: 0x005EF8B5
	public const float CLAIMED_FONT = 26f; // Metadata: 0x005EF8B9
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
	public ThanhTuuTask Task { get; } // 0x00000001802D9050-0x00000001802D9060 
	public RewardDisplayHelper.Entry Entry { get; } // 0x00000001802D90C0-0x00000001802D90D0 
	public RectTransform Rect { get; } // 0x00000001802A8730-0x00000001802A8740 
	public RectTransform SlotRect { get; } // 0x00000001802BA610-0x00000001802BA620 
	public RectTransform ClaimRect { get; } // 0x00000001802D8B80-0x00000001802D8B90 
	public int Index { get; } // 0x00000001803C6430-0x00000001803C6440 

	// Constructors
	public ThanhTuuRowView(); // 0x000000018073FB90-0x000000018073FC00
	static ThanhTuuRowView(); // 0x000000018073FC00-0x000000018073FF20

	// Methods
	public static ThanhTuuRowView Build(MonoBehaviour host, RectTransform content, int index, Action<ThanhTuuRowView> onClaim, Action<ThanhTuuRowView> onSlot); // 0x000000018073C1D0-0x000000018073C4F0
	private void BuildBody(); // 0x000000018073C4F0-0x000000018073DA10
	public void Rebind(); // 0x000000018073DA10-0x000000018073DCA0
	public static Vector4 Geometry(); // 0x000000018073DCA0-0x000000018073DD50
	public static float StepOf(Vector4 g); // 0x000000018073DD50-0x000000018073DD60
	public static float TopOf(int index); // 0x000000018073DD60-0x000000018073DDE0
	public static float RowHeight(); // 0x000000018073DDE0-0x000000018073DE40
	public static float TopPad(); // 0x000000018073DE40-0x000000018073DEA0
	public static float ContentHeight(int count); // 0x000000018073DEA0-0x000000018073DF30
	public void Layout(int index, float extraW); // 0x000000018073DF30-0x000000018073E340
	public void SlideIn(float delay); // 0x000000018073E340-0x000000018073E400
	public void Bind(ThanhTuuTask task, ThanhTuuStrings str, bool claimEnabled); // 0x000000018073E400-0x000000018073E8C0
	private void SetState(ThanhTuuTask task, bool claimEnabled); // 0x000000018073E8C0-0x000000018073ED90
	private void SetBarFill(ThanhTuuTask task); // 0x000000018073ED90-0x000000018073F1C0
	public void PopCheck(); // 0x000000018073F1C0-0x000000018073F390
	public void SetBusy(bool busy); // 0x000000018073F390-0x000000018073F670
	public void StopFx(); // 0x000000018073F670-0x000000018073F950
	private void OnDisable(); // 0x000000018073F950-0x000000018073F960
	private static void SetOn(Component c, bool on); // 0x000000018073F960-0x000000018073FB30
	public static RewardDisplayHelper.Entry FirstEntry(RechargeEventReward reward); // 0x000000018073FB30-0x000000018073FB90
	[CompilerGenerated]
	private void _BuildBody_b__91_0(); // 0x000000018073FF20-0x000000018073FF50
	[CompilerGenerated]
	private void _BuildBody_b__91_1(); // 0x000000018073FF50-0x000000018073FF80
}

