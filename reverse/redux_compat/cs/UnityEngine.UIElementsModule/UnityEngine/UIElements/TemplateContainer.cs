/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[HideInInspector]
	[UxmlElement("Instance")]
	public class TemplateContainer : BindableElement // TypeDefIndex: 4821
	{
		// Fields
		internal static readonly BindingId templateIdProperty; // 0x00
		internal static readonly BindingId templateSourceProperty; // 0x98
		[CompilerGenerated]
		private string _templateId_k__BackingField; // 0x1B8
		private VisualElement m_ContentContainer; // 0x1C0
		private VisualTreeAsset m_TemplateSource; // 0x1C8
	
		// Properties
		[CreateProperty(ReadOnly = true)]
		public string templateId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[CreateProperty(ReadOnly = true)]
		public VisualTreeAsset templateSource { get; internal set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public override VisualElement contentContainer { get; } // 0x0000000181CB22C0-0x0000000181CB22D0 
	
		// Constructors
		public TemplateContainer(); // 0x00000001823BC210-0x00000001823BC270
		public TemplateContainer(string templateId); // 0x00000001823BC1A0-0x00000001823BC210
		internal TemplateContainer(string templateId, VisualTreeAsset templateSource); // 0x00000001823BC270-0x00000001823BC2E0
		static TemplateContainer(); // 0x00000001823BBFD0-0x00000001823BC1A0
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void SetContentContainer(VisualElement content); // 0x0000000181975200-0x0000000181975220
	}
}
