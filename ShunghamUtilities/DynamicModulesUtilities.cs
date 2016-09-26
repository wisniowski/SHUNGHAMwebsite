using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;

namespace ShunghamUtilities
{
    public class DynamicModulesUtilities
    {
        /// <summary>
        /// Gets dynamic content items by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IQueryable<DynamicContent> GetDataItemsByType(string type)
        {
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
            Type resolvedType = TypeResolutionService.ResolveType(type);

            // Fetch a collection of "live" and "visible" items.
            var myCollection = dynamicModuleManager.GetDataItems(resolvedType)
                .Where(i => i.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live && i.Visible == true);

            return myCollection;
        }

        public static string GetDataItemTitleById(string type, Guid id)
        {
            string title = string.Empty;
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
            Type resolvedType = TypeResolutionService.ResolveType(type);

            var item = dynamicModuleManager.GetDataItem(resolvedType, id);

            if (item != null)
            {
                title = item.GetString("Title");
            }

            return title;
        } 
    }
}
