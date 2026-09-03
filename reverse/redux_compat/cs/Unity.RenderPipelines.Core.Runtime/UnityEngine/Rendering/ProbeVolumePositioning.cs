/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal static class ProbeVolumePositioning // TypeDefIndex: 5617
	{
		// Fields
		private static readonly Vector3[] m_Axes; // 0x00
		private static readonly Vector3[] m_AABBCorners; // 0x08
	
		// Constructors
		static ProbeVolumePositioning(); // 0x0000000181E87130-0x0000000181E871E0
	
		// Methods
		public static bool OBBIntersect([IsReadOnly] in ProbeReferenceVolume.Volume a, [IsReadOnly] in ProbeReferenceVolume.Volume b); // 0x0000000181E866B0-0x0000000181E86DF0
		public static bool OBBContains([IsReadOnly] in ProbeReferenceVolume.Volume obb, Vector3 point); // 0x0000000181E86540-0x0000000181E866B0
		public static bool OBBAABBIntersect([IsReadOnly] in ProbeReferenceVolume.Volume a, [IsReadOnly] in Bounds b, [IsReadOnly] in Bounds aAABB); // 0x0000000181E85EC0-0x0000000181E86540
		private static Vector2 ProjectOBB([IsReadOnly] in ProbeReferenceVolume.Volume a, Vector3 axis); // 0x0000000181E86ED0-0x0000000181E87130
		private static Vector2 ProjectAABB([IsReadOnly] in Vector3[] corners, Vector3 axis); // 0x0000000181E86DF0-0x0000000181E86ED0
	}
}
