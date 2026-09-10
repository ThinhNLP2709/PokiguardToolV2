/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class CameraController : MonoBehaviour // TypeDefIndex: 2073
	{
		// Fields
		private Transform cameraTransform; // 0x20
		private Transform dummyTarget; // 0x28
		public Transform CameraTarget; // 0x30
		public float FollowDistance; // 0x38
		public float MaxFollowDistance; // 0x3C
		public float MinFollowDistance; // 0x40
		public float ElevationAngle; // 0x44
		public float MaxElevationAngle; // 0x48
		public float MinElevationAngle; // 0x4C
		public float OrbitalAngle; // 0x50
		public CameraModes CameraMode; // 0x54
		public bool MovementSmoothing; // 0x58
		public bool RotationSmoothing; // 0x59
		private bool previousSmoothing; // 0x5A
		public float MovementSmoothingValue; // 0x5C
		public float RotationSmoothingValue; // 0x60
		public float MoveSensitivity; // 0x64
		private Vector3 currentVelocity; // 0x68
		private Vector3 desiredPosition; // 0x74
		private float mouseX; // 0x80
		private float mouseY; // 0x84
		private Vector3 moveVector; // 0x88
		private float mouseWheel; // 0x94
		private const string event_SmoothingValue = "Slider - Smoothing Value"; // Metadata: 0x0068DF3E
		private const string event_FollowDistance = "Slider - Camera Zoom"; // Metadata: 0x0068DF57
	
		// Nested types
		public enum CameraModes // TypeDefIndex: 2074
		{
			Follow = 0,
			Isometric = 1,
			Free = 2
		}
	
		// Constructors
		public CameraController(); // 0x0000000180729490-0x00000001807294F0
	
		// Methods
		private void Awake(); // 0x00000001807284F0-0x00000001807285C0
		private void Start(); // 0x00000001807293C0-0x0000000180729490
		private void LateUpdate(); // 0x0000000180728F00-0x00000001807293C0
		private void GetPlayerInput(); // 0x00000001807285C0-0x0000000180728F00
	}
}
