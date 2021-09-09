namespace Ar.Common.Authorization
{
    public static class PermissionTypes
    {
        #region Permissions for Param Management und Data Export

        public const string PM_ImportFiles = "pm.importFiles";
        
        public const string PM_ReadDataSources = "pm.readDataSources";

        public const string PM_ReadMappings = "pm.readMappings";

        public const string PM_WriteMappings = "pm.writeMappings";

        public const string PM_ExportData = "pm.exportData";

        #endregion

        #region Permissions for Data Access Layer

        public const string DAL_ReadData = "dal.readData";

        #endregion

        #region Permissions for Dashboard

        public const string Dashboard_View= "dashboard.view";

        public const string Dashboard_Edit = "dashboard.edit";
        
        #endregion

        #region Permisssions for Data Control Center

        public const string DCC_ReadValidations = "dcc.readValidations";

        #endregion

        #region permissions for Identity Server

        public const string IDS_Administrator = "ids.Administrator";

        #endregion
    }
}
