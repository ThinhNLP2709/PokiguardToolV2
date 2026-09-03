/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 82: Unity.2D.Animation.Profiler.dll - Assembly: Unity.2D.Animation.Profiler, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15953-15956

namespace UnityEngine.U2D.Animation.Profiler
{
	[Serializable]
	internal struct SpriteSkinProfilerFrameData // TypeDefIndex: 15955
	{
		// Fields
		public EntityId gameObjectEntityId; // 0x00
		public EntityId rootBoneGameObjectEntityId; // 0x08
		public int boneCount; // 0x10
		public int type; // 0x14
	
		// Nested types
		public enum SpriteSkinType // TypeDefIndex: 15956
		{
			Unknown = 0,
			CPU = 1,
			GPU = 2
		}
	
		// Methods
		public static string GetSpriteSkinTypeName(int type); // 0x0000000181C155B0-0x0000000181C15620
	}
}
