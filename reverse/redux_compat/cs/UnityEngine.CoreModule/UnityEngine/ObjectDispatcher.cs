/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Misc/ObjectDispatcher.h")]
	[RequiredByNativeCode]
	[StaticAccessor("GetObjectDispatcher()", StaticAccessorType.Dot)]
	internal sealed class ObjectDispatcher : IDisposable // TypeDefIndex: 7674
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		private Allocator m_DispatchAllocator; // 0x18
		private TypeDispatchData m_TypeDispatchData; // 0x20
		private TransformDispatchData m_TransformDispatchData; // 0x48
		private Component[] m_TransformedComponents; // 0xA8
		private Action<TypeDispatchData> m_TypeDataCallback; // 0xB0
		private Action<TransformDispatchData> m_TransformDataCallback; // 0xB8
		private Action<Component[]> m_TransformComponentCallback; // 0xC0
		[NoAutoStaticsCleanup]
		private static Action<Object[], IntPtr, IntPtr, int, int, Action<TypeDispatchData>> s_TypeDispatch; // 0x00
		[NoAutoStaticsCleanup]
		private static Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, Action<TransformDispatchData>> s_TransformDispatch; // 0x08
	
		// Properties
		public bool valid { get; } // 0x0000000181C1F6D0-0x0000000181C1F6E0 
	
		// Nested types
		public enum TransformTrackingType // TypeDefIndex: 7675
		{
			GlobalTRS = 0,
			LocalTRS = 1,
			Hierarchy = 2
		}
	
		[Flags]
		public enum TypeTrackingFlags // TypeDefIndex: 7676
		{
			SceneObjects = 1,
			Assets = 2,
			Default = 3,
			EditorOnlyObjects = 4,
			All = 7
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 7677
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001821FB240-0x00000001821FB2B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__64_0(Object[] changed, IntPtr changedID, IntPtr destroyedID, int changedCount, int destroyedCount, Action<TypeDispatchData> callback); // 0x00000001821FADC0-0x00000001821FAED0
			internal void _.cctor_b__64_1(IntPtr transformed, IntPtr parents, IntPtr localToWorldMatrices, IntPtr positions, IntPtr rotations, IntPtr scales, int count, Action<TransformDispatchData> callback); // 0x00000001821FAED0-0x00000001821FB050
		}
	
		// Constructors
		public ObjectDispatcher(); // 0x00000001821F0890-0x00000001821F0A10
		static ObjectDispatcher(); // 0x00000001821F0740-0x00000001821F0890
	
		// Methods
		~ObjectDispatcher(); // 0x00000001821F0150-0x00000001821F01C0
		public void Dispose(); // 0x00000001821EFC90-0x00000001821EFCF0
		private void Dispose(bool disposing); // 0x00000001821EFC00-0x00000001821EFC90
		private void ValidateSystemHandleAndThrow(); // 0x00000001821F0630-0x00000001821F0690
		private void ValidateTypeAndThrow(Type type); // 0x00000001821F0690-0x00000001821F0740
		private void ValidateComponentTypeAndThrow(Type type); // 0x00000001821F0580-0x00000001821F0630
		private void DispatchCallback(TypeDispatchData data); // 0x00000001821EF5C0-0x00000001821EF660
		private void DispatchCallback(TransformDispatchData data); // 0x00000001821EF660-0x00000001821EF7C0
		private void DispatchCallback(Component[] components); // 0x000000018033EAB0-0x000000018033EAD0
		public void DispatchTypeChangesAndClear(Type type, Action<TypeDispatchData> callback, bool sortByInstanceID = false /* Metadata: 0x0069D684 */, bool noScriptingArray = false /* Metadata: 0x0069D685 */); // 0x00000001821EFA50-0x00000001821EFC00
		public void DispatchTransformChangesAndClear(Type type, TransformTrackingType trackingType, Action<TransformDispatchData> callback); // 0x00000001821EF7C0-0x00000001821EF970
		public TypeDispatchData GetTypeChangesAndClear(Type type, Allocator allocator, bool sortByInstanceID = false /* Metadata: 0x0069D686 */, bool noScriptingArray = false /* Metadata: 0x0069D687 */); // 0x00000001821F03B0-0x00000001821F0580
		public TransformDispatchData GetTransformChangesAndClear(Type type, TransformTrackingType trackingType, Allocator allocator); // 0x00000001821F01C0-0x00000001821F03B0
		public void EnableTypeTracking(TypeTrackingFlags typeTrackingMask, params Type[] types); // 0x00000001821EFF20-0x00000001821F00F0
		public void EnableTransformTracking(TransformTrackingType trackingType, params Type[] types); // 0x00000001821EFCF0-0x00000001821EFEC0
		public TypeDispatchData GetTypeChangesAndClear<T>(Allocator allocator, bool sortByInstanceID = false /* Metadata: 0x0069D688 */, bool noScriptingArray = false /* Metadata: 0x0069D689 */)
			where T : Object;
		public TransformDispatchData GetTransformChangesAndClear<T>(TransformTrackingType trackingType, Allocator allocator)
			where T : Object;
		public void EnableTypeTracking<T>(TypeTrackingFlags typeTrackingMask = TypeTrackingFlags.SceneObjects | TypeTrackingFlags.Assets | TypeTrackingFlags.Default /* Metadata: 0x0069D68A */)
			where T : Object;
		public void EnableTransformTracking<T>(TransformTrackingType trackingType)
			where T : Object;
		private static IntPtr CreateDispatchSystemHandle(); // 0x00000001821EF550-0x00000001821EF580
		[NativeMethod(IsThreadSafe = true)]
		private static void DestroyDispatchSystemHandle(IntPtr ptr); // 0x00000001821EF580-0x00000001821EF5C0
		private static void EnableTypeTracking(IntPtr ptr, Type type, TypeTrackingFlags typeTrackingMask); // 0x00000001821F00F0-0x00000001821F0150
		private static void EnableTransformTracking(IntPtr ptr, Type type, TransformTrackingType trackingType); // 0x00000001821EFEC0-0x00000001821EFF20
		private static void DispatchTypeChangesAndClear(IntPtr ptr, Type type, Action<Object[], IntPtr, IntPtr, int, int, Action<TypeDispatchData>> callback, bool sortByInstanceID, bool noScriptingArray, Action<TypeDispatchData> param); // 0x00000001821EF9E0-0x00000001821EFA50
		private static void DispatchTransformDataChangesAndClear(IntPtr ptr, Type type, TransformTrackingType trackingType, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, Action<TransformDispatchData>> callback, Action<TransformDispatchData> param); // 0x00000001821EF970-0x00000001821EF9E0
	}
}
