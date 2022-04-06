using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public float speed = 0;
    float pos = 0;
    private RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.I.gameManagerStateMachine.CurrentState == GameManager.I.transitionState) pos += speed  * Time.deltaTime;
        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}
