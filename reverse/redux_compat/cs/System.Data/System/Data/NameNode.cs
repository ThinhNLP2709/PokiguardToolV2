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
	internal sealed class NameNode : ExpressionNode // TypeDefIndex: 11288
	{
		// Fields
		internal string _name; // 0x18
		internal bool _found; // 0x20
		internal DataColumn _column; // 0x28
	
		// Properties
		internal override bool IsSqlColumn { get; } // 0x0000000181891610-0x0000000181891680 
	
		// Constructors
		internal NameNode(DataTable table, char[] text, int start, int pos); // 0x00000001818915A0-0x0000000181891610
		internal NameNode(DataTable table, string name); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x0000000181890DC0-0x0000000181890F90
		internal override object Eval(); // 0x0000000181891140-0x0000000181891170
		internal override object Eval(DataRow row, DataRowVersion version); // 0x0000000181891020-0x0000000181891100
		internal override object Eval(int[] records); // 0x0000000181891100-0x0000000181891140
		internal override bool IsConstant(); // 0x00000001802E7840-0x00000001802E7850
		internal override bool IsTableConstant(); // 0x0000000181891250-0x00000001818912C0
		internal override bool HasLocalAggregate(); // 0x0000000181891170-0x00000001818911E0
		internal override bool HasRemoteAggregate(); // 0x00000001818911E0-0x0000000181891250
		internal override bool DependsOn(DataColumn column); // 0x0000000181890F90-0x0000000181891020
		internal override ExpressionNode Optimize(); // 0x0000000180370C60-0x0000000180370C70
		internal static string ParseName(char[] text, int start, int pos); // 0x00000001818912C0-0x00000001818915A0
	}
}
