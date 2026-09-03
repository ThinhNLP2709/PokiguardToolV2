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
	public class DataColumnChangeEventArgs : EventArgs // TypeDefIndex: 11226
	{
		// Fields
		private DataColumn _column; // 0x10
		[CompilerGenerated]
		private readonly DataRow _Row_k__BackingField; // 0x18
		[CompilerGenerated]
		private object _ProposedValue_k__BackingField; // 0x20
	
		// Properties
		public object ProposedValue { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		internal DataColumnChangeEventArgs(DataRow row); // 0x00000001818667B0-0x0000000181866820
		public DataColumnChangeEventArgs(DataRow row, DataColumn column, object value); // 0x0000000181866820-0x00000001818668C0
	
		// Methods
		internal void InitializeColumnChangeEvent(DataColumn column, object value); // 0x0000000181866770-0x00000001818667B0
	}
}
