/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Windows.Speech
{
	public abstract class PhraseRecognizer // TypeDefIndex: 7885
	{
		// Fields
		protected IntPtr m_Recognizer; // 0x10
		[CompilerGenerated]
		private PhraseRecognizedDelegate OnPhraseRecognized; // 0x18
	
		// Nested types
		public delegate void PhraseRecognizedDelegate(PhraseRecognizedEventArgs args); // TypeDefIndex: 7886; 0x0000000180A6FF00-0x0000000180A6FF40
	
		// Methods
		[RequiredByNativeCode]
		private void InvokePhraseRecognizedEvent(IntPtr rawText, int rawTextLength, ConfidenceLevel confidence, SemanticMeaning[] semanticMeanings, long phraseStartFileTime, long phraseDurationTicks); // 0x00000001822098D0-0x0000000182209A50
		[RequiredByNativeCode]
		private static SemanticMeaning[] MarshalSemanticMeaning(IntPtr keys, IntPtr values, IntPtr valueSizes, int valueCount); // 0x0000000182209A50-0x0000000182209C90
	}
}
