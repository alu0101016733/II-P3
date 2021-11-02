
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterController : MonoBehaviour
{
    // singleton for game controller
    public static NewCharacterController controller_;

    public float speedMultiplier = 10f;
    private Transform transform_;
    public string controlHorizontal_ = "Horizontal";
    public string controlVertical_ = "Vertical";
    public string controlRotation_ = "Rotation";

    // check if already assigned to object and if so
    void Awake() {
        if(controller_ == null) { // will be asigned first time
            controller_ = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis(controlHorizontal_) * speedMultiplier * Time.deltaTime;
        float verticalMove = Input.GetAxis(controlVertical_) * speedMultiplier * Time.deltaTime;
        float rotationalMove = Input.GetAxis(controlRotation_) * speedMultiplier * Time.deltaTime;
        transform_.Translate(new Vector3(horizontalMove, 0f, verticalMove));
        transform_.Rotate(new Vector3(0f, rotationalMove, 0f));
    }
}
