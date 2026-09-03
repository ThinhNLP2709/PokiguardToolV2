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

namespace Unity.Collections.LowLevel.Unsafe
{
	[NativeHeader("Runtime/Export/BurstLike/BurstLike.bindings.h")]
	[StaticAccessor("BurstLike", StaticAccessorType.DoubleColon)]
	[VisibleToOtherModules(new string[3] {"UnityEngine.ParticleSystemModule", "UnityEngine.AudioModule", "UnityEngine.AnimationModule" })]
	internal static class BurstLike // TypeDefIndex: 7435
	{
		// Nested types
		[IsReadOnly]
		[VisibleToOtherModules(new string[3] {"UnityEngine.ParticleSystemModule", "UnityEngine.AudioModule", "UnityEngine.AnimationModule" })]
		internal struct SharedStatic<T> // TypeDefIndex: 7436
			where T : struct
		{
			// Fields
			private readonly unsafe void* _buffer;
	
			// Properties
			public ref T Data { get; }
	
			// Constructors
			private unsafe SharedStatic(void* buffer);
	
			// Methods
			public static SharedStatic<T> GetOrCreate<TContext>(uint alignment = 0 /* Metadata: 0x0069D1C9 */);
		}
	
		internal static class SharedStatic // TypeDefIndex: 7437
		{
			// Methods
			public static unsafe void* GetOrCreateSharedStaticInternal(long getHashCode64, long getSubHashCode64, uint sizeOf, uint alignment); // 0x00000001821943F0-0x0000000182194410
		}
	}
}
