using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace IOT_Project_OA.DAL
{

    public static class OrmDBHelper
    {
        private const string connectionString = "Data Source=.;Initial Catalog=PRODUCTDB;Integrated Security=True";

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static List<T> GetToList<T>(string sql) where T : class, new()
        {
            List<T> list = new List<T>();
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                list = conn.Query<T>(sql).ToList();
            }
            return list;
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static T GetModel<T>(string sql) where T : class, new()
        {
            T model = new T();
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                model = conn.QueryFirstOrDefault<T>(sql);
            }
            return model;
        }

        /// <summary>
        /// 增删改 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
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
        public static ProcDataAndTotal<T> GetProcData<T>(string tableName,string whereStr,string orderField,string PageIndex) where T:class,new()
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
                    Total = param.Get<int>("Total"),
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
        public static ProcDataAndTotal<T> GetProcData<T>(DynamicParameters param, string procName) where T : class, new()
        {
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                //返回的类
                ProcDataAndTotal<T> dataAndTotal = new ProcDataAndTotal<T>()
                {
                    ProcData = conn.Query<T>(procName, param, commandType: CommandType.StoredProcedure).ToList(),
                    Total = param.Get<int>("Total"),
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
        public static int AddData<T>(T model) where T : class, new()
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

        public static int DeleteData<T>(T model) where T:class,new()
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
    }
}
