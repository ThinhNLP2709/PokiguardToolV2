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
	public struct PhysicsShapeDefinition // TypeDefIndex: 14698
	{
		// Fields
		public PhysicsShape.ContactFilter contactFilter; // 0x00
		public PhysicsShape.SurfaceMaterial surfaceMaterial; // 0x18
		[Min(0f)]
		[SerializeField]
		private float m_Density; // 0x38
		[SerializeField]
		private bool m_IsTrigger; // 0x3C
		[SerializeField]
		private bool m_TriggerEvents; // 0x3D
		[SerializeField]
		private bool m_ContactEvents; // 0x3E
		[SerializeField]
		private bool m_HitEvents; // 0x3F
		[SerializeField]
		private bool m_ContactFilterCallbacks; // 0x40
		[SerializeField]
		private bool m_PreSolveCallbacks; // 0x41
		[SerializeField]
		private bool m_StartStaticContacts; // 0x42
		[SerializeField]
		private bool m_StartMassUpdate; // 0x43
		[SerializeField]
		private bool m_WorldDrawing; // 0x44
		public PhysicsShape.MoverData moverData; // 0x48
	
		// Properties
		public static PhysicsShapeDefinition defaultDefinition { get; } // 0x00000001822C9F40-0x00000001822C9FD0 
	
		// Constructors
		public PhysicsShapeDefinition(); // 0x00000001822C9EC0-0x00000001822C9F40
		public PhysicsShapeDefinition(bool useSettings); // 0x00000001822C9E30-0x00000001822C9EC0
	}
}
