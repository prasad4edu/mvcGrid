using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace mvcGrid.Models
{
    public class EmpBusinessLayer
    {
        public IEnumerable<Empstructure> getAllEmpDetails()
        {
            List<Empstructure> empList = new List<Empstructure>();
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;
                using (SqlConnection sqlCn = new SqlConnection(strConnection))
                {
                    SqlCommand sqlCmd = new SqlCommand("spGetAllEmpDetails", sqlCn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCn.Open();
                    SqlDataReader sqlDr = sqlCmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        Empstructure empstructure = new Empstructure();
                        empstructure.EmpID = Convert.ToInt32(sqlDr["Empid"]);
                        empstructure.EmpName = sqlDr["EmpName"].ToString();
                        empstructure.EmpLastName = sqlDr["EmpLastName"].ToString();
                        empstructure.EmpAge = Convert.ToInt32(sqlDr["EmpAge"]);
                        empstructure.EmpAddress = sqlDr["EmpAddress"].ToString();
                        empList.Add(empstructure);
                    }
                }

            }
            catch (Exception ex)
            { }
            return empList;
        }

        public Empstructure getEmpDetails(string ipEmpID)
        {
            Empstructure empstructure = new Empstructure();
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;
                using (SqlConnection sqlCn = new SqlConnection(strConnection))
                {
                    SqlCommand sqlCmd = new SqlCommand("spGetEmpDetail", sqlCn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmpID", ipEmpID);
                    sqlCn.Open();
                    SqlDataReader sqlDr = sqlCmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        
                        empstructure.EmpID = Convert.ToInt32(sqlDr["Empid"]);
                        empstructure.EmpName = sqlDr["EmpName"].ToString();
                        empstructure.EmpLastName = sqlDr["EmpLastName"].ToString();
                        empstructure.EmpAge = Convert.ToInt32(sqlDr["EmpAge"]);
                        empstructure.EmpAddress = sqlDr["EmpAddress"].ToString();
                      
                    }
                }

            }
            catch (Exception ex)
            { }
            return empstructure;
        }

        public int updateEmpDetails(Empstructure empStructure)
        {
            int sqlint = 0;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;               
                using (SqlConnection sqlCn = new SqlConnection(strConnection))
                {
                    SqlCommand sqlCmd = new SqlCommand("spUpdateEmpDetail", sqlCn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmpID", empStructure.EmpID);
                    sqlCmd.Parameters.AddWithValue("@EmpName", empStructure.EmpName);
                    sqlCmd.Parameters.AddWithValue("@EmpLastName", empStructure.EmpLastName);
                    sqlCmd.Parameters.AddWithValue("@EmpAge", empStructure.EmpAge);
                    sqlCmd.Parameters.AddWithValue("@EmpAddress", empStructure.EmpAddress);
                    sqlCn.Open();
                    sqlint = sqlCmd.ExecuteNonQuery();                   
                }                
            }
            catch (Exception ex)
            { }
            return sqlint;
        }

        public int deleteEmpDetails(string ipEmpID)
        {
            int sqlint = 0;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;
                using (SqlConnection sqlCn = new SqlConnection(strConnection))
                {
                    SqlCommand sqlCmd = new SqlCommand("spDeleteEmpDetail", sqlCn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmpID", ipEmpID);
                    sqlCn.Open();
                    sqlint = sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { }
            return sqlint;
        }

        public int insertEmpDetails(Empstructure empStructure)
        {
            int sqlint = 0;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;
                using (SqlConnection sqlCn = new SqlConnection(strConnection))
                {
                    SqlCommand sqlCmd = new SqlCommand("spInsertEmpDetail", sqlCn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@EmpName", empStructure.EmpName);
                    sqlCmd.Parameters.AddWithValue("@EmpLastName", empStructure.EmpLastName);
                    sqlCmd.Parameters.AddWithValue("@EmpAge", empStructure.EmpAge);
                    sqlCmd.Parameters.AddWithValue("@EmpAddress", empStructure.EmpAddress);
                    sqlCn.Open();
                    sqlint = sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { }
            return sqlint;
        }
    }
}