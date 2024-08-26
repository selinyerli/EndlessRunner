using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float leftRightSpeed = 4f;
    public static bool CanMove = false;
    public bool isJumping = false;
    private bool comingDown = false;
    public GameObject playerObject;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = playerObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!CanMove) return;

        // Forward Movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position;
        newPosition.x += horizontalInput * leftRightSpeed * Time.deltaTime;

        // Clamp horizontal position to the level boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, LevelBoundary.leftSide, LevelBoundary.rightSide);
        transform.position = newPosition;

        // Jump Movement
        if (!isJumping && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)))
        {
            StartCoroutine(JumpSequence());
        }
    }

    IEnumerator JumpSequence()
    {
        isJumping = true;
        playerAnimator.Play("Jump");

        float jumpDuration = 0.45f;
        float jumpHeight = 3f;

        float elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * jumpHeight), Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        comingDown = true;

        elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * jumpHeight), Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
        comingDown = false;
        playerAnimator.Play("Standard Run");
    }
}
