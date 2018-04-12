using HomeworkPlus.Lib.SqlDataManagement;
using HomeworkPlus.Lib.DataClasses;
using dc=HomeworkPlus.Lib.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApplication1.Areas.RESTApi.Controllers
{
    public partial class CoursesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<Course> Courses);
        partial void OnAfterGetById(Course Courses, String courseId);
        partial void OnBeforePost(Course course);
        partial void OnAfterPost(Course course);
        partial void OnBeforePut(Course course);
        partial void OnAfterPut(Course course);
        partial void OnBeforeDelete(Course course);
        partial void OnAfterDelete(Course course);
        

        public CoursesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }

        /// <summary>
        /// GET api/Course - Gets a list of Courses
        /// </summary>
        /// <returns>List of Courses</returns>
        public IEnumerable<Course> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllCourses<Course>()
                            .OrderBy(orderBy => orderBy.Name);
            dc.Course.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        /// <summary>
        /// Gets a specific Course based on it's ID
        /// </summary>
        /// <returns>Course</returns>
        public Course Get(String courseId)
        {
            var CoursesWhere = String.Format("CourseId = '{0}'", courseId);
            var result = this.SDM.GetAllCourses<Course>(CoursesWhere).FirstOrDefault();
            dc.Course.CheckExpand(this.SDM, new Course[] { result }, HttpContext.Current.Request["expand"]);
            this.OnAfterGetById(result, courseId);
            return result;
        }

        /// <summary>
        /// Inserts a new Course
        /// </summary>
        /// <returns>The inserted Course, including the ID assigned</returns>
        public Course Post([FromBody]Course course)
        {// text
            
            if (String.IsNullOrEmpty(course.CourseId)) course.CourseId = Guid.NewGuid().ToString();
            this.OnBeforePost(course);
            this.SDM.Upsert(course);
            this.OnAfterPost(course);
            return course;
        }

        /// <summary>
        /// Updates a specific Course based on it's ID
        /// </summary>
        /// <returns>Course</returns>
        public Course Put([FromBody]Course course)
        {
            
            if (String.IsNullOrEmpty(course.CourseId)) course.CourseId = Guid.NewGuid().ToString();
            this.OnBeforePut(course);
            this.SDM.Upsert(course);
            this.OnAfterPut(course);
            return course;
        }

        /// <summary>
        /// Deletes a specific Course based on it's ID
        /// </summary>
        /// <returns>Course</returns>
        public void Delete(Guid CourseId)
        {
            var courseWhere = String.Format("CourseId = '{0}'", CourseId);
            var course = this.SDM.GetAllCourses<Course>(courseWhere).FirstOrDefault();
            this.OnBeforeDelete(course);
            this.SDM.Delete(course);
            this.OnAfterDelete(course);
        }
    }
}
