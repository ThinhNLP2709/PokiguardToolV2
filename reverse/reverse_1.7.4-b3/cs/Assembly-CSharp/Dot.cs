/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DefaultExecutionOrder(100)]
public class Dot : MonoBehaviour // TypeDefIndex: 2290
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
	private const float INPUT_REFUSED_LOG_INTERVAL = 2f; // Metadata: 0x005F0A52
	public Vector2 firstTouchPosition; // 0x70
	public Vector2 finalTouchPosition; // 0x78
	private Vector2 tempPosition; // 0x80
	public int multiplier; // 0x88
	public TextMesh multiplierTextMesh; // 0x90
	internal Vector2 velocityX; // 0x98
	internal Vector2 velocityY; // 0xA0
	internal Vector2 positionSmoothVelocity; // 0xA8
	internal const float smoothTime = 0.055f; // Metadata: 0x005F0A56
	internal const float fallTime = 0.28f; // Metadata: 0x005F0A5A
	internal const float fallColWaveDelay = 0.008f; // Metadata: 0x005F0A5E
	internal const float fallRowWaveDelay = 0.008f; // Metadata: 0x005F0A62
	private const float FALL_REF_CELLS = 4f; // Metadata: 0x005F0A66
	private const float LANDING_SQUASH_FULL_CELLS = 3f; // Metadata: 0x005F0A6A
	private const float LANDING_SQUASH_MIN_CELLS = 0.15f; // Metadata: 0x005F0A6E
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
	internal const float PREDICTION_TIMEOUT = 3.5f; // Metadata: 0x005F0A72
	private static bool s_turnTimerPausedForLocalDrag; // 0x08
	private static Dot s_dotMouseDownOn; // 0x10
	private static Dot s_tapSelectedDot; // 0x18
	private static Camera s_cachedMainCamera; // 0x20
	private static float s_mouseDownAt; // 0x28
	private const float DRAG_PAUSE_MIN_HOLD_SEC = 0.3f; // Metadata: 0x005F0A76
	private static bool s_moveSentThisRelease; // 0x2C
	private static int s_mouseFrame; // 0x30
	private static bool s_mouseHeld; // 0x34
	private static bool s_inputOpen; // 0x35
	private static int s_globalTickFrame; // 0x38
	internal static int SquashingCount; // 0x3C
	private const float SettleSqrEps = 0.0001f; // Metadata: 0x005F0A7A
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
	private bool IsPVP { get; } // 0x0000000180ADAB30-0x0000000180ADAC90 
	private float CurrentTurnTime { get; } // 0x0000000180ADAC90-0x0000000180ADACD0 
	private bool IsTurnInProgress { get; } // 0x0000000180ADAD40-0x0000000180ADAD90 
	private int CurrentTurnPlayerActorNumber { get; } // 0x0000000180ADAD90-0x0000000180ADADE0 
	private int LocalActorNumber { get; } // 0x0000000180ADADE0-0x0000000180ADAE40 
	private GameState BoardCurrentState { get; } // 0x0000000180ADAE90-0x0000000180ADAED0 
	private bool BoardHasDestroyedThisTurn { get; } // 0x0000000180ADB390-0x0000000180ADB3E0 
	private bool BoardIsProcessingUI { get; } // 0x0000000180ADB3E0-0x0000000180ADB430 
	private int BoardWidth { get; } // 0x0000000180ADB430-0x0000000180ADB480 
	private int BoardHeight { get; } // 0x0000000180ADB480-0x0000000180ADB4D0 
	private bool WsModeActive { get; } // 0x0000000180ADB570-0x0000000180ADB6B0 
	private static bool WsModeActiveStatic { get; } // 0x0000000180ADB7A0-0x0000000180ADB9D0 
	internal static float FallGroupDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180ADBB90-0x0000000180ADBBF0 0x0000000180ADBBF0-0x0000000180ADBC60
	internal static bool MotionSleepEnabled { get; } // 0x0000000180ADBCB0-0x0000000180ADBD80 
	internal string PoolTag { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180551000-0x0000000180551010 0x00000001803752E0-0x00000001803753C0
	internal Vector3 SpawnScale { get; } // 0x0000000180ADC830-0x0000000180ADC850 
	internal bool RenderHidden { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180ADEF20-0x0000000180ADEF30 0x0000000180ADEF30-0x0000000180ADEF40
	public static bool HasTapSelection { get; } // 0x0000000180AE21B0-0x0000000180AE22D0 

	// Constructors
	public Dot(); // 0x0000000180AE2BE0-0x0000000180AE2D00
	static Dot(); // 0x0000000180AE2D00-0x0000000180AE2DA0

	// Methods
	private bool IsCurrentPlayerTurn(int actor); // 0x0000000180ADACD0-0x0000000180ADAD40
	private bool BoardIsPlayerAllowedToMove(); // 0x0000000180ADAE40-0x0000000180ADAE90
	private static void LogInputRefusedThrottled(string reason); // 0x0000000180ADAED0-0x0000000180ADAFD0
	private void SetBoardState(GameState state); // 0x0000000180ADAFD0-0x0000000180ADB1C0
	private void RestoreBoardInputAfterRefusedMove(); // 0x0000000180ADB1C0-0x0000000180ADB390
	private GameObject GetAllDots(int col, int row); // 0x0000000180ADB4D0-0x0000000180ADB570
	private void RequestSwap(int fromCol, int fromRow, int toCol, int toRow); // 0x0000000180ADB6B0-0x0000000180ADB7A0
	private static void TryPauseTurnTimerForDrag(); // 0x0000000180ADB9D0-0x0000000180ADBA80
	private static void TryResumeTurnTimerAfterDrag(); // 0x0000000180ADBA80-0x0000000180ADBB30
	private static void ConsumeDragPauseWithoutSend(); // 0x0000000180ADBB30-0x0000000180ADBB90
	internal static void BeginFallGroup(); // 0x0000000180ADBC60-0x0000000180ADBCB0
	internal void WakeMotion(); // 0x0000000180ADBD80-0x0000000180ADBE50
	internal bool NeedsMotionTick(); // 0x0000000180ADBE50-0x0000000180ADBF50
	internal static void TickGlobal(bool inputOpen); // 0x0000000180ADBF50-0x0000000180ADC460
	private static bool MouseHeld(); // 0x0000000180ADC460-0x0000000180ADC5E0
	internal static void ResetStaticState(); // 0x0000000180ADC5E0-0x0000000180ADC830
	private void Awake(); // 0x0000000180ADC850-0x0000000180ADC910
	internal void ResetForReuse(); // 0x0000000180ADC910-0x0000000180ADCFF0
	private void Start(); // 0x0000000180ADCFF0-0x0000000180ADD4C0
	private void Update(); // 0x0000000180ADD4C0-0x0000000180ADD770
	private void LateUpdate(); // 0x0000000180ADD770-0x0000000180ADD780
	private Vector2 WorldTargetForGrid(int col, int row); // 0x0000000180ADD780-0x0000000180ADDB70
	private void UpdatePositionAndMatches(); // 0x0000000180ADDB70-0x0000000180ADE510
	private void BeginSquash(); // 0x0000000180ADE510-0x0000000180ADE580
	private void EndSquash(); // 0x0000000180ADE580-0x0000000180ADE610
	internal void CancelVisualTweens(); // 0x0000000180ADE610-0x0000000180ADE760
	private float CellHeightWorld(); // 0x0000000180ADE760-0x0000000180ADE7F0
	public void MarkFalling(); // 0x0000000180ADE7F0-0x0000000180ADE8F0
	private void PlayLandingSquash(float dropDistance); // 0x0000000180ADE8F0-0x0000000180ADECB0
	internal void PlayMatchTelegraph(); // 0x0000000180ADECB0-0x0000000180ADEF20
	internal void InvalidateRenderCache(); // 0x0000000180ADEF40-0x0000000180ADF020
	internal void SetRenderVisible(bool visible); // 0x0000000180ADF020-0x0000000180ADF490
	private void OnDestroy(); // 0x0000000180ADF490-0x0000000180ADF550
	private bool UpdateBoardReference(); // 0x0000000180ADF550-0x0000000180ADF9C0
	public bool IsMoving(); // 0x0000000180ADF9C0-0x0000000180ADFB30
	private Vector2 ScreenToWorldOnDotPlane(); // 0x0000000180ADFB30-0x0000000180AE0140
	private void OnMouseDown(); // 0x0000000180AE0140-0x0000000180AE02D0
	private void OnMouseUp(); // 0x0000000180AE02D0-0x0000000180AE0610
	public bool CanInteract(); // 0x0000000180AE0610-0x0000000180AE0B70
	private void CalculateAngle(); // 0x0000000180AE0B70-0x0000000180AE0C00
	private bool IsValidSwipe(); // 0x0000000180AE0C00-0x0000000180AE0C40
	private void MovePieces(); // 0x0000000180AE0C40-0x0000000180AE0EA0
	private void ExecuteSwapToNeighbor(int targetCol, int targetRow); // 0x0000000180AE0EA0-0x0000000180AE1690
	private bool LocalSwapCreatesMatch(int x1, int y1, int x2, int y2); // 0x0000000180AE1690-0x0000000180AE1950
	private void PlayLocalInvalidSwapFeedback(int fc, int fr, int tc, int tr); // 0x0000000180AE1950-0x0000000180AE1FB0
	private static void ClearTapSelection(); // 0x0000000180AE1FB0-0x0000000180AE2160
	public static void ClearTapSelectionStatic(); // 0x0000000180AE2160-0x0000000180AE21B0
	public static bool IsTapSelected(GameObject go); // 0x0000000180AE22D0-0x0000000180AE2570
	private void AttemptTapSelectOrSwap(); // 0x0000000180AE2570-0x0000000180AE2950
	public void ConfirmPrediction(int newCol, int newRow); // 0x0000000180AE2950-0x0000000180AE2A60
	public void CancelPrediction(); // 0x0000000180AE2A60-0x0000000180AE2BE0
	[CompilerGenerated]
	private void _PlayLandingSquash_b__126_0(); // 0x0000000180AE2DA0-0x0000000180AE3020
}

