/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class ChatDockDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 480
{
	// Fields
	public const string CTX_HUB = "hub"; // Metadata: 0x005EF50B
	public const string CTX_MATCH = "match"; // Metadata: 0x005EF50F
	public const float MARGIN = 8f; // Metadata: 0x005EF515
	public const float MATCH_MIN_Y = 210f; // Metadata: 0x005EF519
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x005EF51D
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x005EF521
	private const string KEY_PREFIX = "chatdock.pos."; // Metadata: 0x005EF525
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
	public static bool DraggedRecently { get; } // 0x000000018038BF30-0x000000018038C000 
	public string Context { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180345810-0x0000000180345820 0x000000018038C000-0x000000018038C060
	private bool InMatch { get; } // 0x000000018038C060-0x000000018038C0E0 

	// Constructors
	public ChatDockDrag(); // 0x000000018038EFE0-0x000000018038F0B0
	static ChatDockDrag(); // 0x000000018038F0B0-0x000000018038F100

	// Methods
	private void Awake(); // 0x000000018038C0E0-0x000000018038C550
	private void OnDisable(); // 0x000000018038C550-0x000000018038C5E0
	public void SetContext(string ctx); // 0x000000018038C5E0-0x000000018038C6E0
	private void Update(); // 0x000000018038C6E0-0x000000018038C890
	public void OnBeginDrag(PointerEventData eventData); // 0x000000018038C890-0x000000018038CB40
	public void OnDrag(PointerEventData eventData); // 0x000000018038CB40-0x000000018038CD70
	public void OnEndDrag(PointerEventData eventData); // 0x000000018038CD70-0x000000018038D030
	private void SaveNow(); // 0x000000018038D030-0x000000018038D190
	public Vector2 Clamp(Vector2 anchored); // 0x000000018038D190-0x000000018038D270
	public static Vector2 Clamp(RectTransform rt, Vector2 anchored, bool inMatch); // 0x000000018038D270-0x000000018038D750
	private bool ToCanvasPoint(PointerEventData eventData, out Vector2 point); // 0x000000018038D750-0x000000018038D9B0
	private Vector2 AnchorRef(); // 0x000000018038D9B0-0x000000018038DA20
	private Vector2 AnchoredToCanvas(Vector2 anchored); // 0x000000018038DA20-0x000000018038DA60
	private Vector2 CanvasToAnchored(Vector2 canvasPoint); // 0x000000018038DA60-0x000000018038DAA0
	private Camera EventCam(PointerEventData eventData); // 0x000000018038DAA0-0x000000018038DC90
	private Vector2 CanvasSize(); // 0x000000018038DC90-0x000000018038E060
	public static Vector2 CanvasSizeOf(RectTransform rt); // 0x000000018038E060-0x000000018038E820
	private static float ScaleFactorOf(CanvasScaler scaler); // 0x000000018038E820-0x000000018038E910
	private static string User(); // 0x000000018038E910-0x000000018038E9A0
	public static string KeyOf(string ctx, string axis, string user); // 0x000000018038E9A0-0x000000018038EAD0
	public static Vector2? LoadSaved(string ctx, RectTransform rt); // 0x000000018038EAD0-0x000000018038EDF0
	public static void Save(string ctx, Vector2 anchored, RectTransform rt); // 0x000000018038EDF0-0x000000018038EFE0
}

