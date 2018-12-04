using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject circlePrefab, bulletPrefab;
    public Transform startingPoint;
    private int numberOfObjects = 15;
    private float spaceBetweenInstantiater = 2;
    public Color[] colors;
    private GameObject[] cubes;
    private float[] spectrum = new float[1024];

    void Start()
	{
        generateInstantiater();
    }

	void Update()
	{
        createBullets();
    }

    // will create the bullets as according to the intensity of the song
    private void createBullets()
    {
        if (circlePrefab == null || bulletPrefab == null)
            return;

         AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        //will chose certain circle to instantiate a bullet
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (spectrum[i] >= 0.08f) //here we are taking the 0.08f as the highest intensity
            {
                // the circle color will change when instantiating bullet
                cubes[i].GetComponent<MeshRenderer>().material.color = colors[0];

                //instantiate a bullet
                GameObject bullet = Instantiate(bulletPrefab, cubes[i].transform.position, cubes[i].transform.rotation);

                //maintain the position of the bullet
                bullet.transform.position = cubes[i].transform.position;
            }
            else
            {
                //the circle will stay as default color
                cubes[i].GetComponent<MeshRenderer>().material.color = colors[1];
            }
        }
    }

    //will generate the circles at the top of the screen
    private void generateInstantiater()
    {
        startingPoint.position = new Vector3(-numberOfObjects, startingPoint.position.y, startingPoint.position.z);

        //instantiate all circles 
        for (int i = 0; i < numberOfObjects; i++)
        {
            var vector = startingPoint.position;

            //position of the circel
            var pos = new Vector3(vector.x + (i * spaceBetweenInstantiater), vector.y, vector.z + 9);
           
            //instantiate the circle
            Instantiate(circlePrefab, pos, Quaternion.identity);
        }

        cubes = GameObject.FindGameObjectsWithTag("cubes"); //add all the cubes in the array
    }
}
