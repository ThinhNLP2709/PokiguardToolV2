/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DefaultExecutionOrder(100)]
public class Dot : MonoBehaviour // TypeDefIndex: 1924
{
	// Fields
	[Header("Dot Properties")]
	public int column; // 0x20
	public int row; // 0x24
	public int previousColumn; // 0x28
	public int previousRow; // 0x2C
	public float targetX; // 0x30
	public float targetY; // 0x34
	public bool isMathched; // 0x38
	[Header("Swipe Settings")]
	public float swipeResit; // 0x3C
	public float swipeAngle; // 0x40
	private Board _board; // 0x48
	private BoardPVP _boardPVP; // 0x50
	private Active _active; // 0x58
	private ActivePVP _activePVP; // 0x60
	public GameObject otherDot; // 0x68
	private static float s_lastInputRefusedLogAt; // 0x00
	private const float INPUT_REFUSED_LOG_INTERVAL = 2f; // Metadata: 0x0068DC25
	public Vector2 firstTouchPosition; // 0x70
	public Vector2 finalTouchPosition; // 0x78
	private Vector2 tempPosition; // 0x80
	public int multiplier; // 0x88
	public TextMesh multiplierTextMesh; // 0x90
	internal Vector2 velocityX; // 0x98
	internal Vector2 velocityY; // 0xA0
	internal Vector2 positionSmoothVelocity; // 0xA8
	internal const float smoothTime = 0.055f; // Metadata: 0x0068DC29
	internal const float fallTime = 0.28f; // Metadata: 0x0068DC2D
	internal const float fallColWaveDelay = 0.008f; // Metadata: 0x0068DC31
	internal const float fallRowWaveDelay = 0.008f; // Metadata: 0x0068DC35
	private const float FALL_REF_CELLS = 4f; // Metadata: 0x0068DC39
	private const float LANDING_SQUASH_FULL_CELLS = 3f; // Metadata: 0x0068DC3D
	private const float LANDING_SQUASH_MIN_CELLS = 0.15f; // Metadata: 0x0068DC41
	[CompilerGenerated]
	private static float _FallGroupDurationSec_k__BackingField; // 0x04
	private bool _isFalling; // 0xB0
	private float _fallDelay; // 0xB4
	private float _fallDur; // 0xB8
	private float _fallElapsed; // 0xBC
	private Vector2 _fallStartPos; // 0xC0
	private Vector3 _baseScale; // 0xC8
	private bool _baseScaleCaptured; // 0xD4
	public GameObject originalPrefab; // 0xD8
	internal bool isPredictionSwap; // 0xE0
	internal int predictedTargetX; // 0xE4
	internal int predictedTargetY; // 0xE8
	internal float predictionStartTime; // 0xEC
	internal const float PREDICTION_TIMEOUT = 3.5f; // Metadata: 0x0068DC45
	private static bool s_turnTimerPausedForLocalDrag; // 0x08
	private static Dot s_dotMouseDownOn; // 0x10
	private static Dot s_tapSelectedDot; // 0x18
	private static Camera s_cachedMainCamera; // 0x20
	private static float s_mouseDownAt; // 0x28
	private const float DRAG_PAUSE_MIN_HOLD_SEC = 0.3f; // Metadata: 0x0068DC49
	private static bool s_moveSentThisRelease; // 0x2C
	private static int s_mouseFrame; // 0x30
	private static bool s_mouseHeld; // 0x34
	private static bool s_inputOpen; // 0x35
	private static int s_globalTickFrame; // 0x38
	internal static int SquashingCount; // 0x3C
	private const float SettleSqrEps = 0.0001f; // Metadata: 0x0068DC4D
	private int _settledFrames; // 0xF0
	private bool _squashing; // 0xF4
	private static int s_motionSleepFlag; // 0x40
	[CompilerGenerated]
	private string _PoolTag_k__BackingField; // 0xF8
	private Vector3 _spawnScale; // 0x100
	private bool _spawnScaleCaptured; // 0x10C
	private Renderer[] _renderCache; // 0x110
	private int _renderCacheChildCount; // 0x118
	private Collider2D _colliderCache; // 0x120
	private bool _colliderCached; // 0x128
	[CompilerGenerated]
	private bool _RenderHidden_k__BackingField; // 0x129

