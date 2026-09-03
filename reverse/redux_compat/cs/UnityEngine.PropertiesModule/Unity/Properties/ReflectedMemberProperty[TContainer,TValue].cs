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
	public class ReflectedMemberProperty<TContainer, TValue> : Property<TContainer, TValue> // TypeDefIndex: 14462
	{
		// Fields
		private readonly IMemberInfo m_Info;
		private readonly bool m_IsStructContainerType;
		private GetStructValueAction m_GetStructValueAction;
		private SetStructValueAction m_SetStructValueAction;
		private GetClassValueAction m_GetClassValueAction;
		private SetClassValueAction m_SetClassValueAction;
		[CompilerGenerated]
		private readonly string _Name_k__BackingField;
		[CompilerGenerated]
		private readonly bool _IsReadOnly_k__BackingField;
	
		// Properties
		public override string Name { [CompilerGenerated] get; }
		public override bool IsReadOnly { [CompilerGenerated] get; }
	
		// Nested types
		private delegate TValue GetStructValueAction(ref ref TContainer container); // TypeDefIndex: 14463; 0x00000000-0x00000000
	
		private delegate void SetStructValueAction(ref ref TContainer container, TValue value); // TypeDefIndex: 14464; 0x00000000-0x00000000
	
		private delegate TValue GetClassValueAction(TContainer container); // TypeDefIndex: 14465; 0x00000000-0x00000000
	
		private delegate void SetClassValueAction(TContainer container, TValue value); // TypeDefIndex: 14466; 0x00000000-0x00000000
	
		// Constructors
		internal ReflectedMemberProperty(IMemberInfo info, string name);
	
		// Methods
		public override TValue GetValue(ref ref TContainer container);
		public override void SetValue(ref ref TContainer container, TValue value);
	}
}
