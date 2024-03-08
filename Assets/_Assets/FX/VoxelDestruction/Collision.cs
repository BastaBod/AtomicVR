using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Collider[] hitColliders;

    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;
    public float despawnTimer;
    private Transform rootParent;
    [SerializeField]
    private DESTROY destroyInstance;



    private void OnCollisionEnter(UnityEngine.Collision col)
    {
        destroy(col.contacts[0].point);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AZAAAZAZAZAZAZAAAAAAAAAAAAAAAAAAAAAAAAAA");
        destroy(transform.position);
    }

    public void destroy(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

        if (hitColliders.Length == 0)
            return;

        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.GetComponent<Rigidbody>() == null)
            {
                rootParent = hitCol.GetComponent<Transform>().root;
                if(rootParent.GetComponent<DESTROY>() != null)
                    rootParent.GetComponent<DESTROY>().hitProjectiles += 1;
                hitCol.GetComponent<MeshRenderer>().enabled = true;
                hitCol.gameObject.AddComponent<Rigidbody>();
                hitCol.GetComponent<Rigidbody>().mass = 500;
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                hitCol.GetComponent<Transform>().SetParent(null);
                StartCoroutine(DestroyAfterDelay(hitCol.gameObject, despawnTimer));
            }
        }
    }



    private IEnumerator DestroyAfterDelay(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Make sure the target still exists before attempting to destroy it
        if (target != null)
        {
            // Destroy the target GameObject
            Destroy(target);
        }
    }
}
