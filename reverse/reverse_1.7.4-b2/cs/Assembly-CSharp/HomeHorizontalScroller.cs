/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class HomeHorizontalScroller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 803
{
	// Fields
	private const float FRICTION = 6f; // Metadata: 0x0068BC3A
	private const float MIN_SPEED = 8f; // Metadata: 0x0068BC3E
	private const float OVERSCROLL = 0.35f; // Metadata: 0x0068BC42
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x0068BC46
	[Tooltip("Chi\u1EC1u r\u1ED9ng n\u1ED9i dung (\u1EA3nh n\u1EC1n). Builder \u0111i\u1EC1n theo sprite th\u1EADt.")]
	public float contentWidth; // 0x20
	[Tooltip("Chi\u1EC1u r\u1ED9ng khung nh\u00ECn (kh\u1EDBp CanvasScaler.referenceResolution.x).")]
	public float viewportWidth; // 0x24
	private static bool _dragging; // 0x00
	private static float _lastDragEnd; // 0x04
	private RectTransform _rt; // 0x28
	private float _velocity; // 0x30
	private float _limit; // 0x34

	// Properties
	public static bool DraggedRecently { get; } // 0x0000000180491A30-0x0000000180491AB0 

	// Constructors
	public HomeHorizontalScroller(); // 0x0000000180491A10-0x0000000180491A30
	static HomeHorizontalScroller(); // 0x00000001804919D0-0x0000000180491A10

	// Methods
	private void Awake(); // 0x0000000180491190-0x0000000180491290
	private void OnDisable(); // 0x00000001804914D0-0x0000000180491530
	public void RecalcLimit(); // 0x0000000180491790-0x00000001804917B0
	public void OnBeginDrag(PointerEventData eventData); // 0x0000000180491470-0x00000001804914D0
	public void OnDrag(PointerEventData eventData); // 0x0000000180491530-0x0000000180491720
	public void OnEndDrag(PointerEventData eventData); // 0x0000000180491720-0x0000000180491790
	private void Update(); // 0x00000001804917B0-0x00000001804919D0
	public void CenterInstant(); // 0x0000000180491360-0x0000000180491470
	private float CanvasScale(); // 0x0000000180491290-0x0000000180491360
}

