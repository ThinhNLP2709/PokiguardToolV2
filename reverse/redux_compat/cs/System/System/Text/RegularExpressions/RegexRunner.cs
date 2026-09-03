/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	public abstract class RegexRunner // TypeDefIndex: 8719
	{
		// Fields
		protected internal int runtextbeg; // 0x10
		protected internal int runtextend; // 0x14
		protected internal int runtextstart; // 0x18
		protected internal string runtext; // 0x20
		protected internal int runtextpos; // 0x28
		protected internal int[] runtrack; // 0x30
		protected internal int runtrackpos; // 0x38
		protected internal int[] runstack; // 0x40
		protected internal int runstackpos; // 0x48
		protected internal int[] runcrawl; // 0x50
		protected internal int runcrawlpos; // 0x58
		protected internal int runtrackcount; // 0x5C
		protected internal Match runmatch; // 0x60
		protected internal Regex runregex; // 0x68
		private int _timeout; // 0x70
		private bool _ignoreTimeout; // 0x74
		private int _timeoutOccursAt; // 0x78
		private int _timeoutChecksToSkip; // 0x7C
	
		// Constructors
		protected internal RegexRunner(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected internal Match Scan(Regex regex, string text, int textbeg, int textend, int textstart, int prevlen, bool quick, TimeSpan timeout); // 0x0000000181B83020-0x0000000181B83440
		private void StartTimeoutWatch(); // 0x0000000181B83440-0x0000000181B83470
		protected void CheckTimeout(); // 0x0000000181B82460-0x0000000181B82560
		private void DoCheckTimeout(); // 0x0000000181B82670-0x0000000181B82760
		protected abstract void Go();
		protected abstract bool FindFirstChar();
		protected abstract void InitTrackCount();
		private void InitMatch(); // 0x0000000181B82AC0-0x0000000181B82D70
		private Match TidyMatch(bool quick); // 0x0000000181B83470-0x0000000181B834E0
		protected void EnsureStorage(); // 0x0000000181B82970-0x0000000181B82AC0
		protected bool IsBoundary(int index, int startpos, int endpos); // 0x0000000181B82D70-0x0000000181B82E60
		protected bool IsECMABoundary(int index, int startpos, int endpos); // 0x0000000181B82E60-0x0000000181B82F50
		protected void DoubleTrack(); // 0x0000000181B828C0-0x0000000181B82970
		protected void DoubleStack(); // 0x0000000181B82810-0x0000000181B828C0
		protected void DoubleCrawl(); // 0x0000000181B82760-0x0000000181B82810
		protected void Crawl(int i); // 0x0000000181B82560-0x0000000181B82650
		protected int Popcrawl(); // 0x0000000181B82FE0-0x0000000181B83020
		protected int Crawlpos(); // 0x0000000181B82650-0x0000000181B82670
		protected void Capture(int capnum, int start, int end); // 0x0000000181B823D0-0x0000000181B82460
		protected void TransferCapture(int capnum, int uncapnum, int start, int end); // 0x0000000181B834E0-0x0000000181B83610
		protected void Uncapture(); // 0x0000000181B83610-0x0000000181B83660
		protected bool IsMatched(int cap); // 0x0000000181B82F50-0x0000000181B82F80
		protected int MatchIndex(int cap); // 0x0000000181B82F80-0x0000000181B82FB0
		protected int MatchLength(int cap); // 0x0000000181B82FB0-0x0000000181B82FE0
	}
}
