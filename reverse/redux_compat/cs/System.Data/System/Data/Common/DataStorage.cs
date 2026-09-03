/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal abstract class DataStorage // TypeDefIndex: 11380
	{
		// Fields
		private static readonly Type[] s_storageClassType; // 0x00
		internal readonly DataColumn _column; // 0x10
		internal readonly DataTable _table; // 0x18
		internal readonly Type _dataType; // 0x20
		internal readonly StorageType _storageTypeCode; // 0x28
		private BitArray _dbNullBits; // 0x30
		private readonly object _defaultValue; // 0x38
		internal readonly object _nullValue; // 0x40
		internal readonly bool _isCloneable; // 0x48
		internal readonly bool _isCustomDefinedType; // 0x49
		internal readonly bool _isStringType; // 0x4A
		internal readonly bool _isValueType; // 0x4B
		private static readonly Func<Type, Tuple<bool, bool, bool, bool>> s_inspectTypeForInterfaces; // 0x08
		private static readonly ConcurrentDictionary<Type, Tuple<bool, bool, bool, bool>> s_typeImplementsInterface; // 0x10
	
		// Properties
		internal DataSetDateTime DateTimeMode { get; } // 0x00000001818FFCC0-0x00000001818FFCE0 
		internal IFormatProvider FormatProvider { get; } // 0x00000001818FFCE0-0x00000001818FFD00 
	
		// Constructors
		protected DataStorage(DataColumn column, Type type, object defaultValue, StorageType storageType); // 0x00000001818FFC30-0x00000001818FFCC0
		protected DataStorage(DataColumn column, Type type, object defaultValue, object nullValue, StorageType storageType); // 0x00000001818FFA70-0x00000001818FFAA0
		protected DataStorage(DataColumn column, Type type, object defaultValue, object nullValue, bool isICloneable, StorageType storageType); // 0x00000001818FFAA0-0x00000001818FFC30
		static DataStorage(); // 0x00000001818FEA90-0x00000001818FFA70
	
		// Methods
		public virtual object Aggregate(int[] recordNos, AggregateType kind); // 0x00000001818FC870-0x00000001818FC920
		public object AggregateCount(int[] recordNos); // 0x00000001818FC7E0-0x00000001818FC870
		protected int CompareBits(int recordNo1, int recordNo2); // 0x00000001818FC920-0x00000001818FC9A0
		public abstract int Compare(int recordNo1, int recordNo2);
		public abstract int CompareValueTo(int recordNo1, object value);
		public virtual object ConvertValue(object value); // 0x0000000180A68C50-0x0000000180A68C60
		protected void CopyBits(int srcRecordNo, int dstRecordNo); // 0x00000001818FCA40-0x00000001818FCA90
		public abstract void Copy(int recordNo1, int recordNo2);
		public abstract object Get(int recordNo);
		protected object GetBits(int recordNo); // 0x00000001818FDF10-0x00000001818FDF50
		public virtual int GetStringLength(int record); // 0x00000001818FE140-0x00000001818FE150
		protected bool HasValue(int recordNo); // 0x00000001818FE290-0x00000001818FE2C0
		public virtual bool IsNull(int recordNo); // 0x00000001818FE5F0-0x00000001818FE610
		public abstract void Set(int recordNo, object value);
		protected void SetNullBit(int recordNo, bool flag); // 0x00000001818FEA50-0x00000001818FEA70
		public virtual void SetCapacity(int capacity); // 0x00000001818FE9C0-0x00000001818FEA50
		public abstract object ConvertXmlToObject(string s);
		public virtual object ConvertXmlToObject(XmlReader xmlReader, XmlRootAttribute xmlAttrib); // 0x00000001818FC9F0-0x00000001818FCA40
		public abstract string ConvertObjectToXml(object value);
		public virtual void ConvertObjectToXml(object value, XmlWriter xmlWriter, XmlRootAttribute xmlAttrib); // 0x00000001818FC9A0-0x00000001818FC9F0
		public static DataStorage CreateStorage(DataColumn column, Type dataType, StorageType typeCode); // 0x00000001818FCAB0-0x00000001818FDE80
		internal static StorageType GetStorageType(Type dataType); // 0x00000001818FDFE0-0x00000001818FE140
		internal static Type GetTypeStorage(StorageType storageType); // 0x00000001818FE150-0x00000001818FE1C0
		internal static bool IsTypeCustomType(Type type); // 0x00000001818FE960-0x00000001818FE9C0
		internal static bool IsTypeCustomType(StorageType typeCode); // 0x00000001818FE950-0x00000001818FE960
		internal static bool IsSqlType(StorageType storageType); // 0x00000001818FE940-0x00000001818FE950
		public static bool IsSqlType(Type dataType); // 0x00000001818FE810-0x00000001818FE940
		private static bool DetermineIfValueType(StorageType typeCode, Type dataType); // 0x00000001818FDE80-0x00000001818FDF10
		internal static void ImplementsInterfaces(StorageType typeCode, Type dataType, out bool sqlType, out bool nullable, out bool xmlSerializable, out bool changeTracking, out bool revertibleChangeTracking); // 0x00000001818FE360-0x00000001818FE480
		private static Tuple<bool, bool, bool, bool> InspectTypeForInterfaces(Type dataType); // 0x00000001818FE480-0x00000001818FE5F0
		internal static bool ImplementsINullableValue(StorageType typeCode, Type dataType); // 0x00000001818FE2C0-0x00000001818FE360
		public static bool IsObjectNull(object value); // 0x00000001818FE610-0x00000001818FE750
		public static bool IsObjectSqlNull(object value); // 0x00000001818FE750-0x00000001818FE810
		internal object GetEmptyStorageInternal(int recordCount); // 0x00000001818FDF50-0x00000001818FDF70
		internal void CopyValueInternal(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818FCA90-0x00000001818FCAB0
		internal void SetStorageInternal(object store, BitArray nullbits); // 0x00000001818FEA70-0x00000001818FEA90
		protected abstract object GetEmptyStorage(int recordCount);
		protected abstract void CopyValue(int record, object store, BitArray nullbits, int storeIndex);
		protected abstract void SetStorage(object store, BitArray nullbits);
		protected void SetNullStorage(BitArray nullbits); // 0x0000000180378110-0x0000000180378120
		internal static Type GetType(string value); // 0x00000001818FE1C0-0x00000001818FE290
		internal static string GetQualifiedName(Type type); // 0x00000001818FDF70-0x00000001818FDFE0
	}
}
