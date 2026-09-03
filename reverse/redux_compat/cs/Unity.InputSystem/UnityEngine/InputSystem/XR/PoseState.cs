/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.XR;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	public struct PoseState : IInputStateTypeInfo // TypeDefIndex: 6246
	{
		// Fields
		internal const int kSizeInBytes = 60; // Metadata: 0x00698D7B
		internal static readonly FourCC s_Format; // 0x00
		[InputControl(displayName = "Is Tracked", layout = "Button", sizeInBits = 8)]
		public bool isTracked; // 0x00
		[InputControl(displayName = "Tracking State", layout = "Integer")]
		public InputTrackingState trackingState; // 0x04
		[InputControl(displayName = "Position", noisy = true)]
		public Vector3 position; // 0x08
		[InputControl(displayName = "Rotation", noisy = true)]
		public Quaternion rotation; // 0x14
		[InputControl(displayName = "Velocity", noisy = true)]
		public Vector3 velocity; // 0x24
		[InputControl(displayName = "Angular Velocity", noisy = true)]
		public Vector3 angularVelocity; // 0x30
	
		// Properties
		public FourCC format { get; } // 0x0000000181D9F670-0x0000000181D9F6C0 
	
		// Constructors
		public PoseState(bool isTracked, InputTrackingState trackingState, Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity); // 0x0000000181D9F620-0x0000000181D9F670
		static PoseState(); // 0x0000000181D9F5B0-0x0000000181D9F620
	}
}
