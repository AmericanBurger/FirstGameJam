using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ruch : MonoBehaviour
{
    public Transform B = null;
    public GameObject particleprefab = null;
    public GameObject canvasprefab = null;
    public GameObject A = null;
    public GameObject D = null;
    public float speed = 1.0f;
    public bool isded = false;

    private GameObject[] canvas = new GameObject[2];
	void Start()
    {
        canvas[0] = null;
        canvas[1] = null;
    }

    int klinol = -1;

    void Update()
    {
        if (isded == false)
        {
            float distance = Vector3.Distance(B.position, transform.position);
            transform.position = Vector3.Lerp(transform.position, B.position, (Time.deltaTime / distance) * speed);

            Wezel w = B.GetComponent<Wezel>();
            if (w != null)
            {
                if (w.wae.Length == 1)
                {
                    if (distance < 1f)
                    {
                        B = w.wae[0];
                    }
                }
                else
                {
                    if (distance < 15f)
                    {
                        A.SetActive(true);
                        D.SetActive(true);
                        /*if(canvas[0] == null || canvas[1] == null)
                        {
                            for(int i = 0; i < canvas.Length; ++i)
                            {
                                Vector3 pos = B.position + ((w.wae[i].position - B.position).normalized * 3);
                                canvas[i] = Instantiate(canvasprefab, pos, Quaternion.identity);
                                canvas[i].transform.position = pos;
                                canvas[i].transform.LookAt(transform);
                                if (i == 0)
                                {
                                    canvas[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "A";
                                }
                                else
                                {
                                    canvas[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "D";
                                }
                            }
                        }*/
                        Time.timeScale = 0.2f;

                        if (w.wae.Length == 0)
                        {
                            Time.timeScale = 1.0f;

                            A.SetActive(false);
                            D.SetActive(false);
                        }

                        if (Input.GetKey(KeyCode.A))
                        {
                            klinol = 0;

                            A.SetActive(false);
                            D.SetActive(false);
                        }
                        else if (Input.GetKey(KeyCode.D))
                        {
                            klinol = 1;

                            A.SetActive(false);
                            D.SetActive(false);
                        }
                        /*else if (Input.GetKey(KeyCode.Alpha3))
                        {
                            klinol = 2;
                        }*/

                        if (distance < 1f)
                        {
                            Time.timeScale = 1.0f;
                            if (klinol > -1)
                            {
                                B = w.wae[klinol];
                                klinol = -1;
                                /*Destroy(canvas[0]);
                                Destroy(canvas[1]);
                                canvas[0] = null;
                                canvas[1] = null;*/
                                A.SetActive(false);
                                D.SetActive(false);
                            }
                            else
                            {
                                Destroy(transform.Find("Look").Find("Pioruny").gameObject);
                                Instantiate(
                                    particleprefab,
                                    transform.position,
                                    Quaternion.Euler(-90f, 0f, 0f)
                                );
                                isded = true;
                            }
                        }
                    } else
                    {
                        A.SetActive(false);
                        D.SetActive(false);
                    }
                }
            }
        }
    }
}
