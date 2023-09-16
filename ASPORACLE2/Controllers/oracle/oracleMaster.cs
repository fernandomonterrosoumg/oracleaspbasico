using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ASPORACLE2.Controllers.oracle
{
    public class oracleMaster
    {

        public static string CNNString()
        {
            string oradb = ConfigurationSettings.AppSettings["Oracle"];
            return oradb;
        }

        public static DataTable ExecuteQuery(string sqlQuery, Dictionary<string, object> parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(CNNString()))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                        }
                    }

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string sqlQuery, Dictionary<string, object> parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(CNNString()))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            //command.Parameters.Add(new OracleParameter(param.Key, param.Value));
                            command.Parameters.Add(new OracleParameter
                            {
                                ParameterName = param.Key,
                                Value = param.Value,
                                OracleDbType = GetOracleDbType(param.Value)// Asigna el tipo de parámetro correcto
                            });
                        }
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public static OracleDbType GetOracleDbType(object valor)
        {
            OracleDbType oracleDbType = OracleDbType.Varchar2;

            if (valor is DateTime)
            {
                oracleDbType = OracleDbType.Date;
            }
            else if (valor is long)
            {
                oracleDbType = OracleDbType.Int64;
            }
            else if (valor is int)
            {
                oracleDbType = OracleDbType.Int32;
            }
            else if (valor is short)
            {
                oracleDbType = OracleDbType.Int16;
            }
            else if (valor is sbyte)
            {
                oracleDbType = OracleDbType.Byte;
            }
            else if (valor is byte)
            {
                oracleDbType = OracleDbType.Int16;
            }
            else if (valor is decimal)
            {
                oracleDbType = OracleDbType.Decimal;
            }
            else if (valor is float)
            {
                oracleDbType = OracleDbType.Single;
            }
            else if (valor is double)
            {
                oracleDbType = OracleDbType.Double;
            }
            else if (valor is byte[])
            {
                oracleDbType = OracleDbType.Blob;
            }

            return oracleDbType;
        }


        public static void LogError()
        {
            string DefaultLogPath = "Logs";
            string DefaultErrorMessage = "An error occurred.";
            string logFormat = $"{DateTime.Now:dd/MM/yyyy hh:mm:ss tt} ==> ";
            string logName = $"{DateTime.Now:dd-MM-yyyy tt} ==> ";
            string errorTime = DateTime.Now.ToString("yyyy-MM-dd");

            string logFilePath = Path.Combine(DefaultLogPath, $"{errorTime}-masterclass.txt");
            string fullLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFilePath);

            Directory.CreateDirectory(Path.GetDirectoryName(fullLogPath));

            using (StreamWriter sw = new StreamWriter(fullLogPath, true))
            {
                sw.WriteLine(logFormat + DefaultErrorMessage);
            }
        }


    }




}