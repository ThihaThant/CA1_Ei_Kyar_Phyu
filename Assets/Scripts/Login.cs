using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPOI;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path="Users/Users.xlsx";
        HSSFWorkbook book=new HSSFWorkbook(new FileStream(@path, FileMode.Open));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
