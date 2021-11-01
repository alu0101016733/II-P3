using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public float speed_ = 1f;
    private float passedTime = 0f;
    private Vector3 startPosition_;
    // Start is called before the first frame update
    void Start() {
        startPosition_ = transform.TransformDirection(Vector3.forward);
        ObjectA.nearPlayer += faceTowards;
    }

    // Update is called once per frame
    void Update() {
        passedTime += Time.deltaTime;
        Debug.DrawRay(transform.Find("DroneGuard").position, transform.TransformDirection(Vector3.forward)*5, Color.green);
        if (passedTime > 1f) {
            float singleStep = speed_ * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, startPosition_, singleStep, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    void faceTowards(float normDist) {
        passedTime = 0f;
        GameObject crystal = GameObject.FindGameObjectWithTag("crystal");
        Vector3 targetDirection = crystal.transform.position - transform.Find("DroneGuard").position;
        float singleStep = speed_ * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
