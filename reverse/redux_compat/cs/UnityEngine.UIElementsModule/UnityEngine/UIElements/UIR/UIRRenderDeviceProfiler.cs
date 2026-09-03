/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal sealed class UIRRenderDeviceProfiler : IDisposable // TypeDefIndex: 5051
	{
		// Fields
		private static readonly MemoryLabel s_ScratchLabel; // 0x00
		private readonly List<EntityId> m_ActivePanelComponents; // 0x10
		private readonly List<EntityId> m_BatchContributors; // 0x18
		private bool m_NeedsContributorCapture; // 0x20
		private NativeList<UIToolkitBatchMetricsInfo> m_BatchMetrics; // 0x28
		private NativeList<EntityId> m_BatchOwners; // 0x30
		private uint m_BatchBaseDrawCalls; // 0x38
		private uint m_BatchBaseVerts; // 0x3C
		private uint m_BatchBaseIndices; // 0x40
		private uint m_BatchBaseImmediates; // 0x44
		private uint m_BatchBaseDrawRanges; // 0x48
		private uint m_PanelBaseDrawCalls; // 0x4C
		private uint m_PanelBaseVerts; // 0x50
		private uint m_PanelBaseIndices; // 0x54
	
		// Constructors
		public UIRRenderDeviceProfiler(); // 0x000000018241F1F0-0x000000018241F750
		static UIRRenderDeviceProfiler(); // 0x000000018241F160-0x000000018241F1F0
	
		// Methods
		public void BeginPanel([IsReadOnly] in UIRenderDevice.DrawStatistics current = null); // 0x000000018241EB40-0x000000018241ED30
		internal bool TryGetAccumulated(out NativeArray<UIToolkitBatchMetricsInfo> batches, out NativeArray<EntityId> owners); // 0x000000018241F080-0x000000018241F160
		public void BeginComponent(EntityId componentId); // 0x000000018241EAA0-0x000000018241EB40
		public void EndComponent(); // 0x000000018241EF10-0x000000018241EFB0
		public void OnDraw(); // 0x000000018241EFB0-0x000000018241F080
		public void AppendBatch(EntityId panelId, bool isRenderingNestedTreeRT, KickRangesReason kickRangesReason, [IsReadOnly] in UIRenderDevice.DrawStatistics current); // 0x000000018241E8D0-0x000000018241EAA0
		public void EmitPanel([IsReadOnly] in UIRenderDevice.DrawStatistics current); // 0x000000018241EDA0-0x000000018241EF10
		public void Dispose(); // 0x000000018241ED30-0x000000018241EDA0
	}
}
