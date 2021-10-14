using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Programming_DataSet

{

    class Program

    {

        static void Main(string[] args)

        {
            //--------------create dataset---------------
            // Question 2

            DataSet dsCollege = new DataSet("CollegeDS");

            // Dataset dsCOllege = new DataSet();

            // dsCollege.DataSetName = "CollegeDS"; Another way to write

            Console.WriteLine("\n\n\tThe name of the Dataset Object is : " + dsCollege.DataSetName);
            //-----------------------------------------------


            //--------------------setting tables------------------------
            // Question 3

            DataTable dtStudents = new DataTable("Students");

            DataTable dtCourses = new DataTable("Courses");

            DataTable dtStudentCourses = new DataTable("StudentCourses");
            //---------------------------------------------

            //----------------------------addding info into tABLES---------
            //Question 4 

            dsCollege.Tables.Add(dtStudents);

            dsCollege.Tables.Add(dtCourses);

            dsCollege.Tables.Add(dtStudentCourses);
            //------------------------------------------------

            //---------------------------------------------
            //Question 5

            Console.WriteLine("\n\n\tThe name of the Dataset Objects : " + dsCollege.Tables.Count); //Count displays number

            Console.WriteLine("\n\t " + dtStudents.TableName);

            Console.WriteLine("\n\t " + dtCourses.TableName);

            Console.WriteLine("\n\t " + dtStudentCourses.TableName);
            //-------------------------------------------------

            //---------------------------------------------
            //Question 6

            dtStudents.Columns.Add("StudentId", typeof(Int32));

            dtStudents.Columns.Add("FirstName", typeof(string));

            //dtStudents.Columns.Add("FirstName", System.Type.GetType("System.String"));

            dtStudents.Columns.Add("LastName", typeof(string));

            dtStudents.PrimaryKey = new DataColumn[] { dtStudents.Columns["StudentId"] };

            Console.WriteLine("\n\n\n");

            foreach (DataColumn dc in dtStudents.Columns)

            {

                Console.WriteLine("\n\t" + dc.ColumnName + "\t\t" + dc.DataType);

            }
            //---------------------------------------------------

            //-----------------------------adding students to table-----------------
            //Question 7

            //ADDING ROWS

            DataRow dr1 = dtStudents.NewRow();

            dr1["StudentId"] = 1111111;

            dr1["FirstName"] = "John";

            dr1["LastName"] = "Abbott";

            dtStudents.Rows.Add(dr1);

            //dtStudents.Rows.Add(1111111, "John", "Abbott");

            DataRow dr2 = dtStudents.NewRow();

            dr2["StudentId"] = 2222222;

            dr2["FirstName"] = "Mary";

            dr2["LastName"] = "Green";

            dtStudents.Rows.Add(dr2);

            DataRow dr3 = dtStudents.NewRow();

            dr3["StudentId"] = 3333333;

            dr3["FirstName"] = "Thomas";

            dr3["LastName"] = "Moore";

            dtStudents.Rows.Add(dr3);



            foreach (DataRow dr in dtStudents.Rows)

            {

                Console.WriteLine("\n\t" + dr["StudentId"] + "\t\t" + dr["FirstName"] + "\t\t" + dr["LastName"]);

            }

            //dtStudents.Rows.RemoveAt(2);

            Console.WriteLine("\n\n\n");
           

            foreach (DataRow dr in dtStudents.Rows)

            {

                Console.WriteLine("\n\t" + dr["StudentId"] + "\t\t" + dr["FirstName"] + "\t\t" + dr["LastName"]);

            }
            //-----------------------------------------------

            //------------------------------------1 primary key-------------------------------
            //Question 8

            dtCourses.Columns.Add("CourseCode", typeof(string));

            dtCourses.Columns.Add("CourseTitle", typeof(string));

            dtCourses.Columns.Add("TotalHour", typeof(Int32));

            dtCourses.PrimaryKey = new DataColumn[] { dtCourses.Columns["CourseCode"] };

            Console.WriteLine("\n\n\n");

            foreach (DataColumn dco in dtCourses.Columns)

            {

                Console.WriteLine("\n\t" + dco.ColumnName + "\t\t" + dco.DataType);

            }

            //--------------------------creating rows-------------------
            
            
            //Question 9

            dtCourses.Rows.Add("420-P16-AS", "Structured Programming", 90);

            dtCourses.Rows.Add("420-P25-AS", "Introduction to Object Programming", 75);

            dtCourses.Rows.Add("420-P34-AS", "Advanced Object Programming", 60);

            dtCourses.Rows.Add("420-P46-AS", "Event Programming", 90);

            dtCourses.Rows.Add("420-P55-AS", "Internet Programming I", 75);

            Console.WriteLine("\n\n\n");

            foreach (DataRow dcol in dtCourses.Rows)

            {

                Console.WriteLine("\n\t\t" + dcol["CourseCode"] + "\t\t" + dcol["CourseTitle"] + "\t\t\t" + dcol["TotalHour"]);

            }
            //--------------------------------------------------------------


            //--------------------------------two primary ids--------------------------
            //Question 10 

            dtStudentCourses.Columns.Add("StudentId", typeof(Int32));

            dtStudentCourses.Columns.Add("CourseCode", typeof(string));

            dtStudentCourses.PrimaryKey = new DataColumn[] { dtStudentCourses.Columns["StudentId"], dtStudentCourses.Columns["CourseCode"] };


            //Relations

            DataRelation drStoSC = new DataRelation("StoSC", dtStudents.Columns["StudentId"], dtStudentCourses.Columns["StudentId"]);

            DataRelation drCtoSC = new DataRelation("CtoSC", dtCourses.Columns["CourseCode"], dtStudentCourses.Columns["CourseCode"]);

            dsCollege.Relations.Add(drStoSC);

            dsCollege.Relations.Add(drCtoSC);



            Console.WriteLine("\n\n\n");

            foreach (DataColumn dsc in dtStudentCourses.Columns)

            {

                Console.WriteLine("\n\t" + dsc.ColumnName + "\t\t" + dsc.DataType);

            }
            //---------------------------------ADDing rows to primary key------------------------
            //Question 11

            dtStudentCourses.Rows.Add(1111111, "420-P16-AS");

            dtStudentCourses.Rows.Add(2222222, "420-P16-AS");

            dtStudentCourses.Rows.Add(1111111, "420-P25-AS");

            dtStudentCourses.Rows.Add(2222222, "420-P25-AS");

            dtStudentCourses.Rows.Add(3333333, "420-P34-AS");

            dtStudentCourses.Rows.Add(3333333, "420-P55-AS");

            Console.WriteLine("\n\n\n");

            foreach (DataRow dsco in dtStudentCourses.Rows)

            {

                Console.WriteLine("\n\t\t" + dsco["StudentId"] + "\t\t" + dsco["CourseCode"]);

            }
            //-------------------------------------------------------------

            //Question 12

            DataRow drStudent = dtStudents.Rows.Find(1111111);
            Console.WriteLine("\n\n\t\t\t\tCourse List");
            Console.WriteLine("\n\n\t\t" + "Student: " + drStudent["StudentId"] + "," + drStudent["FirstName"] + drStudent["LastName"]);
            Console.WriteLine("\n\n\n\tCourse Code" + "\tCourseTitle" + "\t\t\tTotal Hour");
            
            foreach (DataRow dr in dtStudentCourses.Rows)
            {
                if (Convert.ToInt32(dr["StudentId"])==1111111)
                 {
                    DataRow drCourse = dtCourses.Rows.Find(dr["CourseCode"]);

                    Console.Write("\n\t" + drCourse["CourseCode"] + "\t" + drCourse["CourseTitle"] + "\t\t\t" + drCourse["TotalHour"]);
                 }

            }
            Console.WriteLine("\n\n\tPress any key to exit the program...");
            Console.ReadKey();

        }
    }
}
