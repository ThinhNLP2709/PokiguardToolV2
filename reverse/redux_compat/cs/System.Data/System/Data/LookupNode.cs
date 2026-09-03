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
	internal sealed class LookupNode : ExpressionNode // TypeDefIndex: 11287
	{
		// Fields
		private readonly string _relationName; // 0x18
		private readonly string _columnName; // 0x20
		private DataColumn _column; // 0x28
		private DataRelation _relation; // 0x30
	
		// Constructors
		internal LookupNode(DataTable table, string columnName, string relationName); // 0x0000000181890D50-0x0000000181890DC0
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x0000000181890840-0x0000000181890BD0
		internal override object Eval(); // 0x0000000181890BE0-0x0000000181890C10
		internal override object Eval(DataRow row, DataRowVersion version); // 0x0000000181890C50-0x0000000181890D50
		internal override object Eval(int[] recordNos); // 0x0000000181890C10-0x0000000181890C50
		internal override bool IsConstant(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool IsTableConstant(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool HasLocalAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool HasRemoteAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool DependsOn(DataColumn column); // 0x0000000181890BD0-0x0000000181890BE0
		internal override ExpressionNode Optimize(); // 0x0000000180370C60-0x0000000180370C70
	}
}
