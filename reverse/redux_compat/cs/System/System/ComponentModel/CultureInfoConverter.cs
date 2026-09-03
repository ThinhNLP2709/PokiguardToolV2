/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public class CultureInfoConverter : TypeConverter // TypeDefIndex: 8834
	{
		// Fields
		private StandardValuesCollection _values; // 0x10
		private const string DefaultInvariantCultureString = "(Default)"; // Metadata: 0x0069E136
	
		// Properties
		private string DefaultCultureString { get; } // 0x0000000181B8BD60-0x0000000181B8BD90 
	
		// Nested types
		private class CultureComparer : IComparer // TypeDefIndex: 8835
		{
			// Fields
			private CultureInfoConverter _converter; // 0x10
	
			// Constructors
			public CultureComparer(CultureInfoConverter cultureConverter); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public int Compare(object item1, object item2); // 0x0000000181B8AD90-0x0000000181B8AF30
		}
	
		private static class CultureInfoMapper // TypeDefIndex: 8836
		{
			// Fields
			private static readonly Dictionary<string, string> s_cultureInfoNameMap; // 0x00
	
			// Constructors
			static CultureInfoMapper(); // 0x0000000181B8F770-0x0000000181B8F7D0
	
			// Methods
			private static Dictionary<string, string> CreateMap(); // 0x0000000181B8BD90-0x0000000181B8F6D0
			public static string GetCultureInfoName(string cultureInfoDisplayName); // 0x0000000181B8F6D0-0x0000000181B8F770
		}
	
		// Constructors
		public CultureInfoConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		protected virtual string GetCultureName(CultureInfo culture); // 0x0000000181B8BB50-0x0000000181B8BB80
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181B8AF30-0x0000000181B8AFB0
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x000000018189D6C0-0x000000018189D740
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181B8AFB0-0x0000000181B8B700
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181B8B700-0x0000000181B8BB50
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181B8BB80-0x0000000181B8BD60
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x00000001802E7840-0x00000001802E7850
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
