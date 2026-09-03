/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Interactions
{
	[DisplayName("Press")]
	public class PressInteraction : IInputInteraction // TypeDefIndex: 6581
	{
		// Fields
		[Tooltip("The amount of actuation a control requires before being considered pressed. If not set, default to \'Default Press Point\' in the global input settings.")]
		public float pressPoint; // 0x10
		[Tooltip("Determines how button presses trigger the action. By default (PressOnly), the action is performed on press. With ReleaseOnly, the action is performed on release. With PressAndRelease, the action is performed on press and release.")]
		public PressBehavior behavior; // 0x14
		private bool m_WaitingForRelease; // 0x18
	
		// Properties
		private float pressPointOrDefault { get; } // 0x0000000181CF59F0-0x0000000181CF5A50 
		private float releasePointOrDefault { get; } // 0x0000000181CF5A50-0x0000000181CF5AD0 
	
		// Constructors
		public PressInteraction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Process(ref InputInteractionContext context); // 0x0000000181CF5740-0x0000000181CF59E0
		public void Reset(); // 0x0000000181CF59E0-0x0000000181CF59F0
	}
}
