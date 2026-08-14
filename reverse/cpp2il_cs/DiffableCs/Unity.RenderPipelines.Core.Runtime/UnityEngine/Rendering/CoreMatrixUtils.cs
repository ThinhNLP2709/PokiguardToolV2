namespace UnityEngine.Rendering;

public static class CoreMatrixUtils
{

	public static void MatrixTimesTranslation(ref Matrix4x4 inOutMatrix, Vector3 translation) { }

	private static Matrix4x4 MultiplyGenericOrthoMatrix(Matrix4x4 ortho, Matrix4x4 rhs) { }

	public static Matrix4x4 MultiplyOrthoMatrix(Matrix4x4 ortho, Matrix4x4 rhs, bool centered) { }

	private static Matrix4x4 MultiplyOrthoMatrixCentered(Matrix4x4 ortho, Matrix4x4 rhs) { }

	public static Matrix4x4 MultiplyPerspectiveMatrix(Matrix4x4 perspective, Matrix4x4 rhs) { }

	public static Matrix4x4 MultiplyProjectionMatrix(Matrix4x4 projMatrix, Matrix4x4 rhs, bool orthoCentered) { }

	public static void TranslationTimesMatrix(ref Matrix4x4 inOutMatrix, Vector3 translation) { }

}

