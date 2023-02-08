
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Data;

namespace TestProject.Models.Common
{
    public class clsConnectionNew
    {

        #region Connection Related Variable

        private string dbServer = "";
        private string dbDatabase = "";
        private string dbUser = "";
        private string dbPassword = "";
        private string strConnection = "";
        public static Boolean blnConOutside = false;

        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommandBuilder scb = new SqlCommandBuilder();


        #endregion Connection Related Variable

        #region Constructor
        //public clsConnectionNew(IConfiguration configuration, Boolean IsWeb = false)
        //{
        //   // _config = configuration;
        //    //Constructor Without Parameter (Call When Object Create Without Database Name)
        //   // GTRMakeConnectionString(dbDatabase, IsWeb);
        //}
        public clsConnectionNew()
        {
            //Constructor  With Parameter (Call When Object Create With Database Name)

        }
        #endregion Constructor

        #region Connection Open & Close

        #region Commented by shariat

        //private void GTRMakeConnectionString(string strDatabaseName, Boolean IsWeb)
        //{
        //    //clsProcedure clsProc = new clsProcedure();
        //    //XmlReader reader = null;
        //    //try
        //    //{
        //    //    if (IsWeb == true)
        //    //    {
        //    //        reader = XmlReader.Create(HttpContext.Current.Server.MapPath(@"~\Server.xml"));
        //    //    }
        //    //    else
        //    //    {
        //    //        reader = XmlReader.Create("Server.xml");
        //    //    }

        //    //    while (reader.Read())
        //    //    {
        //    //        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Server")
        //    //        {
        //    //            if (reader.GetAttribute(0) == "Local")
        //    //            {
        //    //                while (reader.NodeType != XmlNodeType.EndElement)
        //    //                {
        //    //                    reader.Read();
        //    //                    if (reader.Name == "ServerName")
        //    //                    {
        //    //                        while (reader.NodeType != XmlNodeType.EndElement)
        //    //                        {
        //    //                            reader.Read();
        //    //                            if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
        //    //                            {
        //    //                                //dbServer = reader.Value.ToString();
        //    //                                dbServer = clsEncryption.Decrypt(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));
        //    //                                //dbServer = clsEncryption.DecryptTDES(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));

        //    //                            }
        //    //                        }
        //    //                        reader.Read();
        //    //                    }
        //    //                    if (reader.Name == "UserName")
        //    //                    {
        //    //                        while (reader.NodeType != XmlNodeType.EndElement)
        //    //                        {
        //    //                            reader.Read();
        //    //                            if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
        //    //                            {
        //    //                                dbUser = clsEncryption.Decrypt(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));
        //    //                                //dbUser = clsEncryption.DecryptTDES(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));

        //    //                            }
        //    //                        }
        //    //                        reader.Read();
        //    //                    }
        //    //                    if (reader.Name == "Password")
        //    //                    {
        //    //                        while (reader.NodeType != XmlNodeType.EndElement)
        //    //                        {
        //    //                            reader.Read();
        //    //                            if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
        //    //                            {
        //    //                                //dbPassword = clsProc.GTRDecryptWord(reader.Value.ToString());
        //    //                                dbPassword = clsEncryption.Decrypt(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));
        //    //                                //dbPassword = clsEncryption.DecryptTDES(Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty));
        //    //                            }
        //    //                        }
        //    //                        reader.Read();
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //        else if (reader.Name == "dbDefault")
        //    //        {
        //    //            if (strDatabaseName.Length != 0)
        //    //            {
        //    //                dbDatabase = strDatabaseName;
        //    //            }
        //    //            else
        //    //            {
        //    //                while (reader.NodeType != XmlNodeType.EndElement)
        //    //                {
        //    //                    reader.Read();
        //    //                    if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
        //    //                    {
        //    //                        dbDatabase = Regex.Replace(reader.Value.ToString(), @"[^\u0000-\u007F]", string.Empty);
        //    //                    }
        //    //                }
        //    //                reader.Read();
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    //MessageBox.Show(ex.Message);
        //    //}
        //    //finally
        //    //{
        //    //    if (reader != null)
        //    //    {
        //    //        reader.Close();
        //    //    }
        //    //    reader = null;
        //    //    clsProc = null;
        //    //}
        //    //if (dbServer == "")
        //    //{
        //    dbServer = "101.2.165.189\\MSSQL2014";
        //    ///localhost
        //    dbDatabase = "GTRERP_DAP_LIVE";
        //    dbUser = "sa";
        //    dbPassword = "gTr@$#@456*&%^()gT#7";

        //    //    dbServer = "."; ///localhost
        //    //    dbDatabase = "MasterDetails";
        //    //    dbUser = "sa";
        //    //    dbPassword = "gtr@007";
        //    //}
        //    strConnection = @"Data Source=" + this.dbServer + "; Network Library=DBMSSOCN; Initial Catalog=" + this.dbDatabase + "; User ID=" + this.dbUser + "; Password =" + dbPassword + ";Connection Timeout=1200";
        //    // strConnection = _config.GetConnectionString("DefaultConnection");
        //}

