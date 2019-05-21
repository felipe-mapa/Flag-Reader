using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour {
    public static UITest instance;

    private Animator anim;

    private void Awake() {
        instance = this;
        anim = GetComponent<Animator>();
    }

    public void Increment(int _increment) {
        anim.SetInteger("State", anim.GetInteger("State") + _increment);
    }
}
