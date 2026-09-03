/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[DefaultMember("Item")]
	public class DataRowView : ICustomTypeDescriptor, INotifyPropertyChanged // TypeDefIndex: 11249
	{
		// Fields
		private readonly DataView _dataView; // 0x10
		private readonly DataRow _row; // 0x18
		private bool _delayBeginEdit; // 0x20
		private static readonly PropertyDescriptorCollection s_zeroPropertyDescriptorCollection; // 0x00
		[CompilerGenerated]
		private PropertyChangedEventHandler PropertyChanged; // 0x28
	
		// Properties
		public DataView DataView { get; } // 0x0000000180377550-0x0000000180377560 
		private DataRowVersion RowVersionDefault { get; } // 0x0000000181871930-0x0000000181871990 
		public DataRow Row { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public bool IsNew { get; } // 0x0000000181871900-0x0000000181871930 
	
		// Constructors
		internal DataRowView(DataView dataView, DataRow row); // 0x0000000180CB0730-0x0000000180CB0780
		static DataRowView(); // 0x0000000181871880-0x0000000181871900
	
		// Methods
		public override bool Equals(object other); // 0x0000000180A29AB0-0x0000000180A29AC0
		public override int GetHashCode(); // 0x00000001818713D0-0x0000000181871400
		internal int GetRecord(); // 0x0000000181871400-0x0000000181871480
		internal bool HasRecord(); // 0x0000000181871480-0x0000000181871500
		internal object GetColumnValue(DataColumn column); // 0x00000001818712B0-0x00000001818713D0
		internal void SetColumnValue(DataColumn column, object value); // 0x0000000181871590-0x0000000181871650
		public DataView CreateChildView(DataRelation relation, bool followParent); // 0x0000000181871010-0x0000000181871240
		public DataView CreateChildView(DataRelation relation); // 0x0000000181871240-0x0000000181871250
		public void EndEdit(); // 0x0000000181871250-0x00000001818712B0
		internal void RaisePropertyChangedEvent(string propName); // 0x0000000181871500-0x0000000181871590
		AttributeCollection ICustomTypeDescriptor.GetAttributes(); // 0x0000000181871650-0x00000001818716A0
		string ICustomTypeDescriptor.GetClassName(); // 0x00000001802E7860-0x00000001802E7870
		string ICustomTypeDescriptor.GetComponentName(); // 0x00000001802E7860-0x00000001802E7870
		TypeConverter ICustomTypeDescriptor.GetConverter(); // 0x00000001802E7860-0x00000001802E7870
		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent(); // 0x00000001802E7860-0x00000001802E7870
		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty(); // 0x00000001802E7860-0x00000001802E7870
		object ICustomTypeDescriptor.GetEditor(Type editorBaseType); // 0x00000001802E7860-0x00000001802E7870
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(); // 0x00000001818716A0-0x00000001818716F0
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes); // 0x00000001818716F0-0x0000000181871740
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(); // 0x00000001818717D0-0x0000000181871880
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes); // 0x0000000181871740-0x00000001818717D0
		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd); // 0x0000000180370C60-0x0000000180370C70
	}
}
