/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Xml;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class XmlNodeConverter : JsonConverter // TypeDefIndex: 10411
	{
		// Fields
		internal static readonly List<IXmlNode> EmptyChildNodes; // 0x00
		private const string TextName = "#text"; // Metadata: 0x006A1001
		private const string CommentName = "#comment"; // Metadata: 0x006A1007
		private const string CDataName = "#cdata-section"; // Metadata: 0x006A1010
		private const string WhitespaceName = "#whitespace"; // Metadata: 0x006A101F
		private const string SignificantWhitespaceName = "#significant-whitespace"; // Metadata: 0x006A102B
		private const string DeclarationName = "?xml"; // Metadata: 0x006A1043
		private const string JsonNamespaceUri = "http://james.newtonking.com/projects/json"; // Metadata: 0x006A1048
		[CompilerGenerated]
		[Nullable(2)]
		private string _DeserializeRootElementName_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _WriteArrayAttribute_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _OmitRootObject_k__BackingField; // 0x19
		[CompilerGenerated]
		private bool _EncodeSpecialCharacters_k__BackingField; // 0x1A
	
		// Properties
		[Nullable(2)]
		public string DeserializeRootElementName { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool WriteArrayAttribute { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public bool OmitRootObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		public bool EncodeSpecialCharacters { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
	
		// Constructors
		public XmlNodeConverter(); // 0x00000001802F4070-0x00000001802F4080
		static XmlNodeConverter(); // 0x0000000181780D70-0x0000000181780E00
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181780B30-0x0000000181780D70
		private IXmlNode WrapXml(object value); // 0x00000001817807F0-0x0000000181780900
		private void PushParentNamespaces(IXmlNode node, XmlNamespaceManager manager); // 0x000000018177D7F0-0x000000018177DC60
		private string ResolveFullName(IXmlNode node, XmlNamespaceManager manager); // 0x000000018177EF80-0x000000018177F130
		private string GetPropertyName(IXmlNode node, XmlNamespaceManager manager); // 0x000000018177D0C0-0x000000018177D450
		private bool IsArray(IXmlNode node); // 0x000000018177D450-0x000000018177D630
		private void SerializeGroupedNodes(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName); // 0x000000018177F130-0x000000018177F7D0
		private void WriteGroupedNodes(JsonWriter writer, XmlNamespaceManager manager, bool writePropertyName, List<IXmlNode> groupedNodes, string elementNames); // 0x0000000181780900-0x0000000181780A40
		private void WriteGroupedNodes(JsonWriter writer, XmlNamespaceManager manager, bool writePropertyName, IXmlNode node, string elementNames); // 0x0000000181780A40-0x0000000181780B30
		private void SerializeNode(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName); // 0x000000018177F7D0-0x00000001817805B0
		private static bool AllSameName(IXmlNode node); // 0x000000018177AE50-0x000000018177AFC0
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x000000018177E970-0x000000018177EF80
		private void DeserializeValue(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, string propertyName, IXmlNode currentNode); // 0x000000018177CDB0-0x000000018177D0C0
		private void ReadElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, XmlNamespaceManager manager); // 0x000000018177E570-0x000000018177E970
		private void CreateElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string elementName, XmlNamespaceManager manager, [Nullable(2)] string elementPrefix, [Nullable(new byte[3] {2, 1, 2 })] Dictionary<string, string> attributeNameValues); // 0x000000018177BB10-0x000000018177BFE0
		private static void AddAttribute(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, string attributeName, XmlNamespaceManager manager, [Nullable(2)] string attributePrefix); // 0x000000018177AA10-0x000000018177AC50
		private static string ConvertTokenToXmlValue(JsonReader reader); // 0x000000018177B070-0x000000018177B730
		private void ReadArrayElements(JsonReader reader, IXmlDocument document, string propertyName, IXmlNode currentNode, XmlNamespaceManager manager); // 0x000000018177DC60-0x000000018177DEF0
		private void AddJsonArrayAttribute(IXmlElement element, IXmlDocument document); // 0x000000018177AC50-0x000000018177AE50
		private bool ShouldReadInto(JsonReader reader); // 0x00000001817805B0-0x0000000181780640
		private Dictionary<string, string> ReadAttributeElements(JsonReader reader, XmlNamespaceManager manager); // 0x000000018177DEF0-0x000000018177E570
		private void CreateInstruction(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName); // 0x000000018177C120-0x000000018177C4E0
		private void CreateDocumentType(JsonReader reader, IXmlDocument document, IXmlNode currentNode); // 0x000000018177B730-0x000000018177BB10
		private IXmlElement CreateElement(string elementName, IXmlDocument document, [Nullable(2)] string elementPrefix, XmlNamespaceManager manager); // 0x000000018177BFE0-0x000000018177C120
		private void DeserializeNode(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, IXmlNode currentNode); // 0x000000018177C4E0-0x000000018177CDB0
		private bool IsNamespaceAttribute(string attributeName, [Nullable(2)] [NotNullWhen(true)] out string prefix); // 0x000000018177D630-0x000000018177D710
		private bool ValueAttributes(List<IXmlNode> c); // 0x0000000181780640-0x00000001817807F0
		public override bool CanConvert(Type valueType); // 0x000000018177AFC0-0x000000018177B070
		private bool IsXObject(Type valueType); // 0x000000018177D710-0x000000018177D780
		private bool IsXmlNode(Type valueType); // 0x000000018177D780-0x000000018177D7F0
	}
}
