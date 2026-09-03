/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	internal struct PhysicsTransformWatcher // TypeDefIndex: 14701
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static Dictionary<Transform, HashSet<PhysicsCallbacks.ITransformChangedCallback>> s_TransformWatchers; // 0x00
	
		// Methods
		public static void SendCallbacks(ref NativeArray<PhysicsEvents.TransformChangeEvent> transformChangeEvents); // 0x00000001822CBA50-0x00000001822CBE00
		[RequiredByNativeCode]
		private static void ClearAllWatchers(); // 0x00000001822CB8A0-0x00000001822CBA50
		[RequiredByNativeCode]
		private static void TransformChangedCallback(Scripting2D.PhysicsBuffer physicsBuffer); // 0x00000001822CBE00-0x00000001822CBE70
		[RequiredByNativeCode]
		private static void TransformParentHierarchyChangedCallback(Scripting2D.PhysicsBuffer physicsBuffer); // 0x00000001822CBE70-0x00000001822CBEE0
	}
}
