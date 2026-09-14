/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DefaultExecutionOrder(100)]
public class Dot : MonoBehaviour // TypeDefIndex: 2297
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
	private const float INPUT_REFUSED_LOG_INTERVAL = 2f; // Metadata: 0x005F1E69
	public Vector2 firstTouchPosition; // 0x70
	public Vector2 finalTouchPosition; // 0x78
	private Vector2 tempPosition; // 0x80
	public int multiplier; // 0x88
	public TextMesh multiplierTextMesh; // 0x90
	internal Vector2 velocityX; // 0x98
	internal Vector2 velocityY; // 0xA0
	internal Vector2 positionSmoothVelocity; // 0xA8
	internal const float smoothTime = 0.055f; // Metadata: 0x005F1E6D
	internal const float fallTime = 0.28f; // Metadata: 0x005F1E71
	internal const float fallColWaveDelay = 0.008f; // Metadata: 0x005F1E75
	internal const float fallRowWaveDelay = 0.008f; // Metadata: 0x005F1E79
	private const float FALL_REF_CELLS = 4f; // Metadata: 0x005F1E7D
	private const float LANDING_SQUASH_FULL_CELLS = 3f; // Metadata: 0x005F1E81
	private const float LANDING_SQUASH_MIN_CELLS = 0.15f; // Metadata: 0x005F1E85
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
	internal const float PREDICTION_TIMEOUT = 3.5f; // Metadata: 0x005F1E89
	private static bool s_turnTimerPausedForLocalDrag; // 0x08
	private static Dot s_dotMouseDownOn; // 0x10
	private static Dot s_tapSelectedDot; // 0x18
	private static Camera s_cachedMainCamera; // 0x20
	private static float s_mouseDownAt; // 0x28
	private const float DRAG_PAUSE_MIN_HOLD_SEC = 0.3f; // Metadata: 0x005F1E8D
	private static bool s_moveSentThisRelease; // 0x2C
	private bool _pressAccepted; // 0xF0
	private int _pressFingerId; // 0xF4
	private static int s_mouseFrame; // 0x30
	private static bool s_mouseHeld; // 0x34
	private static bool s_inputOpen; // 0x35
	private static int s_globalTickFrame; // 0x38
	internal static int SquashingCount; // 0x3C
	private const float SettleSqrEps = 0.0001f; // Metadata: 0x005F1E91
	private int _settledFrames; // 0xF8
	private bool _squashing; // 0xFC
	private static int s_motionSleepFlag; // 0x40
	[CompilerGenerated]
	private string _PoolTag_k__BackingField; // 0x100
	private Vector3 _spawnScale; // 0x108
	private bool _spawnScaleCaptured; // 0x114
	private Renderer[] _renderCache; // 0x118
	private int _renderCacheChildCount; // 0x120
	private Collider2D _colliderCache; // 0x128
	private bool _colliderCached; // 0x130
	[CompilerGenerated]
	private bool _RenderHidden_k__BackingField; // 0x131

	// Properties
	private bool IsPVP { get; } // 0x0000000180AE7980-0x0000000180AE7AE0 
	private float CurrentTurnTime { get; } // 0x0000000180AE7AE0-0x0000000180AE7B20 
	private bool IsTurnInProgress { get; } // 0x0000000180AE7B90-0x0000000180AE7BE0 
	private int CurrentTurnPlayerActorNumber { get; } // 0x0000000180AE7BE0-0x0000000180AE7C30 
	private int LocalActorNumber { get; } // 0x0000000180AE7C30-0x0000000180AE7C90 
	private GameState BoardCurrentState { get; } // 0x0000000180AE7CE0-0x0000000180AE7D20 
	private bool BoardHasDestroyedThisTurn { get; } // 0x0000000180AE81E0-0x0000000180AE8230 
	private bool BoardIsProcessingUI { get; } // 0x0000000180AE8230-0x0000000180AE8280 
	private int BoardWidth { get; } // 0x0000000180AE8280-0x0000000180AE82D0 
	private int BoardHeight { get; } // 0x0000000180AE82D0-0x0000000180AE8320 
	private bool WsModeActive { get; } // 0x0000000180AE83C0-0x0000000180AE8500 
	private static bool WsModeActiveStatic { get; } // 0x0000000180AE85F0-0x0000000180AE8820 
	internal static float FallGroupDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180AE89E0-0x0000000180AE8A40 0x0000000180AE8A40-0x0000000180AE8AB0
	internal static bool MotionSleepEnabled { get; } // 0x0000000180AE8B00-0x0000000180AE8BD0 
	internal string PoolTag { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802B4A40-0x00000001802B4A50 0x00000001802B4AF0-0x00000001802B4B50
	internal Vector3 SpawnScale { get; } // 0x0000000180AE9680-0x0000000180AE96A0 
	internal bool RenderHidden { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180AEBD80-0x0000000180AEBD90 0x0000000180AEBD90-0x0000000180AEBDA0
	public static bool HasTapSelection { get; } // 0x0000000180AEF410-0x0000000180AEF530 

	// Constructors
	public Dot(); // 0x0000000180AEFE40-0x0000000180AEFF70
	static Dot(); // 0x0000000180AEFF70-0x0000000180AF0010

	// Methods
	private bool IsCurrentPlayerTurn(int actor); // 0x0000000180AE7B20-0x0000000180AE7B90
	private bool BoardIsPlayerAllowedToMove(); // 0x0000000180AE7C90-0x0000000180AE7CE0
	private static void LogInputRefusedThrottled(string reason); // 0x0000000180AE7D20-0x0000000180AE7E20
	private void SetBoardState(GameState state); // 0x0000000180AE7E20-0x0000000180AE8010
	private void RestoreBoardInputAfterRefusedMove(); // 0x0000000180AE8010-0x0000000180AE81E0
	private GameObject GetAllDots(int col, int row); // 0x0000000180AE8320-0x0000000180AE83C0
	private void RequestSwap(int fromCol, int fromRow, int toCol, int toRow); // 0x0000000180AE8500-0x0000000180AE85F0
	private static void TryPauseTurnTimerForDrag(); // 0x0000000180AE8820-0x0000000180AE88D0
	private static void TryResumeTurnTimerAfterDrag(); // 0x0000000180AE88D0-0x0000000180AE8980
	private static void ConsumeDragPauseWithoutSend(); // 0x0000000180AE8980-0x0000000180AE89E0
	internal static void BeginFallGroup(); // 0x0000000180AE8AB0-0x0000000180AE8B00
	internal void WakeMotion(); // 0x0000000180AE8BD0-0x0000000180AE8CA0
	internal bool NeedsMotionTick(); // 0x0000000180AE8CA0-0x0000000180AE8DA0
	internal static void TickGlobal(bool inputOpen); // 0x0000000180AE8DA0-0x0000000180AE92B0
	private static bool MouseHeld(); // 0x0000000180AE92B0-0x0000000180AE9430
	internal static void ResetStaticState(); // 0x0000000180AE9430-0x0000000180AE9680
	private void Awake(); // 0x0000000180AE96A0-0x0000000180AE9760
	internal void ResetForReuse(); // 0x0000000180AE9760-0x0000000180AE9E50
	private void Start(); // 0x0000000180AE9E50-0x0000000180AEA320
	private void Update(); // 0x0000000180AEA320-0x0000000180AEA5D0
	private void LateUpdate(); // 0x0000000180AEA5D0-0x0000000180AEA5E0
	private Vector2 WorldTargetForGrid(int col, int row); // 0x0000000180AEA5E0-0x0000000180AEA9D0
	private void UpdatePositionAndMatches(); // 0x0000000180AEA9D0-0x0000000180AEB370
	private void BeginSquash(); // 0x0000000180AEB370-0x0000000180AEB3E0
	private void EndSquash(); // 0x0000000180AEB3E0-0x0000000180AEB470
	internal void CancelVisualTweens(); // 0x0000000180AEB470-0x0000000180AEB5C0
	private float CellHeightWorld(); // 0x0000000180AEB5C0-0x0000000180AEB650
	public void MarkFalling(); // 0x0000000180AEB650-0x0000000180AEB750
	private void PlayLandingSquash(float dropDistance); // 0x0000000180AEB750-0x0000000180AEBB10
	internal void PlayMatchTelegraph(); // 0x0000000180AEBB10-0x0000000180AEBD80
	internal void InvalidateRenderCache(); // 0x0000000180AEBDA0-0x0000000180AEBE80
	internal void SetRenderVisible(bool visible); // 0x0000000180AEBE80-0x0000000180AEC2F0
	private void OnDestroy(); // 0x0000000180AEC2F0-0x0000000180AEC3B0
	private bool UpdateBoardReference(); // 0x0000000180AEC3B0-0x0000000180AEC820
	public bool IsMoving(); // 0x0000000180AEC820-0x0000000180AEC990
	private Vector2 ScreenToWorldOnDotPlane(); // 0x0000000180AEC990-0x0000000180AECA90
	private Vector2 ScreenToWorldOnDotPlane(Vector3 screenPos); // 0x0000000180AECA90-0x0000000180AED000
	private bool TryGetReleaseWorldPosition(int fingerId, out Vector2 world); // 0x0000000180AED000-0x0000000180AED170
	private void OnMouseDown(); // 0x0000000180AED170-0x0000000180AED3B0
	private void OnMouseUp(); // 0x0000000180AED3B0-0x0000000180AED870
	public bool CanInteract(); // 0x0000000180AED870-0x0000000180AEDDD0
	private void CalculateAngle(); // 0x0000000180AEDDD0-0x0000000180AEDE60
	private bool IsValidSwipe(); // 0x0000000180AEDE60-0x0000000180AEDEA0
	private void MovePieces(); // 0x0000000180AEDEA0-0x0000000180AEE100
	private void ExecuteSwapToNeighbor(int targetCol, int targetRow); // 0x0000000180AEE100-0x0000000180AEE8F0
	private bool LocalSwapCreatesMatch(int x1, int y1, int x2, int y2); // 0x0000000180AEE8F0-0x0000000180AEEBB0
	private void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180AEEBB0-0x0000000180AEF210
	private static void ClearTapSelection(); // 0x0000000180AEF210-0x0000000180AEF3C0
	public static void ClearTapSelectionStatic(); // 0x0000000180AEF3C0-0x0000000180AEF410
	public static bool IsTapSelected(GameObject go); // 0x0000000180AEF530-0x0000000180AEF7D0
	private void AttemptTapSelectOrSwap(); // 0x0000000180AEF7D0-0x0000000180AEFBB0
	public void ConfirmPrediction(int newCol, int newRow); // 0x0000000180AEFBB0-0x0000000180AEFCC0
	public void CancelPrediction(); // 0x0000000180AEFCC0-0x0000000180AEFE40
	[CompilerGenerated]
	private void _PlayLandingSquash_b__128_0(); // 0x0000000180AF0010-0x0000000180AF0290
}

