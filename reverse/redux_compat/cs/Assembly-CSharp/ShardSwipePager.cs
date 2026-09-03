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
public class ShardSwipePager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // TypeDefIndex: 703
{
	// Fields
	public Action<int> OnSwipe; // 0x20
	private const float MIN_DISTANCE = 80f; // Metadata: 0x0064C80F
	private const float HORIZONTAL_BIAS = 1.5f; // Metadata: 0x0064C813
	private Vector2 _start; // 0x28
	private bool _tracking; // 0x30

	// Constructors
	public ShardSwipePager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void OnBeginDrag(PointerEventData eventData); // 0x00000001803ED840-0x00000001803ED880
	public void OnDrag(PointerEventData eventData); // 0x00000001802E76C0-0x00000001802E76D0
	public void OnEndDrag(PointerEventData eventData); // 0x00000001803ED890-0x00000001803ED930
	private void OnDisable(); // 0x00000001803ED880-0x00000001803ED890
}

