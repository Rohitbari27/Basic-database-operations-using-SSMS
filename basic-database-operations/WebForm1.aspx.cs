using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace basic_database_operations
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = TextBox1.Text;
                string lastName = TextBox2.Text;
                int number;
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || !int.TryParse(TextBox3.Text, out number))
                {
                    Response.Write("<script>alert('Please enter valid values for all fields');</script>");
                    return;
                }
                else
                {
                    string cs = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=db; Integrated Security=True;";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        string q = "INSERT INTO demo (FirstName, LastName, number) VALUES (@firstName, @lastName, @number)";
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@firstName", firstName);
                            cmd.Parameters.AddWithValue("@lastName", lastName);
                            cmd.Parameters.AddWithValue("@number", number);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Response.Write($"<script>alert('Inserted successfully');</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Data insertion failed');</script>");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                Response.Write($"Error Type: {ex.GetType()}<br/>");
                Response.Write($"Stack Trace: {ex.StackTrace}<br/>");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=db; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM demo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            DataList1.DataSource = dt;
                            DataList1.DataBind();

                            ListView1.DataSource = dt;
                            ListView1.DataBind();

                            Repeater1.DataSource = dt;
                            Repeater1.DataBind();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write($"<script>alert('Database error: {sqlEx.Message}');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                Response.Write($"Error Type: {ex.GetType()}<br/>");
                Response.Write($"Stack Trace: {ex.StackTrace}<br/>");
            }
        }

        // delete all
        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=db; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string query = "DELETE FROM demo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write($"<script>alert('All records deleted successfully');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No records to delete');</script>");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write($"<script>alert('Database error: {sqlEx.Message}');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                Response.Write($"Error Type: {ex.GetType()}<br/>");
                Response.Write($"Stack Trace: {ex.StackTrace}<br/>");
            }
        }

        //delete by name 

        protected void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = TextBox1.Text;
                string lastName = TextBox2.Text;

                if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                {
                    Response.Write("<script>alert('Please enter a valid first name or last name');</script>");
                    return;
                }

                string cs = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=db; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    string query;
                    if (!string.IsNullOrEmpty(firstName))
                    {
                        query = "DELETE FROM demo WHERE FirstName = @firstName";
                    }
                    else
                    {
                        query = "DELETE FROM demo WHERE LastName = @lastName";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrEmpty(firstName))
                        {
                            cmd.Parameters.AddWithValue("@firstName", firstName);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@lastName", lastName);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write($"<script>alert('Record deleted successfully');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No record found with the specified name');</script>");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write($"<script>alert('Database error: {sqlEx.Message}');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                Response.Write($"Error Type: {ex.GetType()}<br/>");
                Response.Write($"Stack Trace: {ex.StackTrace}<br/>");
            }
        }
    }
}