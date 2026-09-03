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

namespace System.Reflection
{
	[Serializable]
	public abstract class MemberInfo : ICustomAttributeProvider // TypeDefIndex: 3303
	{
		// Properties
		public abstract MemberTypes MemberType { get; }
		public abstract string Name { get; }
		public abstract Type DeclaringType { get; }
		public abstract Type ReflectedType { get; }
		public virtual Module Module { get; } // 0x000000018152BF70-0x000000018152C030 
		public virtual int MetadataToken { get; } // 0x000000018152BF30-0x000000018152BF70 
	
		// Constructors
		protected MemberInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract bool IsDefined(Type attributeType, bool inherit);
		public abstract object[] GetCustomAttributes(bool inherit);
		public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);
		public virtual IList<CustomAttributeData> GetCustomAttributesData(); // 0x000000018152BF00-0x000000018152BF30
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(MemberInfo left, MemberInfo right); // 0x000000018152C030-0x000000018152C350
		public static bool operator !=(MemberInfo left, MemberInfo right); // 0x000000018152C350-0x000000018152C370
	}
}
