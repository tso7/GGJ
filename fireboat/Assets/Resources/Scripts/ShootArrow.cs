using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

    public GameObject arrow;
    public float speed = 5.0f;

    public Transform startMarker;
    public GameObject[] endMarkers;
    public Transform[] missPoints;


    public bool isFired = false;

    private Animator anim;

    private GameObject curArrow;
    private GameObject curTarget;
    private int missPointIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isFired)
        {
            isFired = true;
            curArrow = (GameObject) Instantiate(arrow, startMarker.position, Quaternion.identity);
            anim = curArrow.GetComponent<Animator>();

            switch (SliderMovement.curState)
            {
                case SliderMovement.State.Sweet:
                    endMarkers = GameObject.FindGameObjectsWithTag("boat");
                    foreach (GameObject endMarker in endMarkers)
                    {
                        if (endMarker.transform.position.x < 0)
                        {
                            curTarget = endMarker;
                        }
                    }
                    break;
                case SliderMovement.State.Pffft:
                    missPointIndex = Random.Range(0, missPoints.Length);
                    curTarget = missPoints[missPointIndex].gameObject;
                    break;
                case SliderMovement.State.Meh:
                    missPointIndex = Random.Range(0, missPoints.Length);
                    curTarget = missPoints[missPointIndex].gameObject;
                    break;
            }
            
            StartCoroutine(ArrowTrigger(startMarker.position, curTarget, 2.0f));
            anim.SetBool("fired", true);
        }
        
                  
    }
    IEnumerator ArrowTrigger(Vector3 startPos, GameObject target, float time) {
        
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            Vector3 endPos = target.transform.position;
            endPos.y += 1.0f;
            i += Time.deltaTime * rate;
            curArrow.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        Destroy(curArrow);
        if (SliderMovement.curState == SliderMovement.State.Sweet)
        {
            target.GetComponent<ChangeSpriteOnInput>().ChangeSprite();
        }
        isFired = false;
    }
}
