using UnityEngine;

public class GateController : MonoBehaviour
{
    [Header("Escala")]
    public float scaleMin = 0.2f; // Tamaño mínimo relativo al original (20%)
    public float scaleMax = 1.2f; // Tamaño máximo relativo al original (120%)

    [Header("Animación")]
    public float speed = 1.0f;            // Velocidad de la animación
    public bool invertDirection = false; // Cambia el lado desde el que se encoge

    private Vector3 originalScale;
    private Vector3 originalPosition;

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    void Update()
    {
        // Crea un valor oscilante entre 0 y 1
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        float scaleFactor = Mathf.Lerp(scaleMin, scaleMax, t);

        // Crea nuevas escalas y posiciones
        Vector3 newScale = originalScale;
        Vector3 newPosition = originalPosition;

        // Solo afecta al eje X
        newScale.x = originalScale.x * scaleFactor;

        // Desplazamiento para que se encoja desde un lado
        float delta = (originalScale.x * (1f - scaleFactor)) / 2f;
        newPosition.x = originalPosition.x - delta * (invertDirection ? 1f : -1f);

        // Aplica transformaciones
        transform.localScale = newScale;
        transform.position = newPosition;
    }
}
