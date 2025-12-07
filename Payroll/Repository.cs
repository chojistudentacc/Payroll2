using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Payroll.Models;

namespace Payroll
{
    public class Repository
    {

        private string csvFilePath = @"C:\Users\User\Documents\EmployeeArchive.csv";
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Source\\Repos\\Payroll3\\Payroll\\Payroll.mdf;Integrated Security=True";


        public int GetEmailDataRowCount()
        {
            int rowCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT COUNT(*) FROM emailData";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        rowCount = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Count Error: " + ex.ToString());
            }

            return rowCount;
        }

        public DataTable GetAllEmailData()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT header, body, tail, senderFullName, date FROM emailData ORDER BY date DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Emails Error: " + ex.ToString());
            }

            return table;
        }

        public DataTable SearchEmployees(string role, string keyword)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string tableName = "";
                    if (role == "Employee") tableName = "employeeData";
                    else if (role == "Accountant") tableName = "accountantData";
                    else if (role == "Human Resources") tableName = "hrData";

                    string sql = $@"
                    SELECT employeeID, email, contactNum, address,
                    lastName, firstName, middleName, status
                    FROM {tableName}
                    WHERE employeeID LIKE @keyword OR lastName LIKE @keyword;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.ToString());
            }

            return table;
        }

        public string GetStatus(string employeeID, string role)
        {
            string status = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string tableName = role switch
                    {
                        "Employee" => "employeeData",
                        "Accountant" => "accountantData",
                        "Human Resources" => "hrData",
                        _ => null
                    };

                    if (string.IsNullOrEmpty(tableName))
                        throw new ArgumentException("Invalid role specified.");

                    string query = $"SELECT status FROM {tableName} WHERE employeeID = @employeeID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            status = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee status: " + ex.Message);
            }

            return status;
        }


        public string getPassword(string id, string role)
        {
            string tableName = "";

            if (role == "Employee")
                tableName = "employeeData";
            else if (role == "Accountant")
                tableName = "accountantData";
            else if (role == "Human Resources")
                tableName = "hrData";
            else
                return "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = $"SELECT password FROM {tableName} WHERE employeeID = @employeeID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@employeeID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return "";
        }

        public string getAccountantID(string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT employeeID FROM accountantData WHERE userName=@userName;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }
            return "";
        }

        public string getAdminID(string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT adminID FROM adminData WHERE userName=@userName;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }
            return "";
        }

        public bool IsAdminDataEmpty()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM adminData;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        return count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return false;
            }
        }

        public string GetNextAdminID()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT adminID FROM adminData WHERE adminID LIKE 'ADMN-%';";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int maxNumber = 0;
                            while (reader.Read())
                            {
                                string adminID = reader.GetString(0);
                                if (adminID.StartsWith("ADMN-"))
                                {
                                    string numberPart = adminID.Substring(5);
                                    if (int.TryParse(numberPart, out int number))
                                    {
                                        if (number > maxNumber)
                                        {
                                            maxNumber = number;
                                        }
                                    }
                                }
                            }
                            return "ADMN-" + (maxNumber + 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return null;
            }
        }

        public string GetNextEmployeeID()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(employeeID, 5, LEN(employeeID)) AS INT)), 0) 
                           FROM employeeData 
                           WHERE employeeID LIKE 'EMP-%';";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int maxNumber = (int)command.ExecuteScalar();
                        int nextNumber = maxNumber + 1;
                        return "EMP-" + nextNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return null;
            }
        }

        public string GetNextAccountantID()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(employeeID, 5, LEN(employeeID)) AS INT)), 0) 
                           FROM accountantData 
                           WHERE employeeID LIKE 'ACC-%';";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int maxNumber = (int)command.ExecuteScalar();
                        int nextNumber = maxNumber + 1;
                        return "ACC-" + nextNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return null;
            }
        }

        public string GetNextHRID()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(employeeID, 4, LEN(employeeID)) AS INT)), 0) FROM hrData WHERE employeeID LIKE 'HR-%';";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int maxNumber = (int)command.ExecuteScalar();
                        int nextNumber = maxNumber + 1;
                        return "HR-" + nextNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return null;
            }
        }

        public DataTable GetAllEmployee()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    employeeID,
                    email,
                    contactNum,
                    address,
                    lastName,
                    firstName,
                    middleName,
                    status
                    FROM employeeData;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }


        public DataTable GetAllAccountant()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    employeeID,
                    email,
                    contactNum,
                    address,
                    lastName,
                    firstName,
                    middleName,
                    status
                    FROM accountantData;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public DataTable GetAllHR()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    employeeID,
                    email,
                    contactNum,
                    address,
                    lastName,
                    firstName,
                    middleName,
                    status
                    FROM hrData;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public bool AuthenticateEmployee(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM employeeData WHERE userName COLLATE SQL_Latin1_General_CP1_CS_AS = @userName AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return false;
            }
        }

        public bool AuthenticateAccountant(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM accountantData WHERE userName COLLATE SQL_Latin1_General_CP1_CS_AS = @userName AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return false;
            }
        }

        public bool AuthenticateHr(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM hrData WHERE userName COLLATE SQL_Latin1_General_CP1_CS_AS = @userName AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return false;
            }
        }

        public bool AuthenticateAdmin(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM adminData WHERE userName COLLATE SQL_Latin1_General_CP1_CS_AS = @userName AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return false;
            }
        }

        public string AuthenticateUser(string userName, string password)
        {
            if (AuthenticateEmployee(userName, password))
            {
                return "employee";
            }
            if (AuthenticateAccountant(userName, password))
            {
                return "accountant";
            }
            if (AuthenticateAdmin(userName, password))
            {
                return "admin";
            }
            if (AuthenticateHr(userName, password))
            {
                return "hr";
            }
            return null;
        }

        public bool DropEmployee(string employeeID, string role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string tableName = role switch
                    {
                        "Employee" => "employeeData",
                        "Accountant" => "accountantData",
                        "Human Resources" => "hrData",
                        _ => null
                    };

                    if (string.IsNullOrEmpty(tableName))
                        throw new ArgumentException("Invalid role specified.");

                    string query = $"DELETE FROM {tableName} WHERE employeeID = @employeeID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dropping employee: " + ex.Message);
                return false;
            }
        }


        public void ExportEmployeeToArchive(DataRow employeeData, string role)
        {
            string filePath = csvFilePath;

            bool fileExists = File.Exists(filePath);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                if (!fileExists)
                {
                    sw.WriteLine("EmployeeID,FirstName,LastName,MiddleName,Address,ContactNum,Email,Role,Status");
                }

                sw.WriteLine(
                    $"{employeeData["employeeID"]}," +
                    $"{employeeData["firstName"]}," +
                    $"{employeeData["lastName"]}," +
                    $"{employeeData["middleName"]}," +
                    $"{employeeData["address"]}," +
                    $"{employeeData["contactNum"]}," +
                    $"{employeeData["email"]}," +
                    $"{role}," +
                    $"{employeeData["status"]}"
                );
            }
        }

        public bool AddEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"INSERT INTO employeeData (userName, password, employeeID, email, contactNum, address, lastName, firstName, middleName, status) VALUES (@userName, @password, @employeeID, @email, @contactNum, @address, @lastName, @firstName, @middleName, @status);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", emp.UserName);
                        command.Parameters.AddWithValue("@password", emp.Password);
                        command.Parameters.AddWithValue("@employeeID", GetNextEmployeeID());
                        command.Parameters.AddWithValue("@email", emp.Email);
                        command.Parameters.AddWithValue("@contactNum", emp.ContactNum);
                        command.Parameters.AddWithValue("@address", emp.Address);
                        command.Parameters.AddWithValue("@lastName", emp.LastName);
                        command.Parameters.AddWithValue("@firstName", emp.FirstName);
                        command.Parameters.AddWithValue("@middleName", emp.MiddleName);
                        command.Parameters.AddWithValue("@status", emp.Status);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.ToString());
                return false;
            }
        }

        public bool AddAccountant(Accountant acc)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"INSERT INTO accountantData (userName, password, employeeID, email, contactNum, address, lastName, firstName, middleName, status) VALUES (@userName, @password, @employeeID, @email, @contactNum, @address, @lastName, @firstName, @middleName, @status);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", acc.UserName);
                        command.Parameters.AddWithValue("@password", acc.Password);
                        command.Parameters.AddWithValue("@employeeID", GetNextAccountantID());
                        command.Parameters.AddWithValue("@email", acc.Email);
                        command.Parameters.AddWithValue("@contactNum", acc.ContactNum);
                        command.Parameters.AddWithValue("@address", acc.Address);
                        command.Parameters.AddWithValue("@lastName", acc.LastName);
                        command.Parameters.AddWithValue("@firstName", acc.FirstName);
                        command.Parameters.AddWithValue("@middleName", acc.MiddleName);
                        command.Parameters.AddWithValue("@status", acc.Status);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding accountant: " + ex.ToString());
                return false;
            }
        }

        public bool addHr(HumanResources hr)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"INSERT INTO hrData (userName, password, employeeID, email, contactNum, address, lastName, firstName, middleName, status) VALUES (@userName, @password, @employeeID, @email, @contactNum, @address, @lastName, @firstName, @middleName, @status);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userName", hr.UserName);
                        command.Parameters.AddWithValue("@password", hr.Password);
                        command.Parameters.AddWithValue("@employeeID", GetNextHRID());
                        command.Parameters.AddWithValue("@email", hr.Email);
                        command.Parameters.AddWithValue("@contactNum", hr.ContactNum);
                        command.Parameters.AddWithValue("@address", hr.Address);
                        command.Parameters.AddWithValue("@lastName", hr.LastName);
                        command.Parameters.AddWithValue("@firstName", hr.FirstName);
                        command.Parameters.AddWithValue("@middleName", hr.MiddleName);
                        command.Parameters.AddWithValue("@status", hr.Status);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding HR: " + ex.ToString());
                return false;
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE employeeData SET
                    password   = @password,
                    email      = @Email,
                    contactNum = @ContactNum,
                    address    = @Address,
                    lastName   = @LastName,
                    firstName  = @FirstName,
                    middleName = @MiddleName,
                    status     = @Status
                    WHERE employeeID = @EmployeeID;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@password", emp.Password);
                        cmd.Parameters.AddWithValue("@Email", emp.Email);
                        cmd.Parameters.AddWithValue("@ContactNum", emp.ContactNum);
                        cmd.Parameters.AddWithValue("@Address", emp.Address);
                        cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                        cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", emp.MiddleName);
                        cmd.Parameters.AddWithValue("@Status", emp.Status);
                        cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Employee: " + ex);
                return false;
            }
        }

        public bool UpdateAccountant(Accountant acc)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE accountantData SET
                    password   = @Password,
                    email      = @Email,
                    contactNum = @ContactNum,
                    address    = @Address,
                    lastName   = @LastName,
                    firstName  = @FirstName,
                    middleName = @MiddleName,
                    status     = @Status
                    WHERE employeeID = @EmployeeID;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Password", acc.Password);
                        cmd.Parameters.AddWithValue("@Email", acc.Email);
                        cmd.Parameters.AddWithValue("@ContactNum", acc.ContactNum);
                        cmd.Parameters.AddWithValue("@Address", acc.Address);
                        cmd.Parameters.AddWithValue("@LastName", acc.LastName);
                        cmd.Parameters.AddWithValue("@FirstName", acc.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", acc.MiddleName);
                        cmd.Parameters.AddWithValue("@Status", acc.Status);
                        cmd.Parameters.AddWithValue("@EmployeeID", acc.EmployeeID);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Accountant: " + ex);
                return false;
            }
        }


        public bool UpdateHR(HumanResources hr)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE hrData SET
                    password   = @Password,
                    email      = @Email,
                    contactNum = @ContactNum,
                    address    = @Address,
                    lastName   = @LastName,
                    firstName  = @FirstName,
                    middleName = @MiddleName,
                    status     = @Status
                    WHERE employeeID = @EmployeeID;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Password", hr.Password);
                        cmd.Parameters.AddWithValue("@Email", hr.Email);
                        cmd.Parameters.AddWithValue("@ContactNum", hr.ContactNum);
                        cmd.Parameters.AddWithValue("@Address", hr.Address);
                        cmd.Parameters.AddWithValue("@LastName", hr.LastName);
                        cmd.Parameters.AddWithValue("@FirstName", hr.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", hr.MiddleName);
                        cmd.Parameters.AddWithValue("@Status", hr.Status);
                        cmd.Parameters.AddWithValue("@EmployeeID", hr.EmployeeID);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating HR: " + ex);
                return false;
            }
        }


        public int GetEmployeeCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM employeeData;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return 0;
            }
        }

        public int GetAccountantCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM accountantData;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return 0;
            }
        }

        public int GetHRCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM hrData;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
                return 0;
            }
        }

        public int GetTotalEmployeeCount()
        {
            return GetEmployeeCount() + GetAccountantCount() + GetHRCount();
        }

        public DataTable GetEmployeeNames()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    (firstName + ' ' + lastName) AS EmployeeName,
                    employeeID
                    FROM employeeData
                    WHERE status = 'Active'
                    ORDER BY firstName, lastName;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public DataTable GetHRNames()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    (firstName + ' ' + lastName) AS EmployeeName,
                    employeeID
                    FROM hrData
                    WHERE status = 'Active'
                    ORDER BY firstName, lastName;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public bool AddDepartment(string departmentName, string assignedManager, string managerName, string description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"INSERT INTO departmentData (departmentName, assignedManager, managerName, description) VALUES (@departmentName, @assignedManager, @managerName, @description);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@departmentName", departmentName);
                        command.Parameters.AddWithValue("@assignedManager", assignedManager);
                        command.Parameters.AddWithValue("@managerName", managerName);
                        command.Parameters.AddWithValue("@description", description);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding department: " + ex.ToString());
                return false;
            }
        }

        public DataTable GetAllDepartments()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT 
                    departmentName AS Department,
                    assignedManager AS ManagerID,
                    managerName AS ManagerName,
                    description
                    FROM departmentData;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }
        public DataTable GetAssignedManagers()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT DISTINCT
                    managerName AS EmployeeName,
                    assignedManager AS employeeID
                    FROM departmentData
                    WHERE assignedManager IS NOT NULL
                    ORDER BY managerName;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public bool UpdateDepartment(string originalDepartmentName, string departmentName, string assignedManager, string managerName, string description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE departmentData SET
                    departmentName = @departmentName,
                    assignedManager = @assignedManager,
                    managerName = @managerName,
                    description = @description
                    WHERE departmentName = @originalDepartmentName;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@originalDepartmentName", originalDepartmentName);
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);
                        cmd.Parameters.AddWithValue("@assignedManager", assignedManager);
                        cmd.Parameters.AddWithValue("@managerName", managerName);
                        cmd.Parameters.AddWithValue("@description", description);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating department: " + ex.ToString());
                return false;
            }
        }

        public bool DeleteDepartment(string departmentName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    DELETE FROM departmentData
                    WHERE departmentName = @departmentName;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting department: " + ex.ToString());
                return false;
            }
        }

        public bool AddLog(string adminName, string activity, string details)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    INSERT INTO logsData (date, Name, activity, details)
                    VALUES (@date, @name, @activity, @details);
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@name", adminName);
                        cmd.Parameters.AddWithValue("@activity", activity);
                        cmd.Parameters.AddWithValue("@details", details ?? string.Empty);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding log: " + ex.ToString());
                return false;
            }
        }

        public DataTable GetAllLogs()
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT
                    Id,
                    date,
                    Name,
                    activity,
                    details
                    FROM logsData
                    ORDER BY date DESC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        public DataTable GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    SELECT
                    Id,
                    date,
                    Name,
                    activity,
                    details
                    FROM logsData
                    WHERE date >= @startDate AND date < DATEADD(day, 1, @endDate)
                    ORDER BY date DESC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Exception: " + ex.ToString());
            }

            return table;
        }

        
    }
}