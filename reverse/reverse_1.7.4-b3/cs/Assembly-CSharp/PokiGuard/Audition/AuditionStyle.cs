/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGuard.Audition
{
	public sealed class AuditionStyle // TypeDefIndex: 2545
	{
		// Fields
		public float BtnSize; // 0x10
		public float BtnBezel; // 0x14
		public float BtnX; // 0x18
		public float BtnY; // 0x1C
		public float BarW; // 0x20
		public float BarH; // 0x24
		public float BarY; // 0x28
		public float PillY; // 0x2C
		public float PillH; // 0x30
		public float ArrowSize; // 0x34
		public float ArrowGap; // 0x38
		public float PillPad; // 0x3C
		public string ArrowSkin; // 0x40
		public float ResultY; // 0x48
		public int ResultSize; // 0x4C
		public float StarsY; // 0x50
		public float StarSize; // 0x54
		public float SubY; // 0x58
		public int SubSize; // 0x5C
		public Color ColLeft; // 0x60
		public Color ColRight; // 0x70
		public Color ColDone; // 0x80
		public Color ColWrong; // 0x90
		public Color ColRev; // 0xA0
		public Color ColPerfect; // 0xB0
		public Color ColGreat; // 0xC0
		public Color ColCool; // 0xD0
		public Color ColBad; // 0xE0
		public Color ColMiss; // 0xF0
		public string TxtTouch; // 0x100
		public string TxtLabel; // 0x108
		public string TxtReverse; // 0x110
		public string TxtPerfect; // 0x118
		public string TxtGreat; // 0x120
		public string TxtCool; // 0x128
		public string TxtBad; // 0x130
		public string TxtMiss; // 0x138
		public string TxtMult; // 0x140
		public bool Fx; // 0x148
		public bool Shake; // 0x149
		public bool Sfx; // 0x14A
		public float Scrim; // 0x14C
		public float ResultHold; // 0x150
		private static bool _warned; // 0x00
	
		// Properties
		public bool LegacyArrows { get; } // 0x0000000180BC8710-0x0000000180BC87A0 
	
		// Constructors
		public AuditionStyle(); // 0x0000000180BCA070-0x0000000180BCA950
	
		// Methods
		private static Color Hex(string s); // 0x0000000180BC87A0-0x0000000180BC8860
		public static AuditionStyle Load(); // 0x0000000180BC8860-0x0000000180BC99A0
		private static float Num(JObject o, string key, float def, float min, float max); // 0x0000000180BC99A0-0x0000000180BC9C00
		private static string Skin(JObject o, string key, string def); // 0x0000000180BC9C00-0x0000000180BC9D30
		private static Color Col(JObject o, string key, Color def); // 0x0000000180BC9D30-0x0000000180BC9EF0
		private static string Str(JObject o, string key, string def, int maxLen); // 0x0000000180BC9EF0-0x0000000180BCA070
	}
}
