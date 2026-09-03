/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public abstract class XObject : IXmlLineInfo // TypeDefIndex: 15405
	{
		// Fields
		internal XContainer parent; // 0x10
		internal object annotations; // 0x18
	
		// Properties
		public string BaseUri { get; } // 0x000000018195EB70-0x000000018195EBF0 
		public abstract XmlNodeType NodeType { get; }
		public XElement Parent { get; } // 0x000000018195EC30-0x000000018195ECB0 
		int IXmlLineInfo.LineNumber { get; } // 0x000000018195EAD0-0x000000018195EB20 
		int IXmlLineInfo.LinePosition { get; } // 0x000000018195EB20-0x000000018195EB70 
		internal bool HasBaseUri { get; } // 0x000000018195EBF0-0x000000018195EC30 
	
		// Constructors
		internal XObject(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void AddAnnotation(object annotation); // 0x000000018195E1F0-0x000000018195E4B0
		private object AnnotationForSealedType(Type type); // 0x000000018195E4B0-0x000000018195E5F0
		public T Annotation<T>()
			where T : class;
		bool IXmlLineInfo.HasLineInfo(); // 0x000000018195EA90-0x000000018195EAD0
		internal bool NotifyChanged(object sender, XObjectChangeEventArgs e); // 0x000000018195E7C0-0x000000018195E870
		internal bool NotifyChanging(object sender, XObjectChangeEventArgs e); // 0x000000018195E870-0x000000018195E920
		internal void SetBaseUri(string baseUri); // 0x000000018195E920-0x000000018195E9A0
		internal void SetLineInfo(int lineNumber, int linePosition); // 0x000000018195E9A0-0x000000018195EA20
		internal bool SkipNotify(); // 0x000000018195EA20-0x000000018195EA90
		internal SaveOptions GetSaveOptionsFromAnnotations(); // 0x000000018195E5F0-0x000000018195E7C0
	}
}
