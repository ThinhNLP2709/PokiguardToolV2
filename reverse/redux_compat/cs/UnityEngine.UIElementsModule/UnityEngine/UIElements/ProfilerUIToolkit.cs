/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using AOT;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/ProfilerUIToolkit.h")]
	[NativeHeader("Runtime/Interfaces/IProfilerUIToolkit.h")]
	internal static class ProfilerUIToolkit // TypeDefIndex: 4235
	{
		// Fields
		internal static readonly Guid kProfilerMetadataGuid; // 0x00
		private static CaptureMode s_ActiveCaptureMode; // 0x10
		private static readonly SetActiveCaptureModeDelegate s_SetActiveCaptureModeDelegate; // 0x18
		private static readonly RecordProfilerPanelMetadataForCaptureDelegate s_RecordProfilerPanelMetadataForCaptureDelegate; // 0x20
		private static UIToolkitPanelEventInfo[] s_PendingEvents; // 0x28
		private static int s_PendingEventsCount; // 0x30
		private static readonly Dictionary<Type, ushort> s_EventTypeNameIndices; // 0x38
		private static readonly Dictionary<int, ushort> s_StyleStringIndices; // 0x40
		private static readonly List<string> s_InternedStrings; // 0x48
		private static int s_EmittedInternedStringCount; // 0x50
	
		// Nested types
		internal enum CaptureMode // TypeDefIndex: 4236
		{
			Disabled = 0,
			EditorAndPlaymode = 1,
			PlaymodeOnly = 2
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void SetActiveCaptureModeDelegate(int mode); // TypeDefIndex: 4237; 0x00000001804A78A0-0x00000001804A78B0
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void RecordProfilerPanelMetadataForCaptureDelegate(); // TypeDefIndex: 4238; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		static ProfilerUIToolkit(); // 0x00000001824BC100-0x00000001824BC4B0
	
		// Methods
		[FreeFunction("ProfilerUIToolkit_RegisterManagedCallbacks")]
		private static void Native_RegisterManagedCallbacks(IntPtr setActiveCaptureMode, IntPtr recordProfilerPanelMetadataForCapture); // 0x00000001824BBE40-0x00000001824BBE90
		internal static void RegisterManagedCallbacks(); // 0x00000001824BBE90-0x00000001824BBF80
		[MonoPInvokeCallback(typeof(SetActiveCaptureModeDelegate))]
		internal static void SetActiveCaptureMode(int mode); // 0x00000001824BBF80-0x00000001824BC0A0
		[FreeFunction(Name = "ProfilerUIToolkit::EmitProfilerPanelMetadata")]
		internal static void EmitProfilerPanelMetadata([NotNull] EntityId[] entityIds, int count); // 0x00000001824BB690-0x00000001824BB770
		[FreeFunction("ProfilerUIToolkit_AddPanelUpdateMetrics")]
		private static void Native_AddPanelUpdateMetrics(ref UIToolkitPanelUpdateMetricsInfo panelMetrics); // 0x00000001824BBD20-0x00000001824BBD60
		[FreeFunction("ProfilerUIToolkit_AddBatchAggregateCounters")]
		internal static void AddBatchAggregateCounters(uint batchCount, uint drawCalls, uint vertices, uint indices); // 0x00000001824BAF20-0x00000001824BAF80
		[FreeFunction("ProfilerUIToolkit_EmitBatchMetricsForPanel")]
		private static unsafe void Native_EmitBatchMetricsForPanel(UIToolkitBatchMetricsInfo* batches, int batchCount, EntityId* owners, int ownerCount); // 0x00000001824BBD60-0x00000001824BBDC0
		[FreeFunction("ProfilerUIToolkit_EmitPanelEvents")]
		private static unsafe void Native_EmitPanelEvents(UIToolkitPanelEventInfo* events, int count); // 0x00000001824BBE00-0x00000001824BBE40
		[FreeFunction("ProfilerUIToolkit_EmitEventTypeName")]
		private static unsafe void Native_EmitEventTypeName(byte* utf8, int length); // 0x00000001824BBDC0-0x00000001824BBE00
		internal static void CapturePanelEvent(BaseVisualElementPanel panel, EventBase evt); // 0x00000001824BB140-0x00000001824BB5D0
		private static void EnqueuePanelEvent([IsReadOnly] in UIToolkitPanelEventInfo info); // 0x00000001824BB770-0x00000001824BB860
		private static ushort InternEventTypeName(Type eventType); // 0x00000001824BBB20-0x00000001824BBC10
		private static ushort InternStyleString(int uniqueStyleStringId); // 0x00000001824BBC10-0x00000001824BBD20
		private static ushort AddInternedString(string value); // 0x00000001824BAF80-0x00000001824BB080
		internal static void FlushPendingEvents(); // 0x00000001824BB860-0x00000001824BBB20
		internal static bool ShouldCapturePanel(bool isEditorPanel); // 0x00000001824BC0A0-0x00000001824BC100
		internal static void EmitBatchMetricsForPanel(NativeArray<UIToolkitBatchMetricsInfo> batches, NativeArray<EntityId> owners); // 0x00000001824BB5D0-0x00000001824BB650
		internal static void AddPanelUpdateMetrics(EntityId panelId, uint hierarchyVersionChanges, uint repaintVersionChanges, int veCount); // 0x00000001824BB080-0x00000001824BB140
		[MonoPInvokeCallback(typeof(RecordProfilerPanelMetadataForCaptureDelegate))]
		internal static void RecordProfilerPanelMetadataForCapture(); // 0x00000001824BA8B0-0x00000001824BA980
		private static void EmitProfilerPanelMetadata_Injected(ref ManagedSpanWrapper entityIds, int count); // 0x00000001824BB650-0x00000001824BB690
	}
}
