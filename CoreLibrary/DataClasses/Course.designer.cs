using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using HomeworkPlus.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace HomeworkPlus.Lib.DataClasses
{                            
    public partial class Course
    {
        private void InitPoco()
        {
            
            
                this.Assignments = new BindingList<Assignment>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CourseId")]
        public String CourseId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "When")]
        public String When { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Assignments")]
        public BindingList<Assignment> Assignments { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Assignments, and load them if requested
        /// </summary>
        public static void CheckExpandAssignments(SqlDataManager sdm, IEnumerable<Course> courses, string expandString)
        {
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("assignments", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var coursesWhere = CreateCourseWhere(courses, "Course");
                var childAssignments = sdm.GetAllAssignments<Assignment>(coursesWhere)
                .OrderBy(orderBy => orderBy.Name)
            ;

                courses.ToList()
                        .ForEach(feCourse => feCourse.LoadAssignments(childAssignments));
            }

        }


        

        
        /// <summary>
        /// Find the related Assignments (from the list provided) and attach them locally to the Assignments list.
        /// </summary>
        public void LoadAssignments(IEnumerable<Assignment> assignments)
        {
            assignments.Where(whereAssignment => whereAssignment.Course == this.CourseId)
                    .ToList()
                    .ForEach(feAssignment => this.Assignments.Add(feAssignment));
        }
        

        
        
        private static string CreateCourseWhere(IEnumerable<Course> courses, String forignKeyFieldName = "CourseId")
        {
            if (!courses.Any()) return "1=1";
            else 
            {
                var idList = courses.Select(selectCourse => String.Format("'{0}'", selectCourse.CourseId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Course> courses, string expandString)
        {
            
            
            
            CheckExpandAssignments(sdm, courses, expandString);
        }
        
    }
}
