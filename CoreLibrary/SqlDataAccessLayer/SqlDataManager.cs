/************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************
 Created By: EJ Alexandra - 2016
             An Abstract Level, llc
 License:    Mozilla Public License 2.0
 ************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

using HomeworkPlus.Lib.DataClasses;

using CoreLibrary.Extensions;

namespace HomeworkPlus.Lib.SqlDataManagement
{
    public partial class SqlDataManager : IDisposable
    {
        public SqlDataManager() : this(SqlDataManager.LastConnectionString) 
        {
            this.Schema = "dbo";
        }
    
        public SqlDataManager(String connectionString)
        {
            this.Schema = "dbo";
            this.ConnectionString = connectionString;
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                this.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
        }

        public SqlDataManager(String dataSourceName, String dbName) 
        {
            this.Schema = "dbo";
            this.DataSourceName = dataSourceName;
            this.DBName = dbName;
        }
        
        public void Dispose() 
        {
            this.IsDisposed = true;
        }
        
        public static string LastConnectionString { get; set; }
        public string ConnectionString { get; set; }
        public String DataSourceName { get; set; }
        public String DBName { get; set; }
        public Boolean IsDisposed { get; set; }
        public String Schema { get; set; }
        

  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Assignment assignment)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Assignment] (AssignmentId, Course, DueDate, IsComplete, Notes, Name, createdTime)
                                    VALUES (@AssignmentId, @Course, @DueDate, @IsComplete, @Notes, @Name, @createdTime)", this.Schema);

                
                  
                if (ReferenceEquals(assignment.AssignmentId, null)) cmd.Parameters.AddWithValue("@AssignmentId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AssignmentId", assignment.AssignmentId);
                
                  
                if (ReferenceEquals(assignment.Course, null)) cmd.Parameters.AddWithValue("@Course", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Course", assignment.Course);
                
                  
                if (ReferenceEquals(assignment.DueDate, null)) cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                
                  
                if (ReferenceEquals(assignment.IsComplete, null)) cmd.Parameters.AddWithValue("@IsComplete", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsComplete", assignment.IsComplete);
                
                  
                if (ReferenceEquals(assignment.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", assignment.Notes);
                
                  
                if (ReferenceEquals(assignment.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", assignment.Name);
                
                  
                if (ReferenceEquals(assignment.createdTime, null) ||
                    (assignment.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", assignment.createdTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Assignment assignment)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = assignment.AssignmentId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Assignment] WHERE AssignmentId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(assignment);
                else return this.Insert(assignment);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAssignments<T>()
            where T : Assignment, new()
        {
            return this.GetAllAssignments<T>(String.Empty);
        }

        
        public List<T> GetAllAssignments<T>(String whereClause)
            where T : Assignment, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Assignment]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T assignment = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AssignmentId");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          assignment.AssignmentId = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Course");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          assignment.Course = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("DueDate");
                      if (!reader.IsDBNull(propertyIndex)) //XS:DATE
                      {
                          
                          assignment.DueDate = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("IsComplete");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          assignment.IsComplete = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Notes");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          assignment.Notes = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          assignment.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("createdTime");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          assignment.createdTime = reader.GetDateTime(propertyIndex);
                      }
                   
                    results.Add(assignment);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Assignment
        /// </summary>
        /// <returns></returns>
        public int Update(Assignment assignment)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Assignment] SET 
                                    [Course] = @Course, [DueDate] = @DueDate, [IsComplete] = @IsComplete, [Notes] = @Notes, [Name] = @Name, [createdTime] = @createdTime
                                    WHERE  [AssignmentId] = @AssignmentId", this.Schema);

                 //TEXT
                
                if (ReferenceEquals(assignment.AssignmentId, null)) cmd.Parameters.AddWithValue("@AssignmentId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AssignmentId", assignment.AssignmentId);
                 //TEXT
                
                if (ReferenceEquals(assignment.Course, null)) cmd.Parameters.AddWithValue("@Course", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Course", assignment.Course);
                 //xs:date
                
                if (ReferenceEquals(assignment.DueDate, null)) cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                 //BOOLEAN
                
                if (ReferenceEquals(assignment.IsComplete, null)) cmd.Parameters.AddWithValue("@IsComplete", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsComplete", assignment.IsComplete);
                 //TEXT
                
                if (ReferenceEquals(assignment.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", assignment.Notes);
                 //TEXT
                
                if (ReferenceEquals(assignment.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", assignment.Name);
                 //DATETIME
                
                if (ReferenceEquals(assignment.createdTime, null) ||
                    (assignment.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", assignment.createdTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Assignment
        /// </summary>
        /// <returns></returns>
        public int Delete(Assignment assignment)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Assignment] 
                                    WHERE  [AssignmentId] = @AssignmentId", this.Schema);
                                    
                
                if (ReferenceEquals(assignment.AssignmentId, null)) cmd.Parameters.AddWithValue("@AssignmentId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AssignmentId", assignment.AssignmentId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Course course)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Course] (CourseId, Name, Notes, When, createdTime)
                                    VALUES (@CourseId, @Name, @Notes, @When, @createdTime)", this.Schema);

                
                  
                if (ReferenceEquals(course.CourseId, null)) cmd.Parameters.AddWithValue("@CourseId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                
                  
                if (ReferenceEquals(course.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", course.Name);
                
                  
                if (ReferenceEquals(course.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", course.Notes);
                
                  
                if (ReferenceEquals(course.When, null)) cmd.Parameters.AddWithValue("@When", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@When", course.When);
                
                  
                if (ReferenceEquals(course.createdTime, null) ||
                    (course.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", course.createdTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Course course)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = course.CourseId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Course] WHERE CourseId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(course);
                else return this.Insert(course);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllCourses<T>()
            where T : Course, new()
        {
            return this.GetAllCourses<T>(String.Empty);
        }

        
        public List<T> GetAllCourses<T>(String whereClause)
            where T : Course, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Course]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T course = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("CourseId");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          course.CourseId = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          course.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Notes");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          course.Notes = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("When");
                      if (!reader.IsDBNull(propertyIndex)) //TEXT
                      {
                          
                          course.When = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("createdTime");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          course.createdTime = reader.GetDateTime(propertyIndex);
                      }
                   
                    results.Add(course);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Course
        /// </summary>
        /// <returns></returns>
        public int Update(Course course)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Course] SET 
                                    [Name] = @Name, [Notes] = @Notes, [When] = @When, [createdTime] = @createdTime
                                    WHERE  [CourseId] = @CourseId", this.Schema);

                 //TEXT
                
                if (ReferenceEquals(course.CourseId, null)) cmd.Parameters.AddWithValue("@CourseId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                 //TEXT
                
                if (ReferenceEquals(course.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", course.Name);
                 //TEXT
                
                if (ReferenceEquals(course.Notes, null)) cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Notes", course.Notes);
                 //TEXT
                
                if (ReferenceEquals(course.When, null)) cmd.Parameters.AddWithValue("@When", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@When", course.When);
                 //DATETIME
                
                if (ReferenceEquals(course.createdTime, null) ||
                    (course.createdTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@createdTime", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@createdTime", course.createdTime);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Course
        /// </summary>
        /// <returns></returns>
        public int Delete(Course course)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Course] 
                                    WHERE  [CourseId] = @CourseId", this.Schema);
                                    
                
                if (ReferenceEquals(course.CourseId, null)) cmd.Parameters.AddWithValue("@CourseId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

                  
            
            

        public object LastIdentity { get; set; }
        public string ExecuteAsUser { get; set; }
        
        private SqlConnection CreateSqlConnection() 
        {
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = this.DataSourceName;
                scsb.InitialCatalog = this.DBName;
                scsb.IntegratedSecurity = true;
                this.ConnectionString = scsb.ConnectionString;
            }
            
            SqlDataManager.LastConnectionString = this.ConnectionString;
            
            return new SqlConnection(this.ConnectionString);
        }
        
        
        private void InitializeConnection(SqlConnection conn)
        {
            conn.Open();
            if (!String.IsNullOrEmpty(this.ExecuteAsUser))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("EXECUTE AS USER='{0}'", this.ExecuteAsUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

      