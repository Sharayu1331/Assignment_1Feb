using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentsOfADO
{
    class DMLWithStoredProcedures
    {
        SqlConnection cn = null;
        SqlCommand cm = null;
        SqlDataReader dr = null;
        public int InsertWithSP()
        {
            try
            {
                //Console.WriteLine("Enter Employee ID.");
                //var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee name:");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee salary:");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee department no.");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("sp_InsertDetails", cn);
                cm.CommandType = CommandType.StoredProcedure;

                //cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cm.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cm.Parameters.Add("@esal", SqlDbType.Float).Value = salary;
                cm.Parameters.Add("@deptId", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cm.ExecuteNonQuery();
                

                return i;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int UpdateWithSP()
        {
            try
            {
               Console.WriteLine("Enter Employee ID.");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee name:");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee salary:");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee department no.");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("sp_UpdateEmp", cn);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cm.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cm.Parameters.Add("@esal", SqlDbType.Float).Value = salary;
                cm.Parameters.Add("@deptId", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cm.ExecuteNonQuery();
              
                
                return i;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int DeleteWithSp()
        {
            try
            {
                Console.WriteLine("Enter Employee ID.");
                var eid = Convert.ToInt32(Console.ReadLine());
               // Console.WriteLine("Enter Employee name:");
                //var ename = Console.ReadLine();
                //Console.WriteLine("Enter Employee salary:");
                //var salary = Convert.ToSingle(Console.ReadLine());
                //Console.WriteLine("Enter Employee department no.");
                //var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("sp_DeleteDetails", cn);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
               // cm.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                //cm.Parameters.Add("@esal", SqlDbType.Float).Value = salary;
                //cm.Parameters.Add("@deptId", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cm.ExecuteNonQuery();


                return i;



            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public void SearchDetailsWithSP()
        {
            try
            {
                Console.WriteLine("Enter Employee ID.");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("sp_SearchForDetails", cn);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        Console.WriteLine($"Name is: {dr["ename"]}");
                        Console.WriteLine($"Salary is: {dr["salary"]}");
                        Console.WriteLine($"Department name is: {dr["deptName"]}");
                    }
                }
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table after DML Command");
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("select * from EmployeeTab", cn);
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["ename"]} \t {dr["salary"]} \t {dr["deptno"]} ");
                }
                return 0;


            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }


    }
    class ADOWithStoredProcedures
    {
        static void Main()
        {
            DMLWithStoredProcedures dd = new DMLWithStoredProcedures();

            int op;
            do
            {
                Console.WriteLine("-------Menu-------");
                Console.WriteLine("1.InsertWithStoredProcedure \n 2.DeleteWithStoredProcedure \n 3.UpdateWithStoredProcedure \n 4. SearchWithStoredProcedure \n 5. Show the details \n 6.Exit ");
                Console.WriteLine("Enter choice of operation which you want to perform:");
                var ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        dd.InsertWithSP();
                        break;

                    case 2:
                        dd.DeleteWithSp();
                        break;

                    case 3:
                        dd.UpdateWithSP();
                        break;

                    case 4:
                        dd.SearchDetailsWithSP();
                        break;

                    case 5:
                        dd.ShowData();
                        break;

                    case 6:
                        Console.WriteLine("Exit");


                        break;

                    default:

                        break;

                }

                Console.WriteLine("Do you want to continue(1/0):");

                op = Convert.ToInt32(Console.ReadLine());




            } while (op == 1);
        }
    }
}
