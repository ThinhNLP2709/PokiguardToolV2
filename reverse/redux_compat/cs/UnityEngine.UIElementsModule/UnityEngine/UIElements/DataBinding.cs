/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	[UxmlObject]
	public class DataBinding : Binding, IDataSourceProvider // TypeDefIndex: 3832
	{
		// Fields
		private static MethodInfo s_UpdateUIMethodInfo; // 0x00
		internal static readonly UniqueStyleString textElementInnerInputFieldUssClassNameUnique; // 0x08
		private BindingMode m_BindingMode; // 0x18
		private ConverterGroup m_SourceToUiConverters; // 0x20
		private ConverterGroup m_UiToSourceConverters; // 0x28
		[CompilerGenerated]
		private object _dataSource_k__BackingField; // 0x30
		[CompilerGenerated]
		private Type _dataSourceType_k__BackingField; // 0x38
		[CompilerGenerated]
		private PropertyPath _dataSourcePath_k__BackingField; // 0x40
	
		// Properties
		internal static MethodInfo updateUIMethod { get; } // 0x0000000182389A60-0x0000000182389CA0 
		[CreateProperty]
		public object dataSource { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		[CreateProperty]
		[HideInInspector]
		[Tooltip("A data source is a collection of information. By default, a binding will inherit the existing data source from the hierarchy. You can instead define another object here as the data source, or define the type of property it may be if the source is not yet available.")]
		[UxmlAttribute]
		[UxmlTypeReference(typeof(object))]
		public Type dataSourceType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[CreateProperty]
		public PropertyPath dataSourcePath { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823898C0-0x0000000182389920 0x0000000182389CB0-0x0000000182389D20
		[BindingModeDrawer]
		[CreateProperty]
		[HideInInspector]
		[Tooltip("Controls how a binding is updated, which can include the direction in which data is written.")]
		[UxmlAttribute("binding-mode")]
		public BindingMode bindingMode { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000182389CA0-0x0000000182389CB0
		[CreateProperty(ReadOnly = true)]
		public ConverterGroup sourceToUiConverters { get; } // 0x0000000182389920-0x00000001823899C0 
		[CreateProperty(ReadOnly = true)]
		public ConverterGroup uiToSourceConverters { get; } // 0x00000001823899C0-0x0000000182389A60 
	
		// Constructors
		public DataBinding(); // 0x0000000182389890-0x00000001823898C0
		static DataBinding(); // 0x0000000182389820-0x0000000182389890
	
		// Methods
		private static MethodInfo CacheReflectionInfo(); // 0x0000000182389660-0x0000000182389820
		public void ApplyConverterGroupToSource(ConverterGroup group); // 0x00000001823894A0-0x0000000182389580
		public void ApplyConverterGroupToUI(ConverterGroup group); // 0x0000000182389580-0x0000000182389660
		protected internal virtual BindingResult UpdateUI<TValue>([IsReadOnly] in BindingContext context, ref ref TValue value);
		protected internal virtual BindingResult UpdateSource<TValue>([IsReadOnly] in BindingContext context, ref ref TValue value);
		internal static string GetSetValueErrorString<TValue>(VisitReturnCode returnCode, object source, [IsReadOnly] in PropertyPath sourcePath, object target, [IsReadOnly] in BindingId targetPath, TValue extractedValueFromSource);
	}
}
