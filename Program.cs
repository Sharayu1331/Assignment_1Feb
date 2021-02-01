using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentsOfADO
{
    class DMLWithoutParameters
    {
        SqlConnection cn = null;
        SqlCommand cm = null;
        SqlDataReader dr = null;
        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Enter Employee name:");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee salary:");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee department no.");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("insert into EmployeeTab values('" + ename + "'," + salary + "," + deptno + ")", cn);
                cn.Open();
                int i = cm.ExecuteNonQuery();
                Console.WriteLine("one row added to table employee");
               
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
        public int DeleteOneRow()
        {
            try
            {
                Console.WriteLine("Enter employee id which you want to deleted:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("delete from EmployeeTab where eid= " + eid + " ", cn);
                cn.Open();
                int i = cm.ExecuteNonQuery();
                Console.WriteLine("Row is deleted");
                
                return i;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int UpdateOneRow()
        {
            try
            {
                Console.WriteLine("Enter employee id which you want to update:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("update EmployeeTab set ename ='kabir',salary = 3345.5,deptno = 10 where eid=" + eid + " ", cn);
                cn.Open();
                int i = cm.ExecuteNonQuery();
                Console.WriteLine("Row is Updated");

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
        public void SearchForRow()
        {
            try
            {
                Console.WriteLine("Enter id for search record:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("select ename,salary,deptno from EmployeeTab where eid="+eid+" ", cn);
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        Console.WriteLine($"Name is: {dr["ename"]}");
                        Console.WriteLine($"Salary is: {dr["salary"]}");
                        Console.WriteLine($"Department no is: {dr["deptNo"]}");
                    }
                }

            }
            catch (Exception ee)
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
    class Program
    {
        static void Main(string[] args)
        {
            DMLWithoutParameters dd = new DMLWithoutParameters();
           
            int op;
            do
            {
                Console.WriteLine("-------Menu-------");
                Console.WriteLine("1.Insert row \n 2.Delete row \n 3.Update row \n 4. Search row \n 5.Show the details \n 6.Exit");
                Console.WriteLine("Enter choice of operation which you want to perform:");
                var ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        dd.InsertOneRow();
                        break;

                    case 2:
                        dd.DeleteOneRow();
                        break;

                    case 3:
                        dd.UpdateOneRow();
                        break;

                    case 4:
                        dd.SearchForRow();
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
                
                
                    
               
            } while (op==1);
           
        }
    }
}
