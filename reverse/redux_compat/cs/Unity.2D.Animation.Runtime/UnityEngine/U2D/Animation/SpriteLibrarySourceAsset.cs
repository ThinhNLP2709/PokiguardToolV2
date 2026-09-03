/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class SpriteLibrarySourceAsset : ScriptableObject // TypeDefIndex: 14404
	{
		// Fields
		public const string defaultName = "New Sprite Library Asset"; // Metadata: 0x006A96C9
		public const string extension = ".spriteLib"; // Metadata: 0x006A96E2
		[SerializeField]
		private List<SpriteLibCategoryOverride> m_Library; // 0x18
		[SerializeField]
		private string m_PrimaryLibraryGUID; // 0x20
		[SerializeField]
		private long m_ModificationHash; // 0x28
		[SerializeField]
		private int m_Version; // 0x30
	
		// Properties
		public IReadOnlyList<SpriteLibCategoryOverride> library { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string primaryLibraryGUID { get; } // 0x00000001802F8630-0x00000001802F8640 
		public long modificationHash { get; } // 0x000000018033D240-0x000000018033D250 
		public int version { get; } // 0x000000018033D100-0x000000018033D110 
	
		// Constructors
		public SpriteLibrarySourceAsset(); // 0x0000000181C21DE0-0x0000000181C21E60
	
		// Methods
		public void InitializeWithAsset(SpriteLibrarySourceAsset source); // 0x0000000181C21AB0-0x0000000181C21B60
		public void SetLibrary(IList<SpriteLibCategoryOverride> newLibrary); // 0x0000000181C21C30-0x0000000181C21CF0
		public void SetPrimaryLibraryGUID(string newPrimaryLibraryGUID); // 0x0000000181C21CF0-0x0000000181C21D40
		public void AddCategory(SpriteLibCategoryOverride newCategory); // 0x0000000181C219D0-0x0000000181C21AB0
		public void RemoveCategory(SpriteLibCategoryOverride categoryToRemove); // 0x0000000181C21B60-0x0000000181C21BF0
		public void ClearCategories(); // 0x0000000180F96C70-0x0000000180F96CB0
		public void RemoveCategory(int indexToRemove); // 0x0000000181C21BF0-0x0000000181C21C30
		private void UpdateModificationHash(); // 0x0000000181C21D40-0x0000000181C21DE0
	}
}
