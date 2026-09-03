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

namespace UnityEngine.Jobs
{
	[NativeHeader("Runtime/Transform/ScriptBindings/TransformAccess.bindings.h")]
	public struct TransformAccess // TypeDefIndex: 7880
	{
		// Fields
		private IntPtr hierarchy; // 0x00
		private int index; // 0x08
	
		// Properties
		public Vector3 position { get; } // 0x00000001822205E0-0x0000000182220630 
		public Quaternion rotation { get; } // 0x0000000182220630-0x0000000182220680 
		public Vector3 localScale { get; } // 0x0000000182220530-0x0000000182220580 
		public Matrix4x4 localToWorldMatrix { get; } // 0x0000000182220580-0x00000001822205E0 
		public Matrix4x4 worldToLocalMatrix { get; } // 0x0000000182220680-0x00000001822206E0 
		public bool isValid { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
	
		// Methods
		[NativeMethod(Name = "TransformAccessBindings::GetPosition", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		private static void GetPosition(ref TransformAccess access, out Vector3 p); // 0x0000000182220440-0x0000000182220490
		[NativeMethod(Name = "TransformAccessBindings::GetRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		private static void GetRotation(ref TransformAccess access, out Quaternion r); // 0x0000000182220490-0x00000001822204E0
		[NativeMethod(Name = "TransformAccessBindings::GetLocalScale", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		private static void GetLocalScale(ref TransformAccess access, out Vector3 r); // 0x00000001822203A0-0x00000001822203F0
		[NativeMethod(Name = "TransformAccessBindings::GetLocalToWorldMatrix", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		private static void GetLocalToWorldMatrix(ref TransformAccess access, out Matrix4x4 m); // 0x00000001822203F0-0x0000000182220440
		[NativeMethod(Name = "TransformAccessBindings::GetWorldToLocalMatrix", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		private static void GetWorldToLocalMatrix(ref TransformAccess access, out Matrix4x4 m); // 0x00000001822204E0-0x0000000182220530
	}
}
