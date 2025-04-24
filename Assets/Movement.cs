using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController character;

    public Transform cameraObject;

    public Vector2 moveInput;

    public Vector2 lookInput;

    public Vector2 lookSense;
    
    
    public float moveSpeed = 5f;

    public float currentAngleX;

    public float minAngleX;

    public float maxAngleX;
     

    /************************/
    // Кастомні функції
    /**********************/
    void ReadInput_Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
    }
    void Move_FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = character.transform.TransformDirection(move);
        character.Move(move * Time.fixedDeltaTime * moveSpeed);
    }

    void Look_FixedUpdate()
    {
        Vector3 look = new Vector3(0, lookInput.x, 0);
        character.transform.Rotate(look * Time.fixedDeltaTime * lookSense.x);


        currentAngleX -= lookInput.y * Time.fixedDeltaTime*lookSense.y;
        currentAngleX = Mathf.Clamp(currentAngleX, minAngleX, maxAngleX);

        Vector3 cameraAngles=cameraObject.transform.eulerAngles;
        cameraAngles.x=currentAngleX;
        cameraObject.transform.eulerAngles=cameraAngles;
    }


    /************************/
    // Вбудовані евенти
    /**********************/

    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

     
    void Update()
    {
        ReadInput_Update();
    }
    void FixedUpdate()
    {
    
        Move_FixedUpdate();
        Look_FixedUpdate();
    }
}
