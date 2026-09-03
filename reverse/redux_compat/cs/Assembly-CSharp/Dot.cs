/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DefaultExecutionOrder(100)]
public class Dot : MonoBehaviour // TypeDefIndex: 1652
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
	public Vector2 firstTouchPosition; // 0x70
	public Vector2 finalTouchPosition; // 0x78
	private Vector2 tempPosition; // 0x80
	public int multiplier; // 0x88
	public TextMesh multiplierTextMesh; // 0x90
	internal Vector2 velocityX; // 0x98
	internal Vector2 velocityY; // 0xA0
	internal Vector2 positionSmoothVelocity; // 0xA8
	internal const float smoothTime = 0.055f; // Metadata: 0x0064D828
	internal const float fallTime = 0.28f; // Metadata: 0x0064D82C
	internal const float fallColWaveDelay = 0.008f; // Metadata: 0x0064D830
	internal const float fallRowWaveDelay = 0.008f; // Metadata: 0x0064D834
	private const float FALL_REF_CELLS = 4f; // Metadata: 0x0064D838
	private const float LANDING_SQUASH_FULL_CELLS = 3f; // Metadata: 0x0064D83C
	private const float LANDING_SQUASH_MIN_CELLS = 0.15f; // Metadata: 0x0064D840
	[CompilerGenerated]
	private static float _FallGroupDurationSec_k__BackingField; // 0x00
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
	internal const float PREDICTION_TIMEOUT = 2f; // Metadata: 0x0064D844
	private static bool s_turnTimerPausedForLocalDrag; // 0x04
	private static Dot s_dotMouseDownOn; // 0x08
	private static Dot s_tapSelectedDot; // 0x10
	private static Camera s_cachedMainCamera; // 0x18
	private static int s_mouseFrame; // 0x20
	private static bool s_mouseHeld; // 0x24

	// Properties
	private bool IsPVP { get; } // 0x00000001805C87B0-0x00000001805C8870 
	private float CurrentTurnTime { get; } // 0x00000001805C86A0-0x00000001805C86E0 
	private bool IsTurnInProgress { get; } // 0x00000001805C8870-0x00000001805C88C0 
	private int CurrentTurnPlayerActorNumber { get; } // 0x00000001805C8650-0x00000001805C86A0 
	private int LocalActorNumber { get; } // 0x00000001805C88C0-0x00000001805C8910 
	private GameState BoardCurrentState { get; } // 0x00000001805C84D0-0x00000001805C8510 
	private bool BoardHasDestroyedThisTurn { get; } // 0x00000001805C8510-0x00000001805C8560 
	private bool BoardIsProcessingUI { get; } // 0x00000001805C85B0-0x00000001805C8600 
	private int BoardWidth { get; } // 0x00000001805C8600-0x00000001805C8650 
	private int BoardHeight { get; } // 0x00000001805C8560-0x00000001805C85B0 
	private bool WsModeActive { get; } // 0x00000001805C8910-0x00000001805C8A60 
	internal static float FallGroupDurationSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805C86E0-0x00000001805C8730 0x00000001805C8A60-0x00000001805C8AC0
	public static bool HasTapSelection { get; } // 0x00000001805C8730-0x00000001805C87B0 

	// Constructors
	public Dot(); // 0x00000001805C8410-0x00000001805C84D0
	static Dot(); // 0x00000001805C83D0-0x00000001805C8410

	// Methods
	private bool IsCurrentPlayerTurn(int actor); // 0x00000001805C5D00-0x00000001805C5D70
	private bool BoardIsPlayerAllowedToMove(); // 0x00000001805C4DA0-0x00000001805C4DF0
	private void SetBoardState(GameState state); // 0x00000001805C6E90-0x00000001805C6F70
	private GameObject GetAllDots(int col, int row); // 0x00000001805C5C60-0x00000001805C5D00
	private void RequestSwap(int fromCol, int fromRow, int toCol, int toRow); // 0x00000001805C69C0-0x00000001805C6AB0
	private void TryPauseTurnTimerForDrag(); // 0x00000001805C7240-0x00000001805C7340
	private void TryResumeTurnTimerAfterDrag(); // 0x00000001805C7340-0x00000001805C7440
	internal static void BeginFallGroup(); // 0x00000001805C4D10-0x00000001805C4DA0
	private static bool MouseHeld(); // 0x00000001805C5FC0-0x00000001805C6090
	internal static void ResetStaticState(); // 0x00000001805C6AB0-0x00000001805C6BC0
	private void Start(); // 0x00000001805C6F70-0x00000001805C7240
	private void Update(); // 0x00000001805C7D10-0x00000001805C81A0
	private void LateUpdate(); // 0x00000001805C5F20-0x00000001805C5F30
	private Vector2 WorldTargetForGrid(int col, int row); // 0x00000001805C81A0-0x00000001805C83D0
	private void UpdatePositionAndMatches(); // 0x00000001805C7750-0x00000001805C7D10
	private float CellHeightWorld(); // 0x00000001805C5570-0x00000001805C5600
	public void MarkFalling(); // 0x00000001805C5F30-0x00000001805C5FC0
	private void PlayLandingSquash(float dropDistance); // 0x00000001805C6600-0x00000001805C6850
	internal void PlayMatchTelegraph(); // 0x00000001805C6850-0x00000001805C69C0
	private void OnDestroy(); // 0x00000001805C6310-0x00000001805C6370
	private bool UpdateBoardReference(); // 0x00000001805C7540-0x00000001805C7750
	public bool IsMoving(); // 0x00000001805C5D70-0x00000001805C5E10
	private Vector2 ScreenToWorldOnDotPlane(); // 0x00000001805C6BC0-0x00000001805C6E90
	private void OnMouseDown(); // 0x00000001805C6370-0x00000001805C6460
	private void OnMouseUp(); // 0x00000001805C6460-0x00000001805C6600
	public bool CanInteract(); // 0x00000001805C4E90-0x00000001805C5450
	private void CalculateAngle(); // 0x00000001805C4DF0-0x00000001805C4E90
	private bool IsValidSwipe(); // 0x00000001805C5EE0-0x00000001805C5F20
	private void MovePieces(); // 0x00000001805C6090-0x00000001805C6310
	private void ExecuteSwapToNeighbor(int targetCol, int targetRow); // 0x00000001805C5820-0x00000001805C5C60
	private static void ClearTapSelection(); // 0x00000001805C5640-0x00000001805C5730
	public static void ClearTapSelectionStatic(); // 0x00000001805C5600-0x00000001805C5640
	public static bool IsTapSelected(GameObject go); // 0x00000001805C5E10-0x00000001805C5EE0
	private void AttemptTapSelectOrSwap(); // 0x00000001805C4A90-0x00000001805C4D10
	public void ConfirmPrediction(int newCol, int newRow); // 0x00000001805C5730-0x00000001805C5820
	public void CancelPrediction(); // 0x00000001805C5450-0x00000001805C5570
	[CompilerGenerated]
	private void _PlayLandingSquash_b__91_0(); // 0x00000001805C7440-0x00000001805C7540
}

