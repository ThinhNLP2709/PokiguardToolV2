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
	[UxmlElement]
	public abstract class BaseField<TValueType> : AbstractBaseField, INotifyValueChanged<TValueType> // TypeDefIndex: 3892
	{
		// Fields
		public static readonly string ussClassName;
		public static readonly string labelUssClassName;
		public static readonly string inputUssClassName;
		public static readonly string noLabelVariantUssClassName;
		public static readonly string labelDraggerVariantUssClassName;
		public static readonly string mixedValueLabelUssClassName;
		public static readonly string alignedFieldUssClassName;
		protected internal static readonly string mixedValueString;
		protected internal static readonly PropertyName serializedPropertyCopyName;
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static readonly BindingId valueProperty;
		[DontCreateProperty]
		[SerializeField]
		private TValueType m_Value;
		internal List<ValidateValueHandler> m_OnValidateValue;
		private bool m_SkipValidation;
		[CompilerGenerated]
		private Action viewDataRestored;
	
		// Properties
		protected TValueType rawValue { get; }
		[CreateProperty]
		public virtual TValueType value { get; set; }
	
		// Events
		internal event Action viewDataRestored {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		public delegate TValueType ValidateValueHandler(TValueType value); // TypeDefIndex: 3893; 0x00000000-0x00000000
	
		// Constructors
		protected BaseField(string label, VisualElement visualInput);
		static BaseField();
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual bool EqualsCurrentValue(TValueType v);
		internal TValueType ValidatedValue(TValueType value);
		public virtual void SetValueWithoutNotify(TValueType newValue);
		internal override void OnViewDataReady();
	}
}
