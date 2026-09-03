/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class ConstNode : ExpressionNode // TypeDefIndex: 11273
	{
		// Fields
		internal readonly object _val; // 0x18
	
		// Constructors
		internal ConstNode(DataTable table, ValueType type, object constant); // 0x0000000181884A40-0x0000000181884A60
		internal ConstNode(DataTable table, ValueType type, object constant, bool fParseQuotes); // 0x0000000181884710-0x0000000181884A40
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x00000001803780D0-0x00000001803780E0
		internal override object Eval(); // 0x00000001802F8EC0-0x00000001802F8ED0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x0000000181884190-0x00000001818841B0
		internal override object Eval(int[] recordNos); // 0x0000000181884190-0x00000001818841B0
		internal override bool IsConstant(); // 0x00000001802E7990-0x00000001802E79A0
		internal override bool IsTableConstant(); // 0x00000001802E7990-0x00000001802E79A0
		internal override bool HasLocalAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool HasRemoteAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override ExpressionNode Optimize(); // 0x0000000180370C60-0x0000000180370C70
		private object SmallestDecimal(object constant); // 0x00000001818841B0-0x0000000181884420
		private object SmallestNumeric(object constant); // 0x0000000181884420-0x0000000181884710
	}
}
