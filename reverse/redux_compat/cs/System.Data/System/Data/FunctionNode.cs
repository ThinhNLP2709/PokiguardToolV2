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
	internal sealed class FunctionNode : ExpressionNode // TypeDefIndex: 11207
	{
		// Fields
		internal readonly string _name; // 0x18
		internal readonly int _info; // 0x20
		internal int _argumentCount; // 0x24
		internal ExpressionNode[] _arguments; // 0x28
		[Nullable(2)]
		private readonly TypeLimiter _capturedLimiter; // 0x30
		private static readonly Function[] s_funcs; // 0x00
	
		// Properties
		internal FunctionId Aggregate { get; } // 0x0000000181860A30-0x0000000181860BF0 
		internal bool IsAggregate { get; } // 0x0000000181860BF0-0x0000000181860D50 
	
		// Constructors
		internal FunctionNode(DataTable table, string name); // 0x00000001818608B0-0x0000000181860A30
		static FunctionNode(); // 0x000000018185FE60-0x00000001818608B0
	
		// Methods
		internal void AddArgument(ExpressionNode argument); // 0x000000018185C9B0-0x000000018185CB70
		internal override void Bind(DataTable table, List<DataColumn> list); // 0x000000018185CB70-0x000000018185CE30
		internal override object Eval(); // 0x000000018185F790-0x000000018185F7B0
		internal override object Eval(DataRow row, DataRowVersion version); // 0x000000018185EB40-0x000000018185F750
		internal override object Eval(int[] recordNos); // 0x000000018185F750-0x000000018185F790
		internal override bool IsConstant(); // 0x000000018185FB30-0x000000018185FBC0
		internal override bool IsTableConstant(); // 0x000000018185FBC0-0x000000018185FC50
		internal override bool HasLocalAggregate(); // 0x000000018185FA10-0x000000018185FAA0
		internal override bool HasRemoteAggregate(); // 0x000000018185FAA0-0x000000018185FB30
		internal override bool DependsOn(DataColumn column); // 0x000000018185D010-0x000000018185D0A0
		internal override ExpressionNode Optimize(); // 0x000000018185FC50-0x000000018185FE60
		private Type GetDataType(ExpressionNode node); // 0x000000018185F7B0-0x000000018185FA10
		private object EvalFunction(FunctionId id, object[] argumentValues, DataRow row, DataRowVersion version); // 0x000000018185D0A0-0x000000018185EB40
		internal void Check(); // 0x000000018185CE30-0x000000018185D010
	}
}
