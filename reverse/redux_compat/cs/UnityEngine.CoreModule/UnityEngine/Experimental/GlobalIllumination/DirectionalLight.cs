/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.GlobalIllumination
{
	public struct DirectionalLight // TypeDefIndex: 8213
	{
		// Fields
		public EntityId entityId; // 0x00
		public bool shadow; // 0x08
		public LightMode mode; // 0x09
		public Vector3 position; // 0x0C
		public Quaternion orientation; // 0x18
		public LinearColor color; // 0x28
		public LinearColor indirectColor; // 0x38
		public float indirectMultiplier; // 0x48
		public float penumbraWidthRadian; // 0x4C
		[Obsolete("Directional lights support cookies now. In order to position the cookie projection in the world, a position and full orientation are necessary. Use the position and orientation members instead of the direction parameter.", true)]
		public Vector3 direction; // 0x50
	}
}
