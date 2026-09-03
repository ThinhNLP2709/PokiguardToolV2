/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[RequiredByNativeCode]
	public class ControllerColliderHit // TypeDefIndex: 15420
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload(CleanupStrategy = CleanupStrategy.Clear)]
		private static readonly ControllerColliderHit s_ReusableCollision; // 0x00
		internal CharacterController m_Controller; // 0x10
		internal Collider m_Collider; // 0x18
		internal Vector3 m_Point; // 0x20
		internal Vector3 m_Normal; // 0x2C
		internal Vector3 m_MoveDirection; // 0x38
		internal float m_MoveLength; // 0x44
		internal int m_Push; // 0x48
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public Vector3 moveDirection { get; } // 0x0000000181D8BE50-0x0000000181D8BE70 
	
		// Constructors
		public ControllerColliderHit(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ControllerColliderHit(); // 0x00000001822D5310-0x00000001822D5470
	
		// Methods
		private void SetAllFields(CharacterController controller, Collider collider, Vector3 point, Vector3 normal, Vector3 moveDirection, float moveLength); // 0x00000001822D5110-0x00000001822D51A0
		internal void Clear(); // 0x00000001822D4FA0-0x00000001822D5020
		[RequiredByNativeCode]
		private static ControllerColliderHit Create(CharacterController controller, Collider collider, Vector3 point, Vector3 normal, Vector3 moveDirection, float moveLength); // 0x00000001822D5020-0x00000001822D5110
		[RequiredByNativeCode]
		private static void Update(ControllerColliderHit hit, CharacterController controller, Collider collider, Vector3 point, Vector3 normal, Vector3 moveDirection, float moveLength); // 0x00000001822D51A0-0x00000001822D5240
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822D5240-0x00000001822D5310
	}
}
