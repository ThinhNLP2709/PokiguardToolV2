/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.CSharp;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class CodeIdentifier // TypeDefIndex: 6910
	{
		// Fields
		internal static CodeDomProvider csharp; // 0x00
	
		// Constructors
		static CodeIdentifier(); // 0x0000000181A8C020-0x0000000181A8C0A0
	
		// Methods
		public static string MakePascal(string identifier); // 0x0000000181A8BAF0-0x0000000181A8BE20
		public static string MakeValid(string identifier); // 0x0000000181A8BE20-0x0000000181A8C020
		private static bool IsValidStart(char c); // 0x0000000181A8BA20-0x0000000181A8BA60
		private static bool IsValid(char c); // 0x0000000181A8BA60-0x0000000181A8BAF0
	}
}
