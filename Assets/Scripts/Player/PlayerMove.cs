using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float LeftRightSpeed = 4;


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)); 
        {
            if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
            
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * LeftRightSpeed * -1);
            }
                
        }
    }
}
