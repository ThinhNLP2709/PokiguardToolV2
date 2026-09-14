/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGuard.Audition
{
	public sealed class AuditionChallenge // TypeDefIndex: 2547
	{
		// Fields
		public List<string> Display; // 0x10
		public List<string> Expected; // 0x18
		public int DurationMs; // 0x20
		public int PerfectStartMs; // 0x24
		public int PerfectEndMs; // 0x28
		public int GoodStart1Ms; // 0x2C
		public int GoodEnd1Ms; // 0x30
		public int GoodStart2Ms; // 0x34
		public int GoodEnd2Ms; // 0x38
		public int ReverseFrom; // 0x3C
		public int GreatMs; // 0x40
		public float MultPerfect; // 0x44
		public float MultGood; // 0x48
		public float MultBad; // 0x4C
		public long ChallengeId; // 0x50
	
		// Properties
		public int Count { get; } // 0x0000000180BCA950-0x0000000180BCA970 
	
		// Constructors
		public AuditionChallenge(); // 0x0000000180BCB1B0-0x0000000180BCB1E0
	
		// Methods
		public static string Opposite(string dir); // 0x0000000180BCA970-0x0000000180BCAA10
		public static string NormalizeLr(string raw); // 0x0000000180BCAA10-0x0000000180BCAC80
		public static AuditionChallenge FromService(); // 0x0000000180BCAC80-0x0000000180BCB1B0
	}
}
