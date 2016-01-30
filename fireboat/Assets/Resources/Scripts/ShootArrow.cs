using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

    public Transform arrow;
   public float speed = 5.0f;

    public Transform startMarker;
    public Transform endMarker;

    public bool isFired = false;

    private Animator anim;

    private GameObject curArrow;

    void Start()
    {

    }

    void Update()
    {
        endMarker = GameObject.FindGameObjectWithTag("ship").transform;
        if (endMarker == null)
        {
            Debug.LogError("ship tag not found");
        }
        anim = GameObject.FindGameObjectWithTag("arrow").GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("arrow tag not found");
        }
        
        if (Input.GetKeyDown(KeyCode.S) && !isFired)
        {
            isFired = true;
            curArrow = Instantiate(arrow, startMarker.position, Quaternion.identity) as GameObject;
            StartCoroutine(ArrowTrigger(startMarker.position, endMarker.position, 2.0f));
            anim.SetBool("fired", true);
        }
        
                  
    }
    IEnumerator ArrowTrigger(Vector3 startPos, Vector3 endPos, float time) {
        Debug.Log(endPos);
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            endPos = GameObject.FindGameObjectWithTag("ship").transform.position;
            endPos.y += 1.0f;
            i += Time.deltaTime * rate;
            curArrow.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        Destroy(curArrow);
        isFired = false;
    }
}
