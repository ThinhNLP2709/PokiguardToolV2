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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security
{
	[Serializable]
	[ComVisible(true)]
	public sealed class SecurityElement // TypeDefIndex: 2752
	{
		// Fields
		private string text; // 0x10
		private string tag; // 0x18
		private ArrayList attributes; // 0x20
		private ArrayList children; // 0x28
		private static readonly char[] invalid_tag_chars; // 0x00
		private static readonly char[] invalid_text_chars; // 0x08
		private static readonly char[] invalid_attr_name_chars; // 0x10
		private static readonly char[] invalid_attr_value_chars; // 0x18
		private static readonly char[] invalid_chars; // 0x20
	
		// Properties
		public ArrayList Children { get; } // 0x000000018033D240-0x000000018033D250 
		public string Tag { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string Text { set; } // 0x0000000181483AF0-0x0000000181483C50
		internal string m_strText { set; } // 0x00000001803780D0-0x00000001803780E0
	
		// Nested types
		internal class SecurityAttribute // TypeDefIndex: 2753
		{
			// Fields
			private string _name; // 0x10
			private string _value; // 0x18
	
			// Properties
			public string Name { get; } // 0x0000000180377550-0x0000000180377560 
			public string Value { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			public SecurityAttribute(string name, string value); // 0x0000000181481450-0x00000001814816A0
		}
	
		// Constructors
		public SecurityElement(string tag); // 0x0000000181483800-0x0000000181483810
		public SecurityElement(string tag, string text); // 0x0000000181483810-0x0000000181483AF0
		static SecurityElement(); // 0x00000001814835F0-0x0000000181483800
	
		// Methods
		public void AddAttribute(string name, string value); // 0x00000001814821D0-0x00000001814823C0
		public void AddChild(SecurityElement child); // 0x00000001814823C0-0x00000001814824B0
		public static string Escape(string str); // 0x00000001814824B0-0x00000001814826C0
		private static string Unescape(string str); // 0x0000000181483470-0x00000001814835F0
		public static bool IsValidAttributeName(string name); // 0x00000001814828A0-0x0000000181482920
		public static bool IsValidAttributeValue(string value); // 0x0000000181482920-0x00000001814829A0
		public static bool IsValidTag(string tag); // 0x00000001814829A0-0x0000000181482A20
		public static bool IsValidText(string text); // 0x0000000181482A20-0x0000000181482AA0
		public SecurityElement SearchForChildByTag(string tag); // 0x0000000181482AA0-0x0000000181482C00
		public override string ToString(); // 0x0000000181482E00-0x0000000181482E80
		private void ToXml(ref StringBuilder s, int level); // 0x0000000181482E80-0x0000000181483470
		internal SecurityAttribute GetAttribute(string name); // 0x00000001814826C0-0x00000001814828A0
		internal string SearchForTextOfLocalName(string strLocalName); // 0x0000000181482C00-0x0000000181482E00
	}
}
