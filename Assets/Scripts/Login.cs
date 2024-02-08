using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPOI;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Runtime.CompilerServices;
using NPOI.XSSF.UserModel;
using TMPro;
public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField username;
    public TMP_InputField password;
    ISheet sheet;
    void Start()
    {
        string path="Users/Users.xlsx";
        FileStream fs = new FileStream(@path, FileMode.Open);
        XSSFWorkbook book=new XSSFWorkbook(fs);
        sheet = book.GetSheet("sheet1");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void login()
    {
        
        for (int i = 1; i <= sheet.LastRowNum; i++)
        {
            if (username.text == sheet.GetRow(i).GetCell(1).ToString())
            {
                if (password.text == sheet.GetRow(i).GetCell(2).ToString())
                {
                    Debug.Log(username.text);
                }
            }
        }
    }
}
