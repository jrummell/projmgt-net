using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace PMT.DAL
{
    /// <summary>
    /// Controller class for CvCMatrix
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CvCMatrixController
    {
        // Preload our schema..
        CvCMatrix thisSchemaLoad = new CvCMatrix();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public CvCMatrixCollection FetchAll()
        {
            CvCMatrixCollection coll = new CvCMatrixCollection();
            Query qry = new Query(CvCMatrix.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CvCMatrixCollection FetchByID(object Competency)
        {
            CvCMatrixCollection coll = new CvCMatrixCollection().Where("Competency", Competency).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CvCMatrixCollection FetchByQuery(Query qry)
        {
            CvCMatrixCollection coll = new CvCMatrixCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Competency)
        {
            return (CvCMatrix.Delete(Competency) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Competency)
        {
            return (CvCMatrix.Destroy(Competency) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Competency,double HighComplexity,double MedComplexity,double LowComplexity)
	    {
		    CvCMatrix item = new CvCMatrix();
		    
            item.Competency = Competency;
            
            item.HighComplexity = HighComplexity;
            
            item.MedComplexity = MedComplexity;
            
            item.LowComplexity = LowComplexity;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Competency,double HighComplexity,double MedComplexity,double LowComplexity)
	    {
		    CvCMatrix item = new CvCMatrix();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Competency = Competency;
				
			item.HighComplexity = HighComplexity;
				
			item.MedComplexity = MedComplexity;
				
			item.LowComplexity = LowComplexity;
				
	        item.Save(UserName);
	    }
    }
}
