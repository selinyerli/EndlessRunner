using UnityEngine;
using UnityEngine.Rendering;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLeft;
    public float internalRight;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
