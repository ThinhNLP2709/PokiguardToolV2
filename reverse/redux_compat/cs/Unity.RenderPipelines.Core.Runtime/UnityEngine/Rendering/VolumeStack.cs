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
	public sealed class VolumeStack : IDisposable // TypeDefIndex: 5855
	{
		// Fields
		internal readonly Dictionary<Type, VolumeComponent> components; // 0x10
		private readonly Dictionary<Type, Volume> m_OverridingVolumes; // 0x18
		internal VolumeParameter[] parameters; // 0x20
		internal bool requiresReset; // 0x28
		internal bool requiresResetForAllProperties; // 0x29
		[CompilerGenerated]
		private bool _isValid_k__BackingField; // 0x2A
	
		// Properties
		public bool isValid { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D510-0x000000018052D520 0x000000018052D7D0-0x000000018052D910
	
		// Constructors
		internal VolumeStack(); // 0x0000000181ED11D0-0x0000000181ED12A0
	
		// Methods
		internal void Clear(); // 0x0000000181ED0D50-0x0000000181ED0EB0
		internal void Reload(Type[] componentTypes); // 0x0000000181ED0F40-0x0000000181ED1160
		public T GetComponent<T>()
			where T : VolumeComponent;
		public VolumeComponent GetComponent(Type type); // 0x0000000181ED0ED0-0x0000000181ED0F40
		internal GameObject GetSceneObjectReference<T>()
			where T : VolumeComponent;
		internal void SetOverridingVolume(Type type, Volume volume); // 0x0000000181ED1160-0x0000000181ED11D0
		internal void ClearOverridingVolumes(); // 0x0000000181ED0D30-0x0000000181ED0D50
		public void Dispose(); // 0x0000000181ED0EB0-0x0000000181ED0ED0
	}
}
