/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class ChatDockDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 426
{
	// Fields
	public const string CTX_HUB = "hub"; // Metadata: 0x0068B23E
	public const string CTX_MATCH = "match"; // Metadata: 0x0068B242
	public const float MARGIN = 8f; // Metadata: 0x0068B248
	public const float MATCH_MIN_Y = 210f; // Metadata: 0x0068B24C
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x0068B250
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x0068B254
	private const string KEY_PREFIX = "chatdock.pos."; // Metadata: 0x0068B258
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
	public static bool DraggedRecently { get; } // 0x0000000180365450-0x00000001803654E0 
	public string Context { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180365440-0x0000000180365450 0x0000000180365520-0x0000000180365530
	private bool InMatch { get; } // 0x00000001803654E0-0x0000000180365520 

	// Constructors
	public ChatDockDrag(); // 0x00000001803653F0-0x0000000180365440
	static ChatDockDrag(); // 0x00000001803653B0-0x00000001803653F0

	// Methods
	private void Awake(); // 0x0000000180363240-0x0000000180363480
	private void OnDisable(); // 0x0000000180364620-0x00000001803646A0
	public void SetContext(string ctx); // 0x0000000180364EF0-0x0000000180364F70
	private void Update(); // 0x0000000180365210-0x0000000180365330
	public void OnBeginDrag(PointerEventData eventData); // 0x0000000180364430-0x0000000180364620
	public void OnDrag(PointerEventData eventData); // 0x00000001803646A0-0x0000000180364890
	public void OnEndDrag(PointerEventData eventData); // 0x0000000180364890-0x0000000180364AC0
	private void SaveNow(); // 0x0000000180364AC0-0x0000000180364CB0
	public Vector2 Clamp(Vector2 anchored); // 0x0000000180363EF0-0x0000000180363FA0
	public static Vector2 Clamp(RectTransform rt, Vector2 anchored, bool inMatch); // 0x0000000180363AC0-0x0000000180363EF0
	private bool ToCanvasPoint(PointerEventData eventData, out Vector2 point); // 0x0000000180364F70-0x0000000180365210
	private Vector2 AnchorRef(); // 0x0000000180363150-0x00000001803631C0
	private Vector2 AnchoredToCanvas(Vector2 anchored); // 0x00000001803631C0-0x0000000180363240
	private Vector2 CanvasToAnchored(Vector2 canvasPoint); // 0x0000000180363A30-0x0000000180363AC0
	private Camera EventCam(PointerEventData eventData); // 0x0000000180363FA0-0x0000000180364090
	private Vector2 CanvasSize(); // 0x00000001803638A0-0x0000000180363A30
	public static Vector2 CanvasSizeOf(RectTransform rt); // 0x0000000180363480-0x00000001803638A0
	private static float ScaleFactorOf(CanvasScaler scaler); // 0x0000000180364E00-0x0000000180364EF0
	private static string User(); // 0x0000000180365330-0x00000001803653B0
	public static string KeyOf(string ctx, string axis, string user); // 0x0000000180364090-0x00000001803641D0
	public static Vector2? LoadSaved(string ctx, RectTransform rt); // 0x00000001803641D0-0x0000000180364430
	public static void Save(string ctx, Vector2 anchored, RectTransform rt); // 0x0000000180364CB0-0x0000000180364E00
}

