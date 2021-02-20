using UnityEngine;

public class Cubes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cubes")
        {
            other.gameObject.tag = "Normal";
            Controller.instance.TakeCubes(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<Cubes>();
            Destroy(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DropCubes")
        {
            other.gameObject.tag = "Normal";
            Controller.instance.DropCubes(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<Cubes>();
        }   
    }
}
