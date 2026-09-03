/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal abstract class ExpressionNode // TypeDefIndex: 11275
	{
		// Fields
		private DataTable _table; // 0x10
	
		// Properties
		internal IFormatProvider FormatProvider { get; } // 0x000000018188CB50-0x000000018188CB90 
		internal virtual bool IsSqlColumn { get; } // 0x00000001802E7840-0x00000001802E7850 
		protected DataTable table { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		protected ExpressionNode(DataTable table); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		protected void BindTable(DataTable table); // 0x00000001803780D0-0x00000001803780E0
		internal abstract void Bind(DataTable table, List<DataColumn> list);
		internal abstract object Eval();
		internal abstract object Eval(DataRow row, DataRowVersion version);
		internal abstract object Eval(int[] recordNos);
		internal abstract bool IsConstant();
		internal abstract bool IsTableConstant();
		internal abstract bool HasLocalAggregate();
		internal abstract bool HasRemoteAggregate();
		internal abstract ExpressionNode Optimize();
		internal virtual bool DependsOn(DataColumn column); // 0x00000001802E7840-0x00000001802E7850
		internal static bool IsInteger(StorageType type); // 0x000000018188CA20-0x000000018188CA40
		internal static bool IsIntegerSql(StorageType type); // 0x000000018188CA00-0x000000018188CA20
		internal static bool IsSigned(StorageType type); // 0x000000018188CAF0-0x000000018188CB10
		internal static bool IsSignedSql(StorageType type); // 0x000000018188CAB0-0x000000018188CAF0
		internal static bool IsUnsigned(StorageType type); // 0x000000018188CB30-0x000000018188CB50
		internal static bool IsUnsignedSql(StorageType type); // 0x000000018188CB10-0x000000018188CB30
		internal static bool IsNumeric(StorageType type); // 0x000000018188CA80-0x000000018188CAB0
		internal static bool IsNumericSql(StorageType type); // 0x000000018188CA40-0x000000018188CA80
		internal static bool IsFloat(StorageType type); // 0x000000018188C9E0-0x000000018188CA00
		internal static bool IsFloatSql(StorageType type); // 0x000000018188C9C0-0x000000018188C9E0
	}
}
