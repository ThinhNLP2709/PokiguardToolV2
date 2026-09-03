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
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	internal sealed class RuntimeEventInfo : EventInfo, ISerializable // TypeDefIndex: 3349
	{
		// Fields
		private IntPtr klass; // 0x18
		private IntPtr handle; // 0x20
	
		// Properties
		public override Module Module { get; } // 0x0000000181536200-0x0000000181536270 
		internal BindingFlags BindingFlags { get; } // 0x0000000181535CF0-0x0000000181535E70 
		private RuntimeType ReflectedTypeInternal { get; } // 0x0000000181535C10-0x0000000181535C70 
		public override Type DeclaringType { get; } // 0x0000000181536380-0x00000001815363B0 
		public override Type ReflectedType { get; } // 0x00000001815363E0-0x0000000181536410 
		public override string Name { get; } // 0x00000001815363B0-0x00000001815363E0 
		public override int MetadataToken { get; } // 0x0000000181535BF0-0x0000000181535C00 
	
		// Constructors
		public RuntimeEventInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static void get_event_info(RuntimeEventInfo ev, out MonoEventInfo info); // 0x0000000181536410-0x0000000181536420
		internal static MonoEventInfo GetEventInfo(RuntimeEventInfo ev); // 0x0000000181535FA0-0x0000000181535FE0
		internal RuntimeType GetDeclaringTypeInternal(); // 0x0000000181535F40-0x0000000181535FA0
		internal RuntimeModule GetRuntimeModule(); // 0x0000000181536200-0x0000000181536270
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181535FE0-0x0000000181536100
		internal BindingFlags GetBindingFlags(); // 0x0000000181535CF0-0x0000000181535E70
		public override MethodInfo GetAddMethod(bool nonPublic); // 0x0000000181535C70-0x0000000181535CF0
		public override MethodInfo GetRaiseMethod(bool nonPublic); // 0x0000000181536100-0x0000000181536180
		public override MethodInfo GetRemoveMethod(bool nonPublic); // 0x0000000181536180-0x0000000181536200
		public override string ToString(); // 0x00000001815362E0-0x0000000181536380
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181536270-0x00000001815362E0
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181535EE0-0x0000000181535F40
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181535E70-0x0000000181535EE0
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x0000000181525600-0x0000000181525650
		internal static int get_metadata_token(RuntimeEventInfo monoEvent); // 0x0000000181535BF0-0x0000000181535C00
	}
}