        #endregion
        private void GTRConnectionOpen()
        {

            try
            {
                con = new SqlConnection(AppData.AppData.dbdaperpconstring);
                con.Open();

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        private void GTRConnectionClose()
        {
            if (this.con.State != ConnectionState.Closed)
            {
                this.con.Close();
            }
        }
        #endregion Connection Open & Close

        #region Fill System.Data.System.Data.DataSet
        public void GTRFillDatasetThroughDataAdapter(ref System.Data.DataSet ds, string sqlQuery)
        {
            try
            {
                //Open Connection
                GTRConnectionOpen();

                //Passing Query & Connection Object to initialize Command
                com = new SqlCommand(sqlQuery, con);
                com.CommandTimeout = 1200;
                sda.SelectCommand = com;
                sda.Fill(ds);
                scb.DataAdapter = sda;

                sda.InsertCommand = scb.GetInsertCommand();
                sda.UpdateCommand = scb.GetUpdateCommand();
                sda.DeleteCommand = scb.GetDeleteCommand();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
        }
        public void GTRFillDatasetWithSQLCommand(ref System.Data.DataSet ds, string sqlQuery)
        {
            try
            {
                //Open Connection

                GTRConnectionOpen();
                com = con.CreateCommand();
                com.CommandTimeout = 1200;


                //Passing Query & Connection Object to initialize Command
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GTRConnectionClose();
            }
        }
        #endregion Fill System.Data.System.Data.DataSet

        #region Fill Data Reader
        public IDataReader GetReader(String sql)
        {

            try
            {
                GTRConnectionOpen();
                var command = con.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return null;
        }
        #endregion

        #region Data Save Through Data Adapter
        public void GTRSaveDataThroughDataAdapter(ref System.Data.DataSet ds)
        {
            //Update Database
            sda.Update(ds);
        }
        #endregion Data Save Through Data Adapter

        #region Get Counting Data Or New Id From Database
        public int GTRCountingData(string sqlQuery)
        {
            int Result = 0;
            if (sqlQuery.Length == 0 || sqlQuery == string.Empty)
            {
                return Result;
            }

            try
            {
                //Open Connection
                GTRConnectionOpen();

                //Passing Query & Connection Object to initialize Command
                com = new SqlCommand(sqlQuery, con);
                Result = (Int32)com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
            return Result;
        }
        public Int64 GTRCountingDataLarge(string sqlQuery)
        {
            Int64 Result = 0;
            if (sqlQuery.Length == 0 || sqlQuery == string.Empty)
            {
                return Result;
            }

            try
            {
                //Open Connection
                GTRConnectionOpen();

                //Passing Query & Connection Object to initialize Command
                com = new SqlCommand(sqlQuery, con);
                Result = (Int64)com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
            return Result;
        }

        public string GTRTextData(string sqlQuery)
        {
            string Result = "";
            if (sqlQuery.Length == 0 || sqlQuery == string.Empty)
            {
                return Result;
            }

            try
            {
                //Open Connection
                GTRConnectionOpen();

                //Passing Query & Connection Object to initialize Command
                com = new SqlCommand(sqlQuery, con);
                Result = com.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
            return Result;
        }
        #endregion Get Counting Data Or New Id From Database

        #region Saving Data Direct to Database like Insert or Update
        public int GTRSaveDataWithSQLCommand(string sqlQuery)
        {
            int Result = 0;
            if (sqlQuery.Length == 0 || sqlQuery == string.Empty)
            {
                return Result;
            }

            try
            {
                //Open Connection
                GTRConnectionOpen();

                //Passing Query & Connection Object to initialize Command
                com = new SqlCommand(sqlQuery, con);
                com.CommandTimeout = 1200;
                Result = (Int32)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
            return Result;
        }
        public void GTRSaveDataWithSQLCommand(ArrayList sqlQuery)
        {
            if (sqlQuery.Count == 0)
            {
                throw (new Exception("Empty SQL Query."));
            }

            //Open Connection
            GTRConnectionOpen();
            com = con.CreateCommand();
            com.CommandTimeout = 1200;

            SqlTransaction tran = con.BeginTransaction();
            com.Connection = con;
            com.Transaction = tran;

            try
            {
                //Passing Query & Connection Object to initialize Command
                for (int i = 0; i < sqlQuery.Count; i++)
                {
                    com.CommandText = sqlQuery[i].ToString();
                    com.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (SqlException sqlex)
                {
                    if (tran.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + sqlex.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }
                throw (ex);
            }
            finally
            {
                //Close Connection
                GTRConnectionClose();
            }
        }
        #endregion Saving Data Direct to Database like Insert or Update

    }
}
