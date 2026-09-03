/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[Serializable]
	public class XmlQualifiedName // TypeDefIndex: 6895
	{
		// Fields
		private static HashCodeOfStringDelegate hashCodeDelegate; // 0x00
		private string name; // 0x10
		private string ns; // 0x18
		[NonSerialized]
		private int hash; // 0x20
		public static readonly XmlQualifiedName Empty; // 0x08
	
		// Properties
		public string Namespace { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string Name { get; } // 0x0000000180377550-0x0000000180377560 
		public bool IsEmpty { get; } // 0x0000000181AA6100-0x0000000181AA6140 
	
		// Nested types
		private delegate int HashCodeOfStringDelegate(string s, int sLen, long additionalEntropy); // TypeDefIndex: 6896; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		public XmlQualifiedName(); // 0x0000000181AA6060-0x0000000181AA6100
		public XmlQualifiedName(string name); // 0x0000000181AA5F30-0x0000000181AA5FD0
		public XmlQualifiedName(string name, string ns); // 0x0000000181AA5FD0-0x0000000181AA6060
		static XmlQualifiedName(); // 0x0000000181AA5E00-0x0000000181AA5F30
	
		// Methods
		public override int GetHashCode(); // 0x0000000181AA5830-0x0000000181AA5910
		public override string ToString(); // 0x0000000181AA5CB0-0x0000000181AA5D10
		public override bool Equals(object other); // 0x0000000181AA5550-0x0000000181AA5670
		public static bool operator ==(XmlQualifiedName a, XmlQualifiedName b); // 0x0000000181AA6140-0x0000000181AA61B0
		public static bool operator !=(XmlQualifiedName a, XmlQualifiedName b); // 0x0000000181AA61B0-0x0000000181AA6250
		public static string ToString(string name, string ns); // 0x0000000181AA5D10-0x0000000181AA5D80
		private static HashCodeOfStringDelegate GetHashCodeDelegate(); // 0x0000000181AA5670-0x0000000181AA5830
		private static bool IsRandomizedHashingDisabled(); // 0x00000001802E7840-0x00000001802E7850
		private static int GetHashCodeOfString(string s, int length, long additionalEntropy); // 0x0000000180E2CC10-0x0000000180E2CC40
		internal void Init(string name, string ns); // 0x0000000181AA5910-0x0000000181AA5950
		internal void SetNamespace(string ns); // 0x00000001802FAF70-0x00000001802FAF80
		internal void Verify(); // 0x0000000181AA5D80-0x0000000181AA5E00
		internal void Atomize(XmlNameTable nameTable); // 0x0000000181AA5450-0x0000000181AA54D0
		internal static XmlQualifiedName Parse(string s, IXmlNamespaceResolver nsmgr, out string prefix); // 0x0000000181AA5950-0x0000000181AA5CB0
		internal XmlQualifiedName Clone(); // 0x0000000181AA54D0-0x0000000181AA5550
	}
}
