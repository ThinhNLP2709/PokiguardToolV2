/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using AOT;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/Transform/NativeTransformUtils.h")]
	internal static class NativeTransformUtils // TypeDefIndex: 4257
	{
		// Nested types
		private struct Manager // TypeDefIndex: 4258
		{
			// Fields
			private readonly UnmanagedDataStore m_Nodes; // 0x00
			private readonly UnmanagedDataStore m_Panels; // 0x18
			private readonly UnmanagedDataHandle m_DefaultPanelHandle; // 0x30
			private readonly IntPtr m_ContainsPoint; // 0x38
			private readonly unsafe TransformData* m_InitialStyleTransform; // 0x40
			private static readonly ContainsPointDelegate k_ContainsPointDelegate; // 0x00
			private static readonly ProfilerMarker k_InvokeContainsPointMarker; // 0x08
	
			// Nested types
			private delegate bool ContainsPointDelegate(UnmanagedDataHandle handle, float x, float y); // TypeDefIndex: 4259; 0x0000000180A72BD0-0x0000000180A72BF0
	
			// Constructors
			public unsafe Manager(); // 0x00000001824B3A70-0x00000001824B3C10
			static Manager(); // 0x00000001824B3920-0x00000001824B3A70
	
			// Methods
			[MonoPInvokeCallback(typeof(ContainsPointDelegate))]
			private static bool ContainsPoint(UnmanagedDataHandle handle, float x, float y); // 0x00000001824B3760-0x00000001824B3920
		}
	
		// Constructors
		static NativeTransformUtils(); // 0x00000001824B4B60-0x00000001824B4D90
	
		// Methods
		public static void InitSharedManager(IntPtr managerPtr); // 0x00000001824B48A0-0x00000001824B48E0
		public static void UpdateWorldTransform(UnmanagedDataHandle handle); // 0x00000001824B4AF0-0x00000001824B4B60
		public static void UpdateBoundingBox(UnmanagedDataHandle handle); // 0x00000001824B4A40-0x00000001824B4AB0
		public static unsafe UnmanagedDataHandle PerformPick(UnmanagedDataHandle root, Vector3 localPoint, bool includeIgnoredElement, UnmanagedHandleBuffer* results); // 0x00000001824B4950-0x00000001824B4A00
		private static void UpdateWorldTransform_Injected(in UnmanagedDataHandle handle); // 0x00000001824B4AB0-0x00000001824B4AF0
		private static void UpdateBoundingBox_Injected(in UnmanagedDataHandle handle); // 0x00000001824B4A00-0x00000001824B4A40
		private static unsafe void PerformPick_Injected(in UnmanagedDataHandle root, in Vector3 localPoint, bool includeIgnoredElement, UnmanagedHandleBuffer* results, ); // 0x00000001824B48E0-0x00000001824B4950
	}
}
