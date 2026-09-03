/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class HomeHorizontalScroller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 607
{
	// Fields
	private const float FRICTION = 6f; // Metadata: 0x0064C60F
	private const float MIN_SPEED = 8f; // Metadata: 0x0064C613
	private const float OVERSCROLL = 0.35f; // Metadata: 0x0064C617
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x0064C61B
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
	public static bool DraggedRecently { get; } // 0x00000001803B20F0-0x00000001803B2170 

	// Constructors
	public HomeHorizontalScroller(); // 0x00000001803B20D0-0x00000001803B20F0
	static HomeHorizontalScroller(); // 0x00000001803B2090-0x00000001803B20D0

	// Methods
	private void Awake(); // 0x00000001803B1850-0x00000001803B1950
	private void OnDisable(); // 0x00000001803B1B90-0x00000001803B1BF0
	public void RecalcLimit(); // 0x00000001803B1E50-0x00000001803B1E70
	public void OnBeginDrag(PointerEventData eventData); // 0x00000001803B1B30-0x00000001803B1B90
	public void OnDrag(PointerEventData eventData); // 0x00000001803B1BF0-0x00000001803B1DE0
	public void OnEndDrag(PointerEventData eventData); // 0x00000001803B1DE0-0x00000001803B1E50
	private void Update(); // 0x00000001803B1E70-0x00000001803B2090
	public void CenterInstant(); // 0x00000001803B1A20-0x00000001803B1B30
	private float CanvasScale(); // 0x00000001803B1950-0x00000001803B1A20
}

