/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Transform", PersistentTypeId = 4)]
	[NativeHeader("Configuration/UnityConfigure.h")]
	[NativeHeader("Runtime/Transform/ScriptBindings/TransformScriptBindings.h")]
	[NativeHeader("Runtime/Transform/Transform.h")]
	[RequiredByNativeCode]
	public class Transform : Component, IEnumerable // TypeDefIndex: 7855
	{
		// Properties
		public Vector3 position { get; set; } // 0x0000000182225CE0-0x0000000182225D50 0x00000001822267F0-0x0000000182226850
		public Vector3 localPosition { get; set; } // 0x0000000182225910-0x0000000182225980 0x00000001822264E0-0x0000000182226540
		public Vector3 eulerAngles { get; set; } // 0x0000000182225490-0x0000000182225590 0x00000001822261A0-0x0000000182226260
		public Vector3 localEulerAngles { get; set; } // 0x00000001822257C0-0x00000001822258C0 0x00000001822263D0-0x0000000182226490
		public Vector3 right { get; set; } // 0x0000000182225D50-0x0000000182225E20 0x0000000182226850-0x0000000182226900
		public Vector3 up { get; set; } // 0x0000000182225EE0-0x0000000182225FB0 0x00000001822269B0-0x0000000182226A60
		public Vector3 forward { get; set; } // 0x0000000182225590-0x0000000182225660 0x0000000182226260-0x0000000182226320
		public Quaternion rotation { get; set; } // 0x0000000182225E70-0x0000000182225EE0 0x0000000182226950-0x00000001822269B0
		public Quaternion localRotation { get; set; } // 0x00000001822259D0-0x0000000182225A40 0x0000000182226590-0x00000001822265F0
		[NativeConditional("UNITY_EDITOR")]
		internal RotationOrder rotationOrder { get; set; } // 0x0000000182221150-0x00000001822211B0 0x0000000182223E80-0x0000000182223EE0
		public Vector3 localScale { get; set; } // 0x0000000182225A90-0x0000000182225B00 0x0000000182226640-0x00000001822266A0
		public Transform parent { get; set; } // 0x0000000182220EE0-0x0000000182220F70 0x00000001822266A0-0x00000001822267A0
		internal Transform parentInternal { get; set; } // 0x0000000182220EE0-0x0000000182220F70 0x0000000182223C60-0x0000000182223CE0
		public Matrix4x4 worldToLocalMatrix { get; } // 0x0000000182226000-0x0000000182226080 
		public Matrix4x4 localToWorldMatrix { get; } // 0x0000000182225B50-0x0000000182225BD0 
		public Transform root { get; } // 0x0000000182221080-0x0000000182221110 
		public int childCount { [NativeMethod("GetChildrenCount")] get; } // 0x0000000182225430-0x0000000182225490 
		public Vector3 lossyScale { [NativeMethod("GetWorldScaleLossy")] get; } // 0x0000000182225C20-0x0000000182225C90 
		[NativeProperty("HasChangedDeprecated")]
		public bool hasChanged { get; set; } // 0x00000001822256A0-0x0000000182225700 0x0000000182226370-0x00000001822263D0
		public int hierarchyCapacity { get; set; } // 0x0000000182225700-0x0000000182225760 0x0000000182226140-0x00000001822261A0
		public int hierarchyCount { get; } // 0x0000000182225760-0x00000001822257C0 
		[NativeConditional("UNITY_EDITOR")]
		internal bool constrainProportionsScale { get; set; } // 0x00000001822223F0-0x0000000182222450 0x0000000182223950-0x00000001822239B0
	
		// Nested types
		private class Enumerator : IEnumerator // TypeDefIndex: 7856
		{
			// Fields
			private Transform outer; // 0x10
			private int currentIndex; // 0x18
	
			// Properties
			public object Current { get; } // 0x0000000182205D00-0x0000000182205DA0 
	
			// Constructors
			internal Enumerator(Transform outer); // 0x0000000181A802C0-0x0000000181A80300
	
			// Methods
			public bool MoveNext(); // 0x0000000182205C90-0x0000000182205D00
			public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
		}
	
		// Constructors
		protected Transform(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		internal Vector3 GetLocalEulerAngles(RotationOrder order); // 0x0000000182220D50-0x0000000182220DD0
		internal void SetLocalEulerAngles(Vector3 euler, RotationOrder order); // 0x0000000182223A10-0x0000000182223A80
		[NativeConditional("UNITY_EDITOR")]
		internal void SetLocalEulerHint(Vector3 euler); // 0x0000000182223AD0-0x0000000182223B30
		[NativeConditional("UNITY_EDITOR")]
		[NativeMethod("GetRotationOrder")]
		internal int GetRotationOrderInternal(); // 0x0000000182221150-0x00000001822211B0
		[NativeConditional("UNITY_EDITOR")]
		[NativeMethod("SetRotationOrder")]
		internal void SetRotationOrderInternal(RotationOrder rotationOrder); // 0x0000000182223E80-0x0000000182223EE0
		private Transform GetParent(); // 0x0000000182220EE0-0x0000000182220F70
		public void SetParent(Transform p); // 0x0000000182223C60-0x0000000182223CE0
		[FreeFunction("SetParent", HasExplicitThis = true)]
		public void SetParent(Transform parent, bool worldPositionStays); // 0x0000000182223CE0-0x0000000182223D70
		public void SetPositionAndRotation(Vector3 position, Quaternion rotation); // 0x0000000182223DD0-0x0000000182223E40
		public void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation); // 0x0000000182223B90-0x0000000182223C00
		public void GetPositionAndRotation(out Vector3 position, out Quaternion rotation); // 0x0000000182220FD0-0x0000000182221040
		public void GetLocalPositionAndRotation(out Vector3 localPosition, out Quaternion localRotation); // 0x0000000182220E30-0x0000000182220EA0
		public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo); // 0x0000000182225180-0x0000000182225390
		public void Translate(Vector3 translation); // 0x0000000182224EB0-0x0000000182224EE0
		public void Translate(float x, float y, float z, [DefaultValue("Space.Self")] Space relativeTo); // 0x0000000182225390-0x00000001822253C0
		public void Translate(float x, float y, float z); // 0x00000001822253C0-0x00000001822253F0
		public void Translate(Vector3 translation, Transform relativeTo); // 0x0000000182224EE0-0x0000000182225150
		public void Translate(float x, float y, float z, Transform relativeTo); // 0x0000000182225150-0x0000000182225180
		public void Rotate(Vector3 eulers, [DefaultValue("Space.Self")] Space relativeTo); // 0x00000001822230D0-0x00000001822236F0
		public void Rotate(Vector3 eulers); // 0x0000000182222DD0-0x0000000182222E00
		public void Rotate(float xAngle, float yAngle, float zAngle, [DefaultValue("Space.Self")] Space relativeTo); // 0x00000001822236F0-0x0000000182223720
		public void Rotate(float xAngle, float yAngle, float zAngle); // 0x00000001822230A0-0x00000001822230D0
		[NativeMethod("RotateAround")]
		internal void RotateAroundInternal(Vector3 axis, float angle); // 0x00000001822229D0-0x0000000182222A40
		public void Rotate(Vector3 axis, float angle, [DefaultValue("Space.Self")] Space relativeTo); // 0x0000000182222F10-0x00000001822230A0
		public void Rotate(Vector3 axis, float angle); // 0x0000000182222E00-0x0000000182222F10
		public void RotateAround(Vector3 point, Vector3 axis, float angle); // 0x0000000182222B70-0x0000000182222D60
		public void LookAt(Transform target, [DefaultValue("Vector3.up")] Vector3 worldUp); // 0x00000001822226B0-0x00000001822227F0
		public void LookAt(Transform target); // 0x00000001822224F0-0x0000000182222630
		public void LookAt(Vector3 worldPosition, [DefaultValue("Vector3.up")] Vector3 worldUp); // 0x0000000182222630-0x00000001822226B0
		public void LookAt(Vector3 worldPosition); // 0x00000001822227F0-0x0000000182222880
		[FreeFunction("Internal_LookAt", HasExplicitThis = true)]
		private void Internal_LookAt(Vector3 worldPosition, Vector3 worldUp); // 0x00000001822212B0-0x0000000182221320
		public Vector3 TransformDirection(Vector3 direction); // 0x0000000182223FE0-0x0000000182224060
		public Vector3 TransformDirection(float x, float y, float z); // 0x0000000182224060-0x0000000182224100
		[NativeMethod(Name = "TransformDirections")]
		internal void TransformDirectionsInternal(ReadOnlySpan<Vector3> directions, Span<Vector3> transformedDirections); // 0x0000000182224160-0x0000000182224240
		public void TransformDirections(ReadOnlySpan<Vector3> directions, Span<Vector3> transformedDirections); // 0x0000000182224350-0x0000000182224490
		public void TransformDirections(Span<Vector3> directions); // 0x0000000182224240-0x0000000182224350
		public Vector3 InverseTransformDirection(Vector3 direction); // 0x0000000182221380-0x0000000182221400
		public Vector3 InverseTransformDirection(float x, float y, float z); // 0x0000000182221400-0x00000001822214A0
		[NativeMethod(Name = "InverseTransformDirections")]
		internal void InverseTransformDirectionsInternal(ReadOnlySpan<Vector3> directions, Span<Vector3> transformedDirections); // 0x0000000182221500-0x00000001822215E0
		public void InverseTransformDirections(ReadOnlySpan<Vector3> directions, Span<Vector3> transformedDirections); // 0x00000001822216F0-0x0000000182221830
		public void InverseTransformDirections(Span<Vector3> directions); // 0x00000001822215E0-0x00000001822216F0
		public Vector3 TransformVector(Vector3 vector); // 0x0000000182224AA0-0x0000000182224B20
		public Vector3 TransformVector(float x, float y, float z); // 0x0000000182224A00-0x0000000182224AA0
		[NativeMethod(Name = "TransformVectors")]
		internal void TransformVectorsInternal(ReadOnlySpan<Vector3> vectors, Span<Vector3> transformedVectors); // 0x0000000182224B80-0x0000000182224C60
		public void TransformVectors(ReadOnlySpan<Vector3> vectors, Span<Vector3> transformedVectors); // 0x0000000182224C60-0x0000000182224DA0
		public void TransformVectors(Span<Vector3> vectors); // 0x0000000182224DA0-0x0000000182224EB0
		public Vector3 InverseTransformVector(Vector3 vector); // 0x0000000182221E90-0x0000000182221F10
		public Vector3 InverseTransformVector(float x, float y, float z); // 0x0000000182221DF0-0x0000000182221E90
		[NativeMethod(Name = "InverseTransformVectors")]
		internal void InverseTransformVectorsInternal(ReadOnlySpan<Vector3> vectors, Span<Vector3> transformedVectors); // 0x0000000182221F70-0x0000000182222050
		public void InverseTransformVectors(ReadOnlySpan<Vector3> vectors, Span<Vector3> transformedVectors); // 0x0000000182222160-0x00000001822222A0
		public void InverseTransformVectors(Span<Vector3> vectors); // 0x0000000182222050-0x0000000182222160
		public Vector3 TransformPoint(Vector3 position); // 0x00000001822244F0-0x0000000182224570
		public Vector3 TransformPoint(float x, float y, float z); // 0x0000000182224570-0x0000000182224610
		[NativeMethod(Name = "TransformPoints")]
		internal void TransformPointsInternal(ReadOnlySpan<Vector3> positions, Span<Vector3> transformedPositions); // 0x0000000182224670-0x0000000182224750
		public void TransformPoints(ReadOnlySpan<Vector3> positions, Span<Vector3> transformedPositions); // 0x0000000182224860-0x00000001822249A0
		public void TransformPoints(Span<Vector3> positions); // 0x0000000182224750-0x0000000182224860
		public Vector3 InverseTransformPoint(Vector3 position); // 0x0000000182221930-0x00000001822219B0
		public Vector3 InverseTransformPoint(float x, float y, float z); // 0x0000000182221890-0x0000000182221930
		[NativeMethod(Name = "InverseTransformPoints")]
		internal void InverseTransformPointsInternal(ReadOnlySpan<Vector3> positions, Span<Vector3> transformedPositions); // 0x0000000182221A10-0x0000000182221AF0
		public void InverseTransformPoints(ReadOnlySpan<Vector3> positions, Span<Vector3> transformedPositions); // 0x0000000182221AF0-0x0000000182221C30
		public void InverseTransformPoints(Span<Vector3> positions); // 0x0000000182221C30-0x0000000182221D90
		private Transform GetRoot(); // 0x0000000182221080-0x0000000182221110
		[FreeFunction("DetachChildren", HasExplicitThis = true)]
		public void DetachChildren(); // 0x00000001822207E0-0x0000000182220840
		public void SetAsFirstSibling(); // 0x0000000182223800-0x0000000182223860
		public void SetAsLastSibling(); // 0x00000001822238A0-0x0000000182223900
		public void SetSiblingIndex(int index); // 0x0000000182223F20-0x0000000182223F80
		[NativeMethod("MoveAfterSiblingInternal")]
		internal void MoveAfterSibling(Transform transform, bool notifyEditorAndMarkDirty); // 0x00000001822228E0-0x0000000182222970
		public int GetSiblingIndex(); // 0x00000001822211F0-0x0000000182221250
		[FreeFunction(HasExplicitThis = true)]
		private Transform FindRelativeTransformWithPath(string path, [DefaultValue("false")] bool isActiveOnly); // 0x0000000182220910-0x0000000182220B10
		public Transform Find(string n); // 0x0000000182220840-0x00000001822208B0
		[NativeConditional("UNITY_EDITOR")]
		internal void SendTransformChangedScale(); // 0x0000000182223760-0x00000001822237C0
		[FreeFunction("Internal_IsChildOrSameAsOtherTransform", HasExplicitThis = true)]
		public bool IsChildOf([NotNull] Transform parent); // 0x00000001822222F0-0x00000001822223B0
		[Obsolete("FindChild has been deprecated. Use Find instead (UnityUpgradable) -> Find([mscorlib] System.String)", false)]
		public Transform FindChild(string n); // 0x0000000182220840-0x00000001822208B0
		public IEnumerator GetEnumerator(); // 0x0000000182220C90-0x0000000182220D00
		[Obsolete("warning use Transform.Rotate instead.")]
		public void RotateAround(Vector3 axis, float angle); // 0x0000000182222D60-0x0000000182222DD0
		[Obsolete("warning use Transform.Rotate instead.")]
		public void RotateAroundLocal(Vector3 axis, float angle); // 0x0000000182222AA0-0x0000000182222B10
		[FreeFunction("GetChild", HasExplicitThis = true, ThrowsException = true)]
		public Transform GetChild(int index); // 0x0000000182220BF0-0x0000000182220C90
		[NativeMethod("GetChildrenCount")]
		[Obsolete("warning use Transform.childCount instead (UnityUpgradable) -> Transform.childCount", false)]
		public int GetChildCount(); // 0x0000000182220B50-0x0000000182220BB0
		[FreeFunction("GetHierarchyCapacity", HasExplicitThis = true)]
		private int internal_getHierarchyCapacity(); // 0x0000000182225700-0x0000000182225760
		[FreeFunction("SetHierarchyCapacity", HasExplicitThis = true)]
		private void internal_setHierarchyCapacity(int value); // 0x0000000182226140-0x00000001822261A0
		[FreeFunction("GetHierarchyCount", HasExplicitThis = true)]
		private int internal_getHierarchyCount(); // 0x0000000182225760-0x00000001822257C0
		[FreeFunction("IsNonUniformScaleTransform", HasExplicitThis = true)]
		[NativeConditional("UNITY_EDITOR")]
		internal bool IsNonUniformScaleTransform(); // 0x0000000182222490-0x00000001822224F0
		[NativeConditional("UNITY_EDITOR")]
		private void SetConstrainProportionsScale(bool isLinked); // 0x0000000182223950-0x00000001822239B0
		[NativeConditional("UNITY_EDITOR")]
		private bool IsConstrainProportionsScale(); // 0x00000001822223F0-0x0000000182222450
		private static void get_position_Injected(IntPtr _unity_self, ); // 0x0000000182225C90-0x0000000182225CE0
		private static void set_position_Injected(IntPtr _unity_self, in Vector3 value); // 0x00000001822267A0-0x00000001822267F0
		private static void get_localPosition_Injected(IntPtr _unity_self, ); // 0x00000001822258C0-0x0000000182225910
		private static void set_localPosition_Injected(IntPtr _unity_self, in Vector3 value); // 0x0000000182226490-0x00000001822264E0
		private static void GetLocalEulerAngles_Injected(IntPtr _unity_self, RotationOrder order, ); // 0x0000000182220D00-0x0000000182220D50
		private static void SetLocalEulerAngles_Injected(IntPtr _unity_self, in Vector3 euler, RotationOrder order); // 0x00000001822239B0-0x0000000182223A10
		private static void SetLocalEulerHint_Injected(IntPtr _unity_self, in Vector3 euler); // 0x0000000182223A80-0x0000000182223AD0
		private static void get_rotation_Injected(IntPtr _unity_self, ); // 0x0000000182225E20-0x0000000182225E70
		private static void set_rotation_Injected(IntPtr _unity_self, in Quaternion value); // 0x0000000182226900-0x0000000182226950
		private static void get_localRotation_Injected(IntPtr _unity_self, ); // 0x0000000182225980-0x00000001822259D0
		private static void set_localRotation_Injected(IntPtr _unity_self, in Quaternion value); // 0x0000000182226540-0x0000000182226590
		private static int GetRotationOrderInternal_Injected(IntPtr _unity_self); // 0x0000000182221110-0x0000000182221150
		private static void SetRotationOrderInternal_Injected(IntPtr _unity_self, RotationOrder rotationOrder); // 0x0000000182223E40-0x0000000182223E80
		private static void get_localScale_Injected(IntPtr _unity_self, ); // 0x0000000182225A40-0x0000000182225A90
		private static void set_localScale_Injected(IntPtr _unity_self, in Vector3 value); // 0x00000001822265F0-0x0000000182226640
		private static IntPtr GetParent_Injected(IntPtr _unity_self); // 0x0000000182220EA0-0x0000000182220EE0
		private static void SetParent_Injected(IntPtr _unity_self, IntPtr parent, bool worldPositionStays); // 0x0000000182223C00-0x0000000182223C60
		private static void get_worldToLocalMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182225FB0-0x0000000182226000
		private static void get_localToWorldMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182225B00-0x0000000182225B50
		private static void SetPositionAndRotation_Injected(IntPtr _unity_self, in Vector3 position, in Quaternion rotation); // 0x0000000182223D70-0x0000000182223DD0
		private static void SetLocalPositionAndRotation_Injected(IntPtr _unity_self, in Vector3 localPosition, in Quaternion localRotation); // 0x0000000182223B30-0x0000000182223B90
		private static void GetPositionAndRotation_Injected(IntPtr _unity_self, out Vector3 position, out Quaternion rotation); // 0x0000000182220F70-0x0000000182220FD0
		private static void GetLocalPositionAndRotation_Injected(IntPtr _unity_self, out Vector3 localPosition, out Quaternion localRotation); // 0x0000000182220DD0-0x0000000182220E30
		private static void RotateAroundInternal_Injected(IntPtr _unity_self, in Vector3 axis, float angle); // 0x0000000182222970-0x00000001822229D0
		private static void Internal_LookAt_Injected(IntPtr _unity_self, in Vector3 worldPosition, in Vector3 worldUp); // 0x0000000182221250-0x00000001822212B0
		private static void TransformDirection_Injected(IntPtr _unity_self, in Vector3 direction, ); // 0x0000000182223F80-0x0000000182223FE0
		private static void TransformDirectionsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper directions, ref ManagedSpanWrapper transformedDirections); // 0x0000000182224100-0x0000000182224160
		private static void InverseTransformDirection_Injected(IntPtr _unity_self, in Vector3 direction, ); // 0x0000000182221320-0x0000000182221380
		private static void InverseTransformDirectionsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper directions, ref ManagedSpanWrapper transformedDirections); // 0x00000001822214A0-0x0000000182221500
		private static void TransformVector_Injected(IntPtr _unity_self, in Vector3 vector, ); // 0x00000001822249A0-0x0000000182224A00
		private static void TransformVectorsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper vectors, ref ManagedSpanWrapper transformedVectors); // 0x0000000182224B20-0x0000000182224B80
		private static void InverseTransformVector_Injected(IntPtr _unity_self, in Vector3 vector, ); // 0x0000000182221D90-0x0000000182221DF0
		private static void InverseTransformVectorsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper vectors, ref ManagedSpanWrapper transformedVectors); // 0x0000000182221F10-0x0000000182221F70
		private static void TransformPoint_Injected(IntPtr _unity_self, in Vector3 position, ); // 0x0000000182224490-0x00000001822244F0
		private static void TransformPointsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper positions, ref ManagedSpanWrapper transformedPositions); // 0x0000000182224610-0x0000000182224670
		private static void InverseTransformPoint_Injected(IntPtr _unity_self, in Vector3 position, ); // 0x0000000182221830-0x0000000182221890
		private static void InverseTransformPointsInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper positions, ref ManagedSpanWrapper transformedPositions); // 0x00000001822219B0-0x0000000182221A10
		private static IntPtr GetRoot_Injected(IntPtr _unity_self); // 0x0000000182221040-0x0000000182221080
		private static int get_childCount_Injected(IntPtr _unity_self); // 0x00000001822253F0-0x0000000182225430
		private static void DetachChildren_Injected(IntPtr _unity_self); // 0x00000001822207A0-0x00000001822207E0
		private static void SetAsFirstSibling_Injected(IntPtr _unity_self); // 0x00000001822237C0-0x0000000182223800
		private static void SetAsLastSibling_Injected(IntPtr _unity_self); // 0x0000000182223860-0x00000001822238A0
		private static void SetSiblingIndex_Injected(IntPtr _unity_self, int index); // 0x0000000182223EE0-0x0000000182223F20
		private static void MoveAfterSibling_Injected(IntPtr _unity_self, IntPtr transform, bool notifyEditorAndMarkDirty); // 0x0000000182222880-0x00000001822228E0
		private static int GetSiblingIndex_Injected(IntPtr _unity_self); // 0x00000001822211B0-0x00000001822211F0
		private static IntPtr FindRelativeTransformWithPath_Injected(IntPtr _unity_self, ref ManagedSpanWrapper path, [DefaultValue("false")] bool isActiveOnly); // 0x00000001822208B0-0x0000000182220910
		private static void SendTransformChangedScale_Injected(IntPtr _unity_self); // 0x0000000182223720-0x0000000182223760
		private static void get_lossyScale_Injected(IntPtr _unity_self, ); // 0x0000000182225BD0-0x0000000182225C20
		private static bool IsChildOf_Injected(IntPtr _unity_self, IntPtr parent); // 0x00000001822222A0-0x00000001822222F0
		private static bool get_hasChanged_Injected(IntPtr _unity_self); // 0x0000000182225660-0x00000001822256A0
		private static void set_hasChanged_Injected(IntPtr _unity_self, bool value); // 0x0000000182226320-0x0000000182226370
		private static void RotateAround_Injected(IntPtr _unity_self, in Vector3 axis, float angle); // 0x0000000182222B10-0x0000000182222B70
		private static void RotateAroundLocal_Injected(IntPtr _unity_self, in Vector3 axis, float angle); // 0x0000000182222A40-0x0000000182222AA0
		private static IntPtr GetChild_Injected(IntPtr _unity_self, int index); // 0x0000000182220BB0-0x0000000182220BF0
		private static int GetChildCount_Injected(IntPtr _unity_self); // 0x0000000182220B10-0x0000000182220B50
		private static int internal_getHierarchyCapacity_Injected(IntPtr _unity_self); // 0x0000000182226080-0x00000001822260C0
		private static void internal_setHierarchyCapacity_Injected(IntPtr _unity_self, int value); // 0x0000000182226100-0x0000000182226140
		private static int internal_getHierarchyCount_Injected(IntPtr _unity_self); // 0x00000001822260C0-0x0000000182226100
		private static bool IsNonUniformScaleTransform_Injected(IntPtr _unity_self); // 0x0000000182222450-0x0000000182222490
		private static void SetConstrainProportionsScale_Injected(IntPtr _unity_self, bool isLinked); // 0x0000000182223900-0x0000000182223950
		private static bool IsConstrainProportionsScale_Injected(IntPtr _unity_self); // 0x00000001822223B0-0x00000001822223F0
	}
}
