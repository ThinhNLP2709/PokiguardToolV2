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
	internal interface IDtdEntityInfo // TypeDefIndex: 6713
	{
		// Properties
		string Name { get; }
		bool IsExternal { get; }
		bool IsDeclaredInExternal { get; }
		bool IsUnparsedEntity { get; }
		bool IsParameterEntity { get; }
		string BaseUriString { get; }
		string DeclaredUriString { get; }
		string SystemId { get; }
		string PublicId { get; }
		string Text { get; }
		int LineNumber { get; }
		int LinePosition { get; }
	}
}
