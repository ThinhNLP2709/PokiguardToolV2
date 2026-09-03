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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	[ComVisible(true)]
	public class SoapServices // TypeDefIndex: 2894
	{
		// Fields
		private static Hashtable _xmlTypes; // 0x00
		private static Hashtable _xmlElements; // 0x08
		private static Hashtable _soapActions; // 0x10
		private static Hashtable _soapActionsMethods; // 0x18
		private static Hashtable _typeInfos; // 0x20
	
		// Properties
		public static string XmlNsForClrTypeWithAssembly { get; } // 0x00000001814C85D0-0x00000001814C8600 
		public static string XmlNsForClrTypeWithNs { get; } // 0x00000001814C8630-0x00000001814C8660 
		public static string XmlNsForClrTypeWithNsAndAssembly { get; } // 0x00000001814C8600-0x00000001814C8630 
	
		// Nested types
		private class TypeInfo // TypeDefIndex: 2895
		{
			// Fields
			public Hashtable Attributes; // 0x10
			public Hashtable Elements; // 0x18
	
			// Constructors
			public TypeInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		static SoapServices(); // 0x00000001814C8440-0x00000001814C85D0
	
		// Methods
		public static string CodeXmlNamespaceForClrTypeNamespace(string typeNamespace, string assemblyName); // 0x00000001814C72A0-0x00000001814C7420
		private static string GetNameKey(string name, string namspace); // 0x00000001814C7630-0x00000001814C7690
		private static string GetAssemblyName(MethodBase mb); // 0x00000001814C74F0-0x00000001814C7630
		public static bool GetXmlElementForInteropType(Type type, out string xmlElement, out string xmlNamespace); // 0x00000001814C7690-0x00000001814C77A0
		public static string GetXmlNamespaceForMethodCall(MethodBase mb); // 0x00000001814C77A0-0x00000001814C7850
		public static string GetXmlNamespaceForMethodResponse(MethodBase mb); // 0x00000001814C7850-0x00000001814C7900
		public static bool GetXmlTypeForInteropType(Type type, out string xmlType, out string xmlTypeNamespace); // 0x00000001814C7900-0x00000001814C79F0
		public static void PreLoad(Assembly assembly); // 0x00000001814C8050-0x00000001814C8130
		public static void PreLoad(Type type); // 0x00000001814C79F0-0x00000001814C8050
		public static void RegisterInteropXmlElement(string xmlElement, string xmlNamespace, Type type); // 0x00000001814C8130-0x00000001814C82C0
		public static void RegisterInteropXmlType(string xmlType, string xmlTypeNamespace, Type type); // 0x00000001814C82C0-0x00000001814C8440
		private static string EncodeNs(string ns); // 0x00000001814C7420-0x00000001814C74F0
	}
}
