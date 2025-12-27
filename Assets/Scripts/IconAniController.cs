using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IconAniController : MonoBehaviour
{
    public Image thisImage;
    public int activityO;

    public Color Green;
    public Color Red;
    public Color purple;

    public Animator ani;

    private IconController cont;

    private void LateUpdate()
    {
        if (cont == null) cont = GetComponent<IconController>();

        if (cont.id > 33 && activityO == 1)
        {
            ani.SetBool("isActive", true);
            thisImage.color = Color.Lerp(thisImage.color, purple, 0.05f);
        }
        else if (cont.id > 33)
        {
            ani.SetBool("isActive", false);
            thisImage.color = Color.Lerp(thisImage.color, purple, 0.05f);
        }
        else if (activityO == 1)
        {
            ani.SetBool("isActive", true);
            thisImage.color = Color.Lerp(thisImage.color, Green, 0.05f);
        }
        else if (activityO == 0)
        {
            ani.SetBool("isActive", false);
            thisImage.color = Color.Lerp(thisImage.color, Color.white, 0.05f);
        }
        else if (activityO == -1)
        {
            ani.SetBool("isActive", false);
            thisImage.color = Color.Lerp(thisImage.color, Red, 0.05f);
        }
    }
}
