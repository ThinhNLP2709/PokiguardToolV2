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
	public sealed class DictationRecognizer // TypeDefIndex: 7887
	{
		// Fields
		private IntPtr m_Recognizer; // 0x10
		[CompilerGenerated]
		private DictationHypothesisDelegate DictationHypothesis; // 0x18
		[CompilerGenerated]
		private DictationResultDelegate DictationResult; // 0x20
		[CompilerGenerated]
		private DictationCompletedDelegate DictationComplete; // 0x28
		[CompilerGenerated]
		private DictationErrorHandler DictationError; // 0x30
	
		// Nested types
		public delegate void DictationHypothesisDelegate(string text); // TypeDefIndex: 7888; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void DictationResultDelegate(string text, ConfidenceLevel confidence); // TypeDefIndex: 7889; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void DictationCompletedDelegate(DictationCompletionCause cause); // TypeDefIndex: 7890; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void DictationErrorHandler(string error, int hresult); // TypeDefIndex: 7891; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Methods
		[RequiredByNativeCode]
		private void DictationRecognizer_InvokeHypothesisGeneratedEvent(IntPtr keyword, int keywordLength); // 0x0000000182203A60-0x0000000182203AC0
		[RequiredByNativeCode]
		private void DictationRecognizer_InvokeResultGeneratedEvent(IntPtr keyword, int keywordLength, ConfidenceLevel minimumConfidence); // 0x0000000182203AC0-0x0000000182203B30
		[RequiredByNativeCode]
		private void DictationRecognizer_InvokeCompletedEvent(DictationCompletionCause cause); // 0x00000001803721F0-0x0000000180372210
		[RequiredByNativeCode]
		private void DictationRecognizer_InvokeErrorEvent(string error, int hresult); // 0x0000000182203A40-0x0000000182203A60
	}
}
