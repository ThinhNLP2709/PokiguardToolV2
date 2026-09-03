/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine.Android
{
	[NativeAsStruct]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidConfiguration.bindings.h")]
	[RequiredByNativeCode]
	public sealed class AndroidConfiguration // TypeDefIndex: 14790
	{
		// Fields
		[CompilerGenerated]
		private int _colorMode_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _densityDpi_k__BackingField; // 0x14
		[CompilerGenerated]
		private float _fontScale_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _fontWeightAdjustment_k__BackingField; // 0x1C
		[CompilerGenerated]
		private AndroidKeyboard _keyboard_k__BackingField; // 0x20
		[CompilerGenerated]
		private AndroidHardwareKeyboardHidden _hardKeyboardHidden_k__BackingField; // 0x24
		[CompilerGenerated]
		private AndroidKeyboardHidden _keyboardHidden_k__BackingField; // 0x28
		[CompilerGenerated]
		private int _mobileCountryCode_k__BackingField; // 0x2C
		[CompilerGenerated]
		private int _mobileNetworkCode_k__BackingField; // 0x30
		[CompilerGenerated]
		private AndroidNavigation _navigation_k__BackingField; // 0x34
		[CompilerGenerated]
		private AndroidNavigationHidden _navigationHidden_k__BackingField; // 0x38
		[CompilerGenerated]
		private AndroidOrientation _orientation_k__BackingField; // 0x3C
		[CompilerGenerated]
		private int _screenHeightDp_k__BackingField; // 0x40
		[CompilerGenerated]
		private int _screenWidthDp_k__BackingField; // 0x44
		[CompilerGenerated]
		private int _smallestScreenWidthDp_k__BackingField; // 0x48
		[CompilerGenerated]
		private int _screenLayout_k__BackingField; // 0x4C
		[CompilerGenerated]
		private AndroidTouchScreen _touchScreen_k__BackingField; // 0x50
		[CompilerGenerated]
		private int _uiMode_k__BackingField; // 0x54
		[CompilerGenerated]
		private string _primaryLocaleCountry_k__BackingField; // 0x58
		[CompilerGenerated]
		private string _primaryLocaleLanguage_k__BackingField; // 0x60
	
		// Properties
		private int colorMode { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int densityDpi { [CompilerGenerated] get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public float fontScale { [CompilerGenerated] get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
		public int fontWeightAdjustment { [CompilerGenerated] get; } // 0x0000000180B232F0-0x0000000180B23300 
		public AndroidKeyboard keyboard { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public AndroidHardwareKeyboardHidden hardKeyboardHidden { [CompilerGenerated] get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public AndroidKeyboardHidden keyboardHidden { [CompilerGenerated] get; } // 0x0000000180377930-0x0000000180377940 
		public int mobileCountryCode { [CompilerGenerated] get; } // 0x00000001803B5DE0-0x00000001803B5DF0 
		public int mobileNetworkCode { [CompilerGenerated] get; } // 0x000000018033D100-0x000000018033D110 
		public AndroidNavigation navigation { [CompilerGenerated] get; } // 0x000000018033D0F0-0x000000018033D100 
		public AndroidNavigationHidden navigationHidden { [CompilerGenerated] get; } // 0x000000018047EDE0-0x000000018047EDF0 
		public AndroidOrientation orientation { [CompilerGenerated] get; } // 0x00000001804EFAC0-0x00000001804EFAD0 
		public int screenHeightDp { [CompilerGenerated] get; } // 0x000000018033D790-0x000000018033D7A0 
		public int screenWidthDp { [CompilerGenerated] get; } // 0x000000018033D780-0x000000018033D790 
		public int smallestScreenWidthDp { [CompilerGenerated] get; } // 0x000000018033D1C0-0x000000018033D1D0 
		private int screenLayout { [CompilerGenerated] get; } // 0x000000018033D1B0-0x000000018033D1C0 
		public AndroidTouchScreen touchScreen { [CompilerGenerated] get; } // 0x000000018033D660-0x000000018033D670 
		private int uiMode { [CompilerGenerated] get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		private string primaryLocaleCountry { [CompilerGenerated] get; } // 0x00000001802F4000-0x00000001802F4010 
		private string primaryLocaleLanguage { [CompilerGenerated] get; } // 0x0000000180333260-0x0000000180333490 
		public AndroidLocale[] locales { get; } // 0x0000000182148060-0x00000001821481C0 
		public AndroidColorModeHdr colorModeHdr { get; } // 0x0000000182148040-0x0000000182148050 
		public AndroidColorModeWideColorGamut colorModeWideColorGamut { get; } // 0x0000000182148050-0x0000000182148060 
		public AndroidScreenLayoutDirection screenLayoutDirection { get; } // 0x00000001821481C0-0x00000001821481D0 
		public AndroidScreenLayoutLong screenLayoutLong { get; } // 0x00000001821481D0-0x00000001821481E0 
		public AndroidScreenLayoutRound screenLayoutRound { get; } // 0x00000001821481E0-0x00000001821481F0 
		public AndroidScreenLayoutSize screenLayoutSize { get; } // 0x00000001821481F0-0x0000000182148200 
		public AndroidUIModeNight uiModeNight { get; } // 0x0000000182148200-0x0000000182148210 
		public AndroidUIModeType uiModeType { get; } // 0x0000000182148210-0x0000000182148220 
	
		// Methods
		public override string ToString(); // 0x0000000182147790-0x0000000182148040
	}
}
