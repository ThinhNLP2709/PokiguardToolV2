namespace UnityEngine.Rendering.Universal;

internal static class ShaderPropertyId
{
	public static readonly int glossyEnvironmentColor; //Field offset: 0x0
	public static readonly int subtractiveShadowColor; //Field offset: 0x4
	public static readonly int glossyEnvironmentCubeMap; //Field offset: 0x8
	public static readonly int glossyEnvironmentCubeMapHDR; //Field offset: 0xC
	public static readonly int ambientSkyColor; //Field offset: 0x10
	public static readonly int ambientEquatorColor; //Field offset: 0x14
	public static readonly int ambientGroundColor; //Field offset: 0x18
	public static readonly int time; //Field offset: 0x1C
	public static readonly int sinTime; //Field offset: 0x20
	public static readonly int cosTime; //Field offset: 0x24
	public static readonly int deltaTime; //Field offset: 0x28
	public static readonly int timeParameters; //Field offset: 0x2C
	public static readonly int lastTimeParameters; //Field offset: 0x30
	public static readonly int scaledScreenParams; //Field offset: 0x34
	public static readonly int worldSpaceCameraPos; //Field offset: 0x38
	public static readonly int screenParams; //Field offset: 0x3C
	public static readonly int alphaToMaskAvailable; //Field offset: 0x40
	public static readonly int projectionParams; //Field offset: 0x44
	public static readonly int zBufferParams; //Field offset: 0x48
	public static readonly int orthoParams; //Field offset: 0x4C
	public static readonly int globalMipBias; //Field offset: 0x50
	public static readonly int screenSize; //Field offset: 0x54
	public static readonly int screenCoordScaleBias; //Field offset: 0x58
	public static readonly int screenSizeOverride; //Field offset: 0x5C
	public static readonly int viewMatrix; //Field offset: 0x60
	public static readonly int projectionMatrix; //Field offset: 0x64
	public static readonly int viewAndProjectionMatrix; //Field offset: 0x68
	public static readonly int inverseViewMatrix; //Field offset: 0x6C
	public static readonly int inverseProjectionMatrix; //Field offset: 0x70
	public static readonly int inverseViewAndProjectionMatrix; //Field offset: 0x74
	public static readonly int cameraProjectionMatrix; //Field offset: 0x78
	public static readonly int inverseCameraProjectionMatrix; //Field offset: 0x7C
	public static readonly int worldToCameraMatrix; //Field offset: 0x80
	public static readonly int cameraToWorldMatrix; //Field offset: 0x84
	public static readonly int shadowBias; //Field offset: 0x88
	public static readonly int lightDirection; //Field offset: 0x8C
	public static readonly int lightPosition; //Field offset: 0x90
	public static readonly int cameraWorldClipPlanes; //Field offset: 0x94
	public static readonly int billboardNormal; //Field offset: 0x98
	public static readonly int billboardTangent; //Field offset: 0x9C
	public static readonly int billboardCameraParams; //Field offset: 0xA0
	public static readonly int previousViewProjectionNoJitter; //Field offset: 0xA4
	public static readonly int viewProjectionNoJitter; //Field offset: 0xA8
	public static readonly int previousViewProjectionNoJitterStereo; //Field offset: 0xAC
	public static readonly int viewProjectionNoJitterStereo; //Field offset: 0xB0
	public static readonly int blitTexture; //Field offset: 0xB4
	public static readonly int blitScaleBias; //Field offset: 0xB8
	public static readonly int sourceTex; //Field offset: 0xBC
	public static readonly int scaleBias; //Field offset: 0xC0
	public static readonly int scaleBiasRt; //Field offset: 0xC4
	public static readonly int rtHandleScale; //Field offset: 0xC8
	public static readonly int rendererColor; //Field offset: 0xCC
	public static readonly int ditheringTexture; //Field offset: 0xD0
	public static readonly int ditheringTextureInvSize; //Field offset: 0xD4
	public static readonly int renderingLayerMaxInt; //Field offset: 0xD8
	public static readonly int renderingLayerRcpMaxInt; //Field offset: 0xDC
	public static readonly int overlayUITexture; //Field offset: 0xE0
	public static readonly int hdrOutputLuminanceParams; //Field offset: 0xE4
	public static readonly int hdrOutputGradingParams; //Field offset: 0xE8

	private static ShaderPropertyId() { }

}

