/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public sealed class XmlReaderSettings // TypeDefIndex: 6753
	{
		// Fields
		private bool useAsync; // 0x10
		private XmlNameTable nameTable; // 0x18
		private XmlResolver xmlResolver; // 0x20
		private int lineNumberOffset; // 0x28
		private int linePositionOffset; // 0x2C
		private ConformanceLevel conformanceLevel; // 0x30
		private bool checkCharacters; // 0x34
		private long maxCharactersInDocument; // 0x38
		private long maxCharactersFromEntities; // 0x40
		private bool ignoreWhitespace; // 0x48
		private bool ignorePIs; // 0x49
		private bool ignoreComments; // 0x4A
		private DtdProcessing dtdProcessing; // 0x4C
		private ValidationType validationType; // 0x50
		private XmlSchemaValidationFlags validationFlags; // 0x54
		private XmlSchemaSet schemas; // 0x58
		private ValidationEventHandler valEventHandler; // 0x60
		private bool closeInput; // 0x68
		private bool isReadOnly; // 0x69
		[CompilerGenerated]
		private bool _IsXmlResolverSet_k__BackingField; // 0x6A
		private static bool? s_enableLegacyXmlSettings; // 0x00
	
		// Properties
		public bool Async { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x0000000181A421E0-0x0000000181A42230
		public XmlNameTable NameTable { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181A426F0-0x0000000181A42750
		internal bool IsXmlResolverSet { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181A42160-0x0000000181A42170 0x0000000181A42500-0x0000000181A42510
		public XmlResolver XmlResolver { set; } // 0x0000000181A42900-0x0000000181A42960
		public int LineNumberOffset { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000181A42510-0x0000000181A42560
		public int LinePositionOffset { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x0000000181A42560-0x0000000181A425B0
		public ConformanceLevel ConformanceLevel { get; set; } // 0x000000018033D100-0x000000018033D110 0x0000000181A422D0-0x0000000181A42370
		public bool CheckCharacters { get; set; } // 0x00000001816DAFD0-0x00000001816DAFE0 0x0000000181A42230-0x0000000181A42280
		public long MaxCharactersInDocument { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181A42650-0x0000000181A426F0
		public long MaxCharactersFromEntities { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181A425B0-0x0000000181A42650
		public bool IgnoreWhitespace { get; set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000181A424B0-0x0000000181A42500
		public bool IgnoreProcessingInstructions { get; set; } // 0x0000000181A42150-0x0000000181A42160 0x0000000181A42460-0x0000000181A424B0
		public bool IgnoreComments { get; set; } // 0x0000000181A42140-0x0000000181A42150 0x0000000181A42410-0x0000000181A42460
		public DtdProcessing DtdProcessing { get; set; } // 0x000000018033D1B0-0x000000018033D1C0 0x0000000181A42370-0x0000000181A42410
		public bool CloseInput { get; set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000181A42280-0x0000000181A422D0
		public ValidationType ValidationType { get; set; } // 0x000000018033D660-0x000000018033D670 0x0000000181A42860-0x0000000181A42900
		public XmlSchemaValidationFlags ValidationFlags { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181A427C0-0x0000000181A42860
		public XmlSchemaSet Schemas { get; set; } // 0x0000000181A42170-0x0000000181A421E0 0x0000000181A42760-0x0000000181A427C0
		internal bool ReadOnly { set; } // 0x0000000181A42750-0x0000000181A42760
	
		// Constructors
		public XmlReaderSettings(); // 0x0000000181A42050-0x0000000181A42140
	
		// Methods
		internal XmlResolver GetXmlResolver(); // 0x00000001802F8630-0x00000001802F8640
		internal XmlResolver GetXmlResolver_CheckConfig(); // 0x0000000181A41E40-0x0000000181A41E70
		public XmlReaderSettings Clone(); // 0x0000000181A419A0-0x0000000181A41A00
		internal ValidationEventHandler GetEventHandler(); // 0x0000000180333260-0x0000000180333490
		internal XmlReader CreateReader(Stream input, Uri baseUri, string baseUriString, XmlParserContext inputContext); // 0x0000000181A41C00-0x0000000181A41DA0
		internal XmlReader CreateReader(TextReader input, string baseUriString, XmlParserContext inputContext); // 0x0000000181A41AE0-0x0000000181A41C00
		private void CheckReadOnly(string propertyName); // 0x0000000181A418F0-0x0000000181A419A0
		private void Initialize(); // 0x0000000181A41F60-0x0000000181A42050
		private void Initialize(XmlResolver resolver); // 0x0000000181A41E70-0x0000000181A41F60
		private static XmlResolver CreateDefaultResolver(); // 0x0000000181A41A00-0x0000000181A41A50
		internal XmlReader AddValidation(XmlReader reader); // 0x0000000181A417B0-0x0000000181A418F0
		private XmlValidatingReaderImpl CreateDtdValidatingReader(XmlReader baseReader); // 0x0000000181A41A50-0x0000000181A41AE0
		internal static bool EnableLegacyXmlSettings(); // 0x0000000181A41DA0-0x0000000181A41E40
	}
}
