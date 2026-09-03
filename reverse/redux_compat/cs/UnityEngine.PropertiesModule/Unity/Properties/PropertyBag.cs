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
	public static class PropertyBag // TypeDefIndex: 14494
	{
		// Methods
		public static void AcceptWithSpecializedVisitor<TContainer>(IPropertyBag<TContainer> properties, IPropertyBagVisitor visitor, ref ref TContainer container);
		public static void Register<TContainer>(PropertyBag<TContainer> propertyBag);
		public static IPropertyBag GetPropertyBag(Type type); // 0x00000001822DCD70-0x00000001822DCDC0
		public static IPropertyBag<TContainer> GetPropertyBag<TContainer>();
		public static bool TryGetPropertyBagForValue<TValue>(ref ref TValue value, out IPropertyBag propertyBag);
	}
}
