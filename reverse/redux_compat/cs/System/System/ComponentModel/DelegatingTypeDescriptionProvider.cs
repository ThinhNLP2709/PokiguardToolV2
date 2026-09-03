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
	internal sealed class DelegatingTypeDescriptionProvider : TypeDescriptionProvider // TypeDefIndex: 8842
	{
		// Fields
		private readonly Type _type; // 0x20
	
		// Properties
		internal TypeDescriptionProvider Provider { get; } // 0x0000000181BA71B0-0x0000000181BA7200 
	
		// Constructors
		internal DelegatingTypeDescriptionProvider(Type type); // 0x00000001806CFC00-0x00000001806CFC40
	
		// Methods
		public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args); // 0x0000000181BA6E60-0x0000000181BA6F10
		public override IDictionary GetCache(object instance); // 0x0000000181BA6F10-0x0000000181BA6F90
		public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance); // 0x0000000181BA6F90-0x0000000181BA7010
		protected internal override IExtenderProvider[] GetExtenderProviders(object instance); // 0x0000000181BA7010-0x0000000181BA7090
		public override Type GetReflectionType(Type objectType, object instance); // 0x0000000181BA7090-0x0000000181BA7120
		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance); // 0x0000000181BA7120-0x0000000181BA71B0
	}
}
