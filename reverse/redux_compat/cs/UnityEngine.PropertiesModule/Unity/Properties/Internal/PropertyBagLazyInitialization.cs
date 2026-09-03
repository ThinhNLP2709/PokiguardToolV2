/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties.Internal
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal static class PropertyBagLazyInitialization // TypeDefIndex: 14591
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly Dictionary<Type, Func<IPropertyBag>> s_LazyPropertyBagRegistrations; // 0x00
	
		// Constructors
		static PropertyBagLazyInitialization(); // 0x00000001822DC300-0x00000001822DC390
	
		// Methods
		public static void AddLazyRegistration(Type type, Func<IPropertyBag> registration); // 0x00000001822DC0E0-0x00000001822DC170
		public static bool HasLazyRegistration(Type type); // 0x00000001822DC170-0x00000001822DC1F0
		public static bool TryGetRegistrationDelegate(Type type, out Func<IPropertyBag> registrationDelegate); // 0x00000001822DC270-0x00000001822DC300
		public static void RemoveRegistration(Type type); // 0x00000001822DC1F0-0x00000001822DC270
	}
}
