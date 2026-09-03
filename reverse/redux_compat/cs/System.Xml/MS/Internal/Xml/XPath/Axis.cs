/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.XPath
{
	internal class Axis : AstNode // TypeDefIndex: 7299
	{
		// Fields
		private AxisType _axisType; // 0x10
		private AstNode _input; // 0x18
		private string _prefix; // 0x20
		private string _name; // 0x28
		private XPathNodeType _nodeType; // 0x30
		protected bool abbrAxis; // 0x34
		private string _urn; // 0x38
	
		// Properties
		public override AstType Type { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override XPathResultType ReturnType { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		public AstNode Input { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string Prefix { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string Name { get; } // 0x000000018033D240-0x000000018033D250 
		public XPathNodeType NodeType { get; } // 0x000000018033D100-0x000000018033D110 
		public AxisType TypeOfAxis { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool AbbrAxis { get; } // 0x00000001816DAFD0-0x00000001816DAFE0 
		public string Urn { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Nested types
		public enum AxisType // TypeDefIndex: 7300
		{
			Ancestor = 0,
			AncestorOrSelf = 1,
			Attribute = 2,
			Child = 3,
			Descendant = 4,
			DescendantOrSelf = 5,
			Following = 6,
			FollowingSibling = 7,
			Namespace = 8,
			Parent = 9,
			Preceding = 10,
			PrecedingSibling = 11,
			Self = 12,
			None = 13
		}
	
		// Constructors
		public Axis(AxisType axisType, AstNode input, string prefix, string name, XPathNodeType nodetype); // 0x0000000181A20A30-0x0000000181A20AD0
		public Axis(AxisType axisType, AstNode input); // 0x0000000181A20AD0-0x0000000181A20B80
	}
}
