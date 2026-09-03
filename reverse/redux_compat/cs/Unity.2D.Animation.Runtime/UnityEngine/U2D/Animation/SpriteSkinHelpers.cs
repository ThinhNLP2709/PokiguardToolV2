/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal static class SpriteSkinHelpers // TypeDefIndex: 14415
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 14416
		{
			// Fields
			public string boneHash; // 0x10
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetSpriteBonesTransforms_b__0(Bone x); // 0x0000000181C2E9A0-0x0000000181C2E9D0
		}
	
		// Methods
		public static void CacheChildren(Transform current, Dictionary<int, List<SpriteSkin.TransformData>> cache); // 0x0000000181C25D40-0x0000000181C25FE0
		public static string GenerateTransformPath(Transform rootBone, Transform child); // 0x0000000181C26100-0x0000000181C26200
		public static bool GetSpriteBonesTransforms(SpriteSkin spriteSkin, out Transform[] outTransform, bool forceCreateCache = false /* Metadata: 0x006A96FA */); // 0x0000000181C266B0-0x0000000181C26B10
		private static bool GetSpriteBonesTransformFromPath(SpriteBone[] spriteBones, Dictionary<int, List<SpriteSkin.TransformData>> hierarchyCache, Transform[] outNewBoneTransform); // 0x0000000181C26200-0x0000000181C266B0
		private static void CalculateBoneTransformsPath(int index, SpriteBone[] spriteBones, string[] paths); // 0x0000000181C25FE0-0x0000000181C26100
	}
}
