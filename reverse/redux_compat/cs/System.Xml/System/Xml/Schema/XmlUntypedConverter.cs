/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class XmlUntypedConverter : XmlListConverter // TypeDefIndex: 7275
	{
		// Fields
		private bool allowListToList; // 0x30
		public static readonly XmlValueConverter Untyped; // 0x00
		public static readonly XmlValueConverter UntypedList; // 0x08
	
		// Constructors
		protected XmlUntypedConverter(); // 0x0000000181A12860-0x0000000181A12940
		protected XmlUntypedConverter(XmlUntypedConverter atomicConverter, bool allowListToList); // 0x0000000181A12760-0x0000000181A12860
		static XmlUntypedConverter(); // 0x0000000181A125D0-0x0000000181A12760
	
		// Methods
		public override bool ToBoolean(string value); // 0x0000000181A10810-0x0000000181A108B0
		public override bool ToBoolean(object value); // 0x0000000181A10660-0x0000000181A10810
		public override DateTime ToDateTime(string value); // 0x0000000181A10B20-0x0000000181A10BC0
		public override DateTime ToDateTime(object value); // 0x0000000181A10BC0-0x0000000181A10D50
		public override DateTimeOffset ToDateTimeOffset(string value); // 0x0000000181A10A60-0x0000000181A10B20
		public override DateTimeOffset ToDateTimeOffset(object value); // 0x0000000181A108B0-0x0000000181A10A60
		public override decimal ToDecimal(string value); // 0x0000000181A10D50-0x0000000181A10E10
		public override decimal ToDecimal(object value); // 0x0000000181A10E10-0x0000000181A10FE0
		public override double ToDouble(string value); // 0x0000000181A11190-0x0000000181A11230
		public override double ToDouble(object value); // 0x0000000181A10FE0-0x0000000181A11190
		public override int ToInt32(string value); // 0x0000000181A11230-0x0000000181A112D0
		public override int ToInt32(object value); // 0x0000000181A112D0-0x0000000181A11480
		public override long ToInt64(string value); // 0x0000000181A11630-0x0000000181A116D0
		public override long ToInt64(object value); // 0x0000000181A11480-0x0000000181A11630
		public override float ToSingle(string value); // 0x0000000181A11880-0x0000000181A11920
		public override float ToSingle(object value); // 0x0000000181A116D0-0x0000000181A11880
		public override string ToString(bool value); // 0x0000000181A12390-0x0000000181A123E0
		public override string ToString(DateTime value); // 0x0000000181A12520-0x0000000181A12570
		public override string ToString(DateTimeOffset value); // 0x0000000181A12570-0x0000000181A125D0
		public override string ToString(decimal value); // 0x0000000181A11920-0x0000000181A11980
		public override string ToString(double value); // 0x0000000181A123E0-0x0000000181A12430
		public override string ToString(int value); // 0x0000000181A124D0-0x0000000181A12520
		public override string ToString(long value); // 0x0000000181A12480-0x0000000181A124D0
		public override string ToString(float value); // 0x0000000181A12430-0x0000000181A12480
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A11980-0x0000000181A12390
		public override object ChangeType(bool value, Type destinationType); // 0x0000000181A0E560-0x0000000181A0E6E0
		public override object ChangeType(DateTime value, Type destinationType); // 0x0000000181A0EF40-0x0000000181A0F0B0
		public override object ChangeType(decimal value, Type destinationType); // 0x0000000181A0F230-0x0000000181A0F3D0
		public override object ChangeType(double value, Type destinationType); // 0x0000000181A0E3E0-0x0000000181A0E560
		public override object ChangeType(int value, Type destinationType); // 0x0000000181A0F0B0-0x0000000181A0F230
		public override object ChangeType(long value, Type destinationType); // 0x0000000181A0E260-0x0000000181A0E3E0
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0E6E0-0x0000000181A0EF40
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0F3D0-0x0000000181A10340
		private object ChangeTypeWildcardDestination(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0DFD0-0x0000000181A0E110
		private object ChangeTypeWildcardSource(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0E110-0x0000000181A0E260
		protected override object ChangeListType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0DCB0-0x0000000181A0DFD0
		private bool SupportsType(Type clrType); // 0x0000000181A10340-0x0000000181A10660
	}
}
