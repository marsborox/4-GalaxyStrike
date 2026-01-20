using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float controlSpeed = 10f;
    [SerializeField] float xClampedRange=10f;
    [SerializeField] float yClamedRange=5f;

    [SerializeField] float controlRollFactor=20;
    [SerializeField] float controlPitchFactor = 20;
    [SerializeField] float rotationSpeed =10f;
    Vector2 movement;
    void Update()
    {
        //float xOffset = controlSpeed*Time.deltaTime;
        ProcessTranslation();
        ProcessRotation();
    }
    public void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos,-xClampedRange, xClampedRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clamedYPos = Mathf.Clamp(rawYPos, -yClamedRange, yClamedRange);

        transform.localPosition = new Vector3(clampedXPos, clamedYPos, 0f);
    }
    private void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        //Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        //transform.localRotation = targetRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation,rotationSpeed * Time.deltaTime);
    }
}
