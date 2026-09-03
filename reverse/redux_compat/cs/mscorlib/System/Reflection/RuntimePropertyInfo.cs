/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Mono;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	internal class RuntimePropertyInfo : PropertyInfo, ISerializable // TypeDefIndex: 3359
	{
		// Fields
		internal IntPtr klass; // 0x10
		internal IntPtr prop; // 0x18
		private MonoPropertyInfo info; // 0x20
		private PInfo cached; // 0x50
		private GetterAdapter cached_getter; // 0x58
	
		// Properties
		internal BindingFlags BindingFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Module Module { get; } // 0x0000000181536200-0x0000000181536270 
		private RuntimeType ReflectedTypeInternal { get; } // 0x0000000181535C10-0x0000000181535C70 
		public override bool CanRead { get; } // 0x000000018153B9E0-0x000000018153BA10 
		public override bool CanWrite { get; } // 0x000000018153BA10-0x000000018153BA40 
		public override Type PropertyType { get; } // 0x000000018153BAC0-0x000000018153BB70 
		public override Type ReflectedType { get; } // 0x000000018153BB70-0x000000018153BBB0 
		public override Type DeclaringType { get; } // 0x000000018153BA40-0x000000018153BA80 
		public override string Name { get; } // 0x000000018153BA80-0x000000018153BAC0 
		public override int MetadataToken { get; } // 0x0000000181535BF0-0x0000000181535C00 
	
		// Nested types
		private delegate object GetterAdapter(object _this); // TypeDefIndex: 3360; 0x00000001804A78A0-0x00000001804A78B0
	
		private delegate R Getter<T, R>(T _this); // TypeDefIndex: 3361; 0x00000000-0x00000000
	
		private delegate R StaticGetter<R>(); // TypeDefIndex: 3362; 0x00000000-0x00000000
	
		// Constructors
		public RuntimePropertyInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal static void get_property_info(RuntimePropertyInfo prop, ref MonoPropertyInfo info, PInfo req_info); // 0x000000018153BBB0-0x000000018153BBC0
		internal RuntimeType GetDeclaringTypeInternal(); // 0x0000000181535F40-0x0000000181535FA0
		internal RuntimeModule GetRuntimeModule(); // 0x0000000181536200-0x0000000181536270
		public override string ToString(); // 0x000000018153B9D0-0x000000018153B9E0
		private string FormatNameAndSig(bool serialization); // 0x000000018153AB90-0x000000018153AE70
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018153B2F0-0x000000018153B450
		internal string SerializationToString(); // 0x000000018153B780-0x000000018153B790
		private void CachePropertyInfo(PInfo flags); // 0x000000018153AB50-0x000000018153AB90
		public override MethodInfo GetGetMethod(bool nonPublic); // 0x000000018153AF20-0x000000018153AF90
		public override ParameterInfo[] GetIndexParameters(); // 0x000000018153AF90-0x000000018153B2F0
		public override MethodInfo GetSetMethod(bool nonPublic); // 0x000000018153B500-0x000000018153B570
		public override bool IsDefined(Type attributeType, bool inherit); // 0x000000018153B720-0x000000018153B780
		public override object[] GetCustomAttributes(bool inherit); // 0x000000018153AE70-0x000000018153AEC0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018153AEC0-0x000000018153AF20
		private static object GetterAdapterFrame<T, R>(Getter<T, R> getter, object obj);
		private static object StaticGetterAdapterFrame<R>(StaticGetter<R> getter, object obj);
		public override object GetValue(object obj, object[] index); // 0x0000000181534010-0x0000000181534050
		public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture); // 0x000000018153B570-0x000000018153B720
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture); // 0x000000018153B790-0x000000018153B9D0
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x0000000181525600-0x0000000181525650
		internal static int get_metadata_token(RuntimePropertyInfo monoProperty); // 0x0000000181535BF0-0x0000000181535C00
		private static PropertyInfo internal_from_handle_type(IntPtr event_handle, IntPtr type_handle); // 0x000000018153BBC0-0x000000018153BBD0
		internal static PropertyInfo GetPropertyFromHandle(RuntimePropertyHandle handle, RuntimeTypeHandle reflectedType); // 0x000000018153B450-0x000000018153B500
	}
}
