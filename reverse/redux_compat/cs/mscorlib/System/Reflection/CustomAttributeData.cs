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
	[ComVisible(true)]
	public class CustomAttributeData // TypeDefIndex: 3343
	{
		// Fields
		private ConstructorInfo ctorInfo; // 0x10
		private IList<CustomAttributeTypedArgument> ctorArgs; // 0x18
		private IList<CustomAttributeNamedArgument> namedArgs; // 0x20
		private LazyCAttrData lazyData; // 0x28
	
		// Properties
		[ComVisible(true)]
		public virtual ConstructorInfo Constructor { get; } // 0x0000000180377550-0x0000000180377560 
		[ComVisible(true)]
		public virtual IList<CustomAttributeTypedArgument> ConstructorArguments { get; } // 0x0000000181526470-0x0000000181526490 
		public virtual IList<CustomAttributeNamedArgument> NamedArguments { get; } // 0x0000000181526490-0x00000001815264B0 
		public Type AttributeType { get; } // 0x00000001815019E0-0x0000000181501A10 
	
		// Nested types
		private class LazyCAttrData // TypeDefIndex: 3344
		{
			// Fields
			internal Assembly assembly; // 0x10
			internal IntPtr data; // 0x18
			internal uint data_length; // 0x20
	
			// Constructors
			public LazyCAttrData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		protected CustomAttributeData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal CustomAttributeData(ConstructorInfo ctorInfo, Assembly assembly, IntPtr data, uint data_length); // 0x0000000181526290-0x0000000181526360
		internal CustomAttributeData(ConstructorInfo ctorInfo); // 0x0000000181526360-0x0000000181526470
		internal CustomAttributeData(ConstructorInfo ctorInfo, IList<CustomAttributeTypedArgument> ctorArgs, IList<CustomAttributeNamedArgument> namedArgs); // 0x00000001803A7D10-0x00000001803A7D80
	
		// Methods
		private static void ResolveArgumentsInternal(ConstructorInfo ctor, Assembly assembly, IntPtr data, uint data_length, out object[] ctorArgs, out object[] namedArgs); // 0x0000000181525AA0-0x0000000181525AB0
		private void ResolveArguments(); // 0x0000000181525AB0-0x0000000181525C70
		public static IList<CustomAttributeData> GetCustomAttributes(Assembly target); // 0x0000000181525650-0x00000001815256A0
		public static IList<CustomAttributeData> GetCustomAttributes(MemberInfo target); // 0x0000000181525600-0x0000000181525650
		internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeType target); // 0x0000000181525510-0x0000000181525560
		public static IList<CustomAttributeData> GetCustomAttributes(Module target); // 0x0000000181525560-0x00000001815255B0
		public static IList<CustomAttributeData> GetCustomAttributes(ParameterInfo target); // 0x00000001815255B0-0x0000000181525600
		public override string ToString(); // 0x0000000181525C70-0x0000000181526290
		private static T[] UnboxValues<T>(object[] values);
		public override bool Equals(object obj); // 0x0000000181524FE0-0x0000000181525510
		public override int GetHashCode(); // 0x00000001815256A0-0x0000000181525AA0
	}
}
