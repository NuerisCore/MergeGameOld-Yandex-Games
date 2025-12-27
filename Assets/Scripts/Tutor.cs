using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    public static Tutor instance;
    public int quque = 0;
    public float speed = 5f;

    private void Awake()
    {
        instance = this;
        quque = 0;
    }

    public Transform target1;
    public Transform target2;

    private void OnEnable()
    {
        if (MainController.instance.Level != 1) gameObject.SetActive(false);
        target1 = null;
        target2 = null;
        FinTargets();
    }

    private void LateUpdate()
    {
        if ((target1 == null || target2 == null)) FinTargets();
        else
        {
            if (Vector2.Distance(transform.position, target2.position) < 0.1f) transform.position = target1.position;
            else transform.position = Vector2.MoveTowards(transform.position, target2.position, speed + Vector2.Distance(transform.position, target2.position) / 50f);
        }
    }

    private void FinTargets()
    {
        var a = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < a.Length; i++)
        {
            if (quque == 0)
            {
                if (a[i].GetComponent<IconController>().id == 21 && target1 == null) target1 = a[i].transform;
                else if (a[i].GetComponent<IconController>().id == 21 && target2 == null)
                {
                    target2 = a[i].transform;
                    quque++;
                    break;
                }
            }
            else if (quque == 1)
            {
                if (a[i].GetComponent<IconController>().id == 12 && target1 == null) target1 = a[i].transform;
                else if (a[i].GetComponent<IconController>().id == 12 && target1.GetComponent<IconController>().id == 12)
                {
                    target2 = a[i].transform;
                    quque++;
                    break;
                }
            }
            else if (quque == 2)
            {
                if (a[i].GetComponent<IconController>().id == 12 && target1 == null) target1 = a[i].transform;
                else if (a[i].GetComponent<IconController>().id == 12 && target1.GetComponent<IconController>().id == 12)
                {
                    target2 = a[i].transform;
                    quque++;
                    break;
                }
            }
            else if (quque == 3)
            {
                target2 = GameObject.FindGameObjectWithTag("Respawn").transform;
                if (a[i].GetComponent<IconController>().id > 33)
                {
                    target1 = a[i].transform;
                    break;
                }
            }
        }

        if (target1 != null) transform.position = target1.position;
    }
}
