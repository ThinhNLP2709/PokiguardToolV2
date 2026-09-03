/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct DateTimeResult // TypeDefIndex: 2262
	{
		// Fields
		internal int Year; // 0x00
		internal int Month; // 0x04
		internal int Day; // 0x08
		internal int Hour; // 0x0C
		internal int Minute; // 0x10
		internal int Second; // 0x14
		internal double fraction; // 0x18
		internal int era; // 0x20
		internal ParseFlags flags; // 0x24
		internal TimeSpan timeZoneOffset; // 0x28
		internal Calendar calendar; // 0x30
		internal DateTime parsedDate; // 0x38
		internal ParseFailureKind failure; // 0x40
		internal string failureMessageID; // 0x48
		internal object failureMessageFormatArgument; // 0x50
		internal string failureArgumentName; // 0x58
		internal ReadOnlySpan<char> originalDateTimeString; // 0x60
		internal ReadOnlySpan<char> failedFormatSpecifier; // 0x70
	
		// Methods
		internal void Init(ReadOnlySpan<char> originalDateTimeString); // 0x00000001815F78C0-0x00000001815F78F0
		internal void SetDate(int year, int month, int day); // 0x0000000180F46690-0x0000000180F466A0
		internal void SetBadFormatSpecifierFailure(); // 0x00000001815F7990-0x00000001815F79F0
		internal void SetBadFormatSpecifierFailure(ReadOnlySpan<char> failedFormatSpecifier); // 0x00000001815F7940-0x00000001815F7990
		internal void SetBadDateTimeFailure(); // 0x00000001815F78F0-0x00000001815F7940
		internal void SetFailure(ParseFailureKind failure, string failureMessageID); // 0x00000001815F7A20-0x00000001815F7A30
		internal void SetFailure(ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument); // 0x00000001815F79F0-0x00000001815F7A00
		internal void SetFailure(ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument, string failureArgumentName); // 0x00000001815F7A00-0x00000001815F7A20
	}
}
