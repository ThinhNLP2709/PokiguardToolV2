/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class VolumeProfile : ScriptableObject // TypeDefIndex: 5851
	{
		// Fields
		public List<VolumeComponent> components; // 0x18
		internal DirtyState dirtyState; // 0x20
	
		// Properties
		[Obsolete("This field was only public for editor access. #from(6000.0)")]
		public bool isDirty { get; set; } // 0x0000000181ED0D00-0x0000000181ED0D10 0x0000000181ED0D10-0x0000000181ED0D30
	
		// Nested types
		[Flags]
		internal enum DirtyState // TypeDefIndex: 5852
		{
			None = 0,
			DirtyByComponentChange = 1,
			DirtyByProfileReset = 2,
			Other = 4
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5853
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<VolumeComponent> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181ECE570-0x0000000181ECE5E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _OnEnable_b__6_0(VolumeComponent x); // 0x0000000181ECE250-0x0000000181ECE2A0
		}
	
		// Constructors
		public VolumeProfile(); // 0x0000000181ED0C80-0x0000000181ED0D00
	
		// Methods
		private void OnEnable(); // 0x0000000181ED09D0-0x0000000181ED0AD0
		internal void OnDisable(); // 0x0000000181ED08F0-0x0000000181ED09D0
		public void Reset(); // 0x0000000181ED0BB0-0x0000000181ED0BC0
		public T Add<T>(bool overrides = false /* Metadata: 0x00661B6E */)
			where T : VolumeComponent;
		public VolumeComponent Add(Type type, bool overrides = false /* Metadata: 0x00661B6F */); // 0x0000000181ED0380-0x0000000181ED0510
		public void Remove<T>()
			where T : VolumeComponent;
		public void Remove(Type type); // 0x0000000181ED0AD0-0x0000000181ED0BB0
		public bool Has<T>()
			where T : VolumeComponent;
		public bool Has(Type type); // 0x0000000181ED07C0-0x0000000181ED08F0
		public bool HasSubclassOf(Type type); // 0x0000000181ED06A0-0x0000000181ED07C0
		public bool TryGet<T>(out ref T component)
			where T : VolumeComponent;
		public bool TryGet<T>(Type type, out ref T component)
			where T : VolumeComponent;
		public bool TryGetSubclassOf<T>(Type type, out ref T component)
			where T : VolumeComponent;
		public bool TryGetAllSubclassOf<T>(Type type, List<T> result)
			where T : VolumeComponent;
		internal int GetComponentListHashCode(); // 0x0000000181ED0510-0x0000000181ED05B0
		public int GetStateHash(); // 0x0000000181ED05B0-0x0000000181ED06A0
		internal void Sanitize(); // 0x0000000181ED0BC0-0x0000000181ED0C80
	}
}
