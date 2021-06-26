using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public Vector2 bounds;

    private bool direction;

    private void Awake()
    {
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, bounds.x, this.gameObject.transform.localPosition.z);
        this.direction = true;
    }

    private void Update()
    {
        if (direction)
        {
            if (this.gameObject.transform.localPosition.y + speed > bounds.y)
            {
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, bounds.y, this.gameObject.transform.localPosition.z);
                this.direction = false;
            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y + speed, this.gameObject.transform.localPosition.z);
            }
        }
        else
        {
            if (this.gameObject.transform.localPosition.y - speed < bounds.x)
            {
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, bounds.x, this.gameObject.transform.localPosition.z);
                this.direction = true;

            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y - speed, this.gameObject.transform.localPosition.z);
            }
        }
    }
}
