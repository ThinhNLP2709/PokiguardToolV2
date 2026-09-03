/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public abstract class ContainerPropertyBag<TContainer> : PropertyBag<TContainer>, INamedProperties<TContainer> // TypeDefIndex: 14468
	{
		// Fields
		private readonly List<IProperty<TContainer>> m_PropertiesList;
		private readonly Dictionary<string, IProperty<TContainer>> m_PropertiesHash;
	
		// Constructors
		static ContainerPropertyBag();
		protected ContainerPropertyBag();
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal ContainerPropertyBag(int initialCapacity);
	
		// Methods
		protected void AddProperty<TValue>(Property<TContainer, TValue> property);
		public override PropertyCollection<TContainer> GetProperties();
		public override PropertyCollection<TContainer> GetProperties(ref ref TContainer container);
		public bool TryGetProperty(ref ref TContainer container, string name, out IProperty<TContainer> property);
	}
}
