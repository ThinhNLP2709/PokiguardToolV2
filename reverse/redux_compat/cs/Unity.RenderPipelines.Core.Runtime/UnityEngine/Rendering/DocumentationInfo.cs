/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DocumentationInfo // TypeDefIndex: 5535
	{
		// Fields
		private const string fallbackVersion = "13.1"; // Metadata: 0x006615E8
		private const string packageDocumentationUrl = "https://docs.unity3d.com/Packages/{0}@{1}/manual/"; // Metadata: 0x006615ED
		private const string url = "https://docs.unity3d.com/Packages/{0}@{1}/manual/{2}.html{3}"; // Metadata: 0x0066161F
		private const string k_ManualUrlFormat = "https://docs.unity3d.com/{0}/Documentation/Manual/{1}.html{2}"; // Metadata: 0x0066165C
		private const string k_ManualFallbackUrlFormat = "https://docs.unity3d.com/Manual/{0}.html{1}"; // Metadata: 0x0066169A
	
		// Properties
		public static string version { get; } // 0x0000000181E53A00-0x0000000181E53A30 
	
		// Nested types
		public enum Location // TypeDefIndex: 5536
		{
			Package = 0,
			Manual = 1
		}
	
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
		[Conditional("UNITY_EDITOR")]
		public sealed class SourceAttribute : Attribute // TypeDefIndex: 5537
		{
			// Fields
			[CompilerGenerated]
			private readonly Location _Location_k__BackingField; // 0x10
	
			// Properties
			public Location Location { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
			// Constructors
			public SourceAttribute(Location location); // 0x0000000181380310-0x0000000181380340
		}
	
		// Constructors
		public DocumentationInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static string GetPackageLink(string packageName, string packageVersion, string pageName); // 0x0000000181E53220-0x0000000181E533F0
		public static string GetPackageLink(string packageName, string packageVersion, string pageName, string pageHash); // 0x0000000181E533F0-0x0000000181E53600
		public static string GetPageLink(string packageName, string pageName); // 0x0000000181E53820-0x0000000181E53A00
		public static string GetPageLink(string packageName, string pageName, string pageHash); // 0x0000000181E53600-0x0000000181E53820
		public static string GetDefaultPackageLink(string packageName, string packageVersion); // 0x0000000181E53130-0x0000000181E53180
		public static string GetDefaultPackageLink(string packageName); // 0x0000000181E530D0-0x0000000181E53130
		public static string GetManualLink(string pageName, string pageHash = "" /* Metadata: 0x006615E7 */); // 0x0000000181E53180-0x0000000181E53220
	}
}
