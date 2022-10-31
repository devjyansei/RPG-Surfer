using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Touch touch;
    Vector3 touchDownPos;
    Vector3 touchUpPos;

    [SerializeField] float speed;
    [SerializeField] float sliderSpeed;
    bool isDragStarted;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragStarted = true;
                touchDownPos = touch.position;
                touchUpPos = touch.position;                
            }

        }
        if (isDragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchDownPos = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchUpPos = touch.position;
                isDragStarted = false;
            }
        }
       /* if (touch.phase == TouchPhase.Canceled)
        {
            isDragStarted = false;
        }*/
        if (CalculateDirection().x > 0 && isDragStarted)
        {
            transform.Translate(CalculateDirection().x * sliderSpeed * Time.deltaTime, 0, 1*speed*Time.deltaTime);
        }
        else if (CalculateDirection().x < 0 && isDragStarted)
        {
            transform.Translate(CalculateDirection().x * sliderSpeed * Time.deltaTime, 0, 1*speed*Time.deltaTime);

        }
        this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);//need normalize;
    }
    // HATA : ekrana basýlýnca hýz artýyor.
    Vector3 CalculateDirection()
    {
        Vector3 direction = (touchDownPos - touchUpPos).normalized;
        return direction;
    }
}
