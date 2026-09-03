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
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[RequiredByNativeCode]
	public struct MeshGenerationResult : IEquatable<MeshGenerationResult> // TypeDefIndex: 15370
	{
		// Fields
		[CompilerGenerated]
		private readonly MeshId _MeshId_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly Mesh _Mesh_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly MeshCollider _MeshCollider_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly MeshGenerationStatus _Status_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly MeshVertexAttributes _Attributes_k__BackingField; // 0x24
		[CompilerGenerated]
		private readonly ulong _Timestamp_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly Vector3 _Position_k__BackingField; // 0x30
		[CompilerGenerated]
		private readonly Quaternion _Rotation_k__BackingField; // 0x3C
		[CompilerGenerated]
		private readonly Vector3 _Scale_k__BackingField; // 0x4C
	
		// Properties
		[NativeName("meshId")]
		public MeshId MeshId { [CompilerGenerated] [IsReadOnly] get; } // 0x000000018092E600-0x000000018092E610 
		[NativeName("mesh")]
		public Mesh Mesh { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180377550-0x0000000180377560 
		[NativeName("meshCollider")]
		public MeshCollider MeshCollider { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		[NativeName("status")]
		public MeshGenerationStatus Status { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		[NativeName("attributes")]
		public MeshVertexAttributes Attributes { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180D17D10-0x0000000180D17D20 
		[NativeName("position")]
		public Vector3 Position { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000181E25A60-0x0000000181E25A80 
		[NativeName("rotation")]
		public Quaternion Rotation { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000181FA2B30-0x0000000181FA2B40 
		[NativeName("scale")]
		public Vector3 Scale { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001825D5E90-0x00000001825D5EB0 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001825D59B0-0x00000001825D5A80
		public bool Equals(MeshGenerationResult other); // 0x00000001825D5A80-0x00000001825D5C60
		public override int GetHashCode(); // 0x00000001825D5C60-0x00000001825D5E90
	}
}
