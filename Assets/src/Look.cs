using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        Transform temp = transform.parent.GetComponent<Ruch>().B;

        if (temp != null)
        {
            Quaternion current = transform.localRotation;
            transform.LookAt(temp);
            transform.localRotation = Quaternion.Lerp(current, transform.localRotation, 5 * Time.deltaTime);
        }
	}
}
