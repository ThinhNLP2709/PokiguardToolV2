/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class DataExpression : IFilter // TypeDefIndex: 11274
	{
		// Fields
		internal string _originalExpression; // 0x10
		private bool _parsed; // 0x18
		private bool _bound; // 0x19
		private ExpressionNode _expr; // 0x20
		private DataTable _table; // 0x28
		private readonly StorageType _storageType; // 0x30
		private readonly Type _dataType; // 0x38
		private DataColumn[] _dependency; // 0x40
	
		// Properties
		internal string Expression { get; } // 0x0000000181885520-0x0000000181885570 
		internal bool HasValue { get; } // 0x00000001817D1AF0-0x00000001817D1B00 
	
		// Constructors
		internal DataExpression(DataTable table, string expression); // 0x0000000181885110-0x0000000181885130
		internal DataExpression(DataTable table, string expression, Type type); // 0x0000000181885130-0x0000000181885520
	
		// Methods
		internal void Bind(DataTable table); // 0x0000000181884A60-0x0000000181884B90
		internal bool DependsOn(DataColumn column); // 0x0000000181884B90-0x0000000181884BC0
		internal object Evaluate(); // 0x0000000181884D10-0x0000000181884D20
		internal object Evaluate(DataRow row, DataRowVersion version); // 0x0000000181884BC0-0x0000000181884D10
		public bool Invoke(DataRow row, DataRowVersion version); // 0x0000000181884D80-0x0000000181884E30
		internal DataColumn[] GetDependency(); // 0x0000000180377940-0x0000000180377950
		internal bool IsTableAggregate(); // 0x0000000181884E30-0x0000000181884E60
		internal static bool IsUnknown(object value); // 0x0000000181884E60-0x0000000181884EB0
		internal bool HasLocalAggregate(); // 0x0000000181884D20-0x0000000181884D50
		internal bool HasRemoteAggregate(); // 0x0000000181884D50-0x0000000181884D80
		internal static bool ToBoolean(object value); // 0x0000000181884EB0-0x0000000181885110
	}
}
