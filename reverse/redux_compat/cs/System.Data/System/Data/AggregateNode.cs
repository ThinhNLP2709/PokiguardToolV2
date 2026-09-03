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
	internal sealed class AggregateNode : ExpressionNode // TypeDefIndex: 11269
	{
		// Fields
		private readonly AggregateType _type; // 0x18
		private readonly Aggregate _aggregate; // 0x1C
		private readonly bool _local; // 0x20
		private readonly string _relationName; // 0x28
		private readonly string _columnName; // 0x30
		private DataTable _childTable; // 0x38
		private DataColumn _column; // 0x40
		private DataRelation _relation; // 0x48
	
		// Constructors
		internal AggregateNode(DataTable table, FunctionId aggregateType, string columnName); // 0x000000018187CA90-0x000000018187CAB0
		internal AggregateNode(DataTable table, FunctionId aggregateType, string columnName, bool local, string relationName); // 0x000000018187C940-0x000000018187CA90
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x000000018187BFD0-0x000000018187C390
		internal static void Bind(DataRelation relation, List<DataColumn> list); // 0x000000018187C390-0x000000018187C4F0
		internal override object Eval(); // 0x000000018185F790-0x000000018185F7B0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x000000018187C620-0x000000018187C930
		internal override object Eval(int[] records); // 0x000000018187C580-0x000000018187C620
		internal override bool IsConstant(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool IsTableConstant(); // 0x0000000180F1D2E0-0x0000000180F1D2F0
		internal override bool HasLocalAggregate(); // 0x0000000180F1D2E0-0x0000000180F1D2F0
		internal override bool HasRemoteAggregate(); // 0x000000018187C930-0x000000018187C940
		internal override bool DependsOn(DataColumn column); // 0x000000018187C4F0-0x000000018187C580
		internal override ExpressionNode Optimize(); // 0x0000000180370C60-0x0000000180370C70
	}
}
