using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

//---------------------------------------------------------------------------------
// Author		: Vincent Goh
// Date  		: 2019-04-23
// Description	: Write testing result to Excel file in Output folder.
//---------------------------------------------------------------------------------
public class MyRuntimeTest : MonoBehaviour {

	private string excelName;

	void Start() {
		RunTimeTest();
	}

	void RunTimeTest(){
		DateTime dt = DateTime.Now;
		excelName = dt.ToString("yyyy-MM-dd") + ".xls";

        string path = Application.dataPath + "/Output/";

        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        Debug.Log("streaming assets: " + Application.streamingAssetsPath);
            

        if (System.IO.File.Exists (path + excelName)) {
			Debug.Log ("File Exist: ["+path+"]");
            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow hRow = sheet.GetRow(0);
            IRow row = sheet.CreateRow(sheet.LastRowNum);

            for (int i = 0; i < hRow.LastCellNum; i++)
            {
                row.CreateCell(i).SetCellValue("F");
            }

            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");

            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }
             //*/
            //IWorkbook book = new HSSFWorkbook();
			//ISheet sheet = book.GetSheetAt(0); //GetSheet("Batch" + dt.ToString("yyyy-MM-dd"));

            //int lastRow = sheet.LastRowNum;
            //Debug.Log("Last Row: " + sheet.LastRowNum);
            //sheet.CreateRow(1).CreateCell(0).SetCellValue("Victor");
            //saveCreateCell
            //FileStream xfile = File.Create(path);
			//book.Write(xfile);
			//xfile.Close ();

		} else {
			Debug.Log ("File DOES NOT Exist");

			//*****
			IWorkbook book = new HSSFWorkbook();;
            //using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) {
            //	book = new XSSFWorkbook();
            //}
            ISheet sheet = book.CreateSheet("Batch"+ dt.ToString("yyyy-MM-dd"));
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Name");

            //*
            sheet.GetRow(0).CreateCell(1).SetCellValue("NRIC_Passport");
            sheet.GetRow(0).CreateCell(2).SetCellValue("StartTime");
            sheet.GetRow(0).CreateCell(3).SetCellValue("EndTime");
            sheet.GetRow(0).CreateCell(4).SetCellValue("Attempt");
            sheet.GetRow(0).CreateCell(5).SetCellValue("Step01");
            sheet.GetRow(0).CreateCell(6).SetCellValue("Step02");
            sheet.GetRow(0).CreateCell(7).SetCellValue("Step03");
            sheet.GetRow(0).CreateCell(8).SetCellValue("Step04");
            sheet.GetRow(0).CreateCell(9).SetCellValue("Step05");
            sheet.GetRow(0).CreateCell(10).SetCellValue("Step06");
            sheet.GetRow(0).CreateCell(11).SetCellValue("Step07");
            sheet.GetRow(0).CreateCell(12).SetCellValue("Step08");
            sheet.GetRow(0).CreateCell(13).SetCellValue("Step09");
            sheet.GetRow(0).CreateCell(14).SetCellValue("Step10");
            sheet.GetRow(0).CreateCell(15).SetCellValue("Step11");
            sheet.GetRow(0).CreateCell(16).SetCellValue("Step12");
            sheet.GetRow(0).CreateCell(17).SetCellValue("Step13");
            sheet.GetRow(0).CreateCell(18).SetCellValue("Step14");
            sheet.GetRow(0).CreateCell(19).SetCellValue("Step15");
            sheet.GetRow(0).CreateCell(20).SetCellValue("Step16");
            //******/

            sheet.CreateRow(sheet.LastRowNum+1).CreateCell(0).SetCellValue("-END-");
            Debug.Log("Last ROW: " + sheet.LastRowNum);

            //save
            FileStream xfile = File.Create(path+excelName);
            book.Write(xfile);
            xfile.Close();
            

        }
	}
}
