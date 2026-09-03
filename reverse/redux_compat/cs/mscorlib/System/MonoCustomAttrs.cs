/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal static class MonoCustomAttrs // TypeDefIndex: 2472
	{
		// Fields
		private static Assembly corlib; // 0x00
		[ThreadStatic]
		private static Dictionary<Type, AttributeUsageAttribute> usage_cache; // 0x80000000
		private static readonly AttributeUsageAttribute DefaultAttributeUsage; // 0x08
	
		// Nested types
		private class AttributeInfo // TypeDefIndex: 2473
		{
			// Fields
			private AttributeUsageAttribute _usage; // 0x10
			private int _inheritanceLevel; // 0x18
	
			// Properties
			public AttributeUsageAttribute Usage { get; } // 0x0000000180377550-0x0000000180377560 
			public int InheritanceLevel { get; } // 0x0000000180B23260-0x0000000180B23270 
	
			// Constructors
			public AttributeInfo(AttributeUsageAttribute usage, int inheritanceLevel); // 0x000000018164BDC0-0x000000018164BDF0
		}
	
		// Constructors
		static MonoCustomAttrs(); // 0x00000001816566E0-0x0000000181656760
	
		// Methods
		private static bool IsUserCattrProvider(object obj); // 0x00000001816561D0-0x0000000181656390
		internal static Attribute[] GetCustomAttributesInternal(ICustomAttributeProvider obj, Type attributeType, bool pseudoAttrs); // 0x00000001816549F0-0x0000000181654A00
		internal static object[] GetPseudoCustomAttributes(ICustomAttributeProvider obj, Type attributeType); // 0x0000000181655BF0-0x0000000181655ED0
		private static object[] GetPseudoCustomAttributes(Type type); // 0x0000000181655A60-0x0000000181655BF0
		internal static object[] GetCustomAttributesBase(ICustomAttributeProvider obj, Type attributeType, bool inheritedOnly); // 0x00000001816537E0-0x00000001816539A0
		internal static object[] GetCustomAttributes(ICustomAttributeProvider obj, Type attributeType, bool inherit); // 0x0000000181654A00-0x0000000181655410
		internal static object[] GetCustomAttributes(ICustomAttributeProvider obj, bool inherit); // 0x0000000181655410-0x0000000181655580
		private static CustomAttributeData[] GetCustomAttributesDataInternal(ICustomAttributeProvider obj); // 0x0000000181653B20-0x0000000181653B30
		internal static IList<CustomAttributeData> GetCustomAttributesData(ICustomAttributeProvider obj, bool inherit = false /* Metadata: 0x0064E6FE */); // 0x00000001816548D0-0x00000001816549F0
		internal static IList<CustomAttributeData> GetCustomAttributesData(ICustomAttributeProvider obj, Type attributeType, bool inherit); // 0x0000000181653B30-0x00000001816548D0
		internal static IList<CustomAttributeData> GetCustomAttributesDataBase(ICustomAttributeProvider obj, Type attributeType, bool inheritedOnly); // 0x00000001816539A0-0x0000000181653B20
		internal static CustomAttributeData[] GetPseudoCustomAttributesData(ICustomAttributeProvider obj, Type attributeType); // 0x0000000181655580-0x0000000181655820
		private static CustomAttributeData[] GetPseudoCustomAttributesData(Type type); // 0x0000000181655820-0x0000000181655A60
		internal static bool IsDefined(ICustomAttributeProvider obj, Type attributeType, bool inherit); // 0x0000000181655EE0-0x00000001816561D0
		internal static bool IsDefinedInternal(ICustomAttributeProvider obj, Type AttributeType); // 0x0000000181655ED0-0x0000000181655EE0
		private static PropertyInfo GetBasePropertyDefinition(RuntimePropertyInfo property); // 0x0000000181653000-0x0000000181653370
		private static EventInfo GetBaseEventDefinition(RuntimeEventInfo evt); // 0x0000000181652DC0-0x0000000181653000
		private static ICustomAttributeProvider GetBase(ICustomAttributeProvider obj); // 0x0000000181653370-0x00000001816537E0
		private static AttributeUsageAttribute RetrieveAttributeUsageNoCache(Type attributeType); // 0x0000000181656390-0x0000000181656590
		private static AttributeUsageAttribute RetrieveAttributeUsage(Type attributeType); // 0x0000000181656590-0x00000001816566E0
	}
}
