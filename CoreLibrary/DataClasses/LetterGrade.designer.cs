using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using HomeworkPlus.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace HomeworkPlus.Lib.DataClasses
{                            
    public partial class LetterGrade
    {
        private void InitPoco()
        {
            
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "LetterGradeId")]
        public String LetterGradeId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PointMin")]
        public Nullable<Int32> PointMin { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PointMincopy")]
        public Nullable<Int32> PointMincopy { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    

        

        
        
        private static string CreateLetterGradeWhere(IEnumerable<LetterGrade> letterGrades, String forignKeyFieldName = "LetterGradeId")
        {
            if (!letterGrades.Any()) return "1=1";
            else 
            {
                var idList = letterGrades.Select(selectLetterGrade => String.Format("'{0}'", selectLetterGrade.LetterGradeId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<LetterGrade> letterGrades, string expandString)
        {
            
        }
        
    }
}
