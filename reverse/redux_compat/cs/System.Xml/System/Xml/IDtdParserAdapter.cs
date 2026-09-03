/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal interface IDtdParserAdapter // TypeDefIndex: 6715
	{
		// Properties
		XmlNameTable NameTable { get; }
		IXmlNamespaceResolver NamespaceResolver { get; }
		Uri BaseUri { get; }
		char[] ParsingBuffer { get; }
		int ParsingBufferLength { get; }
		int CurrentPosition { get; set; }
		int LineNo { get; }
		int LineStartPosition { get; }
		bool IsEof { get; }
		int EntityStackLength { get; }
		bool IsEntityEolNormalized { get; }
	
		// Methods
		int ReadData();
		void OnNewLine(int pos);
		int ParseNumericCharRef(StringBuilder internalSubsetBuilder);
		int ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder);
		void ParsePI(StringBuilder sb);
		void ParseComment(StringBuilder sb);
		bool PushEntity(IDtdEntityInfo entity, out int entityId);
		bool PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId);
		bool PushExternalSubset(string systemId, string publicId);
		void PushInternalDtd(string baseUri, string internalDtd);
		void OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo);
		void OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo);
		void Throw(Exception e);
	}
}
