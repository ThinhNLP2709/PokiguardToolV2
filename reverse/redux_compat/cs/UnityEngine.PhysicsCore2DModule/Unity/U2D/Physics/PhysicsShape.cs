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
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsShape : IEquatable<Unity.U2D.Physics.PhysicsShape> // TypeDefIndex: 14634
	{
		// Fields
		private readonly PhysicsHandle m_PhysicsHandle; // 0x00
	
		// Properties
		public bool isValid { get; } // 0x00000001822CA0B0-0x00000001822CA0F0 
		public object callbackTarget { get; } // 0x00000001822CA070-0x00000001822CA0B0 
	
		// Nested types
		[Serializable]
		public struct SurfaceMaterial // TypeDefIndex: 14635
		{
			// Fields
			[Min(0f)]
			[SerializeField]
			private float m_Friction; // 0x00
			[Min(0f)]
			[SerializeField]
			private float m_Bounciness; // 0x04
			[FormerlySerializedAs("m_FrictionCombine")]
			[SerializeField]
			private MixingMode m_FrictionMixing; // 0x08
			[FormerlySerializedAs("m_BouncinessCombine")]
			[SerializeField]
			private MixingMode m_BouncinessMixing; // 0x0C
			[Range(0f, 65535f)]
			[SerializeField]
			private ushort m_FrictionPriority; // 0x10
			[Range(0f, 65535f)]
			[SerializeField]
			private ushort m_BouncinessPriority; // 0x12
			[Min(0f)]
			[SerializeField]
			private float m_RollingResistance; // 0x14
			[SerializeField]
			private float m_TangentSpeed; // 0x18
			[SerializeField]
			private Color32 m_CustomColor; // 0x1C
	
			// Properties
			public static SurfaceMaterial defaultMaterial { get; } // 0x00000001822D27E0-0x00000001822D2840 
	
			// Nested types
			public enum MixingMode // TypeDefIndex: 14636
			{
				Average = 0,
				Mean = 1,
				Multiply = 2,
				Minimum = 3,
				Maximum = 4
			}
	
			// Constructors
			public SurfaceMaterial(); // 0x00000001822D2780-0x00000001822D27E0
		}
	
		[IsReadOnly]
		public struct ContactId // TypeDefIndex: 14637
		{
			// Fields
			private readonly int m_IndexId; // 0x00
			private readonly ushort m_WorldId; // 0x04
			private readonly ushort m_Padding; // 0x06
			private readonly int m_GenerationId; // 0x08
	
			// Methods
			public override string ToString(); // 0x00000001822C4FE0-0x00000001822C5080
		}
	
		public enum ContactFilterMode // TypeDefIndex: 14638
		{
			Both = 0,
			Either = 1
		}
	
		public enum ContactFilterGroupMode // TypeDefIndex: 14639
		{
			Group = 0,
			Filtering = 1
		}
	
		[Serializable]
		public struct ContactFilter // TypeDefIndex: 14640
		{
			// Fields
			public static readonly PhysicsMask DefaultCategories; // 0x00
			public static readonly PhysicsMask DefaultContacts; // 0x08
			public static readonly ContactFilter Everything; // 0x10
			public static readonly ContactFilter defaultFilter; // 0x28
			[SerializeField]
			internal PhysicsMask m_Categories; // 0x00
			[SerializeField]
			internal PhysicsMask m_Contacts; // 0x08
			[SerializeField]
			internal int m_GroupIndex; // 0x10
	
			// Constructors
			public ContactFilter(PhysicsMask categories, PhysicsMask contacts, int groupIndex = 0 /* Metadata: 0x006A978F */); // 0x00000001822C4FD0-0x00000001822C4FE0
			static ContactFilter(); // 0x00000001822C4EC0-0x00000001822C4FD0
		}
	
		[Serializable]
		public struct MoverData // TypeDefIndex: 14641
		{
			// Fields
			[Min(0f)]
			[SerializeField]
			private float m_PushLimit; // 0x00
			[SerializeField]
			private bool m_ClipVelocity; // 0x04
	
			// Constructors
			public MoverData(); // 0x00000001822C64B0-0x00000001822C64C0
		}
	
		// Methods
		public override string ToString(); // 0x00000001822C68B0-0x00000001822C68C0
		public override bool Equals(object obj); // 0x00000001822C9FD0-0x00000001822CA070
		public bool Equals(PhysicsShape other); // 0x00000001822C6770-0x00000001822C67A0
		public override int GetHashCode(); // 0x00000001822C6840-0x00000001822C68B0
	}
}
