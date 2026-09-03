/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public abstract class CustomTypeDescriptor : ICustomTypeDescriptor // TypeDefIndex: 8837
	{
		// Fields
		private readonly ICustomTypeDescriptor _parent; // 0x10
	
		// Constructors
		protected CustomTypeDescriptor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual AttributeCollection GetAttributes(); // 0x0000000181BA4820-0x0000000181BA4920
		public virtual string GetClassName(); // 0x0000000181BA4920-0x0000000181BA4970
		public virtual string GetComponentName(); // 0x0000000181BA4970-0x0000000181BA49C0
		public virtual TypeConverter GetConverter(); // 0x0000000181BA49C0-0x0000000181BA4AC0
		public virtual EventDescriptor GetDefaultEvent(); // 0x0000000181BA4AC0-0x0000000181BA4B80
		public virtual PropertyDescriptor GetDefaultProperty(); // 0x0000000181BA4B80-0x0000000181BA4C40
		public virtual object GetEditor(Type editorBaseType); // 0x0000000181BA4C40-0x0000000181BA4CA0
		public virtual EventDescriptorCollection GetEvents(); // 0x0000000181BA4CA0-0x0000000181BA4DA0
		public virtual EventDescriptorCollection GetEvents(Attribute[] attributes); // 0x0000000181BA4DA0-0x0000000181BA4EB0
		public virtual PropertyDescriptorCollection GetProperties(); // 0x0000000181BA4FC0-0x0000000181BA50C0
		public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes); // 0x0000000181BA4EB0-0x0000000181BA4FC0
		public virtual object GetPropertyOwner(PropertyDescriptor pd); // 0x0000000181BA50C0-0x0000000181BA5120
	}
}
