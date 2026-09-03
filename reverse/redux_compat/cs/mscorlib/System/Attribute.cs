/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter | AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public abstract class Attribute // TypeDefIndex: 2411
	{
		// Properties
		public virtual object TypeId { get; } // 0x00000001816240F0-0x0000000181624100 
	
		// Constructors
		protected Attribute(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static Attribute[] InternalGetCustomAttributes(PropertyInfo element, Type type, bool inherit); // 0x000000018162D420-0x000000018162D4D0
		private static Attribute[] InternalGetCustomAttributes(EventInfo element, Type type, bool inherit); // 0x000000018162D370-0x000000018162D420
		private static Attribute[] InternalParamGetCustomAttributes(ParameterInfo parameter, Type attributeType, bool inherit); // 0x000000018162D5B0-0x000000018162DA50
		private static bool InternalIsDefined(PropertyInfo element, Type attributeType, bool inherit); // 0x000000018162D540-0x000000018162D5B0
		private static bool InternalIsDefined(EventInfo element, Type attributeType, bool inherit); // 0x000000018162D4D0-0x000000018162D540
		public static Attribute[] GetCustomAttributes(MemberInfo element, Type type); // 0x000000018162C520-0x000000018162C530
		public static Attribute[] GetCustomAttributes(MemberInfo element, Type type, bool inherit); // 0x000000018162C890-0x000000018162CB70
		public static Attribute[] GetCustomAttributes(MemberInfo element); // 0x000000018162C230-0x000000018162C240
		public static Attribute[] GetCustomAttributes(MemberInfo element, bool inherit); // 0x000000018162CFE0-0x000000018162D1F0
		public static bool IsDefined(MemberInfo element, Type attributeType); // 0x000000018162DA50-0x000000018162DA60
		public static bool IsDefined(MemberInfo element, Type attributeType, bool inherit); // 0x000000018162DA60-0x000000018162DD50
		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType); // 0x000000018162BF90-0x000000018162C040
		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType, bool inherit); // 0x000000018162BEE0-0x000000018162BF90
		public static Attribute[] GetCustomAttributes(ParameterInfo element, Type attributeType, bool inherit); // 0x000000018162C240-0x000000018162C520
		public static Attribute[] GetCustomAttributes(ParameterInfo element, bool inherit); // 0x000000018162C040-0x000000018162C220
		public static Attribute[] GetCustomAttributes(Module element, bool inherit); // 0x000000018162C760-0x000000018162C890
		public static Attribute[] GetCustomAttributes(Module element, Type attributeType, bool inherit); // 0x000000018162CB70-0x000000018162CDB0
		public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType); // 0x000000018162C220-0x000000018162C230
		public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType, bool inherit); // 0x000000018162C530-0x000000018162C760
		public static Attribute[] GetCustomAttributes(Assembly element); // 0x000000018162CED0-0x000000018162CFE0
		public static Attribute[] GetCustomAttributes(Assembly element, bool inherit); // 0x000000018162CDB0-0x000000018162CED0
		public static Attribute GetCustomAttribute(Assembly element, Type attributeType); // 0x000000018162BE30-0x000000018162BEE0
		public static Attribute GetCustomAttribute(Assembly element, Type attributeType, bool inherit); // 0x000000018162BD80-0x000000018162BE30
		public override bool Equals(object obj); // 0x000000018162BB20-0x000000018162BD80
		private static bool AreFieldValuesEqual(object thisValue, object thatValue); // 0x000000018162B980-0x000000018162BB20
		public override int GetHashCode(); // 0x000000018162D1F0-0x000000018162D370
		public virtual bool Match(object obj); // 0x000000018162DD50-0x000000018162DD70
		public virtual bool IsDefaultAttribute(); // 0x00000001802E7840-0x00000001802E7850
	}
}
