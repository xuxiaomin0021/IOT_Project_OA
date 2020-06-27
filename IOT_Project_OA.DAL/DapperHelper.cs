using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using IOT_Project_OA.Model;

namespace IOT_Project_OA.DAL
{

    public class DapperHelper
    {
        private const string connectionString = "Data Source=192.168.0.111;Initial Catalog=OA_Object;User ID=sa;PassWord=1234";

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public List<T> GetToList<T>() where T : class, new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                Type t = typeof(T);
                string sql = $"select * from {t.Name}";
                return conn.Query<T>(sql).ToList();
            }
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public T GetModel<T>(string sql) where T : class, new()
        {
            T model = new T();
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                model = conn.QueryFirstOrDefault<T>(sql);
            }
            return model;
        }

        /// <summary>
        /// 增删改 bu
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            int res = 0;
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                res = conn.Execute(sql);
            }
            return res;
        }

        /// <summary>
        /// 单表存储过程查询
        /// </summary>
        /// <typeparam name="T">接收数据的类</typeparam>
        /// <param name="tableName">要查询的表名</param>
        /// <param name="whereStr">查询的条件拼接语句</param>
        /// <param name="orderField">根据id字段进行排序</param>
        /// <param name="PageIndex">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<T> GetProcData<T>(string tableName,string whereStr,string orderField,int PageIndex) where T:class,new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                var param = new DynamicParameters();
                param.Add("@table",tableName);
                param.Add("@field","*");
                param.Add("@where",whereStr);
                param.Add("@order",orderField);
                param.Add("@pageSize",5);
                param.Add("@pageNumber",PageIndex);
                param.Add("@Total",0,DbType.Int32,ParameterDirection.Output);

                //返回的类
                ProcDataAndTotal<T> dataAndTotal = new ProcDataAndTotal<T>()
                {
                    ProcData = conn.Query<T>("SP_Paging1", param, commandType: CommandType.StoredProcedure).ToList(),
                    Total = param.Get<int>("@Total"),
                };
                return dataAndTotal;
            }
        }


        /// <summary>
        /// 多表联查的存储过程
        /// </summary>
        /// <typeparam name="T">接收参数的类</typeparam>
        /// <param name="param">存储过程的参数</param>
        /// <param name="procName">存储过程的名称</param>
        /// <returns></returns>
        public ProcDataAndTotal<T> GetProcData<T>(DynamicParameters param, string procName) where T : class, new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                //返回的类
                ProcDataAndTotal<T> dataAndTotal = new ProcDataAndTotal<T>()
                {
                    ProcData = conn.Query<T>(procName, param, commandType: CommandType.StoredProcedure).ToList(),
                    Total = param.Get<int>("@Total"),
                };
                return dataAndTotal;
            }
        }

        
        /// <summary>
        /// 泛型反射添加
        /// </summary>
        /// <typeparam name="T">添加的类</typeparam>
        /// <param name="model">添加的参数类</param>
        /// <returns></returns>
        public int AddData<T>(T model) where T : class, new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                Type t = model.GetType();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"insert into {t.Name} values (");
                PropertyInfo[] property = t.GetProperties();
                foreach (var item in property)
                {
                    stringBuilder.Append($"'{item.GetValue(model)}',");
                }
                string sql = stringBuilder.ToString().Substring(0,stringBuilder.Length-1)+")";
                return conn.Execute(sql);
            }
        }

        /// <summary>
        /// 反射删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">将要删除的记录的ID存在model中</param>
        /// <returns></returns>
        public int DeleteData<T>(T model) where T:class,new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                Type t = model.GetType();
                PropertyInfo[] property = t.GetProperties();
                string sql = $"delete from {t.Name} ";
                foreach (var item in property)
                {
                    if(!string.IsNullOrEmpty(item.GetValue(model).ToString()))
                    {
                        sql += $" where {item.Name} = '{item.GetValue(model)}'";
                    }
                }
                return conn.Execute(sql);
            }
        }



        /// <summary>
        /// 全能表单删批删存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="tableName">表名</param>
        /// <param name="idName">表名的主键ID名</param>
        /// <param name="deleteIds">要删除的ID</param>
        /// <returns></returns>
        public int SingerAndBatchDeleteTable(string procName,string tableName,string idName,string deleteIds) 
        {
            int code = 0;
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                deleteIds = "'" + deleteIds + "'";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@tableName", tableName);
                parameters.Add("@tableID", idName);
                parameters.Add("@DeleID",deleteIds);
                code = conn.Execute(procName,parameters,commandType:CommandType.StoredProcedure);
            }
           return code;
        } 


        public int UpdateEmp(string procName,Base_Emp_Information model)
        {
            string qian ="'";
            string hou = "'";
            model.Emp_Dept = qian + model.Emp_Dept + hou;
            model.Emp_Post = qian + model.Emp_Post + hou;
            model.Health = qian + model.Health + hou;
            model.Phone = qian + model.Phone + hou;
            string id = qian + model.Emp_ID + hou;
            int code = 0;
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@updateFile1", model.Emp_Dept);
                parameters.Add("@updateFile2", model.Emp_Post);
                parameters.Add("@updateFile3", model.Phone);
                parameters.Add("@updateFile4", model.Health);
                parameters.Add("@id", id);
                code = conn.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            }
            return code;

        }


    }
}
