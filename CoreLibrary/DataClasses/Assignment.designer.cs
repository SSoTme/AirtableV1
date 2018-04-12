using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using HomeworkPlus.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace HomeworkPlus.Lib.DataClasses
{                            
    public partial class Assignment
    {
        private void InitPoco()
        {
            
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AssignmentId")]
        public String AssignmentId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Course")]
        public String Course { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DueDate")]
        public Nullable<DateTime> DueDate { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsComplete")]
        public Nullable<Boolean> IsComplete { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    

        

        
        
        private static string CreateAssignmentWhere(IEnumerable<Assignment> assignments, String forignKeyFieldName = "AssignmentId")
        {
            if (!assignments.Any()) return "1=1";
            else 
            {
                var idList = assignments.Select(selectAssignment => String.Format("'{0}'", selectAssignment.AssignmentId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Assignment> assignments, string expandString)
        {
            
        }
        
    }
}
