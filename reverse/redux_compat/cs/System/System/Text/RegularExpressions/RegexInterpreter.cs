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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexInterpreter : RegexRunner // TypeDefIndex: 8712
	{
		// Fields
		private readonly RegexCode _code; // 0x80
		private readonly CultureInfo _culture; // 0x88
		private int _operator; // 0x90
		private int _codepos; // 0x94
		private bool _rightToLeft; // 0x98
		private bool _caseInsensitive; // 0x99
	
		// Constructors
		public RegexInterpreter(RegexCode code, CultureInfo culture); // 0x0000000181B6EA30-0x0000000181B6EA90
	
		// Methods
		protected override void InitTrackCount(); // 0x0000000181B6E140-0x0000000181B6E170
		private void Advance(int i); // 0x0000000181B6B8F0-0x0000000181B6B970
		private void Goto(int newpos); // 0x0000000181B6E0B0-0x0000000181B6E140
		private void Textto(int newpos); // 0x0000000180378100-0x0000000180378110
		private void Trackto(int newpos); // 0x0000000181B6EA10-0x0000000181B6EA30
		private int Textstart(); // 0x0000000180B23260-0x0000000180B23270
		private int Textpos(); // 0x0000000180377930-0x0000000180377940
		private int Trackpos(); // 0x0000000181B6E9F0-0x0000000181B6EA10
		private void TrackPush(); // 0x0000000181B6E9B0-0x0000000181B6E9F0
		private void TrackPush(int I1); // 0x0000000181B6E940-0x0000000181B6E9B0
		private void TrackPush(int I1, int I2); // 0x0000000181B6E8B0-0x0000000181B6E940
		private void TrackPush(int I1, int I2, int I3); // 0x0000000181B6E800-0x0000000181B6E8B0
		private void TrackPush2(int I1); // 0x0000000181B6E790-0x0000000181B6E800
		private void TrackPush2(int I1, int I2); // 0x0000000181B6E700-0x0000000181B6E790
		private void Backtrack(); // 0x0000000181B6B970-0x0000000181B6BA50
		private void SetOperator(int op); // 0x0000000181B6E3B0-0x0000000181B6E3E0
		private void TrackPop(); // 0x0000000181B6E6E0-0x0000000181B6E6F0
		private void TrackPop(int framesize); // 0x0000000181B6E6F0-0x0000000181B6E700
		private int TrackPeek(); // 0x0000000181B6E6B0-0x0000000181B6E6E0
		private int TrackPeek(int i); // 0x0000000181B6E670-0x0000000181B6E6B0
		private void StackPush(int I1); // 0x0000000181B6E4D0-0x0000000181B6E510
		private void StackPush(int I1, int I2); // 0x0000000181B6E470-0x0000000181B6E4D0
		private void StackPop(); // 0x0000000181B6E450-0x0000000181B6E460
		private void StackPop(int framesize); // 0x0000000181B6E460-0x0000000181B6E470
		private int StackPeek(); // 0x0000000181B6E3E0-0x0000000181B6E410
		private int StackPeek(int i); // 0x0000000181B6E410-0x0000000181B6E450
		private int Operator(); // 0x000000018169CBC0-0x000000018169CBD0
		private int Operand(int i); // 0x0000000181B6E180-0x0000000181B6E1D0
		private int Leftchars(); // 0x0000000181B6E170-0x0000000181B6E180
		private int Rightchars(); // 0x0000000181B6E3A0-0x0000000181B6E3B0
		private int Bump(); // 0x0000000181B6BA70-0x0000000181B6BA90
		private int Forwardchars(); // 0x0000000181B6C110-0x0000000181B6C130
		private char Forwardcharnext(); // 0x0000000181B6C070-0x0000000181B6C110
		private bool Stringmatch(string str); // 0x0000000181B6E510-0x0000000181B6E670
		private bool Refmatch(int index, int len); // 0x0000000181B6E1D0-0x0000000181B6E3A0
		private void Backwardnext(); // 0x0000000181B6BA50-0x0000000181B6BA70
		private char CharAt(int j); // 0x0000000181B6BA90-0x0000000181B6BAB0
		protected override bool FindFirstChar(); // 0x0000000181B6BAB0-0x0000000181B6C070
		protected override void Go(); // 0x0000000181B6C130-0x0000000181B6E0B0
	}
}
