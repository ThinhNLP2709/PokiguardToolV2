/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal static class SqlConvert // TypeDefIndex: 11389
	{
		// Methods
		public static SqlByte ConvertToSqlByte(object value); // 0x00000001819101E0-0x0000000181910380
		public static SqlInt16 ConvertToSqlInt16(object value); // 0x0000000181911680-0x00000001819118E0
		public static SqlInt32 ConvertToSqlInt32(object value); // 0x00000001819118E0-0x0000000181911C50
		public static SqlInt64 ConvertToSqlInt64(object value); // 0x0000000181911C50-0x00000001819120E0
		public static SqlDouble ConvertToSqlDouble(object value); // 0x0000000181910E40-0x00000001819114D0
		public static SqlDecimal ConvertToSqlDecimal(object value); // 0x00000001819107D0-0x0000000181910E40
		public static SqlSingle ConvertToSqlSingle(object value); // 0x00000001819126B0-0x0000000181912CD0
		public static SqlMoney ConvertToSqlMoney(object value); // 0x00000001819120E0-0x00000001819126B0
		public static SqlDateTime ConvertToSqlDateTime(object value); // 0x00000001819105E0-0x00000001819107D0
		public static SqlBoolean ConvertToSqlBoolean(object value); // 0x0000000181910040-0x00000001819101E0
		public static SqlGuid ConvertToSqlGuid(object value); // 0x00000001819114D0-0x0000000181911680
		public static SqlBinary ConvertToSqlBinary(object value); // 0x000000018190FE90-0x0000000181910040
		public static SqlString ConvertToSqlString(object value); // 0x0000000181912CD0-0x0000000181912EA0
		public static SqlChars ConvertToSqlChars(object value); // 0x00000001819104B0-0x00000001819105E0
		public static SqlBytes ConvertToSqlBytes(object value); // 0x0000000181910380-0x00000001819104B0
		public static DateTimeOffset ConvertStringToDateTimeOffset(string value, IFormatProvider formatProvider); // 0x000000018190FE10-0x000000018190FE90
		public static object ChangeTypeForDefaultValue(object value, Type type, IFormatProvider formatProvider); // 0x000000018190DE20-0x000000018190DFB0
		public static object ChangeType2(object value, StorageType stype, Type type, IFormatProvider formatProvider); // 0x000000018190C350-0x000000018190DE20
		public static object ChangeTypeForXML(object value, Type type); // 0x000000018190DFB0-0x000000018190FE10
	}
}
