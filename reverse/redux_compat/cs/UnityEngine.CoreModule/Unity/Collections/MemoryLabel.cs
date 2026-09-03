/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections
{
	[IsReadOnly]
	[UnityMarshalAs(NativeType.Custom, CustomMarshaller = typeof(BindingsMarshaller))]
	public struct MemoryLabel // TypeDefIndex: 7412
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal readonly IntPtr pointer; // 0x00
		internal readonly Allocator allocator; // 0x08
	
		// Properties
		public bool IsCreated { get; } // 0x0000000181616660-0x0000000181616670 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7413
		{
		}
	
		// Constructors
		public MemoryLabel(string areaName, string objectName, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069D1AF */); // 0x00000001821905F0-0x0000000182190740
		internal unsafe MemoryLabel(byte* areaName, int areaNameLen, byte* objectName, int objectNameLen, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069D1B0 */); // 0x0000000182190470-0x00000001821905F0
	
		// Methods
		public static bool SupportsAllocator(Allocator allocator); // 0x0000000182190460-0x0000000182190470
		private static bool IsNullOrEmpty(string str); // 0x000000018171BD50-0x000000018171BD60
		private static unsafe bool IsNullOrEmpty__Unmanaged(byte* name, int nameLen); // 0x0000000182190450-0x0000000182190460
	}
}
