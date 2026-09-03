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
	internal sealed class RelatedView : DataView, IFilter // TypeDefIndex: 11310
	{
		// Fields
		private readonly DataKey? _parentKey; // 0xB8
		private readonly DataKey _childKey; // 0xC8
		private readonly DataRowView _parentRowView; // 0xD0
		private readonly object[] _filterValues; // 0xD8
	
		// Constructors
		public RelatedView(DataColumn[] columns, object[] values); // 0x000000018189D420-0x000000018189D580
		public RelatedView(DataRowView parentRowView, DataKey parentKey, DataColumn[] childKeyColumns); // 0x000000018189D580-0x000000018189D6C0
	
		// Methods
		private object[] GetParentValues(); // 0x000000018189D1F0-0x000000018189D280
		public bool Invoke(DataRow row, DataRowVersion version); // 0x000000018189D280-0x000000018189D3F0
		internal override IFilter GetFilter(); // 0x0000000180370C60-0x0000000180370C70
		public override DataRowView AddNew(); // 0x000000018189D180-0x000000018189D1F0
		internal override void SetIndex(string newSort, DataViewRowState newRowStates, IFilter newRowFilter); // 0x000000018189D3F0-0x000000018189D420
	}
}
