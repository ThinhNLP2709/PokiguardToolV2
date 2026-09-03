/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Windows.Speech
{
	public struct PhraseRecognizedEventArgs // TypeDefIndex: 7897
	{
		// Fields
		public readonly ConfidenceLevel confidence; // 0x00
		public readonly SemanticMeaning[] semanticMeanings; // 0x08
		public readonly string text; // 0x10
		public readonly DateTime phraseStartTime; // 0x18
		public readonly TimeSpan phraseDuration; // 0x20
	
		// Constructors
		internal PhraseRecognizedEventArgs(string text, ConfidenceLevel confidence, SemanticMeaning[] semanticMeanings, DateTime phraseStartTime, TimeSpan phraseDuration); // 0x0000000182209870-0x00000001822098D0
	}
}
