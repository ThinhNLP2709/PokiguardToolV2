/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public class DelegateProperty<TContainer, TValue> : Property<TContainer, TValue> // TypeDefIndex: 14448
	{
		// Fields
		private readonly PropertyGetter<TContainer, TValue> m_Getter;
		private readonly PropertySetter<TContainer, TValue> m_Setter;
		[CompilerGenerated]
		private readonly string _Name_k__BackingField;
	
		// Properties
		public override string Name { [CompilerGenerated] get; }
		public override bool IsReadOnly { get; }
	
		// Constructors
		public DelegateProperty(string name, PropertyGetter<TContainer, TValue> getter, PropertySetter<TContainer, TValue> setter = null);
	
		// Methods
		public override TValue GetValue(ref ref TContainer container);
		public override void SetValue(ref ref TContainer container, TValue value);
	}
}
