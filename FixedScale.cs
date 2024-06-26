/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: Bugfix Fixed Scale Script SkyHop
 Datum: 04-05-2024
 */
using UnityEngine;

public class FixedScale : MonoBehaviour
{
    private Vector3 initialScale;

    void Start()
    {
        // Sla de oorspronkelijke schaal op
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Houd de schaal constant
        transform.localScale = initialScale;
    }
}
