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
	[NativeHeader("Runtime/Export/Camera/CullingGroup.bindings.h")]
	public class CullingGroup : IDisposable // TypeDefIndex: 7509
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
		private StateChanged m_OnStateChanged; // 0x18
	
		// Properties
		public Camera targetCamera { set; } // 0x0000000182189F90-0x000000018218A010
	
		// Nested types
		public delegate void StateChanged(CullingGroupEvent sphere); // TypeDefIndex: 7510; 0x00000001804A78A0-0x00000001804A78B0
	
		internal static class BindingsMarshaller // TypeDefIndex: 7511
		{
			// Methods
			public static IntPtr ConvertToNative(CullingGroup cullingGroup); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public CullingGroup(); // 0x0000000182189F00-0x0000000182189F40
	
		// Methods
		~CullingGroup(); // 0x0000000182189740-0x00000001821897E0
		[FreeFunction("CullingGroup_Bindings::Dispose", HasExplicitThis = true)]
		private void DisposeInternal(); // 0x0000000182189680-0x00000001821896E0
		public void Dispose(); // 0x00000001821896E0-0x0000000182189740
		public void SetBoundingSpheres([UnityMarshalAs(NativeType.ScriptingObjectPtr)] BoundingSphere[] array); // 0x0000000182189D80-0x0000000182189DE0
		public void SetBoundingSphereCount(int count); // 0x0000000182189CD0-0x0000000182189D30
		public int QueryIndices(bool visible, int[] result, int firstIndex); // 0x0000000182189A20-0x0000000182189B10
		[FreeFunction("CullingGroup_Bindings::QueryIndices", HasExplicitThis = true, ThrowsException = true)]
		private int QueryIndices(bool visible, int distanceIndex, CullingQueryOptions options, int[] result, int firstIndex); // 0x0000000182189930-0x0000000182189A20
		[FreeFunction("CullingGroup_Bindings::SetBoundingDistances", HasExplicitThis = true)]
		public void SetBoundingDistances(float[] distances); // 0x0000000182189BD0-0x0000000182189C90
		[FreeFunction("CullingGroup_Bindings::SetDistanceReferencePoint", HasExplicitThis = true)]
		private void SetDistanceReferencePoint_InternalVector3(Vector3 point); // 0x0000000182189E30-0x0000000182189E90
		public void SetDistanceReferencePoint(Vector3 point); // 0x0000000182189E90-0x0000000182189F00
		[RequiredByNativeCode]
		private static void SendEvents(CullingGroup cullingGroup, IntPtr eventsPtr, int count); // 0x0000000182189B10-0x0000000182189B80
		[FreeFunction("CullingGroup_Bindings::Init")]
		private static IntPtr Init(object scripting); // 0x0000000182189880-0x00000001821898C0
		[FreeFunction("CullingGroup_Bindings::FinalizerFailure", HasExplicitThis = true, IsThreadSafe = true)]
		private void FinalizerFailure(); // 0x0000000182189820-0x0000000182189880
		private static void DisposeInternal_Injected(IntPtr _unity_self); // 0x0000000182189640-0x0000000182189680
		private static void set_targetCamera_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182189F40-0x0000000182189F90
		private static void SetBoundingSpheres_Injected(IntPtr _unity_self, BoundingSphere[] array); // 0x0000000182189D30-0x0000000182189D80
		private static void SetBoundingSphereCount_Injected(IntPtr _unity_self, int count); // 0x0000000182189C90-0x0000000182189CD0
		private static int QueryIndices_Injected(IntPtr _unity_self, bool visible, int distanceIndex, CullingQueryOptions options, ref ManagedSpanWrapper result, int firstIndex); // 0x00000001821898C0-0x0000000182189930
		private static void SetBoundingDistances_Injected(IntPtr _unity_self, ref ManagedSpanWrapper distances); // 0x0000000182189B80-0x0000000182189BD0
		private static void SetDistanceReferencePoint_InternalVector3_Injected(IntPtr _unity_self, in Vector3 point); // 0x0000000182189DE0-0x0000000182189E30
		private static void FinalizerFailure_Injected(IntPtr _unity_self); // 0x00000001821897E0-0x0000000182189820
	}
}
