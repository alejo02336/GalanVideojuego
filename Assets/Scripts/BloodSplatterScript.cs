using UnityEngine;
using System.Collections;

// Decompile by Si Borokokok

public class BloodSplatterScript : MonoBehaviour
{
	public Transform bloodPrefab;
	public int maxAmountBloodPrefabs = 20;
    private GameObject[] bloodInstances;
    public Transform bloodPosition;
	public Transform bloodRotation;
	public int bloodLocalRotationYOffset;
	
    public void Main()
    {
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bloodRotation.Rotate((float) 0, (float) bloodLocalRotationYOffset, (float) 0);
            Transform transform = Object.Instantiate(bloodPrefab, bloodPosition.position, bloodRotation.rotation) as Transform;
            bloodInstances = GameObject.FindGameObjectsWithTag("blood");
            if ((bloodInstances).Length >= maxAmountBloodPrefabs)
            {
                Destroy(bloodInstances[0]);
            }
        }
    }
}

