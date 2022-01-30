﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void Awake()
    {
        _hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            _hero.SetDirection(-1);
        } 
        else if (Input.GetKey(KeyCode.D)) 
        {
            _hero.SetDirection(1);
        } 
        else 
        {
            _hero.SetDirection(0);
        }
    }
}
