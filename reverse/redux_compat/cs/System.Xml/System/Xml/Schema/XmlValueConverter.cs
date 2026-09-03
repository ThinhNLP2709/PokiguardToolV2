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
	internal abstract class XmlValueConverter // TypeDefIndex: 7267
	{
		// Constructors
		protected XmlValueConverter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract bool ToBoolean(long value);
		public abstract bool ToBoolean(int value);
		public abstract bool ToBoolean(double value);
		public abstract bool ToBoolean(DateTime value);
		public abstract bool ToBoolean(string value);
		public abstract bool ToBoolean(object value);
		public abstract int ToInt32(bool value);
		public abstract int ToInt32(long value);
		public abstract int ToInt32(double value);
		public abstract int ToInt32(DateTime value);
		public abstract int ToInt32(string value);
		public abstract int ToInt32(object value);
		public abstract long ToInt64(bool value);
		public abstract long ToInt64(int value);
		public abstract long ToInt64(double value);
		public abstract long ToInt64(DateTime value);
		public abstract long ToInt64(string value);
		public abstract long ToInt64(object value);
		public abstract decimal ToDecimal(string value);
		public abstract decimal ToDecimal(object value);
		public abstract double ToDouble(bool value);
		public abstract double ToDouble(int value);
		public abstract double ToDouble(long value);
		public abstract double ToDouble(DateTime value);
		public abstract double ToDouble(string value);
		public abstract double ToDouble(object value);
		public abstract float ToSingle(double value);
		public abstract float ToSingle(string value);
		public abstract float ToSingle(object value);
		public abstract DateTime ToDateTime(bool value);
		public abstract DateTime ToDateTime(int value);
		public abstract DateTime ToDateTime(long value);
		public abstract DateTime ToDateTime(double value);
		public abstract DateTime ToDateTime(DateTimeOffset value);
		public abstract DateTime ToDateTime(string value);
		public abstract DateTime ToDateTime(object value);
		public abstract DateTimeOffset ToDateTimeOffset(DateTime value);
		public abstract DateTimeOffset ToDateTimeOffset(string value);
		public abstract DateTimeOffset ToDateTimeOffset(object value);
		public abstract string ToString(bool value);
		public abstract string ToString(int value);
		public abstract string ToString(long value);
		public abstract string ToString(decimal value);
		public abstract string ToString(float value);
		public abstract string ToString(double value);
		public abstract string ToString(DateTime value);
		public abstract string ToString(DateTimeOffset value);
		public abstract string ToString(object value);
		public abstract string ToString(object value, IXmlNamespaceResolver nsResolver);
		public abstract object ChangeType(bool value, Type destinationType);
		public abstract object ChangeType(int value, Type destinationType);
		public abstract object ChangeType(long value, Type destinationType);
		public abstract object ChangeType(decimal value, Type destinationType);
		public abstract object ChangeType(double value, Type destinationType);
		public abstract object ChangeType(DateTime value, Type destinationType);
		public abstract object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver);
		public abstract object ChangeType(object value, Type destinationType);
		public abstract object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver);
	}
}
