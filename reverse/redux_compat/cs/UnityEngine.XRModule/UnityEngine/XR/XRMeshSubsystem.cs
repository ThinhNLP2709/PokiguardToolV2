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

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_XR")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshingSubsystem.h")]
	[UsedByNativeCode]
	public class XRMeshSubsystem : IntegratedSubsystem<XRMeshSubsystemDescriptor> // TypeDefIndex: 15372
	{
		// Nested types
		[IsReadOnly]
		[NativeConditional("ENABLE_XR")]
		private struct MeshTransformList : IDisposable // TypeDefIndex: 15373
		{
			// Fields
			private readonly IntPtr m_Self; // 0x00
	
			// Methods
			public void Dispose(); // 0x00000001825D5FC0-0x00000001825D6000
			[FreeFunction("UnityXRMeshTransformList_Dispose")]
			private static void Dispose(IntPtr self); // 0x00000001825D6000-0x00000001825D6040
		}
	
		// Constructors
		public XRMeshSubsystem(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokeMeshReadyDelegate(IntPtr resultPtr, Action<MeshGenerationResult> onMeshGenerationComplete); // 0x00000001825D7E10-0x00000001825D7EF0
		[NativeMethod]
		private static MeshGenerationResult GetMeshGenerationResult(IntPtr resultPtr); // 0x00000001825D7DA0-0x00000001825D7E10
		private static void GetMeshGenerationResult_Injected(IntPtr resultPtr, ); // 0x00000001825D7D50-0x00000001825D7DA0
	}
}
