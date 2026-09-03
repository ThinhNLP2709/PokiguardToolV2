/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.GlobalIllumination
{
	[UsedByNativeCode]
	public struct LightDataGI // TypeDefIndex: 8219
	{
		// Fields
		public EntityId entityId; // 0x00
		public EntityId cookieTextureEntityId; // 0x08
		public float cookieScale; // 0x10
		public LinearColor color; // 0x14
		public LinearColor indirectColor; // 0x24
		public Quaternion orientation; // 0x34
		public Vector3 position; // 0x44
		public float range; // 0x50
		public float coneAngle; // 0x54
		public float innerConeAngle; // 0x58
		public float shape0; // 0x5C
		public float shape1; // 0x60
		public LightType type; // 0x64
		public LightMode mode; // 0x65
		public byte shadow; // 0x66
		public FalloffType falloff; // 0x67
		public float indirectMultiplier; // 0x68
		private int _padding; // 0x6C
	
		// Methods
		public void Init(ref DirectionalLight light, ref Cookie cookie); // 0x0000000182248570-0x00000001822485F0
		public void Init(ref PointLight light, ref Cookie cookie); // 0x00000001822486B0-0x0000000182248730
		public void Init(ref SpotLight light, ref Cookie cookie); // 0x00000001822484E0-0x0000000182248570
		public void Init(ref RectangleLight light, ref Cookie cookie); // 0x0000000182248850-0x00000001822488D0
		public void Init(ref DiscLight light, ref Cookie cookie); // 0x0000000182248730-0x00000001822487B0
		public void Init(ref DirectionalLight light); // 0x00000001822487B0-0x0000000182248850
		public void Init(ref PointLight light); // 0x00000001822488D0-0x0000000182248970
		public void Init(ref SpotLight light); // 0x00000001822485F0-0x00000001822486B0
		public void InitNoBake(EntityId lightEntityId); // 0x00000001822484D0-0x00000001822484E0
	}
}
