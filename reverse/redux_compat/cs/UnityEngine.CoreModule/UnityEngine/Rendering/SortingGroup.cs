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

namespace UnityEngine.Rendering
{
	[NativeClass("SortingGroup", PersistentTypeId = 210)]
	[NativeHeader("Runtime/2D/Sorting/SortingGroup.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class SortingGroup : Behaviour // TypeDefIndex: 8247
	{
		// Properties
		[StaticAccessor("SortingGroup", StaticAccessorType.DoubleColon)]
		internal static int invalidSortingGroupID { get; } // 0x0000000182253620-0x0000000182253650 
		public int sortingLayerID { get; } // 0x0000000182253690-0x00000001822536F0 
		public int sortingOrder { get; } // 0x0000000182253730-0x0000000182253790 
	
		// Methods
		[StaticAccessor("SortingGroup", StaticAccessorType.DoubleColon)]
		internal static SortingGroup GetSortingGroupByIndex(int index); // 0x00000001822535C0-0x0000000182253620
		private static IntPtr GetSortingGroupByIndex_Injected(int index); // 0x0000000182253580-0x00000001822535C0
		private static int get_sortingLayerID_Injected(IntPtr _unity_self); // 0x0000000182253650-0x0000000182253690
		private static int get_sortingOrder_Injected(IntPtr _unity_self); // 0x00000001822536F0-0x0000000182253730
	}
}
