using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class IconController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public IconAniController ani;
    public bool isHold = false;
    public bool isTaken;
    public float speed;

    public Sprite[] sprites;
    public int id;
    public int ids;

    private Image thhis;

    public Transform[] parents;
    public AudioSource audio;
    public AudioSource audio2;

    private void Awake()
    {
        thhis = GetComponent<Image>();
    }

    private void Update()
    {
        thhis.sprite = sprites[id];

        if (isHold && Input.GetMouseButton(0))
        {
            ani.activityO = 1;
            transform.position = Vector2.MoveTowards(transform.position, Input.mousePosition, speed + Vector2.Distance(transform.position, Input.mousePosition) / 7f);
        }
        else if (!isHold && Input.GetMouseButton(0))
        {
            transform.position = Vector2.MoveTowards(transform.position, ani.thisImage.transform.position, speed + Vector2.Distance(transform.position, ani.thisImage.transform.position) / 7f);
        }
        else
        {
            ani.activityO = 0;
            transform.position = Vector2.MoveTowards(transform.position, ani.thisImage.transform.position, speed + Vector2.Distance(transform.position, ani.thisImage.transform.position) / 7f);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        transform.SetParent(parents[0].transform);
        isHold = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        transform.SetParent(parents[1].transform);
        isHold = false;

        if (ovj != null && id > 33)
        {
            audio2.Play();
            ani.ani.SetBool("isActive", false);
            ani.thisImage.color = Color.white;
            MainController.instance.Merged(id, ids, ids, transform, gameObject, true);
            ovj.Entered(MainController.instance.Level, id);
        }
        else if (col != null && col.id == id)
        {
            audio.pitch = 1f + Random.Range(-0.1f, 0.1f);
            audio.Play();
            ani.ani.SetBool("isActive", false);
            ani.thisImage.color = Color.white;
            MainController.instance.Merged(id, col.ids, ids, col.transform, gameObject);
        }
        else if (col != null && col.id != id)
        {
            int idds = ids;
            Image a1 = ani.thisImage;
            Animator a2 = ani.ani;

            ids = col.ids;
            ani.thisImage = col.ani.thisImage;
            ani.ani = col.ani.ani;
            col.ids = idds;
            col.ani.ani = a2;
            col.ani.thisImage = a1;
        }
    }

    private IconController col;
    private OBJ ovj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.name == "T_T")
        {
            ovj = collision.GetComponent<OBJ>();
        }
        else if (!isHold && Input.GetMouseButton(0) && collision.GetComponent<IconController>().id != id)
        {
            ani.activityO = -1;
        }
        else if (!isHold && Input.GetMouseButton(0) && collision.GetComponent<IconController>().id == id)
        {   
            ani.activityO = 1;
        }
        else if (isHold && Input.GetMouseButton(0) && collision.GetComponent<IconController>())
        {
            col = collision.GetComponent<IconController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.name == "T_T")
        {

        }
        else if (!isHold && Input.GetMouseButton(0) && collision.GetComponent<IconController>().id != id)
        {
            ani.activityO = 0;
        }
        else if (!isHold && Input.GetMouseButton(0) && collision.GetComponent<IconController>().id == id)
        {
            ani.activityO = 0;
        }
        else if (isHold && Input.GetMouseButton(0) && col != null && collision.transform == col.transform)
        {
            col = null;
        }
    }
}
