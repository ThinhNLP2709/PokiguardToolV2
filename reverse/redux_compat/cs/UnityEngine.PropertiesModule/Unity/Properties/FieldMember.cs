/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	internal struct FieldMember : IMemberInfo // TypeDefIndex: 14460
	{
		// Fields
		internal readonly FieldInfo m_FieldInfo; // 0x00
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x08
	
		// Properties
		public string Name { [CompilerGenerated] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public bool IsReadOnly { get; } // 0x00000001822DA7F0-0x00000001822DA810 
		public Type ValueType { get; } // 0x00000001822DA810-0x00000001822DA840 
	
		// Constructors
		public FieldMember(FieldInfo fieldInfo); // 0x00000001822DA7C0-0x00000001822DA7F0
	
		// Methods
		public object GetValue(object obj); // 0x00000001822DA770-0x00000001822DA7A0
		public void SetValue(object obj, object value); // 0x00000001822DA7A0-0x00000001822DA7C0
		public IEnumerable<Attribute> GetCustomAttributes(); // 0x00000001822DA760-0x00000001822DA770
	}
}
