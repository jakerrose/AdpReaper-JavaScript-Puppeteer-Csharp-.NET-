using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    public class DominionEmployeeDocMetadataLifeWell
    {
        public DominionEmpDocMetaFileTypeLifeWell[] fileTypeOptions { get; set; }
        public DominionEmpDocMetaFileCatLifeWell[] fileCategoryOptions { get; set; }
        public DominionEmpDocMetaSubCatLifeWell[] subCategoryOptions { get; set; }
        public DominionEmpDocMetaPageDataLifeWell[] pageData { get; set; }
        public DominionEmpDocMetaDefaultDataLifeWell defaultData { get; set; }
        public int maxFileSize { get; set; }
    }

    public class DominionEmpDocMetaFileTypeLifeWell
    {
        public string id { get; set; }
        public string fileTypeDescription { get; set; }
        public int? fileCategoryId { get; set; }
        public bool isSystemGenerated { get; set; }
        public int defaultEmployeeAccessLevelId { get; set; }
        public int defaultManagerAccessLevelId { get; set; }
        public int defaultSupervisorAccessLevelId { get; set; }
        public bool isInactive { get; set; }
    }

    public class DominionEmpDocMetaFileCatLifeWell
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool isRestricted { get; set; }
    }

    public class DominionEmpDocMetaSubCatLifeWell
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool isRestricted { get; set; }
    }

    public class DominionEmpDocMetaPageDataLifeWell
    {
        public DominionEmpDocMetaPageDatumLifeWell[] personnel { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] payroll { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] i9 { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] confidentialPHI { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] confidentialOther { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] signedAcknowledgements { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] other { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell[] eeUploads { get; set; }
    }

    public class DominionEmpDocMetaDefaultDataLifeWell
    {
        public DominionEmpDocMetaPageDatumLifeWell personnel { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell payroll { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell i9 { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell confidentialPHI { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell confidentialOther { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell signedAcknowledgements { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell other { get; set; }
        public DominionEmpDocMetaPageDatumLifeWell eeUploads { get; set; }
    }

    public class DominionEmpDocMetaPageDatumLifeWell
    {
        public int id { get; set; }
        public string fileType { get; set; }
        public string fileTypeId { get; set; }
        public int? fileCategoryId { get; set; }
        public int? fileSubCategoryId { get; set; }
        public string fileTypeName { get; set; }
        public string fileName { get; set; }
        public string uploadDate { get; set; }
        public string attachmentDescription { get; set; }
        public bool isAlternateRecord { get; set; }
        public bool allowSubcategoryModifications { get; set; }
        public string clientMessageAttachmentId { get; set; }
        public string systemMessageAttachmentId { get; set; }
        public bool preventDelete { get; set; }
        public bool isNew { get; set; }
        public bool isChanged { get; set; }
        public bool isDeleted { get; set; }
        public int employeeAccessLevelId { get; set; }
        public int managerAccessLevelId { get; set; }
        public int supervisorAccessLevelId { get; set; }
        public int currentUserAccessLevelId { get; set; }
    }
}
