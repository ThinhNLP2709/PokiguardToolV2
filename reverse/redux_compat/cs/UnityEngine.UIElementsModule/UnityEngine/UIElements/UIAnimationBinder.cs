/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeClass("UIAnimationBinder", PersistentTypeId = 382093023)]
	[NativeHeader("Modules/UIElements/Core/Native/UIAnimationBinder.h")]
	[NativeHeader("Modules/UIElements/Core/Native/UIAnimationClip.h")]
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal sealed class UIAnimationBinder : UnityEngine.Object, IValueAnimationUpdate // TypeDefIndex: 4261
	{
		// Fields
		[CompilerGenerated]
		private VisualElement _rootVisualElement_k__BackingField; // 0x18
		private bool exposeRootElement; // 0x20
		private static readonly int[] m_ChannelCount; // 0x00
		private static readonly PropertyType[] m_PropertyTypeMapping; // 0x08
		private static readonly string[][] m_ChannelSuffixes; // 0x10
		private static readonly AnimationChannelKind[][] m_ChannelKinds; // 0x18
		internal List<KeyValuePair<string, VisualElement>> m_Elements; // 0x28
		internal Dictionary<PropertyName, VisualElement> m_ElementsMap; // 0x30
		[TupleElementNames(new string[2] {"element", "id" })]
		private Dictionary<ValueTuple<VisualElement, StylePropertyId>, List<FilterFunction>> m_PendingFilterWrites; // 0x38
		private bool m_BatchingFilterWrites; // 0x40
	
		// Properties
		private VisualElement rootVisualElement { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		internal enum PropertyType // TypeDefIndex: 4262
		{
			Length = 0,
			Float = 1,
			Int = 2,
			Enum = 3,
			BackgroundPosition = 4,
			BackgroundRepeat = 5,
			BackgroundSize = 6,
			BackgroundGradient = 7,
			Color = 8,
			Background = 9,
			Filter = 10,
			Font = 11,
			FontDefinition = 12,
			Cursor = 13,
			TextShadow = 14,
			TextAutoSize = 15,
			List = 16,
			Translate = 17,
			TransformOrigin = 18,
			Shorthand = 19,
			Rotate = 20,
			Scale = 21,
			UIAnimationClip = 22,
			MaterialDefinition = 23,
			Ratio = 24,
			EntityId = 25
		}
	
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal enum AnimationChannelKind // TypeDefIndex: 4263
		{
			Float = 0,
			Int = 1,
			PPtr = 2
		}
	
		// Constructors
		static UIAnimationBinder(); // 0x00000001824C37A0-0x00000001824C5CB0
	
		// Methods
		[FreeFunction("UIAnimationBinder::Create")]
		internal static UIAnimationBinder Create(); // 0x00000001824BEC00-0x00000001824BEC80
		private void Internal_AssignKnownElementNames(string[] names, PropertyName[] propertyHashes); // 0x00000001824C0970-0x00000001824C0A80
		private void Internal_ApplyBoundValues(); // 0x00000001824C0880-0x00000001824C0910
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SampleClip(UIAnimationClip clip, float time); // 0x00000001824C1A20-0x00000001824C1AF0
		internal void DeactivateAnimation(); // 0x00000001824BECC0-0x00000001824BED50
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void ClearBindings(); // 0x00000001824BE960-0x00000001824BE9F0
		internal void RegisterRootDocument(VisualElement element, bool exposeRootElement); // 0x00000001824C1760-0x00000001824C17E0
		[RequiredByNativeCode(Optional = true)]
		private void ClearElementCaches(); // 0x00000001824BE9F0-0x00000001824BEB00
		[RequiredByNativeCode(Optional = true)]
		private void UnregisterRootElement(); // 0x00000001824C2920-0x00000001824C2970
		private void ClearElementNames(); // 0x00000001824BEB00-0x00000001824BEBD0
		[RequiredByNativeCode(Optional = true)]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void UpdateElementNames(); // 0x00000001824C2970-0x00000001824C2E70
		private void GatherAnimatableElements(string path, VisualElement element, bool skipElement); // 0x00000001824BF0A0-0x00000001824BF2D0
		internal void ApplyAnimatedValues(); // 0x00000001824BE810-0x00000001824BE920
		[RequiredByNativeCode(Optional = true)]
		private void IterateOnBoundValues(IntPtr values, int count); // 0x00000001824C0A80-0x00000001824C0C40
		[RequiredByNativeCode(Optional = true)]
		private void FetchCurrentValue(IntPtr values, int count); // 0x00000001824BED50-0x00000001824BEEC0
		void IValueAnimationUpdate.Tick(long currentTimeMs); // 0x00000001824BE810-0x00000001824BE920
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static int GetChannelCount(StylePropertyId id); // 0x00000001824BF2D0-0x00000001824BF340
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static PropertyType GetPropertyTypeMapping(StylePropertyId id); // 0x00000001824C07D0-0x00000001824C0840
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static AnimationChannelKind GetChannelKind(StylePropertyId id, int channel); // 0x00000001824BF340-0x00000001824BF3E0
		private int GetElementCount(); // 0x00000001824BF3E0-0x00000001824BF400
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetFloatValue(int elementIndex, int propertyId, int channel, float value); // 0x00000001824C1AF0-0x00000001824C25A0
		internal float GetFloatValue(int elementIndex, int propertyId, int channel); // 0x00000001824BF400-0x00000001824BFF90
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void SetObjectValue(int elementIndex, int propertyId, int channel, EntityId value); // 0x00000001824C25A0-0x00000001824C2920
		internal EntityId GetObjectValue(int elementIndex, int propertyId, int channel); // 0x00000001824BFF90-0x00000001824C05E0
		private static float ReadFilterFloatOrTypeChannel(VisualElement element, int channel); // 0x00000001824C1010-0x00000001824C13E0
		private static EntityId ReadFilterCustomDefinitionChannel(VisualElement element, int channel); // 0x00000001824C0C40-0x00000001824C0E60
		private static float ReadFilterValue(VisualElement element, int filterIndex, int subChannel); // 0x00000001824C1530-0x00000001824C1760
		private static FilterFunctionType ReadFilterType(VisualElement element, int filterIndex); // 0x00000001824C13E0-0x00000001824C1530
		private static EntityId ReadFilterCustomDefinition(VisualElement element, int filterIndex); // 0x00000001824C0E60-0x00000001824C1010
		private static void WriteFilterValue(List<FilterFunction> filterList, int filterIndex, int subChannel, float value); // 0x00000001824C3430-0x00000001824C37A0
		private static void WriteFilterType(List<FilterFunction> filterList, int filterIndex, int rawType); // 0x00000001824C3120-0x00000001824C3430
		private static void ReseedParametersFromDefinition(ref FilterFunction f, FilterFunctionDefinition def, bool useInterpolationDefault); // 0x00000001824C17E0-0x00000001824C19C0
		private static void WriteFilterCustomDefinition(List<FilterFunction> filterList, int filterIndex, FilterFunctionDefinition newDef); // 0x00000001824C2E70-0x00000001824C3120
		private List<FilterFunction> GetOrLoadFilterList(VisualElement e, StylePropertyId id); // 0x00000001824C05E0-0x00000001824C07D0
		internal void FlushPendingFilterWrites(); // 0x00000001824BEEC0-0x00000001824BF0A0
		private static IntPtr Create_Injected(); // 0x00000001824BEBD0-0x00000001824BEC00
		private static void Internal_AssignKnownElementNames_Injected(IntPtr _unity_self, string[] names, ref ManagedSpanWrapper propertyHashes); // 0x00000001824C0910-0x00000001824C0970
		private static void Internal_ApplyBoundValues_Injected(IntPtr _unity_self); // 0x00000001824C0840-0x00000001824C0880
		private static void SampleClip_Injected(IntPtr _unity_self, IntPtr clip, float time); // 0x00000001824C19C0-0x00000001824C1A20
		private static void DeactivateAnimation_Injected(IntPtr _unity_self); // 0x00000001824BEC80-0x00000001824BECC0
		private static void ClearBindings_Injected(IntPtr _unity_self); // 0x00000001824BE920-0x00000001824BE960
	}
}
