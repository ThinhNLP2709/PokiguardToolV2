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
	public abstract class PathVisitor : IPropertyBagVisitor, IPropertyVisitor // TypeDefIndex: 14517
	{
		// Fields
		private int m_PathIndex; // 0x10
		[CompilerGenerated]
		private PropertyPath _Path_k__BackingField; // 0x18
		[CompilerGenerated]
		private IProperty _Property_k__BackingField; // 0xA8
		[CompilerGenerated]
		private bool _ReadonlyVisit_k__BackingField; // 0xB0
		[CompilerGenerated]
		private VisitReturnCode _ReturnCode_k__BackingField; // 0xB4
	
		// Properties
		public PropertyPath Path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018112E750-0x000000018112E7B0 0x00000001822DB0E0-0x00000001822DB140
		private IProperty Property { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public bool ReadonlyVisit { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001807186D0-0x00000001807186E0 0x0000000180718740-0x0000000180718750
		public VisitReturnCode ReturnCode { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018158AD40-0x000000018158AD50 0x0000000181C4C370-0x0000000181C4C380
	
		// Nested types
		[IsReadOnly]
		private struct PropertyScope : IDisposable // TypeDefIndex: 14518
		{
			// Fields
			private readonly PathVisitor m_Visitor; // 0x00
			private readonly IProperty m_Property; // 0x08
	
			// Constructors
			public PropertyScope(PathVisitor visitor, IProperty property); // 0x00000001822E19A0-0x00000001822E1A10
	
			// Methods
			public void Dispose(); // 0x00000001822E1970-0x00000001822E19A0
		}
	
		// Constructors
		protected PathVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Reset(); // 0x00000001822DB080-0x00000001822DB0E0
		void IPropertyBagVisitor.Visit<TContainer>(IPropertyBag<TContainer> properties, ref ref TContainer container);
		void IPropertyVisitor.Visit<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container);
		protected virtual void VisitPath<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container, ref ref TValue value);
	}
}
