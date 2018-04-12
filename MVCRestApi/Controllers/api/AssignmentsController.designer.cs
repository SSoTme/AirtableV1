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
    public partial class AssignmentsController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<Assignment> Assignments);
        partial void OnAfterGetById(Assignment Assignments, String assignmentId);
        partial void OnBeforePost(Assignment assignment);
        partial void OnAfterPost(Assignment assignment);
        partial void OnBeforePut(Assignment assignment);
        partial void OnAfterPut(Assignment assignment);
        partial void OnBeforeDelete(Assignment assignment);
        partial void OnAfterDelete(Assignment assignment);
        

        public AssignmentsController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }

        /// <summary>
        /// GET api/Assignment - Gets a list of Assignments
        /// </summary>
        /// <returns>List of Assignments</returns>
        public IEnumerable<Assignment> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllAssignments<Assignment>()
                            .OrderBy(orderBy => orderBy.Name);
            dc.Assignment.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        /// <summary>
        /// Gets a specific Assignment based on it's ID
        /// </summary>
        /// <returns>Assignment</returns>
        public Assignment Get(String assignmentId)
        {
            var AssignmentsWhere = String.Format("AssignmentId = '{0}'", assignmentId);
            var result = this.SDM.GetAllAssignments<Assignment>(AssignmentsWhere).FirstOrDefault();
            dc.Assignment.CheckExpand(this.SDM, new Assignment[] { result }, HttpContext.Current.Request["expand"]);
            this.OnAfterGetById(result, assignmentId);
            return result;
        }

        /// <summary>
        /// Inserts a new Assignment
        /// </summary>
        /// <returns>The inserted Assignment, including the ID assigned</returns>
        public Assignment Post([FromBody]Assignment assignment)
        {// text
            
            if (String.IsNullOrEmpty(assignment.AssignmentId)) assignment.AssignmentId = Guid.NewGuid().ToString();
            this.OnBeforePost(assignment);
            this.SDM.Upsert(assignment);
            this.OnAfterPost(assignment);
            return assignment;
        }

        /// <summary>
        /// Updates a specific Assignment based on it's ID
        /// </summary>
        /// <returns>Assignment</returns>
        public Assignment Put([FromBody]Assignment assignment)
        {
            
            if (String.IsNullOrEmpty(assignment.AssignmentId)) assignment.AssignmentId = Guid.NewGuid().ToString();
            this.OnBeforePut(assignment);
            this.SDM.Upsert(assignment);
            this.OnAfterPut(assignment);
            return assignment;
        }

        /// <summary>
        /// Deletes a specific Assignment based on it's ID
        /// </summary>
        /// <returns>Assignment</returns>
        public void Delete(Guid AssignmentId)
        {
            var assignmentWhere = String.Format("AssignmentId = '{0}'", AssignmentId);
            var assignment = this.SDM.GetAllAssignments<Assignment>(assignmentWhere).FirstOrDefault();
            this.OnBeforeDelete(assignment);
            this.SDM.Delete(assignment);
            this.OnAfterDelete(assignment);
        }
    }
}
