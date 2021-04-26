using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_TasksRepository
    {
        WP_Tasks GetRecord (string Id);
        IEnumerable<WP_Tasks> GetRecordsByCategoryMain  (string recid);
        IEnumerable<WP_Tasks> GetRecordsByReference_Id (string recid);

        //Programme Tasks
        IEnumerable<WP_Tasks> GetRecordsByDirDivDeptTypeAndStatus (int dirid, int divid, string depttype, string status);
        IEnumerable<WP_Tasks> GetRecordsByCategoryDirDivDeptTypeAndStatus (string category, int dirid, int divid, string depttype, string status);




        //Procurement Department Tasks
        WP_Tasks GetRecordByCategoryReferenceIdAndStatus (string category, string referenceid, string status);

        WP_Tasks GetRecordByCategoryReferenceIdDirDivDeptTypeAndStatus (string category, string referenceid,  int dirid, int divid, string depttype, string status);
        WP_Tasks GetRecordBySubcategory1ReferenceIdAndStatus (string subcategory1, string referenceid, string status);
        WP_Tasks GetRecordBySubcategory1ReferenceIdDirDivDeptTypeAndStatus (string subcategory1, string referenceid, int dirid, int divid, string depttype, string status);



        IEnumerable<WP_Tasks> GetAllRecords();

        WP_Tasks GetRecordByCategoryReferenceIdSubcategory1AndTask (string category, string referenceid, string subcategory1, string task);

    
        WP_Tasks Add(WP_Tasks rec);
        WP_Tasks Update(WP_Tasks recChanges);
        WP_Tasks Delete(string id);
         
    }
}