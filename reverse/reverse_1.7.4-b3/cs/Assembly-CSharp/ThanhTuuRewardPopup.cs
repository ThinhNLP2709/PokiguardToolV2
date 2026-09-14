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
public sealed class ThanhTuuRewardPopup : MonoBehaviour // TypeDefIndex: 1302
{
	// Fields
	public const float X = 477f; // Metadata: 0x005EF76A
	public const float Y = 250f; // Metadata: 0x005EF76E
	public const float W = 820f; // Metadata: 0x005EF772
	public const float H = 480f; // Metadata: 0x005EF776
	public const float BOX = 220f; // Metadata: 0x005EF77A
	public const float BOX_DY = -10f; // Metadata: 0x005EF77E
	public const float GLOW = 360f; // Metadata: 0x005EF782
	public const float SWIRL = 560f; // Metadata: 0x005EF786
	public const float STAR = 76f; // Metadata: 0x005EF78A
	public const float SPARKLE = 48f; // Metadata: 0x005EF78E
	public const int STARS = 12; // Metadata: 0x005EF792
	public const float ICON_ONE = 110f; // Metadata: 0x005EF793
	public const float ICON_MANY = 84f; // Metadata: 0x005EF797
	public const float GRID_STEP = 104f; // Metadata: 0x005EF79B
	public const int PER_ROW = 6; // Metadata: 0x005EF79F
	public const float GRID_DY = 20f; // Metadata: 0x005EF7A0
	public const int MAX_CELLS = 18; // Metadata: 0x005EF7A4
	public const float OK_W = 190f; // Metadata: 0x005EF7A5
	public const float OK_H = 120f; // Metadata: 0x005EF7A9
	public const float OK_DY = -215f; // Metadata: 0x005EF7AD
	public const float OK_FONT = 30f; // Metadata: 0x005EF7B1
	public const float QTY_FONT = 24f; // Metadata: 0x005EF7B5
	public const float T_DIM = 0.12f; // Metadata: 0x005EF7B9
	public const float T_FRAME = 0.18f; // Metadata: 0x005EF7BD
	public const float T_BOX_IN = 0.1f; // Metadata: 0x005EF7C1
	public const float BOX_IN = 0.15f; // Metadata: 0x005EF7C5
	public const float T_WOBBLE = 0.25f; // Metadata: 0x005EF7C9
	public const float WOBBLE = 0.36f; // Metadata: 0x005EF7CD
	public const float WOBBLE_DEG = 4f; // Metadata: 0x005EF7D1
	public const float T_BURST = 0.5f; // Metadata: 0x005EF7D5
	public const float GLOW_TIME = 0.35f; // Metadata: 0x005EF7D9
	public const float FLASH_TIME = 0.2f; // Metadata: 0x005EF7DD
	public const float FLASH_ALPHA = 0.8f; // Metadata: 0x005EF7E1
	public const float T_BOX_OFF = 0.62f; // Metadata: 0x005EF7E5
	public const float T_STARS = 0.6f; // Metadata: 0x005EF7E9
	public const float SWIRL_TIME = 0.6f; // Metadata: 0x005EF7ED
	public const float STAR_TIME = 0.7f; // Metadata: 0x005EF7F1
	public const float SWIRL_DEG = 200f; // Metadata: 0x005EF7F5
	public const float T_REWARD = 0.62f; // Metadata: 0x005EF7F9
	public const float REWARD_POP = 0.25f; // Metadata: 0x005EF7FD
	public const float REWARD_STAGGER = 0.05f; // Metadata: 0x005EF801
	public const float REWARD_PEAK = 1.15f; // Metadata: 0x005EF805
	public const float T_OK = 0.9f; // Metadata: 0x005EF809
	public const float OK_FADE = 0.15f; // Metadata: 0x005EF80D
	public const float TWINKLE = 0.6f; // Metadata: 0x005EF811
	public const float EDIT_POSE = 1.05f; // Metadata: 0x005EF815
	public const int SEED = 20260911; // Metadata: 0x005EF819
	public static readonly Color DIM; // 0x00
	public static readonly Color QTY_COLOR; // 0x10
	public static readonly Color QTY_OUTLINE; // 0x20
	public static readonly Color OK_OUTLINE; // 0x30
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private RectTransform _body; // 0x30
	private RectTransform _grid; // 0x38
	private RectTransform _boxRt; // 0x40
	private RectTransform _glowRt; // 0x48
	private RectTransform _okRt; // 0x50
	private CanvasGroup _group; // 0x58
	private CanvasGroup _okGroup; // 0x60
	private Image _dim; // 0x68
	private Image _frame; // 0x70
	private Image _flash; // 0x78
	private Image _glow; // 0x80
	private Image _box; // 0x88
	private Image _okImg; // 0x90
	private UnityEngine.UI.Text _okTxt; // 0x98
	private readonly RectTransform[] _swirl; // 0xA0
	private readonly Image[] _swirlImg; // 0xA8
	private readonly RectTransform[] _stars; // 0xB0
	private readonly Image[] _starImg; // 0xB8
	private readonly RectTransform[] _sparkles; // 0xC0
	private readonly Image[] _sparkleImg; // 0xC8
	private readonly List<Cell> _cells; // 0xD0
	private readonly List<RewardDisplayHelper.Entry> _entries; // 0xD8
	private StarSeed[] _seed; // 0xE0
	private Action _onClosed; // 0xE8
	private ThanhTuuClaimResult _result; // 0xF0
	private bool _okReady; // 0xF8
	private bool _closing; // 0xF9
	private bool _burst; // 0xFA
	private bool _starsOn; // 0xFB
	private bool _twinkle; // 0xFC
	private int _timelineId; // 0x100
	private int _twinkleId; // 0x104
	private int _fadeId; // 0x108
	private float _end; // 0x10C

