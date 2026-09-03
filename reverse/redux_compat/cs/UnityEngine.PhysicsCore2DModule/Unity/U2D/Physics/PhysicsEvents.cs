/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsEvents // TypeDefIndex: 14643
	{
		// Fields
		[CompilerGenerated]
		private static PreSimulateEventHandler s_PreSimulate; // 0x00
		[CompilerGenerated]
		private static PostSimulateEventHandler s_PostSimulate; // 0x08
		[CompilerGenerated]
		private static WorldDrawResultsEventHandler s_WorldDrawResults; // 0x10
		[CompilerGenerated]
		private static WorldDefinitionChangeEventHandler s_WorldDefinitionChange; // 0x18
		[CompilerGenerated]
		private static WorldTransformPlaneChangeEventHandler s_WorldTransformPlaneChange; // 0x20
	
		// Nested types
		[IsReadOnly]
		public struct TransformWriteEvent // TypeDefIndex: 14644
		{
			// Fields
			private readonly PhysicsWorld m_World; // 0x00
			private readonly PhysicsWorld.SimulationType m_SimulationType; // 0x04
			private readonly PhysicsWorld.TransformPlane m_TransformPlane; // 0x08
			private readonly PhysicsWorld.TransformPlaneCustom m_TransfomPlaneCustom; // 0x0C
			private readonly PhysicsWorld.TransformTweenMode m_TransformTweenMode; // 0xB8
			private readonly NativeArray<PhysicsBody.TransformWriteTween> m_TransformWriteTweens; // 0xC0
	
			// Constructors
			internal TransformWriteEvent(PhysicsWorld world, PhysicsWorld.SimulationType simulationType, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transfomPlaneCustom, PhysicsWorld.TransformTweenMode transformTweenMode, ref NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens); // 0x00000001822D2D50-0x00000001822D2DF0
		}
	
		[IsReadOnly]
		public struct TransformTweenWriteEvent // TypeDefIndex: 14645
		{
			// Fields
			private readonly PhysicsWorld m_World; // 0x00
			private readonly float m_InterpolationTime; // 0x04
			private readonly float m_ExtrapolationTime; // 0x08
			private readonly PhysicsWorld.TransformPlane m_TransformPlane; // 0x0C
			private readonly PhysicsWorld.TransformPlaneCustom m_TransfomPlaneCustom; // 0x10
			private readonly NativeArray<PhysicsBody.TransformWriteTween> m_TransformWriteTweens; // 0xC0
	
			// Constructors
			internal TransformTweenWriteEvent(PhysicsWorld world, float interpolationTime, float extrapolationTime, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transfomPlaneCustom, ref NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens); // 0x00000001822D2CB0-0x00000001822D2D50
		}
	
		[IsReadOnly]
		public struct BodyUpdateEvent // TypeDefIndex: 14646
		{
			// Fields
			private readonly IntPtr m_UserData; // 0x00
			private readonly PhysicsTransform m_Transform; // 0x08
			private readonly PhysicsBody m_Body; // 0x18
			private readonly bool m_FellAsleep; // 0x20
	
			// Properties
			public PhysicsTransform transform { get; } // 0x0000000180C57230-0x0000000180C57240 
			public PhysicsBody body { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public bool fellAsleep { get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
	
			// Methods
			public override string ToString(); // 0x00000001822C3B50-0x00000001822C3C20
		}
	
		[IsReadOnly]
		public struct TriggerBeginEvent // TypeDefIndex: 14647
		{
			// Fields
			private readonly PhysicsShape m_TriggerShape; // 0x00
			private readonly PhysicsShape m_VisitorShape; // 0x08
			private readonly bool m_FirstGroup; // 0x10
	
			// Properties
			public PhysicsShape triggerShape { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public PhysicsShape visitorShape { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
			public bool firstGroup { get; } // 0x00000001805625D0-0x00000001805625E0 
	
			// Methods
			public override string ToString(); // 0x00000001822D3120-0x00000001822D31D0
		}
	
		[IsReadOnly]
		public struct TriggerEndEvent // TypeDefIndex: 14648
		{
			// Fields
			private readonly PhysicsShape m_TriggerShape; // 0x00
			private readonly PhysicsShape m_VisitorShape; // 0x08
			private readonly bool m_LastGroup; // 0x10
	
			// Properties
			public PhysicsShape triggerShape { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public PhysicsShape visitorShape { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
			public bool lastGroup { get; } // 0x00000001805625D0-0x00000001805625E0 
	
			// Methods
			public override string ToString(); // 0x00000001822D3330-0x00000001822D33E0
		}
	
		[IsReadOnly]
		public struct ContactBeginEvent // TypeDefIndex: 14649
		{
			// Fields
			private readonly PhysicsShape m_ShapeA; // 0x00
			private readonly PhysicsShape m_ShapeB; // 0x08
			private readonly PhysicsShape.ContactId m_ContactId; // 0x10
			private readonly bool m_FirstGroup; // 0x1C
	
			// Properties
			public PhysicsShape shapeA { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public PhysicsShape shapeB { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
			public PhysicsShape.ContactId contactId { get; } // 0x0000000180719290-0x00000001807192B0 
			public bool firstGroup { get; } // 0x0000000180E38E30-0x0000000180E38E40 
	
			// Methods
			public override string ToString(); // 0x00000001822C4670-0x00000001822C4890
		}
	
		[IsReadOnly]
		public struct ContactEndEvent // TypeDefIndex: 14650
		{
			// Fields
			private readonly PhysicsShape m_ShapeA; // 0x00
			private readonly PhysicsShape m_ShapeB; // 0x08
			private readonly PhysicsShape.ContactId m_ContactId; // 0x10
			private readonly bool m_LastGroup; // 0x1C
	
			// Properties
			public PhysicsShape shapeA { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public PhysicsShape shapeB { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
			public PhysicsShape.ContactId contactId { get; } // 0x0000000180719290-0x00000001807192B0 
			public bool lastGroup { get; } // 0x0000000180E38E30-0x0000000180E38E40 
	
			// Methods
			public override string ToString(); // 0x00000001822C4A70-0x00000001822C4C90
		}
	
		[IsReadOnly]
		public struct ContactFilterEvent // TypeDefIndex: 14651
		{
			// Fields
			private readonly PhysicsWorld m_PhysicsWorld; // 0x00
			private readonly PhysicsShape m_ShapeA; // 0x04
			private readonly PhysicsShape m_ShapeB; // 0x0C
	
			// Properties
			public PhysicsWorld physicsWorld { get; } // 0x0000000180732D10-0x0000000180732D20 
			public PhysicsShape shapeA { get; } // 0x0000000180C57300-0x0000000180C57310 
			public PhysicsShape shapeB { get; } // 0x00000001822C4EB0-0x00000001822C4EC0 
	
			// Methods
			public override string ToString(); // 0x00000001822C4DF0-0x00000001822C4EB0
		}
	
		[IsReadOnly]
		public struct PreSolveEvent // TypeDefIndex: 14652
		{
			// Fields
			private readonly PhysicsWorld m_PhysicsWorld; // 0x00
			private readonly PhysicsShape m_ShapeA; // 0x04
			private readonly PhysicsShape m_ShapeB; // 0x0C
			private readonly Vector2 m_Point; // 0x14
			private readonly Vector2 m_Normal; // 0x1C
	
			// Properties
			public PhysicsWorld physicsWorld { get; } // 0x0000000180732D10-0x0000000180732D20 
			public PhysicsShape shapeA { get; } // 0x0000000180C57300-0x0000000180C57310 
			public PhysicsShape shapeB { get; } // 0x00000001822C4EB0-0x00000001822C4EC0 
			public Vector2 point { get; } // 0x000000018112F6D0-0x000000018112F6F0 
			public Vector2 normal { get; } // 0x00000001822D0EE0-0x00000001822D0F00 
	
			// Methods
			public override string ToString(); // 0x00000001822D0C60-0x00000001822D0EE0
		}
	
		[IsReadOnly]
		public struct JointThresholdEvent // TypeDefIndex: 14653
		{
			// Fields
			private readonly PhysicsJoint m_Joint; // 0x00
			private readonly IntPtr m_UserData; // 0x08
	
			// Properties
			public PhysicsJoint joint { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
			// Methods
			public override string ToString(); // 0x00000001822C5BD0-0x00000001822C5C40
		}
	
		[IsReadOnly]
		public struct TransformChangeEvent // TypeDefIndex: 14654
		{
			// Fields
			private readonly EntityId m_TransformId; // 0x00
			private readonly PhysicsWorld.TransformChangeReason m_ChangeReason; // 0x08
	
			// Properties
			public Transform transform { get; } // 0x00000001822D2840-0x00000001822D28C0 
		}
	
		public delegate void PreSimulateEventHandler(PhysicsWorld world, float deltaTime); // TypeDefIndex: 14655; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void PostSimulateEventHandler(PhysicsWorld world, float deltaTime); // TypeDefIndex: 14656; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void WorldDrawResultsEventHandler(PhysicsWorld world, ref PhysicsWorld.DrawResults drawResults); // TypeDefIndex: 14657; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void WorldDefinitionChangeEventHandler(PhysicsWorld world); // TypeDefIndex: 14658; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void WorldTransformPlaneChangeEventHandler(PhysicsWorld world, PhysicsWorld.TransformPlane oldTransformPlane, PhysicsWorld.TransformPlane newTransformPlane); // TypeDefIndex: 14659; 0x0000000180A72B30-0x0000000180A72B50
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokePreSimulate(PhysicsWorld world, float deltaTime); // 0x00000001822C8290-0x00000001822C8320
		[RequiredByNativeCode]
		private static void InvokePostSimulate(PhysicsWorld world, float deltaTime); // 0x00000001822C8200-0x00000001822C8290
		[RequiredByNativeCode]
		private static bool SendContactFilterCallback(object callbackTarget, ContactFilterEvent contactFilterEvent); // 0x00000001822C8530-0x00000001822C8610
		[RequiredByNativeCode]
		private static bool SendPreSolveCallback(object callbackTarget, PreSolveEvent preSolveEvent); // 0x00000001822C8630-0x00000001822C8710
		[RequiredByNativeCode]
		private static void SendBodyUpdateCallbacks(PhysicsWorld world); // 0x00000001822C84F0-0x00000001822C8510
		[RequiredByNativeCode]
		private static void SendContactCallbacks(PhysicsWorld world); // 0x00000001822C8510-0x00000001822C8530
		[RequiredByNativeCode]
		private static void SendTriggerCallbacks(PhysicsWorld world); // 0x00000001822C8710-0x00000001822C8730
		[RequiredByNativeCode]
		private static void SendJointThresholdCallbacks(PhysicsWorld world); // 0x00000001822C8610-0x00000001822C8630
		[RequiredByNativeCode]
		internal static void InvokeWorldDrawResultsEvent(PhysicsWorld world, ref PhysicsWorld.DrawResults drawResults); // 0x00000001822C83B0-0x00000001822C8440
		[RequiredByNativeCode]
		internal static void InvokeWorldDefinitionChangeEvent(PhysicsWorld world); // 0x00000001822C8320-0x00000001822C83B0
		[RequiredByNativeCode]
		internal static void InvokeWorldTransformPlaneChangeEvent(PhysicsWorld world, PhysicsWorld.TransformPlane oldTransformPlane, PhysicsWorld.TransformPlane newTransformPlane); // 0x00000001822C8440-0x00000001822C84F0
	}
}
