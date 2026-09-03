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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("MeshFilter", PersistentTypeId = 33)]
	[NativeHeader("Runtime/Graphics/Mesh/MeshFilter.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class MeshFilter : Component // TypeDefIndex: 7581
	{
		// Properties
		public Mesh sharedMesh { get; set; } // 0x00000001821B52D0-0x00000001821B5360 0x00000001821B53B0-0x00000001821B5430
		public Mesh mesh { [NativeName("GetInstantiatedMeshFromScript")] get; } // 0x00000001821B5200-0x00000001821B5290 
	
		// Constructors
		public MeshFilter(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[RequiredByNativeCode]
		private void DontStripMeshFilter(); // 0x00000001802E76C0-0x00000001802E76D0
		private static IntPtr get_sharedMesh_Injected(IntPtr _unity_self); // 0x00000001821B5290-0x00000001821B52D0
		private static void set_sharedMesh_Injected(IntPtr _unity_self, IntPtr value); // 0x00000001821B5360-0x00000001821B53B0
		private static IntPtr get_mesh_Injected(IntPtr _unity_self); // 0x00000001821B51C0-0x00000001821B5200
	}
}