	// Properties
	private bool IsPVP { get; } // 0x00000001806F2090-0x00000001806F2150 
	private float CurrentTurnTime { get; } // 0x00000001806F1F70-0x00000001806F1FC0 
	private bool IsTurnInProgress { get; } // 0x00000001806F2150-0x00000001806F21A0 
	private int CurrentTurnPlayerActorNumber { get; } // 0x00000001806F1F20-0x00000001806F1F70 
	private int LocalActorNumber { get; } // 0x00000001806F21A0-0x00000001806F21F0 
	private GameState BoardCurrentState { get; } // 0x00000001806F1DA0-0x00000001806F1DE0 
	private bool BoardHasDestroyedThisTurn { get; } // 0x00000001806F1DE0-0x00000001806F1E30 
	private bool BoardIsProcessingUI { get; } // 0x00000001806F1E80-0x00000001806F1ED0 
	private int BoardWidth { get; } // 0x00000001806F1ED0-0x00000001806F1F20 
	private int BoardHeight { get; } // 0x00000001806F1E30-0x00000001806F1E80 
	private bool WsModeActive { get; } // 0x00000001806F24B0-0x00000001806F2600 
	private static bool WsModeActiveStatic { get; } // 0x00000001806F22F0-0x00000001806F24B0 
	internal static float FallGroupDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806F1FC0-0x00000001806F2010 0x00000001806F2600-0x00000001806F2660
	internal static bool MotionSleepEnabled { get; } // 0x00000001806F21F0-0x00000001806F22B0 
	internal string PoolTag { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806F22B0-0x00000001806F22C0 0x00000001806F2660-0x00000001806F2680
	internal Vector3 SpawnScale { get; } // 0x00000001806F22D0-0x00000001806F22F0 
	internal bool RenderHidden { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806F22C0-0x00000001806F22D0 0x00000001806F2680-0x00000001806F2690
	public static bool HasTapSelection { get; } // 0x00000001806F2010-0x00000001806F2090 

	// Constructors
	public Dot(); // 0x00000001806F1CB0-0x00000001806F1DA0
	static Dot(); // 0x00000001806F1C20-0x00000001806F1CB0

	// Methods
	private bool IsCurrentPlayerTurn(int actor); // 0x00000001806EE550-0x00000001806EE5C0
	private bool BoardIsPlayerAllowedToMove(); // 0x00000001806ED4C0-0x00000001806ED510
	private static void LogInputRefusedThrottled(string reason); // 0x00000001806EE940-0x00000001806EE9D0
	private void SetBoardState(GameState state); // 0x00000001806F01D0-0x00000001806F02B0
	private void RestoreBoardInputAfterRefusedMove(); // 0x00000001806EFE40-0x00000001806EFF00
	private GameObject GetAllDots(int col, int row); // 0x00000001806EE450-0x00000001806EE4F0
	private void RequestSwap(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001806EF800-0x00000001806EF930
	private static void TryPauseTurnTimerForDrag(); // 0x00000001806F0AD0-0x00000001806F0BC0
	private static void TryResumeTurnTimerAfterDrag(); // 0x00000001806F0BC0-0x00000001806F0CB0
	private static void ConsumeDragPauseWithoutSend(); // 0x00000001806EDDD0-0x00000001806EDE20
	internal static void BeginFallGroup(); // 0x00000001806ED3C0-0x00000001806ED450
	internal void WakeMotion(); // 0x00000001806F19B0-0x00000001806F19F0
	internal bool NeedsMotionTick(); // 0x00000001806EED90-0x00000001806EEE20
	internal static void TickGlobal(bool inputOpen); // 0x00000001806F0780-0x00000001806F0AD0
	private static bool MouseHeld(); // 0x00000001806EEA80-0x00000001806EEB50
	internal static void ResetStaticState(); // 0x00000001806EFCD0-0x00000001806EFE40
	private void Awake(); // 0x00000001806ED360-0x00000001806ED3C0
	internal void ResetForReuse(); // 0x00000001806EF930-0x00000001806EFCD0
	private void Start(); // 0x00000001806F04B0-0x00000001806F0780
	private void Update(); // 0x00000001806F17B0-0x00000001806F19B0
	private void LateUpdate(); // 0x00000001806EE770-0x00000001806EE780
	private Vector2 WorldTargetForGrid(int col, int row); // 0x00000001806F19F0-0x00000001806F1C20
	private void UpdatePositionAndMatches(); // 0x00000001806F1030-0x00000001806F17B0
	private void BeginSquash(); // 0x00000001806ED450-0x00000001806ED4C0
	private void EndSquash(); // 0x00000001806EDE20-0x00000001806EDEB0
	private float CellHeightWorld(); // 0x00000001806EDAF0-0x00000001806EDB80
	public void MarkFalling(); // 0x00000001806EE9D0-0x00000001806EEA80
	private void PlayLandingSquash(float dropDistance); // 0x00000001806EF1D0-0x00000001806EF470
	internal void PlayMatchTelegraph(); // 0x00000001806EF690-0x00000001806EF800
	internal void InvalidateRenderCache(); // 0x00000001806EE4F0-0x00000001806EE550
	internal void SetRenderVisible(bool visible); // 0x00000001806F02B0-0x00000001806F04B0
	private void OnDestroy(); // 0x00000001806EEE20-0x00000001806EEE90
	private bool UpdateBoardReference(); // 0x00000001806F0E20-0x00000001806F1030
	public bool IsMoving(); // 0x00000001806EE5C0-0x00000001806EE660
	private Vector2 ScreenToWorldOnDotPlane(); // 0x00000001806EFF00-0x00000001806F01D0
	private void OnMouseDown(); // 0x00000001806EEE90-0x00000001806EEFA0
	private void OnMouseUp(); // 0x00000001806EEFA0-0x00000001806EF1D0
	public bool CanInteract(); // 0x00000001806ED5A0-0x00000001806ED9B0
	private void CalculateAngle(); // 0x00000001806ED510-0x00000001806ED5A0
	private bool IsValidSwipe(); // 0x00000001806EE730-0x00000001806EE770
	private void MovePieces(); // 0x00000001806EEB50-0x00000001806EED90
	private void ExecuteSwapToNeighbor(int targetCol, int targetRow); // 0x00000001806EDEB0-0x00000001806EE450
	private bool LocalSwapCreatesMatch(int x1, int y1, int x2, int y2); // 0x00000001806EE780-0x00000001806EE940
	private void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x00000001806EF470-0x00000001806EF690
	private static void ClearTapSelection(); // 0x00000001806EDBC0-0x00000001806EDCB0
	public static void ClearTapSelectionStatic(); // 0x00000001806EDB80-0x00000001806EDBC0
	public static bool IsTapSelected(GameObject go); // 0x00000001806EE660-0x00000001806EE730
	private void AttemptTapSelectOrSwap(); // 0x00000001806ED0E0-0x00000001806ED360
	public void ConfirmPrediction(int newCol, int newRow); // 0x00000001806EDCB0-0x00000001806EDDD0
	public void CancelPrediction(); // 0x00000001806ED9B0-0x00000001806EDAF0
	[CompilerGenerated]
	private void _PlayLandingSquash_b__125_0(); // 0x00000001806F0CB0-0x00000001806F0E20
}

