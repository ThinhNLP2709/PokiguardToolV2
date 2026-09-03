/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class LTRect // TypeDefIndex: 305
{
	// Fields
	public Rect _rect; // 0x10
	public float alpha; // 0x20
	public float rotation; // 0x24
	public Vector2 pivot; // 0x28
	public Vector2 margin; // 0x30
	public Rect relativeRect; // 0x38
	public bool rotateEnabled; // 0x48
	[HideInInspector]
	public bool rotateFinished; // 0x49
	public bool alphaEnabled; // 0x4A
	public string labelStr; // 0x50
	public LTGUI.Element_Type type; // 0x58
	public GUIStyle style; // 0x60
	public bool useColor; // 0x68
	public Color color; // 0x6C
	public bool fontScaleToFit; // 0x7C
	public bool useSimpleScale; // 0x7D
	public bool sizeByHeight; // 0x7E
	public Texture texture; // 0x80
	private int _id; // 0x88
	[HideInInspector]
	public int counter; // 0x8C
	public static bool colorTouched; // 0x00

	// Properties
	public bool hasInitiliazed { get; } // 0x00000001806F6E20-0x00000001806F6E30 
	public int id { get; } // 0x00000001806F6E80-0x00000001806F6E90 
	public float x { get; set; } // 0x00000001806F7160-0x00000001806F71B0 0x00000001806F76E0-0x00000001806F7740
	public float y { get; set; } // 0x00000001806F71B0-0x00000001806F7200 0x00000001806F7740-0x00000001806F77A0
	public float width { get; set; } // 0x00000001806F7110-0x00000001806F7160 0x00000001806F7680-0x00000001806F76E0
	public float height { get; set; } // 0x00000001806F6E30-0x00000001806F6E80 0x00000001806F7610-0x00000001806F7670
	public Rect rect { get; set; } // 0x00000001806F6E90-0x00000001806F7110 0x00000001806F7670-0x00000001806F7680

	// Constructors
	public LTRect(); // 0x00000001806F6C40-0x00000001806F6CD0
	public LTRect(Rect rect); // 0x00000001806F6CD0-0x00000001806F6D60
	public LTRect(float x, float y, float width, float height); // 0x00000001806F6B90-0x00000001806F6C40
	public LTRect(float x, float y, float width, float height, float alpha); // 0x00000001806F6D60-0x00000001806F6E20
	public LTRect(float x, float y, float width, float height, float alpha, float rotation); // 0x00000001806F6AB0-0x00000001806F6B90

	// Methods
	public void setId(int id, int counter); // 0x00000001806F7530-0x00000001806F7540
	public void reset(); // 0x00000001806F74D0-0x00000001806F7510
	public void resetForRotation(); // 0x00000001806F7200-0x00000001806F74D0
	public LTRect setStyle(GUIStyle style); // 0x00000001806F7570-0x00000001806F7590
	public LTRect setFontScaleToFit(bool fontScaleToFit); // 0x00000001806F7520-0x00000001806F7530
	public LTRect setColor(Color color); // 0x00000001806F7510-0x00000001806F7520
	public LTRect setAlpha(float alpha); // 0x00000001806BFCD0-0x00000001806BFCE0
	public LTRect setLabel(string str); // 0x00000001806F7540-0x00000001806F7560
	public LTRect setUseSimpleScale(bool useSimpleScale, Rect relativeRect); // 0x00000001806F7600-0x00000001806F7610
	public LTRect setUseSimpleScale(bool useSimpleScale); // 0x00000001806F7590-0x00000001806F7600
	public LTRect setSizeByHeight(bool sizeByHeight); // 0x00000001806F7560-0x00000001806F7570
	public override string ToString(); // 0x00000001806F68C0-0x00000001806F6AB0
}

