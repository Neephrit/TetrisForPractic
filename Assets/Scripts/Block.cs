using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float previosTime;
    [SerializeField] private Vector3 rotationPoint;
    [SerializeField] private float fallTime = 0.8f;

    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grib = new Transform[width, height];
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!validMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!validMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
            
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!validMove())
                transform.position -= new Vector3(1, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        if (Time.time - previosTime > (Input.GetKeyDown(KeyCode.S) ? fallTime/10:fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!validMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                _addToGrib();
                _cheakLine();
                //_cheakHeight();
                this.enabled = false;
                FindAnyObjectByType<Spawner>().SpawnBloks();
            }
            previosTime = Time.time;            
        }
    }

    private void _cheakLine()
    {
        for(int i = height-1; i >= 0; i--)
        {
            if(_hasLine(i))
            {
                _deleteLine(i);
                FindAnyObjectByType<GameManager>().AddScore(10);
                _rowDown(i);
            }
        }
    }

    private bool _hasLine(int i)
    {
        for(int j=0; j<width; j++)
        {
            if (grib[j,i] == null)
                return false;
        }
        return true;
    }

    private void _deleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grib[j,i].gameObject);
            grib[j,i] = null;
        }
    }

    private void _rowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for(int j=0; j<width;j++)
            {
                if (grib[j,y] != null)
                {
                    grib[j,y-1]= grib[j,y];
                    grib[j,y] = null;
                    grib[j,y-1].transform.position-=new Vector3(0,1,0);
                }
            }
        }
    }
    private void _addToGrib()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);
            grib[roundedX, roundedY] = children;

            if (roundedY > 13)
            {
                FindAnyObjectByType<GameManager>().Dead();
            }
        }
        
    }
    private bool validMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);

            if(roundedX<0 || roundedX >= width || roundedY<0 || roundedY>=height)
                return false;
            if (grib[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
