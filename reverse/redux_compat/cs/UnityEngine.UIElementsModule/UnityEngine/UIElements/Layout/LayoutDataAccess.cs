/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	[IsReadOnly]
	internal struct LayoutDataAccess // TypeDefIndex: 5195
	{
		// Fields
		private readonly int m_Manager; // 0x00
		private readonly UnmanagedDataStore m_Nodes; // 0x08
		private readonly UnmanagedDataStore m_Configs; // 0x20
	
		// Constructors
		internal LayoutDataAccess(int manager, UnmanagedDataStore nodes, UnmanagedDataStore configs); // 0x0000000182439740-0x0000000182439770
	
		// Methods
		private ref ref T GetTypedNodeDataRef<T>(UnmanagedDataHandle handle, LayoutNodeDataType type)
			where T : struct;
		private ref ref T GetTypedConfigDataRef<T>(UnmanagedDataHandle handle, LayoutConfigDataType type)
			where T : struct;
		public ref LayoutNodeData GetNodeData(UnmanagedDataHandle handle); // 0x0000000182439600-0x0000000182439630
		public ref LayoutComputedData GetComputedData(UnmanagedDataHandle handle); // 0x00000001824394D0-0x0000000182439500
		public unsafe LayoutComputedData* GetComputedDataPtr(UnmanagedDataHandle handle); // 0x00000001824394D0-0x0000000182439500
		public ref LayoutCacheData GetCacheData(UnmanagedDataHandle handle); // 0x00000001824394A0-0x00000001824394D0
		public ref ComputedStyle GetComputedStyle(UnmanagedDataHandle handle); // 0x0000000182439500-0x0000000182439530
		public unsafe VisualElementTransformData* GetTransformDataPtr(UnmanagedDataHandle handle); // 0x0000000182439690-0x00000001824396C0
		internal unsafe VisualElementSelectorData* GetSelectorDataPtr(UnmanagedDataHandle handle); // 0x0000000182439660-0x0000000182439690
		public ref LayoutConfigData GetConfigData(UnmanagedDataHandle handle); // 0x0000000182439530-0x0000000182439560
		public ref PanelTransformData GetPanelTransformData(UnmanagedDataHandle handle); // 0x0000000182439630-0x0000000182439660
		public LayoutMeasureFunction GetMeasureFunction(UnmanagedDataHandle handle); // 0x0000000182439560-0x0000000182439600
		public void SetMeasureFunction(UnmanagedDataHandle handle, LayoutMeasureFunction value); // 0x00000001824396C0-0x0000000182439740
		public LayoutBaselineFunction GetBaselineFunction(UnmanagedDataHandle handle); // 0x0000000182439400-0x00000001824394A0
	}
}
