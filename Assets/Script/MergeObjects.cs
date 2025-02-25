using UnityEngine;

public class MergeObjects : MonoBehaviour
{

    private Rigidbody rb;
    public bool triggerActivated = false;
    public GameObject objectToSpawn;
    public bool isMerging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        MergeObjects otherMergeScript = collision.gameObject.GetComponent<MergeObjects>();

        if (otherMergeScript != null && !isMerging && !otherMergeScript.isMerging)
        {
            isMerging = true;
            otherMergeScript.isMerging = true;

            Vector3 spawnPosition = (transform.position + collision.transform.position) / 2;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


    void GrabObject()
    {
        rb.isKinematic = false; // Active la physique pour grab
    }

    void ReleaseObject()
    {
        rb.isKinematic = true; // Désactive la physique pour qu'il ne tombe pas
    }
}

