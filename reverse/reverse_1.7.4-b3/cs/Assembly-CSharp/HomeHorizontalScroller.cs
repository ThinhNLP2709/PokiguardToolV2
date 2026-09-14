/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class HomeHorizontalScroller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 970
{
	// Fields
	private const float FRICTION = 6f; // Metadata: 0x005EF1A1
	private const float MIN_SPEED = 8f; // Metadata: 0x005EF1A5
	private const float OVERSCROLL = 0.35f; // Metadata: 0x005EF1A9
	private const float DRAG_LOCK_SEC = 0.12f; // Metadata: 0x005EF1AD
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
	public static bool DraggedRecently { get; } // 0x00000001805E4A60-0x00000001805E4B20 

	// Constructors
	public HomeHorizontalScroller(); // 0x00000001805E5880-0x00000001805E58E0
	static HomeHorizontalScroller(); // 0x00000001805E58E0-0x00000001805E5930

	// Methods
	private void Awake(); // 0x00000001805E4B20-0x00000001805E4C70
	private void OnDisable(); // 0x00000001805E4C70-0x00000001805E4CE0
	public void RecalcLimit(); // 0x00000001805E4CE0-0x00000001805E4D00
	public void OnBeginDrag(PointerEventData eventData); // 0x00000001805E4D00-0x00000001805E4D70
	public void OnDrag(PointerEventData eventData); // 0x00000001805E4D70-0x00000001805E5160
	public void OnEndDrag(PointerEventData eventData); // 0x00000001805E5160-0x00000001805E5210
	private void Update(); // 0x00000001805E5210-0x00000001805E54D0
	public void CenterInstant(); // 0x00000001805E54D0-0x00000001805E56B0
	private float CanvasScale(); // 0x00000001805E56B0-0x00000001805E5880
}

