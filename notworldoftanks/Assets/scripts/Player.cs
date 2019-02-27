using UnityEngine;


public class Player : MonoBehaviour
{
    float speed = 1;
    public float maxMoveRange = 4;
    public float currentMoved = 0;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayerMovement()
    {
        if (currentMoved < maxMoveRange)
        {
            float amountToMove = speed * Time.deltaTime;

            if (Input.GetKey("a"))
            {
                gameObject.transform.position += Vector3.left * amountToMove;
                currentMoved += amountToMove;
            }
                
            if (Input.GetKey("d"))
            {
                gameObject.transform.position += Vector3.right * amountToMove;
                currentMoved += amountToMove;
            }
        }
    }
}
