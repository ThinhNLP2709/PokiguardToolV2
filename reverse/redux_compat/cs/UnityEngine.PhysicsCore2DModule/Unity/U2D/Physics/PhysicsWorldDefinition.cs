/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[Serializable]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsWorldDefinition // TypeDefIndex: 14627
	{
		// Fields
		[SerializeField]
		private Vector2 m_Gravity; // 0x00
		[FormerlySerializedAs("m_SimulationMode")]
		[SerializeField]
		private PhysicsWorld.SimulationType m_SimulationType; // 0x08
		[Min(1f)]
		[SerializeField]
		private int m_SimulationSubSteps; // 0x0C
		[Range(1f, 64f)]
		[SerializeField]
		private int m_SimulationWorkers; // 0x10
		[SerializeField]
		private PhysicsWorld.TransformWriteMode m_TransformWriteMode; // 0x14
		[FormerlySerializedAs("m_TransformTweening")]
		[SerializeField]
		private PhysicsWorld.TransformTweenMode m_TransformTweenMode; // 0x18
		[SerializeField]
		private PhysicsWorld.TransformPlane m_TransformPlane; // 0x1C
		[SerializeField]
		private PhysicsWorld.TransformPlaneCustom m_TransformPlaneCustom; // 0x20
		[SerializeField]
		private bool m_SyncInterpolation; // 0xCC
		[SerializeField]
		private bool m_SleepingAllowed; // 0xCD
		[SerializeField]
		private bool m_ContinuousAllowed; // 0xCE
		[SerializeField]
		private bool m_EventGroupingAllowed; // 0xCF
		[SerializeField]
		private bool m_ContactFilterCallbacks; // 0xD0
		[SerializeField]
		private bool m_PreSolveCallbacks; // 0xD1
		[SerializeField]
		private bool m_AutoBodyUpdateCallbacks; // 0xD2
		[SerializeField]
		private bool m_AutoJointThresholdCallbacks; // 0xD3
		[Min(0f)]
		[SerializeField]
		private float m_BounceThreshold; // 0xD4
		[Min(0f)]
		[SerializeField]
		private float m_ContactHitEventThreshold; // 0xD8
		[Min(0f)]
		[SerializeField]
		private float m_ContactFrequency; // 0xDC
		[Min(0f)]
		[SerializeField]
		private float m_ContactDamping; // 0xE0
		[Min(0f)]
		[SerializeField]
		private float m_ContactSpeed; // 0xE4
		[Min(0f)]
		[SerializeField]
		private float m_ContactRecycleDistance; // 0xE8
		[Min(0f)]
		[SerializeField]
		private float m_MaximumLinearSpeed; // 0xEC
		[SerializeField]
		private PhysicsWorld.DrawOptions m_DrawOptions; // 0xF0
		[SerializeField]
		private PhysicsWorld.DrawFillOptions m_DrawFillOptions; // 0xF4
		[SerializeField]
		private PhysicsWorld.DrawContactType m_DrawContactType; // 0xF8
		[SerializeField]
		private PhysicsWorld.IgnoreFilter m_DrawFilter; // 0xFC
		[SerializeField]
		private PhysicsWorld.DrawTarget m_DrawTarget; // 0x100
		[Range(1f, 5f)]
		[SerializeField]
		private float m_DrawThickness; // 0x104
		[Range(0f, 1f)]
		[SerializeField]
		private float m_DrawFillAlpha; // 0x108
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawPointScale; // 0x10C
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawNormalScale; // 0x110
		[FormerlySerializedAs("m_DrawImpulseScale")]
		[Range(0.0001f, 10f)]
		[SerializeField]
		private float m_DrawForceScale; // 0x114
		[SerializeField]
		private int m_DrawOrder; // 0x118
		[SerializeField]
		private PhysicsWorld.DrawColors m_DrawColors; // 0x11C
		[SerializeField]
		private PhysicsWorld.WorldCapacity m_Capacity; // 0x3EC
	
		// Properties
		public static PhysicsWorldDefinition defaultDefinition { get; } // 0x00000001822CD720-0x00000001822CD7E0 
	
		// Constructors
		public PhysicsWorldDefinition(); // 0x00000001822CD5A0-0x00000001822CD650
		public PhysicsWorldDefinition(bool useSettings); // 0x00000001822CD650-0x00000001822CD720
	}
}
