/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ChatRowLongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // TypeDefIndex: 507
{
	// Fields
	public const float HoldSeconds = 0.45f; // Metadata: 0x005EF54F
	private const float DragCancelFactor = 1.2f; // Metadata: 0x005EF553
	private const float FallbackDragThreshold = 10f; // Metadata: 0x005EF557
	public long msgId; // 0x20
	public string scope; // 0x28
	public GameObject row; // 0x30
	private Action<ChatRowLongPress> _onLongPress; // 0x38
	private bool _holding; // 0x40
	private Vector2 _downPos; // 0x44
	private float _downAt; // 0x4C

	// Constructors
	public ChatRowLongPress(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Setup(long id, string reactScope, GameObject rowGO, Action<ChatRowLongPress> onLongPress); // 0x000000018039D730-0x000000018039D940
	public void OnPointerDown(PointerEventData eventData); // 0x000000018039D940-0x000000018039D9E0
	public void OnPointerUp(PointerEventData eventData); // 0x000000018039D9E0-0x000000018039D9F0
	private void OnDisable(); // 0x000000018039D9E0-0x000000018039D9F0
	private void Update(); // 0x000000018039D9F0-0x000000018039DC80
	private static Vector2 CurrentPointer(); // 0x000000018039DC80-0x000000018039DDE0
}