	// Properties
	public bool IsShowing { get; } // 0x00000001807354F0-0x0000000180735650 
	public bool OkReady { get; } // 0x0000000180735650-0x0000000180735660 
	public Vector3 CenterWorld { get; } // 0x0000000180735660-0x0000000180735880 
	public ThanhTuuClaimResult Result { get; } // 0x0000000180735880-0x0000000180735890 

	// Nested types
	private struct StarSeed // TypeDefIndex: 1303
	{
		// Fields
		public Vector2 dir; // 0x00
		public float dist; // 0x08
		public float rot0; // 0x0C
		public float spin; // 0x10
		public float size; // 0x14
		public float delay; // 0x18
	}

	private sealed class Cell // TypeDefIndex: 1304
	{
		// Fields
		public RectTransform rt; // 0x10
		public Image icon; // 0x18
		public UnityEngine.UI.Text qty; // 0x20

		// Constructors
		public Cell(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public ThanhTuuRewardPopup(); // 0x000000018073BAD0-0x000000018073C000
	static ThanhTuuRewardPopup(); // 0x000000018073C000-0x000000018073C1D0

	// Methods
	public static ThanhTuuRewardPopup Build(MonoBehaviour host, RectTransform parent); // 0x0000000180735890-0x0000000180735BC0
	private void BuildBody(); // 0x0000000180735BC0-0x0000000180737490
	private static Image Fx(Transform parent, string name, Vector2 pos, float size); // 0x0000000180737490-0x0000000180737590
	private static StarSeed[] MakeSeed(); // 0x0000000180737590-0x0000000180737900
	public void Rebind(); // 0x0000000180737900-0x0000000180737BF0
	public void Show(ThanhTuuClaimResult result, Action onClosed); // 0x0000000180737BF0-0x0000000180738340
	public void Hide(); // 0x0000000180738340-0x0000000180738860
	public void OnOk(); // 0x0000000180738860-0x00000001807389F0
	private void Finish(); // 0x00000001807389F0-0x0000000180738B00
	private void OnTimelineDone(); // 0x0000000180738B00-0x0000000180738C10
	private void CancelTweens(); // 0x0000000180738C10-0x0000000180738C80
	private void OnDisable(); // 0x0000000180738C80-0x0000000180738C90
	private void LayoutRewards(RechargeEventReward granted); // 0x0000000180738C90-0x0000000180739A60
	private Cell EnsureCell(int i); // 0x0000000180739A60-0x000000018073A0C0
	public void PoseAt(float t); // 0x000000018073A0C0-0x000000018073B660
	private void PoseSparkles(float k); // 0x000000018073B660-0x000000018073BAD0
}

