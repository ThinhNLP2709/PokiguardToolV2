namespace UnityEngine;

[NativeHeader("Runtime/Transform/Transform.h")]
[NativeHeader("Runtime/Transform/ScriptBindings/TransformScriptBindings.h")]
[NativeHeader("Configuration/UnityConfigure.h")]
[RequiredByNativeCode]
public class Transform : Component, IEnumerable
{
	private class Enumerator : IEnumerator
	{
		private Transform outer; //Field offset: 0x10
		private int currentIndex; //Field offset: 0x18

		public override object Current
		{
			 get { } //Length: 160
		}

		internal Enumerator(Transform outer) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}


	public int childCount
	{
		[NativeMethod("GetChildrenCount")]
		 get { } //Length: 119
	}

	public Vector3 eulerAngles
	{
		 get { } //Length: 283
		 set { } //Length: 210
	}

	public Vector3 forward
	{
		 get { } //Length: 270
		 set { } //Length: 167
	}

	[NativeProperty("HasChangedDeprecated")]
	public bool hasChanged
	{
		 get { } //Length: 119
		 set { } //Length: 135
	}

	public Vector3 localEulerAngles
	{
		 get { } //Length: 283
		 set { } //Length: 210
	}

	public Vector3 localPosition
	{
		 get { } //Length: 145
		 set { } //Length: 134
	}

	public Quaternion localRotation
	{
		 get { } //Length: 143
		 set { } //Length: 134
	}

	public Vector3 localScale
	{
		 get { } //Length: 145
		 set { } //Length: 134
	}

	public Matrix4x4 localToWorldMatrix
	{
		 get { } //Length: 155
	}

	public Vector3 lossyScale
	{
		[NativeMethod("GetWorldScaleLossy")]
		 get { } //Length: 145
	}

	public Transform parent
	{
		 get { } //Length: 145
		 set { } //Length: 304
	}

	internal Transform parentInternal
	{
		internal get { } //Length: 145
		internal set { } //Length: 181
	}

	public Vector3 position
	{
		 get { } //Length: 145
		 set { } //Length: 134
	}

	public Vector3 right
	{
		 get { } //Length: 270
	}

	public Transform root
	{
		 get { } //Length: 145
	}

	public Quaternion rotation
	{
		 get { } //Length: 143
		 set { } //Length: 134
	}

	public Vector3 up
	{
		 get { } //Length: 270
	}

	public Matrix4x4 worldToLocalMatrix
	{
		 get { } //Length: 155
	}

	public Transform Find(string n) { }

	[FreeFunction(HasExplicitThis = True)]
	private Transform FindRelativeTransformWithPath(string path, bool isActiveOnly) { }

	private static IntPtr FindRelativeTransformWithPath_Injected(IntPtr _unity_self, ref ManagedSpanWrapper path, bool isActiveOnly) { }

	[NativeMethod("GetChildrenCount")]
	public int get_childCount() { }

	private static int get_childCount_Injected(IntPtr _unity_self) { }

	public Vector3 get_eulerAngles() { }

	public Vector3 get_forward() { }

	public bool get_hasChanged() { }

	private static bool get_hasChanged_Injected(IntPtr _unity_self) { }

	public Vector3 get_localEulerAngles() { }

	public Vector3 get_localPosition() { }

	private static void get_localPosition_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public Quaternion get_localRotation() { }

	private static void get_localRotation_Injected(IntPtr _unity_self, out Quaternion ret) { }

	public Vector3 get_localScale() { }

	private static void get_localScale_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public Matrix4x4 get_localToWorldMatrix() { }

