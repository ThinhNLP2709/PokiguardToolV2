/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomePressScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler // TypeDefIndex: 981
{
	// Fields
	private const float DRAG_TOLERANCE_PX = 12f; // Metadata: 0x005F0589
	private const float DOWN_SCALE = 0.92f; // Metadata: 0x005F058D
	private const float DOWN_TIME = 0.08f; // Metadata: 0x005F0591
	private const float UP_TIME = 0.12f; // Metadata: 0x005F0595
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
	public bool IsPressed { get; } // 0x00000001805EDE00-0x00000001805EDE10 

	// Events
	public event Action Clicked {
		add; // 0x00000001805ECF20-0x00000001805ED010
		remove; // 0x00000001805ED010-0x00000001805ED100
	}

	// Constructors
	public HomePressScale(); // 0x00000001805EDE10-0x00000001805EDE80

	// Methods
	private void Awake(); // 0x00000001805ED100-0x00000001805ED2C0
	private void OnDisable(); // 0x00000001805ED2C0-0x00000001805ED4C0
	public void OnPointerDown(PointerEventData eventData); // 0x00000001805ED4C0-0x00000001805ED6F0
	public void OnPointerUp(PointerEventData eventData); // 0x00000001805ED6F0-0x00000001805ED8D0
	public void OnPointerClick(PointerEventData eventData); // 0x00000001805ED8D0-0x00000001805EDA40
	public void ResetVisual(); // 0x00000001805EDA40-0x00000001805EDC40
	public void CaptureBaseScale(); // 0x00000001805EDC40-0x00000001805EDE00
}

