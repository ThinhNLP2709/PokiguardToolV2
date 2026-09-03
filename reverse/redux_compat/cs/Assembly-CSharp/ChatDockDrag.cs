/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class ChatDockDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 374
{
	// Fields
	public const string CTX_HUB = "hub"; // Metadata: 0x0064C27C
	public const string CTX_MATCH = "match"; // Metadata: 0x0064C280
	public const float MARGIN = 8f; // Metadata: 0x0064C286
	public const float MATCH_MIN_Y = 210f; // Metadata: 0x0064C28A
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x0064C28E
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x0064C292
	private const string KEY_PREFIX = "chatdock.pos."; // Metadata: 0x0064C296
	private static bool _dragging; // 0x00
	private static bool _movedFar; // 0x01
	private static float _lastEnd; // 0x04
	private RectTransform _rt; // 0x20
	private RectTransform _parentRect; // 0x28
	private Canvas _rootCanvas; // 0x30
	private CanvasScaler _scaler; // 0x38
	private Vector2 _grabOffset; // 0x40
	private Vector2 _startScreen; // 0x48
	private Vector2 _startAnchored; // 0x50
	private Vector2 _lastCanvasSize; // 0x58
	private bool _dirty; // 0x60
	[CompilerGenerated]
	private string _Context_k__BackingField; // 0x68

	// Properties
	public static bool DraggedRecently { get; } // 0x0000000180316970-0x0000000180316A00 
	public string Context { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	private bool InMatch { get; } // 0x0000000180316A00-0x0000000180316A40 

	// Constructors
	public ChatDockDrag(); // 0x0000000180316910-0x0000000180316960
	static ChatDockDrag(); // 0x00000001803168D0-0x0000000180316910

	// Methods
	private void Awake(); // 0x0000000180314760-0x00000001803149A0
	private void OnDisable(); // 0x0000000180315B40-0x0000000180315BC0
	public void SetContext(string ctx); // 0x0000000180316410-0x0000000180316490
	private void Update(); // 0x0000000180316730-0x0000000180316850
	public void OnBeginDrag(PointerEventData eventData); // 0x0000000180315950-0x0000000180315B40
	public void OnDrag(PointerEventData eventData); // 0x0000000180315BC0-0x0000000180315DB0
	public void OnEndDrag(PointerEventData eventData); // 0x0000000180315DB0-0x0000000180315FE0
	private void SaveNow(); // 0x0000000180315FE0-0x00000001803161D0
	public Vector2 Clamp(Vector2 anchored); // 0x0000000180315410-0x00000001803154C0
	public static Vector2 Clamp(RectTransform rt, Vector2 anchored, bool inMatch); // 0x0000000180314FE0-0x0000000180315410
	private bool ToCanvasPoint(PointerEventData eventData, out Vector2 point); // 0x0000000180316490-0x0000000180316730
	private Vector2 AnchorRef(); // 0x0000000180314670-0x00000001803146E0
	private Vector2 AnchoredToCanvas(Vector2 anchored); // 0x00000001803146E0-0x0000000180314760
	private Vector2 CanvasToAnchored(Vector2 canvasPoint); // 0x0000000180314F50-0x0000000180314FE0
	private Camera EventCam(PointerEventData eventData); // 0x00000001803154C0-0x00000001803155B0
	private Vector2 CanvasSize(); // 0x0000000180314DC0-0x0000000180314F50
	public static Vector2 CanvasSizeOf(RectTransform rt); // 0x00000001803149A0-0x0000000180314DC0
	private static float ScaleFactorOf(CanvasScaler scaler); // 0x0000000180316320-0x0000000180316410
	private static string User(); // 0x0000000180316850-0x00000001803168D0
	public static string KeyOf(string ctx, string axis, string user); // 0x00000001803155B0-0x00000001803156F0
	public static Vector2? LoadSaved(string ctx, RectTransform rt); // 0x00000001803156F0-0x0000000180315950
	public static void Save(string ctx, Vector2 anchored, RectTransform rt); // 0x00000001803161D0-0x0000000180316320
}

