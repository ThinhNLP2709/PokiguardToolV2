/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel.Design
{
	public abstract class DesignerOptionService // TypeDefIndex: 8938
	{
		// Nested types
		[DefaultMember("Item")]
		[Editor("", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter(typeof(DesignerOptionConverter))]
		public sealed class DesignerOptionCollection : ICollection // TypeDefIndex: 8939
		{
			// Fields
			private DesignerOptionService _service; // 0x10
			private string _name; // 0x18
			private object _value; // 0x20
			private ArrayList _children; // 0x28
			private PropertyDescriptorCollection _properties; // 0x30
	
			// Properties
			public int Count { get; } // 0x0000000181BC8460-0x0000000181BC84A0 
			public string Name { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public PropertyDescriptorCollection Properties { get; } // 0x0000000181BC84A0-0x0000000181BC8BD0 
			bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
			object ICollection.SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
	
			// Nested types
			private sealed class WrappedPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 8940
			{
				// Fields
				private object target; // 0x88
				private PropertyDescriptor property; // 0x90
	
				// Properties
				public override AttributeCollection Attributes { get; } // 0x0000000181BDDEA0-0x0000000181BDDED0 
				public override Type ComponentType { get; } // 0x0000000181BDDED0-0x0000000181BDDF00 
				public override bool IsReadOnly { get; } // 0x0000000181BDDF00-0x0000000181BDDF30 
				public override Type PropertyType { get; } // 0x0000000181BDDF30-0x0000000181BDE730 
	
				// Constructors
				internal WrappedPropertyDescriptor(PropertyDescriptor property, object target); // 0x0000000181BDDE10-0x0000000181BDDEA0
	
				// Methods
				public override bool CanResetValue(object component); // 0x0000000181BDDCD0-0x0000000181BDDD10
				public override object GetValue(object component); // 0x0000000181BDDD10-0x0000000181BDDD50
				public override void ResetValue(object component); // 0x0000000181BDDD50-0x0000000181BDDD90
				public override void SetValue(object component, object value); // 0x0000000181BDDD90-0x0000000181BDDDD0
				public override bool ShouldSerializeValue(object component); // 0x0000000181BDDDD0-0x0000000181BDDE10
			}
	
			// Methods
			public void CopyTo(Array array, int index); // 0x0000000181BC8320-0x0000000181BC8380
			private void EnsurePopulated(); // 0x0000000181BC8380-0x0000000181BC8420
			public IEnumerator GetEnumerator(); // 0x0000000181BC8420-0x0000000181BC8460
		}
	
		internal sealed class DesignerOptionConverter : TypeConverter // TypeDefIndex: 8941
		{
			// Nested types
			private class OptionPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 8942
			{
				// Fields
				private DesignerOptionCollection _option; // 0x88
	
				// Properties
				public override Type ComponentType { get; } // 0x0000000181BD20C0-0x0000000181BD20E0 
				public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
				public override Type PropertyType { get; } // 0x0000000181BD20C0-0x0000000181BD20E0 
	
				// Constructors
				internal OptionPropertyDescriptor(DesignerOptionCollection option); // 0x0000000181BD2070-0x0000000181BD20C0
	
				// Methods
				public override bool CanResetValue(object component); // 0x00000001802E7840-0x00000001802E7850
				public override object GetValue(object component); // 0x000000018038B8A0-0x000000018038B8B0
				public override void ResetValue(object component); // 0x00000001802E76C0-0x00000001802E76D0
				public override void SetValue(object component, object value); // 0x00000001802E76C0-0x00000001802E76D0
				public override bool ShouldSerializeValue(object component); // 0x00000001802E7840-0x00000001802E7850
			}
	
			// Constructors
			public DesignerOptionConverter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override bool GetPropertiesSupported(ITypeDescriptorContext cxt); // 0x00000001802E7990-0x00000001802E79A0
			public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext cxt, object value, Attribute[] attributes); // 0x0000000181BC8CA0-0x0000000181BC91D0
			public override object ConvertTo(ITypeDescriptorContext cxt, CultureInfo culture, object value, Type destinationType); // 0x0000000181BC8BD0-0x0000000181BC8CA0
		}
	
		// Methods
		protected virtual void PopulateOptionCollection(DesignerOptionCollection options); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
