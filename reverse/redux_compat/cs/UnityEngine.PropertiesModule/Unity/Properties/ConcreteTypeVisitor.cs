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
	public abstract class ConcreteTypeVisitor : IPropertyBagVisitor // TypeDefIndex: 14502
	{
		// Constructors
		protected ConcreteTypeVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected abstract void VisitContainer<TContainer>(ref ref TContainer container);
		void IPropertyBagVisitor.Visit<TContainer>(IPropertyBag<TContainer> properties, ref ref TContainer container);
	}
}
