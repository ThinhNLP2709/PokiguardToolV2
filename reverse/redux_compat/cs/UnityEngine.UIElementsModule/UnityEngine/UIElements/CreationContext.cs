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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public struct CreationContext : IEquatable<UnityEngine.UIElements.CreationContext> // TypeDefIndex: 4923
	{
		// Fields
		[CompilerGenerated]
		private VisualElement _target_k__BackingField; // 0x00
		[CompilerGenerated]
		private List<int> _veaIdsPath_k__BackingField; // 0x08
		[CompilerGenerated]
		private TemplateAsset _templateAsset_k__BackingField; // 0x10
		[CompilerGenerated]
		private VisualTreeAsset _visualTreeAsset_k__BackingField; // 0x18
		[CompilerGenerated]
		private Dictionary<string, VisualElement> _slotInsertionPoints_k__BackingField; // 0x20
		[CompilerGenerated]
		private List<AttributeOverrideRange> _attributeOverrides_k__BackingField; // 0x28
		[CompilerGenerated]
		private List<SerializedDataOverrideRange> _serializedDataOverrides_k__BackingField; // 0x30
		[CompilerGenerated]
		private List<string> _namesPath_k__BackingField; // 0x38
	
		// Properties
		public VisualElement target { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal List<int> veaIdsPath { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		internal TemplateAsset templateAsset { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public VisualTreeAsset visualTreeAsset { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Dictionary<string, VisualElement> slotInsertionPoints { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		internal List<AttributeOverrideRange> attributeOverrides { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal List<SerializedDataOverrideRange> serializedDataOverrides { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		private List<string> namesPath { [CompilerGenerated] set; } // 0x000000018033E850-0x000000018033E860
		internal bool hasOverrides { get; } // 0x00000001823CDBC0-0x00000001823CDBF0 
	
		// Nested types
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal struct AttributeOverrideRange // TypeDefIndex: 4924
		{
			// Fields
			internal readonly VisualTreeAsset sourceAsset; // 0x00
			internal readonly List<TemplateAsset.AttributeOverride> attributeOverrides; // 0x08
		}
	
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal struct SerializedDataOverrideRange // TypeDefIndex: 4925
		{
			// Fields
			internal readonly VisualTreeAsset sourceAsset; // 0x00
			internal readonly int templateId; // 0x08
			internal readonly List<TemplateAsset.UxmlSerializedDataOverride> attributeOverrides; // 0x10
		}
	
		// Constructors
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal CreationContext(Dictionary<string, VisualElement> slotInsertionPoints, List<AttributeOverrideRange> attributeOverrides, List<SerializedDataOverrideRange> serializedDataOverrides, VisualTreeAsset vta, VisualElement target, List<int> veaIdsPath, List<string> namesPath, TemplateAsset ta); // 0x00000001823CDB00-0x00000001823CDBC0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001823CD950-0x00000001823CDA00
		public bool Equals(CreationContext other); // 0x00000001823CD850-0x00000001823CD950
		public override int GetHashCode(); // 0x00000001823CDA00-0x00000001823CDB00
	}
}
