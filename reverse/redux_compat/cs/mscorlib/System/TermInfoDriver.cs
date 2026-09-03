/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal class TermInfoDriver : IConsoleDriver // TypeDefIndex: 2484
	{
		// Fields
		private static unsafe int* native_terminal_size; // 0x00
		private static int terminal_size; // 0x08
		private static readonly string[] locations; // 0x10
		private TermInfoReader reader; // 0x10
		private int cursorLeft; // 0x18
		private int cursorTop; // 0x1C
		private string title; // 0x20
		private string titleFormat; // 0x28
		private bool cursorVisible; // 0x30
		private string csrVisible; // 0x38
		private string csrInvisible; // 0x40
		private string clear; // 0x48
		private string bell; // 0x50
		private string term; // 0x58
		private StreamReader stdin; // 0x60
		private CStreamWriter stdout; // 0x68
		private int windowWidth; // 0x70
		private int windowHeight; // 0x74
		private int bufferHeight; // 0x78
		private int bufferWidth; // 0x7C
		private char[] buffer; // 0x80
		private int readpos; // 0x88
		private int writepos; // 0x8C
		private string keypadXmit; // 0x90
		private string keypadLocal; // 0x98
		private bool inited; // 0xA0
		private object initLock; // 0xA8
		private bool initKeys; // 0xB0
		private string origPair; // 0xB8
		private string origColors; // 0xC0
		private string cursorAddress; // 0xC8
		private ConsoleColor fgcolor; // 0xD0
		private string setfgcolor; // 0xD8
		private string setbgcolor; // 0xE0
		private int maxColors; // 0xE8
		private bool noGetPosition; // 0xEC
		private Hashtable keymap; // 0xF0
		private ByteMatcher rootmap; // 0xF8
		private int rl_startx; // 0x100
		private int rl_starty; // 0x104
		private byte[] control_characters; // 0x108
		private static readonly int[] _consoleColorToAnsiCode; // 0x18
		private char[] echobuf; // 0x110
		private int echon; // 0x118
	
		// Properties
		public bool Initialized { get; } // 0x000000018165FFF0-0x0000000181660000 
		public int WindowHeight { get; } // 0x0000000181660000-0x0000000181660030 
		public int WindowWidth { get; } // 0x0000000181660030-0x0000000181660060 
	
		// Constructors
		public TermInfoDriver(string term); // 0x000000018165F9F0-0x000000018165FFF0
		static TermInfoDriver(); // 0x000000018165F840-0x000000018165F9F0
	
		// Methods
		private static string TryTermInfoDir(string dir, string term); // 0x000000018165F4B0-0x000000018165F5C0
		private static string SearchTerminfo(string term); // 0x000000018165EFA0-0x000000018165F100
		private void WriteConsole(string str); // 0x000000018165F5C0-0x000000018165F5F0
		public void Init(); // 0x000000018165D960-0x000000018165E470
		private void IncrementX(); // 0x000000018165D670-0x000000018165D700
		public void WriteSpecialKey(ConsoleKeyInfo key); // 0x000000018165F640-0x000000018165F840
		public void WriteSpecialKey(char c); // 0x000000018165F5F0-0x000000018165F640
		public bool IsSpecialKey(ConsoleKeyInfo key); // 0x000000018165E500-0x000000018165E620
		public bool IsSpecialKey(char c); // 0x000000018165E4B0-0x000000018165E500
		private void GetCursorPosition(); // 0x000000018165CFB0-0x000000018165D270
		private void CheckWindowDimensions(); // 0x000000018165A350-0x000000018165A450
		private void AddToBuffer(int b); // 0x000000018165A220-0x000000018165A330
		private void AdjustBuffer(); // 0x000000018165A330-0x000000018165A350
		private ConsoleKeyInfo CreateKeyInfoFromInt(int n, bool alt); // 0x000000018165A450-0x000000018165A5A0
		private object GetKeyFromBuffer(bool cooked); // 0x000000018165D270-0x000000018165D670
		private ConsoleKeyInfo ReadKeyInternal(out bool fresh); // 0x000000018165E720-0x000000018165E940
		private bool InputPending(); // 0x000000018165E470-0x000000018165E4B0
		private void QueueEcho(char c); // 0x000000018165E620-0x000000018165E720
		private void Echo(ConsoleKeyInfo key); // 0x000000018165CE10-0x000000018165CFB0
		private void EchoFlush(); // 0x000000018165CDC0-0x000000018165CE10
		public int Read([In, Out] char[] dest, int index, int count); // 0x000000018165EC50-0x000000018165EFA0
		public ConsoleKeyInfo ReadKey(bool intercept); // 0x000000018165E940-0x000000018165EA00
		public string ReadLine(); // 0x000000018165EA00-0x000000018165EA10
		public string ReadToEnd(); // 0x000000018165EA10-0x000000018165EA20
		private string ReadUntilConditionInternal(bool haltOnNewLine); // 0x000000018165EA20-0x000000018165EC50
		public void SetCursorPosition(int left, int top); // 0x000000018165F100-0x000000018165F4B0
		private void CreateKeyMap(); // 0x000000018165A5A0-0x000000018165CDC0
		private void InitKeys(); // 0x000000018165D700-0x000000018165D960
		private void AddStringMapping(TermInfoStrings s); // 0x000000018165A080-0x000000018165A220
	}
}
