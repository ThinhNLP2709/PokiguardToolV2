/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.U2D
{
	[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
	[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
	public static class SpriteDataAccessExtensions // TypeDefIndex: 8465
	{
		// Methods
		private static void CheckAttributeTypeMatchesAndThrow<T>(VertexAttribute channel);
		private static SpriteChannelInfo GetBindPoseInfo([NotNull] Sprite sprite); // 0x000000018226C9E0-0x000000018226CA90
		private static SpriteChannelInfo GetIndicesInfo([NotNull] Sprite sprite); // 0x000000018226CDB0-0x000000018226CE60
		private static SpriteChannelInfo GetChannelInfo([NotNull] Sprite sprite, VertexAttribute channel); // 0x000000018226CCA0-0x000000018226CD60
		private static SpriteBone[] GetBoneInfo([NotNull] Sprite sprite); // 0x000000018226CBC0-0x000000018226CC50
		internal static int GetPrimaryVertexStreamSize(Sprite sprite); // 0x000000018226CF90-0x000000018226CFD0
		private static bool HasVertexAttribute_Injected(IntPtr sprite, VertexAttribute channel); // 0x000000018226D0A0-0x000000018226D0E0
		private static int GetVertexCount_Injected(IntPtr sprite); // 0x000000018226CFD0-0x000000018226D010
		private static void GetBindPoseInfo_Injected(IntPtr sprite, ); // 0x000000018226C990-0x000000018226C9E0
		private static void GetIndicesInfo_Injected(IntPtr sprite, ); // 0x000000018226CD60-0x000000018226CDB0
		private static void GetChannelInfo_Injected(IntPtr sprite, VertexAttribute channel, ); // 0x000000018226CC50-0x000000018226CCA0
		private static SpriteBone[] GetBoneInfo_Injected(IntPtr sprite); // 0x000000018226CB80-0x000000018226CBC0
		private static int GetPrimaryVertexStreamSize_Injected(IntPtr sprite); // 0x000000018226CF50-0x000000018226CF90
	
		// Extension methods
		public static NativeSlice<T> GetVertexAttribute<T>(this Sprite sprite, VertexAttribute channel)
			where T : struct;
		public static NativeArray<Matrix4x4> GetBindPoses(this Sprite sprite); // 0x000000018226CA90-0x000000018226CB80
		public static NativeArray<ushort> GetIndices(this Sprite sprite); // 0x000000018226CE60-0x000000018226CF50
		public static SpriteBone[] GetBones(this Sprite sprite); // 0x000000018226CBC0-0x000000018226CC50
		[NativeName("HasChannel")]
		public static bool HasVertexAttribute([NotNull] this Sprite sprite, VertexAttribute channel); // 0x000000018226D0E0-0x000000018226D180
		public static int GetVertexCount([NotNull] this Sprite sprite); // 0x000000018226D010-0x000000018226D0A0
	}
}
