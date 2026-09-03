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
public class HomePressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler // TypeDefIndex: 616
{
	// Fields
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x0064C62A
	private const float DOWN_SCALE = 0.92f; // Metadata: 0x0064C62E
	private const float DOWN_TIME = 0.08f; // Metadata: 0x0064C632
	private const float UP_TIME = 0.12f; // Metadata: 0x0064C636
	[Tooltip("Object b\u1ECB co gi\u00E3n. B\u1ECF tr\u1ED1ng = ch\u00EDnh object n\u00E0y.")]
	public Transform target; // 0x20
	[Tooltip("T\u1EAFt t\u01B0\u01A1ng t\u00E1c (n\u00FAt \u0111ang b\u1ECB c\u1EDD t\u00EDnh n\u0103ng kho\u00E1) \u2014 v\u1EABn nh\u1EADn b\u1EA5m nh\u01B0ng kh\u00F4ng ph\u00E1t Clicked.")]
	public bool interactable; // 0x28
	[CompilerGenerated]
	private Action Clicked; // 0x30
	private Vector3 _baseScale; // 0x38
	private Vector2 _downPos; // 0x44
	private bool _down; // 0x4C

	// Properties
	public bool IsPressed { get; } // 0x00000001803B6550-0x00000001803B6560 

	// Events
	public event Action Clicked {
		add; // 0x00000001803B64B0-0x00000001803B6550
		remove; // 0x00000001803B6560-0x00000001803B6600
	}

	// Constructors
	public HomePressScale(); // 0x00000001803B6480-0x00000001803B64B0

	// Methods
	private void Awake(); // 0x00000001803B5DF0-0x00000001803B5EA0
	private void OnDisable(); // 0x00000001803B5F50-0x00000001803B6020
	public void OnPointerDown(PointerEventData eventData); // 0x00000001803B6140-0x00000001803B62A0
	public void OnPointerUp(PointerEventData eventData); // 0x00000001803B62A0-0x00000001803B63B0
	public void OnPointerClick(PointerEventData eventData); // 0x00000001803B6020-0x00000001803B6140
	public void ResetVisual(); // 0x00000001803B63B0-0x00000001803B6480
	public void CaptureBaseScale(); // 0x00000001803B5EA0-0x00000001803B5F50
}

