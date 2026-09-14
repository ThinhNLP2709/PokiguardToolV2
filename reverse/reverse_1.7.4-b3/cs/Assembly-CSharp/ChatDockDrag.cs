/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class ChatDockDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 480
{
	// Fields
	public const string CTX_HUB = "hub"; // Metadata: 0x005EE13B
	public const string CTX_MATCH = "match"; // Metadata: 0x005EE13F
	public const float MARGIN = 8f; // Metadata: 0x005EE145
	public const float MATCH_MIN_Y = 210f; // Metadata: 0x005EE149
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x005EE14D
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x005EE151
	private const string KEY_PREFIX = "chatdock.pos."; // Metadata: 0x005EE155
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
	public static bool DraggedRecently { get; } // 0x000000018038BD80-0x000000018038BE50 
	public string Context { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456F0-0x0000000180345700 0x000000018038BE50-0x000000018038BEB0
	private bool InMatch { get; } // 0x000000018038BEB0-0x000000018038BF30 

	// Constructors
	public ChatDockDrag(); // 0x000000018038EE30-0x000000018038EF00
	static ChatDockDrag(); // 0x000000018038EF00-0x000000018038EF50

	// Methods
	private void Awake(); // 0x000000018038BF30-0x000000018038C3A0
	private void OnDisable(); // 0x000000018038C3A0-0x000000018038C430
	public void SetContext(string ctx); // 0x000000018038C430-0x000000018038C530
	private void Update(); // 0x000000018038C530-0x000000018038C6E0
	public void OnBeginDrag(PointerEventData eventData); // 0x000000018038C6E0-0x000000018038C990
	public void OnDrag(PointerEventData eventData); // 0x000000018038C990-0x000000018038CBC0
	public void OnEndDrag(PointerEventData eventData); // 0x000000018038CBC0-0x000000018038CE80
	private void SaveNow(); // 0x000000018038CE80-0x000000018038CFE0
	public Vector2 Clamp(Vector2 anchored); // 0x000000018038CFE0-0x000000018038D0C0
	public static Vector2 Clamp(RectTransform rt, Vector2 anchored, bool inMatch); // 0x000000018038D0C0-0x000000018038D5A0
	private bool ToCanvasPoint(PointerEventData eventData, out Vector2 point); // 0x000000018038D5A0-0x000000018038D800
	private Vector2 AnchorRef(); // 0x000000018038D800-0x000000018038D870
	private Vector2 AnchoredToCanvas(Vector2 anchored); // 0x000000018038D870-0x000000018038D8B0
	private Vector2 CanvasToAnchored(Vector2 canvasPoint); // 0x000000018038D8B0-0x000000018038D8F0
	private Camera EventCam(PointerEventData eventData); // 0x000000018038D8F0-0x000000018038DAE0
	private Vector2 CanvasSize(); // 0x000000018038DAE0-0x000000018038DEB0
	public static Vector2 CanvasSizeOf(RectTransform rt); // 0x000000018038DEB0-0x000000018038E670
	private static float ScaleFactorOf(CanvasScaler scaler); // 0x000000018038E670-0x000000018038E760
	private static string User(); // 0x000000018038E760-0x000000018038E7F0
	public static string KeyOf(string ctx, string axis, string user); // 0x000000018038E7F0-0x000000018038E920
	public static Vector2? LoadSaved(string ctx, RectTransform rt); // 0x000000018038E920-0x000000018038EC40
	public static void Save(string ctx, Vector2 anchored, RectTransform rt); // 0x000000018038EC40-0x000000018038EE30
}

