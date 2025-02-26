using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{


    public class DocumentApiResponse
    {
        public List<FileTypeOptionsItem> fileTypeOptions { get; set; }
        public List<FileCategoryOptionsItem> fileCategoryOptions { get; set; }
        public List<string> subCategoryOptions { get; set; }
        public List<PageDataItem> pageData { get; set; }
        //public DefaultData defaultData { get; set; }
        public int maxFileSize { get; set; }
    }
    public class FileTypeOptionsItem
        {
            public string id { get; set; }
            public string fileTypeDescription { get; set; }
            public int fileCategoryId { get; set; }
            //public bool isSystemGenerated { get; set; }
            //public int defaultEmployeeAccessLevelId { get; set; }
            //public int defaultManagerAccessLevelId { get; set; }
            //public int defaultSupervisorAccessLevelId { get; set; }
            //public bool isInactive { get; set; }
        }

        public class FileCategoryOptionsItem
        {
            public int id { get; set; }
            public string description { get; set; }
            public bool isRestricted { get; set; }
        }

        public class PayrollItem
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            public bool isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public int clientMessageAttachmentId { get; set; }
            //public int systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class ConfidentialPHIItem
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            //public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class ConfidentialOtherItem
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            //public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            public bool isNew { get; set; }
            public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            public int employeeAccessLevelId { get; set; }
            public int managerAccessLevelId { get; set; }
            public int supervisorAccessLevelId { get; set; }
            public int currentUserAccessLevelId { get; set; }
        }

        public class SignedAcknowledgementsItem
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public string isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class PageDataItem
        {
            public List<string> personnel { get; set; }
            public List<PayrollItem> payroll { get; set; }
            public List<string> i9 { get; set; }
            public List<ConfidentialPHIItem> confidentialPHI { get; set; }
            public List<ConfidentialOtherItem> confidentialOther { get; set; }
            public List<SignedAcknowledgementsItem> signedAcknowledgements { get; set; }
            public List<string> other { get; set; }
            public List<string> eeUploads { get; set; }
        }

        public class Personnel
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public bool allowSubcategoryModifications { get; set; }
            //public int clientMessageAttachmentId { get; set; }
            //public int systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class Payroll
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public int fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public string isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class I9
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public bool allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public bool preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public string isChanged { get; set; }
            //public string isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class ConfidentialPHI
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public bool allowSubcategoryModifications { get; set; }
            //public int clientMessageAttachmentId { get; set; }
            //public int systemMessageAttachmentId { get; set; }
            //public bool preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class ConfidentialOther
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public bool allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public bool preventDelete { get; set; }
            //public bool isNew { get; set; }
            //public bool isChanged { get; set; }
            //public bool isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class SignedAcknowledgements
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public bool isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public string isNew { get; set; }
            //public string isChanged { get; set; }
            //public string isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class Other
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public string isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public string isNew { get; set; }
            //public string isChanged { get; set; }
            //public string isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        public class EeUploads
        {
            public int id { get; set; }
            public string fileType { get; set; }
            public string fileTypeId { get; set; }
            public int fileCategoryId { get; set; }
            public string fileSubCategoryId { get; set; }
            public string fileTypeName { get; set; }
            public string fileName { get; set; }
            public string uploadDate { get; set; }
            public string attachmentDescription { get; set; }
            //public string isAlternateRecord { get; set; }
            //public string allowSubcategoryModifications { get; set; }
            //public string clientMessageAttachmentId { get; set; }
            //public string systemMessageAttachmentId { get; set; }
            //public string preventDelete { get; set; }
            //public string isNew { get; set; }
            //public string isChanged { get; set; }
            //public string isDeleted { get; set; }
            //public int employeeAccessLevelId { get; set; }
            //public int managerAccessLevelId { get; set; }
            //public int supervisorAccessLevelId { get; set; }
            //public int currentUserAccessLevelId { get; set; }
        }

        //public class DefaultData
        //{
        //    //public   { get; set; }
        //    public Personnel personnel { get; set; }
        //    public Payroll payroll { get; set; }
        //    public I9 i9 { get; set; }
        //    public ConfidentialPHI confidentialPHI { get; set; }
        //    public ConfidentialOther confidentialOther { get; set; }
        //    public SignedAcknowledgements signedAcknowledgements { get; set; }
        //    public Other other { get; set; }
        //    public EeUploads eeUploads { get; set; }
        //}

        

    

}
