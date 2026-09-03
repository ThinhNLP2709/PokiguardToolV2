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

namespace UnityEngine
{
	[NativeClass("LODGroup", PersistentTypeId = 205)]
	[NativeHeader("Runtime/Graphics/LOD/LODGroup.h")]
	[NativeHeader("Runtime/Graphics/LOD/LODUtility.h")]
	[NativeHeader("Runtime/Graphics/LOD/LODGroupManager.h")]
	[StaticAccessor("GetLODGroupManager()", StaticAccessorType.Dot)]
	public class LODGroup : Component // TypeDefIndex: 7624
	{
		// Properties
		public Vector3 localReferencePoint { get; } // 0x00000001821A3C70-0x00000001821A3CE0 
		public float size { get; } // 0x00000001821A3D20-0x00000001821A3D80 
	
		// Methods
		[FreeFunction("GetLODs_Binding", HasExplicitThis = true)]
		public LOD[] GetLODs(); // 0x00000001821A3BC0-0x00000001821A3C20
		private static void get_localReferencePoint_Injected(IntPtr _unity_self, ); // 0x00000001821A3C20-0x00000001821A3C70
		private static float get_size_Injected(IntPtr _unity_self); // 0x00000001821A3CE0-0x00000001821A3D20
		private static LOD[] GetLODs_Injected(IntPtr _unity_self); // 0x00000001821A3B80-0x00000001821A3BC0
	}
}
