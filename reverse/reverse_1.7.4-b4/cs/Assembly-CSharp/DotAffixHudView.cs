/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class DotAffixHudView : MonoBehaviour // TypeDefIndex: 2189
{
	// Fields
	private static readonly int IdleHash; // 0x00
	private static readonly Color PLATE; // 0x04
	private static readonly Color FRAME; // 0x14
	private static readonly Color RING; // 0x24
	private const float SLICE_MULT = 3f; // Metadata: 0x005F1B65
	private const float FADE_IN = 0.25f; // Metadata: 0x005F1B69
	private const float FADE_SWAP = 0.15f; // Metadata: 0x005F1B6D
	private const float FADE_OUT = 0.15f; // Metadata: 0x005F1B71
	private const float MOVE_SHARPNESS = 14f; // Metadata: 0x005F1B75
	private const float POP_SEC = 0.28f; // Metadata: 0x005F1B79
	private const float POP_FROM = 0.82f; // Metadata: 0x005F1B7D
	private const float RESCAN_SEC = 1.5f; // Metadata: 0x005F1B81
	private const float MAX_OBSTACLE_SHARE = 0.4f; // Metadata: 0x005F1B85
	private static readonly HashSet<string> HEADER_SKIP; // 0x38
	private const float PITY_MAX_SCALE = 1.35f; // Metadata: 0x005F1B89
	private static readonly string[] EXTRA_NODES; // 0x40
	private static readonly float[] SCALE_STEPS; // 0x48
	[CompilerGenerated]
	private SpriteRenderer _Host_k__BackingField; // 0x20
	[CompilerGenerated]
	private EntityId _HostId_k__BackingField; // 0x28
	[CompilerGenerated]
	private bool _SelfSide_k__BackingField; // 0x30
	[CompilerGenerated]
	private int _Actor_k__BackingField; // 0x34
	[CompilerGenerated]
	private bool _IsPreview_k__BackingField; // 0x38
	[CompilerGenerated]
	private bool _HasPlacement_k__BackingField; // 0x39
	[CompilerGenerated]
	private Rect _PlacedRect_k__BackingField; // 0x3C
	[CompilerGenerated]
	private float _PlacedScale_k__BackingField; // 0x4C
	[CompilerGenerated]
	private int _PlacedCols_k__BackingField; // 0x50
	[CompilerGenerated]
	private bool _PlacedTitle_k__BackingField; // 0x54
	[CompilerGenerated]
	private bool _PlacedClean_k__BackingField; // 0x55
	[CompilerGenerated]
	private float _PlacedOverlap_k__BackingField; // 0x58
	[CompilerGenerated]
	private Vector2 _HeadAnchor_k__BackingField; // 0x5C
	[CompilerGenerated]
	private int _LandedIndex_k__BackingField; // 0x64
	[CompilerGenerated]
	private bool _Revealing_k__BackingField; // 0x68
	private RectTransform _container; // 0x70
	private Canvas _rootCanvas; // 0x78
	private Animator _anim; // 0x80
	private RectTransform _rt; // 0x88
	private CanvasGroup _cg; // 0x90
	private UnityEngine.UI.Text _title; // 0x98
	private float _titleWidth; // 0xA0
	private bool _hasTitle; // 0xA4
	private readonly Chip[] _drop; // 0xA8
	private Chip _luck; // 0xB0
	private readonly List<Chip> _order; // 0xB8
	private int _layoutCols; // 0xC0
	private bool _layoutTitle; // 0xC4
	private RectTransform _hit; // 0xC8
	private const float HIT_PAD = 4f; // Metadata: 0x005F1B8D
	private const float TITLE_DROP_PENALTY = 10f; // Metadata: 0x005F1B91
	private readonly int[] _pct; // 0xD0
	private readonly int[] _readBuf; // 0xD8
	private int _luckIndex; // 0xE0
	private int _luckPct; // 0xE4
	private bool _hasData; // 0xE8
	private int _dataVersion; // 0xEC
	private string _titleText; // 0xF0
	private bool _haveHead; // 0xF8
	private bool _headFromIdle; // 0xF9
	private float _headMinX; // 0xFC
	private float _headMaxX; // 0x100
	private float _headTop; // 0x104
	private RuntimeAnimatorController _headCtrl; // 0x108
	private bool _headAnimOn; // 0x110
	private Sprite _headStaticSprite; // 0x118
	private int _scrW; // 0x120
	private int _scrH; // 0x124
	private float _settleUntil; // 0x128
	private readonly List<Rect> _obs; // 0x130
	private readonly List<ObstacleInfo> _obsInfo; // 0x138
	private readonly List<KeyValuePair<string, RectTransform>> _rtNodes; // 0x140
	private readonly List<KeyValuePair<string, List<Graphic>>> _groups; // 0x148
	private readonly List<Graphic> _graphicBuf; // 0x150
	private readonly List<DotAffixHudLayout.Variant> _variants; // 0x158
	private readonly Vector3[] _corners; // 0x160
	private RectTransform _board; // 0x168
	private RectTransform _selfBar; // 0x170
	private RectTransform _enemyBar; // 0x178
	private float _nextRescanAt; // 0x180
	private int _lastSolveHash; // 0x184
	private bool _wantVisible; // 0x188
	private float _alpha; // 0x18C
	private float _notBefore; // 0x190
	private bool _popping; // 0x194
	private float _popT; // 0x198
	private bool _revealDone; // 0x19C
	private Coroutine _reel; // 0x1A0
	private Vector2 _pos; // 0x1A8
	private Vector2 _targetPos; // 0x1B0
	private float _scale; // 0x1B8
	private float _targetScale; // 0x1BC
	private bool _snapNext; // 0x1C0
	private float _nextTickAt; // 0x1C4

	// Properties
	public SpriteRenderer Host { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public EntityId HostId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x0000000180A44280-0x0000000180A44290
	public bool SelfSide { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028CE40-0x000000018028CE50 0x000000018028CE50-0x000000018028CE60
	public int Actor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6C80-0x00000001803C6C90 0x00000001803C6C90-0x00000001803C6CA0
	public bool IsPreview { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808421B0-0x00000001808421C0 0x00000001808421C0-0x00000001808421D0
	public bool HasPlacement { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A44290-0x0000000180A442A0 0x0000000180A442A0-0x0000000180A442B0
	public Rect PlacedRect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A442B0-0x0000000180A442C0 0x0000000180A442C0-0x0000000180A442D0
	public float PlacedScale { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A442D0-0x0000000180A442E0 0x0000000180A442E0-0x0000000180A442F0
	public int PlacedCols { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6D00-0x00000001803C6D10 0x00000001803C6D10-0x00000001803C6D20
	public bool PlacedTitle { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A442F0-0x0000000180A44300 0x0000000180A44300-0x0000000180A44310
	public bool PlacedClean { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A44310-0x0000000180A44320 0x0000000180A44320-0x0000000180A44330
	public float PlacedOverlap { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E9000-0x00000001803E9010 0x00000001803E9010-0x00000001803E9020
	public Vector2 HeadAnchor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A44330-0x0000000180A44350 0x0000000180A44350-0x0000000180A44360
	public int LandedIndex { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802AE260-0x00000001802AE270 0x0000000180A44360-0x0000000180A44370
	public bool Revealing { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A44370-0x0000000180A44380 0x0000000180A44380-0x0000000180A44390
	public int EntryCount { get; } // 0x0000000180A44390-0x0000000180A443B0 
	public float Alpha { get; } // 0x0000000180A443B0-0x0000000180A44510 
	public bool WantVisible { get; } // 0x0000000180A44510-0x0000000180A44520 
	public RectTransform Container { get; } // 0x00000001803C6D50-0x00000001803C6D60 
	public Canvas RootCanvas { get; } // 0x00000001802A86B0-0x00000001802A86C0 
	public IReadOnlyList<ObstacleInfo> Obstacles { get; } // 0x0000000180A44520-0x0000000180A44530 
	public RectTransform HitArea { get; } // 0x00000001802D9080-0x00000001802D9090 
	public bool CanShowTip { get; } // 0x0000000180A4FFE0-0x0000000180A50140 
	internal int DataVersion { get; } // 0x00000001803C71A0-0x00000001803C71B0 
	internal string OwnerName { get; } // 0x0000000180A50140-0x0000000180A501A0 
	private Camera UiCamera { get; } // 0x0000000180A50700-0x0000000180A50820 

	// Nested types
	public struct ObstacleInfo // TypeDefIndex: 2190
	{
		// Fields
		public string name; // 0x00
		public Rect rect; // 0x08
	}

	private sealed class Chip // TypeDefIndex: 2191
	{
		// Fields
		public RectTransform root; // 0x10
		public Image icon; // 0x18
		public Image ring; // 0x20
		public Image star; // 0x28
		public UnityEngine.UI.Text text; // 0x30
		public bool hasIcon; // 0x38
		public float width; // 0x3C

		// Constructors
		public Chip(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _Reel_d__186 : IEnumerator<object> // TypeDefIndex: 2192
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DotAffixHudView __4__this; // 0x20
		public float reelSec; // 0x28
		public int target; // 0x2C
		private int _n_5__2; // 0x30
		private int _steps_5__3; // 0x34
		private int _start_5__4; // 0x38
		private float _waitUntil_5__5; // 0x3C
		private float _t_5__6; // 0x40
		private int _i_5__7; // 0x44
		private float _until_5__8; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Reel_d__186(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A52760-0x0000000180A532E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A532E0-0x0000000180A53320
	}

	// Constructors
	public DotAffixHudView(); // 0x0000000180A51800-0x0000000180A52160
	static DotAffixHudView(); // 0x0000000180A52160-0x0000000180A52760

	// Methods
	internal void Init(SpriteRenderer host, RectTransform container, Canvas rootCanvas, bool selfSide); // 0x0000000180A44530-0x0000000180A44C70
	internal void BindActor(int actor); // 0x0000000180A44C70-0x0000000180A44CE0
	internal void BindPreview(int[] pct, string luckyTag, int luckPct); // 0x0000000180A44CE0-0x0000000180A44E80
	private void BeginSwap(); // 0x0000000180A44E80-0x0000000180A450A0
	private void BuildNodes(); // 0x0000000180A450A0-0x0000000180A45700
	private Chip BuildChip(string name, int tagIndex, bool luck); // 0x0000000180A45700-0x0000000180A46330
	private void RefreshFromSnapshot(); // 0x0000000180A46330-0x0000000180A463F0
	private void ClearData(); // 0x0000000180A463F0-0x0000000180A46870
	private void ApplyData(int[] pct, int luckIndex, int luck, bool force); // 0x0000000180A46870-0x0000000180A47550
	private static void SetChipText(Chip c, string s); // 0x0000000180A47550-0x0000000180A47670
	public Vector2 SizeFor(int cols, bool title); // 0x0000000180A47670-0x0000000180A47870
	private void ApplyLayout(int cols, bool title); // 0x0000000180A47870-0x0000000180A47C80
	private void Update(); // 0x0000000180A47C80-0x0000000180A47E40
	private void Tick(float now); // 0x0000000180A47E40-0x0000000180A483B0
	private void ResetHead(); // 0x0000000180A483B0-0x0000000180A483D0
	private void SampleHead(bool hostVisible); // 0x0000000180A483D0-0x0000000180A48E00
	private static bool IsIdle(Animator a); // 0x0000000180A48E00-0x0000000180A48F70
	private void Rescan(); // 0x0000000180A48F70-0x0000000180A4A4A0
	private RectTransform ResolveBoardFallback(); // 0x0000000180A4A4A0-0x0000000180A4A8E0
	private void AddSlotGroups(Transform panel); // 0x0000000180A4A8E0-0x0000000180A4ADA0
	private void AddGroup(string name, Transform root); // 0x0000000180A4ADA0-0x0000000180A4AFC0
	private Rect CollectObstacles(); // 0x0000000180A4AFC0-0x0000000180A4BF80
	private void AddOverlayBar(string name, RectTransform bar, float margin, float maxArea); // 0x0000000180A4BF80-0x0000000180A4C390
	private void AddObstacle(string name, Rect r, float margin, float maxArea); // 0x0000000180A4C390-0x0000000180A4C6B0
	private Rect LocalRectOf(RectTransform rt); // 0x0000000180A4C6B0-0x0000000180A4C8D0
	private Rect OverlayRectUnscaled(RectTransform rt, float maxScale); // 0x0000000180A4C8D0-0x0000000180A4CF80
	private Rect OverlayRectToLocal(RectTransform rt); // 0x0000000180A4CF80-0x0000000180A4CFE0
	private Rect OverlayCornersToLocal(); // 0x0000000180A4CFE0-0x0000000180A4D3B0
	private void Solve(Rect screen); // 0x0000000180A4D3B0-0x0000000180A4DD10
	private void BuildVariants(); // 0x0000000180A4DD10-0x0000000180A4E320
	private int Hash(Vector2 anchor, Rect bounds); // 0x0000000180A4E320-0x0000000180A4E620
	private static int Q(float v); // 0x0000000180A4E620-0x0000000180A4E630
	private void BeginReveal(); // 0x0000000180A4E630-0x0000000180A4E9D0
	private void StopReel(); // 0x0000000180A4E9D0-0x0000000180A4ED80
	[IteratorStateMachine(typeof(_Reel_d__186))]
	private IEnumerator Reel(float reelSec, int target); // 0x0000000180A4ED80-0x0000000180A4EE40
	private void Animate(float dt); // 0x0000000180A4EE40-0x0000000180A4F690
	private static float EaseOutBack(float t); // 0x0000000180335460-0x00000001803354A0
	private void OnDestroy(); // 0x0000000180A4F690-0x0000000180A4F890
	private void BuildHitArea(); // 0x0000000180A4F890-0x0000000180A4FEF0
	internal void OnTap(); // 0x0000000180A4FEF0-0x0000000180A4FFE0
	internal void CopyData(int[] pct, out int luckIndex, out int luck); // 0x0000000180A501A0-0x0000000180A50220
	internal bool TryBoardLocalRect(out Rect board); // 0x0000000180A50220-0x0000000180A50560
	internal Rect ScreenLocalRect(); // 0x0000000180A50560-0x0000000180A50700
	internal Vector2 LocalToScreen(Vector2 local); // 0x0000000180A50820-0x0000000180A50950
	internal float PixelsPerHudUnit(); // 0x0000000180A50950-0x0000000180A50AD0
	internal bool HitContainsScreen(Vector2 screenPos); // 0x0000000180A50AD0-0x0000000180A50C20
	private static RectTransform NewRect(Transform parent, string name); // 0x0000000180A50C20-0x0000000180A50EC0
	private static Image NewImage(Transform parent, string name); // 0x0000000180A50EC0-0x0000000180A51290
	private static UnityEngine.UI.Text NewText(Transform parent, string name, int fontSize, Color color, TextAnchor anchor); // 0x0000000180A51290-0x0000000180A51800
	private static void Stretch(RectTransform rt); // 0x000000018079BBB0-0x000000018079BCA0
}

