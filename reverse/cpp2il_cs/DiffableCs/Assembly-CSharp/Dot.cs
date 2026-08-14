//Type is in global namespace

[DefaultExecutionOrder(100)]
public class Dot : MonoBehaviour
{
	internal const float smoothTime = 0.055; //Field offset: 0x0
	private static bool s_turnTimerPausedForLocalDrag; //Field offset: 0x0
	internal const float PREDICTION_TIMEOUT = 2; //Field offset: 0x0
	private const float LANDING_SQUASH_MIN_DROP = 0.5; //Field offset: 0x0
	private const float FALL_REF_CELLS = 4; //Field offset: 0x0
	internal const float fallColWaveDelay = 0.012; //Field offset: 0x0
	internal const float fallTime = 0.28; //Field offset: 0x0
	private static Dot s_dotMouseDownOn; //Field offset: 0x8
	private static Dot s_tapSelectedDot; //Field offset: 0x10
	private static Camera s_cachedMainCamera; //Field offset: 0x18
	private static int s_mouseFrame; //Field offset: 0x20
	private static bool s_mouseHeld; //Field offset: 0x24
	[Header("Dot Properties")]
	public int column; //Field offset: 0x20
	public int row; //Field offset: 0x24
	public int previousColumn; //Field offset: 0x28
	public int previousRow; //Field offset: 0x2C
	public float targetX; //Field offset: 0x30
	public float targetY; //Field offset: 0x34
	public bool isMathched; //Field offset: 0x38
	[Header("Swipe Settings")]
	public float swipeResit; //Field offset: 0x3C
	public float swipeAngle; //Field offset: 0x40
	private Board _board; //Field offset: 0x48
	private BoardPVP _boardPVP; //Field offset: 0x50
	private Active _active; //Field offset: 0x58
	private ActivePVP _activePVP; //Field offset: 0x60
	public GameObject otherDot; //Field offset: 0x68
	public Vector2 firstTouchPosition; //Field offset: 0x70
	public Vector2 finalTouchPosition; //Field offset: 0x78
	private Vector2 tempPosition; //Field offset: 0x80
	public int multiplier; //Field offset: 0x88
	public TextMesh multiplierTextMesh; //Field offset: 0x90
	internal Vector2 velocityX; //Field offset: 0x98
	internal Vector2 velocityY; //Field offset: 0xA0
	internal Vector2 positionSmoothVelocity; //Field offset: 0xA8
	private bool _isFalling; //Field offset: 0xB0
	private float _fallDelay; //Field offset: 0xB4
	private float _fallDur; //Field offset: 0xB8
	private float _fallElapsed; //Field offset: 0xBC
	private Vector2 _fallStartPos; //Field offset: 0xC0
	private Vector3 _baseScale; //Field offset: 0xC8
	private bool _baseScaleCaptured; //Field offset: 0xD4
	public GameObject originalPrefab; //Field offset: 0xD8
	internal bool isPredictionSwap; //Field offset: 0xE0
	internal int predictedTargetX; //Field offset: 0xE4
	internal int predictedTargetY; //Field offset: 0xE8
	internal float predictionStartTime; //Field offset: 0xEC

	private GameState BoardCurrentState
	{
		private get { } //Length: 64
	}

	private bool BoardHasDestroyedThisTurn
	{
		private get { } //Length: 72
	}

	private int BoardHeight
	{
		private get { } //Length: 67
	}

	private bool BoardIsProcessingUI
	{
		private get { } //Length: 72
	}

	private int BoardWidth
	{
		private get { } //Length: 67
	}

	private int CurrentTurnPlayerActorNumber
	{
		private get { } //Length: 73
	}

	private float CurrentTurnTime
	{
		private get { } //Length: 58
	}

	private bool IsPVP
	{
		private get { } //Length: 172
	}

	private bool IsTurnInProgress
	{
		private get { } //Length: 72
	}

	private int LocalActorNumber
	{
		private get { } //Length: 73
	}

	private bool WsModeActive
	{
		private get { } //Length: 371
	}

	private static Dot() { }

	public Dot() { }

	[CompilerGenerated]
	private void <PlayLandingSquash>b__84_0() { }

	private void AttemptTapSelectOrSwap() { }

	private bool BoardIsPlayerAllowedToMove() { }

	private void CalculateAngle() { }

	public void CancelPrediction() { }

	public bool CanInteract() { }

	private float CellHeightWorld() { }

	private static void ClearTapSelection() { }

	public void ConfirmPrediction(int newCol, int newRow) { }

	private void ExecuteSwapToNeighbor(int targetCol, int targetRow) { }

	private GameState get_BoardCurrentState() { }

	private bool get_BoardHasDestroyedThisTurn() { }

	private int get_BoardHeight() { }

	private bool get_BoardIsProcessingUI() { }

	private int get_BoardWidth() { }

	private int get_CurrentTurnPlayerActorNumber() { }

	private float get_CurrentTurnTime() { }

	private bool get_IsPVP() { }

	private bool get_IsTurnInProgress() { }

	private int get_LocalActorNumber() { }

	private bool get_WsModeActive() { }

	private GameObject GetAllDots(int col, int row) { }

	private bool IsCurrentPlayerTurn(int actor) { }

	public bool IsMoving() { }

	private bool IsValidSwipe() { }

	private void LateUpdate() { }

	public void MarkFalling() { }

	private static bool MouseHeld() { }

	private void MovePieces() { }

	private void OnDestroy() { }

	private void OnMouseDown() { }

	private void OnMouseUp() { }

	private void PlayLandingSquash(float dropDistance) { }

	private void RequestSwap(int fromCol, int fromRow, int toCol, int toRow) { }

	internal static void ResetStaticState() { }

	private Vector2 ScreenToWorldOnDotPlane() { }

	private void SetBoardState(GameState state) { }

	private void Start() { }

	private void TryPauseTurnTimerForDrag() { }

	private void TryResumeTurnTimerAfterDrag() { }

	private void Update() { }

	private bool UpdateBoardReference() { }

	private void UpdatePositionAndMatches() { }

	private Vector2 WorldTargetForGrid(int col, int row) { }

}

