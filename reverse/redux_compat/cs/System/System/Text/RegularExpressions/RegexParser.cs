/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexParser // TypeDefIndex: 8716
	{
		// Fields
		private RegexNode _stack; // 0x10
		private RegexNode _group; // 0x18
		private RegexNode _alternation; // 0x20
		private RegexNode _concatenation; // 0x28
		private RegexNode _unit; // 0x30
		private string _pattern; // 0x38
		private int _currentPos; // 0x40
		private CultureInfo _culture; // 0x48
		private int _autocap; // 0x50
		private int _capcount; // 0x54
		private int _captop; // 0x58
		private int _capsize; // 0x5C
		private Hashtable _caps; // 0x60
		private Hashtable _capnames; // 0x68
		private int[] _capnumlist; // 0x70
		private List<string> _capnamelist; // 0x78
		private RegexOptions _options; // 0x80
		private List<RegexOptions> _optionsStack; // 0x88
		private bool _ignoreNextParen; // 0x90
		private static readonly byte[] s_category; // 0x00
	
		// Constructors
		private RegexParser(CultureInfo culture); // 0x0000000181B81220-0x0000000181B812F0
		static RegexParser(); // 0x0000000181B81160-0x0000000181B81220
	
		// Methods
		public static RegexTree Parse(string re, RegexOptions op); // 0x0000000181B7CBA0-0x0000000181B7CDC0
		public static RegexReplacement ParseReplacement(string rep, Hashtable caps, int capsize, Hashtable capnames, RegexOptions op); // 0x0000000181B7CA30-0x0000000181B7CBA0
		public static string Escape(string input); // 0x0000000181B7BD20-0x0000000181B7BF10
		private void SetPattern(string Re); // 0x0000000181B80F70-0x0000000181B80FB0
		private void Reset(RegexOptions topopts); // 0x0000000181B7D060-0x0000000181B7D0E0
		private RegexNode ScanRegex(); // 0x0000000181B80520-0x0000000181B80E00
		private RegexNode ScanReplacement(); // 0x0000000181B80E00-0x0000000181B80F70
		private RegexCharClass ScanCharClass(bool caseInsensitive, bool scanOnly); // 0x0000000181B7E2B0-0x0000000181B7EBC0
		private RegexNode ScanGroupOpen(); // 0x0000000181B7F570-0x0000000181B80230
		private void ScanBlank(); // 0x0000000181B7DE10-0x0000000181B7E1E0
		private RegexNode ScanBackslash(bool scanOnly); // 0x0000000181B7D170-0x0000000181B7D720
		private RegexNode ScanBasicBackslash(bool scanOnly); // 0x0000000181B7D720-0x0000000181B7DE10
		private RegexNode ScanDollar(); // 0x0000000181B7F120-0x0000000181B7F570
		private string ScanCapname(); // 0x0000000181B7E1E0-0x0000000181B7E2B0
		private char ScanOctal(); // 0x0000000181B80360-0x0000000181B80400
		private int ScanDecimal(); // 0x0000000181B7F060-0x0000000181B7F120
		private char ScanHex(int c); // 0x0000000181B80230-0x0000000181B80360
		private static int HexDigit(char ch); // 0x0000000181B7BF10-0x0000000181B7BF50
		private char ScanControl(); // 0x0000000181B7EF90-0x0000000181B7F060
		private bool IsOnlyTopOption(RegexOptions option); // 0x0000000181B7C070-0x0000000181B7C090
		private void ScanOptions(); // 0x0000000181B80400-0x0000000181B80520
		private char ScanCharEscape(); // 0x0000000181B7EBC0-0x0000000181B7EF90
		private string ParseProperty(); // 0x0000000181B7C850-0x0000000181B7CA30
		private int TypeFromCode(char ch); // 0x0000000181B81080-0x0000000181B81100
		private static RegexOptions OptionFromCode(char ch); // 0x0000000181B7C7B0-0x0000000181B7C850
		private void CountCaptures(); // 0x0000000181B7B770-0x0000000181B7BCF0
		private void NoteCaptureSlot(int i, int pos); // 0x0000000181B7C670-0x0000000181B7C760
		private void NoteCaptureName(string name, int pos); // 0x0000000181B7C4C0-0x0000000181B7C670
		private void NoteCaptures(Hashtable caps, int capsize, Hashtable capnames); // 0x0000000181B7C760-0x0000000181B7C7B0
		private void AssignNameSlots(); // 0x0000000181B7B000-0x0000000181B7B6D0
		private int CaptureSlotFromName(string capname); // 0x0000000181B7B6D0-0x0000000181B7B730
		private bool IsCaptureSlot(int i); // 0x0000000181B7BF80-0x0000000181B7BFF0
		private bool IsCaptureName(string capname); // 0x0000000181B7BF50-0x0000000181B7BF80
		private bool UseOptionN(); // 0x0000000181B81130-0x0000000181B81140
		private bool UseOptionI(); // 0x0000000181B81110-0x0000000181B81120
		private bool UseOptionM(); // 0x0000000181B81120-0x0000000181B81130
		private bool UseOptionS(); // 0x0000000181B81140-0x0000000181B81150
		private bool UseOptionX(); // 0x0000000181B81150-0x0000000181B81160
		private bool UseOptionE(); // 0x0000000181B81100-0x0000000181B81110
		private static bool IsSpecial(char ch); // 0x0000000181B7C190-0x0000000181B7C210
		private static bool IsStopperX(char ch); // 0x0000000181B7C210-0x0000000181B7C290
		private static bool IsQuantifier(char ch); // 0x0000000181B7C090-0x0000000181B7C110
		private bool IsTrueQuantifier(); // 0x0000000181B7C290-0x0000000181B7C410
		private static bool IsSpace(char ch); // 0x0000000181B7C110-0x0000000181B7C190
		private static bool IsMetachar(char ch); // 0x0000000181B7BFF0-0x0000000181B7C070
		private void AddConcatenate(int pos, int cch, bool isReplacement); // 0x0000000181B7A980-0x0000000181B7ABA0
		private void PushGroup(); // 0x0000000181B7CF50-0x0000000181B7CFD0
		private void PopGroup(); // 0x0000000181B7CDC0-0x0000000181B7CEC0
		private bool EmptyStack(); // 0x00000001813DEED0-0x00000001813DEEE0
		private void StartGroup(RegexNode openGroup); // 0x0000000181B80FB0-0x0000000181B81080
		private void AddAlternate(); // 0x0000000181B7A6E0-0x0000000181B7A800
		private void AddConcatenate(); // 0x0000000181B7A940-0x0000000181B7A980
		private void AddConcatenate(bool lazy, int min, int max); // 0x0000000181B7A800-0x0000000181B7A940
		private RegexNode Unit(); // 0x000000018031E110-0x000000018031E120
		private void AddUnitOne(char ch); // 0x0000000181B7AE00-0x0000000181B7AEE0
		private void AddUnitNotone(char ch); // 0x0000000181B7AD20-0x0000000181B7AE00
		private void AddUnitSet(string cc); // 0x0000000181B7AEE0-0x0000000181B7AF80
		private void AddUnitNode(RegexNode node); // 0x0000000180378110-0x0000000180378120
		private void AddUnitType(int type); // 0x0000000181B7AF80-0x0000000181B7B000
		private void AddGroup(); // 0x0000000181B7ABA0-0x0000000181B7AD20
		private void PushOptions(); // 0x0000000181B7CFD0-0x0000000181B7D060
		private void PopOptions(); // 0x0000000181B7CEF0-0x0000000181B7CF50
		private bool EmptyOptionsStack(); // 0x0000000181B7BCF0-0x0000000181B7BD20
		private void PopKeepOptions(); // 0x0000000181B7CEC0-0x0000000181B7CEF0
		private ArgumentException MakeException(string message); // 0x0000000181B7C410-0x0000000181B7C490
		private int Textpos(); // 0x000000018033D790-0x000000018033D7A0
		private void Textto(int pos); // 0x000000018033ED10-0x000000018033ED20
		private char RightCharMoveRight(); // 0x0000000181B7D0E0-0x0000000181B7D110
		private void MoveRight(); // 0x0000000181B7C4A0-0x0000000181B7C4B0
		private void MoveRight(int i); // 0x0000000181B7C4B0-0x0000000181B7C4C0
		private void MoveLeft(); // 0x0000000181B7C490-0x0000000181B7C4A0
		private char CharAt(int i); // 0x0000000181B7B730-0x0000000181B7B750
		internal char RightChar(); // 0x0000000181B7D110-0x0000000181B7D140
		private char RightChar(int i); // 0x0000000181B7D140-0x0000000181B7D170
		private int CharsRight(); // 0x0000000181B7B750-0x0000000181B7B770
	}
}
