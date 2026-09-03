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
using UnityEngine.UIElements.Layout;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Layout/Native/LayoutModel.h")]
	internal struct LayoutData : IStyleDataGroup<UnityEngine.UIElements.LayoutData> // TypeDefIndex: 4632
	{
		// Fields
		public static LayoutData Default; // 0x00
		public LayoutDirection Direction; // 0x00
		public LayoutFlexDirection FlexDirection; // 0x04
		public LayoutJustify JustifyContent; // 0x08
		public LayoutAlign AlignContent; // 0x0C
		public LayoutAlign AlignItems; // 0x10
		public LayoutAlign AlignSelf; // 0x14
		public LayoutPositionType PositionType; // 0x18
		public float AspectRatio; // 0x1C
		public LayoutWrap FlexWrap; // 0x20
		public LayoutOverflow Overflow; // 0x24
		public LayoutDisplay Display; // 0x28
		public float FlexGrow; // 0x2C
		public float FlexShrink; // 0x30
		public Length FlexBasis; // 0x34
		public Length ColumnGap; // 0x3C
		public Length RowGap; // 0x44
		public FixedBuffer4<float> Border; // 0x4C
		public FixedBuffer4<Length> Position; // 0x5C
		public FixedBuffer4<Length> Margin; // 0x7C
		public FixedBuffer4<Length> Padding; // 0x9C
		public FixedBuffer2<Length> MaxDimensions; // 0xBC
		public FixedBuffer2<Length> MinDimensions; // 0xCC
		public FixedBuffer2<Length> Dimensions; // 0xDC
	
		// Properties
		public Align alignContent { get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public Align alignItems { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public Align alignSelf { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public Ratio aspectRatio { get; set; } // 0x0000000182543880-0x0000000182543890 0x0000000182543E30-0x0000000182543E60
		public float borderBottomWidth { get; set; } // 0x0000000182543890-0x00000001825438D0 0x0000000182543E60-0x0000000182543EB0
		public float borderLeftWidth { get; set; } // 0x00000001825438D0-0x0000000182543910 0x0000000182543EB0-0x0000000182543F00
		public float borderRightWidth { get; set; } // 0x0000000182543910-0x0000000182543950 0x0000000182543F00-0x0000000182543F50
		public float borderTopWidth { get; set; } // 0x0000000182543950-0x0000000182543990 0x0000000182543F50-0x0000000182543FA0
		public Length bottom { get; set; } // 0x0000000182543990-0x00000001825439D0 0x0000000182543FA0-0x0000000182543FF0
		public DisplayStyle display { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public Length flexBasis { get; set; } // 0x0000000181E47350-0x0000000181E47360 0x0000000182544000-0x0000000182544010
		public FlexDirection flexDirection { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public float flexGrow { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x000000018206CC90-0x000000018206CCA0
		public float flexShrink { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
		public Length columnGap { get; set; } // 0x00000001825439D0-0x00000001825439E0 0x0000000182543FF0-0x0000000182544000
		public Wrap flexWrap { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public Length height { get; set; } // 0x00000001825439E0-0x0000000182543A20 0x0000000182544010-0x0000000182544060
		public Justify justifyContent { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public Length left { get; set; } // 0x0000000182543A20-0x0000000182543A60 0x0000000182544060-0x00000001825440B0
		public Length marginBottom { get; set; } // 0x0000000182543A60-0x0000000182543AA0 0x00000001825440B0-0x0000000182544100
		public Length marginLeft { get; set; } // 0x0000000182543AA0-0x0000000182543AE0 0x0000000182544100-0x0000000182544150
		public Length marginRight { get; set; } // 0x0000000182543AE0-0x0000000182543B20 0x0000000182544150-0x00000001825441A0
		public Length marginTop { get; set; } // 0x0000000182543B20-0x0000000182543B60 0x00000001825441A0-0x00000001825441F0
		public Length maxHeight { get; set; } // 0x0000000182543B60-0x0000000182543BA0 0x00000001825441F0-0x0000000182544240
		public Length maxWidth { get; set; } // 0x0000000182543BA0-0x0000000182543BE0 0x0000000182544240-0x0000000182544290
		public Length minHeight { get; set; } // 0x0000000182543BE0-0x0000000182543C20 0x0000000182544290-0x00000001825442E0
		public Length minWidth { get; set; } // 0x0000000182543C20-0x0000000182543C60 0x00000001825442E0-0x0000000182544330
		public OverflowInternal overflow { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public Length paddingBottom { get; set; } // 0x0000000182543C60-0x0000000182543CA0 0x0000000182544330-0x0000000182544380
		public Length paddingLeft { get; set; } // 0x0000000182543CA0-0x0000000182543CE0 0x0000000182544380-0x00000001825443D0
		public Length paddingRight { get; set; } // 0x0000000182543CE0-0x0000000182543D20 0x00000001825443D0-0x0000000182544420
		public Length paddingTop { get; set; } // 0x0000000182543D20-0x0000000182543D60 0x0000000182544420-0x0000000182544470
		public Position position { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public Length right { get; set; } // 0x0000000182543D60-0x0000000182543DA0 0x0000000182544470-0x00000001825444C0
		public Length rowGap { get; set; } // 0x0000000182543DA0-0x0000000182543DB0 0x00000001825444C0-0x00000001825444D0
		public Length top { get; set; } // 0x0000000182543DB0-0x0000000182543DF0 0x00000001825444D0-0x0000000182544520
		public Length width { get; set; } // 0x0000000182543DF0-0x0000000182543E30 0x0000000182544520-0x0000000182544570
	
		// Constructors
		static LayoutData(); // 0x00000001825436D0-0x0000000182543880
	
		// Methods
		public LayoutData GetDefault(); // 0x00000001825435F0-0x00000001825436D0
		public LayoutData Copy(); // 0x0000000182543560-0x00000001825435F0
		public void CopyFrom(ref LayoutData other); // 0x0000000182543440-0x0000000182543560
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
