/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal interface ISimpleCollator // TypeDefIndex: 3441
	{
		// Methods
		SortKey GetSortKey(string source, CompareOptions options);
		int Compare(string s1, int idx1, int len1, string s2, int idx2, int len2, CompareOptions options);
		bool IsPrefix(string src, string target, CompareOptions opt);
		bool IsSuffix(string src, string target, CompareOptions opt);
		int IndexOf(string s, string target, int start, int length, CompareOptions opt);
		int LastIndexOf(string s, string target, int start, int length, CompareOptions opt);
	}
}
