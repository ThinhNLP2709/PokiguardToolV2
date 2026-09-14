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
public sealed class ThanhTuuRewardPopup : MonoBehaviour // TypeDefIndex: 1304
{
	// Fields
	public const float X = 477f; // Metadata: 0x005F0B37
	public const float Y = 250f; // Metadata: 0x005F0B3B
	public const float W = 820f; // Metadata: 0x005F0B3F
	public const float H = 480f; // Metadata: 0x005F0B43
	public const float BOX = 220f; // Metadata: 0x005F0B47
	public const float BOX_DY = -10f; // Metadata: 0x005F0B4B
	public const float GLOW = 360f; // Metadata: 0x005F0B4F
	public const float SWIRL = 560f; // Metadata: 0x005F0B53
	public const float STAR = 76f; // Metadata: 0x005F0B57
	public const float SPARKLE = 48f; // Metadata: 0x005F0B5B
	public const int STARS = 12; // Metadata: 0x005F0B5F
	public const float ICON_ONE = 110f; // Metadata: 0x005F0B60
	public const float ICON_MANY = 84f; // Metadata: 0x005F0B64
	public const float GRID_STEP = 104f; // Metadata: 0x005F0B68
	public const int PER_ROW = 6; // Metadata: 0x005F0B6C
	public const float GRID_DY = 20f; // Metadata: 0x005F0B6D
	public const int MAX_CELLS = 18; // Metadata: 0x005F0B71
	public const float OK_W = 190f; // Metadata: 0x005F0B72
	public const float OK_H = 120f; // Metadata: 0x005F0B76
	public const float OK_DY = -215f; // Metadata: 0x005F0B7A
	public const float OK_FONT = 30f; // Metadata: 0x005F0B7E
	public const float QTY_FONT = 24f; // Metadata: 0x005F0B82
	public const float T_DIM = 0.12f; // Metadata: 0x005F0B86
	public const float T_FRAME = 0.18f; // Metadata: 0x005F0B8A
	public const float T_BOX_IN = 0.1f; // Metadata: 0x005F0B8E
	public const float BOX_IN = 0.15f; // Metadata: 0x005F0B92
	public const float T_WOBBLE = 0.25f; // Metadata: 0x005F0B96
	public const float WOBBLE = 0.36f; // Metadata: 0x005F0B9A
	public const float WOBBLE_DEG = 4f; // Metadata: 0x005F0B9E
	public const float T_BURST = 0.5f; // Metadata: 0x005F0BA2
	public const float GLOW_TIME = 0.35f; // Metadata: 0x005F0BA6
	public const float FLASH_TIME = 0.2f; // Metadata: 0x005F0BAA
	public const float FLASH_ALPHA = 0.8f; // Metadata: 0x005F0BAE
	public const float T_BOX_OFF = 0.62f; // Metadata: 0x005F0BB2
	public const float T_STARS = 0.6f; // Metadata: 0x005F0BB6
	public const float SWIRL_TIME = 0.6f; // Metadata: 0x005F0BBA
	public const float STAR_TIME = 0.7f; // Metadata: 0x005F0BBE
	public const float SWIRL_DEG = 200f; // Metadata: 0x005F0BC2
	public const float T_REWARD = 0.62f; // Metadata: 0x005F0BC6
	public const float REWARD_POP = 0.25f; // Metadata: 0x005F0BCA
	public const float REWARD_STAGGER = 0.05f; // Metadata: 0x005F0BCE
	public const float REWARD_PEAK = 1.15f; // Metadata: 0x005F0BD2
	public const float T_OK = 0.9f; // Metadata: 0x005F0BD6
	public const float OK_FADE = 0.15f; // Metadata: 0x005F0BDA
	public const float TWINKLE = 0.6f; // Metadata: 0x005F0BDE
	public const float EDIT_POSE = 1.05f; // Metadata: 0x005F0BE2
	public const int SEED = 20260911; // Metadata: 0x005F0BE6
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
	public bool IsShowing { get; } // 0x00000001807372A0-0x0000000180737400 
	public bool OkReady { get; } // 0x0000000180737400-0x0000000180737410 
	public Vector3 CenterWorld { get; } // 0x0000000180737410-0x0000000180737630 
	public ThanhTuuClaimResult Result { get; } // 0x0000000180737630-0x0000000180737640 

	// Nested types
	private struct StarSeed // TypeDefIndex: 1305
	{
		// Fields
		public Vector2 dir; // 0x00
		public float dist; // 0x08
		public float rot0; // 0x0C
		public float spin; // 0x10
		public float size; // 0x14
		public float delay; // 0x18
	}

	private sealed class Cell // TypeDefIndex: 1306
	{
		// Fields
		public RectTransform rt; // 0x10
		public Image icon; // 0x18
		public UnityEngine.UI.Text qty; // 0x20

		// Constructors
		public Cell(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public ThanhTuuRewardPopup(); // 0x000000018073D880-0x000000018073DDB0
	static ThanhTuuRewardPopup(); // 0x000000018073DDB0-0x000000018073DF80

	// Methods
	public static ThanhTuuRewardPopup Build(MonoBehaviour host, RectTransform parent); // 0x0000000180737640-0x0000000180737970
	private void BuildBody(); // 0x0000000180737970-0x0000000180739240
	private static Image Fx(Transform parent, string name, Vector2 pos, float size); // 0x0000000180739240-0x0000000180739340
	private static StarSeed[] MakeSeed(); // 0x0000000180739340-0x00000001807396B0
	public void Rebind(); // 0x00000001807396B0-0x00000001807399A0
	public void Show(ThanhTuuClaimResult result, Action onClosed); // 0x00000001807399A0-0x000000018073A0F0
	public void Hide(); // 0x000000018073A0F0-0x000000018073A610
	public void OnOk(); // 0x000000018073A610-0x000000018073A7A0
	private void Finish(); // 0x000000018073A7A0-0x000000018073A8B0
	private void OnTimelineDone(); // 0x000000018073A8B0-0x000000018073A9C0
	private void CancelTweens(); // 0x000000018073A9C0-0x000000018073AA30
	private void OnDisable(); // 0x000000018073AA30-0x000000018073AA40
	private void LayoutRewards(RechargeEventReward granted); // 0x000000018073AA40-0x000000018073B810
	private Cell EnsureCell(int i); // 0x000000018073B810-0x000000018073BE70
	public void PoseAt(float t); // 0x000000018073BE70-0x000000018073D410
	private void PoseSparkles(float k); // 0x000000018073D410-0x000000018073D880
}

