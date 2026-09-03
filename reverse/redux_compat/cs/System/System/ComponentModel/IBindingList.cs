/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public interface IBindingList : IList // TypeDefIndex: 8854
	{
		// Properties
		bool AllowNew { get; }
		bool AllowEdit { get; }
		bool AllowRemove { get; }
		bool SupportsChangeNotification { get; }
		bool SupportsSearching { get; }
		bool SupportsSorting { get; }
		bool IsSorted { get; }
		PropertyDescriptor SortProperty { get; }
		ListSortDirection SortDirection { get; }
	
		// Methods
		object AddNew();
		void AddIndex(PropertyDescriptor property);
		void ApplySort(PropertyDescriptor property, ListSortDirection direction);
		int Find(PropertyDescriptor property, object key);
		void RemoveIndex(PropertyDescriptor property);
		void RemoveSort();
	}
}
