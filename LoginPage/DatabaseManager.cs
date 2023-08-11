using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage
{
    /// <summary>
    /// this class provide functionality of intrating with database. 
    /// </summary>
    class DatabaseManager
    {

        private SqlConnection _connection;
        /// <summary>
        /// get the SQL connection Object used for perfpeming operation on SQL Server dataabase
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                return this._connection;
            }
            private set
            {
                this._connection = value;
            }
        }


        //public DataTable DataSource { get; internal set; }
        /// <summary>
        /// the constrarotr for <b>DatabaseManager class. </b>
        /// this constrtor useses app.conffig file for connection string.
        /// </summary>
        public DatabaseManager()
        {
            _connection = new SqlConnection();
            this._connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DSMCConnectionString"].ConnectionString;
        }
        /// <summary>
        /// exexutes a SQl statement and retrn a single value from database 
        /// </summary>
        /// <param name="sql">the Sql sattement passt to thedatabase fpr executation </param>
        /// <returns>the value retrived from databse.</returns>
        public object ExecuteScalar(String sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = this._connection;
            Connection.Open();
            object result = cmd.ExecuteScalar();
            this._connection.Close();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(String sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = this._connection;
            Connection.Open();
            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(result);
            this._connection.Close();
            return result;

        }
        public int ExecuteNonQuery(String sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = this._connection;
            Connection.Open();
            int result = cmd.ExecuteNonQuery();
            this._connection.Close();
            return result;
        }
        public Decimal GetNextPKValue(String Columnname, String tablename)
        {
            String sql = "select Max(" + Columnname + ")+1 from " + tablename;
            Decimal id = (decimal)this.ExecuteScalar(sql);
            return id;
        }

        //public bool CheckLogin(string username, string password)
        //{
        //// existing CheckLogin code
        //return true ;
        //}
        //public DataTable RetrieveData(string tableName)
        //{
        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        // Open SQL connection
        //        _connection.Open();

        //        // Create SQL command to retrieve data from the specified table
        //        SqlCommand command = new SqlCommand("SELECT * FROM " + tableName, connection);

        //        // Create a SqlDataAdapter to fill the DataTable
        //        SqlDataAdapter da = new SqlDataAdapter(command);

        //        // Fill the DataTable with data from the database
        //        da.Fill(dt);
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Handle the exception
        //        // You may want to log the exception
        //    }
        //    finally
        //    {
        //        // Close the connection
        //        connection.Close();
        //    }

        //    return dt;
        //}

        //public void InsertRecord(int Vendor_ID, String txtVendorName,  String txtContactPerson , String txtPostalAddress , int txtMobileNo , String txtCity)
        //    {
        //        try
        //        {
        //            // Open SQL connection
        //            _connection.Open();

        //        // Create SQL command to insert a new record
        //         SqlCommand command = new SqlCommand("insert into Vendors (Vendor_ID,Vendor_Name,Contact_Person,Postal_Address,Mobile_No,City)"
        //        + " values (555,'" + txtVendorName+ "', '" + txtContactPerson + "', '" + txtPostalAddress + "', " + txtMobileNo + ", '" + txtCity + "')", connection);

        //            // Execute SQL command
        //            command.ExecuteNonQuery();
        //            _connection.Close();
        //    }
        //        catch (SqlException ex)
        //        {
        //            // handle the exception
        //            // you may want to log the exception
        //        }

        //    }

        //public SqlDataReader SelectRecord(int id)
        //{
        //    try
        //    {
        //        // Open SQL connection
        //        connection.Open();

        //        // Create SQL command to select a record
        //        SqlCommand command = new SqlCommand("SELECT * FROM YourTable WHERE id = @id", connection);
        //        command.Parameters.AddWithValue("@id", id);

        //        // Execute SQL command and return the resulting data reader
        //        return command.ExecuteReader();
        //    }
        //    catch (SqlException ex)
        //    {
        //        // handle the exception
        //        // you may want to log the exception
        //        return null;
        //    }
        //    finally
        //    {
        //        // Close SQL connection
        //        connection.Close();
        //    }
        //}

        //public void UpdateRecord(int id, string column1, string column2, ...)
        //{
        //    try
        //    {
        //        // Open SQL connection
        //        connection.Open();

        //        // Create SQL command to update a record
        //        SqlCommand command = new SqlCommand("UPDATE YourTable SET column1 = @column1, column2 = @column2, ... WHERE id = @id", connection);
        //        command.Parameters.AddWithValue("@id", id);
        //        command.Parameters.AddWithValue("@column1", column1);
        //        command.Parameters.AddWithValue("@column2", column2);
        //        // ... add parameters for other columns

        //        // Execute SQL command
        //        command.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        // handle the exception
        //        // you may want to log the exception
        //    }
        //    finally
        //    {
        //        // Close SQL connection
        //        connection.Close();
        //    }
        //}

        //public void DeleteRecord(int id)
        //{
        //    try
        //    {
        //        // Open SQL connection
        //        connection.Open();

        //        // Create SQL command to delete a record
        //        SqlCommand command = new Sql
        //    //public void insertRecord(int Vendor_ID, String Vendor_Name, String Contact_Person, String Postal_Address, int Mobile_No, String City)
        //    //{
        //    //    try
        //    //    {

        //        //        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
        //        //        con.ConnectionString = @"Data Source = .\SQLEXPRESS; Database = DSMC_Hospital_Management_System; integrated security = true;";
        //        //        con.Open();
        //        //        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //        //        cmd.Connection = con;
        //        //        cmd.CommandText = "insert into Vendors (Vendor_ID,Vendor_Name,Contact_Person,Postal_Address,Mobile_No,City)"
        //        //        + " values (10012,'" + txtVendorName.Text.Trim() + "', '" + txtContactPerson.Text.Trim() + "', '" + txtPostalAddress.Text.Trim() + "', " + txtMobileNo.Text.Trim() + ", '" + txtCity.Text.Trim() + "')";
        //        //        //cmd.CommandText = "INSERT INTO Vendors (Vendor_ID,Vendor_Name, Contact_Person, Postal_Address, Mobile_No,City) " +
        //        //        //                   "VALUES (@Vendor_Name, @Contact_Person, @Postal_Address, @Mobile_No,@City)";

        //        //        //cmd.Parameters.AddWithValue("@Vendor_Name", txtVendorName.Text.Trim());
        //        //        //cmd.Parameters.AddWithValue("@Contact_Person", txtContactPerson.Text.Trim());
        //        //        //cmd.Parameters.AddWithValue("@Postal_Address", txtPostalAddress.Text.Trim());
        //        //        //cmd.Parameters.AddWithValue("@Mobile_No", txtMobileNo.Text.Trim());
        //        //        //cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
        //        //        cmd.ExecuteNonQuery();
        //        //        MessageBox.Show("successfully inserted");
        //        //        ////this.dgv.DataSource = dt;
        //        //        frmVendorsMgt.RefreshDataGridView();
        //        //        con.Close();
        //        //        this.Close();
        //        //        textBox1.Text = cmd.CommandText;
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //    }

        //        //}
    }
}