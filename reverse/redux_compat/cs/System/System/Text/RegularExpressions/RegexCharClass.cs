/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexCharClass // TypeDefIndex: 8705
	{
		// Fields
		private static readonly string s_internalRegexIgnoreCase; // 0x00
		private static readonly string s_space; // 0x08
		private static readonly string s_notSpace; // 0x10
		private static readonly string s_word; // 0x18
		private static readonly string s_notWord; // 0x20
		public static readonly string SpaceClass; // 0x28
		public static readonly string NotSpaceClass; // 0x30
		public static readonly string WordClass; // 0x38
		public static readonly string NotWordClass; // 0x40
		public static readonly string DigitClass; // 0x48
		public static readonly string NotDigitClass; // 0x50
		private static readonly Dictionary<string, string> s_definedCategories; // 0x58
		private static readonly string[][] s_propTable; // 0x60
		private static readonly LowerCaseMapping[] s_lcTable; // 0x68
		private List<SingleRange> _rangelist; // 0x10
		private StringBuilder _categories; // 0x18
		private bool _canonical; // 0x20
		private bool _negate; // 0x21
		private RegexCharClass _subtractor; // 0x28
	
		// Properties
		public bool CanMerge { get; } // 0x0000000181B69B40-0x0000000181B69B60 
		public bool Negate { set; } // 0x000000018147BC30-0x000000018147BC40
	
		// Nested types
		[IsReadOnly]
		private struct LowerCaseMapping // TypeDefIndex: 8706
		{
			// Fields
			public readonly char ChMin; // 0x00
			public readonly char ChMax; // 0x02
			public readonly int LcOp; // 0x04
			public readonly int Data; // 0x08
	
			// Constructors
			internal LowerCaseMapping(char chMin, char chMax, int lcOp, int data); // 0x0000000181B5F750-0x0000000181B5F770
		}
	
		private sealed class SingleRangeComparer : IComparer<SingleRange> // TypeDefIndex: 8707
		{
			// Fields
			public static readonly SingleRangeComparer Instance; // 0x00
	
			// Constructors
			private SingleRangeComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static SingleRangeComparer(); // 0x0000000181B71BB0-0x0000000181B71C20
	
			// Methods
			public int Compare(SingleRange x, SingleRange y); // 0x0000000181B71B70-0x0000000181B71BB0
		}
	
		[IsReadOnly]
		private struct SingleRange // TypeDefIndex: 8708
		{
			// Fields
			public readonly char First; // 0x00
			public readonly char Last; // 0x02
	
			// Constructors
			internal SingleRange(char first, char last); // 0x0000000181552300-0x0000000181552310
		}
	
		// Constructors
		public RegexCharClass(); // 0x0000000181B69A10-0x0000000181B69AC0
		private RegexCharClass(bool negate, List<SingleRange> ranges, StringBuilder categories, RegexCharClass subtraction); // 0x0000000181B69AC0-0x0000000181B69B40
		static RegexCharClass(); // 0x0000000181B63F20-0x0000000181B69A10
	
		// Methods
		public void AddChar(char c); // 0x0000000181B62140-0x0000000181B62150
		public void AddCharClass(RegexCharClass cc); // 0x0000000181B61FC0-0x0000000181B62140
		private void AddSet(string set); // 0x0000000181B625D0-0x0000000181B627B0
		public void AddSubtraction(RegexCharClass sub); // 0x000000018033E840-0x000000018033E850
		public void AddRange(char first, char last); // 0x0000000181B624F0-0x0000000181B625D0
		public void AddCategoryFromName(string categoryName, bool invert, bool caseInsensitive, string pattern); // 0x0000000181B61D70-0x0000000181B61FA0
		private void AddCategory(string category); // 0x0000000181B61FA0-0x0000000181B61FC0
		public void AddLowercase(CultureInfo culture); // 0x0000000181B623E0-0x0000000181B624F0
		private void AddLowercaseRange(char chMin, char chMax, CultureInfo culture); // 0x0000000181B62200-0x0000000181B623E0
		public void AddWord(bool ecma, bool negate); // 0x0000000181B628E0-0x0000000181B62A10
		public void AddSpace(bool ecma, bool negate); // 0x0000000181B627B0-0x0000000181B628E0
		public void AddDigit(bool ecma, bool negate, string pattern); // 0x0000000181B62150-0x0000000181B62200
		public static char SingletonChar(string set); // 0x0000000181B63D70-0x0000000181B63D90
		public static bool IsMergeable(string charClass); // 0x0000000181B633B0-0x0000000181B63460
		public static bool IsEmpty(string charClass); // 0x0000000181B632D0-0x0000000181B633B0
		public static bool IsSingleton(string set); // 0x0000000181B635D0-0x0000000181B63710
		public static bool IsSingletonInverse(string set); // 0x0000000181B63490-0x0000000181B635D0
		private static bool IsSubtraction(string charClass); // 0x0000000181B63710-0x0000000181B63770
		private static bool IsNegated(string set); // 0x0000000181B63460-0x0000000181B63490
		public static bool IsECMAWordChar(char ch); // 0x0000000181B63220-0x0000000181B632D0
		public static bool IsWordChar(char ch); // 0x0000000181B63770-0x0000000181B63840
		public static bool CharInClass(char ch, string set); // 0x0000000181B631A0-0x0000000181B63200
		private static bool CharInClassRecursive(char ch, string set, int start); // 0x0000000181B63070-0x0000000181B631A0
		private static bool CharInClassInternal(char ch, string set, int start, int mySetLength, int myCategoryLength); // 0x0000000181B62E50-0x0000000181B63070
		private static bool CharInCategory(char ch, string set, int start, int mySetLength, int myCategoryLength); // 0x0000000181B62CC0-0x0000000181B62E50
		private static bool CharInCategoryGroup(char ch, UnicodeCategory chcategory, string category, ref int i); // 0x0000000181B62BF0-0x0000000181B62CC0
		private static string NegateCategory(string category); // 0x0000000181B63840-0x0000000181B638D0
		public static RegexCharClass Parse(string charClass); // 0x0000000181B63B00-0x0000000181B63B50
		private static RegexCharClass ParseRecursive(string charClass, int start); // 0x0000000181B638D0-0x0000000181B63B00
		private int RangeCount(); // 0x0000000180B5F570-0x0000000180B5F590
		public string ToStringClass(); // 0x0000000181B63D90-0x0000000181B63F20
		private SingleRange GetRangeAt(int i); // 0x0000000181B63200-0x0000000181B63220
		private void Canonicalize(); // 0x0000000181B62A10-0x0000000181B62BF0
		private static string SetFromProperty(string capname, bool invert, string pattern); // 0x0000000181B63B50-0x0000000181B63D70
	}
}
