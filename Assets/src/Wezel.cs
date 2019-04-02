using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Wezel : MonoBehaviour
{
    public Material linia = null;

    public Transform[] wae = new Transform[1];

    void Start()
    {
        for(int i = 0; i < wae.Length; ++i)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector3.zero;
            LineRenderer temp = obj.AddComponent<LineRenderer>();

            Vector3[] pos = new Vector3[2];
            pos[0] = transform.position;
            pos[1] = wae[i].position;

            temp.SetPositions(pos);
            temp.material = linia;
            temp.startWidth = 0.2f;
            temp.endWidth = 0.2f;
        }
        /*LineRenderer temp = gameObject.AddComponent<LineRenderer>();
        Vector3[] pos = new Vector3[2 * wae.Length];

        //Debug.Log(transform.name + " => " + wae.Length + " " + pos.Length);

        for (int i = 0; i < wae.Length; ++i)
        {
            pos[(2 * i) + 0] = wae[i].position;
            pos[(2 * i) + 1] = transform.position;
        }

        temp.SetPositions(pos);
        temp.material = linia;
        temp.startWidth = 0.2f;
        temp.endWidth = 0.2f;*/
    }

    private void OnDrawGizmos()
    {
        if (Selection.Contains(gameObject.GetInstanceID()))
        {
            for (int i = 0; i < wae.Length; ++i)
            {
                Gizmos.color = Color.red;

                if (wae != null && wae[i] != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(transform.position, wae[i].position);
                } else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(transform.position, 0.5f);
                }
            }
        }
    }
}
