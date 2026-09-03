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
	[NativeHeader("Runtime/Misc/AsyncOperation.h")]
	[NativeHeader("Runtime/Export/Scripting/AsyncOperation.bindings.h")]
	[RequiredByNativeCode]
	public class AsyncOperation : YieldInstruction // TypeDefIndex: 7708
	{
		// Fields
		[VisibleToOtherModules]
		internal IntPtr m_Ptr; // 0x10
		private Action<AsyncOperation> m_completeCallback; // 0x18
	
		// Properties
		public bool isDone { [NativeMethod("IsDone")] get; } // 0x00000001821E2030-0x00000001821E2090 
		public float progress { [NativeMethod("GetProgress")] get; } // 0x00000001821E20D0-0x00000001821E2130 
		public int priority { [NativeMethod("SetPriority")] set; } // 0x00000001821E22D0-0x00000001821E2330
		public bool allowSceneActivation { [NativeMethod("GetAllowSceneActivation")] get; [NativeMethod("SetAllowSceneActivation")] set; } // 0x00000001821E1F90-0x00000001821E1FF0 0x00000001821E2230-0x00000001821E2290
	
		// Events
		public event Action<AsyncOperation> completed {
			add; // 0x00000001821E1E20-0x00000001821E1F50
			remove; // 0x00000001821E2130-0x00000001821E21E0
		}
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7709
		{
			// Methods
			public static AsyncOperation ConvertToManaged(IntPtr ptr); // 0x00000001821E47A0-0x00000001821E4820
			public static IntPtr ConvertToNative(AsyncOperation asyncOperation); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		protected AsyncOperation(IntPtr ptr); // 0x00000001821E1DC0-0x00000001821E1E20
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		[StaticAccessor("AsyncOperationBindings", StaticAccessorType.DoubleColon)]
		private static void InternalDestroy(IntPtr ptr); // 0x00000001821E1CE0-0x00000001821E1D20
		[NativeMethod(IsThreadSafe = true)]
		[StaticAccessor("AsyncOperationBindings", StaticAccessorType.DoubleColon)]
		private static void InternalSetManagedObject(IntPtr ptr, [UnityMarshalAs(NativeType.ScriptingObjectPtr)] AsyncOperation self); // 0x00000001821E1D20-0x00000001821E1D70
		~AsyncOperation(); // 0x00000001821E1C50-0x00000001821E1CE0
		[RequiredByNativeCode]
		internal void InvokeCompletionEvent(); // 0x00000001821E1D70-0x00000001821E1DC0
		private static bool get_isDone_Injected(IntPtr _unity_self); // 0x00000001821E1FF0-0x00000001821E2030
		private static float get_progress_Injected(IntPtr _unity_self); // 0x00000001821E2090-0x00000001821E20D0
		private static void set_priority_Injected(IntPtr _unity_self, int value); // 0x00000001821E2290-0x00000001821E22D0
		private static bool get_allowSceneActivation_Injected(IntPtr _unity_self); // 0x00000001821E1F50-0x00000001821E1F90
		private static void set_allowSceneActivation_Injected(IntPtr _unity_self, bool value); // 0x00000001821E21E0-0x00000001821E2230
	}
}
