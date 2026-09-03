/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	[ComVisible(true)]
	public class TypeConverter // TypeDefIndex: 8911
	{
		// Fields
		private const string s_UseCompatibleTypeConverterBehavior = "UseCompatibleTypeConverterBehavior"; // Metadata: 0x0069E14A
		private static bool useCompatibleTypeConversion; // 0x00
	
		// Properties
		private static bool UseCompatibleTypeConversion { get; } // 0x0000000181BD5E60-0x0000000181BD5EB0 
	
		// Nested types
		protected abstract class SimplePropertyDescriptor : PropertyDescriptor // TypeDefIndex: 8912
		{
			// Fields
			private Type componentType; // 0x88
			private Type propertyType; // 0x90
	
			// Properties
			public override Type ComponentType { get; } // 0x000000018038B8A0-0x000000018038B8B0 
			public override bool IsReadOnly { get; } // 0x0000000181BD47D0-0x0000000181BD4850 
			public override Type PropertyType { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
			// Constructors
			protected SimplePropertyDescriptor(Type componentType, string name, Type propertyType); // 0x0000000181BD4730-0x0000000181BD47D0
			protected SimplePropertyDescriptor(Type componentType, string name, Type propertyType, Attribute[] attributes); // 0x0000000181BD46C0-0x0000000181BD4730
	
			// Methods
			public override bool CanResetValue(object component); // 0x0000000181BD4450-0x0000000181BD45A0
			public override void ResetValue(object component); // 0x0000000181BD45A0-0x0000000181BD46C0
			public override bool ShouldSerializeValue(object component); // 0x00000001802E7840-0x00000001802E7850
		}
	
		public class StandardValuesCollection : ICollection // TypeDefIndex: 8913
		{
			// Fields
			private ICollection values; // 0x10
			private Array valueArray; // 0x18
	
			// Properties
			public int Count { get; } // 0x0000000181BD4910-0x0000000181BD4980 
			public object this[int index] { get => default; } // 0x0000000181BD4A30-0x0000000181BD4B30 
			int ICollection.Count { get; } // 0x0000000181BD4910-0x0000000181BD4980 
			bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
			object ICollection.SyncRoot { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Constructors
			public StandardValuesCollection(ICollection values); // 0x0000000181BD4980-0x0000000181BD4A30
	
			// Methods
			public void CopyTo(Array array, int index); // 0x0000000181BD4850-0x0000000181BD48C0
			public IEnumerator GetEnumerator(); // 0x0000000181BD48C0-0x0000000181BD4910
			void ICollection.CopyTo(Array array, int index); // 0x0000000181BD4850-0x0000000181BD48C0
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181BD48C0-0x0000000181BD4910
		}
	
		// Constructors
		public TypeConverter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool CanConvertFrom(Type sourceType); // 0x0000000181BD4F80-0x0000000181BD4FA0
		public virtual bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181BD4F20-0x0000000181BD4F80
		public bool CanConvertTo(Type destinationType); // 0x0000000181BD4FA0-0x0000000181BD4FC0
		public virtual bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181BD4FC0-0x0000000181BD5010
		public object ConvertFrom(object value); // 0x0000000181BD5180-0x0000000181BD51E0
		public virtual object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BD51E0-0x0000000181BD5250
		public object ConvertFromInvariantString(string text); // 0x0000000181BD5010-0x0000000181BD5070
		public object ConvertFromInvariantString(ITypeDescriptorContext context, string text); // 0x0000000181BD5070-0x0000000181BD50E0
		public object ConvertFromString(string text); // 0x0000000181BD5150-0x0000000181BD5180
		public object ConvertFromString(ITypeDescriptorContext context, string text); // 0x0000000181BD50E0-0x0000000181BD5150
		public object ConvertFromString(ITypeDescriptorContext context, CultureInfo culture, string text); // 0x0000000181B59220-0x0000000181B59240
		public object ConvertTo(object value, Type destinationType); // 0x0000000181BD5550-0x0000000181BD5580
		public virtual object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BD5580-0x0000000181BD5770
		public string ConvertToInvariantString(object value); // 0x0000000181BD5250-0x0000000181BD52A0
		public string ConvertToInvariantString(ITypeDescriptorContext context, object value); // 0x0000000181BD52A0-0x0000000181BD5300
		public string ConvertToString(object value); // 0x0000000181BD5300-0x0000000181BD53C0
		public string ConvertToString(ITypeDescriptorContext context, object value); // 0x0000000181BD5480-0x0000000181BD5550
		public string ConvertToString(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BD53C0-0x0000000181BD5480
		public object CreateInstance(IDictionary propertyValues); // 0x0000000181BD5770-0x0000000181BD5790
		public virtual object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues); // 0x00000001802E7860-0x00000001802E7870
		protected Exception GetConvertFromException(object value); // 0x0000000181BD5790-0x0000000181BD58D0
		protected Exception GetConvertToException(object value, Type destinationType); // 0x0000000181BD58D0-0x0000000181BD5A60
		public bool GetCreateInstanceSupported(); // 0x0000000181BD5A60-0x0000000181BD5A80
		public virtual bool GetCreateInstanceSupported(ITypeDescriptorContext context); // 0x00000001802E7840-0x00000001802E7850
		public PropertyDescriptorCollection GetProperties(object value); // 0x0000000181BD5AA0-0x0000000181BD5BB0
		public PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value); // 0x0000000181BD5BB0-0x0000000181BD5CD0
		public virtual PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes); // 0x00000001802E7860-0x00000001802E7870
		public bool GetPropertiesSupported(); // 0x0000000181BD5A80-0x0000000181BD5AA0
		public virtual bool GetPropertiesSupported(ITypeDescriptorContext context); // 0x00000001802E7840-0x00000001802E7850
		public ICollection GetStandardValues(); // 0x0000000181BD5CF0-0x0000000181BD5D10
		public virtual StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x00000001802E7860-0x00000001802E7870
		public bool GetStandardValuesExclusive(); // 0x0000000181745D10-0x0000000181745D30
		public virtual bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x00000001802E7840-0x00000001802E7850
		public bool GetStandardValuesSupported(); // 0x0000000181BD5CD0-0x0000000181BD5CF0
		public virtual bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7840-0x00000001802E7850
		public bool IsValid(object value); // 0x0000000181BD5D10-0x0000000181BD5D30
		public virtual bool IsValid(ITypeDescriptorContext context, object value); // 0x0000000181BD5D30-0x0000000181BD5E20
		protected PropertyDescriptorCollection SortProperties(PropertyDescriptorCollection props, string[] names); // 0x0000000181BD5E20-0x0000000181BD5E60
	}
}
