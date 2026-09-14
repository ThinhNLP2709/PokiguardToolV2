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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DotAffixHudView : MonoBehaviour // TypeDefIndex: 2187
{
	// Fields
	private static readonly int IdleHash; // 0x00
	private static readonly Color PLATE; // 0x04
	private static readonly Color FRAME; // 0x14
	private static readonly Color RING; // 0x24
	private const float SLICE_MULT = 3f; // Metadata: 0x005F0794
	private const float FADE_IN = 0.25f; // Metadata: 0x005F0798
	private const float FADE_SWAP = 0.15f; // Metadata: 0x005F079C
	private const float FADE_OUT = 0.15f; // Metadata: 0x005F07A0
	private const float MOVE_SHARPNESS = 14f; // Metadata: 0x005F07A4
	private const float POP_SEC = 0.28f; // Metadata: 0x005F07A8
	private const float POP_FROM = 0.82f; // Metadata: 0x005F07AC
	private const float RESCAN_SEC = 1.5f; // Metadata: 0x005F07B0
	private const float MAX_OBSTACLE_SHARE = 0.4f; // Metadata: 0x005F07B4
	private static readonly HashSet<string> HEADER_SKIP; // 0x38
	private const float PITY_MAX_SCALE = 1.35f; // Metadata: 0x005F07B8
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
	private const float TITLE_DROP_PENALTY = 10f; // Metadata: 0x005F07BC
	private readonly int[] _pct; // 0xC8
	private readonly int[] _readBuf; // 0xD0
	private int _luckIndex; // 0xD8
	private int _luckPct; // 0xDC
	private bool _hasData; // 0xE0
	private int _dataVersion; // 0xE4
	private string _titleText; // 0xE8
	private bool _haveHead; // 0xF0
	private bool _headFromIdle; // 0xF1
	private float _headMinX; // 0xF4
	private float _headMaxX; // 0xF8
	private float _headTop; // 0xFC
	private RuntimeAnimatorController _headCtrl; // 0x100
	private bool _headAnimOn; // 0x108
	private Sprite _headStaticSprite; // 0x110
	private int _scrW; // 0x118
	private int _scrH; // 0x11C
	private float _settleUntil; // 0x120
	private readonly List<Rect> _obs; // 0x128
	private readonly List<ObstacleInfo> _obsInfo; // 0x130
	private readonly List<KeyValuePair<string, RectTransform>> _rtNodes; // 0x138
	private readonly List<KeyValuePair<string, List<Graphic>>> _groups; // 0x140
	private readonly List<Graphic> _graphicBuf; // 0x148
	private readonly List<DotAffixHudLayout.Variant> _variants; // 0x150
	private readonly Vector3[] _corners; // 0x158
	private RectTransform _board; // 0x160
	private RectTransform _selfBar; // 0x168
	private RectTransform _enemyBar; // 0x170
	private float _nextRescanAt; // 0x178
	private int _lastSolveHash; // 0x17C
	private bool _wantVisible; // 0x180
	private float _alpha; // 0x184
	private float _notBefore; // 0x188
	private bool _popping; // 0x18C
	private float _popT; // 0x190
	private bool _revealDone; // 0x194
	private Coroutine _reel; // 0x198
	private Vector2 _pos; // 0x1A0
	private Vector2 _targetPos; // 0x1A8
	private float _scale; // 0x1B0
	private float _targetScale; // 0x1B4
	private bool _snapNext; // 0x1B8
	private float _nextTickAt; // 0x1BC

	// Properties
	public SpriteRenderer Host { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public EntityId HostId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x0000000180A78980-0x0000000180A78990
	public bool SelfSide { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028CE40-0x000000018028CE50 0x000000018028CE50-0x000000018028CE60
	public int Actor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5FB0-0x00000001803C5FC0 0x00000001803C5FC0-0x00000001803C5FD0
	public bool IsPreview { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018083FF90-0x000000018083FFA0 0x000000018083FFA0-0x000000018083FFB0
	public bool HasPlacement { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A78990-0x0000000180A789A0 0x0000000180A789A0-0x0000000180A789B0
	public Rect PlacedRect { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A789B0-0x0000000180A789C0 0x0000000180A789C0-0x0000000180A789D0
	public float PlacedScale { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A789D0-0x0000000180A789E0 0x0000000180A789E0-0x0000000180A789F0
	public int PlacedCols { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6030-0x00000001803C6040 0x00000001803C6040-0x00000001803C6050
	public bool PlacedTitle { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A789F0-0x0000000180A78A00 0x0000000180A78A00-0x0000000180A78A10
	public bool PlacedClean { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A78A10-0x0000000180A78A20 0x0000000180A78A20-0x0000000180A78A30
	public float PlacedOverlap { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803E82C0-0x00000001803E82D0 0x00000001803E82D0-0x00000001803E82E0
	public Vector2 HeadAnchor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A78A30-0x0000000180A78A50 0x0000000180A78A50-0x0000000180A78A60
	public int LandedIndex { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802AE260-0x00000001802AE270 0x0000000180A78A60-0x0000000180A78A70
	public bool Revealing { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A78A70-0x0000000180A78A80 0x0000000180A78A80-0x0000000180A78A90
	public int EntryCount { get; } // 0x0000000180A78A90-0x0000000180A78AB0 
	public float Alpha { get; } // 0x0000000180A78AB0-0x0000000180A78C10 
	public bool WantVisible { get; } // 0x0000000180A78C10-0x0000000180A78C20 
	public RectTransform Container { get; } // 0x00000001803C6080-0x00000001803C6090 
	public Canvas RootCanvas { get; } // 0x00000001802A86B0-0x00000001802A86C0 
	public IReadOnlyList<ObstacleInfo> Obstacles { get; } // 0x0000000180A78C20-0x0000000180A78C30 

	// Nested types
	public struct ObstacleInfo // TypeDefIndex: 2188
	{
		// Fields
		public string name; // 0x00
		public Rect rect; // 0x08
	}

	private sealed class Chip // TypeDefIndex: 2189
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
	private sealed class _Reel_d__182 : IEnumerator<object> // TypeDefIndex: 2190
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
		public _Reel_d__182(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A859E0-0x0000000180A86560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A86560-0x0000000180A865A0
	}

	// Constructors
	public DotAffixHudView(); // 0x0000000180A84A80-0x0000000180A853E0
	static DotAffixHudView(); // 0x0000000180A853E0-0x0000000180A859E0

	// Methods
	internal void Init(SpriteRenderer host, RectTransform container, Canvas rootCanvas, bool selfSide); // 0x0000000180A78C30-0x0000000180A79360
	internal void BindActor(int actor); // 0x0000000180A79360-0x0000000180A793D0
	internal void BindPreview(int[] pct, string luckyTag, int luckPct); // 0x0000000180A793D0-0x0000000180A79570
	private void BeginSwap(); // 0x0000000180A79570-0x0000000180A79760
	private void BuildNodes(); // 0x0000000180A79760-0x0000000180A79E30
	private Chip BuildChip(string name, int tagIndex, bool luck); // 0x0000000180A79E30-0x0000000180A7AAE0
	private void RefreshFromSnapshot(); // 0x0000000180A7AAE0-0x0000000180A7ABA0
	private void ClearData(); // 0x0000000180A7ABA0-0x0000000180A7B020
	private void ApplyData(int[] pct, int luckIndex, int luck, bool force); // 0x0000000180A7B020-0x0000000180A7BD00
	private static void SetChipText(Chip c, string s); // 0x0000000180A7BD00-0x0000000180A7BE20
	public Vector2 SizeFor(int cols, bool title); // 0x0000000180A7BE20-0x0000000180A7C020
	private void ApplyLayout(int cols, bool title); // 0x0000000180A7C020-0x0000000180A7C430
	private void Update(); // 0x0000000180A7C430-0x0000000180A7C5F0
	private void Tick(float now); // 0x0000000180A7C5F0-0x0000000180A7CBB0
	private void ResetHead(); // 0x0000000180A7CBB0-0x0000000180A7CBD0
	private void SampleHead(bool hostVisible); // 0x0000000180A7CBD0-0x0000000180A7D600
	private static bool IsIdle(Animator a); // 0x0000000180A7D600-0x0000000180A7D770
	private void Rescan(); // 0x0000000180A7D770-0x0000000180A7ECA0
	private RectTransform ResolveBoardFallback(); // 0x0000000180A7ECA0-0x0000000180A7F0E0
	private void AddSlotGroups(Transform panel); // 0x0000000180A7F0E0-0x0000000180A7F5A0
	private void AddGroup(string name, Transform root); // 0x0000000180A7F5A0-0x0000000180A7F7C0
	private Rect CollectObstacles(); // 0x0000000180A7F7C0-0x0000000180A80780
	private void AddOverlayBar(string name, RectTransform bar, float margin, float maxArea); // 0x0000000180A80780-0x0000000180A80B90
	private void AddObstacle(string name, Rect r, float margin, float maxArea); // 0x0000000180A80B90-0x0000000180A80EB0
	private Rect LocalRectOf(RectTransform rt); // 0x0000000180A80EB0-0x0000000180A810D0
	private Rect OverlayRectUnscaled(RectTransform rt, float maxScale); // 0x0000000180A810D0-0x0000000180A81780
	private Rect OverlayRectToLocal(RectTransform rt); // 0x0000000180A81780-0x0000000180A817E0
	private Rect OverlayCornersToLocal(); // 0x0000000180A817E0-0x0000000180A81BB0
	private void Solve(Rect screen); // 0x0000000180A81BB0-0x0000000180A82510
	private void BuildVariants(); // 0x0000000180A82510-0x0000000180A82B20
	private int Hash(Vector2 anchor, Rect bounds); // 0x0000000180A82B20-0x0000000180A82E20
	private static int Q(float v); // 0x0000000180A82E20-0x0000000180A82E30
	private void BeginReveal(); // 0x0000000180A82E30-0x0000000180A831D0
	private void StopReel(); // 0x0000000180A831D0-0x0000000180A83580
	[IteratorStateMachine(typeof(_Reel_d__182))]
	private IEnumerator Reel(float reelSec, int target); // 0x0000000180A83580-0x0000000180A83640
	private void Animate(float dt); // 0x0000000180A83640-0x0000000180A83CD0
	private static float EaseOutBack(float t); // 0x0000000180335340-0x0000000180335380
	private void OnDestroy(); // 0x0000000180A83CD0-0x0000000180A83EA0
	private static RectTransform NewRect(Transform parent, string name); // 0x0000000180A83EA0-0x0000000180A84140
	private static Image NewImage(Transform parent, string name); // 0x0000000180A84140-0x0000000180A84510
	private static UnityEngine.UI.Text NewText(Transform parent, string name, int fontSize, Color color, TextAnchor anchor); // 0x0000000180A84510-0x0000000180A84A80
	private static void Stretch(RectTransform rt); // 0x0000000180799B40-0x0000000180799C30
}

