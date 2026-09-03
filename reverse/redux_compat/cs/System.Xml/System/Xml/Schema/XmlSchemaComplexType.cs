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
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaComplexType : XmlSchemaType // TypeDefIndex: 7192
	{
		// Fields
		private XmlSchemaDerivationMethod block; // 0x98
		private XmlSchemaContentModel contentModel; // 0xA0
		private XmlSchemaParticle particle; // 0xA8
		private XmlSchemaObjectCollection attributes; // 0xB0
		private XmlSchemaAnyAttribute anyAttribute; // 0xB8
		private XmlSchemaParticle contentTypeParticle; // 0xC0
		private XmlSchemaDerivationMethod blockResolved; // 0xC8
		private XmlSchemaObjectTable localElements; // 0xD0
		private XmlSchemaObjectTable attributeUses; // 0xD8
		private XmlSchemaAnyAttribute attributeWildcard; // 0xE0
		private static XmlSchemaComplexType anyTypeLax; // 0x00
		private static XmlSchemaComplexType anyTypeSkip; // 0x08
		private static XmlSchemaComplexType untypedAnyType; // 0x10
		private byte pvFlags; // 0xE8
	
		// Properties
		[XmlIgnore]
		internal static XmlSchemaComplexType AnyType { get; } // 0x00000001819DBB60-0x00000001819DBBB0 
		[XmlIgnore]
		internal static XmlSchemaComplexType UntypedAnyType { get; } // 0x00000001819DBD30-0x00000001819DBD80 
		internal static ContentValidator AnyTypeContentValidator { get; } // 0x00000001819DBAF0-0x00000001819DBB60 
		[DefaultValue(false)]
		[XmlAttribute("abstract")]
		public bool IsAbstract { get; set; } // 0x0000000180CC37E0-0x0000000180CC37F0 0x00000001819DBDB0-0x00000001819DBDE0
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("block")]
		public XmlSchemaDerivationMethod Block { get; set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
		[DefaultValue(false)]
		[XmlAttribute("mixed")]
		public override bool IsMixed { get; set; } // 0x0000000180CC3990-0x0000000180CC39A0 0x00000001819DBDE0-0x00000001819DBE10
		[XmlElement("simpleContent", typeof(XmlSchemaSimpleContent))]
		[XmlElement("complexContent", typeof(XmlSchemaComplexContent))]
		public XmlSchemaContentModel ContentModel { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		[XmlElement("all", typeof(XmlSchemaAll))]
		[XmlElement("group", typeof(XmlSchemaGroupRef))]
		[XmlElement("sequence", typeof(XmlSchemaSequence))]
		[XmlElement("choice", typeof(XmlSchemaChoice))]
		public XmlSchemaParticle Particle { get; set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
		public XmlSchemaObjectCollection Attributes { get; } // 0x00000001819DBC30-0x00000001819DBCB0 
		[XmlElement("anyAttribute")]
		public XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		[XmlIgnore]
		public XmlSchemaContentType ContentType { get; } // 0x000000018169CBC0-0x000000018169CBD0 
		[XmlIgnore]
		public XmlSchemaParticle ContentTypeParticle { get; } // 0x00000001806CCB70-0x00000001806CCB80 
		[XmlIgnore]
		public XmlSchemaDerivationMethod BlockResolved { get; } // 0x000000018158B020-0x000000018158B030 
		[XmlIgnore]
		public XmlSchemaObjectTable AttributeUses { get; } // 0x00000001819DBBB0-0x00000001819DBC30 
		[XmlIgnore]
		public XmlSchemaAnyAttribute AttributeWildcard { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		[XmlIgnore]
		internal XmlSchemaObjectTable LocalElements { get; } // 0x00000001819DBCB0-0x00000001819DBD30 
		internal bool HasWildCard { set; } // 0x00000001819DBD80-0x00000001819DBDB0
	
		// Constructors
		static XmlSchemaComplexType(); // 0x00000001819DB6E0-0x00000001819DBA70
		public XmlSchemaComplexType(); // 0x00000001819DBA70-0x00000001819DBAF0
	
		// Methods
		private static XmlSchemaComplexType CreateAnyType(XmlSchemaContentProcessing processContents); // 0x00000001819DAD60-0x00000001819DB230
		internal void SetContentTypeParticle(XmlSchemaParticle value); // 0x00000001806CCDA0-0x00000001806CCDC0
		internal void SetBlockResolved(XmlSchemaDerivationMethod value); // 0x00000001819DB6D0-0x00000001819DB6E0
		internal void SetAttributeWildcard(XmlSchemaAnyAttribute value); // 0x00000001806CCDC0-0x00000001806CCDE0
		internal void SetAttributes(XmlSchemaObjectCollection newAttributes); // 0x00000001806C0C00-0x00000001806C0C20
		internal bool ContainsIdAttribute(bool findAll); // 0x00000001819DAAB0-0x00000001819DAD60
		internal override XmlSchemaObject Clone(); // 0x00000001819DAAA0-0x00000001819DAAB0
		internal XmlSchemaObject Clone(XmlSchema parentSchema); // 0x00000001819DA140-0x00000001819DAAA0
		private void ClearCompiledState(); // 0x00000001819D9820-0x00000001819D98E0
		internal static XmlSchemaObjectCollection CloneAttributes(XmlSchemaObjectCollection attributes); // 0x00000001819D98E0-0x00000001819D9B60
		private static XmlSchemaObjectCollection CloneGroupBaseParticles(XmlSchemaObjectCollection groupBaseParticles, XmlSchema parentSchema); // 0x00000001819D9B60-0x00000001819D9CA0
		internal static XmlSchemaParticle CloneParticle(XmlSchemaParticle particle, XmlSchema parentSchema); // 0x00000001819D9CA0-0x00000001819DA140
		private static XmlSchemaForm GetResolvedElementForm(XmlSchema parentSchema, XmlSchemaElement element); // 0x00000001819DB230-0x00000001819DB260
		internal static bool HasParticleRef(XmlSchemaParticle particle, XmlSchema parentSchema); // 0x00000001819DB3C0-0x00000001819DB6D0
		internal static bool HasAttributeQNameRef(XmlSchemaObjectCollection attributes); // 0x00000001819DB260-0x00000001819DB3C0
	}
}
