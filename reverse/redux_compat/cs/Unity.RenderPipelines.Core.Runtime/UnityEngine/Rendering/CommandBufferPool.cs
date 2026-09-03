/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Pool;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class CommandBufferPool // TypeDefIndex: 5338
	{
		// Fields
		private static ObjectPool<CommandBuffer> s_BufferPool; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5339
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000181E278A0-0x0000000181E27910
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal CommandBuffer _.cctor_b__4_0(); // 0x0000000181E27830-0x0000000181E27880
			internal void _.cctor_b__4_1(CommandBuffer x); // 0x0000000181E27880-0x0000000181E278A0
		}
	
		// Constructors
		static CommandBufferPool(); // 0x0000000181E1F2F0-0x0000000181E1F480
	
		// Methods
		public static CommandBuffer Get(); // 0x0000000181E1F050-0x0000000181E1F0F0
		public static CommandBuffer Get(string name); // 0x0000000181E1F0F0-0x0000000181E1F180
		public static void Release(CommandBuffer buffer); // 0x0000000181E1F180-0x0000000181E1F2F0
	}
}
