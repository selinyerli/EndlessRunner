using UnityEngine;
using UnityEngine.Rendering;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -2.3f;
    public static float rightSide = 2.3f;
    public float internalLeft;
    public float internalRight;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
