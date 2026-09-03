/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	internal sealed class ReflectTypeDescriptionProvider : TypeDescriptionProvider // TypeDefIndex: 8909
	{
		// Fields
		private Hashtable _typeData; // 0x20
		private static Type[] _typeConstructor; // 0x00
		private static Hashtable _editorTables; // 0x08
		private static Hashtable _intrinsicTypeConverters; // 0x10
		private static object _intrinsicReferenceKey; // 0x18
		private static object _intrinsicNullableKey; // 0x20
		private static object _dictionaryKey; // 0x28
		private static Hashtable _propertyCache; // 0x30
		private static Hashtable _eventCache; // 0x38
		private static Hashtable _attributeCache; // 0x40
		private static Hashtable _extendedPropertyCache; // 0x48
		private static readonly Guid _extenderProviderKey; // 0x50
		private static readonly Guid _extenderPropertiesKey; // 0x60
		private static readonly Guid _extenderProviderPropertiesKey; // 0x70
		private static readonly Type[] _skipInterfaceAttributeList; // 0x80
		private static object _internalSyncObject; // 0x88
	
		// Properties
		private static Hashtable IntrinsicTypeConverters { get; } // 0x0000000181BBCAA0-0x0000000181BBD1C0 
	
		// Nested types
		private class ReflectedTypeData // TypeDefIndex: 8910
		{
			// Fields
			private Type _type; // 0x10
			private AttributeCollection _attributes; // 0x18
			private EventDescriptorCollection _events; // 0x20
			private PropertyDescriptorCollection _properties; // 0x28
			private TypeConverter _converter; // 0x30
			private object[] _editors; // 0x38
			private Type[] _editorTypes; // 0x40
			private int _editorCount; // 0x48
	
			// Properties
			internal bool IsPopulated { get; } // 0x0000000181BBF170-0x0000000181BBF1A0 
	
			// Constructors
			internal ReflectedTypeData(Type type); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			internal AttributeCollection GetAttributes(); // 0x0000000181BBD1C0-0x0000000181BBD6D0
			internal string GetClassName(object instance); // 0x00000001818C15C0-0x00000001818C15F0
			internal string GetComponentName(object instance); // 0x0000000181BBD6D0-0x0000000181BBD790
			internal TypeConverter GetConverter(object instance); // 0x0000000181BBD790-0x0000000181BBDD00
			internal EventDescriptor GetDefaultEvent(object instance); // 0x0000000181BBDD00-0x0000000181BBDE60
			internal PropertyDescriptor GetDefaultProperty(object instance); // 0x0000000181BBDE60-0x0000000181BBDFC0
			internal object GetEditor(object instance, Type editorBaseType); // 0x0000000181BBE220-0x0000000181BBE8E0
			private static EditorAttribute GetEditorAttribute(AttributeCollection attributes, Type editorBaseType); // 0x0000000181BBDFC0-0x0000000181BBE220
			internal EventDescriptorCollection GetEvents(); // 0x0000000181BBE8E0-0x0000000181BBEC30
			internal PropertyDescriptorCollection GetProperties(); // 0x0000000181BBEC30-0x0000000181BBEFA0
			private Type GetTypeFromName(string typeName); // 0x0000000181BBEFA0-0x0000000181BBF0F0
			internal void Refresh(); // 0x0000000181BBF0F0-0x0000000181BBF170
		}
	
		// Constructors
		internal ReflectTypeDescriptionProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ReflectTypeDescriptionProvider(); // 0x0000000181BBC6D0-0x0000000181BBCAA0
	
		// Methods
		public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args); // 0x0000000181BB7490-0x0000000181BB76A0
		private static object CreateInstance(Type objectType, Type callingType); // 0x0000000181BB7380-0x0000000181BB7490
		internal AttributeCollection GetAttributes(Type type); // 0x0000000181BB76A0-0x0000000181BB76D0
		public override IDictionary GetCache(object instance); // 0x0000000181BB76D0-0x0000000181BB78A0
		internal string GetClassName(Type type); // 0x0000000181BB78A0-0x0000000181BB78E0
		internal string GetComponentName(Type type, object instance); // 0x0000000181BB78E0-0x0000000181BB79B0
		internal TypeConverter GetConverter(Type type, object instance); // 0x0000000181BB79B0-0x0000000181BB79F0
		internal EventDescriptor GetDefaultEvent(Type type, object instance); // 0x0000000181BB79F0-0x0000000181BB7B60
		internal PropertyDescriptor GetDefaultProperty(Type type, object instance); // 0x0000000181BB7B60-0x0000000181BB7CD0
		internal object GetEditor(Type type, object instance, Type editorBaseType); // 0x0000000181BB8110-0x0000000181BB8160
		private static Hashtable GetEditorTable(Type editorBaseType); // 0x0000000181BB7CD0-0x0000000181BB8110
		internal EventDescriptorCollection GetEvents(Type type); // 0x0000000181BB8160-0x0000000181BB8190
		internal AttributeCollection GetExtendedAttributes(object instance); // 0x0000000181BB8190-0x0000000181BB81E0
		internal string GetExtendedClassName(object instance); // 0x0000000181BB81E0-0x0000000181BB8240
		internal string GetExtendedComponentName(object instance); // 0x0000000181BB8240-0x0000000181BB8340
		internal TypeConverter GetExtendedConverter(object instance); // 0x0000000181BB8340-0x0000000181BB83A0
		internal EventDescriptor GetExtendedDefaultEvent(object instance); // 0x00000001802E7860-0x00000001802E7870
		internal PropertyDescriptor GetExtendedDefaultProperty(object instance); // 0x00000001802E7860-0x00000001802E7870
		internal object GetExtendedEditor(object instance, Type editorBaseType); // 0x0000000181BB83A0-0x0000000181BB8410
		internal EventDescriptorCollection GetExtendedEvents(object instance); // 0x0000000181BB8410-0x0000000181BB8460
		internal PropertyDescriptorCollection GetExtendedProperties(object instance); // 0x0000000181BB8460-0x0000000181BB89A0
		protected internal override IExtenderProvider[] GetExtenderProviders(object instance); // 0x0000000181BB8A10-0x0000000181BB8CC0
		private static IExtenderProvider[] GetExtenders(ICollection components, object instance, IDictionary cache); // 0x0000000181BB8CC0-0x0000000181BB9630
		internal object GetExtendedPropertyOwner(object instance, PropertyDescriptor pd); // 0x0000000181BB89A0-0x0000000181BB8A10
		public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance); // 0x00000001802E7860-0x00000001802E7870
		internal PropertyDescriptorCollection GetProperties(Type type); // 0x0000000181BB9630-0x0000000181BB9660
		internal object GetPropertyOwner(Type type, object instance, PropertyDescriptor pd); // 0x0000000181BB9660-0x0000000181BB96C0
		public override Type GetReflectionType(Type objectType, object instance); // 0x0000000180A68C50-0x0000000180A68C60
		private ReflectedTypeData GetTypeData(Type type, bool createIfNeeded); // 0x0000000181BB96C0-0x0000000181BB9990
		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance); // 0x00000001802E7860-0x00000001802E7870
		private static Type GetTypeFromName(string typeName); // 0x0000000181BB9990-0x0000000181BB9A50
		internal bool IsPopulated(Type type); // 0x0000000181BB9A50-0x0000000181BB9AA0
		private static Attribute[] ReflectGetAttributes(Type type); // 0x0000000181BB9AA0-0x0000000181BB9EE0
		internal static Attribute[] ReflectGetAttributes(MemberInfo member); // 0x0000000181BB9EE0-0x0000000181BBA320
		private static EventDescriptor[] ReflectGetEvents(Type type); // 0x0000000181BBA320-0x0000000181BBA9C0
		private static PropertyDescriptor[] ReflectGetExtendedProperties(IExtenderProvider provider); // 0x0000000181BBA9C0-0x0000000181BBB790
		private static PropertyDescriptor[] ReflectGetProperties(Type type); // 0x0000000181BBB790-0x0000000181BBBDB0
		internal void Refresh(Type type); // 0x0000000181BBBDB0-0x0000000181BBBE40
		private static object SearchIntrinsicTable(Hashtable table, Type callingType); // 0x0000000181BBBE40-0x0000000181BBC6D0
	}
}
