/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Jobs
{
	[NativeHeader("Runtime/Transform/ScriptBindings/TransformAccess.bindings.h")]
	[NativeType(CodegenOptions = CodegenOptions.Custom)]
	public struct TransformAccessArray : IDisposable // TypeDefIndex: 7881
	{
		// Fields
		private IntPtr m_TransformArray; // 0x00
	
		// Properties
		public bool isCreated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public Transform this[int index] { get => default; } // 0x0000000182220270-0x00000001822202E0 
		public int capacity { get; set; } // 0x00000001822202E0-0x0000000182220320 0x0000000182220360-0x00000001822203A0
		public int length { get; } // 0x0000000182220320-0x0000000182220360 
	
		// Constructors
		public TransformAccessArray(int capacity, int desiredJobCount = -1 /* Metadata: 0x0069D7DB */); // 0x0000000182220200-0x0000000182220270
	
		// Methods
		public static void Allocate(int capacity, int desiredJobCount, out TransformAccessArray array); // 0x000000018221FDB0-0x000000018221FE10
		public void Dispose(); // 0x000000018221FE90-0x000000018221FEF0
		internal IntPtr GetTransformAccessArrayForSchedule(); // 0x00000001808BADD0-0x00000001808BADE0
		public void Add(Transform transform); // 0x000000018221FD60-0x000000018221FDB0
		public void RemoveAtSwapBack(int index); // 0x00000001822200A0-0x00000001822200E0
		public void SetTransforms(Transform[] transforms); // 0x00000001822201B0-0x0000000182220200
		[NativeMethod(Name = "TransformAccessArrayBindings::Create", IsFreeFunction = true)]
		private static IntPtr Create(int capacity, int desiredJobCount); // 0x000000018221FE10-0x000000018221FE50
		[NativeMethod(Name = "DestroyTransformAccessArray", IsFreeFunction = true)]
		private static void DestroyTransformAccessArray(IntPtr transformArray); // 0x000000018221FE50-0x000000018221FE90
		[NativeMethod(Name = "TransformAccessArrayBindings::SetTransforms", IsFreeFunction = true)]
		private static void SetTransforms(IntPtr transformArrayIntPtr, Transform[] transforms); // 0x0000000182220160-0x00000001822201B0
		[NativeMethod(Name = "TransformAccessArrayBindings::AddTransform", IsFreeFunction = true)]
		private static void Add(IntPtr transformArrayIntPtr, Transform transform); // 0x000000018221FD10-0x000000018221FD60
		[NativeMethod(Name = "TransformAccessArrayBindings::RemoveAtSwapBack", IsFreeFunction = true, ThrowsException = true)]
		private static void RemoveAtSwapBack(IntPtr transformArrayIntPtr, int index); // 0x00000001822200E0-0x0000000182220120
		[NativeMethod(Name = "TransformAccessArrayBindings::GetSortedTransformAccess", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		internal static IntPtr GetSortedTransformAccess(IntPtr transformArrayIntPtr); // 0x000000018221FFB0-0x000000018221FFF0
		[NativeMethod(Name = "TransformAccessArrayBindings::GetSortedToUserIndex", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		internal static IntPtr GetSortedToUserIndex(IntPtr transformArrayIntPtr); // 0x000000018221FF70-0x000000018221FFB0
		[NativeMethod(Name = "TransformAccessArrayBindings::GetLength", IsFreeFunction = true)]
		internal static int GetLength(IntPtr transformArrayIntPtr); // 0x000000018221FF30-0x000000018221FF70
		[NativeMethod(Name = "TransformAccessArrayBindings::GetCapacity", IsFreeFunction = true)]
		internal static int GetCapacity(IntPtr transformArrayIntPtr); // 0x000000018221FEF0-0x000000018221FF30
		[NativeMethod(Name = "TransformAccessArrayBindings::SetCapacity", IsFreeFunction = true)]
		internal static void SetCapacity(IntPtr transformArrayIntPtr, int capacity); // 0x0000000182220120-0x0000000182220160
		[NativeMethod(Name = "TransformAccessArrayBindings::GetTransform", IsFreeFunction = true, ThrowsException = true)]
		internal static Transform GetTransform(IntPtr transformArrayIntPtr, int index); // 0x0000000182220030-0x00000001822200A0
		private static void Add_Injected(IntPtr transformArrayIntPtr, IntPtr transform); // 0x000000018221FCC0-0x000000018221FD10
		private static IntPtr GetTransform_Injected(IntPtr transformArrayIntPtr, int index); // 0x000000018221FFF0-0x0000000182220030
	}
}
