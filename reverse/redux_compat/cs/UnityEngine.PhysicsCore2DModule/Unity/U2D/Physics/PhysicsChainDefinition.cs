/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[Serializable]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsChainDefinition // TypeDefIndex: 14696
	{
		// Fields
		[SerializeField]
		private PhysicsShape.SurfaceMaterial m_SurfaceMaterial; // 0x00
		[SerializeField]
		private PhysicsShape.ContactFilter m_ContactFilter; // 0x20
		[SerializeField]
		private bool m_IsLoop; // 0x38
		[SerializeField]
		private bool m_TriggerEvents; // 0x39
	
		// Properties
		public static PhysicsChainDefinition defaultDefinition { get; } // 0x00000001822C6B30-0x00000001822C6BB0 
	
		// Constructors
		public PhysicsChainDefinition(); // 0x00000001822C6A30-0x00000001822C6AB0
		public PhysicsChainDefinition(bool useSettings); // 0x00000001822C6AB0-0x00000001822C6B30
	}
}
