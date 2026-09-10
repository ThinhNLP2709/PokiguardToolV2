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
public class HomePressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler // TypeDefIndex: 812
{
	// Fields
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x0068BC55
	private const float DOWN_SCALE = 0.92f; // Metadata: 0x0068BC59
	private const float DOWN_TIME = 0.08f; // Metadata: 0x0068BC5D
	private const float UP_TIME = 0.12f; // Metadata: 0x0068BC61
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
	public bool IsPressed { get; } // 0x0000000180495E80-0x0000000180495E90 

	// Events
	public event Action Clicked {
		add; // 0x0000000180495DE0-0x0000000180495E80
		remove; // 0x0000000180495E90-0x0000000180495F30
	}

	// Constructors
	public HomePressScale(); // 0x0000000180495DB0-0x0000000180495DE0

	// Methods
	private void Awake(); // 0x0000000180495720-0x00000001804957D0
	private void OnDisable(); // 0x0000000180495880-0x0000000180495950
	public void OnPointerDown(PointerEventData eventData); // 0x0000000180495A70-0x0000000180495BD0
	public void OnPointerUp(PointerEventData eventData); // 0x0000000180495BD0-0x0000000180495CE0
	public void OnPointerClick(PointerEventData eventData); // 0x0000000180495950-0x0000000180495A70
	public void ResetVisual(); // 0x0000000180495CE0-0x0000000180495DB0
	public void CaptureBaseScale(); // 0x00000001804957D0-0x0000000180495880
}

