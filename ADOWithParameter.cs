using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentsOfADO
{
    class DMLWithParameter
    {
        SqlConnection cn = null;
        SqlCommand cm = null;
        SqlDataReader dr = null;
        public int InsertWithParameters()
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
                cm = new SqlCommand("Insert into EmployeeTab values(@ename,@salary,@deptno)", cn);
                cm.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cm.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cm.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cm.ExecuteNonQuery();
                //Console.WriteLine("one row added to table employee");
                
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
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee id which you want to deleted:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("delete from EmployeeTab where eid= " + eid + " ", cn);
                cm.Parameters.Add("@eid", SqlDbType.Int).Value =eid;
                cn.Open();
                int i = cm.ExecuteNonQuery();
                return i;
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee id which you want to update:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("update EmployeeTab set ename ='kajal',salary = 3345.5,deptno = 11 where eid=" + eid + " ", cn);
                cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
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
        public void SearchWithParameters()
        {
            try
            {
                Console.WriteLine("Enter id for search record:");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3dotnet;Integrated Security=True");
                cm = new SqlCommand("select ename,salary,deptno from EmployeeTab where eid=" + eid + " ", cn);

                cm.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    
                    
                        Console.WriteLine($"Name is: {dr["ename"]}");
                        Console.WriteLine($"Salary is: {dr["salary"]}");
                        Console.WriteLine($"Department no is: {dr["deptNo"]}");
                    
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
    class ADOWithParameter
    {
        static void Main()
        {
            DMLWithParameter dd = new DMLWithParameter();
            int op;
            do
            {
                Console.WriteLine("-------Menu-------");
                Console.WriteLine("1.InsertWithParameters \n 2.DeleteWithParameters \n 3.UpdateWithParameters \n 4.SearchWithParameters \n 5.Show Details \n 6.Exit");
                Console.WriteLine("Enter choice of operation which you want to perform:");
                var ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        dd.InsertWithParameters();
                        break;

                    case 2:
                        dd.DeleteWithParameters();
                        break;

                    case 3:
                        dd.UpdateWithParameters();
                        break;

                    case 4:
                        dd.SearchWithParameters();
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

            //dd.InsertWithParameters();
            //dd.DeleteWithParameters();
            // dd.UpdateWithParameters();
            //dd.SearchWithParameters();
            //dd.ShowData();
        }
    }
}
