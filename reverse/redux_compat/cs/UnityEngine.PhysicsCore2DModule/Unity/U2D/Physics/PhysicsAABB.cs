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
	public struct PhysicsAABB // TypeDefIndex: 14660
	{
		// Fields
		[SerializeField]
		private Vector2 m_LowerBound; // 0x00
		[SerializeField]
		private Vector2 m_UpperBound; // 0x08
	
		// Properties
		public bool isValid { [IsReadOnly] get; } // 0x00000001822C6590-0x00000001822C65D0 
		public Vector2 lowerBound { [IsReadOnly] get; set; } // 0x0000000181E6F9A0-0x0000000181E6F9C0 0x0000000180CBE820-0x0000000180CBE830
		public Vector2 upperBound { [IsReadOnly] get; set; } // 0x0000000181DD08D0-0x0000000181DD08F0 0x0000000181663F00-0x0000000181663F10
	
		// Methods
		[IsReadOnly]
		public override string ToString(); // 0x00000001822C64C0-0x00000001822C6590
	}
}
