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
	internal abstract class XmlBaseConverter : XmlValueConverter // TypeDefIndex: 7268
	{
		// Fields
		private XmlSchemaType schemaType; // 0x10
		private XmlTypeCode typeCode; // 0x18
		private Type clrTypeDefault; // 0x20
		protected static readonly Type ICollectionType; // 0x00
		protected static readonly Type IEnumerableType; // 0x08
		protected static readonly Type IListType; // 0x10
		protected static readonly Type ObjectArrayType; // 0x18
		protected static readonly Type StringArrayType; // 0x20
		protected static readonly Type XmlAtomicValueArrayType; // 0x28
		protected static readonly Type DecimalType; // 0x30
		protected static readonly Type Int32Type; // 0x38
		protected static readonly Type Int64Type; // 0x40
		protected static readonly Type StringType; // 0x48
		protected static readonly Type XmlAtomicValueType; // 0x50
		protected static readonly Type ObjectType; // 0x58
		protected static readonly Type ByteType; // 0x60
		protected static readonly Type Int16Type; // 0x68
		protected static readonly Type SByteType; // 0x70
		protected static readonly Type UInt16Type; // 0x78
		protected static readonly Type UInt32Type; // 0x80
		protected static readonly Type UInt64Type; // 0x88
		protected static readonly Type XPathItemType; // 0x90
		protected static readonly Type DoubleType; // 0x98
		protected static readonly Type SingleType; // 0xA0
		protected static readonly Type DateTimeType; // 0xA8
		protected static readonly Type DateTimeOffsetType; // 0xB0
		protected static readonly Type BooleanType; // 0xB8
		protected static readonly Type ByteArrayType; // 0xC0
		protected static readonly Type XmlQualifiedNameType; // 0xC8
		protected static readonly Type UriType; // 0xD0
		protected static readonly Type TimeSpanType; // 0xD8
		protected static readonly Type XPathNavigatorType; // 0xE0
	
		// Properties
		protected XmlSchemaType SchemaType { get; } // 0x0000000180377550-0x0000000180377560 
		protected XmlTypeCode TypeCode { get; } // 0x0000000180B23260-0x0000000180B23270 
		protected string XmlTypeName { get; } // 0x00000001819E76C0-0x00000001819E78D0 
		protected Type DefaultClrType { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		protected XmlBaseConverter(XmlSchemaType schemaType); // 0x00000001819E7450-0x00000001819E7650
		protected XmlBaseConverter(XmlTypeCode typeCode); // 0x00000001819E7360-0x00000001819E7450
		protected XmlBaseConverter(XmlBaseConverter converterAtomic); // 0x00000001819E7650-0x00000001819E76C0
		protected XmlBaseConverter(XmlBaseConverter converterAtomic, Type clrTypeDefault); // 0x00000001819E7300-0x00000001819E7360
		static XmlBaseConverter(); // 0x00000001819E6BE0-0x00000001819E7300
	
		// Methods
		public override bool ToBoolean(DateTime value); // 0x00000001819E4530-0x00000001819E4610
		public override bool ToBoolean(double value); // 0x00000001819E4450-0x00000001819E4530
		public override bool ToBoolean(int value); // 0x00000001819E42C0-0x00000001819E4390
		public override bool ToBoolean(long value); // 0x00000001819E46D0-0x00000001819E47A0
		public override bool ToBoolean(string value); // 0x00000001819E4390-0x00000001819E4450
		public override bool ToBoolean(object value); // 0x00000001819E4610-0x00000001819E46D0
		public override DateTime ToDateTime(bool value); // 0x00000001819E4DE0-0x00000001819E4EC0
		public override DateTime ToDateTime(DateTimeOffset value); // 0x00000001819E4F90-0x00000001819E5080
		public override DateTime ToDateTime(double value); // 0x00000001819E4A60-0x00000001819E4B50
		public override DateTime ToDateTime(int value); // 0x00000001819E4D00-0x00000001819E4DE0
		public override DateTime ToDateTime(long value); // 0x00000001819E4B50-0x00000001819E4C30
		public override DateTime ToDateTime(string value); // 0x00000001819E4EC0-0x00000001819E4F90
		public override DateTime ToDateTime(object value); // 0x00000001819E4C30-0x00000001819E4D00
		public override DateTimeOffset ToDateTimeOffset(DateTime value); // 0x00000001819E4880-0x00000001819E4980
		public override DateTimeOffset ToDateTimeOffset(string value); // 0x00000001819E47A0-0x00000001819E4880
		public override DateTimeOffset ToDateTimeOffset(object value); // 0x00000001819E4980-0x00000001819E4A60
		public override decimal ToDecimal(string value); // 0x00000001819E5160-0x00000001819E5240
		public override decimal ToDecimal(object value); // 0x00000001819E5080-0x00000001819E5160
		public override double ToDouble(bool value); // 0x00000001819E53E0-0x00000001819E54B0
		public override double ToDouble(DateTime value); // 0x00000001819E5300-0x00000001819E53E0
		public override double ToDouble(int value); // 0x00000001819E5570-0x00000001819E5640
		public override double ToDouble(long value); // 0x00000001819E5640-0x00000001819E5710
		public override double ToDouble(string value); // 0x00000001819E54B0-0x00000001819E5570
		public override double ToDouble(object value); // 0x00000001819E5240-0x00000001819E5300
		public override int ToInt32(bool value); // 0x00000001819E5B20-0x00000001819E5BF0
		public override int ToInt32(DateTime value); // 0x00000001819E57D0-0x00000001819E58B0
		public override int ToInt32(double value); // 0x00000001819E5A40-0x00000001819E5B20
		public override int ToInt32(long value); // 0x00000001819E5970-0x00000001819E5A40
		public override int ToInt32(string value); // 0x00000001819E5710-0x00000001819E57D0
		public override int ToInt32(object value); // 0x00000001819E58B0-0x00000001819E5970
		public override long ToInt64(bool value); // 0x00000001819E6000-0x00000001819E60D0
		public override long ToInt64(DateTime value); // 0x00000001819E5CC0-0x00000001819E5DA0
		public override long ToInt64(double value); // 0x00000001819E5E60-0x00000001819E5F40
		public override long ToInt64(int value); // 0x00000001819E5BF0-0x00000001819E5CC0
		public override long ToInt64(string value); // 0x00000001819E5DA0-0x00000001819E5E60
		public override long ToInt64(object value); // 0x00000001819E5F40-0x00000001819E6000
		public override float ToSingle(double value); // 0x00000001819E6190-0x00000001819E6270
		public override float ToSingle(string value); // 0x00000001819E60D0-0x00000001819E6190
		public override float ToSingle(object value); // 0x00000001819E6270-0x00000001819E6330
		public override string ToString(bool value); // 0x00000001819E69A0-0x00000001819E6A60
		public override string ToString(DateTime value); // 0x00000001819E6650-0x00000001819E6720
		public override string ToString(DateTimeOffset value); // 0x00000001819E63F0-0x00000001819E64C0
		public override string ToString(decimal value); // 0x00000001819E6580-0x00000001819E6650
		public override string ToString(double value); // 0x00000001819E6720-0x00000001819E67F0
		public override string ToString(int value); // 0x00000001819E6330-0x00000001819E63F0
		public override string ToString(long value); // 0x00000001819E68C0-0x00000001819E6980
		public override string ToString(float value); // 0x00000001819E67F0-0x00000001819E68C0
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x00000001819E64C0-0x00000001819E6580
		public override string ToString(object value); // 0x00000001819E6980-0x00000001819E69A0
		public override object ChangeType(bool value, Type destinationType); // 0x00000001819E1740-0x00000001819E17A0
		public override object ChangeType(DateTime value, Type destinationType); // 0x00000001819E1860-0x00000001819E18E0
		public override object ChangeType(decimal value, Type destinationType); // 0x00000001819E1650-0x00000001819E16E0
		public override object ChangeType(double value, Type destinationType); // 0x00000001819E1800-0x00000001819E1860
		public override object ChangeType(int value, Type destinationType); // 0x00000001819E16E0-0x00000001819E1740
		public override object ChangeType(long value, Type destinationType); // 0x00000001819E17A0-0x00000001819E1800
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819E1630-0x00000001819E1650
		public override object ChangeType(object value, Type destinationType); // 0x00000001819E1600-0x00000001819E1630
		protected static bool IsDerivedFrom(Type derivedType, Type baseType); // 0x00000001819E2FF0-0x00000001819E30B0
		protected Exception CreateInvalidClrMappingException(Type sourceType, Type destinationType); // 0x00000001819E18E0-0x00000001819E1BE0
		protected static string QNameToString(XmlQualifiedName name); // 0x00000001819E30B0-0x00000001819E31D0
		protected virtual object ChangeListType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819E15A0-0x00000001819E1600
		protected static byte[] StringToBase64Binary(string value); // 0x00000001819E33B0-0x00000001819E3430
		protected static DateTime StringToDate(string value); // 0x00000001819E35D0-0x00000001819E3650
		protected static DateTime StringToDateTime(string value); // 0x00000001819E3550-0x00000001819E35D0
		protected static TimeSpan StringToDayTimeDuration(string value); // 0x00000001819E3650-0x00000001819E36C0
		protected static TimeSpan StringToDuration(string value); // 0x00000001819E36C0-0x00000001819E3730
		protected static DateTime StringToGDay(string value); // 0x00000001819E37C0-0x00000001819E3840
		protected static DateTime StringToGMonth(string value); // 0x00000001819E39E0-0x00000001819E3A60
		protected static DateTime StringToGMonthDay(string value); // 0x00000001819E38D0-0x00000001819E3950
		protected static DateTime StringToGYear(string value); // 0x00000001819E3C00-0x00000001819E3C80
		protected static DateTime StringToGYearMonth(string value); // 0x00000001819E3AF0-0x00000001819E3B70
		protected static DateTimeOffset StringToDateOffset(string value); // 0x00000001819E3430-0x00000001819E34C0
		protected static DateTimeOffset StringToDateTimeOffset(string value); // 0x00000001819E34C0-0x00000001819E3550
		protected static DateTimeOffset StringToGDayOffset(string value); // 0x00000001819E3730-0x00000001819E37C0
		protected static DateTimeOffset StringToGMonthOffset(string value); // 0x00000001819E3950-0x00000001819E39E0
		protected static DateTimeOffset StringToGMonthDayOffset(string value); // 0x00000001819E3840-0x00000001819E38D0
		protected static DateTimeOffset StringToGYearOffset(string value); // 0x00000001819E3B70-0x00000001819E3C00
		protected static DateTimeOffset StringToGYearMonthOffset(string value); // 0x00000001819E3A60-0x00000001819E3AF0
		protected static byte[] StringToHexBinary(string value); // 0x00000001819E3C80-0x00000001819E3D50
		protected static XmlQualifiedName StringToQName(string value, IXmlNamespaceResolver nsResolver); // 0x00000001819E3D50-0x00000001819E4030
		protected static DateTime StringToTime(string value); // 0x00000001819E40C0-0x00000001819E4140
		protected static DateTimeOffset StringToTimeOffset(string value); // 0x00000001819E4030-0x00000001819E40C0
		protected static TimeSpan StringToYearMonthDuration(string value); // 0x00000001819E4140-0x00000001819E41B0
		protected static string AnyUriToString(Uri value); // 0x00000001819E1530-0x00000001819E1550
		protected static string Base64BinaryToString(byte[] value); // 0x00000001819E1550-0x00000001819E15A0
		protected static string DateToString(DateTime value); // 0x00000001819E1DD0-0x00000001819E1E50
		protected static string DateTimeToString(DateTime value); // 0x00000001819E1D50-0x00000001819E1DD0
		protected static string DayTimeDurationToString(TimeSpan value); // 0x00000001819E1E50-0x00000001819E1EC0
		protected static string DurationToString(TimeSpan value); // 0x00000001819E2420-0x00000001819E2490
		protected static string GDayToString(DateTime value); // 0x00000001819E2520-0x00000001819E25A0
		protected static string GMonthToString(DateTime value); // 0x00000001819E2740-0x00000001819E27C0
		protected static string GMonthDayToString(DateTime value); // 0x00000001819E2630-0x00000001819E26B0
		protected static string GYearToString(DateTime value); // 0x00000001819E2960-0x00000001819E29E0
		protected static string GYearMonthToString(DateTime value); // 0x00000001819E2850-0x00000001819E28D0
		protected static string DateOffsetToString(DateTimeOffset value); // 0x00000001819E1BE0-0x00000001819E1C70
		protected static string DateTimeOffsetToString(DateTimeOffset value); // 0x00000001819E1CC0-0x00000001819E1D50
		protected static string GDayOffsetToString(DateTimeOffset value); // 0x00000001819E2490-0x00000001819E2520
		protected static string GMonthOffsetToString(DateTimeOffset value); // 0x00000001819E26B0-0x00000001819E2740
		protected static string GMonthDayOffsetToString(DateTimeOffset value); // 0x00000001819E25A0-0x00000001819E2630
		protected static string GYearOffsetToString(DateTimeOffset value); // 0x00000001819E28D0-0x00000001819E2960
		protected static string GYearMonthOffsetToString(DateTimeOffset value); // 0x00000001819E27C0-0x00000001819E2850
		protected static string QNameToString(XmlQualifiedName qname, IXmlNamespaceResolver nsResolver); // 0x00000001819E31D0-0x00000001819E33B0
		protected static string TimeToString(DateTime value); // 0x00000001819E4240-0x00000001819E42C0
		protected static string TimeOffsetToString(DateTimeOffset value); // 0x00000001819E41B0-0x00000001819E4240
		protected static string YearMonthDurationToString(TimeSpan value); // 0x00000001819E6B70-0x00000001819E6BE0
		internal static DateTime DateTimeOffsetToDateTime(DateTimeOffset value); // 0x00000001819E1C70-0x00000001819E1CC0
		internal static int DecimalToInt32(decimal value); // 0x00000001819E1EC0-0x00000001819E2090
		protected static long DecimalToInt64(decimal value); // 0x00000001819E2090-0x00000001819E2260
		protected static ulong DecimalToUInt64(decimal value); // 0x00000001819E2260-0x00000001819E2420
		protected static byte Int32ToByte(int value); // 0x00000001819E29E0-0x00000001819E2AE0
		protected static short Int32ToInt16(int value); // 0x00000001819E2AE0-0x00000001819E2BE0
		protected static sbyte Int32ToSByte(int value); // 0x00000001819E2BE0-0x00000001819E2CE0
		protected static ushort Int32ToUInt16(int value); // 0x00000001819E2CE0-0x00000001819E2DE0
		protected static int Int64ToInt32(long value); // 0x00000001819E2DE0-0x00000001819E2EF0
		protected static uint Int64ToUInt32(long value); // 0x00000001819E2EF0-0x00000001819E2FF0
		protected static DateTime UntypedAtomicToDateTime(string value); // 0x00000001819E6AF0-0x00000001819E6B70
		protected static DateTimeOffset UntypedAtomicToDateTimeOffset(string value); // 0x00000001819E6A60-0x00000001819E6AF0
	}
}
