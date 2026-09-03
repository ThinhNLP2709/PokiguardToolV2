/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	internal class Normalization // TypeDefIndex: 2740
	{
		// Fields
		private static unsafe byte* props; // 0x00
		private static unsafe int* mappedChars; // 0x08
		private static unsafe short* charMapIndex; // 0x10
		private static unsafe short* helperIndex; // 0x18
		private static unsafe ushort* mapIdxToComposite; // 0x20
		private static unsafe byte* combiningClass; // 0x28
		private static object forLock; // 0x30
		public static readonly bool isReady; // 0x38
	
		// Constructors
		static Normalization(); // 0x000000018147E9A0-0x000000018147EC00
	
		// Methods
		private static uint PropValue(int cp); // 0x000000018147E080-0x000000018147E110
		private static int CharMapIdx(int cp); // 0x000000018147C6A0-0x000000018147C730
		private static byte GetCombiningClass(int c); // 0x000000018147DD00-0x000000018147DDB0
		private static int GetPrimaryCompositeFromMapIndex(int src); // 0x000000018147DDB0-0x000000018147DE60
		private static int GetPrimaryCompositeHelperIndex(int cp); // 0x000000018147DE60-0x000000018147DF10
		private static string Compose(string source, int checkType); // 0x000000018147CC40-0x000000018147CE20
		private static StringBuilder Combine(string source, int start, int checkType); // 0x000000018147C920-0x000000018147CA60
		private static void Combine(StringBuilder sb, int i, int checkType); // 0x000000018147CA60-0x000000018147CC40
		private static int CombineHangul(StringBuilder sb, string s, int current); // 0x000000018147C730-0x000000018147C920
		private static int Fetch(StringBuilder sb, string s, int i); // 0x000000018147D8D0-0x000000018147D920
		private static int TryComposeWithPreviousStarter(StringBuilder sb, string s, int current); // 0x000000018147E510-0x000000018147E810
		private static int TryCompose(int i, int starter, int candidate); // 0x000000018147E810-0x000000018147E9A0
		private static string Decompose(string source, int checkType); // 0x000000018147D020-0x000000018147D5D0
		private static void Decompose(string source, ref StringBuilder sb, int checkType); // 0x000000018147D5D0-0x000000018147D8D0
		private static void ReorderCanonical(string src, ref StringBuilder sb, int start); // 0x000000018147E250-0x000000018147E510
		private static void DecomposeChar(ref StringBuilder sb, ref int[] buf, string s, int i, int checkType, ref int start); // 0x000000018147CE20-0x000000018147D020
		public static NormalizationCheck QuickCheck(char c, int type); // 0x000000018147E110-0x000000018147E250
		private static int GetCanonicalHangul(int s, int[] buf, int bufIdx); // 0x000000018147D920-0x000000018147DA40
		private static int GetCanonical(int c, int[] buf, int bufIdx, int checkType); // 0x000000018147DA40-0x000000018147DD00
		public static string Normalize(string source, NormalizationForm normalizationForm); // 0x000000018147DF10-0x000000018147DFE0
		public static string Normalize(string source, int type); // 0x000000018147DFE0-0x000000018147E080
		private static void load_normalization_resource(out IntPtr props, out IntPtr mappedChars, out IntPtr charMapIndex, out IntPtr helperIndex, out IntPtr mapIdxToComposite, out IntPtr combiningClass); // 0x000000018147EC00-0x000000018147EC10
	}
}
