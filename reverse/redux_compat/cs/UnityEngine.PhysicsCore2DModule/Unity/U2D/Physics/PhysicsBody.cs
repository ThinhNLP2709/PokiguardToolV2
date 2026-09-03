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
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsBody : IEquatable<Unity.U2D.Physics.PhysicsBody> // TypeDefIndex: 14628
	{
		// Fields
		private readonly PhysicsHandle m_PhysicsHandle; // 0x00
	
		// Properties
		public bool isValid { get; } // 0x00000001822C6900-0x00000001822C6940 
		public object callbackTarget { get; } // 0x00000001822C68C0-0x00000001822C6900 
	
		// Nested types
		public enum BodyType // TypeDefIndex: 14629
		{
			Dynamic = 0,
			Kinematic = 1,
			Static = 2
		}
	
		[Flags]
		public enum BodyConstraints // TypeDefIndex: 14630
		{
			None = 0,
			PositionX = 1,
			PositionY = 2,
			Position = 3,
			Rotation = 4,
			All = 7
		}
	
		public enum TransformWriteMode // TypeDefIndex: 14631
		{
			Current = 0,
			Interpolate = 1,
			Extrapolate = 2,
			Off = 3
		}
	
		public struct TransformWriteTween // TypeDefIndex: 14632
		{
			// Fields
			private PhysicsBody m_Body; // 0x00
			private TransformWriteMode m_TransformWriteMode; // 0x08
			private PhysicsTransform m_PhysicsTransform; // 0x0C
			private EntityId m_TransformId; // 0x20
			private int m_TransformDepth; // 0x28
			private Vector2 m_LinearVelocity; // 0x2C
			private float m_AngularVelocity; // 0x34
			private Vector3 m_PositionFrom; // 0x38
			private Quaternion m_RotationFrom; // 0x44
	
			// Properties
			public PhysicsBody body { [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public TransformWriteMode transformWriteMode { [IsReadOnly] get; } // 0x0000000180732D20-0x0000000180732D30 
			public PhysicsTransform physicsTransform { [IsReadOnly] get; } // 0x0000000181D8BE90-0x0000000181D8BEA0 
			public Transform transform { [IsReadOnly] get; } // 0x00000001822D3050-0x00000001822D3120 
			public Vector2 linearVelocity { [IsReadOnly] get; } // 0x00000001822D3020-0x00000001822D3040 
			public float angularVelocity { [IsReadOnly] get; } // 0x0000000181230A40-0x0000000181230A50 
			public Vector3 positionFrom { [IsReadOnly] get; } // 0x0000000181D8BE50-0x0000000181D8BE70 
			public Quaternion rotationFrom { [IsReadOnly] get; } // 0x00000001822D3040-0x00000001822D3050 
	
			// Methods
			[IsReadOnly]
			public void GetPose(PhysicsWorld.TransformPlane transformPlane, ref PhysicsWorld.TransformPlaneCustom transformPlaneCustom, bool fast2D, out Vector3 position, out Quaternion rotation); // 0x00000001822D2DF0-0x00000001822D3020
		}
	
		// Methods
		public override string ToString(); // 0x00000001822C68B0-0x00000001822C68C0
		public override bool Equals(object obj); // 0x00000001822C67A0-0x00000001822C6840
		public bool Equals(PhysicsBody other); // 0x00000001822C6770-0x00000001822C67A0
		public override int GetHashCode(); // 0x00000001822C6840-0x00000001822C68B0
	}
}
