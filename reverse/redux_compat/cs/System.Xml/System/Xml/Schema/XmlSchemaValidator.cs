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
using System.Text;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public sealed class XmlSchemaValidator // TypeDefIndex: 7263
	{
		// Fields
		private XmlSchemaSet schemaSet; // 0x10
		private XmlSchemaValidationFlags validationFlags; // 0x18
		private int startIDConstraint; // 0x1C
		private bool isRoot; // 0x20
		private bool rootHasSchema; // 0x21
		private bool attrValid; // 0x22
		private bool checkEntity; // 0x23
		private SchemaInfo compiledSchemaInfo; // 0x28
		private IDtdInfo dtdSchemaInfo; // 0x30
		private Hashtable validatedNamespaces; // 0x38
		private HWStack validationStack; // 0x40
		private ValidationState context; // 0x48
		private ValidatorState currentState; // 0x50
		private Hashtable attPresence; // 0x58
		private SchemaAttDef wildID; // 0x60
		private Hashtable IDs; // 0x68
		private IdRefNode idRefListHead; // 0x70
		private XmlQualifiedName contextQName; // 0x78
		private string NsXs; // 0x80
		private string NsXsi; // 0x88
		private string NsXmlNs; // 0x90
		private string NsXml; // 0x98
		private XmlSchemaObject partialValidationType; // 0xA0
		private StringBuilder textValue; // 0xA8
		private ValidationEventHandler eventHandler; // 0xB0
		private object validationEventSender; // 0xB8
		private XmlNameTable nameTable; // 0xC0
		private IXmlLineInfo positionInfo; // 0xC8
		private IXmlLineInfo dummyPositionInfo; // 0xD0
		private XmlResolver xmlResolver; // 0xD8
		private Uri sourceUri; // 0xE0
		private string sourceUriString; // 0xE8
		private IXmlNamespaceResolver nsResolver; // 0xF0
		private XmlSchemaContentProcessing processContents; // 0xF8
		private string xsiTypeString; // 0x100
		private string xsiNilString; // 0x108
		private string xsiSchemaLocationString; // 0x110
		private string xsiNoNamespaceSchemaLocationString; // 0x118
		private static readonly XmlSchemaDatatype dtQName; // 0x00
		private static readonly XmlSchemaDatatype dtCDATA; // 0x08
		private static readonly XmlSchemaDatatype dtStringArray; // 0x10
		private static XmlSchemaParticle[] EmptyParticleArray; // 0x18
		private static XmlSchemaAttribute[] EmptyAttributeArray; // 0x20
		private XmlCharType xmlCharType; // 0x120
		internal static bool[,] ValidStates; // 0x28
		private static string[] MethodNames; // 0x30
	
		// Properties
		public XmlResolver XmlResolver { set; } // 0x00000001806CCE00-0x00000001806CCE20
		public IXmlLineInfo LineInfoProvider { set; } // 0x00000001819FEAF0-0x00000001819FEB20
		public Uri SourceUri { set; } // 0x00000001819FEB20-0x00000001819FEB80
		public object ValidationEventSender { set; } // 0x00000001806CCDE0-0x00000001806CCE00
		internal XmlSchemaSet SchemaSet { get; } // 0x0000000180377550-0x0000000180377560 
		internal XmlSchemaValidationFlags ValidationFlags { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal XmlSchemaContentType CurrentContentType { get; } // 0x00000001819FE910-0x00000001819FE950 
		private bool StrictlyAssessed { get; } // 0x00000001819FEA00-0x00000001819FEA40 
		private bool HasSchema { get; } // 0x00000001819FE970-0x00000001819FE9C0 
		private bool HasIdentityConstraints { get; } // 0x00000001819FE950-0x00000001819FE970 
		internal bool ProcessIdentityConstraints { get; } // 0x00000001819FE9C0-0x00000001819FE9D0 
		internal bool ReportValidationWarnings { get; } // 0x00000001819FE9F0-0x00000001819FEA00 
		internal bool ProcessSchemaHints { get; } // 0x00000001819FE9D0-0x00000001819FE9F0 
	
		// Events
		public event ValidationEventHandler ValidationEventHandler {
			add; // 0x00000001819FE860-0x00000001819FE910
			remove; // 0x00000001819FEA40-0x00000001819FEAF0
		}
	
		// Constructors
		public XmlSchemaValidator(XmlNameTable nameTable, XmlSchemaSet schemas, IXmlNamespaceResolver namespaceResolver, XmlSchemaValidationFlags validationFlags); // 0x00000001819FE480-0x00000001819FE860
		static XmlSchemaValidator(); // 0x00000001819FDFE0-0x00000001819FE480
	
		// Methods
		private void Init(); // 0x00000001819F7EF0-0x00000001819F8330
		private void Reset(); // 0x00000001819FAAB0-0x00000001819FAB70
		public void AddSchema(XmlSchema schema); // 0x00000001819F26B0-0x00000001819F2AE0
		public void Initialize(); // 0x00000001819F8330-0x00000001819F8490
		public void Initialize(XmlSchemaObject partialValidationType); // 0x00000001819F8490-0x00000001819F8770
		public void ValidateElement(string localName, string namespaceUri, XmlSchemaInfo schemaInfo, string xsiType, string xsiNil, string xsiSchemaLocation, string xsiNoNamespaceSchemaLocation); // 0x00000001819FD260-0x00000001819FD780
		public object ValidateAttribute(string localName, string namespaceUri, XmlValueGetter attributeValue, XmlSchemaInfo schemaInfo); // 0x00000001819FCC60-0x00000001819FCCE0
		private object ValidateAttribute(string lName, string ns, XmlValueGetter attributeValueGetter, string attributeStringValue, XmlSchemaInfo schemaInfo); // 0x00000001819FC1D0-0x00000001819FCC60
		public void ValidateEndOfAttributes(XmlSchemaInfo schemaInfo); // 0x00000001819FD790-0x00000001819FD860
		public void ValidateText(XmlValueGetter elementValue); // 0x00000001819FD8C0-0x00000001819FD930
		private void ValidateText(string elementStringValue, XmlValueGetter elementValueGetter); // 0x00000001819FD930-0x00000001819FDD20
		public void ValidateWhitespace(XmlValueGetter elementValue); // 0x00000001819FDF70-0x00000001819FDFE0
		private void ValidateWhitespace(string elementStringValue, XmlValueGetter elementValueGetter); // 0x00000001819FDD20-0x00000001819FDF70
		public object ValidateEndElement(XmlSchemaInfo schemaInfo); // 0x00000001819FD780-0x00000001819FD790
		public void SkipToEndElement(XmlSchemaInfo schemaInfo); // 0x00000001819FB620-0x00000001819FB860
		public void EndValidation(); // 0x00000001819F6910-0x00000001819F6B40
		internal void GetUnspecifiedDefaultAttributes(ArrayList defaultAttributes, bool createNodeData); // 0x00000001819F77C0-0x00000001819F7EF0
		internal void SetDtdSchemaInfo(IDtdInfo dtdSchemaInfo); // 0x00000001819FB600-0x00000001819FB620
		internal string GetConcatenatedValue(); // 0x00000001819F70D0-0x00000001819F7100
		private object InternalValidateEndElement(XmlSchemaInfo schemaInfo, object typedValue); // 0x00000001819F8770-0x00000001819F8DB0
		private void ProcessSchemaLocations(string xsiSchemaLocation, string xsiNoNamespaceSchemaLocation); // 0x00000001819FA1B0-0x00000001819FA490
		private object ValidateElementContext(XmlQualifiedName elementName, out bool invalidElementInContext); // 0x00000001819FCCE0-0x00000001819FD260
		private XmlSchemaElement GetSubstitutionGroupHead(XmlQualifiedName member); // 0x00000001819F7510-0x00000001819F7750
		private object ValidateAtomicValue(string stringValue, out XmlSchemaSimpleType memberType); // 0x00000001819FBEC0-0x00000001819FC1D0
		private object ValidateAtomicValue(object parsedValue, out XmlSchemaSimpleType memberType); // 0x00000001819FBAA0-0x00000001819FBEC0
		private string GetTypeName(SchemaDeclBase decl); // 0x00000001819F7750-0x00000001819F77C0
		private void SaveTextValue(object value); // 0x00000001819FAB70-0x00000001819FABC0
		private void Push(XmlQualifiedName elementName); // 0x00000001819FA7C0-0x00000001819FA9D0
		private void Pop(); // 0x00000001819F9210-0x00000001819F9380
		private SchemaElementDecl FastGetElementDecl(XmlQualifiedName elementName, object particle); // 0x00000001819F6D70-0x00000001819F70A0
		private SchemaElementDecl CheckXsiTypeAndNil(SchemaElementDecl elementDecl, string xsiType, string xsiNil, ref bool declFound); // 0x00000001819F4160-0x00000001819F48A0
		private void ThrowDeclNotFoundWarningOrError(bool declFound); // 0x00000001819FB860-0x00000001819FBAA0
		private void CheckElementProperties(); // 0x00000001819F33C0-0x00000001819F34B0
		private void ValidateStartElementIdentityConstraints(); // 0x00000001819FD860-0x00000001819FD8C0
		private SchemaAttDef CheckIsXmlAttribute(XmlQualifiedName attQName); // 0x00000001819F3900-0x00000001819F3A90
		private void AddXmlNamespaceSchema(); // 0x00000001819F2AE0-0x00000001819F2BC0
		internal object CheckMixedValueConstraint(string elementValue); // 0x00000001819F3A90-0x00000001819F3BA0
		private void LoadSchema(string uri, string url); // 0x00000001819F8DB0-0x00000001819F9210
		internal void RecompileSchemaSet(); // 0x00000001819FAA40-0x00000001819FAAB0
		private void ProcessTokenizedType(XmlTokenizedType ttype, string name, bool attrValue); // 0x00000001819FA490-0x00000001819FA7C0
		private object CheckAttributeValue(object value, SchemaAttDef attdef); // 0x00000001819F3110-0x00000001819F33C0
		private object CheckElementValue(string stringValue); // 0x00000001819F34B0-0x00000001819F37D0
		private void CheckTokenizedTypes(XmlSchemaDatatype dtype, object typedValue, bool attrValue); // 0x00000001819F3FD0-0x00000001819F4160
		private object FindId(string name); // 0x00000001819F70A0-0x00000001819F70D0
		private void CheckForwardRefs(); // 0x00000001819F37D0-0x00000001819F3900
		private void CheckStateTransition(ValidatorState toState, string methodName); // 0x00000001819F3D50-0x00000001819F3FD0
		private void ClearPSVI(); // 0x00000001819F48A0-0x00000001819F4900
		private void CheckRequiredAttributes(SchemaElementDecl currentElementDecl); // 0x00000001819F3BA0-0x00000001819F3D50
		private XmlSchemaElement GetSchemaElement(); // 0x00000001819F73A0-0x00000001819F7510
		internal string GetDefaultAttributePrefix(string attributeNS); // 0x00000001819F7100-0x00000001819F73A0
		private void AddIdentityConstraints(); // 0x00000001819F20B0-0x00000001819F26B0
		private void ElementIdentityConstraints(); // 0x00000001819F4F50-0x00000001819F52F0
		private void AttributeIdentityConstraints(string name, string ns, object obj, string sobj, XmlSchemaDatatype datatype); // 0x00000001819F2BC0-0x00000001819F2F10
		private void EndElementIdentityConstraints(object typedValue, string stringValue, XmlSchemaDatatype datatype); // 0x00000001819F5CF0-0x00000001819F6910
		internal static void ElementValidationError(XmlQualifiedName name, ValidationState context, ValidationEventHandler eventHandler, object sender, string sourceUri, int lineNo, int linePos, XmlSchemaSet schemaSet); // 0x00000001819F52F0-0x00000001819F5CF0
		internal static void CompleteValidationError(ValidationState context, ValidationEventHandler eventHandler, object sender, string sourceUri, int lineNo, int linePos, XmlSchemaSet schemaSet); // 0x00000001819F4900-0x00000001819F4F50
		internal static string PrintExpectedElements(ArrayList expected, bool getParticles); // 0x00000001819F9380-0x00000001819F98F0
		private static string PrintNames(ArrayList expected); // 0x00000001819F9F00-0x00000001819FA080
		private static void PrintNamesWithNS(ArrayList expected, StringBuilder builder); // 0x00000001819F98F0-0x00000001819F9F00
		private static void EnumerateAny(StringBuilder builder, string namespaces); // 0x00000001819F6B40-0x00000001819F6D70
		internal static string QNameString(string localName, string ns); // 0x00000001819FA9D0-0x00000001819FAA40
		internal static string BuildElementName(XmlQualifiedName qname); // 0x00000001819F30A0-0x00000001819F3110
		internal static string BuildElementName(string localName, string ns); // 0x00000001819F2F10-0x00000001819F30A0
		private void ProcessEntity(string name); // 0x00000001819FA080-0x00000001819FA1B0
		private void SendValidationEvent(string code); // 0x00000001819FB060-0x00000001819FB080
		private void SendValidationEvent(string code, string[] args); // 0x00000001819FB180-0x00000001819FB2A0
		private void SendValidationEvent(string code, string arg); // 0x00000001819FB080-0x00000001819FB180
		private void SendValidationEvent(string code, string arg1, string arg2); // 0x00000001819FACF0-0x00000001819FAE60
		private void SendValidationEvent(string code, string[] args, Exception innerException, XmlSeverityType severity); // 0x00000001819FB390-0x00000001819FB4E0
		private void SendValidationEvent(string code, string[] args, Exception innerException); // 0x00000001819FABD0-0x00000001819FACF0
		private void SendValidationEvent(XmlSchemaValidationException e); // 0x00000001819FABC0-0x00000001819FABD0
		private void SendValidationEvent(XmlSchemaException e); // 0x00000001819FB2A0-0x00000001819FB390
		private void SendValidationEvent(string code, string msg, XmlSeverityType severity); // 0x00000001819FB4E0-0x00000001819FB600
		private void SendValidationEvent(XmlSchemaValidationException e, XmlSeverityType severity); // 0x00000001819FAE60-0x00000001819FAFA0
		internal static void SendValidationEvent(ValidationEventHandler eventHandler, object sender, XmlSchemaValidationException e, XmlSeverityType severity); // 0x00000001819FAFA0-0x00000001819FB060
	}
}
