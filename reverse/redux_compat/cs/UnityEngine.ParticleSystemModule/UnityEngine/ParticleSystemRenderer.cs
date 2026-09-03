/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 67: UnityEngine.ParticleSystemModule.dll - Assembly: UnityEngine.ParticleSystemModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15828-15838

namespace UnityEngine
{
	[NativeClass("ParticleSystemRenderer", PersistentTypeId = 199)]
	[NativeHeader("ParticleSystemScriptingClasses.h")]
	[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemRendererScriptBindings.h")]
	[NativeHeader("Modules/ParticleSystem/ParticleSystemRenderer.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class ParticleSystemRenderer : Renderer // TypeDefIndex: 15838
	{
		// Methods
		[FreeFunction(Name = "ParticleSystemRendererScriptBindings::GetMeshes", HasExplicitThis = true)]
		[RequiredByNativeCode]
		public int GetMeshes([NotNull] out Mesh[] meshes); // 0x00000001822C04F0-0x00000001822C0590
		private static int GetMeshes_Injected(IntPtr _unity_self, out Mesh[] meshes); // 0x00000001822C04A0-0x00000001822C04F0
	}
}
