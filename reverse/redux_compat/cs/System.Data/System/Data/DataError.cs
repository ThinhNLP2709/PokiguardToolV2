/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class DataError // TypeDefIndex: 11230
	{
		// Fields
		private string _rowError; // 0x10
		private int _count; // 0x18
		private ColumnError[] _errorList; // 0x20
	
		// Properties
		internal string Text { get; set; } // 0x0000000180377550-0x0000000180377560 0x000000018186A780-0x000000018186A7B0
		internal bool HasErrors { get; } // 0x000000018186A860-0x000000018186A890 
	
		// Nested types
		internal struct ColumnError // TypeDefIndex: 11231
		{
			// Fields
			internal DataColumn _column; // 0x00
			internal string _error; // 0x08
		}
	
		// Constructors
		internal DataError(); // 0x000000018186A820-0x000000018186A860
		internal DataError(string rowError); // 0x000000018186A7B0-0x000000018186A820
	
		// Methods
		internal void SetColumnError(DataColumn column, string error); // 0x000000018186A4C0-0x000000018186A780
		internal string GetColumnError(DataColumn column); // 0x000000018186A200-0x000000018186A270
		internal void Clear(DataColumn column); // 0x000000018186A0D0-0x000000018186A180
		internal void Clear(); // 0x000000018186A180-0x000000018186A200
		internal DataColumn[] GetColumnsInError(); // 0x000000018186A270-0x000000018186A360
		private void SetText(string errorText); // 0x000000018186A780-0x000000018186A7B0
		internal int IndexOf(DataColumn column); // 0x000000018186A360-0x000000018186A4C0
	}
}
