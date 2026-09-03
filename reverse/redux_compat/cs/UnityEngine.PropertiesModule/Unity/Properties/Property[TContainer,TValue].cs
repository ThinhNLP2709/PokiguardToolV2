/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties.Internal;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public abstract class Property<TContainer, TValue> : IProperty<TContainer>, IAttributes // TypeDefIndex: 14454
	{
		// Fields
		private List<Attribute> m_Attributes;
	
		// Properties
		List<Attribute> IAttributes.Attributes { get; set; }
		public abstract string Name { get; }
		public abstract bool IsReadOnly { get; }
	
		// Constructors
		protected Property();
	
		// Methods
		public Type DeclaredValueType();
		public void Accept(IPropertyVisitor visitor, ref ref TContainer container);
		public abstract TValue GetValue(ref ref TContainer container);
		public abstract void SetValue(ref ref TContainer container, TValue value);
		protected void AddAttribute(Attribute attribute);
		protected void AddAttributes(IEnumerable<Attribute> attributes);
		void IAttributes.AddAttribute(Attribute attribute);
		void IAttributes.AddAttributes(IEnumerable<Attribute> attributes);
		public bool HasAttribute<TAttribute>()
			where TAttribute : Attribute;
		public TAttribute GetAttribute<TAttribute>()
			where TAttribute : Attribute;
		AttributesScope IAttributes.CreateAttributesScope(IAttributes attributes);
	}
}
