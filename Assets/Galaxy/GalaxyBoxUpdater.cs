using UnityEngine;
using System.Collections;

public class GalaxyBoxUpdater : MonoBehaviour
{
    public Material galaxyBox;

    Material workingMaterial;

	private void Start ()
    {
        workingMaterial = new Material(galaxyBox);
        RenderSettings.skybox = workingMaterial;
	}
	
	private void Update ()
    {
        workingMaterial.SetMatrix("_RotationMatrix", transform.localToWorldMatrix);
	}
}
