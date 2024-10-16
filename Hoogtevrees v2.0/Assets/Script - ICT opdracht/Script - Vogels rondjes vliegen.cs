using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BirdMovement : MonoBehaviour
{
    public float speed = 5f; // Snelheid van de vogel
    public float radius = 20f; // Straal van de cirkel waar de vogel omheen vliegt
    public Vector3 centerPoint = Vector3.zero; // Het middelpunt van de cirkel
    private float angle = 0f; // De huidige hoek van de vogel op de cirkel
 
    private Animator animator; // Animator referentie
 
    // Start wordt één keer aangeroepen bij het starten van het spel
    void Start()
    {
        // Haal de Animator op van het vogelobject
        animator = GetComponent<Animator>();
 
        // Controleer of de Animator bestaat en start de vleugel-fladder-animatie
        if (animator != null)
        {
            animator.SetBool("IsFlying", true); // Zet de parameter "IsFlying" aan om de fladder-animatie te starten
        }
 
        // Startpositie van de vogel op de cirkel
        transform.position = CalculatePositionOnCircle(angle);
    }
 
    // Update wordt één keer per frame aangeroepen
    void Update()
    {
        // Update de hoek op basis van de snelheid van de vogel
        angle += speed * Time.deltaTime;
 
        // Bereken de nieuwe positie op de cirkel
        Vector3 newPos = CalculatePositionOnCircle(angle);
 
        // Beweeg de vogel naar de nieuwe positie
        transform.position = newPos;
 
        // Zorg dat de vogel naar de vliegrichting kijkt (om de cirkel heen)
        Vector3 direction = newPos - centerPoint; // Richting van de vogel naar het midden van de cirkel
        transform.rotation = Quaternion.LookRotation(Vector3.Cross(direction, Vector3.up));
 
        // Pas de fladderende animatiesnelheid aan op basis van de snelheid
        if (animator != null)
        {
            animator.SetFloat("FlapSpeed", speed); // Pas de snelheid van de vleugels aan op basis van de vliegsnelheid
        }
    }
 
    // Functie om de positie van de vogel op een cirkel te berekenen
    Vector3 CalculatePositionOnCircle(float angle)
    {
        // Bereken de x- en z-posities op basis van de sinus en cosinus van de hoek
        float x = centerPoint.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.z + Mathf.Sin(angle) * radius;
 
        // Retourneer de nieuwe positie op de cirkel (hoogte van de vogel blijft constant)
        return new Vector3(x, transform.position.y, z);
    }
}