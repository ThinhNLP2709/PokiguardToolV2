/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[DefaultProperty("ColumnName")]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public class DataColumn : MarshalByValueComponent // TypeDefIndex: 11188
	{
		// Fields
		private bool _allowNull; // 0x20
		private string _caption; // 0x28
		private string _columnName; // 0x30
		private Type _dataType; // 0x38
		private StorageType _storageType; // 0x40
		internal object _defaultValue; // 0x48
		private DataSetDateTime _dateTimeMode; // 0x50
		private DataExpression _expression; // 0x58
		private int _maxLength; // 0x60
		private int _ordinal; // 0x64
		private bool _readOnly; // 0x68
		internal Index _sortIndex; // 0x70
		internal DataTable _table; // 0x78
		private bool _unique; // 0x80
		internal MappingType _columnMapping; // 0x84
		internal int _hashCode; // 0x88
		internal int _errors; // 0x8C
		private bool _isSqlType; // 0x90
		private bool _implementsINullable; // 0x91
		private bool _implementsIChangeTracking; // 0x92
		private bool _implementsIRevertibleChangeTracking; // 0x93
		private bool _implementsIXMLSerializable; // 0x94
		private bool _defaultValueIsNull; // 0x95
		internal List<DataColumn> _dependentColumns; // 0x98
		internal PropertyCollection _extendedProperties; // 0xA0
		private DataStorage _storage; // 0xA8
		private AutoIncrementValue _autoInc; // 0xB0
		internal string _columnUri; // 0xB8
		private string _columnPrefix; // 0xC0
		internal string _encodedColumnName; // 0xC8
		internal SimpleType _simpleType; // 0xD0
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0xD8
		[CompilerGenerated]
		private string _XmlDataType_k__BackingField; // 0xE0
		[CompilerGenerated]
		private PropertyChangedEventHandler PropertyChanging; // 0xE8
	
		// Properties
		[DefaultValue(true)]
		public bool AllowDBNull { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x0000000181846200-0x0000000181846350
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		public bool AutoIncrement { get; set; } // 0x0000000181845C40-0x0000000181845C60 0x00000001818466D0-0x00000001818468B0
		internal object AutoIncrementCurrent { get; set; } // 0x0000000181845B90-0x0000000181845BE0 0x0000000181846350-0x00000001818464C0
		internal AutoIncrementValue AutoInc { get; } // 0x0000000181845AA0-0x0000000181845B90 
		[DefaultValue(0)]
		public long AutoIncrementSeed { get; set; } // 0x0000000181845BE0-0x0000000181845C10 0x00000001818464C0-0x00000001818465C0
		[DefaultValue(1)]
		public long AutoIncrementStep { get; set; } // 0x0000000181845C10-0x0000000181845C40 0x00000001818465C0-0x00000001818466D0
		public string Caption { get; set; } // 0x0000000181845C60-0x0000000181845C80 0x00000001818468B0-0x0000000181846960
		[DefaultValue("")]
		[RefreshProperties(RefreshProperties.All)]
		public string ColumnName { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181846C30-0x0000000181846FD0
		internal string EncodedColumnName { get; } // 0x0000000181845DE0-0x0000000181845E60 
		internal IFormatProvider FormatProvider { get; } // 0x0000000181845F30-0x0000000181845F70 
		internal CultureInfo Locale { get; } // 0x0000000181846080-0x00000001818460C0 
		internal int ObjectID { get; } // 0x0000000181846100-0x0000000181846110 
		[DefaultValue("")]
		public string Prefix { get; set; } // 0x00000001806CCB70-0x00000001806CCB80 0x0000000181848B80-0x0000000181848CE0
		internal bool Computed { get; } // 0x0000000181845C80-0x0000000181845C90 
		internal DataExpression DataExpression { get; } // 0x00000001802F4000-0x00000001802F4010 
		[DefaultValue(typeof(string))]
		[RefreshProperties(RefreshProperties.All)]
		[TypeConverter(typeof(ColumnTypeConverter))]
		public Type DataType { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181846FD0-0x0000000181847A20
		[DefaultValue(DataSetDateTime.UnspecifiedLocal)]
		[RefreshProperties(RefreshProperties.All)]
		public DataSetDateTime DateTimeMode { get; set; } // 0x000000018033D660-0x000000018033D670 0x0000000181847A20-0x0000000181847B80
		[TypeConverter(typeof(DefaultValueTypeConverter))]
		public object DefaultValue { get; set; } // 0x0000000181845CA0-0x0000000181845DE0 0x0000000181847B80-0x0000000181847EB0
		internal bool DefaultValueIsNull { get; } // 0x0000000181845C90-0x0000000181845CA0 
		[DefaultValue("")]
		[RefreshProperties(RefreshProperties.All)]
		public string Expression { get; set; } // 0x0000000181845E60-0x0000000181845EB0 0x0000000181847EB0-0x00000001818484B0
		[Browsable(false)]
		public PropertyCollection ExtendedProperties { get; } // 0x0000000181845EB0-0x0000000181845F30 
		internal bool HasData { get; } // 0x0000000181845F70-0x0000000181845F80 
		internal bool ImplementsINullable { get; } // 0x0000000181845F90-0x0000000181845FA0 
		internal bool ImplementsIChangeTracking { get; } // 0x0000000181845F80-0x0000000181845F90 
		internal bool ImplementsIRevertibleChangeTracking { get; } // 0x0000000181845FA0-0x0000000181845FB0 
		internal bool IsValueType { get; } // 0x0000000181846030-0x0000000181846050 
		internal bool IsSqlType { get; } // 0x000000018033D630-0x000000018033D640 
		[DefaultValue(-1)]
		public int MaxLength { get; set; } // 0x000000018150C180-0x000000018150C190 0x0000000181848650-0x0000000181848A00
		public string Namespace { get; set; } // 0x00000001818460C0-0x0000000181846100 0x0000000181848A00-0x0000000181848B80
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Ordinal { get; } // 0x00000001802F2020-0x00000001802F2030 
		[DefaultValue(false)]
		public bool ReadOnly { get; set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000181848CE0-0x0000000181848DC0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Index SortIndex { get; } // 0x0000000181846110-0x0000000181846200 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataTable Table { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		internal object this[int record] { get => default; set {} } // 0x0000000181846050-0x0000000181846080 0x00000001818484B0-0x0000000181848650
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Unique { get; set; } // 0x000000018170D340-0x000000018170D350 0x0000000181848E20-0x00000001818491E0
		internal string XmlDataType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001806CCDC0-0x00000001806CCDE0
		internal SimpleType SimpleType { get; set; } // 0x00000001806CCB60-0x00000001806CCB70 0x0000000181848DC0-0x0000000181848E20
		[DefaultValue(MappingType.Element)]
		public virtual MappingType ColumnMapping { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000181846960-0x0000000181846C30
		internal bool IsCustomType { get; } // 0x0000000181845FC0-0x0000000181846030 
		internal bool ImplementsIXMLSerializable { get; } // 0x0000000181845FB0-0x0000000181845FC0 
	
		// Constructors
		public DataColumn(); // 0x00000001818456E0-0x0000000181845740
		public DataColumn(string columnName, Type dataType); // 0x00000001818456B0-0x00000001818456E0
		public DataColumn(string columnName, Type dataType, string expr, MappingType type); // 0x0000000181845740-0x0000000181845AA0
	
		// Methods
		private void UpdateColumnType(Type type, StorageType typeCode); // 0x00000001818455A0-0x00000001818456B0
		internal string GetColumnValueAsString(DataRow row, DataRowVersion version); // 0x0000000181843FC0-0x00000001818440B0
		private void SetMaxLengthSimpleType(); // 0x0000000181845070-0x00000001818451A0
		internal void SetOrdinalInternal(int ordinal); // 0x00000001818451A0-0x00000001818452E0
		internal void SetTable(DataTable table); // 0x0000000181845330-0x0000000181845410
		private DataRow GetDataRow(int index); // 0x00000001818440B0-0x00000001818440E0
		internal void InitializeRecord(int record); // 0x00000001818444F0-0x0000000181844540
		internal void SetValue(int record, object value); // 0x0000000181845410-0x0000000181845500
		internal void FreeRecord(int record); // 0x0000000181843F00-0x0000000181843F40
		internal void InternalUnique(bool value); // 0x00000001812500E0-0x00000001812500F0
		internal void CheckColumnConstraint(DataRow row, DataRowAction action); // 0x0000000181842C90-0x0000000181842DC0
		internal bool CheckMaxLength(); // 0x0000000181842E50-0x00000001818430C0
		internal void CheckMaxLength(DataRow dr); // 0x0000000181842DC0-0x0000000181842E50
		protected internal void CheckNotAllowNull(); // 0x00000001818430C0-0x0000000181843420
		internal void CheckNullable(DataRow row); // 0x0000000181843420-0x00000001818434B0
		protected void CheckUnique(); // 0x00000001818434B0-0x0000000181843510
		internal int Compare(int record1, int record2); // 0x0000000181843CD0-0x0000000181843D00
		internal bool CompareValueTo(int record1, object value, bool checkType); // 0x0000000181843B00-0x0000000181843CA0
		internal int CompareValueTo(int record1, object value); // 0x0000000181843CA0-0x0000000181843CD0
		internal object ConvertValue(object value); // 0x0000000181843DC0-0x0000000181843DF0
		internal void Copy(int srcRecordNo, int dstRecordNo); // 0x0000000181843ED0-0x0000000181843F00
		internal DataColumn Clone(); // 0x0000000181843510-0x0000000181843B00
		internal object GetAggregateValue(int[] records, AggregateType kind); // 0x0000000181843F40-0x0000000181843FC0
		private int GetStringLength(int record); // 0x0000000181844120-0x0000000181844150
		internal void Init(int record); // 0x0000000181844420-0x00000001818444F0
		internal static bool IsAutoIncrementType(Type dataType); // 0x00000001818445D0-0x0000000181844740
		internal bool IsValueCustomTypeInstance(object value); // 0x0000000181844E40-0x0000000181844F00
		internal bool IsInRelation(); // 0x0000000181844740-0x0000000181844890
		internal bool IsMaxLengthViolated(); // 0x0000000181844890-0x0000000181844CC0
		internal bool IsNotAllowDBNullViolated(); // 0x0000000181844CC0-0x0000000181844E40
		protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent); // 0x000000018136F380-0x000000018136F3B0
		protected internal void RaisePropertyChanging(string name); // 0x0000000181844F00-0x0000000181844F80
		private void InsureStorage(); // 0x0000000181844540-0x00000001818445D0
		internal void SetCapacity(int capacity); // 0x0000000181845020-0x0000000181845070
		internal void OnSetDataSet(); // 0x00000001802E76C0-0x00000001802E76D0
		public override string ToString(); // 0x0000000181845500-0x00000001818455A0
		internal object ConvertXmlToObject(string s); // 0x0000000181843DF0-0x0000000181843E40
		internal object ConvertXmlToObject(XmlReader xmlReader, XmlRootAttribute xmlAttrib); // 0x0000000181843E40-0x0000000181843EA0
		internal string ConvertObjectToXml(object value); // 0x0000000181843D00-0x0000000181843D50
		internal void ConvertObjectToXml(object value, XmlWriter xmlWriter, XmlRootAttribute xmlAttrib); // 0x0000000181843D50-0x0000000181843DC0
		internal object GetEmptyColumnStore(int recordCount); // 0x00000001818440E0-0x0000000181844120
		internal void CopyValueIntoStore(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181843EA0-0x0000000181843ED0
		internal void SetStorage(object store, BitArray nullbits); // 0x00000001818452E0-0x0000000181845330
		internal void AddDependentColumn(DataColumn expressionColumn); // 0x0000000181842B70-0x0000000181842C90
		internal void RemoveDependentColumn(DataColumn expressionColumn); // 0x0000000181844F80-0x0000000181845020
		internal void HandleDependentColumnList(DataExpression oldExpression, DataExpression newExpression); // 0x0000000181844150-0x0000000181844420
	}
}
