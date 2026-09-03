/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[Serializable]
	[DefaultProperty("DataSetName")]
	[ToolboxItem("Microsoft.VSDesigner.Data.VS.DataSetToolboxItem, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[XmlRoot("DataSet")]
	[XmlSchemaProvider("GetDataSetSchema")]
	public class DataSet : MarshalByValueComponent, IXmlSerializable, ISerializable // TypeDefIndex: 11203
	{
		// Fields
		private DataViewManager _defaultViewManager; // 0x20
		private readonly DataTableCollection _tableCollection; // 0x28
		private readonly DataRelationCollection _relationCollection; // 0x30
		internal PropertyCollection _extendedProperties; // 0x38
		private string _dataSetName; // 0x40
		private string _datasetPrefix; // 0x48
		internal string _namespaceURI; // 0x50
		private bool _enforceConstraints; // 0x58
		private bool _caseSensitive; // 0x59
		private CultureInfo _culture; // 0x60
		private bool _cultureUserSet; // 0x68
		internal bool _fInReadXml; // 0x69
		internal bool _fInLoadDiffgram; // 0x6A
		internal bool _fTopLevelTable; // 0x6B
		internal bool _fInitInProgress; // 0x6C
		internal bool _fEnableCascading; // 0x6D
		internal bool _fIsSchemaLoading; // 0x6E
		internal string _mainTableName; // 0x70
		private SerializationFormat _remotingFormat; // 0x78
		private object _defaultViewManagerLock; // 0x80
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x88
		private static XmlSchemaComplexType s_schemaTypeForWSDL; // 0x08
		internal bool _useDataSetSchemaOnly; // 0x8C
		internal bool _udtIsWrapped; // 0x8D
		[CompilerGenerated]
		private PropertyChangedEventHandler PropertyChanging; // 0x90
		[CompilerGenerated]
		private MergeFailedEventHandler MergeFailed; // 0x98
		[CompilerGenerated]
		private DataRowCreatedEventHandler DataRowCreated; // 0xA0
		[CompilerGenerated]
		private DataSetClearEventhandler ClearFunctionCalled; // 0xA8
	
		// Properties
		[DefaultValue(SerializationFormat.Xml)]
		public SerializationFormat RemotingFormat { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x0000000181854F30-0x0000000181854FF0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual SchemaSerializationMode SchemaSerializationMode { get; } // 0x0000000180472790-0x00000001804727A0 
		[DefaultValue(false)]
		public bool CaseSensitive { get; set; } // 0x00000001802E7880-0x00000001802E7890 0x00000001818543B0-0x0000000181854640
		[DefaultValue(true)]
		public bool EnforceConstraints { get; set; } // 0x0000000181424750-0x0000000181424760 0x00000001818547B0-0x00000001818548F0
		[DefaultValue("")]
		public string DataSetName { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181854640-0x00000001818547B0
		[DefaultValue("")]
		public string Namespace { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x0000000181854A50-0x0000000181854E30
		[DefaultValue("")]
		public string Prefix { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000181854E30-0x0000000181854F30
		[Browsable(false)]
		public PropertyCollection ExtendedProperties { get; } // 0x0000000181854340-0x00000001818543B0 
		public CultureInfo Locale { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001818548F0-0x0000000181854A50
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ISite Site { get; } // 0x0000000180377550-0x0000000180377560 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DataRelationCollection Relations { get; } // 0x000000018031E110-0x000000018031E120 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DataTableCollection Tables { get; } // 0x000000018033D240-0x000000018033D250 
		internal string MainTableName { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		internal int ObjectID { get; } // 0x000000018033D620-0x000000018033D630 
	
		// Constructors
		public DataSet(); // 0x0000000181853CF0-0x0000000181853F60
		public DataSet(string dataSetName); // 0x0000000181854310-0x0000000181854340
		protected DataSet(SerializationInfo info, StreamingContext context); // 0x0000000181854140-0x0000000181854310
		protected DataSet(SerializationInfo info, StreamingContext context, bool ConstructSchema); // 0x0000000181853F60-0x0000000181854140
	
		// Methods
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018184C160-0x000000018184C190
		protected virtual void InitializeDerivedDataSet(); // 0x00000001802E76C0-0x00000001802E76D0
		private void SerializeDataSet(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat); // 0x0000000181851810-0x0000000181851E70
		internal void DeserializeDataSet(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat, SchemaSerializationMode schemaSerializationMode); // 0x000000018184ACF0-0x000000018184AEC0
		private void DeserializeDataSetSchema(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat, SchemaSerializationMode schemaSerializationMode); // 0x000000018184A820-0x000000018184ACF0
		private void DeserializeDataSetData(SerializationInfo info, StreamingContext context, SerializationFormat remotingFormat); // 0x000000018184A3E0-0x000000018184A590
		private void SerializeDataSetProperties(SerializationInfo info, StreamingContext context); // 0x0000000181851670-0x0000000181851810
		private void DeserializeDataSetProperties(SerializationInfo info, StreamingContext context); // 0x000000018184A590-0x000000018184A820
		private void SerializeRelations(SerializationInfo info, StreamingContext context); // 0x0000000181851E70-0x00000001818523C0
		private void DeserializeRelations(SerializationInfo info, StreamingContext context); // 0x000000018184AEC0-0x000000018184B5A0
		internal void FailedEnableConstraints(); // 0x000000018184BCD0-0x000000018184BD10
		internal void RestoreEnforceConstraints(bool value); // 0x0000000181424790-0x00000001814247A0
		internal void EnableConstraints(); // 0x000000018184B5A0-0x000000018184BB70
		internal void SetLocaleValue(CultureInfo value, bool userSet); // 0x00000001818523C0-0x0000000181852AE0
		internal bool ShouldSerializeLocale(); // 0x0000000180B25580-0x0000000180B25590
		public void Clear(); // 0x0000000181849250-0x0000000181849410
		public virtual DataSet Clone(); // 0x0000000181849410-0x000000018184A3E0
		internal int EstimatedXmlStringSize(); // 0x000000018184BB70-0x000000018184BCD0
		internal string GetRemotingDiffGram(DataTable table); // 0x000000018184C190-0x000000018184C2C0
		internal string GetXmlSchemaForRemoting(DataTable table); // 0x000000018184C2C0-0x000000018184C460
		public void ReadXmlSchema(XmlReader reader); // 0x000000018184E5E0-0x000000018184E5F0
		internal void ReadXmlSchema(XmlReader reader, bool denyResolving); // 0x000000018184E5F0-0x000000018184EEF0
		internal bool MoveToElement(XmlReader reader, int depth); // 0x0000000181835120-0x0000000181835200
		private static void MoveToElement(XmlReader reader); // 0x000000018184CD20-0x000000018184CDB0
		internal void ReadEndElement(XmlReader reader); // 0x0000000181836C30-0x0000000181836CF0
		internal void ReadXSDSchema(XmlReader reader, bool denyResolving); // 0x000000018184D1B0-0x000000018184D470
		internal void ReadXDRSchema(XmlReader reader); // 0x000000018184D040-0x000000018184D1B0
		private void WriteXmlSchema(XmlWriter writer, SchemaFormat schemaFormat, Converter<Type, string> multipleTargetConverter); // 0x0000000181853900-0x0000000181853B10
		public XmlReadMode ReadXml(XmlReader reader); // 0x0000000181851400-0x0000000181851410
		internal XmlReadMode ReadXml(XmlReader reader, bool denyResolving); // 0x0000000181850120-0x0000000181851400
		internal void InferSchema(XmlDocument xdoc, string[] excludedNamespaces, XmlReadMode mode); // 0x000000018184C460-0x000000018184C7A0
		private bool IsEmpty(); // 0x000000018184C7A0-0x000000018184C990
		private void ReadXmlDiffgram(XmlReader reader); // 0x000000018184D470-0x000000018184E5E0
		public XmlReadMode ReadXml(XmlReader reader, XmlReadMode mode); // 0x000000018184F240-0x000000018184F260
		internal XmlReadMode ReadXml(XmlReader reader, XmlReadMode mode, bool denyResolving); // 0x000000018184F260-0x0000000181850120
		public void WriteXml(XmlWriter writer, XmlWriteMode mode); // 0x0000000181853B10-0x0000000181853CF0
		public void Merge(DataSet dataSet); // 0x000000018184C990-0x000000018184CAE0
		public void Merge(DataSet dataSet, bool preserveChanges, MissingSchemaAction missingSchemaAction); // 0x000000018184CAE0-0x000000018184CD20
		protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent); // 0x00000001813A8540-0x00000001813A8570
		internal void OnMergeFailed(MergeFailedEventArgs mfevent); // 0x000000018184CDE0-0x000000018184CE60
		internal void RaiseMergeFailed(DataTable table, string conflict, MissingSchemaAction missingSchemaAction); // 0x000000018184CEB0-0x000000018184CFC0
		internal void OnDataRowCreated(DataRow row); // 0x000000018184CDB0-0x000000018184CDE0
		internal void OnClearFunctionCalled(DataTable table); // 0x000000018136F1D0-0x000000018136F200
		protected internal virtual void OnRemoveTable(DataTable table); // 0x00000001802E76C0-0x00000001802E76D0
		internal void OnRemovedTable(DataTable table); // 0x000000018184CE80-0x000000018184CEB0
		protected virtual void OnRemoveRelation(DataRelation relation); // 0x00000001802E76C0-0x00000001802E76D0
		internal void OnRemoveRelationHack(DataRelation relation); // 0x000000018184CE60-0x000000018184CE80
		protected internal void RaisePropertyChanging(string name); // 0x000000018184CFC0-0x000000018184D040
		internal DataTable[] TopLevelTables(); // 0x0000000181852E00-0x0000000181852E10
		internal DataTable[] TopLevelTables(bool forSchema); // 0x0000000181852E10-0x0000000181853070
		public virtual void Reset(); // 0x0000000181851410-0x0000000181851670
		internal bool ValidateCaseConstraint(); // 0x0000000181853070-0x0000000181853470
		internal bool ValidateLocaleConstraint(); // 0x0000000181853470-0x0000000181853900
		internal DataTable FindTable(DataTable baseTable, PropertyDescriptor[] props, int propStart); // 0x000000018184BD10-0x000000018184BE90
		protected virtual void ReadXmlSerializable(XmlReader reader); // 0x000000018184EEF0-0x000000018184F240
		public static XmlSchemaComplexType GetDataSetSchema(XmlSchemaSet schemaSet); // 0x000000018184BE90-0x000000018184C160
		XmlSchema IXmlSerializable.GetSchema(); // 0x0000000181852AE0-0x0000000181852C60
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x0000000181852C60-0x0000000181852DB0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x0000000181852DB0-0x0000000181852E00
	}
}
