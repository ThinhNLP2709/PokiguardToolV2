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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class BindingUpdater // TypeDefIndex: 3824
	{
		// Fields
		private static readonly CastDataSourceVisitor s_VisitDataSourceAsRootVisitor; // 0x00
		private static readonly UIPathVisitor s_VisitDataSourceAtPathVisitor; // 0x08
	
		// Nested types
		private sealed class CastDataSourceVisitor : ConcreteTypeVisitor // TypeDefIndex: 3825
		{
			// Fields
			[CompilerGenerated]
			private DataBinding _Binding_k__BackingField; // 0x10
			[CompilerGenerated]
			private BindingContext _bindingContext_k__BackingField; // 0x18
			[CompilerGenerated]
			private BindingResult _result_k__BackingField; // 0x150
	
			// Properties
			public DataBinding Binding { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public BindingContext bindingContext { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182382290-0x0000000182382320 0x0000000182382320-0x00000001823823B0
			public BindingResult result { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001820AF290-0x00000001820AF2A0 0x00000001823823B0-0x00000001823823D0
	
			// Constructors
			public CastDataSourceVisitor(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public void Reset(); // 0x00000001823821B0-0x0000000182382290
			protected override void VisitContainer<TContainer>(ref ref TContainer container);
		}
	
		private sealed class UIPathVisitor : PathVisitor // TypeDefIndex: 3826
		{
			// Fields
			[CompilerGenerated]
			private DataBinding _binding_k__BackingField; // 0xB8
			[CompilerGenerated]
			private BindingUpdateStage _direction_k__BackingField; // 0xC0
			[CompilerGenerated]
			private BindingContext _bindingContext_k__BackingField; // 0xC8
			[CompilerGenerated]
			private BindingResult _result_k__BackingField; // 0x200
	
			// Properties
			public DataBinding binding { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
			public BindingUpdateStage direction { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181239340-0x0000000181239350 0x000000018170C650-0x000000018170C660
			public BindingContext bindingContext { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182393790-0x0000000182393830 0x0000000182393840-0x00000001823938D0
			public BindingResult result { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182393830-0x0000000182393840 0x00000001823938D0-0x00000001823938F0
	
			// Constructors
			public UIPathVisitor(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override void Reset(); // 0x0000000182393680-0x0000000182393790
			protected override void VisitPath<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container, ref ref TValue value);
		}
	
		// Constructors
		public BindingUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static BindingUpdater(); // 0x0000000182381570-0x0000000182381640
	
		// Methods
		public bool ShouldProcessBindingAtStage(Binding bindingObject, BindingUpdateStage stage, bool versionChanged, bool dirty); // 0x000000018237F300-0x000000018237F630
		private static bool ShouldProcessBindingAtStage(DataBinding dataBinding, BindingUpdateStage stage, bool versionChanged, bool dirty); // 0x000000018237F630-0x000000018237F740
		private bool ShouldProcessBindingAtStage(CustomBinding customBinding, BindingUpdateStage stage, bool versionChanged, bool dirty); // 0x000000018237F740-0x000000018237F820
		public BindingResult UpdateUI([IsReadOnly] in BindingContext context, Binding bindingObject); // 0x0000000182381060-0x0000000182381210
		public BindingResult UpdateSource([IsReadOnly] in BindingContext context, Binding bindingObject); // 0x0000000182380760-0x0000000182380910
		private BindingResult UpdateUI([IsReadOnly] in BindingContext context, DataBinding dataBinding); // 0x0000000182380960-0x0000000182381060
		private BindingResult UpdateUI([IsReadOnly] in BindingContext context, CustomBinding customBinding); // 0x0000000182380910-0x0000000182380960
		private BindingResult UpdateDataSource([IsReadOnly] in BindingContext context, DataBinding dataBinding); // 0x0000000182380370-0x0000000182380760
		private BindingResult UpdateDataSource([IsReadOnly] in BindingContext context, CustomBinding customBinding); // 0x0000000182380340-0x0000000182380370
		private static BindingResult TryUpdateUIWithNonContainer([IsReadOnly] in BindingContext context, DataBinding binding, object value); // 0x000000018237F820-0x0000000182380340
		private static ValueTuple<bool, VisitReturnCode, BindingResult> VisitRoot(DataBinding dataBinding, ref object container, [IsReadOnly] in BindingContext context); // 0x0000000182381210-0x0000000182381570
		private static ValueTuple<bool, VisitReturnCode, VisitReturnCode, BindingResult> VisitAtPath<TContainer>(DataBinding dataBinding, BindingUpdateStage direction, ref ref TContainer container, [IsReadOnly] in PropertyPath path, [IsReadOnly] in BindingContext context);
		internal static string GetVisitationErrorString(VisitReturnCode returnCode, [IsReadOnly] in BindingContext context); // 0x000000018237F0B0-0x000000018237F300
		internal static string GetExtractValueErrorString(VisitReturnCode returnCode, object target, [IsReadOnly] in PropertyPath path); // 0x000000018237EDF0-0x000000018237F030
		internal static string GetRootDataSourceError(object target); // 0x000000018237F030-0x000000018237F0B0
	}
}
