/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsWorld : IEquatable<Unity.U2D.Physics.PhysicsWorld> // TypeDefIndex: 14604
	{
		// Fields
		internal readonly ushort m_Index1; // 0x00
		private readonly ushort m_Generation; // 0x02
	
		// Properties
		public static int allocatedWorldCapacity { get; } // 0x00000001822D01B0-0x00000001822D01E0 
		public static bool alwaysDrawWorlds { get; } // 0x00000001822D01E0-0x00000001822D0210 
		public static bool isRenderingAllowed { get; } // 0x00000001822D0210-0x00000001822D0240 
		public bool isValid { get; } // 0x00000001822D0240-0x00000001822D0280 
	
		// Nested types
		public enum SimulationType // TypeDefIndex: 14605
		{
			FixedUpdate = 0,
			Update = 1,
			Script = 2
		}
	
		public enum TransformChangeMode // TypeDefIndex: 14606
		{
			Off = 0,
			FrameStart = 1,
			FixedUpdate = 2,
			Update = 3
		}
	
		public enum TransformWriteMode // TypeDefIndex: 14607
		{
			Off = 0,
			Fast2D = 1,
			Slow3D = 2,
			Custom = 3
		}
	
		public enum TransformTweenMode // TypeDefIndex: 14608
		{
			Off = 0,
			Parallel = 1,
			Sequential = 2,
			Custom = 3
		}
	
		[Flags]
		public enum TransformChangeReason // TypeDefIndex: 14609
		{
			WorldPosition = 1,
			WorldRotation = 2,
			WorldScale = 4,
			AnyWorld = 7,
			LocalPosition = 8,
			LocalRotation = 16,
			LocalScale = 32,
			AnyLocal = 56,
			Animation = 64,
			ParentHierarchy = 128,
			Any = 255
		}
	
		public enum TransformPlane // TypeDefIndex: 14610
		{
			XY = 0,
			XZ = 1,
			ZY = 2,
			Custom = 3
		}
	
		[Serializable]
		public struct TransformPlaneCustom : ISerializationCallbackReceiver // TypeDefIndex: 14611
		{
			// Fields
			[SerializeField]
			internal Vector3 m_Translate; // 0x00
			[SerializeField]
			internal Vector3 m_Rotate; // 0x0C
			[Range(0.001f, 10f)]
			[SerializeField]
			internal float m_Scale; // 0x18
			private Matrix4x4 m_ToCustom; // 0x1C
			private Matrix4x4 m_FromCustom; // 0x5C
			private Quaternion m_CustomRotation; // 0x9C
	
			// Properties
			public Matrix4x4 toCustom { [IsReadOnly] get; } // 0x00000001822D2C80-0x00000001822D2CB0 
	
			// Constructors
			public TransformPlaneCustom(); // 0x00000001822D2C30-0x00000001822D2C80
	
			// Methods
			[IsReadOnly]
			internal void PlaneProjection([IsReadOnly] in PhysicsTransform physicsTransform, out Vector3 position, out Quaternion rotation); // 0x00000001822D29D0-0x00000001822D2C20
			[IsReadOnly]
			public Vector3 ToPosition(Vector2 position); // 0x00000001822C37D0-0x00000001822C3960
			private void CalculatePlaneCustom(); // 0x00000001822D28C0-0x00000001822D29D0
			void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x00000001822D2C20-0x00000001822D2C30
			void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x00000001822D2C20-0x00000001822D2C30
		}
	
		[Flags]
		public enum IgnoreFilter // TypeDefIndex: 14612
		{
			None = 0,
			IgnoreStaticBodies = 1,
			IgnoreKinematicBodies = 2,
			IgnoreDynamicBodies = 4,
			IgnoreTriggerShapes = 8,
			IgnoreNonTriggerShapes = 16,
			IgnoreCircleShapes = 32,
			IgnoreCapsuleShapes = 64,
			IgnorePolygonShapes = 128,
			IgnoreSegmentShapes = 256,
			IgnoreChainSegmentShapes = 512
		}
	
		public enum RenderingMode // TypeDefIndex: 14613
		{
			EditorOnly = 0,
			DevelopmentPlayer = 1,
			AnyPlayer = 2
		}
	
		public enum DrawContactType // TypeDefIndex: 14614
		{
			Point = 1,
			AnchorA = 2,
			AnchorB = 3,
			Average = 4
		}
	
		public enum DrawTarget // TypeDefIndex: 14615
		{
			Both = 0,
			SceneView = 1,
			GameView = 2
		}
	
		[Serializable]
		public struct WorldCapacity // TypeDefIndex: 14616
		{
			// Fields
			[Min(0f)]
			[SerializeField]
			private int m_StaticShapeCount; // 0x00
			[Min(0f)]
			[SerializeField]
			private int m_DynamicShapeCount; // 0x04
			[Min(0f)]
			[SerializeField]
			private int m_StaticBodyCount; // 0x08
			[Min(0f)]
			[SerializeField]
			private int m_DynamicBodyCount; // 0x0C
			[Min(0f)]
			[SerializeField]
			private int m_ContactCount; // 0x10
		}
	
		[Flags]
		public enum DrawOptions // TypeDefIndex: 14617
		{
			Off = 0,
			SelectedBodies = 1,
			SelectedShapes = 2,
			SelectedShapeBounds = 4,
			SelectedJoints = 8,
			AllBodies = 16,
			AllShapes = 32,
			AllShapeBounds = 64,
			AllJoints = 128,
			AllContactPoints = 256,
			AllContactNormal = 512,
			AllContactImpulse = 1024,
			AllContactForces = 1024,
			AllContactFriction = 2048,
			AllCustom = 4096,
			DefaultSelected = 4106,
			DefaultAll = 4256,
			AllSolverIslands = 8192
		}
	
		[Flags]
		public enum DrawFillOptions // TypeDefIndex: 14618
		{
			Interior = 1,
			Outline = 2,
			Orientation = 4,
			All = 7
		}
	
		[IsReadOnly]
		public struct DrawResults // TypeDefIndex: 14619
		{
			// Fields
			internal readonly Scripting2D.PhysicsBuffer m_PolygonGeometryElements; // 0x00
			internal readonly Scripting2D.PhysicsBuffer m_CircleGeometryElements; // 0x10
			internal readonly Scripting2D.PhysicsBuffer m_CapsuleGeometryElements; // 0x20
			internal readonly Scripting2D.PhysicsBuffer m_LineElements; // 0x30
			internal readonly Scripting2D.PhysicsBuffer m_PointElements; // 0x40
	
			// Properties
			public bool isValid { get; } // 0x00000001822C5370-0x00000001822C53A0 
			public NativeArray<PolygonGeometryElement> polygonGeometryArray { get; } // 0x00000001822C5400-0x00000001822C5430 
			public NativeArray<CircleGeometryElement> circleGeometryArray { get; } // 0x00000001822C5340-0x00000001822C5370 
			public NativeArray<CapsuleGeometryElement> capsuleGeometryArray { get; } // 0x00000001822C5310-0x00000001822C5340 
			public NativeArray<LineElement> lineArray { get; } // 0x00000001822C53A0-0x00000001822C53D0 
			public NativeArray<PointElement> pointArray { get; } // 0x00000001822C53D0-0x00000001822C5400 
	
			// Nested types
			[IsReadOnly]
			public struct PolygonGeometryElement // TypeDefIndex: 14620
			{
				// Fields
				public readonly PhysicsTransform transform; // 0x00
				public readonly Vector2 p0; // 0x10
				public readonly Vector2 p1; // 0x18
				public readonly Vector2 p2; // 0x20
				public readonly Vector2 p3; // 0x28
				public readonly Vector2 p4; // 0x30
				public readonly Vector2 p5; // 0x38
				public readonly Vector2 p6; // 0x40
				public readonly Vector2 p7; // 0x48
				public readonly int count; // 0x50
				public readonly float radius; // 0x54
				public readonly float elementDepth; // 0x58
				public readonly DrawFillOptions drawFillOptions; // 0x5C
				public readonly Color color; // 0x60
	
				// Methods
				public static int Size(); // 0x0000000180A2FAF0-0x0000000180A2FB00
			}
	
			[IsReadOnly]
			public struct CircleGeometryElement // TypeDefIndex: 14621
			{
				// Fields
				public readonly PhysicsTransform transform; // 0x00
				public readonly float radius; // 0x10
				public readonly float elementDepth; // 0x14
				public readonly DrawFillOptions drawFillOptions; // 0x18
				public readonly Color color; // 0x1C
	
				// Methods
				public static int Size(); // 0x0000000180A2FB00-0x0000000180A2FB10
			}
	
			[IsReadOnly]
			public struct CapsuleGeometryElement // TypeDefIndex: 14622
			{
				// Fields
				public readonly PhysicsTransform transform; // 0x00
				public readonly float radius; // 0x10
				public readonly float length; // 0x14
				public readonly float elementDepth; // 0x18
				public readonly DrawFillOptions drawFillOptions; // 0x1C
				public readonly Color color; // 0x20
	
				// Methods
				public static int Size(); // 0x0000000180A2FA90-0x0000000180A2FAA0
			}
	
			[IsReadOnly]
			public struct LineElement // TypeDefIndex: 14623
			{
				// Fields
				public readonly PhysicsTransform transform; // 0x00
				public readonly float length; // 0x10
				public readonly float elementDepth; // 0x14
				public readonly Color color; // 0x18
	
				// Methods
				public static int Size(); // 0x0000000180A2FAD0-0x0000000180A2FAE0
			}
	
			[IsReadOnly]
			public struct PointElement // TypeDefIndex: 14624
			{
				// Fields
				public readonly Vector2 position; // 0x00
				public readonly float radius; // 0x08
				public readonly float elementDepth; // 0x0C
				public readonly Color color; // 0x10
	
				// Methods
				public static int Size(); // 0x0000000180A2FAE0-0x0000000180A2FAF0
			}
	
			// Methods
			public override string ToString(); // 0x00000001822C5080-0x00000001822C5310
		}
	
		[Serializable]
		public struct DrawColors // TypeDefIndex: 14625
		{
			// Fields
			public Color transformAxisX; // 0x00
			public Color transformAxisY; // 0x10
			public Color bodyBad; // 0x20
			public Color bodyDisabled; // 0x30
			public Color bodyAwake; // 0x40
			public Color bodyStatic; // 0x50
			public Color bodyKinematic; // 0x60
			public Color bodyTimeOfImpactEvent; // 0x70
			public Color bodyFastCollisions; // 0x80
			public Color bodyMovingFast; // 0x90
			public Color bodySpeedCapped; // 0xA0
			public Color shapeTrigger; // 0xB0
			public Color shapeOther; // 0xC0
			public Color shapeBounds; // 0xD0
			public Color contactSpeculative; // 0xE0
			public Color contactAdded; // 0xF0
			public Color contactPersisted; // 0x100
			public Color contactNormal; // 0x110
			public Color contactImpulse; // 0x120
			public Color contactFriction; // 0x130
			public Color solverIsland; // 0x140
			private readonly ConstraintGraphArray m_ConstraintGraph; // 0x150
	
			// Nested types
			[DefaultMember("Item")]
			private struct ConstraintGraphArray // TypeDefIndex: 14626
			{
				// Fields
				public Color graphConstraint0; // 0x00
				public Color graphConstraint1; // 0x10
				public Color graphConstraint2; // 0x20
				public Color graphConstraint3; // 0x30
				public Color graphConstraint4; // 0x40
				public Color graphConstraint5; // 0x50
				public Color graphConstraint6; // 0x60
				public Color graphConstraint7; // 0x70
				public Color graphConstraint8; // 0x80
				public Color graphConstraint9; // 0x90
				public Color graphConstraint10; // 0xA0
				public Color graphConstraint11; // 0xB0
				public Color graphConstraint12; // 0xC0
				public Color graphConstraint13; // 0xD0
				public Color graphConstraint14; // 0xE0
				public Color graphConstraint15; // 0xF0
				public Color graphConstraint16; // 0x100
				public Color graphConstraint17; // 0x110
				public Color graphConstraint18; // 0x120
				public Color graphConstraint19; // 0x130
				public Color graphConstraint20; // 0x140
				public Color graphConstraint21; // 0x150
				public Color graphConstraint22; // 0x160
				public Color graphConstraint23; // 0x170
			}
		}
	
		// Methods
		public override string ToString(); // 0x00000001822D0130-0x00000001822D01B0
		public override bool Equals(object obj); // 0x00000001822CF250-0x00000001822CF2E0
		public bool Equals(PhysicsWorld other); // 0x000000018226A7F0-0x000000018226A810
		public override int GetHashCode(); // 0x00000001822CF2E0-0x00000001822CF340
		public static void SetTransform(Transform transform, ref Vector3 position, ref Quaternion rotation, bool transformChangedEvent = false /* Metadata: 0x006A971A */); // 0x00000001822D00C0-0x00000001822D0130
		public static void SetTransformAccess(ref TransformAccess transformAccess, ref Vector3 position, ref Quaternion rotation, bool transformChangedEvent = false /* Metadata: 0x006A971B */); // 0x00000001822CFFE0-0x00000001822D0050
		internal void SetTransformWriteTweens(ReadOnlySpan<PhysicsBody.TransformWriteTween> transformWriteTweens); // 0x00000001822D0050-0x00000001822D00C0
		public void SendBodyUpdateCallbacks(); // 0x00000001822CF340-0x00000001822CF590
		public void SendContactCallbacks(); // 0x00000001822CF590-0x00000001822CF9C0
		public void SendTriggerCallbacks(); // 0x00000001822CFBE0-0x00000001822CFFE0
		public void SendJointThresholdCallbacks(); // 0x00000001822CF9C0-0x00000001822CFBE0
		internal static void DrawAllWorlds(PhysicsAABB drawAABB, DrawTarget cameraTarget); // 0x00000001822CF210-0x00000001822CF250
	}
}