	private static void get_localToWorldMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret) { }

	[NativeMethod("GetWorldScaleLossy")]
	public Vector3 get_lossyScale() { }

	private static void get_lossyScale_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public Transform get_parent() { }

	internal Transform get_parentInternal() { }

	public Vector3 get_position() { }

	private static void get_position_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public Vector3 get_right() { }

	public Transform get_root() { }

	public Quaternion get_rotation() { }

	private static void get_rotation_Injected(IntPtr _unity_self, out Quaternion ret) { }

	public Vector3 get_up() { }

	public Matrix4x4 get_worldToLocalMatrix() { }

	private static void get_worldToLocalMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret) { }

	[FreeFunction("GetChild", HasExplicitThis = True)]
	[NativeThrows]
	public Transform GetChild(int index) { }

	private static IntPtr GetChild_Injected(IntPtr _unity_self, int index) { }

	public override IEnumerator GetEnumerator() { }

	private Transform GetParent() { }

	private static IntPtr GetParent_Injected(IntPtr _unity_self) { }

	private Transform GetRoot() { }

	private static IntPtr GetRoot_Injected(IntPtr _unity_self) { }

	public int GetSiblingIndex() { }

	private static int GetSiblingIndex_Injected(IntPtr _unity_self) { }

	[FreeFunction("Internal_LookAt", HasExplicitThis = True)]
	private void Internal_LookAt(Vector3 worldPosition, Vector3 worldUp) { }

	private static void Internal_LookAt_Injected(IntPtr _unity_self, in Vector3 worldPosition, in Vector3 worldUp) { }

	public Vector3 InverseTransformPoint(Vector3 position) { }

	private static void InverseTransformPoint_Injected(IntPtr _unity_self, in Vector3 position, out Vector3 ret) { }

	[FreeFunction("Internal_IsChildOrSameTransform", HasExplicitThis = True)]
	public bool IsChildOf(Transform parent) { }

	private static bool IsChildOf_Injected(IntPtr _unity_self, IntPtr parent) { }

	public void LookAt(Transform target) { }

	public void LookAt(Vector3 worldPosition, Vector3 worldUp) { }

	public void Rotate(Vector3 eulers, Space relativeTo) { }

	public void Rotate(float xAngle, float yAngle, float zAngle) { }

	public void RotateAround(Vector3 point, Vector3 axis, float angle) { }

	[NativeMethod("RotateAround")]
	internal void RotateAroundInternal(Vector3 axis, float angle) { }

	private static void RotateAroundInternal_Injected(IntPtr _unity_self, in Vector3 axis, float angle) { }

	public void set_eulerAngles(Vector3 value) { }

	public void set_forward(Vector3 value) { }

	public void set_hasChanged(bool value) { }

	private static void set_hasChanged_Injected(IntPtr _unity_self, bool value) { }

	public void set_localEulerAngles(Vector3 value) { }

	public void set_localPosition(Vector3 value) { }

	private static void set_localPosition_Injected(IntPtr _unity_self, in Vector3 value) { }

	public void set_localRotation(Quaternion value) { }

	private static void set_localRotation_Injected(IntPtr _unity_self, in Quaternion value) { }

	public void set_localScale(Vector3 value) { }

	private static void set_localScale_Injected(IntPtr _unity_self, in Vector3 value) { }

	public void set_parent(Transform value) { }

	internal void set_parentInternal(Transform value) { }

	public void set_position(Vector3 value) { }

	private static void set_position_Injected(IntPtr _unity_self, in Vector3 value) { }

	public void set_rotation(Quaternion value) { }

	private static void set_rotation_Injected(IntPtr _unity_self, in Quaternion value) { }

	public void SetAsFirstSibling() { }

	private static void SetAsFirstSibling_Injected(IntPtr _unity_self) { }

	public void SetAsLastSibling() { }

	private static void SetAsLastSibling_Injected(IntPtr _unity_self) { }

	public void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation) { }

	private static void SetLocalPositionAndRotation_Injected(IntPtr _unity_self, in Vector3 localPosition, in Quaternion localRotation) { }

	[FreeFunction("SetParent", HasExplicitThis = True)]
	public void SetParent(Transform parent, bool worldPositionStays) { }

	public void SetParent(Transform p) { }

	private static void SetParent_Injected(IntPtr _unity_self, IntPtr parent, bool worldPositionStays) { }

	public void SetSiblingIndex(int index) { }

	private static void SetSiblingIndex_Injected(IntPtr _unity_self, int index) { }

	public Vector3 TransformDirection(float x, float y, float z) { }

	public Vector3 TransformDirection(Vector3 direction) { }

	private static void TransformDirection_Injected(IntPtr _unity_self, in Vector3 direction, out Vector3 ret) { }

	public Vector3 TransformPoint(Vector3 position) { }

	private static void TransformPoint_Injected(IntPtr _unity_self, in Vector3 position, out Vector3 ret) { }

	public void Translate(Vector3 translation, Space relativeTo) { }

}

