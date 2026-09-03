/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties.Internal;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public abstract class PropertyBag<TContainer> : IPropertyBag<TContainer>, IPropertyBagRegister, IConstructor<TContainer> // TypeDefIndex: 14495
	{
		// Fields
		[CompilerGenerated]
		private readonly InstantiationKind _InstantiationKind_k__BackingField;
	
		// Properties
		InstantiationKind IConstructor.InstantiationKind { get; }
		protected virtual InstantiationKind InstantiationKind { [CompilerGenerated] get; }
	
		// Constructors
		static PropertyBag();
		protected PropertyBag();
	
		// Methods
		void IPropertyBagRegister.Register();
		public void Accept(ITypeVisitor visitor);
		void IPropertyBag.Accept(IPropertyBagVisitor visitor, ref object container);
		void IPropertyBag<TContainer>.Accept(IPropertyBagVisitor visitor, ref ref TContainer container);
		PropertyCollection<TContainer> IPropertyBag<TContainer>.GetProperties();
		PropertyCollection<TContainer> IPropertyBag<TContainer>.GetProperties(ref ref TContainer container);
		TContainer IConstructor<TContainer>.Instantiate();
		public abstract PropertyCollection<TContainer> GetProperties();
		public abstract PropertyCollection<TContainer> GetProperties(ref ref TContainer container);
		protected virtual TContainer Instantiate();
	}
}
