/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal class BinaryNode : ExpressionNode // TypeDefIndex: 11270
	{
		// Fields
		internal int _op; // 0x18
		internal ExpressionNode _left; // 0x20
		internal ExpressionNode _right; // 0x28
	
		// Nested types
		private enum DataTypePrecedence // TypeDefIndex: 11271
		{
			SqlBinary = -10,
			SqlBytes = -9,
			Char = -8,
			SqlChars = -7,
			SqlXml = -6,
			String = -5,
			SqlString = -4,
			SqlGuid = -3,
			Boolean = -2,
			SqlBoolean = -1,
			Error = 0,
			SByte = 1,
			SqlByte = 2,
			Byte = 3,
			Int16 = 4,
			SqlInt16 = 5,
			UInt16 = 6,
			Int32 = 7,
			SqlInt32 = 8,
			UInt32 = 9,
			Int64 = 10,
			SqlInt64 = 11,
			UInt64 = 12,
			SqlMoney = 13,
			Decimal = 14,
			SqlDecimal = 15,
			Single = 16,
			SqlSingle = 17,
			Double = 18,
			SqlDouble = 19,
			TimeSpan = 20,
			DateTime = 23,
			DateTimeOffset = 24,
			SqlDateTime = 25
		}
	
		// Constructors
		internal BinaryNode(DataTable table, int op, ExpressionNode left, ExpressionNode right); // 0x0000000181884120-0x0000000181884190
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x000000018187D800-0x000000018187D880
		internal override object Eval(); // 0x000000018185F790-0x000000018185F7B0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x0000000181882EB0-0x0000000181882EE0
		internal override object Eval(int[] recordNos); // 0x0000000181882E20-0x0000000181882E60
		internal override bool IsConstant(); // 0x00000001818832A0-0x0000000181883300
		internal override bool IsTableConstant(); // 0x00000001818833F0-0x0000000181883450
		internal override bool HasLocalAggregate(); // 0x00000001818831E0-0x0000000181883240
		internal override bool HasRemoteAggregate(); // 0x0000000181883240-0x00000001818832A0
		internal override bool DependsOn(DataColumn column); // 0x000000018187D880-0x000000018187D8F0
		internal override ExpressionNode Optimize(); // 0x0000000181883450-0x00000001818837C0
		internal void SetTypeMismatchError(int op, Type left, Type right); // 0x0000000181883FF0-0x0000000181884030
		private static object Eval(ExpressionNode expr, DataRow row, DataRowVersion version, int[] recordNos); // 0x0000000181882E60-0x0000000181882EB0
		internal int BinaryCompare(object vLeft, object vRight, StorageType resultType, int op); // 0x000000018187CAB0-0x000000018187CAE0
		internal int BinaryCompare(object vLeft, object vRight, StorageType resultType, int op, CompareInfo comparer); // 0x000000018187CAE0-0x000000018187D800
		private object EvalBinaryOp(int op, ExpressionNode left, ExpressionNode right, DataRow row, DataRowVersion version, int[] recordNos); // 0x000000018187D8F0-0x0000000181882E20
		private DataTypePrecedence GetPrecedence(StorageType storageType); // 0x0000000181883050-0x00000001818831E0
		private static StorageType GetPrecedenceType(DataTypePrecedence code); // 0x0000000181882EE0-0x0000000181883050
		private bool IsMixed(StorageType left, StorageType right); // 0x0000000181883380-0x00000001818833F0
		private bool IsMixedSql(StorageType left, StorageType right); // 0x0000000181883300-0x0000000181883380
		internal StorageType ResultType(StorageType left, StorageType right, bool lc, bool rc, int op); // 0x0000000181883C40-0x0000000181883FF0
		internal StorageType ResultSqlType(StorageType left, StorageType right, bool lc, bool rc, int op); // 0x00000001818837C0-0x0000000181883C40
		private int SqlResultType(int typeCode); // 0x0000000181884030-0x0000000181884120
	}
}
