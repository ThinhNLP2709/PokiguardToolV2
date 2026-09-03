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
	internal static class ExceptionBuilder // TypeDefIndex: 11202
	{
		// Methods
		private static void TraceException(string trace, Exception e); // 0x000000018185B520-0x000000018185B5A0
		internal static Exception TraceExceptionAsReturnValue(Exception e); // 0x000000018185B310-0x000000018185B3C0
		internal static Exception TraceExceptionForCapture(Exception e); // 0x000000018185B3C0-0x000000018185B470
		internal static Exception TraceExceptionWithoutRethrow(Exception e); // 0x000000018185B470-0x000000018185B520
		internal static Exception _Argument(string error); // 0x000000018185BD70-0x000000018185BE50
		internal static Exception _Argument(string error, Exception innerException); // 0x000000018185BC80-0x000000018185BD70
		private static Exception _ArgumentNull(string paramName, string msg); // 0x000000018185BAA0-0x000000018185BB90
		internal static Exception _ArgumentOutOfRange(string paramName, string msg); // 0x000000018185BB90-0x000000018185BC80
		private static Exception _IndexOutOfRange(string error); // 0x000000018185C2B0-0x000000018185C390
		private static Exception _InvalidOperation(string error); // 0x000000018185C550-0x000000018185C630
		private static Exception _InvalidEnumArgumentException(string error); // 0x000000018185C470-0x000000018185C550
		private static Exception _InvalidEnumArgumentException<T>(T value);
		private static void ThrowDataException(string error, Exception innerException); // 0x000000018185B210-0x000000018185B280
		private static Exception _Data(string error); // 0x000000018185BF30-0x000000018185C010
		private static Exception _Constraint(string error); // 0x000000018185BE50-0x000000018185BF30
		private static Exception _InvalidConstraint(string error); // 0x000000018185C390-0x000000018185C470
		private static Exception _DeletedRowInaccessible(string error); // 0x000000018185C010-0x000000018185C0F0
		private static Exception _DuplicateName(string error); // 0x000000018185C0F0-0x000000018185C1D0
		private static Exception _InRowChangingEvent(string error); // 0x000000018185C1D0-0x000000018185C2B0
		private static Exception _NoNullAllowed(string error); // 0x000000018185C630-0x000000018185C710
		private static Exception _ReadOnly(string error); // 0x000000018185C710-0x000000018185C7F0
		private static Exception _RowNotInTable(string error); // 0x000000018185C7F0-0x000000018185C8D0
		private static Exception _VersionNotFound(string error); // 0x000000018185C8D0-0x000000018185C9B0
		public static Exception ArgumentNull(string paramName); // 0x0000000181855270-0x00000001818553B0
		public static Exception ArgumentOutOfRange(string paramName); // 0x00000001818553B0-0x00000001818554F0
		public static Exception BadObjectPropertyAccess(string error); // 0x00000001818556D0-0x0000000181855750
		public static Exception TypeNotAllowed(Type type); // 0x000000018185B5A0-0x000000018185B640
		public static Exception CaseInsensitiveNameConflict(string name); // 0x0000000181856640-0x00000001818566C0
		public static Exception NamespaceNameConflict(string name); // 0x0000000181859320-0x00000001818593A0
		public static Exception InvalidOffsetLength(); // 0x0000000181858630-0x0000000181858670
		public static Exception ColumnNotInTheTable(string column, string table); // 0x0000000181856840-0x00000001818568D0
		public static Exception ColumnNotInAnyTable(); // 0x0000000181856800-0x0000000181856840
		public static Exception ColumnOutOfRange(int index); // 0x00000001818568D0-0x0000000181856980
		public static Exception ColumnOutOfRange(string column); // 0x0000000181856980-0x0000000181856A00
		public static Exception CannotAddColumn1(string column); // 0x00000001818559D0-0x0000000181855A50
		public static Exception CannotAddColumn2(string column); // 0x0000000181855A50-0x0000000181855AD0
		public static Exception CannotAddColumn3(); // 0x0000000181855AD0-0x0000000181855B10
		public static Exception CannotAddColumn4(string column); // 0x0000000181855B10-0x0000000181855B90
		public static Exception CannotAddDuplicate(string column); // 0x0000000181855C90-0x0000000181855D10
		public static Exception CannotAddDuplicate2(string table); // 0x0000000181855B90-0x0000000181855C10
		public static Exception CannotAddDuplicate3(string table); // 0x0000000181855C10-0x0000000181855C90
		public static Exception CannotRemoveColumn(); // 0x0000000181855FA0-0x0000000181855FE0
		public static Exception CannotRemovePrimaryKey(); // 0x0000000181856100-0x0000000181856140
		public static Exception CannotRemoveChildKey(string relation); // 0x0000000181855F20-0x0000000181855FA0
		public static Exception CannotRemoveConstraint(string constraint, string table); // 0x0000000181855FE0-0x0000000181856070
		public static Exception CannotRemoveExpression(string column, string expression); // 0x0000000181856070-0x0000000181856100
		public static Exception AddPrimaryKeyConstraint(); // 0x0000000181855150-0x0000000181855190
		public static Exception NoConstraintName(); // 0x0000000181859530-0x0000000181859570
		public static Exception ConstraintViolation(string constraint); // 0x0000000181856D40-0x0000000181856DC0
		public static string KeysToString(object[] keys); // 0x0000000181858CD0-0x0000000181858DE0
		public static string UniqueConstraintViolationText(DataColumn[] columns, object[] values); // 0x000000018185B780-0x000000018185BA20
		public static Exception ConstraintViolation(DataColumn[] columns, object[] values); // 0x0000000181856D20-0x0000000181856D40
		public static Exception ConstraintOutOfRange(int index); // 0x0000000181856BF0-0x0000000181856CA0
		public static Exception DuplicateConstraint(string constraint); // 0x0000000181857520-0x00000001818575A0
		public static Exception DuplicateConstraintName(string constraint); // 0x0000000181857420-0x00000001818574A0
		public static Exception NeededForForeignKeyConstraint(UniqueConstraint key, ForeignKeyConstraint fk); // 0x00000001818593A0-0x0000000181859470
		public static Exception UniqueConstraintViolation(); // 0x000000018185BA20-0x000000018185BA60
		public static Exception ConstraintForeignTable(); // 0x0000000181856BB0-0x0000000181856BF0
		public static Exception ConstraintParentValues(); // 0x0000000181856CA0-0x0000000181856CE0
		public static Exception ConstraintAddFailed(DataTable table); // 0x0000000181856B20-0x0000000181856BB0
		public static Exception ConstraintRemoveFailed(); // 0x0000000181856CE0-0x0000000181856D20
		public static Exception FailedCascadeDelete(string constraint); // 0x0000000181857B40-0x0000000181857BC0
		public static Exception FailedCascadeUpdate(string constraint); // 0x0000000181857BC0-0x0000000181857C40
		public static Exception FailedClearParentTable(string table, string constraint, string childTable); // 0x0000000181857C40-0x0000000181857CE0
		public static Exception ForeignKeyViolation(string constraint, object[] keys); // 0x0000000181857CE0-0x0000000181857D80
		public static Exception RemoveParentRow(ForeignKeyConstraint constraint); // 0x000000018185A410-0x000000018185A4B0
		public static string MaxLengthViolationText(string columnName); // 0x0000000181858EF0-0x0000000181858F60
		public static string NotAllowDBNullViolationText(string columnName); // 0x00000001818596F0-0x0000000181859760
		public static Exception CantAddConstraintToMultipleNestedTable(string tableName); // 0x0000000181856490-0x0000000181856510
		public static Exception AutoIncrementAndExpression(); // 0x00000001818555D0-0x0000000181855610
		public static Exception AutoIncrementAndDefaultValue(); // 0x0000000181855590-0x00000001818555D0
		public static Exception AutoIncrementSeed(); // 0x0000000181855690-0x00000001818556D0
		public static Exception CantChangeDataType(); // 0x0000000181856510-0x0000000181856550
		public static Exception NullDataType(); // 0x00000001818597A0-0x00000001818597E0
		public static Exception ColumnNameRequired(); // 0x00000001818567C0-0x0000000181856800
		public static Exception DefaultValueAndAutoIncrement(); // 0x0000000181857050-0x0000000181857090
		public static Exception DefaultValueDataType(string column, Type defaultType, Type columnType, Exception inner); // 0x0000000181857190-0x00000001818572E0
		public static Exception DefaultValueColumnDataType(string column, Type defaultType, Type columnType, Exception inner); // 0x0000000181857090-0x0000000181857190
		public static Exception ExpressionAndUnique(); // 0x0000000181857A30-0x0000000181857A70
		public static Exception ExpressionAndReadOnly(); // 0x00000001818579F0-0x0000000181857A30
		public static Exception ExpressionAndConstraint(DataColumn column, Constraint constraint); // 0x0000000181857930-0x00000001818579F0
		public static Exception ExpressionInConstraint(DataColumn column); // 0x0000000181857AB0-0x0000000181857B40
		public static Exception ExpressionCircular(); // 0x0000000181857A70-0x0000000181857AB0
		public static Exception NonUniqueValues(string column); // 0x0000000181859670-0x00000001818596F0
		public static Exception NullKeyValues(string column); // 0x00000001818597E0-0x0000000181859860
		public static Exception NullValues(string column); // 0x00000001818598A0-0x00000001818599D0
		public static Exception ReadOnlyAndExpression(); // 0x0000000181859C90-0x0000000181859CD0
		public static Exception ReadOnly(string column); // 0x0000000181859CD0-0x0000000181859D50
		public static Exception UniqueAndExpression(); // 0x000000018185B740-0x000000018185B780
		public static Exception SetFailed(object value, DataColumn column, Type type, Exception innerException); // 0x000000018185AAA0-0x000000018185ABD0
		public static Exception CannotSetToNull(DataColumn column); // 0x0000000181856400-0x0000000181856490
		public static Exception LongerThanMaxLength(DataColumn column); // 0x0000000181858DE0-0x0000000181858E70
		public static Exception CannotSetMaxLength(DataColumn column, int value); // 0x0000000181856210-0x00000001818562E0
		public static Exception CannotSetMaxLength2(DataColumn column); // 0x0000000181856180-0x0000000181856210
		public static Exception CannotSetSimpleContentType(string columnName, Type type); // 0x00000001818562E0-0x0000000181856370
		public static Exception CannotSetSimpleContent(string columnName, Type type); // 0x0000000181856370-0x0000000181856400
		public static Exception CannotChangeNamespace(string columnName); // 0x0000000181855D90-0x0000000181855E10
		public static Exception HasToBeStringType(DataColumn column); // 0x0000000181857F40-0x0000000181857FD0
		public static Exception AutoIncrementCannotSetIfHasData(string typeName); // 0x0000000181855610-0x0000000181855690
		public static Exception INullableUDTwithoutStaticNull(string typeName); // 0x0000000181858050-0x00000001818580D0
		public static Exception IComparableNotImplemented(string typeName); // 0x0000000181857FD0-0x0000000181858050
		public static Exception UDTImplementsIChangeTrackingButnotIRevertible(string typeName); // 0x000000018185B640-0x000000018185B6C0
		public static Exception InvalidDataColumnMapping(Type type); // 0x00000001818583C0-0x0000000181858460
		public static Exception CannotSetDateTimeModeForNonDateTimeColumns(); // 0x0000000181856140-0x0000000181856180
		public static Exception InvalidDateTimeMode(DataSetDateTime mode); // 0x0000000181858460-0x00000001818584A0
		public static Exception CantChangeDateTimeMode(DataSetDateTime oldValue, DataSetDateTime newValue); // 0x0000000181856550-0x0000000181856640
		public static Exception ColumnTypeNotSupported(); // 0x0000000181856A80-0x0000000181856AE0
		public static Exception SetFailed(string name); // 0x000000018185ABD0-0x000000018185AC50
		public static Exception CanNotUse(); // 0x0000000181855950-0x0000000181855990
		public static Exception SetIListObject(); // 0x000000018185AC50-0x000000018185AC90
		public static Exception AddNewNotAllowNull(); // 0x0000000181855110-0x0000000181855150
		public static Exception NotOpen(); // 0x0000000181859760-0x00000001818597A0
		public static Exception CreateChildView(); // 0x0000000181856E90-0x0000000181856ED0
		public static Exception CanNotDelete(); // 0x00000001818557D0-0x0000000181855810
		public static Exception GetElementIndex(int index); // 0x0000000181857E00-0x0000000181857EB0
		public static Exception AddExternalObject(); // 0x00000001818550D0-0x0000000181855110
		public static Exception CanNotClear(); // 0x0000000181855790-0x00000001818557D0
		public static Exception InsertExternalObject(); // 0x0000000181858260-0x00000001818582A0
		public static Exception RemoveExternalObject(); // 0x000000018185A3D0-0x000000018185A410
		public static Exception KeyTableMismatch(); // 0x0000000181858BE0-0x0000000181858C20
		public static Exception KeyNoColumns(); // 0x0000000181858BA0-0x0000000181858BE0
		public static Exception KeyTooManyColumns(int cols); // 0x0000000181858C20-0x0000000181858CD0
		public static Exception KeyDuplicateColumns(string columnName); // 0x0000000181858AA0-0x0000000181858B20
		public static Exception RelationDataSetMismatch(); // 0x0000000181859F50-0x0000000181859F90
		public static Exception ColumnsTypeMismatch(); // 0x0000000181856AE0-0x0000000181856B20
		public static Exception KeyLengthMismatch(); // 0x0000000181858B20-0x0000000181858B60
		public static Exception KeyLengthZero(); // 0x0000000181858B60-0x0000000181858BA0
		public static Exception ForeignRelation(); // 0x0000000181857D80-0x0000000181857DC0
		public static Exception KeyColumnsIdentical(); // 0x0000000181858A60-0x0000000181858AA0
		public static Exception RelationForeignTable(string t1, string t2); // 0x000000018185A050-0x000000018185A0E0
		public static Exception GetParentRowTableMismatch(string t1, string t2); // 0x0000000181857EB0-0x0000000181857F40
		public static Exception SetParentRowTableMismatch(string t1, string t2); // 0x000000018185AC90-0x000000018185AD20
		public static Exception RelationForeignRow(); // 0x000000018185A010-0x000000018185A050
		public static Exception RelationNestedReadOnly(); // 0x000000018185A0E0-0x000000018185A120
		public static Exception TableCantBeNestedInTwoTables(string tableName); // 0x000000018185AE60-0x000000018185AEE0
		public static Exception LoopInNestedRelations(string tableName); // 0x0000000181858E70-0x0000000181858EF0
		public static Exception RelationDoesNotExist(); // 0x0000000181859FD0-0x000000018185A010
		public static Exception ParentOrChildColumnsDoNotHaveDataSet(); // 0x00000001818599D0-0x0000000181859A10
		public static Exception InValidNestedRelation(string childTableName); // 0x00000001818580D0-0x0000000181858150
		public static Exception InvalidParentNamespaceinNestedRelation(string childTableName); // 0x0000000181858670-0x00000001818586F0
		public static Exception RowNotInTheDataSet(); // 0x000000018185A7F0-0x000000018185A830
		public static Exception RowNotInTheTable(); // 0x000000018185A830-0x000000018185A870
		public static Exception EditInRowChanging(); // 0x00000001818577B0-0x00000001818577F0
		public static Exception EndEditInRowChanging(); // 0x0000000181857870-0x00000001818578B0
		public static Exception BeginEditInRowChanging(); // 0x0000000181855750-0x0000000181855790
		public static Exception CancelEditInRowChanging(); // 0x0000000181855990-0x00000001818559D0
		public static Exception DeleteInRowDeleting(); // 0x00000001818572E0-0x0000000181857320
		public static Exception ValueArrayLength(); // 0x000000018185BA60-0x000000018185BAA0
		public static Exception NoCurrentData(); // 0x0000000181859570-0x00000001818595B0
		public static Exception NoOriginalData(); // 0x00000001818595B0-0x00000001818595F0
		public static Exception NoProposedData(); // 0x00000001818595F0-0x0000000181859630
		public static Exception RowRemovedFromTheTable(); // 0x000000018185A920-0x000000018185A960
		public static Exception DeletedRowInaccessible(); // 0x0000000181857320-0x0000000181857360
		public static Exception RowAlreadyDeleted(); // 0x000000018185A570-0x000000018185A5B0
		public static Exception RowEmpty(); // 0x000000018185A670-0x000000018185A6B0
		public static Exception InvalidRowVersion(); // 0x0000000181858830-0x0000000181858870
		public static Exception RowOutOfRange(int index); // 0x000000018185A870-0x000000018185A920
		public static Exception RowInsertTwice(int index, string tableName); // 0x000000018185A730-0x000000018185A7F0
		public static Exception RowInsertMissing(string tableName); // 0x000000018185A6B0-0x000000018185A730
		public static Exception RowAlreadyRemoved(); // 0x000000018185A630-0x000000018185A670
		public static Exception MultipleParents(); // 0x00000001818592A0-0x00000001818592E0
		public static Exception InvalidRowState(DataRowState state); // 0x00000001818587F0-0x0000000181858830
		public static Exception InvalidRowBitPattern(); // 0x00000001818587B0-0x00000001818587F0
		internal static Exception SetDataSetNameToEmpty(); // 0x000000018185AA60-0x000000018185AAA0
		internal static Exception SetDataSetNameConflicting(string name); // 0x000000018185A9E0-0x000000018185AA60
		public static Exception DataSetUnsupportedSchema(string ns); // 0x0000000181856ED0-0x0000000181856F50
		public static Exception MergeMissingDefinition(string obj); // 0x0000000181858F70-0x0000000181858FF0
		public static Exception TablesInDifferentSets(); // 0x000000018185B1D0-0x000000018185B210
		public static Exception RelationAlreadyExists(); // 0x0000000181859D90-0x0000000181859DD0
		public static Exception RowAlreadyInOtherCollection(); // 0x000000018185A5B0-0x000000018185A5F0
		public static Exception RowAlreadyInTheCollection(); // 0x000000018185A5F0-0x000000018185A630
		public static Exception RecordStateRange(); // 0x0000000181859D50-0x0000000181859D90
		public static Exception IndexKeyLength(int length, int keyLength); // 0x0000000181858150-0x0000000181858260
		public static Exception RemovePrimaryKey(DataTable table); // 0x000000018185A4B0-0x000000018185A570
		public static Exception RelationAlreadyInOtherDataSet(); // 0x0000000181859DD0-0x0000000181859E10
		public static Exception RelationAlreadyInTheDataSet(); // 0x0000000181859E10-0x0000000181859E50
		public static Exception RelationNotInTheDataSet(string relation); // 0x000000018185A120-0x000000018185A1A0
		public static Exception RelationOutOfRange(object index); // 0x000000018185A1A0-0x000000018185A250
		public static Exception DuplicateRelation(string relation); // 0x0000000181857620-0x00000001818576A0
		public static Exception RelationTableNull(); // 0x000000018185A350-0x000000018185A390
		public static Exception RelationDataSetNull(); // 0x0000000181859F90-0x0000000181859FD0
		public static Exception RelationTableWasRemoved(); // 0x000000018185A390-0x000000018185A3D0
		public static Exception ParentTableMismatch(); // 0x0000000181859A10-0x0000000181859A50
		public static Exception ChildTableMismatch(); // 0x0000000181856700-0x0000000181856740
		public static Exception EnforceConstraint(); // 0x00000001818578B0-0x00000001818578F0
		public static Exception CaseLocaleMismatch(); // 0x00000001818566C0-0x0000000181856700
		public static Exception CannotChangeCaseLocale(); // 0x0000000181855D10-0x0000000181855D50
		public static Exception CannotChangeCaseLocale(Exception innerException); // 0x0000000181855D50-0x0000000181855D90
		public static Exception InvalidRemotingFormat(SerializationFormat mode); // 0x0000000181858770-0x00000001818587B0
		public static Exception TableForeignPrimaryKey(); // 0x000000018185AEE0-0x000000018185AF20
		public static Exception TableCannotAddToSimpleContent(); // 0x000000018185AE20-0x000000018185AE60
		public static Exception NoTableName(); // 0x0000000181859630-0x0000000181859670
		public static Exception MultipleTextOnlyColumns(); // 0x00000001818592E0-0x0000000181859320
		public static Exception InvalidSortString(string sort); // 0x00000001818588F0-0x0000000181858970
		public static Exception DuplicateTableName(string table); // 0x0000000181857730-0x00000001818577B0
		public static Exception DuplicateTableName2(string table, string ns); // 0x00000001818576A0-0x0000000181857730
		public static Exception SelfnestedDatasetConflictingName(string table); // 0x000000018185A960-0x000000018185A9E0
		public static Exception DatasetConflictingName(string table); // 0x0000000181856F90-0x0000000181857010
		public static Exception TableAlreadyInOtherDataSet(); // 0x000000018185ADA0-0x000000018185ADE0
		public static Exception TableAlreadyInTheDataSet(); // 0x000000018185ADE0-0x000000018185AE20
		public static Exception TableOutOfRange(int index); // 0x000000018185B120-0x000000018185B1D0
		public static Exception TableNotInTheDataSet(string table); // 0x000000018185B0A0-0x000000018185B120
		public static Exception TableInRelation(); // 0x000000018185AFE0-0x000000018185B020
		public static Exception TableInConstraint(DataTable table, Constraint constraint); // 0x000000018185AF20-0x000000018185AFE0
		public static Exception CanNotSerializeDataTableHierarchy(); // 0x0000000181855890-0x00000001818558D0
		public static Exception CanNotRemoteDataTable(); // 0x0000000181855850-0x0000000181855890
		public static Exception CanNotSetRemotingFormat(); // 0x0000000181855910-0x0000000181855950
		public static Exception CanNotSerializeDataTableWithEmptyName(); // 0x00000001818558D0-0x0000000181855910
		public static Exception TableNotFound(string tableName); // 0x000000018185B020-0x000000018185B0A0
		public static Exception AggregateException(AggregateType aggregateType, Type type); // 0x0000000181855190-0x0000000181855270
		public static Exception InvalidStorageType(TypeCode typecode); // 0x0000000181858970-0x0000000181858A20
		public static Exception RangeArgument(int min, int max); // 0x0000000181859BB0-0x0000000181859C90
		public static Exception NullRange(); // 0x0000000181859860-0x00000001818598A0
		public static Exception NegativeMinimumCapacity(); // 0x0000000181859470-0x00000001818594B0
		public static Exception ProblematicChars(char charValue); // 0x0000000181859AD0-0x0000000181859BB0
		public static Exception StorageSetFailed(); // 0x000000018185AD60-0x000000018185ADA0
		public static Exception SimpleTypeNotSupported(); // 0x000000018185AD20-0x000000018185AD60
		public static Exception MissingAttribute(string attribute); // 0x00000001818590C0-0x0000000181859160
		public static Exception MissingAttribute(string element, string attribute); // 0x0000000181859030-0x00000001818590C0
		public static Exception InvalidAttributeValue(string name, string value); // 0x0000000181858330-0x00000001818583C0
		public static Exception AttributeValues(string name, string value1, string value2); // 0x00000001818554F0-0x0000000181855590
		public static Exception ElementTypeNotFound(string name); // 0x00000001818577F0-0x0000000181857870
		public static Exception RelationParentNameMissing(string rel); // 0x000000018185A250-0x000000018185A2D0
		public static Exception RelationChildNameMissing(string rel); // 0x0000000181859ED0-0x0000000181859F50
		public static Exception RelationTableKeyMissing(string rel); // 0x000000018185A2D0-0x000000018185A350
		public static Exception RelationChildKeyMissing(string rel); // 0x0000000181859E50-0x0000000181859ED0
		public static Exception UndefinedDatatype(string name); // 0x000000018185B6C0-0x000000018185B740
		public static Exception DatatypeNotDefined(); // 0x0000000181857010-0x0000000181857050
		public static Exception MismatchKeyLength(); // 0x0000000181858FF0-0x0000000181859030
		public static Exception InvalidField(string name); // 0x0000000181858530-0x00000001818585B0
		public static Exception InvalidSelector(string name); // 0x0000000181858870-0x00000001818588F0
		public static Exception CircularComplexType(string name); // 0x0000000181856740-0x00000001818567C0
		public static Exception CannotInstantiateAbstract(string name); // 0x0000000181855EA0-0x0000000181855F20
		public static Exception InvalidKey(string name); // 0x00000001818585B0-0x0000000181858630
		public static Exception DiffgramMissingTable(string name); // 0x00000001818573A0-0x0000000181857420
		public static Exception DiffgramMissingSQL(); // 0x0000000181857360-0x00000001818573A0
		public static Exception DuplicateConstraintRead(string str); // 0x00000001818574A0-0x0000000181857520
		public static Exception ColumnTypeConflict(string name); // 0x0000000181856A00-0x0000000181856A80
		public static Exception CannotConvert(string name, string type); // 0x0000000181855E10-0x0000000181855EA0
		public static Exception MissingRefer(string name); // 0x0000000181859160-0x0000000181859220
		public static Exception InvalidPrefix(string name); // 0x00000001818586F0-0x0000000181858770
		public static Exception CanNotDeserializeObjectType(); // 0x0000000181855810-0x0000000181855850
		public static Exception IsDataSetAttributeMissingInSchema(); // 0x0000000181858A20-0x0000000181858A60
		public static Exception TooManyIsDataSetAtributeInSchema(); // 0x000000018185B2D0-0x000000018185B310
		public static Exception NestedCircular(string name); // 0x00000001818594B0-0x0000000181859530
		public static Exception MultipleParentRows(string tableQName); // 0x0000000181859220-0x00000001818592A0
		public static Exception PolymorphismNotSupported(string typeName); // 0x0000000181859A50-0x0000000181859AD0
		public static Exception DataTableInferenceNotSupported(); // 0x0000000181856F50-0x0000000181856F90
		internal static void ThrowMultipleTargetConverter(Exception innerException); // 0x000000018185B280-0x000000018185B2D0
		public static Exception DuplicateDeclaration(string name); // 0x00000001818575A0-0x0000000181857620
		public static Exception FoundEntity(); // 0x0000000181857DC0-0x0000000181857E00
		public static Exception MergeFailed(string name); // 0x0000000181858F60-0x0000000181858F70
		public static Exception ConvertFailed(Type type1, Type type2); // 0x0000000181856DC0-0x0000000181856E90
		internal static Exception InvalidDuplicateNamedSimpleTypeDelaration(string stName, string errorStr); // 0x00000001818584A0-0x0000000181858530
		internal static Exception InternalRBTreeError(RBTreeError internalError); // 0x00000001818582A0-0x0000000181858330
		public static Exception EnumeratorModified(); // 0x00000001818578F0-0x0000000181857930
	}
}
