/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 57: UnityEngine.VFXModule.dll - Assembly: UnityEngine.VFXModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15667-15684

namespace UnityEngine.VFX
{
	[Serializable]
	[RequiredByNativeCode]
	public abstract class VFXSpawnerCallbacks : ScriptableObject // TypeDefIndex: 15678
	{
		// Constructors
		protected VFXSpawnerCallbacks(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public abstract void OnPlay(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);
		public abstract void OnUpdate(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);
		public abstract void OnStop(VFXSpawnerState state, VFXExpressionValues vfxValues, VisualEffect vfxComponent);
	}
}
