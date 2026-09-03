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
	internal sealed class ZeroOpNode : ExpressionNode // TypeDefIndex: 11291
	{
		// Fields
		internal readonly int _op; // 0x18
	
		// Constructors
		internal ZeroOpNode(int op); // 0x00000001818A8EE0-0x00000001818A8F10
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x00000001802E76C0-0x00000001802E76D0
		internal override object Eval(); // 0x00000001818A8E70-0x00000001818A8EE0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x0000000181884190-0x00000001818841B0
		internal override object Eval(int[] recordNos); // 0x0000000181884190-0x00000001818841B0
		internal override bool IsConstant(); // 0x00000001802E7990-0x00000001802E79A0
		internal override bool IsTableConstant(); // 0x00000001802E7990-0x00000001802E79A0
		internal override bool HasLocalAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool HasRemoteAggregate(); // 0x00000001802E7840-0x00000001802E7850
		internal override ExpressionNode Optimize(); // 0x0000000180370C60-0x0000000180370C70
	}
}
