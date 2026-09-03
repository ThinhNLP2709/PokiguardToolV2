/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	[ComVisible(true)]
	public class TextInfo : ICloneable, IDeserializationCallback // TypeDefIndex: 3436
	{
		// Fields
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly; // 0x10
		[OptionalField(VersionAdded = 3)]
		private string m_cultureName; // 0x18
		[NonSerialized]
		private CultureData m_cultureData; // 0x20
		[NonSerialized]
		private string m_textInfoName; // 0x28
		[NonSerialized]
		private bool? m_IsAsciiCasingSameAsInvariant; // 0x30
		internal static TextInfo s_Invariant; // 0x00
		[OptionalField(VersionAdded = 2)]
		private string customCultureName; // 0x38
		[OptionalField(VersionAdded = 1)]
		internal bool m_useUserOverride; // 0x40
		[OptionalField(VersionAdded = 1)]
		internal int m_win32LangID; // 0x44
	
		// Properties
		internal static TextInfo Invariant { get; } // 0x000000018158E2E0-0x000000018158E3F0 
		[ComVisible(false)]
		public string CultureName { get; } // 0x000000018033D240-0x000000018033D250 
		private bool IsAsciiCasingSameAsInvariant { get; } // 0x000000018158E3F0-0x000000018158E4A0 
	
		// Constructors
		internal TextInfo(CultureData cultureData); // 0x000000018158E240-0x000000018158E2B0
		internal TextInfo(); // 0x000000018158E2B0-0x000000018158E2E0
	
		// Methods
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x000000018158CC50-0x000000018158CC90
		private void OnDeserialized(); // 0x000000018158CB10-0x000000018158CC40
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x000000018158CC40-0x000000018158CC50
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx); // 0x000000018158CC90-0x000000018158CD10
		[ComVisible(false)]
		public virtual object Clone(); // 0x000000018158C9A0-0x000000018158CA20
		internal void SetReadOnlyState(bool readOnly); // 0x00000001804C2E20-0x00000001804C2E30
		public virtual char ToLower(char c); // 0x000000018158D350-0x000000018158D3B0
		public virtual string ToLower(string str); // 0x000000018158D3B0-0x000000018158D4D0
		private static char ToLowerAsciiInvariant(char c); // 0x000000018158CD10-0x000000018158CD30
		public virtual char ToUpper(char c); // 0x000000018158E1E0-0x000000018158E240
		public virtual string ToUpper(string str); // 0x000000018158E0C0-0x000000018158E1E0
		internal static char ToUpperAsciiInvariant(char c); // 0x000000018158D990-0x000000018158D9B0
		private static bool IsAscii(char c); // 0x000000018158CAE0-0x000000018158CAF0
		public override bool Equals(object obj); // 0x000000018158CA20-0x000000018158CAB0
		public override int GetHashCode(); // 0x000000018158CAB0-0x000000018158CAE0
		public override string ToString(); // 0x000000018158D4D0-0x000000018158D520
		public string ToTitleCase(string str); // 0x000000018158D520-0x000000018158D8F0
		private static int AddNonLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen); // 0x000000018158C630-0x000000018158C6D0
		private int AddTitlecaseLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen); // 0x000000018158C6D0-0x000000018158C8A0
		private static bool IsWordSeparator(UnicodeCategory category); // 0x000000018158CB00-0x000000018158CB10
		private static bool IsLetterCategory(UnicodeCategory uc); // 0x000000018158CAF0-0x000000018158CB00
		void IDeserializationCallback.OnDeserialization(object sender); // 0x000000018158CC40-0x000000018158CC50
		private string ToUpperInternal(string str); // 0x000000018158DFE0-0x000000018158E0C0
		private string ToLowerInternal(string str); // 0x000000018158D270-0x000000018158D350
		private char ToUpperInternal(char c); // 0x000000018158D9B0-0x000000018158DFE0
		private char ToLowerInternal(char c); // 0x000000018158CD30-0x000000018158D270
		internal void ToUpperAsciiInvariant(ReadOnlySpan<char> source, Span<char> destination); // 0x000000018158D8F0-0x000000018158D990
		internal void ChangeCase(ReadOnlySpan<char> source, Span<char> destination, bool toUpper); // 0x000000018158C8A0-0x000000018158C9A0
	}
}
