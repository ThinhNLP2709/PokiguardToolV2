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
	internal sealed class UnaryNode : ExpressionNode // TypeDefIndex: 11290
	{
		// Fields
		internal readonly int _op; // 0x18
		internal ExpressionNode _right; // 0x20
	
		// Constructors
		internal UnaryNode(DataTable table, int op, ExpressionNode right); // 0x00000001818A0930-0x00000001818A0980
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x000000018189FDA0-0x000000018189FE00
		internal override object Eval(); // 0x000000018185F790-0x000000018185F7B0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x00000001818A0730-0x00000001818A0780
		internal override object Eval(int[] recordNos); // 0x00000001818A0700-0x00000001818A0730
		private object EvalUnaryOp(int op, object vl); // 0x000000018189FE30-0x00000001818A0700
		internal override bool IsConstant(); // 0x00000001818A07E0-0x00000001818A0810
		internal override bool IsTableConstant(); // 0x00000001818A0810-0x00000001818A0840
		internal override bool HasLocalAggregate(); // 0x00000001818A0780-0x00000001818A07B0
		internal override bool HasRemoteAggregate(); // 0x00000001818A07B0-0x00000001818A07E0
		internal override bool DependsOn(DataColumn column); // 0x000000018189FE00-0x000000018189FE30
		internal override ExpressionNode Optimize(); // 0x00000001818A0840-0x00000001818A0930
	}
}
