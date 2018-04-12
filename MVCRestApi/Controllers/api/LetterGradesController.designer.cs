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
    public partial class LetterGradesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<LetterGrade> LetterGrades);
        partial void OnAfterGetById(LetterGrade LetterGrades, String letterGradeId);
        partial void OnBeforePost(LetterGrade lettergrade);
        partial void OnAfterPost(LetterGrade lettergrade);
        partial void OnBeforePut(LetterGrade lettergrade);
        partial void OnAfterPut(LetterGrade lettergrade);
        partial void OnBeforeDelete(LetterGrade lettergrade);
        partial void OnAfterDelete(LetterGrade lettergrade);
        

        public LetterGradesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }

        /// <summary>
        /// GET api/LetterGrade - Gets a list of LetterGrades
        /// </summary>
        /// <returns>List of LetterGrades</returns>
        public IEnumerable<LetterGrade> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllLetterGrades<LetterGrade>()
                            .OrderBy(orderBy => orderBy.Name);
            dc.LetterGrade.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        /// <summary>
        /// Gets a specific LetterGrade based on it's ID
        /// </summary>
        /// <returns>LetterGrade</returns>
        public LetterGrade Get(String letterGradeId)
        {
            var LetterGradesWhere = String.Format("LetterGradeId = '{0}'", letterGradeId);
            var result = this.SDM.GetAllLetterGrades<LetterGrade>(LetterGradesWhere).FirstOrDefault();
            dc.LetterGrade.CheckExpand(this.SDM, new LetterGrade[] { result }, HttpContext.Current.Request["expand"]);
            this.OnAfterGetById(result, letterGradeId);
            return result;
        }

        /// <summary>
        /// Inserts a new LetterGrade
        /// </summary>
        /// <returns>The inserted LetterGrade, including the ID assigned</returns>
        public LetterGrade Post([FromBody]LetterGrade lettergrade)
        {// text
            
            if (String.IsNullOrEmpty(lettergrade.LetterGradeId)) lettergrade.LetterGradeId = Guid.NewGuid().ToString();
            this.OnBeforePost(lettergrade);
            this.SDM.Upsert(lettergrade);
            this.OnAfterPost(lettergrade);
            return lettergrade;
        }

        /// <summary>
        /// Updates a specific LetterGrade based on it's ID
        /// </summary>
        /// <returns>LetterGrade</returns>
        public LetterGrade Put([FromBody]LetterGrade lettergrade)
        {
            
            if (String.IsNullOrEmpty(lettergrade.LetterGradeId)) lettergrade.LetterGradeId = Guid.NewGuid().ToString();
            this.OnBeforePut(lettergrade);
            this.SDM.Upsert(lettergrade);
            this.OnAfterPut(lettergrade);
            return lettergrade;
        }

        /// <summary>
        /// Deletes a specific LetterGrade based on it's ID
        /// </summary>
        /// <returns>LetterGrade</returns>
        public void Delete(Guid LetterGradeId)
        {
            var lettergradeWhere = String.Format("LetterGradeId = '{0}'", LetterGradeId);
            var lettergrade = this.SDM.GetAllLetterGrades<LetterGrade>(lettergradeWhere).FirstOrDefault();
            this.OnBeforeDelete(lettergrade);
            this.SDM.Delete(lettergrade);
            this.OnAfterDelete(lettergrade);
        }
    }
}
