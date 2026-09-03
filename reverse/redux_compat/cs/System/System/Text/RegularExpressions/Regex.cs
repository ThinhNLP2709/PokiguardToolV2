/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	public class Regex : ISerializable // TypeDefIndex: 8701
	{
		// Fields
		private static int s_cacheSize; // 0x00
		private static readonly Dictionary<CachedCodeEntryKey, CachedCodeEntry> s_cache; // 0x08
		private static int s_cacheCount; // 0x10
		private static CachedCodeEntry s_cacheFirst; // 0x18
		private static CachedCodeEntry s_cacheLast; // 0x20
		private static readonly TimeSpan s_maximumMatchTimeout; // 0x28
		internal static readonly TimeSpan s_defaultMatchTimeout; // 0x30
		public static readonly TimeSpan InfiniteMatchTimeout; // 0x38
		protected internal TimeSpan internalMatchTimeout; // 0x10
		protected internal string pattern; // 0x18
		protected internal RegexOptions roptions; // 0x20
		protected internal RegexRunnerFactory factory; // 0x28
		protected internal Hashtable caps; // 0x30
		protected internal Hashtable capnames; // 0x38
		protected internal string[] capslist; // 0x40
		protected internal int capsize; // 0x48
		internal ExclusiveReference _runnerref; // 0x50
		internal WeakReference<RegexReplacement> _replref; // 0x58
		internal RegexCode _code; // 0x60
		internal bool _refsInitialized; // 0x68
	
		// Properties
		public RegexOptions Options { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public bool RightToLeft { get; } // 0x0000000181B712B0-0x0000000181B712C0 
	
		// Nested types
		[IsReadOnly]
		internal struct CachedCodeEntryKey : IEquatable<CachedCodeEntryKey> // TypeDefIndex: 8702
		{
			// Fields
			private readonly RegexOptions _options; // 0x00
			private readonly string _cultureKey; // 0x08
			private readonly string _pattern; // 0x10
	
			// Constructors
			public CachedCodeEntryKey(RegexOptions options, string cultureKey, string pattern); // 0x0000000181A40C60-0x0000000181A40CA0
	
			// Methods
			public override bool Equals(object obj); // 0x0000000181B5C650-0x0000000181B5C730
			public bool Equals(CachedCodeEntryKey other); // 0x0000000181B5C5E0-0x0000000181B5C650
			public static bool operator ==(CachedCodeEntryKey left, CachedCodeEntryKey right); // 0x0000000181B5C7A0-0x0000000181B5C820
			public override int GetHashCode(); // 0x0000000181B5C730-0x0000000181B5C7A0
		}
	
		internal sealed class CachedCodeEntry // TypeDefIndex: 8703
		{
			// Fields
			public CachedCodeEntry Next; // 0x10
			public CachedCodeEntry Previous; // 0x18
			public readonly CachedCodeEntryKey Key; // 0x20
			public RegexCode Code; // 0x38
			public readonly Hashtable Caps; // 0x40
			public readonly Hashtable Capnames; // 0x48
			public readonly string[] Capslist; // 0x50
			public readonly int Capsize; // 0x58
			public readonly ExclusiveReference Runnerref; // 0x60
			public readonly WeakReference<RegexReplacement> ReplRef; // 0x68
	
			// Constructors
			public CachedCodeEntry(CachedCodeEntryKey key, Hashtable capnames, string[] capslist, RegexCode code, Hashtable caps, int capsize, ExclusiveReference runner, WeakReference<RegexReplacement> replref); // 0x0000000181B5C820-0x0000000181B5C8F0
		}
	
		// Constructors
		static Regex(); // 0x0000000181B713E0-0x0000000181B71550
		protected Regex(); // 0x0000000181B71B00-0x0000000181B71B70
		public Regex(string pattern); // 0x0000000181B71550-0x0000000181B715D0
		public Regex(string pattern, RegexOptions options); // 0x0000000181B71A70-0x0000000181B71B00
		private Regex(string pattern, RegexOptions options, TimeSpan matchTimeout, bool addToCache); // 0x0000000181B715D0-0x0000000181B71A70
	
		// Methods
		private CachedCodeEntry GetCachedCode(CachedCodeEntryKey key, bool isToAdd); // 0x0000000181B6F170-0x0000000181B6F2C0
		private CachedCodeEntry GetCachedCodeEntryInternal(CachedCodeEntryKey key, bool isToAdd); // 0x0000000181B6EC10-0x0000000181B6F170
		private void FillCacheDictionary(); // 0x0000000181B6EB30-0x0000000181B6EC10
		private static bool TryGetCacheValue(CachedCodeEntryKey key, out CachedCodeEntry entry); // 0x0000000181B711D0-0x0000000181B712A0
		private static bool TryGetCacheValueSmall(CachedCodeEntryKey key, out CachedCodeEntry entry); // 0x0000000181B71080-0x0000000181B711D0
		private static CachedCodeEntry LookupCachedAndPromote(CachedCodeEntryKey key); // 0x0000000181B6FBA0-0x0000000181B6FFC0
		public static bool IsMatch(string input, string pattern); // 0x0000000181B6F7E0-0x0000000181B6F940
		public static bool IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout); // 0x0000000181B6FA70-0x0000000181B6FBA0
		public bool IsMatch(string input); // 0x0000000181B6F940-0x0000000181B6F9E0
		public bool IsMatch(string input, int startat); // 0x0000000181B6F9E0-0x0000000181B6FA70
		public static Match Match(string input, string pattern); // 0x0000000181B70210-0x0000000181B70370
		public static Match Match(string input, string pattern, RegexOptions options, TimeSpan matchTimeout); // 0x0000000181B70060-0x0000000181B70180
		public Match Match(string input); // 0x0000000181B6FFC0-0x0000000181B70060
		public Match Match(string input, int startat); // 0x0000000181B70180-0x0000000181B70210
		public MatchCollection Matches(string input); // 0x0000000181B70370-0x0000000181B70540
		public MatchCollection Matches(string input, int startat); // 0x0000000181B70540-0x0000000181B70710
		public static string Replace(string input, string pattern, string replacement); // 0x0000000181B708B0-0x0000000181B70A90
		public static string Replace(string input, string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout); // 0x0000000181B70710-0x0000000181B708B0
		public string Replace(string input, string replacement); // 0x0000000181B70A90-0x0000000181B70BC0
		public string Replace(string input, string replacement, int count, int startat); // 0x0000000181B70BC0-0x0000000181B70CE0
		protected internal static void ValidateMatchTimeout(TimeSpan matchTimeout); // 0x0000000181B712C0-0x0000000181B713E0
		private static TimeSpan InitDefaultMatchTimeout(); // 0x0000000181B6F4E0-0x0000000181B6F6F0
		void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context); // 0x0000000181B71040-0x0000000181B71080
		public static string Escape(string str); // 0x0000000181B6EA90-0x0000000181B6EB30
		public override string ToString(); // 0x00000001802F8EC0-0x00000001802F8ED0
		public string GroupNameFromNumber(int i); // 0x0000000181B6F2C0-0x0000000181B6F3C0
		public int GroupNumberFromName(string name); // 0x0000000181B6F3C0-0x0000000181B6F4E0
		protected void InitializeReferences(); // 0x0000000181B6F6F0-0x0000000181B6F7E0
		internal Match Run(bool quick, int prevlen, string input, int beginning, int length, int startat); // 0x0000000181B70CE0-0x0000000181B71040
		protected internal bool UseOptionR(); // 0x0000000181B712B0-0x0000000181B712C0
		internal bool UseOptionInvariant(); // 0x0000000181B712A0-0x0000000181B712B0
	}
}
