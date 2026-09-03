/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[StaticAccessor("GeometryUtilityScripting", StaticAccessorType.DoubleColon)]
	public sealed class GeometryUtility // TypeDefIndex: 7525
	{
		// Methods
		public static void CalculateFrustumPlanes([IsReadOnly] in Matrix4x4 worldToProjectionMatrix, Span<Plane> planes); // 0x000000018218ED90-0x000000018218EEF0
		public static void CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix, Plane[] planes); // 0x000000018218EEF0-0x000000018218F080
		[NativeName("ExtractPlanes")]
		private static void Internal_ExtractPlanes(Span<Plane> planes, [IsReadOnly] in Matrix4x4 worldToProjectionMatrix); // 0x000000018218F0D0-0x000000018218F140
		private static void Internal_ExtractPlanes_Injected(ref ManagedSpanWrapper planes, [IsReadOnly] in Matrix4x4 worldToProjectionMatrix); // 0x000000018218F080-0x000000018218F0D0
	}
}
