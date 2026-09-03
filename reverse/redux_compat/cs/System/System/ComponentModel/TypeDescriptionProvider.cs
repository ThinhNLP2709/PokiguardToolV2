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
	public abstract class TypeDescriptionProvider // TypeDefIndex: 8885
	{
		// Fields
		private readonly TypeDescriptionProvider _parent; // 0x10
		private EmptyCustomTypeDescriptor _emptyDescriptor; // 0x18
	
		// Nested types
		private sealed class EmptyCustomTypeDescriptor : CustomTypeDescriptor // TypeDefIndex: 8886
		{
			// Constructors
			public EmptyCustomTypeDescriptor(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		protected TypeDescriptionProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args); // 0x0000000181BBFF40-0x0000000181BC0010
		public virtual IDictionary GetCache(object instance); // 0x0000000181BC0010-0x0000000181BC0030
		public virtual ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance); // 0x0000000181BC0030-0x0000000181BC00E0
		protected internal virtual IExtenderProvider[] GetExtenderProviders(object instance); // 0x0000000181BC00E0-0x0000000181BC01E0
		public Type GetReflectionType(Type objectType); // 0x0000000181694F60-0x0000000181694F80
		public virtual Type GetReflectionType(Type objectType, object instance); // 0x0000000181BC01E0-0x0000000181BC0210
		public ICustomTypeDescriptor GetTypeDescriptor(Type objectType); // 0x0000000181429E80-0x0000000181429EA0
		public ICustomTypeDescriptor GetTypeDescriptor(object instance); // 0x0000000181BC02D0-0x0000000181BC0360
		public virtual ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance); // 0x0000000181BC0210-0x0000000181BC02D0
	}
}
