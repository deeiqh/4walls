using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cow;
    Sprite[] cows;
    int cowsIdx = 0;

    float speed = 0.05f;

    float[] path = {-7f, -6.75f, -6.5f, -6.25f, 1f};
    int idx = 0;

    float x;

    float[] timeHalts = {0.25f, 0.25f, 0.25f, 0.25f};
    float time = 0;
    float timeStep = 0.01f;

    float scale = 1f;

    bool walk = false;

    void Start()
    {
        cow = GameObject.Find("cow");

        cows = Resources.LoadAll<Sprite>("Images/cow");

        cow.gameObject.GetComponent<SpriteRenderer>().sprite = cows[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!walk){
            if (idx < timeHalts.Length && time < timeHalts[idx]) {
                cow.gameObject.transform.localPosition = new Vector3(path[idx],0,0);
                cow.gameObject.transform.localScale = new Vector3(scale, scale, scale);
                time += timeStep;
            } else {
                time = 0;
                idx++;
                x = cow.gameObject.transform.localPosition.x;
                walk = true;
            }
        }

        if (walk) {
            if (idx < path.Length && x < path[idx]) {
                cow.gameObject.GetComponent<SpriteRenderer>().sprite = cows[cowsIdx%cows.Length];
                x += speed;
                cow.gameObject.transform.localPosition = new Vector3(x,0,0);
                scale -= 0.005f;
                cow.gameObject.transform.localScale = new Vector3(scale, scale,scale);
            } else {
                walk = false;
                cowsIdx ++;
                if (idx > path.Length) {
                    cow.gameObject.GetComponent<SpriteRenderer>().sprite = cows[0];
                }
            }
        }
    }
}
