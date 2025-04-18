using UnityEngine;

public class HoleHandler : MonoBehaviour
{
    public int NormalSphereLayer, FallingSphereLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == NormalSphereLayer)
        {
            other.gameObject.layer = FallingSphereLayer;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FallingSphereLayer)
        {
            other.gameObject.layer = NormalSphereLayer;
        }

        if (other.tag == "Eatable")
        {
            if (transform.position.y > other.transform.position.y)
            {
                other.gameObject.transform.parent = null;
                transform.parent.gameObject.GetComponent<Hole>().Eat(other.gameObject.GetComponent<MapObject>().FoodScore);
                Destroy(other.gameObject, 2f);
            }
        }
    }
}
