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

namespace UnityEngine.Rendering
{
	[NativeClass("BatchMeshID")]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct BatchMeshID : IEquatable<BatchMeshID> // TypeDefIndex: 8341
	{
		// Fields
		public static readonly BatchMeshID Null; // 0x00
		public uint value; // 0x00
	
		// Constructors
		static BatchMeshID(); // 0x0000000182255630-0x0000000182255670
	
		// Methods
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public override bool Equals(object obj); // 0x0000000182255590-0x0000000182255630
		public bool Equals(BatchMeshID other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public static bool operator ==(BatchMeshID a, BatchMeshID b); // 0x0000000182255670-0x00000001822556C0
	}
}
