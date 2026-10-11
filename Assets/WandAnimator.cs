using UnityEngine;

public class WandAnimator : MonoBehaviour
{
    public float swingAmount = 20f;
    public float swingSpeed = 10f;

    private Quaternion originalRotation;
    private bool isSwinging;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSwinging = true;
        }

        if (isSwinging)
        {
            Quaternion target = originalRotation * Quaternion.Euler(-swingAmount, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * swingSpeed);

            if (Quaternion.Angle(transform.localRotation, target) < 1f)
            {
                isSwinging = false;
            }
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, originalRotation, Time.deltaTime * swingSpeed);
        }
    }
}