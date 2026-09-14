/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class CameraController : MonoBehaviour // TypeDefIndex: 2471
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
		private const string event_SmoothingValue = "Slider - Smoothing Value"; // Metadata: 0x005F0E3C
		private const string event_FollowDistance = "Slider - Camera Zoom"; // Metadata: 0x005F0E55
	
		// Nested types
		public enum CameraModes // TypeDefIndex: 2472
		{
			Follow = 0,
			Isometric = 1,
			Free = 2
		}
	
		// Constructors
		public CameraController(); // 0x0000000180B84FB0-0x0000000180B85050
	
		// Methods
		private void Awake(); // 0x0000000180B82ED0-0x0000000180B83150
		private void Start(); // 0x0000000180B83150-0x0000000180B83340
		private void LateUpdate(); // 0x0000000180B83340-0x0000000180B83E60
		private void GetPlayerInput(); // 0x0000000180B83E60-0x0000000180B84FB0
	}
}
