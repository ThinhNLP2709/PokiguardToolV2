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
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class XmlAnyConverter : XmlBaseConverter // TypeDefIndex: 7276
	{
		// Fields
		public static readonly XmlValueConverter Item; // 0x00
		public static readonly XmlValueConverter AnyAtomic; // 0x08
	
		// Constructors
		protected XmlAnyConverter(XmlTypeCode typeCode); // 0x0000000181A01CB0-0x0000000181A01D10
		static XmlAnyConverter(); // 0x0000000181A01B90-0x0000000181A01CB0
	
		// Methods
		public override bool ToBoolean(object value); // 0x0000000181A00C90-0x0000000181A00E40
		public override DateTime ToDateTime(object value); // 0x0000000181A01040-0x0000000181A01200
		public override DateTimeOffset ToDateTimeOffset(object value); // 0x0000000181A00E40-0x0000000181A01040
		public override decimal ToDecimal(object value); // 0x0000000181A01200-0x0000000181A01400
		public override double ToDouble(object value); // 0x0000000181A01400-0x0000000181A015B0
		public override int ToInt32(object value); // 0x0000000181A015B0-0x0000000181A01760
		public override long ToInt64(object value); // 0x0000000181A01760-0x0000000181A01910
		public override float ToSingle(object value); // 0x0000000181A019B0-0x0000000181A01B90
		public override object ChangeType(bool value, Type destinationType); // 0x00000001819FF350-0x00000001819FF4F0
		public override object ChangeType(DateTime value, Type destinationType); // 0x00000001819FF4F0-0x00000001819FF690
		public override object ChangeType(decimal value, Type destinationType); // 0x00000001819FEE10-0x00000001819FEFE0
		public override object ChangeType(double value, Type destinationType); // 0x0000000181A00AF0-0x0000000181A00C90
		public override object ChangeType(int value, Type destinationType); // 0x00000001819FF690-0x00000001819FF830
		public override object ChangeType(long value, Type destinationType); // 0x00000001819FEFE0-0x00000001819FF180
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819FF180-0x00000001819FF350
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819FF830-0x0000000181A00AF0
		private object ChangeTypeWildcardDestination(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819FEB80-0x00000001819FECC0
		private object ChangeTypeWildcardSource(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x00000001819FECC0-0x00000001819FEE10
		private XPathNavigator ToNavigator(XPathNavigator nav); // 0x0000000181A01910-0x0000000181A019B0
	}
}
