using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrivesByFromRightEvent : Event
{
    public GameObject carPrefab;
    public int lastCar = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }

    public override void occur()
    {
        if (Timer.getTime() - lastCar < 11)
            return;
        lastCar = Timer.getTime();
        List<Color> colors = new List<Color> { Color.red, Color.blue, Color.yellow, Color.cyan, Color.black, Color.magenta };
        Color c = colors[UnityEngine.Random.Range(0, colors.Count)];
        GameObject car = (GameObject)GameObject.Instantiate(carPrefab, new Vector3(transform.position.x + 600, transform.position.y, transform.position.z + .5f), Quaternion.identity, transform);
        car.transform.localScale = new Vector3(car.transform.localScale.x * -.9f, car.transform.localScale.y * .9f, car.transform.localScale.z);
        car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z + UnityEngine.Random.Range(0, 0.1f));
        car.transform.GetChild(1).GetComponent<SpriteRenderer>().color = c;
        car.transform.GetChild(1).transform.position = car.transform.GetChild(1).transform.position - new Vector3(0, 0, -0.1f);
        car.GetComponent<Animator>().speed = UnityEngine.Random.Range(1f, 3f);
        base.occur();
    }
}
