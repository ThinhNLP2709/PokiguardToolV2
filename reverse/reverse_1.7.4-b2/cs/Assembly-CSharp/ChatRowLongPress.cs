/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatRowLongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // TypeDefIndex: 453
{
	// Fields
	public const float HoldSeconds = 0.45f; // Metadata: 0x0068B2C0
	private const float DragCancelFactor = 1.2f; // Metadata: 0x0068B2C4
	private const float FallbackDragThreshold = 10f; // Metadata: 0x0068B2C8
	public long msgId; // 0x20
	public string scope; // 0x28
	public GameObject row; // 0x30
	private Action<ChatRowLongPress> _onLongPress; // 0x38
	private bool _holding; // 0x40
	private Vector2 _downPos; // 0x44
	private float _downAt; // 0x4C

	// Constructors
	public ChatRowLongPress(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void Setup(long id, string reactScope, GameObject rowGO, Action<ChatRowLongPress> onLongPress); // 0x0000000180379D20-0x0000000180379DE0
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180379CC0-0x0000000180379D20
	public void OnPointerUp(PointerEventData eventData); // 0x0000000180379CB0-0x0000000180379CC0
	private void OnDisable(); // 0x0000000180379CB0-0x0000000180379CC0
	private void Update(); // 0x0000000180379DE0-0x0000000180379FA0
	private static Vector2 CurrentPointer(); // 0x0000000180379C10-0x0000000180379CB0
}

