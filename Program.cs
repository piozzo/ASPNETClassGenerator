using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MySql.Data.MySqlClient;

namespace ASPNETClassGenerator
{
    class Program
    {

        public enum FieldType
        {
            INT, VARCHAR, ENUM, DECIMAL, DATE, TIME, DATETIME, BIT, DOUBLE, BOOLEAN
        }

        public class FieldTypeInfo
        {
            public FieldType typeName;
            public int typeSize;
            public int typePrecision;
            public List<string> typeEnumList;

            public FieldTypeInfo()
            {
                typeName = FieldType.VARCHAR;
                typeSize = 0;
                typePrecision = 0;
                typeEnumList = new List<string>();
            }
        }

        static void Main(string[] args)
        {
            if (!validateInput(args))
                return;

            string className = args[0];
            string host = args[1];
            string dbName = args[2];
            string tableName = args[3];
            string username = args[4];
            string password = args[5];

            if (!System.IO.Directory.Exists("BLL"))
            {
                System.IO.Directory.CreateDirectory("BLL");
            }

            if (!System.IO.Directory.Exists("DAL"))
            {
                System.IO.Directory.CreateDirectory("DAL");
            }

            string connectionString = "Server=" + host + ";Database=" + dbName + ";Uid=" + username + ";Pwd=" + password + ";";
            //string className = char.ToUpper(tableName[0]) + tableName.Substring(1);
            string listaCampi = "";
            string listaParametri = "";
            List<string> proprietaList = new List<string>();
            List<string> fieldCaptionList = new List<string>();
            Dictionary<string, FieldType> parametriDictionaryTypes = new Dictionary<string,FieldType>();
            string stringaTemp = "";
            

            #region [ Creazione della Business class ]
            using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"BLL\" + tableName + ".cs"))
            {

                sw.WriteLine(getUsing());

                sw.WriteLine("public class " + className + " {");
                sw.WriteLine();

                using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
                {
                    cnMySql.Open();

                    using (MySqlCommand cmd = new MySqlCommand("DESC " + dbName + "." + tableName, cnMySql))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            sw.WriteLine("\t#region [ Proprietà ]");
                            sw.WriteLine();

                            while (reader.Read())
                            {
                                // prepariamo anche la lista dei campi separati da backtick

                                fieldCaptionList.Add(reader["field"].ToString());

                                listaCampi = listaCampi + "`" + reader["field"].ToString() + "`, ";
                                listaParametri = listaParametri + "?" + reader["field"].ToString() + ", ";

                                string privateFieldName = "_" + char.ToUpper(reader["field"].ToString()[0]) + reader["field"].ToString().Substring(1);
                                string fieldName = privateFieldName.Substring(1);
                                string fieldType = reader["type"].ToString();

                                proprietaList.Add(fieldName);

                                FieldTypeInfo field = getFieldTypeInfo(fieldType);

                                parametriDictionaryTypes.Add(fieldName, field.typeName);

                                bool allowsNull = reader["Null"].ToString() == "YES";

                                switch (field.typeName)
                                {
                                    case FieldType.VARCHAR:
                                        sw.WriteLine("\tprivate string " + privateFieldName + ";");
                                        sw.WriteLine("\tpublic string " + fieldName + " {");
                                        sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                        sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                        sw.WriteLine("\t}");
                                        sw.WriteLine();
                                        break;
                                    case FieldType.BIT:
                                    case FieldType.BOOLEAN:
                                        sw.WriteLine("\tprivate bool " + privateFieldName + ";");
                                        sw.WriteLine("\tpublic bool " + fieldName + " {");
                                        sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                        sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                        sw.WriteLine("\t}");
                                        sw.WriteLine();
                                        break;
                                    case FieldType.INT:
                                        if (allowsNull)
                                        {
                                            sw.WriteLine("\tprivate int? " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic int? " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }
                                        else
                                        {
                                            sw.WriteLine("\tprivate int " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic int " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }
                                        
                                        break;
                                    case FieldType.DECIMAL:
                                    case FieldType.DOUBLE:
                                        if (allowsNull)
                                        {
                                            sw.WriteLine("\tprivate double? " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic double? " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }
                                        else
                                        {
                                            sw.WriteLine("\tprivate double " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic double " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }
                                        break;
                                    case FieldType.DATETIME:
                                    case FieldType.DATE:
                                    case FieldType.TIME:
                                        if (allowsNull)
                                        {
                                            sw.WriteLine("\tprivate DateTime? " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic DateTime? " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }
                                        else
                                        {
                                            sw.WriteLine("\tprivate DateTime " + privateFieldName + ";");
                                            sw.WriteLine("\tpublic DateTime " + fieldName + " {");
                                            sw.WriteLine("\t\tget { return " + privateFieldName + "; }");
                                            sw.WriteLine("\t\tset { " + privateFieldName + " = value; } ");
                                            sw.WriteLine("\t}");
                                            sw.WriteLine();
                                        }

                                        break;
                                }
                            }

                            listaCampi = listaCampi.TrimEnd(' ', ',');
                            listaParametri = listaParametri.TrimEnd(' ', ',');

                            sw.WriteLine("\t#endregion");
                        }
                    }

                    sw.WriteLine();
                    sw.WriteLine("\t#region [ Metodi Pubblici ]");
                    sw.WriteLine();
                    sw.WriteLine("\tpublic static void inserisci");
                    sw.WriteLine();
                    sw.WriteLine("\t#endregion");

                    cnMySql.Close();
                }

                sw.WriteLine("}");

            }

            #endregion

            #region [ Creazione della Data Access Layer Class ]

            using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"DAL\" + tableName + "Provider.cs"))
            {

                sw.WriteLine(getUsing());

                sw.WriteLine("public class " + className + "Provider {");
                sw.WriteLine();

                // metodo INSERT
                sw.WriteLine("\tpublic static int insert" + className + "(" + className + " item) ");
                sw.WriteLine("\t{");
                sw.WriteLine("\t\tint idNew = 0;");
                sw.WriteLine("\t\tusing (MySqlConnection cnMySql = new MySqlConnection(connectionString))");
                sw.WriteLine("\t\t{");
                sw.WriteLine("\t\t\tcnMySql.Open();");
                sw.WriteLine();

                sw.WriteLine("\t\t\tSystem.Text.StringBuilder sb = new System.Text.StringBuilder();");
                sw.WriteLine("\t\t\tsb.Append(\"INSERT INTO " + dbName + "." + tableName + "(" + listaCampi + ")\");");
                sw.WriteLine("\t\t\tsb.Append(\"VALUES \");");
                sw.WriteLine("\t\t\tsb.Append(\"(" + listaParametri + ");\"); ");
                sw.WriteLine("\t\t\tsb.Append(\"select last_insert_id() as idNew from " + dbName + "." + tableName + "; \");");
                sw.WriteLine();
                sw.WriteLine("\t\t\tusing (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) ");
                sw.WriteLine("\t\t\t{");
                sw.WriteLine("\t\t\t\ttry ");
                sw.WriteLine("\t\t\t\t{");
                sw.WriteLine("\t\t\t\t\t//cmd.ExecuteNonQuery();");
                sw.WriteLine("\t\t\t\t\tobject o = ExecuteScalar(cmd);");
                sw.WriteLine("\t\t\t\t\to = Convert.toInt32(o);");
                sw.WriteLine("\t\t\t\t}");
                sw.WriteLine("\t\t\t\tcatch (MySqlException ex) ");
                sw.WriteLine("\t\t\t\t{");
                sw.WriteLine("\t\t\t\t\tEventLogger.LogError(\"Errore durante l'inserimento dell'oggetto " + className + " nel database.\", ex);");
                sw.WriteLine("\t\t\t\t}");
                sw.WriteLine("\t\t\t}");
                sw.WriteLine();
                sw.WriteLine("\t\t\tcnMySql.Close();");
                sw.WriteLine("\t\t}");
                sw.WriteLine("\t\treturn idNew;");
                sw.WriteLine("\t}");

                sw.WriteLine();

                // metodo UPDATE
                sw.WriteLine("\tpublic static void update" + className + "(" + className + " item) ");
                sw.WriteLine("\t{");
                sw.WriteLine("\t\tusing (MySqlConnection cnMySql = new MySqlConnection(connectionString))");
                sw.WriteLine("\t\t{");
                sw.WriteLine("\t\t\tcnMySql.Open();");
                sw.WriteLine();
                sw.WriteLine("\t\t\tSystem.Text.StringBuilder sb = new System.Text.StringBuilder();");
                sw.WriteLine("\t\t\tsb.Append(\"UPDATE " + dbName + "." + tableName + " \");");
                sw.WriteLine("\t\t\tsb.Append(\"SET \");");

                stringaTemp = "";

                foreach (string prop in proprietaList)
                {
                    stringaTemp += "\t\t\tsb.Append(\"`" + char.ToLower(prop[0]) + prop.Substring(1) + "` = ?" + char.ToLower(prop[0]) + prop.Substring(1) + ", \");" + Environment.NewLine;
                }

                sw.Write(stringaTemp);
                sw.WriteLine("\t\t\tsb.Append(\"WHERE id=?id;\");");
                sw.WriteLine();

                sw.WriteLine();
                sw.WriteLine("\t\t\tusing (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) ");
                sw.WriteLine("\t\t\t{");
                sw.WriteLine("\t\t\t\t//lista parametri comando");
                sw.WriteLine("\t\t\t\ttry ");
                sw.WriteLine("\t\t\t\t{");
                sw.WriteLine("\t\t\t\t\tcmd.ExecuteNonQuery();");
                sw.WriteLine("\t\t\t\t}");
                sw.WriteLine("\t\t\t\tcatch (MySqlException ex) ");
                sw.WriteLine("\t\t\t\t{");
                sw.WriteLine("\t\t\t\t\tEventLogger.LogError(\"Errore durante l'aggiornamento dell'oggetto " + className + " nel database.\", ex);");
                sw.WriteLine("\t\t\t\t}");
                sw.WriteLine("\t\t\t}");
                sw.WriteLine();
                sw.WriteLine("\t\t\tcnMySql.Close();");
                sw.WriteLine("\t\t}");
                sw.WriteLine("\t}");

                sw.WriteLine();

                // getItemFromReader
                sw.WriteLine("protected " + className + " get" + className + "FromReader(IDataReader reader)");
                sw.WriteLine("{");
                sw.WriteLine("\t" + className + " item = new " + className + "();");
                sw.WriteLine();
                foreach (string prop in proprietaList)
                {
                    stringaTemp = "\titem." + prop + " = ";

                    switch (parametriDictionaryTypes[prop])
                    {
                        case FieldType.INT:
                            stringaTemp += "ConvertDBObjectToInt";
                            break;
                        case FieldType.BIT:
                        case FieldType.BOOLEAN:
                            stringaTemp += "ConvertDBObjectToBool";
                            break;
                        case FieldType.DECIMAL:
                        case FieldType.DOUBLE:
                            stringaTemp += "ConvertDBObjectToDouble";
                            break;
                        case FieldType.DATETIME:
                        case FieldType.DATE:
                        case FieldType.TIME:
                            stringaTemp += "ConvertDBObjectToDateTime";
                            break;
                        case FieldType.VARCHAR:
                            stringaTemp += "ConvertDBObjectToString";
                            break;
                    }

                    stringaTemp += "(reader[\"" + char.ToLower(prop[0]) + prop.Substring(1) + "\"]);";

                    sw.WriteLine(stringaTemp);
                }

                sw.WriteLine();
                sw.WriteLine("\treturn item;");

                sw.WriteLine("}");

                // stampiamo i parametri

                sw.WriteLine();
                sw.WriteLine("//Parametri per le query");
                sw.WriteLine();

                foreach (string prop in proprietaList)
                {
                    sw.WriteLine("cmd.Parameters.AddWithValue(\"?" + char.ToLower(prop.ToString()[0]) + prop.ToString().Substring(1) + "\", item." + prop + ");");
                }

            }

            #endregion
        }

        private static bool validateInput(string[] args)
        {
            bool risposta = false;

            switch (args.ToList<string>().Count)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    risposta = false;
                    Console.WriteLine("Sintassi: ASPNETClassGenerator <className> <host> <dbName> <tableName> <username> <password>");
                    break;
                case 6:
                    risposta = true;
                    break;
                default:
                    Console.WriteLine("Sintassi: ASPNETClassGenerator <className> <host> <dbName> <tableName> <username> <password>");
                    risposta = false;
                    break;
            }

            return risposta;
        }

        private static string getUsing()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Configuration;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.Security;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using System.Web.UI.WebControls.WebParts;");
            sb.AppendLine("using System.Web.UI.HtmlControls;");
            sb.AppendLine("using System.Collections.Generic;");

            sb.AppendLine();

            return sb.ToString();
        }

        private static FieldTypeInfo getFieldTypeInfo(string mysqlFieldType)
        {
            FieldTypeInfo fieldInfo = new FieldTypeInfo();
            int startIndex = 0;
            int endIndex = 0;

            if (mysqlFieldType.StartsWith("enum"))
            {
                fieldInfo.typeName = FieldType.ENUM;
                fieldInfo.typeSize = 0;
                fieldInfo.typePrecision = 0;
                startIndex = mysqlFieldType.IndexOf('(') + 1;
                endIndex = mysqlFieldType.IndexOf(')');
                List<string> listaEnum = mysqlFieldType.Substring(startIndex, endIndex - startIndex).Split(',').ToList<string>();
                fieldInfo.typeEnumList = listaEnum;
            }
            else if (mysqlFieldType.StartsWith("int"))
            {
                fieldInfo.typeName = FieldType.INT;

                startIndex = mysqlFieldType.IndexOf('(') + 1;
                endIndex = mysqlFieldType.IndexOf(')');

                fieldInfo.typeSize = int.Parse(mysqlFieldType.Substring(startIndex, endIndex - startIndex));
            }
            else if (mysqlFieldType.StartsWith("decimal"))
            {
                fieldInfo.typeName = FieldType.DECIMAL;

                startIndex = mysqlFieldType.IndexOf('(') + 1;
                endIndex = mysqlFieldType.IndexOf(')');

                string characteristcs = mysqlFieldType.Substring(startIndex, endIndex - startIndex);

                if (characteristcs.Contains(','))
                {
                    fieldInfo.typeSize = int.Parse(characteristcs.Split(',').ToArray().ElementAt(0));
                    fieldInfo.typePrecision = int.Parse(characteristcs.Split(',').ToArray().ElementAt(1));
                }
                else
                {
                    fieldInfo.typeSize = int.Parse(characteristcs);
                    fieldInfo.typePrecision = 0;
                }
            }
            else if (mysqlFieldType.StartsWith("double"))
            {
                fieldInfo.typeName = FieldType.DOUBLE;

                startIndex = mysqlFieldType.IndexOf('(') + 1;
                endIndex = mysqlFieldType.IndexOf(')');

                string characteristcs = mysqlFieldType.Substring(startIndex, endIndex - startIndex);

                if (characteristcs.Contains(','))
                {
                    fieldInfo.typeSize = int.Parse(characteristcs.Split(',').ToArray().ElementAt(0));
                    fieldInfo.typePrecision = int.Parse(characteristcs.Split(',').ToArray().ElementAt(1));
                }
                else
                {
                    fieldInfo.typeSize = int.Parse(characteristcs);
                    fieldInfo.typePrecision = 0;
                }
            }
            else if (mysqlFieldType.StartsWith("bit"))
            {
                fieldInfo.typeName = FieldType.BIT;
            }
            else if (mysqlFieldType.StartsWith("boolean"))
            {
                fieldInfo.typeName = FieldType.BOOLEAN;
            }
            else if (mysqlFieldType.StartsWith("datetime"))
            {
                fieldInfo.typeName = FieldType.DATETIME;
            }
            else if (mysqlFieldType.StartsWith("date"))
            {
                fieldInfo.typeName = FieldType.DATE;
            }
            else if (mysqlFieldType.StartsWith("time"))
            {
                fieldInfo.typeName = FieldType.TIME;
            }
            else if (mysqlFieldType.StartsWith("varchar"))
            {
                fieldInfo.typeName = FieldType.VARCHAR;

                startIndex = mysqlFieldType.IndexOf('(') + 1;
                endIndex = mysqlFieldType.IndexOf(')');

                fieldInfo.typeSize = int.Parse(mysqlFieldType.Substring(startIndex, endIndex - startIndex));
            }

            return fieldInfo;
        }
    }
}
