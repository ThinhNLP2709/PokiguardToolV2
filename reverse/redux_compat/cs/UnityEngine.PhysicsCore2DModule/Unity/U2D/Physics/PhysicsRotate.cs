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
	public struct PhysicsRotate : ISerializationCallbackReceiver // TypeDefIndex: 14642
	{
		// Fields
		public Vector2 direction; // 0x00
		private static readonly PhysicsRotate identityRotation; // 0x00
		private static readonly PhysicsRotate leftRotation; // 0x08
		private static readonly PhysicsRotate upRotation; // 0x10
		private static readonly PhysicsRotate downRotation; // 0x18
	
		// Properties
		public float cos { [IsReadOnly] get; } // 0x000000018035C780-0x000000018035C790 
		public float sin { [IsReadOnly] get; } // 0x000000018035C790-0x000000018035C7A0 
		public bool isValid { [IsReadOnly] get; } // 0x00000001822C9DB0-0x00000001822C9DF0 
		public float radians { [IsReadOnly] get; } // 0x00000001822C9DF0-0x00000001822C9E30 
		public float degrees { [IsReadOnly] get; } // 0x00000001822C9CA0-0x00000001822C9D50 
		public static PhysicsRotate identity { get; } // 0x00000001822C9D50-0x00000001822C9DB0 
	
		// Constructors
		public PhysicsRotate(); // 0x00000001822C9C70-0x00000001822C9CA0
		public PhysicsRotate(Vector2 direction); // 0x00000001822C9C30-0x00000001822C9C70
		static PhysicsRotate(); // 0x00000001822C9AD0-0x00000001822C9C30
	
		// Methods
		public static PhysicsRotate FromRadians(float radians); // 0x00000001822C9710-0x00000001822C9760
		[IsReadOnly]
		public PhysicsRotate IntegrateRotation(float deltaAngle); // 0x00000001822C9760-0x00000001822C97C0
		public void OnBeforeSerialize(); // 0x00000001822C9890-0x00000001822C9960
		public void OnAfterDeserialize(); // 0x00000001822C97C0-0x00000001822C9890
		[IsReadOnly]
		public override string ToString(); // 0x00000001822C9960-0x00000001822C9AD0
	}
}
